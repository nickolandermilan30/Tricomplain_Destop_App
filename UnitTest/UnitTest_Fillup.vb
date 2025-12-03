Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tricomplain

<TestClass>
Public Class UnitTest_FillUp

    ' Helper: create FillUp instance with panels assigned
    Private Function CreateFillUpInstance() As Object
        Dim instance As New FillUp()

        ' Inject panels for fileshow and filedisplay
        Dim fileshowPanel As New Panel()
        Dim filedisplayPanel As New Panel()

        ' Use reflection to set private fields
        Dim t = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic

        Dim fFileshow = t.GetField("fileshow", flags)
        Dim fFiledisplay = t.GetField("filedisplay", flags)

        If fFileshow IsNot Nothing Then fFileshow.SetValue(instance, fileshowPanel)
        If fFiledisplay IsNot Nothing Then fFiledisplay.SetValue(instance, filedisplayPanel)

        Return instance
    End Function

    <TestMethod>
    Public Sub DisplayFile_WithDocx_ShouldPopulateFileshowControls()
        ' Arrange
        Dim tmpFile = Path.Combine(Path.GetTempPath(), "sample.docx")
        File.WriteAllText(tmpFile, "dummy content")

        Dim instance = CreateFillUpInstance()
        Dim t = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic

        ' Act
        Dim method = t.GetMethod("DisplayFile", flags)
        Assert.IsNotNull(method, "DisplayFile method not found")
        method.Invoke(instance, New Object() {tmpFile})

        ' Assert
        Dim fileshowField = t.GetField("fileshow", flags)
        Dim fileshowPanel As Panel = CType(fileshowField.GetValue(instance), Panel)
        Assert.IsTrue(fileshowPanel.Controls.Count > 0, "fileshow should have controls added")

        ' Cleanup
        If File.Exists(tmpFile) Then File.Delete(tmpFile)
    End Sub

    <TestMethod>
    Public Sub AddFileToList_ShouldAddPanelToFiledisplay()
        ' Arrange
        Dim tmpFile = Path.Combine(Path.GetTempPath(), "sample2.docx")
        File.WriteAllText(tmpFile, "dummy content 2")

        Dim instance = CreateFillUpInstance()
        Dim t = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic

        ' Act
        Dim method = t.GetMethod("AddFileToList", flags)
        Assert.IsNotNull(method, "AddFileToList method not found")
        method.Invoke(instance, New Object() {tmpFile})

        ' Assert
        Dim filedisplayField = t.GetField("filedisplay", flags)
        Dim filedisplayPanel As Panel = CType(filedisplayField.GetValue(instance), Panel)
        Assert.IsTrue(filedisplayPanel.Controls.Count > 0, "filedisplay should have a panel added")

        ' check filename in added panel
        Dim found As Boolean = False
        For Each pnl As Control In filedisplayPanel.Controls
            For Each ctrl As Control In pnl.Controls
                If TypeOf ctrl Is Label Then
                    If CType(ctrl, Label).Text = Path.GetFileName(tmpFile) Then
                        found = True
                        Exit For
                    End If
                End If
            Next
            If found Then Exit For
        Next
        Assert.IsTrue(found, "Filename label should exist in panel")

        ' Cleanup
        If File.Exists(tmpFile) Then File.Delete(tmpFile)
    End Sub

End Class
