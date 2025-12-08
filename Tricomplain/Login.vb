Imports System.Net
Imports Newtonsoft.Json

Public Class Login

    ' === Firebase BASE URL ===
    Private FirebaseURL As String = "https://tricomplain-default-rtdb.firebaseio.com/desktop/register/user/"

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim reg As New Register()
        reg.Show()
        Me.Hide()
    End Sub

    ' ======================================================
    ' LOGIN FUNCTION
    ' ======================================================
    Private Sub loginnow_Click(sender As Object, e As EventArgs) Handles loginnow.Click

        If email.Text = "" Or password.Text = "" Then
            MessageBox.Show("Please enter email and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim client As New WebClient()
            Dim json As String = client.DownloadString(FirebaseURL & ".json")

            If json = "null" Then
                MessageBox.Show("No users found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Deserialize all users
            Dim users As Dictionary(Of String, Object) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)

            Dim found As Boolean = False

            ' Loop through all users (user1, user2, user3...)
            For Each u In users
                Dim userData As Dictionary(Of String, Object) =
                    JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(u.Value.ToString())

                Dim dbEmail As String = userData("email").ToString()
                Dim dbPassword As String = userData("password").ToString()

                ' CHECK LOGIN
                If dbEmail = email.Text And dbPassword = password.Text Then
                    found = True
                    Exit For
                End If
            Next

            If found Then
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Go to Home form
                Dim h As New Home()
                h.Show()
                Me.Hide()
            Else
                MessageBox.Show("Incorrect email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

End Class
