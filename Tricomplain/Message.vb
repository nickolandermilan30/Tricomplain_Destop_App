Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Message
    Private FirebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/"
    Private FirebaseSecret As String = "aScxTGOEQP00AtvnSaATvyxx9MOPlaCwUJXJhXnI"

    ' === These values must be set before showing this form ===
    Public Property ComplaintType As String  ' e.g. "commuter complaint" or "driver complaint"
    Public Property TicketNumber As String   ' e.g. "3698"

    Private NodeName As String = Nothing     ' to store the Firebase node to update

    ' === Load message on form load ===
    Private Sub Message_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If String.IsNullOrEmpty(ComplaintType) OrElse String.IsNullOrEmpty(TicketNumber) Then
                MessageBox.Show("Missing ComplaintType or TicketNumber.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' === Get all complaints under the type ===
            Dim url As String = $"{FirebaseUrl}{ComplaintType}.json?auth={FirebaseSecret}"
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"

            Using response As WebResponse = request.GetResponse()
                Using dataStream As IO.Stream = response.GetResponseStream()
                    Using reader As New IO.StreamReader(dataStream)
                        Dim jsonText As String = reader.ReadToEnd()
                        If jsonText = "null" OrElse String.IsNullOrWhiteSpace(jsonText) Then
                            MessageBox.Show("No complaints found in database.")
                            Return
                        End If

                        Dim allComplaints As JObject = JObject.Parse(jsonText)

                        ' Find node by ticket number
                        For Each item In allComplaints.Properties()
                            Dim complaint As JObject = item.Value
                            Dim tNo As String = complaint("ticketNo")?.ToString()
                            If tNo = TicketNumber Then
                                NodeName = item.Name
                                msg.Text = complaint("message")?.ToString()  ' show existing message
                                Exit For
                            End If
                        Next
                    End Using
                End Using
            End Using

            If NodeName Is Nothing Then
                MessageBox.Show("Ticket number not found in database.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading message: " & ex.Message)
        End Try
    End Sub

    ' === Save / Update message when clicking Submit ===
    Private Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        If NodeName Is Nothing Then
            MessageBox.Show("Complaint node not found. Cannot update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim updateUrl As String = $"{FirebaseUrl}{ComplaintType}/{NodeName}.json?auth={FirebaseSecret}"

            Dim messageData As New JObject()
            messageData("message") = msg.Text  ' update text, can be empty or replaced

            Dim updateRequest As WebRequest = WebRequest.Create(updateUrl)
            updateRequest.Method = "PATCH"
            Dim dataBytes As Byte() = Encoding.UTF8.GetBytes(messageData.ToString())
            updateRequest.ContentType = "application/json"
            updateRequest.ContentLength = dataBytes.Length

            Using dataStream As IO.Stream = updateRequest.GetRequestStream()
                dataStream.Write(dataBytes, 0, dataBytes.Length)
            End Using

            Using response As WebResponse = updateRequest.GetResponse()
                ' Success, show confirmation and go back
                MessageBox.Show("Message successfully submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' === Return to previous form ===
                Dim prevForm As Form = Application.OpenForms.Cast(Of Form)().FirstOrDefault(Function(f) f.Name = "MonitorComplaints")
                If prevForm IsNot Nothing Then
                    prevForm.Show()
                Else
                    ' fallback if previous form not found
                    Dim mainForm As New MonitorComplaints()
                    mainForm.Show()
                End If

                Me.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving message: " & ex.Message)
        End Try
    End Sub

    ' === Optional text change handler ===
    Private Sub msg_TextChanged(sender As Object, e As EventArgs) Handles msg.TextChanged
        ' Optional live update logic can go here if needed
    End Sub

    ' === Label placeholders (can be removed if unused) ===
    Private Sub stikerno_Click(sender As Object, e As EventArgs) Handles stikerno.Click
    End Sub

    Private Sub violation_Click(sender As Object, e As EventArgs) Handles violation.Click
    End Sub

    Private Sub detination_Click(sender As Object, e As EventArgs) Handles detination.Click
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
    End Sub
End Class
