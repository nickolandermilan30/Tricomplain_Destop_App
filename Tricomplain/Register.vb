Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class Register

    ' === Firebase Base URL ===
    Private FirebaseURL As String = "https://tricomplain-default-rtdb.firebaseio.com/desktop/register/user/"

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hide password on form load
        password.UseSystemPasswordChar = True
    End Sub

    Private Sub username_TextChanged(sender As Object, e As EventArgs) Handles username.TextChanged

    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    ' ============================================
    ' BACK BUTTON - return to Login
    ' ============================================
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim h As New Login()
        h.Show()
        Me.Hide()
    End Sub


    ' ============================================
    ' REGISTER NOW BUTTON
    ' ============================================
    Private Async Sub Registernow_Click(sender As Object, e As EventArgs) Handles Registernow.Click

        If username.Text = "" Or email.Text = "" Or password.Text = "" Then
            MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' ==================================================
            ' GET CURRENT USER COUNT
            ' ==================================================
            Dim client As New WebClient()
            Dim json As String = client.DownloadString(FirebaseURL & ".json")

            Dim users As Dictionary(Of String, Object) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)

            Dim userCount As Integer = 0

            If users IsNot Nothing Then
                userCount = users.Count
            End If

            Dim newUserId As String = "user" & (userCount + 1).ToString()

            ' ==================================================
            ' DATA TO SAVE
            ' ==================================================
            Dim userData As New Dictionary(Of String, String) From {
                {"username", username.Text},
                {"email", email.Text},
                {"password", password.Text}
            }

            Dim postJson As String = JsonConvert.SerializeObject(userData)
            client.Headers(HttpRequestHeader.ContentType) = "application/json"

            ' ==================================================
            ' SAVE TO FIREBASE
            ' ==================================================
            Dim result = client.UploadString(FirebaseURL & newUserId & ".json", "PUT", postJson)

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim h As New Login()
            h.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub



End Class
