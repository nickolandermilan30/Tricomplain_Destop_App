Imports System.Drawing
Imports System.Net.Http
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Public Class Unarchive

    Private FirebaseStorageBase As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o"
    Private StorageFolder As String = "Files/Franchise"
    Private UploadedFilesDBUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles.json"

    Public MainFormRefresh As Franchise.RefreshDelegate
    Private AllFilesData As JObject

    '==========================================
    '             LOAD FORM
    '==========================================
    Private Async Sub Unarchive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Await LoadArchivedFiles()
        Catch ex As Exception
            MessageBox.Show("Error loading Unarchive: " & ex.Message)
        End Try
    End Sub


    '==========================================
    '     LOAD ARCHIVED FILES FROM FIREBASE
    '==========================================
    Private Async Function LoadArchivedFiles() As Task
        Unarchive_panel.Controls.Clear()
        Try
            Using client As New HttpClient()
                Dim resp = Await client.GetAsync(UploadedFilesDBUrl)
                Dim json = Await resp.Content.ReadAsStringAsync()

                If String.IsNullOrWhiteSpace(json) OrElse json = "null" Then
                    ShowEmptyMessage("No archived files found.")
                    Return
                End If

                AllFilesData = JObject.Parse(json)

                For Each entry In AllFilesData
                    Dim fileName = entry.Value("name")?.ToString()
                    Dim fileUrl = entry.Value("url")?.ToString()
                    Dim bnNumber = entry.Value("bn_number")?.ToString()
                    Dim archived As Boolean = False

                    If entry.Value("archived") IsNot Nothing Then
                        Boolean.TryParse(entry.Value("archived").ToString(), archived)
                    End If

                    If archived Then
                        AddArchivedFileCard(fileName, fileUrl, bnNumber)
                    End If
                Next
            End Using

        Catch ex As Exception
            ShowEmptyMessage("Error loading archived files: " & ex.Message)
        End Try
    End Function



    '==========================================
    '          ADD ARCHIVED FILE CARD
    '==========================================
    Private Sub AddArchivedFileCard(fileName As String, fileUrl As String, bnNumber As String)

        Dim card As New Panel() With {
            .Height = 70,
            .Dock = DockStyle.Top,
            .Padding = New Padding(8),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' FILE ICON
        Dim pic As New PictureBox() With {
            .Image = SystemIcons.WinLogo.ToBitmap(),
            .Size = New Size(40, 40),
            .Location = New Point(10, 15),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        ' FILE NAME
        Dim lblFileName As New Label() With {
            .Text = fileName,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(60, 10),
            .AutoSize = True
        }

        ' BN NUMBER
        Dim lblBN As New Label() With {
            .Text = $"BN Number: {bnNumber}",
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.DarkBlue,
            .Location = New Point(60, 35),
            .AutoSize = True
        }

        ' UNARCHIVE BUTTON
        Dim btnUnarchive As New Button() With {
            .Text = "Unarchive",
            .Width = 100,
            .Height = 30,
            .BackColor = Color.LightGreen,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(card.Width - 120, 20)
        }

        AddHandler btnUnarchive.Click, Async Sub()
                                           Try
                                               Await ToggleArchive(fileName, fileUrl, False, bnNumber)
                                               card.Dispose()

                                               If MainFormRefresh IsNot Nothing Then
                                                   MainFormRefresh.Invoke()
                                               End If
                                           Catch ex As Exception
                                               MessageBox.Show("Error unarchiving file: " & ex.Message)
                                           End Try
                                       End Sub

        AddHandler card.Resize, Sub()
                                    btnUnarchive.Left = card.Width - 120
                                End Sub

        card.Controls.AddRange({pic, lblFileName, lblBN, btnUnarchive})

        Unarchive_panel.Controls.Add(card)
        Unarchive_panel.Controls.SetChildIndex(card, 0)
    End Sub



    '==========================================
    '       UPDATE FIREBASE ARCHIVE STATUS
    '==========================================
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

                If keyToUpdate IsNot Nothing Then
                    Dim updateUrl = $"https://tricomplain-default-rtdb.firebaseio.com/uploadedFiles/{keyToUpdate}.json"
                    Await client.PatchAsync(updateUrl, New StringContent(jsonBody, Encoding.UTF8, "application/json"))
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating archive state: " & ex.Message)
        End Try
    End Function



    '==========================================
    '               SEARCH FEATURE
    '==========================================
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        RunSearch()
    End Sub

    Private Sub searchvalid_TextChanged(sender As Object, e As EventArgs) Handles searchvalid.TextChanged
        If searchvalid.Text.Trim() = "" Then
            Unarchive_panel.Controls.Clear()
            LoadArchivedFiles()
        End If
    End Sub

    Private Sub RunSearch()
        Dim keyword As String = searchvalid.Text.Trim()

        If keyword = "" Then
            LoadArchivedFiles()
            Return
        End If

        Unarchive_panel.Controls.Clear()

        Dim found As Boolean = False

        For Each entry In AllFilesData
            Dim fileName = entry.Value("name")?.ToString()
            Dim fileUrl = entry.Value("url")?.ToString()
            Dim bnNumber = entry.Value("bn_number")?.ToString()
            Dim archived As Boolean = False

            Boolean.TryParse(entry.Value("archived")?.ToString(), archived)

            If archived AndAlso bnNumber IsNot Nothing Then
                If bnNumber.Contains(keyword) Then
                    AddArchivedFileCard(fileName, fileUrl, bnNumber)
                    found = True
                End If
            End If
        Next

        If Not found Then
            ShowEmptyMessage("No results found for BN: " & keyword)
        End If
    End Sub



    '==========================================
    '               EMPTY MESSAGE
    '==========================================
    Private Sub ShowEmptyMessage(Optional msg As String = "No archived files.")
        Unarchive_panel.Controls.Clear()

        Dim lbl As New Label() With {
            .Text = msg,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 11, FontStyle.Italic),
            .ForeColor = Color.Gray,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Unarchive_panel.Controls.Add(lbl)
    End Sub



    '==========================================
    '                 BACK BUTTON
    '==========================================
    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Me.Close()
    End Sub

End Class
