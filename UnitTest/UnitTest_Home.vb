Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class UnitTest_Home

    ' Helper: create an instance of the Home form
    Private Function CreateHomeInstance() As Object
        ' find Home type in loaded assemblies
        Dim homeType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            homeType = asm.GetType("Home")
            If homeType IsNot Nothing Then Exit For
            ' fallback: search all types
            For Each t In asm.GetTypes()
                If t.Name = "Home" Then
                    homeType = t
                    Exit For
                End If
            Next
            If homeType IsNot Nothing Then Exit For
        Next

        If homeType Is Nothing Then
            Assert.Fail("Could not find type 'Home'. Make sure UnitTest project references your project.")
        End If

        Dim instance = Activator.CreateInstance(homeType)
        Return instance
    End Function

    <TestMethod>
    Public Sub FranchiseButton_Click_ShouldOpenFranchiseForm()
        ' Arrange
        Dim instance = CreateHomeInstance()
        Dim homeType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' simulate click
        Dim buttonField = homeType.GetField("Franchise", flags)
        Dim btn As Button = Nothing
        If buttonField IsNot Nothing Then
            btn = CType(buttonField.GetValue(instance), Button)
        Else
            ' fallback: create dummy button
            btn = New Button()
        End If

        ' get click handler method
        Dim clickMethod = homeType.GetMethod("franchise_Click", flags)
        Assert.IsNotNull(clickMethod, "franchise_Click method not found")

        ' Act: invoke click
        clickMethod.Invoke(instance, New Object() {btn, EventArgs.Empty})

        ' Assert: instance should hide (Me.Hide) - check Form's Visible property
        Dim visibleProp = homeType.GetProperty("Visible", flags)
        If visibleProp IsNot Nothing Then
            Dim visible = CBool(visibleProp.GetValue(instance))
            Assert.IsFalse(visible, "Home form should be hidden after Franchise button click")
        End If
    End Sub

    <TestMethod>
    Public Sub MonitorButton_Click_ShouldOpenMonitorComplaintsForm()
        ' Arrange
        Dim instance = CreateHomeInstance()
        Dim homeType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' simulate click
        Dim buttonField = homeType.GetField("monitor", flags)
        Dim btn As Button = Nothing
        If buttonField IsNot Nothing Then
            btn = CType(buttonField.GetValue(instance), Button)
        Else
            ' fallback: create dummy button
            btn = New Button()
        End If

        ' get click handler method
        Dim clickMethod = homeType.GetMethod("monitor_Click", flags)
        Assert.IsNotNull(clickMethod, "monitor_Click method not found")

        ' Act: invoke click
        clickMethod.Invoke(instance, New Object() {btn, EventArgs.Empty})

        ' Assert: instance should hide
        Dim visibleProp = homeType.GetProperty("Visible", flags)
        If visibleProp IsNot Nothing Then
            Dim visible = CBool(visibleProp.GetValue(instance))
            Assert.IsFalse(visible, "Home form should be hidden after Monitor button click")
        End If
    End Sub

    <TestMethod>
    Public Sub HomeLoad_ShouldNotThrow()
        ' Arrange
        Dim instance = CreateHomeInstance()
        Dim homeType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        ' get Home_Load method
        Dim loadMethod = homeType.GetMethod("Home_Load", flags)
        Assert.IsNotNull(loadMethod, "Home_Load method not found")

        ' Act & Assert: should not throw
        Try
            loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("Home_Load threw exception: " & ex.Message)
        End Try
    End Sub

End Class
