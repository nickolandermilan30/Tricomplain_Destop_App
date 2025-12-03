Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class FillUp
    ' === Firebase Configuration ===
    Private FirebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/"
    Private FirebaseSecret As String = "aScxTGOEQP00AtvnSaATvyxx9MOPlaCwUJXJhXnI"
    Private FirebaseStorage As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o"

    ' === Shared list of uploaded files (local paths) ===
    Public Shared UploadedFiles As New List(Of String)

    Private Sub FillUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filedisplay.Controls.Clear()
    End Sub

    ' ====== UPLOAD BUTTON (only .docx allowed) ======
    Private Sub uploadbtn_Click(sender As Object, e As EventArgs) Handles uploadbtn.Click
        Try
            Dim dlg As New OpenFileDialog()
            dlg.Filter = "Word Documents (*.docx)|*.docx"
            dlg.Title = "Select a .docx file to upload"

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = dlg.FileName
                If Not String.Equals(Path.GetExtension(filePath), ".docx", StringComparison.OrdinalIgnoreCase) Then
                    MessageBox.Show("Only .docx files are allowed.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                UploadedFiles.Clear() ' ✅ Only keep one file (latest)
                UploadedFiles.Add(filePath)
                filedisplay.Controls.Clear()
                AddFileToList(filePath)
                DisplayFile(filePath)
            End If

        Catch ex As Exception
            MessageBox.Show("Error selecting file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ====== DISPLAY FILE IN PREVIEW ======
    Private Sub DisplayFile(file As String)
        fileshow.Controls.Clear()

        Dim ext As String = Path.GetExtension(file).ToLower()
        Dim panel As New Panel() With {
        .Dock = DockStyle.Fill,
        .BackColor = Color.LightGray
    }

        Dim lblTitle As New Label() With {
        .Text = "Preview:",
        .Font = New Font("Segoe UI", 11, FontStyle.Bold),
        .Location = New Point(20, 20),
        .AutoSize = True
    }

        Dim iconPic As New PictureBox() With {
        .Size = New Size(80, 80),
        .Location = New Point(20, 60),
        .SizeMode = PictureBoxSizeMode.StretchImage
    }

        ' Show Word icon if docx file
        If ext = ".docx" Then
            Try
                iconPic.Image = Icon.ExtractAssociatedIcon(file).ToBitmap()
            Catch
                iconPic.Image = SystemIcons.WinLogo.ToBitmap()
            End Try
        Else
            iconPic.Image = SystemIcons.Warning.ToBitmap()
        End If

        Dim lblFile As New Label() With {
        .Text = Path.GetFileName(file),
        .Font = New Font("Segoe UI", 10, FontStyle.Regular),
        .Location = New Point(120, 90),
        .AutoSize = True
    }

        Dim btnOpen As New Button() With {
        .Text = "Open File",
        .Font = New Font("Segoe UI", 9, FontStyle.Bold),
        .BackColor = Color.FromArgb(52, 152, 219),
        .ForeColor = Color.White,
        .FlatStyle = FlatStyle.Flat,
        .Location = New Point(120, 120),
        .Width = 100,
        .Height = 40
    }

        btnOpen.FlatAppearance.BorderSize = 0

        AddHandler btnOpen.Click, Sub()
                                      Try
                                          ' Try to open with Microsoft Word directly
                                          Process.Start("winword.exe", $"""{file}""")
                                      Catch
                                          ' If Word fails, open with default app
                                          Try
                                              Process.Start(New ProcessStartInfo With {
                                                  .FileName = file,
                                                  .UseShellExecute = True
                                              })
                                          Catch
                                              MessageBox.Show("Cannot open file. Make sure MS Word is installed.",
                                                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                          End Try
                                      End Try
                                  End Sub

        panel.Controls.Add(lblTitle)
        panel.Controls.Add(iconPic)
        panel.Controls.Add(lblFile)
        panel.Controls.Add(btnOpen)
        fileshow.Controls.Add(panel)
    End Sub

    ' ====== FILE LIST CARD DISPLAY ======
    Private Sub AddFileToList(filePath As String)
        Dim pnl As New Panel()
        pnl.Height = 45
        pnl.Dock = DockStyle.Top
        pnl.BackColor = Color.WhiteSmoke
        pnl.Padding = New Padding(8)
        pnl.Margin = New Padding(0, 0, 0, 4)

        Dim iconImg As Image
        Try
            iconImg = Icon.ExtractAssociatedIcon(filePath).ToBitmap()
        Catch
            iconImg = SystemIcons.WinLogo.ToBitmap()
        End Try

        Dim pic As New PictureBox() With {
            .Image = iconImg,
            .Size = New Size(30, 30),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Location = New Point(8, 7)
        }

        Dim lbl As New Label() With {
            .Text = Path.GetFileName(filePath),
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .AutoSize = False,
            .Width = 300,
            .Location = New Point(50, 12)
        }

        pnl.Controls.Add(pic)
        pnl.Controls.Add(lbl)
        filedisplay.Controls.Add(pnl)
        filedisplay.Controls.SetChildIndex(pnl, 0)
    End Sub

    ' ====== DONE BUTTON ======
    Private Async Sub done_Click(sender As Object, e As EventArgs) Handles done.Click
        ' === Check BN Number ===
        If String.IsNullOrWhiteSpace(bnnumber.Text) Then
            MessageBox.Show("Please enter a valid BN Number before proceeding.", "Missing BN Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bnnumber.Focus()
            Return
        End If

        ' === Check if a file is uploaded ===
        If UploadedFiles.Count = 0 Then
            MessageBox.Show("Please choose one .docx file before proceeding.", "No File", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' === Show loading dialog ===
        Dim loadingForm As New Form With {
            .Size = New Size(300, 120),
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .StartPosition = FormStartPosition.CenterScreen,
            .ControlBox = False,
            .Text = "Uploading..."
        }

        Dim lblLoading As New Label With {
            .Text = "Uploading to Firebase, please wait...",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        loadingForm.Controls.Add(lblLoading)
        loadingForm.Show()
        loadingForm.Refresh()

        Try
            Dim filePath As String = UploadedFiles.First()
            Await UploadDocxToFirebaseAsync(filePath)

            MessageBox.Show("File uploaded successfully!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadingForm.Close()

            Dim f As New Franchise()
            f.Show()
            Me.Hide()

        Catch ex As Exception
            loadingForm.Close()
            MessageBox.Show("Upload failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ====== FIREBASE UPLOAD FUNCTION ======
    Private Async Function UploadDocxToFirebaseAsync(filePath As String) As Task
        Try
            Dim newName As String = Path.GetFileName(filePath)
            Dim tempPath As String = Path.Combine(Path.GetTempPath(), newName)
            File.Copy(filePath, tempPath, True)

            Dim folderPath As String = "Files/Franchise/"
            Dim firebaseStoragePath As String = folderPath & newName
            Dim storageUrl As String = $"{FirebaseStorage}?name={Uri.EscapeDataString(firebaseStoragePath)}"

            Using client As New HttpClient()
                Using fs As New FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    Dim content As New StreamContent(fs)
                    content.Headers.ContentType = New MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document")

                    Dim response = Await client.PostAsync(storageUrl, content)
                    Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()

                    If response.IsSuccessStatusCode Then
                        Dim downloadUrl As String =
                            $"https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o/{Uri.EscapeDataString(firebaseStoragePath)}?alt=media"
                        Await SaveFileDataToDatabase(newName, downloadUrl)
                    Else
                        Throw New Exception("Upload failed: " & jsonResponse)
                    End If
                End Using
            End Using

            If File.Exists(tempPath) Then File.Delete(tempPath)

        Catch ex As Exception
            Throw New Exception("Error uploading to Firebase: " & ex.Message)
        End Try
    End Function

    ' ====== SAVE FILE INFO TO REALTIME DATABASE ======
    Private Async Function SaveFileDataToDatabase(fileName As String, fileUrl As String) As Task
        Try
            Dim data As New Dictionary(Of String, Object) From {
                {"bn_number", bnnumber.Text.Trim()},
                {"name", fileName},
                {"url", fileUrl},
                {"path", "Files/Franchise/" & fileName},
                {"timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
            }

            Dim jsonData As String = JsonConvert.SerializeObject(data)
            Dim requestUrl As String = $"{FirebaseUrl}/uploadedFiles.json?auth={FirebaseSecret}"

            Using client As New HttpClient()
                Dim content As New StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")
                Await client.PostAsync(requestUrl, content)
            End Using

        Catch ex As Exception
            Throw New Exception("Error saving to Firebase Database: " & ex.Message)
        End Try
    End Function

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Dim f As New Franchise()
        f.Show()
        Me.Close()
    End Sub

    ' ====== DOWNLOAD GOOGLE DOC AS .DOCX ======
    Private Async Sub downloadfile_Click(sender As Object, e As EventArgs) Handles downloadfile.Click
        Try
            Dim downloadUrl As String = "https://docs.google.com/document/d/1bhn2h0P7BiR0fHPCxiFvNhGXKm-HCiF5/export?format=docx"

            Dim saveDialog As New SaveFileDialog() With {
                .Filter = "Word Document (*.docx)|*.docx",
                .FileName = "Franchise-Form.docx",
                .Title = "Save Google Docs File As"
            }

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Using client As New HttpClient()
                    Dim fileBytes = Await client.GetByteArrayAsync(downloadUrl)
                    Await File.WriteAllBytesAsync(saveDialog.FileName, fileBytes)
                End Using

                MessageBox.Show("File downloaded successfully!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error downloading file: " & ex.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bnnumber_TextChanged(sender As Object, e As EventArgs) Handles bnnumber.TextChanged
        ' Optional: Add validation logic here
    End Sub

    Private Sub filedisplay_Paint(sender As Object, e As PaintEventArgs) Handles filedisplay.Paint

    End Sub
End Class
