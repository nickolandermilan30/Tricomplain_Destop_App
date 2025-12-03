Imports System.IO
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Drawing

Public Class View

    Public SelectedFileName As String
    Public SelectedFileUrl As String
    Public SelectedBN As String

    Private FirebaseDB As String = "https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles.json"
    Private FirebaseDBBase As String = "https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles"
    Private StorageBase As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o"
    Private StorageFolder As String = "Files/Franchise"

    Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display BN Number
        bnnumber.Text = If(String.IsNullOrWhiteSpace(SelectedBN), "", SelectedBN)

        ' Display file card (icon + name)
        DisplayFileCard()
    End Sub

    '==========================================================
    ' 🔹 DISPLAY FILE NAME + ICON ONLY
    '==========================================================
    Private Sub DisplayFileCard()
        File_Display.Controls.Clear()

        Dim card As New Panel() With {
            .Height = 60,
            .Dock = DockStyle.Top,
            .BackColor = Color.WhiteSmoke,
            .BorderStyle = BorderStyle.FixedSingle,
            .Padding = New Padding
        }

        ' File icon
        Dim pic As New PictureBox() With {
            .Image = SystemIcons.WinLogo.ToBitmap(),
            .Size = New Size(40, 40),
            .Location = New Point(5, 10),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        ' File name label
        Dim lbl As New Label() With {
            .Text = SelectedFileName,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(60, 15),
            .AutoSize = True
        }

        card.Controls.Add(pic)
        card.Controls.Add(lbl)
        File_Display.Controls.Add(card)
    End Sub

    '==========================================================
    ' 🔹 UPDATE BN NUMBER
    '==========================================================
    Private Async Sub changebnnumber_Click(sender As Object, e As EventArgs) Handles changebnnumber.Click
        If bnnumber.Text.Trim = "" Then
            MessageBox.Show("BN Number cannot be empty!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim keyToUpdate = Await FindKeyByFileName(SelectedFileName)
            If keyToUpdate Is Nothing Then
                MessageBox.Show("File not found in DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim updateUrl = $"{FirebaseDBBase}/{keyToUpdate}.json"
            Dim body = $"{{""bn_number"": ""{bnnumber.Text}""}}"

            Using client As New HttpClient
                Await client.PatchAsync(updateUrl, New StringContent(body, System.Text.Encoding.UTF8, "application/json"))
            End Using

            MessageBox.Show("BN Number updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating BN Number: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '==========================================================
    ' 🔹 FIND DB KEY
    '==========================================================
    Private Async Function FindKeyByFileName(fileName As String) As Threading.Tasks.Task(Of String)
        Using client As New HttpClient()
            Dim resp = Await client.GetAsync(FirebaseDB)
            Dim json = Await resp.Content.ReadAsStringAsync()
            If String.IsNullOrWhiteSpace(json) OrElse json = "null" Then Return Nothing

            Dim obj As JObject = JObject.Parse(json)
            For Each entry In obj
                If entry.Value("name")?.ToString() = fileName Then
                    Return entry.Key
                End If
            Next
        End Using
        Return Nothing
    End Function

    '==========================================================
    ' 🔹 REPLACE FILE
    '==========================================================
    Private Async Sub replace_Click(sender As Object, e As EventArgs) Handles replace.Click
        Dim dlg As New OpenFileDialog With {.Filter = "Word Document (.docx)|.docx"}
        If dlg.ShowDialog <> DialogResult.OK Then Exit Sub

        Dim selectedPath = dlg.FileName
        If Not File.Exists(selectedPath) Then
            MessageBox.Show("Selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim newFileName = Path.GetFileName(selectedPath)
            Dim storagePath = $"{StorageFolder}/{newFileName}"

            ' Upload new file to Firebase Storage
            Using client As New HttpClient
                Using fs As New FileStream(selectedPath, FileMode.Open, FileAccess.Read)
                    Dim content As New StreamContent(fs)
                    content.Headers.ContentType =
                        New Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    Await client.PostAsync($"{StorageBase}?name={Uri.EscapeDataString(storagePath)}", content)
                End Using
            End Using

            ' Update DB
            Dim newURL = $"{StorageBase}/{Uri.EscapeDataString(storagePath)}?alt=media"
            Dim key = Await FindKeyByFileName(SelectedFileName)
            If key IsNot Nothing Then
                Dim updateUrl = $"{FirebaseDBBase}/{key}.json"
                Dim jsonBody = $"{{""name"":""{newFileName}"",""url"":""{newURL}"",""path"":""{storagePath}""}}"
                Using client As New HttpClient
                    Await client.PatchAsync(updateUrl, New StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json"))
                End Using

                ' Update local props
                SelectedFileName = newFileName
                SelectedFileUrl = newURL

                ' Refresh file card display
                DisplayFileCard()

                MessageBox.Show("File replaced successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("File DB entry not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error replacing file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '==========================================================
    ' 🔹 BACK BUTTON 
    '==========================================================
    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Dim f As New Franchise()
        f.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim tempPath = IO.Path.Combine(IO.Path.GetTempPath(), SelectedFileName)

            Using c As New Net.Http.HttpClient()
                IO.File.WriteAllBytes(tempPath, c.GetByteArrayAsync(SelectedFileUrl).Result)
            End Using

            Process.Start(New ProcessStartInfo(tempPath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Cannot open file: " & ex.Message)
        End Try
    End Sub



End Class