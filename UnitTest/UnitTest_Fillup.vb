Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tricomplain

<TestClass>
Public Class UnitTest_FillUp

    ' Helper: create FillUp instance with panels assigned
    Private Function CreateFillUpInstance() As FillUp
        Dim instance As New FillUp()

        ' Inject panels for fileshow and filedisplay using reflection
        Dim fileshowPanel As New Panel()
        Dim filedisplayPanel As New Panel()

        Dim t = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic

        t.GetField("fileshow", flags)?.SetValue(instance, fileshowPanel)
        t.GetField("filedisplay", flags)?.SetValue(instance, filedisplayPanel)

        ' Inject a TextBox for bnnumber to avoid null reference
        Dim bnTextBox As New TextBox()
        t.GetField("bnnumber", flags)?.SetValue(instance, bnTextBox)

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
        Dim fileshowPanel As Panel = CType(t.GetField("fileshow", flags).GetValue(instance), Panel)
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
        Dim filedisplayPanel As Panel = CType(t.GetField("filedisplay", flags).GetValue(instance), Panel)
        Assert.IsTrue(filedisplayPanel.Controls.Count > 0, "filedisplay should have a panel added")

        ' Check filename in added panel
        Dim found As Boolean = False
        For Each pnl As Control In filedisplayPanel.Controls
            For Each ctrl As Control In pnl.Controls
                If TypeOf ctrl Is Label AndAlso CType(ctrl, Label).Text = Path.GetFileName(tmpFile) Then
                    found = True
                    Exit For
                End If
            Next
            If found Then Exit For
        Next
        Assert.IsTrue(found, "Filename label should exist in panel")

        ' Cleanup
        If File.Exists(tmpFile) Then File.Delete(tmpFile)
    End Sub

    <TestMethod>
    Public Sub UploadButton_ShouldClearAndAddUploadedFile()
        ' Arrange
        Dim tmpFile = Path.Combine(Path.GetTempPath(), "uploadtest.docx")
        File.WriteAllText(tmpFile, "upload test")

        Dim instance = CreateFillUpInstance()
        Dim t = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic

        ' Simulate UploadedFiles being empty
        FillUp.UploadedFiles.Clear()

        ' Act: Call AddFileToList and DisplayFile manually
        t.GetMethod("AddFileToList", flags).Invoke(instance, New Object() {tmpFile})
        t.GetMethod("DisplayFile", flags).Invoke(instance, New Object() {tmpFile})
        FillUp.UploadedFiles.Add(tmpFile)

        ' Assert
        Assert.AreEqual(1, FillUp.UploadedFiles.Count, "UploadedFiles should contain exactly one file")

        Dim filedisplayPanel As Panel = CType(t.GetField("filedisplay", flags).GetValue(instance), Panel)
        Assert.IsTrue(filedisplayPanel.Controls.Count > 0, "filedisplay should have controls")

        Dim fileshowPanel As Panel = CType(t.GetField("fileshow", flags).GetValue(instance), Panel)
        Assert.IsTrue(fileshowPanel.Controls.Count > 0, "fileshow should have controls")

        ' Cleanup
        If File.Exists(tmpFile) Then File.Delete(tmpFile)
    End Sub

End Class
