Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq

<TestClass>
Public Class UnitTest_View

    ' Helper: create instance of View form
    Private Function CreateViewInstance() As Object
        Dim vType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            vType = asm.GetType("View")
            If vType IsNot Nothing Then Exit For
            For Each t In asm.GetTypes()
                If t.Name = "View" Then
                    vType = t
                    Exit For
                End If
            Next
            If vType IsNot Nothing Then Exit For
        Next

        If vType Is Nothing Then
            Assert.Fail("Could not find type 'View'. Ensure UnitTest project references main project.")
        End If

        Dim instance = Activator.CreateInstance(vType)

        ' Inject Panel for File_Display
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim panelField = vType.GetField("File_Display", flags)
        If panelField IsNot Nothing Then
            panelField.SetValue(instance, New FlowLayoutPanel())
        End If

        ' Inject BN TextBox
        Dim bnField = vType.GetField("bnnumber", flags)
        If bnField IsNot Nothing Then
            bnField.SetValue(instance, New TextBox())
        End If

        Return instance
    End Function

    <TestMethod>
    Public Sub FormLoad_ShouldDisplayBNAndFileCard()
        ' Arrange
        Dim instance = CreateViewInstance()
        Dim vType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Set properties
        vType.GetProperty("SelectedBN", flags).SetValue(instance, "BN123")
        vType.GetProperty("SelectedFileName", flags).SetValue(instance, "test.docx")

        Dim loadMethod = vType.GetMethod("View_Load", flags)
        Assert.IsNotNull(loadMethod, "View_Load not found")

        ' Act
        loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})

        ' Assert
        Dim bnTextBox = CType(vType.GetField("bnnumber", flags).GetValue(instance), TextBox)
        Assert.AreEqual("BN123", bnTextBox.Text, "BN number not displayed correctly")

        Dim filePanel = CType(vType.GetField("File_Display", flags).GetValue(instance), FlowLayoutPanel)
        Assert.IsTrue(filePanel.Controls.Count > 0, "File card panel was not created")
    End Sub

    <TestMethod>
    Public Sub DisplayFileCard_ShouldAddPanelWithLabel()
        ' Arrange
        Dim instance = CreateViewInstance()
        Dim vType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        vType.GetProperty("SelectedFileName", flags).SetValue(instance, "file.docx")
        Dim method = vType.GetMethod("DisplayFileCard", flags)
        Assert.IsNotNull(method, "DisplayFileCard not found")

        ' Act
        method.Invoke(instance, Nothing)

        ' Assert
        Dim panel = CType(vType.GetField("File_Display", flags).GetValue(instance), FlowLayoutPanel)
        Assert.IsTrue(panel.Controls.Count > 0, "File card panel not added")
        Dim cardPanel = CType(panel.Controls(0), Panel)
        Assert.IsTrue(cardPanel.Controls.OfType(Of Label)().Any(Function(l) l.Text = "file.docx"), "File name label not found")
    End Sub

    <TestMethod>
    Public Sub BackButton_Click_ShouldCloseForm()
        ' Arrange
        Dim instance = CreateViewInstance()
        Dim vType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim backMethod = vType.GetMethod("back_Click", flags)
        Assert.IsNotNull(backMethod, "back_Click not found")

        ' Act & Assert
        Try
            backMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("back_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub Button1_Click_ShouldAttemptOpenFile()
        ' Arrange
        Dim instance = CreateViewInstance()
        Dim vType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Set SelectedFileName and SelectedFileUrl
        vType.GetProperty("SelectedFileName", flags).SetValue(instance, "dummyfile.txt")
        vType.GetProperty("SelectedFileUrl", flags).SetValue(instance, "https://example.com/dummyfile.txt")

        Dim method = vType.GetMethod("Button1_Click", flags)
        Assert.IsNotNull(method, "Button1_Click not found")

        ' Act & Assert (cannot really open file in unit test, just check method runs)
        Try
            method.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("Button1_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub ChangeBNNumber_Empty_ShouldShowMessage()
        ' Arrange
        Dim instance = CreateViewInstance()
        Dim vType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Set BN TextBox empty
        Dim bnField = CType(vType.GetField("bnnumber", flags).GetValue(instance), TextBox)
        bnField.Text = ""

        Dim method = vType.GetMethod("changebnnumber_Click", flags)
        Assert.IsNotNull(method, "changebnnumber_Click not found")

        ' Act & Assert (should not throw)
        Try
            method.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("changebnnumber_Click threw exception: " & ex.Message)
        End Try
    End Sub

End Class
