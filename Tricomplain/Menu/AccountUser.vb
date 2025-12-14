Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class AccountUser

    ' ===== FIREBASE URLS =====
    Private firebaseAllAdmins As String =
        "https://tricomplain-default-rtdb.firebaseio.com/desktop/register/user.json"

    Private firebaseUsers As String =
        "https://tricomplain-default-rtdb.firebaseio.com/Users.json"

    Private UsersData As JObject

    Private Async Sub AccountUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupAdminGrid()
        SetupCommuterGrid()
        SetupDriverGrid()

        Await LoadUsers()
    End Sub

    ' ========================================================
    '   SETUP GRIDS
    ' ========================================================
    Private Sub SetupAdminGrid()
        Admin.Columns.Clear()
        Admin.Columns.Add("username", "Username")
        Admin.Columns.Add("email", "Email")
        Admin.Columns.Add("password", "Password")
        Admin.AllowUserToAddRows = False
        Admin.ReadOnly = True
    End Sub

    Private Sub SetupCommuterGrid()
        Commuter.Columns.Clear()
        Commuter.Columns.Add("id", "UserID")
        Commuter.Columns.Add("email", "Email")
        Commuter.Columns.Add("phone", "Phone")
        Commuter.Columns.Add("role", "Role")
        Commuter.AllowUserToAddRows = False
    End Sub

    Private Sub SetupDriverGrid()
        driver.Columns.Clear()
        driver.Columns.Add("id", "UserID")
        driver.Columns.Add("email", "Email")
        driver.Columns.Add("phone", "Phone")
        driver.Columns.Add("role", "Role")
        driver.AllowUserToAddRows = False
    End Sub

    ' ========================================================
    '   LOAD ALL ADMIN / REGISTER USERS
    ' ========================================================
    Private Async Function LoadAllRegisterUsers() As Task
        Try
            Using client As New HttpClient()
                Dim response As String = Await client.GetStringAsync(firebaseAllAdmins)

                If String.IsNullOrWhiteSpace(response) OrElse response = "null" Then
                    MessageBox.Show("No users found.")
                    Return
                End If

                Dim data As JObject = JObject.Parse(response)

                Admin.Rows.Clear()

                For Each user In data
                    Dim obj = CType(user.Value, JObject)

                    Admin.Rows.Add(
                        obj("username")?.ToString(),
                        obj("email")?.ToString(),
                        obj("password")?.ToString()
                    )
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading admin users: " & ex.Message)
        End Try
    End Function

    ' ========================================================
    '   LOAD COMMUTER + DRIVER
    ' ========================================================
    Private Async Function LoadUsers() As Task
        Try
            Using client As New HttpClient()
                Dim response As String = Await client.GetStringAsync(firebaseUsers)

                If String.IsNullOrWhiteSpace(response) OrElse response = "null" Then Return

                UsersData = JObject.Parse(response)

                Commuter.Rows.Clear()
                driver.Rows.Clear()

                For Each user In UsersData
                    Dim id As String = user.Key
                    Dim obj = CType(user.Value, JObject)
                    Dim role = obj("role")?.ToString()

                    If role = "Commuter" Then
                        Commuter.Rows.Add(id, obj("email"), obj("phone"), role)
                    ElseIf role = "Driver" Then
                        driver.Rows.Add(id, obj("email"), obj("phone"), role)
                    End If
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        End Try
    End Function

    ' ========================================================
    '   ADMIN GRID CLICK → LOAD ALL USERS
    ' ========================================================
    Private Async Sub Admin_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Admin.CellContentClick
        Await LoadAllRegisterUsers()
    End Sub

    Private Sub Commuter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Commuter.CellContentClick
    End Sub

    Private Sub driver_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles driver.CellContentClick
    End Sub

End Class
