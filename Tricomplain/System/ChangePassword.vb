Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class ChangePassword

    ' Firebase base URL
    Private FirebaseURL As String = "https://tricomplain-default-rtdb.firebaseio.com/desktop/register/user.json"

    Private Sub changepass_Click(sender As Object, e As EventArgs) Handles changepass.Click

        If email.Text = "" Or newpassword.Text = "" Then
            MessageBox.Show("Please enter email and new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            ' === GET ALL USERS ===
            Dim request As WebRequest = WebRequest.Create(FirebaseURL)
            request.Method = "GET"

            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim json As String = reader.ReadToEnd()

            reader.Close()
            response.Close()

            Dim users As JObject = JObject.Parse(json)

            Dim userFound As Boolean = False

            ' === LOOP USERS ===
            For Each user As JProperty In users.Properties()

                Dim userEmail As String = user.Value("email").ToString()

                If userEmail.ToLower() = email.Text.ToLower() Then

                    ' === UPDATE PASSWORD ===
                    Dim updateUrl As String =
                        "https://tricomplain-default-rtdb.firebaseio.com/desktop/register/user/" &
                        user.Name & "/password.json"

                    Dim updateRequest As WebRequest = WebRequest.Create(updateUrl)
                    updateRequest.Method = "PUT"
                    updateRequest.ContentType = "application/json"

                    Dim newPassJson As String = """" & newpassword.Text & """"

                    Using streamWriter As New StreamWriter(updateRequest.GetRequestStream())
                        streamWriter.Write(newPassJson)
                        streamWriter.Flush()
                    End Using

                    Dim updateResponse As WebResponse = updateRequest.GetResponse()
                    updateResponse.Close()

                    MessageBox.Show("Password successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    userFound = True
                    Exit For
                End If
            Next

            If Not userFound Then
                MessageBox.Show("Email not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

End Class
