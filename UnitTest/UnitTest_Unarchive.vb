Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class UnitTest_Unarchive

    ' Helper to create instance of Unarchive
    Private Function CreateUnarchiveInstance() As Object
        Dim uaType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            uaType = asm.GetType("Unarchive")
            If uaType IsNot Nothing Then Exit For
            For Each t In asm.GetTypes()
                If t.Name = "Unarchive" Then
                    uaType = t
                    Exit For
                End If
            Next
            If uaType IsNot Nothing Then Exit For
        Next

        If uaType Is Nothing Then
            Assert.Fail("Could not find type 'Unarchive'. Ensure UnitTest project references main project.")
        End If

        Dim instance = Activator.CreateInstance(uaType)

        ' Inject a panel for Unarchive_panel
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim panelField = uaType.GetField("Unarchive_panel", flags)
        If panelField IsNot Nothing Then
            panelField.SetValue(instance, New FlowLayoutPanel())
        End If

        ' Inject AllFilesData
        Dim filesDataField = uaType.GetField("AllFilesData", flags)
        If filesDataField IsNot Nothing Then
            filesDataField.SetValue(instance, New Newtonsoft.Json.Linq.JObject())
        End If

        Return instance
    End Function

    <TestMethod>
    Public Sub FormLoad_ShouldCallLoadArchivedFiles()
        ' Arrange
        Dim instance = CreateUnarchiveInstance()
        Dim uaType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim loadMethod = uaType.GetMethod("Unarchive_Load", flags)
        Assert.IsNotNull(loadMethod, "Unarchive_Load method not found")

        ' Act & Assert
        Try
            loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("Unarchive_Load threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub AddArchivedFileCard_ShouldAddControls()
        ' Arrange
        Dim instance = CreateUnarchiveInstance()
        Dim uaType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim addCardMethod = uaType.GetMethod("AddArchivedFileCard", flags)
        Assert.IsNotNull(addCardMethod, "AddArchivedFileCard method not found")

        ' Act
        addCardMethod.Invoke(instance, New Object() {"testfile.txt", "https://dummyurl.com/file.txt", "12345"})

        ' Assert
        Dim panelField = uaType.GetField("Unarchive_panel", flags)
        Dim panel = CType(panelField.GetValue(instance), FlowLayoutPanel)
        Assert.IsTrue(panel.Controls.Count > 0, "AddArchivedFileCard did not add a control to panel")
    End Sub

    <TestMethod>
    Public Sub RunSearch_WithEmptyKeyword_ShouldReloadAllFiles()
        ' Arrange
        Dim instance = CreateUnarchiveInstance()
        Dim uaType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim searchTextField = uaType.GetField("searchvalid", flags)
        Dim txtBox As New TextBox()
        txtBox.Text = ""
        If searchTextField IsNot Nothing Then
            searchTextField.SetValue(instance, txtBox)
        End If

        Dim runSearchMethod = uaType.GetMethod("RunSearch", flags)
        Assert.IsNotNull(runSearchMethod, "RunSearch method not found")

        ' Act & Assert
        Try
            runSearchMethod.Invoke(instance, Nothing)
        Catch ex As Exception
            Assert.Fail("RunSearch threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub ShowEmptyMessage_ShouldAddLabelToPanel()
        ' Arrange
        Dim instance = CreateUnarchiveInstance()
        Dim uaType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim showMsgMethod = uaType.GetMethod("ShowEmptyMessage", flags)
        Assert.IsNotNull(showMsgMethod, "ShowEmptyMessage method not found")

        ' Act
        showMsgMethod.Invoke(instance, New Object() {"No files found"})

        ' Assert
        Dim panelField = uaType.GetField("Unarchive_panel", flags)
        Dim panel = CType(panelField.GetValue(instance), FlowLayoutPanel)
        Assert.IsTrue(panel.Controls.Count = 1, "ShowEmptyMessage did not add a label")
        Dim lbl = TryCast(panel.Controls(0), Label)
        Assert.IsNotNull(lbl)
        Assert.AreEqual("No files found", lbl.Text)
    End Sub

    <TestMethod>
    Public Sub BackButton_Click_ShouldCloseForm()
        ' Arrange
        Dim instance = CreateUnarchiveInstance()
        Dim uaType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim backMethod = uaType.GetMethod("back_Click", flags)
        Assert.IsNotNull(backMethod, "back_Click not found")

        ' Act & Assert
        Try
            backMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("back_Click threw exception: " & ex.Message)
        End Try
    End Sub

End Class
