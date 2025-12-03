Imports System.Drawing
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Public Class Franchise
    ' === Firebase URLs ===
    Private FirebaseStorageBase As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o"
    Private StorageFolder As String = "Files/Franchise"
    Private UploadedFilesDBUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles.json"

    Private AllFilesData As JObject ' Store all fetched files for searching

    ' === Delegate to refresh list from other forms ===
    Public Delegate Sub RefreshDelegate()
    Public RefreshListCallback As RefreshDelegate

    Private Async Sub Franchise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshListCallback = AddressOf RefreshFileList
        Await RefreshFileList()
    End Sub

    ' === Fetch and display DOCX files (SORTED BY DATE NEWEST → OLDEST) ===
    Public Async Function RefreshFileList() As Task
        Panel1.Controls.Clear()
        Try
            Using client As New HttpClient()
                Dim resp = Await client.GetAsync(UploadedFilesDBUrl)
                Dim json = Await resp.Content.ReadAsStringAsync()

                If String.IsNullOrWhiteSpace(json) OrElse json = "null" Then
                    ShowEmptyMessage("No uploaded DOCX files found.")
                    Return
                End If

                AllFilesData = JObject.Parse(json)

                ' ⭐ SORT BY TIMESTAMP (NEWEST → OLDEST)
                Dim sortedFiles = AllFilesData _
                    .Properties() _
                    .Select(Function(p) p.Value) _
                    .OrderByDescending(Function(x)
                                           Dim dt As DateTime
                                           DateTime.TryParse(x("timestamp")?.ToString(), dt)
                                           Return dt
                                       End Function) _
                    .ToList()

                ' Display sorted
                For Each entry In sortedFiles
                    Dim fileName = entry("name")?.ToString()
                    Dim fileUrl = entry("url")?.ToString()
                    Dim bnNumber = entry("bn_number")?.ToString()
                    Dim archived As Boolean = False
                    If entry("archived") IsNot Nothing Then Boolean.TryParse(entry("archived").ToString(), archived)

                    If Not String.IsNullOrEmpty(fileName) AndAlso fileName.ToLower().EndsWith(".docx") AndAlso Not archived Then
                        AddFileCard(fileName, fileUrl, bnNumber, archived)
                    End If
                Next

            End Using
        Catch ex As Exception
            ShowEmptyMessage("Error loading files: " & ex.Message)
        End Try
    End Function

    ' === Add File Card ===
    Private Sub AddFileCard(fileName As String, fileUrl As String, bnNumber As String, isArchived As Boolean)
        Dim card As New Panel() With {
            .Height = 75,
            .Dock = DockStyle.Top,
            .Padding = New Padding(8),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim pic As New PictureBox() With {
            .Image = SystemIcons.WinLogo.ToBitmap(),
            .Size = New Size(40, 40),
            .Location = New Point(10, 15),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        Dim lblFileName As New Label() With {
            .Text = fileName,
            .Font = New Font("Segoe UI", 10),
            .Location = New Point(60, 25),
            .AutoSize = True
        }

        Dim lblBN As New Label() With {
            .Text = $"BN Number: {bnNumber}",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.MediumBlue,
            .AutoSize = True
        }

        AddHandler card.Resize, Sub()
                                    lblBN.Left = lblFileName.Left + lblFileName.Width + 30
                                    lblBN.Top = 25
                                End Sub

        ' Replace button
        Dim btnView As New Button() With {
            .Text = "Replace",
            .Width = 100,
            .Height = 30,
            .BackColor = Color.LightBlue,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(card.Width - 410, 22)
        }
        AddHandler btnView.Click, Sub()
                                      Dim viewForm As New View()
                                      viewForm.SelectedFileName = fileName
                                      viewForm.SelectedFileUrl = fileUrl
                                      viewForm.SelectedBN = bnNumber
                                      viewForm.Show()
                                  End Sub
        AddHandler card.Resize, Sub() btnView.Left = card.Width - 410

        ' Rename button
        Dim btnRename As New Button() With {
            .Text = "Rename",
            .Width = 80,
            .Height = 30,
            .BackColor = Color.Khaki,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(card.Width - 300, 22)
        }
        AddHandler btnRename.Click, Async Sub()
                                        Await RenameFile(fileName, bnNumber)
                                    End Sub
        AddHandler card.Resize, Sub() btnRename.Left = card.Width - 300

        ' Archive button
        Dim btnArchive As New Button() With {
            .Text = "Archive",
            .Width = 90,
            .Height = 30,
            .BackColor = Color.LightGray,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(card.Width - 200, 22)
        }
        AddHandler btnArchive.Click, Async Sub()
                                         Await ToggleArchive(fileName, fileUrl, True, bnNumber)
                                         Await RefreshFileList()
                                     End Sub

        ' Delete button
        Dim btnDelete As New Button() With {
            .Text = "Delete",
            .Width = 80,
            .Height = 30,
            .BackColor = Color.LightCoral,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(card.Width - 100, 22)
        }
        AddHandler btnDelete.Click, Async Sub()
                                        Dim confirm = MessageBox.Show($"Delete '{fileName}' permanently?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                        If confirm = DialogResult.Yes Then
                                            Await DeleteFileFromFirebase(fileName)
                                            Await DeleteFileAndData(fileName)
                                            MessageBox.Show("File deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Await RefreshFileList()
                                        End If
                                    End Sub

        AddHandler card.Resize, Sub()
                                    btnArchive.Left = card.Width - 200
                                    btnDelete.Left = card.Width - 100
                                End Sub

        card.Controls.AddRange({pic, lblFileName, lblBN, btnView, btnRename, btnArchive, btnDelete})
        Panel1.Controls.Add(card)
        Panel1.Controls.SetChildIndex(card, 0)
    End Sub

    ' === Rename File ===
    Private Async Function RenameFile(oldName As String, bnNumber As String) As Task
        Dim newBaseName As String = InputBox("Enter new file name:", "Rename File", Path.GetFileNameWithoutExtension(oldName))
        If String.IsNullOrWhiteSpace(newBaseName) Then Exit Function

        Try
            Dim oldPath = $"{StorageFolder}/{oldName}"
            Dim newFileName = $"{newBaseName}.docx"
            Dim newPath = $"{StorageFolder}/{newFileName}"
            Dim tempFile = Path.Combine(Path.GetTempPath(), oldName)

            ' Download old file
            Using client As New HttpClient()
                Dim data = Await client.GetByteArrayAsync($"{FirebaseStorageBase}/{Uri.EscapeDataString(oldPath)}?alt=media")
                File.WriteAllBytes(tempFile, data)
            End Using

            ' Upload new file
            Using client As New HttpClient()
                Using fs As New FileStream(tempFile, FileMode.Open)
                    Dim content As New StreamContent(fs)
                    content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    Await client.PostAsync($"{FirebaseStorageBase}?name={Uri.EscapeDataString(newPath)}", content)
                End Using
            End Using

            ' Delete old file & DB record
            Await DeleteFileFromFirebase(oldName)
            Await DeleteFileAndData(oldName)

            ' Save new file info
            Dim newFileUrl = $"{FirebaseStorageBase}/{Uri.EscapeDataString(newPath)}?alt=media"
            Await ToggleArchive(newFileName, newFileUrl, False, bnNumber)

            Await RefreshFileList()
            MessageBox.Show($"Renamed to '{newFileName}' successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Rename failed: " & ex.Message)
        End Try
    End Function

    ' === Archive / Unarchive ===
    Private Async Function ToggleArchive(fileName As String, fileUrl As String, archived As Boolean, bnNumber As String) As Task
        Try
            Dim filePath = $"{StorageFolder}/{fileName}"
            Dim timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim jsonBody = $"{{""bn_number"": ""{bnNumber}"", ""name"": ""{fileName}"", ""path"": ""{filePath}"", ""url"": ""{fileUrl}"", ""timestamp"": ""{timestamp}"", ""archived"": {archived.ToString().ToLower()} }}"

            Using client As New HttpClient()
                Dim getResp = Await client.GetAsync(UploadedFilesDBUrl)
                Dim getJson = Await getResp.Content.ReadAsStringAsync()
                Dim keyToUpdate As String = Nothing

                If Not String.IsNullOrWhiteSpace(getJson) AndAlso getJson <> "null" Then
                    Dim obj As JObject = JObject.Parse(getJson)
                    For Each entry In obj
                        If entry.Value("name")?.ToString() = fileName Then
                            keyToUpdate = entry.Key
                            Exit For
                        End If
                    Next
                End If

                If keyToUpdate Is Nothing Then
                    Await client.PostAsync(UploadedFilesDBUrl, New StringContent(jsonBody, Encoding.UTF8, "application/json"))
                Else
                    Dim updateUrl = $"https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles/{keyToUpdate}.json"
                    Await client.PatchAsync(updateUrl, New StringContent(jsonBody, Encoding.UTF8, "application/json"))
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving archive state: " & ex.Message)
        End Try
    End Function

    ' === Delete DB Data ===
    Private Async Function DeleteFileAndData(fileName As String) As Task
        Try
            Using client As New HttpClient()
                Dim resp = Await client.GetAsync(UploadedFilesDBUrl)
                Dim json = Await resp.Content.ReadAsStringAsync()
                If Not String.IsNullOrWhiteSpace(json) AndAlso json <> "null" Then
                    Dim obj As JObject = JObject.Parse(json)
                    For Each entry In obj
                        If entry.Value("name")?.ToString() = fileName Then
                            Dim delUrl = $"https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles/{entry.Key}.json"
                            Await client.DeleteAsync(delUrl)
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting from DB: " & ex.Message)
        End Try
    End Function

    ' === Delete Firebase Storage File ===
    Private Async Function DeleteFileFromFirebase(fileName As String) As Task
        Try
            Dim fullPath = $"{StorageFolder}/{fileName}"
            Dim deleteUrl = $"{FirebaseStorageBase}/{Uri.EscapeDataString(fullPath)}"
            Using client As New HttpClient()
                Await client.DeleteAsync(deleteUrl)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting from Storage: " & ex.Message)
        End Try
    End Function

    Private Sub ShowEmptyMessage(Optional msg As String = "No .docx files available.")
        Panel1.Controls.Clear()
        Dim lbl As New Label() With {
            .Text = msg,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 11, FontStyle.Italic),
            .ForeColor = Color.Gray,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Panel1.Controls.Add(lbl)
    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Dim f As New Home
        f.Show()
        Close()
    End Sub

    Private Sub unarchive_Click(sender As Object, e As EventArgs) Handles unarchive.Click
        Dim unarchiveForm As New Unarchive()
        unarchiveForm.MainFormRefresh = AddressOf RefreshFileList
        unarchiveForm.Show()
    End Sub

    Private Sub upload_Click(sender As Object, e As EventArgs) Handles upload.Click
        Dim f As New FillUp()
        f.Show()
        Me.Hide()
    End Sub

    '=================================================================
    '            ⭐⭐   BN NUMBER SEARCH FEATURE   ⭐⭐
    '=================================================================

    Private Sub find_Click(sender As Object, e As EventArgs) Handles find.Click
        If AllFilesData Is Nothing Then Return

        Dim searchBN As String = search.Text.Trim()

        If searchBN = "" Then
            MessageBox.Show("Enter BN Number to search.")
            Return
        End If

        Panel1.Controls.Clear()

        Dim found As Boolean = False

        For Each entry In AllFilesData.Properties()
            Dim value = entry.Value
            Dim bn = value("bn_number")?.ToString()

            If bn IsNot Nothing AndAlso bn = searchBN Then
                found = True
                AddFileCard(
                    value("name").ToString(),
                    value("url").ToString(),
                    value("bn_number").ToString(),
                    value("archived")
                )
            End If
        Next

        If Not found Then
            ShowEmptyMessage("No files found for BN Number: " & searchBN)
        End If
    End Sub

    Private Async Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        search.Text = ""
        Await RefreshFileList()
    End Sub

    Private Sub refresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Panel1.Controls.Clear()
        RefreshFileList()
    End Sub
End Class
