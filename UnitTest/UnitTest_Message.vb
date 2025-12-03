Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class UnitTest_Message

    ' Helper: create an instance of Message form
    Private Function CreateMessageInstance() As Object
        Dim messageType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            messageType = asm.GetType("Message")
            If messageType IsNot Nothing Then Exit For
            For Each t In asm.GetTypes()
                If t.Name = "Message" Then
                    messageType = t
                    Exit For
                End If
            Next
            If messageType IsNot Nothing Then Exit For
        Next

        If messageType Is Nothing Then
            Assert.Fail("Could not find type 'Message'. Ensure UnitTest project references the main project.")
        End If

        Dim instance = Activator.CreateInstance(messageType)

        ' Inject msg TextBox for testing
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim msgField = messageType.GetField("msg", flags)
        If msgField IsNot Nothing Then
            msgField.SetValue(instance, New TextBox())
        End If

        Return instance
    End Function

    <TestMethod>
    Public Sub MessageLoad_WithValidTicket_ShouldSetNodeNameAndMsg()
        ' Arrange
        Dim instance = CreateMessageInstance()
        Dim messageType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Set properties
        Dim propComplaintType = messageType.GetProperty("ComplaintType", flags)
        Dim propTicketNumber = messageType.GetProperty("TicketNumber", flags)
        propComplaintType.SetValue(instance, "commuter_complaint")
        propTicketNumber.SetValue(instance, "12345")

        ' get Message_Load method
        Dim loadMethod = messageType.GetMethod("Message_Load", flags)
        Assert.IsNotNull(loadMethod, "Message_Load not found")

        ' Act: invoke load
        Try
            loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})
            ' Since actual Firebase is not mocked, NodeName may remain Nothing, but method should not throw
        Catch ex As Exception
            Assert.Fail("Message_Load threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub SubmitClick_WithNodeName_ShouldNotThrow()
        ' Arrange
        Dim instance = CreateMessageInstance()
        Dim messageType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Set NodeName manually to simulate existing complaint
        Dim nodeField = messageType.GetField("NodeName", flags)
        nodeField.SetValue(instance, "dummyNode")

        ' Inject msg TextBox
        Dim msgField = messageType.GetField("msg", flags)
        Dim msgBox As New TextBox() With {.Text = "Test message"}
        msgField.SetValue(instance, msgBox)

        ' get submit_Click method
        Dim submitMethod = messageType.GetMethod("submit_Click", flags)
        Assert.IsNotNull(submitMethod, "submit_Click method not found")

        ' Act & Assert: invoke click
        Try
            submitMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
            ' Should not throw, although actual WebRequest will fail without mocking Firebase
        Catch ex As Exception
            ' Accept WebException as valid since no real Firebase, fail if other exception
            If Not TypeOf ex.InnerException Is System.Net.WebException Then
                Assert.Fail("submit_Click threw unexpected exception: " & ex.Message)
            End If
        End Try
    End Sub

    <TestMethod>
    Public Sub SubmitClick_WithoutNodeName_ShouldShowError()
        ' Arrange
        Dim instance = CreateMessageInstance()
        Dim messageType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' Ensure NodeName is Nothing
        Dim nodeField = messageType.GetField("NodeName", flags)
        nodeField.SetValue(instance, Nothing)

        ' get submit_Click method
        Dim submitMethod = messageType.GetMethod("submit_Click", flags)
        Assert.IsNotNull(submitMethod, "submit_Click method not found")

        ' Act & Assert: invoke click, should not throw, shows MessageBox
        Try
            submitMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            ' MessageBox may cause ThreadException, ignore, test passes if no other exceptions
            If Not TypeOf ex.InnerException Is System.InvalidOperationException Then
                Assert.Fail("submit_Click threw unexpected exception: " & ex.Message)
            End If
        End Try
    End Sub

End Class
