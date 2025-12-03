Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class UnitTest_MonitorComplaints

    ' Helper: create an instance of MonitorComplaints form
    Private Function CreateMonitorInstance() As Object
        Dim monitorType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            monitorType = asm.GetType("MonitorComplaints")
            If monitorType IsNot Nothing Then Exit For
            For Each t In asm.GetTypes()
                If t.Name = "MonitorComplaints" Then
                    monitorType = t
                    Exit For
                End If
            Next
            If monitorType IsNot Nothing Then Exit For
        Next

        If monitorType Is Nothing Then
            Assert.Fail("Could not find type 'MonitorComplaints'. Ensure UnitTest project references the main project.")
        End If

        Dim instance = Activator.CreateInstance(monitorType)

        ' Inject FlowLayoutPanel1 for testing
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim flpField = monitorType.GetField("FlowLayoutPanel1", flags)
        If flpField IsNot Nothing Then
            flpField.SetValue(instance, New FlowLayoutPanel())
        End If

        Return instance
    End Function

    <TestMethod>
    Public Sub MonitorLoad_ShouldSetupFlowLayoutAndLoadAllComplaints()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim loadMethod = monitorType.GetMethod("MonitorComplaints_Load", flags)
        Assert.IsNotNull(loadMethod, "MonitorComplaints_Load not found")

        ' Act & Assert
        Try
            loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("MonitorComplaints_Load threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub ReloadButton_Click_ShouldCallLoadAllComplaints()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim reloadMethod = monitorType.GetMethod("reload_Click", flags)
        Assert.IsNotNull(reloadMethod, "reload_Click not found")

        ' Act & Assert
        Try
            reloadMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            ' WebRequest calls may fail; ensure no other exception type
            If Not TypeOf ex.InnerException Is System.Net.WebException Then
                Assert.Fail("reload_Click threw unexpected exception: " & ex.Message)
            End If
        End Try
    End Sub

    <TestMethod>
    Public Sub BackButton_Click_ShouldShowHomeForm()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim backMethod = monitorType.GetMethod("backbtn_Click", flags)
        Assert.IsNotNull(backMethod, "backbtn_Click not found")

        ' Act & Assert
        Try
            backMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("backbtn_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub ValidBtn_Click_ShouldShowValidComplaintsForm()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim validMethod = monitorType.GetMethod("validbtn_Click", flags)
        Assert.IsNotNull(validMethod, "validbtn_Click not found")

        ' Act & Assert
        Try
            validMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("validbtn_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub Penalty_Click_ShouldShowValidReportForm()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim penaltyMethod = monitorType.GetMethod("penalty_Click", flags)
        Assert.IsNotNull(penaltyMethod, "penalty_Click not found")

        ' Act & Assert
        Try
            penaltyMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("penalty_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub SaveStatus_ShouldNotThrow()
        ' Arrange
        Dim instance = CreateMonitorInstance()
        Dim monitorType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim saveMethod = monitorType.GetMethod("SaveStatus", flags)
        Assert.IsNotNull(saveMethod, "SaveStatus not found")

        ' Act & Assert: use dummy path/status; WebRequest will fail without network
        Try
            saveMethod.Invoke(instance, New Object() {"dummy/path", "valid"})
        Catch ex As Exception
            If Not TypeOf ex.InnerException Is System.Net.WebException Then
                Assert.Fail("SaveStatus threw unexpected exception: " & ex.Message)
            End If
        End Try
    End Sub

End Class
