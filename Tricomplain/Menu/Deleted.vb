Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text

Public Class Deleted

    ' Firebase URLs
    Private firebaseDeleted As String = "https://tricomplain-default-rtdb.firebaseio.com/deleted complaints.json"
    Private firebaseActive As String = "https://tricomplain-default-rtdb.firebaseio.com/commuter complaint.json"
    Private firebaseSearchHistory As String = "https://tricomplain-default-rtdb.firebaseio.com/search history"

    Private AllDeletedData As JObject


    Private Async Sub Deleted_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadDeletedComplaints()
    End Sub

    Private Function SafeGet(obj As JToken, field As String) As String
        Try
            If obj(field) Is Nothing Then Return "N/A"
            Return obj(field).ToString()
        Catch
            Return "N/A"
        End Try
    End Function

    ' ==========================================================
    ' LOAD ALL DELETED COMPLAINTS
    ' ==========================================================
    Private Async Function LoadDeletedComplaints() As Threading.Tasks.Task
        deletedlistcomplaints.Controls.Clear()
        deletedlistcomplaints.AutoScroll = True

        Using client As New HttpClient()
            Try
                Dim response As String = Await client.GetStringAsync(firebaseDeleted)

                If response Is Nothing OrElse response = "null" Then
                    deletedlistcomplaints.Controls.Add(New Label With {
                        .Text = "No deleted complaints found.",
                        .AutoSize = True,
                        .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                        .Left = 10,
                        .Top = 10
                    })
                    Return
                End If

                AllDeletedData = JObject.Parse(response)
                DisplayComplaints(AllDeletedData)

            Catch ex As Exception
                MessageBox.Show("Error loading deleted complaints: " & ex.Message)
            End Try
        End Using
    End Function

    ' ==========================================================
    ' DISPLAY PANEL RESULT
    ' ==========================================================
    Private Sub DisplayComplaints(data As JObject)
        deletedlistcomplaints.Controls.Clear()

        Dim yOffset As Integer = 10
        Dim maxLimit As Integer = 100
        Dim counter As Integer = 0

        For Each item In data

            If counter >= maxLimit Then Exit For  ' 🔥 LIMIT 100 ONLY

            Dim key As String = item.Key
            Dim complaint = item.Value

            Dim pnl As New Panel With {
            .Width = deletedlistcomplaints.Width - 35,
            .Height = 180,
            .Top = yOffset,
            .Left = 10,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(245, 245, 245)
        }

            pnl.Controls.Add(New Label With {.Text = "Ticket No: " & SafeGet(complaint, "ticketNo"), .Top = 10, .Left = 10, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .AutoSize = True})
            pnl.Controls.Add(New Label With {.Text = "Date: " & SafeGet(complaint, "date") & "   Time: " & SafeGet(complaint, "time"), .Top = 35, .Left = 10, .AutoSize = True})
            pnl.Controls.Add(New Label With {.Text = "Destination: " & SafeGet(complaint, "destination"), .Top = 55, .Left = 10, .AutoSize = True})
            pnl.Controls.Add(New Label With {.Text = "Violation: " & SafeGet(complaint, "violation"), .Top = 75, .Left = 10, .AutoSize = True})
            pnl.Controls.Add(New Label With {.Text = "Status: " & SafeGet(complaint, "status"), .Top = 95, .Left = 10, .ForeColor = Color.DarkGreen, .Font = New Font("Segoe UI", 8, FontStyle.Italic), .AutoSize = True})

            ' IMAGE
            If complaint("fileUrls") IsNot Nothing AndAlso complaint("fileUrls").HasValues Then
                Try
                    Dim imgUrl As String = complaint("fileUrls")(0).ToString()
                    Dim pic As New PictureBox With {.Width = 120, .Height = 120, .Top = 10, .Left = pnl.Width - 140, .SizeMode = PictureBoxSizeMode.Zoom, .BorderStyle = BorderStyle.FixedSingle}

                    Dim req As HttpWebRequest = CType(HttpWebRequest.Create(imgUrl), HttpWebRequest)
                    Using resImg As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
                        Using stream As Stream = resImg.GetResponseStream()
                            pic.Image = Image.FromStream(stream)
                        End Using
                    End Using

                    pnl.Controls.Add(pic)
                Catch
                End Try
            End If

            ' RETRIEVE BUTTON
            Dim btnRetrieve As New Button With {
            .Text = "Retrieve",
            .Width = 100,
            .Height = 40,
            .Top = pnl.Height - 50,
            .Left = 10,
            .BackColor = Color.FromArgb(0, 123, 255),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }

            AddHandler btnRetrieve.Click, Async Sub()
                                              If MessageBox.Show("Retrieve this complaint?", "Confirm", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                                                  Await RetrieveComplaint(key, complaint)
                                                  MessageBox.Show("Complaint retrieved successfully!")
                                                  Await LoadDeletedComplaints()
                                              End If
                                          End Sub

            pnl.Controls.Add(btnRetrieve)

            ' PERMANENT DELETE BUTTON
            Dim btnDelete As New Button With {
            .Text = "Permanent Delete",
            .Width = 140,
            .Height = 40,
            .Top = pnl.Height - 50,
            .Left = btnRetrieve.Right + 10,
            .BackColor = Color.FromArgb(220, 53, 69),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }

            AddHandler btnDelete.Click, Async Sub()
                                            If MessageBox.Show("Delete this permanently?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                                                Await DeleteComplaint(key)
                                                MessageBox.Show("Permanently deleted!")
                                                Await LoadDeletedComplaints()
                                            End If
                                        End Sub

            pnl.Controls.Add(btnDelete)

            deletedlistcomplaints.Controls.Add(pnl)

            yOffset += pnl.Height + 10
            counter += 1
        Next

        ' 🔥 UPDATE LABEL COUNT (ex: 45/100)
        UpdateCountLabel(counter)

    End Sub


    Private Sub UpdateCountLabel(total As Integer)
        count.Text = total.ToString() & "/100"
    End Sub



    ' ==========================================================
    ' CHECK + SAVE SEARCH HISTORY (NO DUPLICATE)
    ' ==========================================================
    Private Async Function SaveSearchHistory(ticket As String) As Threading.Tasks.Task
        Using client As New HttpClient()

            ' 1. Load history first
            Dim historyRaw As String = Await client.GetStringAsync(firebaseSearchHistory & ".json")
            Dim history As JObject = Nothing

            If Not String.IsNullOrEmpty(historyRaw) AndAlso historyRaw <> "null" Then
                history = JObject.Parse(historyRaw)

                ' 2. Check if ticket already saved
                For Each entry In history
                    If entry.Value("ticket")?.ToString() = ticket Then
                        Return ' already exists → DON'T SAVE
                    End If
                Next
            End If

            ' 3. Save only if not existing
            Dim historyJson As String =
                "{""ticket"":""" & ticket & """," &
                """date"":""" & Date.Now.ToString("yyyy-MM-dd") & """," &
                """time"":""" & Date.Now.ToString("HH:mm:ss") & """}"

            Dim content As New StringContent(historyJson, Encoding.UTF8, "application/json")
            Await client.PostAsync(firebaseSearchHistory & ".json", content)

        End Using
    End Function


    ' ==========================================================
    ' SEARCH
    ' ==========================================================
    Private Async Sub search_Click(sender As Object, e As EventArgs) Handles search.Click

        If AllDeletedData Is Nothing Then Exit Sub
        Dim keyword As String = searchbox.Text.Trim()

        If keyword = "" Then
            DisplayComplaints(AllDeletedData)
            Exit Sub
        End If

        Await SaveSearchHistory(keyword)

        Dim filtered As New JObject()

        For Each item In AllDeletedData
            Dim complaint = item.Value
            Dim ticket As String = SafeGet(complaint, "ticketNo")

            If ticket.ToLower().Contains(keyword.ToLower()) Then
                filtered.Add(item.Key, item.Value)
            End If
        Next

        If filtered.Count = 0 Then
            deletedlistcomplaints.Controls.Clear()
            deletedlistcomplaints.Controls.Add(New Label With {
                .Text = "No matching ticket found.",
                .Top = 10,
                .Left = 10,
                .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                .AutoSize = True
            })
        Else
            DisplayComplaints(filtered)
        End If
    End Sub

    ' ==========================================================
    ' SORT NEWEST FIRST
    ' ==========================================================
    Private Sub filtertimedate_Click(sender As Object, e As EventArgs) Handles filtertimedate.Click
        If AllDeletedData Is Nothing Then Exit Sub

        Dim sorted = New JObject(
            AllDeletedData.Properties().
            OrderByDescending(Function(p)
                                  Dim d = SafeGet(p.Value, "date")
                                  Dim t = SafeGet(p.Value, "time")
                                  Dim dt As DateTime
                                  DateTime.TryParse(d & " " & t, dt)
                                  Return dt
                              End Function)
        )

        DisplayComplaints(sorted)
    End Sub

    ' ==========================================================
    ' SORT A → Z
    ' ==========================================================
    Private Sub filterAtoZ_Click(sender As Object, e As EventArgs) Handles filterAtoZ.Click
        If AllDeletedData Is Nothing Then Exit Sub

        Dim sorted = New JObject(
            AllDeletedData.Properties().
            OrderBy(Function(p)
                        Return SafeGet(p.Value, "ticketNo")
                    End Function)
        )

        DisplayComplaints(sorted)
    End Sub

    Private Async Function RetrieveComplaint(key As String, complaint As JToken) As Threading.Tasks.Task
        Using client As New HttpClient()
            Dim json As String = complaint.ToString()
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            Await client.PostAsync(firebaseActive, content)

            Dim deleteUrl As String = $"https://tricomplain-default-rtdb.firebaseio.com/deleted complaints/{key}.json"
            Await client.DeleteAsync(deleteUrl)
        End Using
    End Function

    Private Async Function DeleteComplaint(key As String) As Threading.Tasks.Task
        Using client As New HttpClient()
            Dim deleteUrl As String = $"https://tricomplain-default-rtdb.firebaseio.com/deleted complaints/{key}.json"
            Await client.DeleteAsync(deleteUrl)
        End Using
    End Function

    ' ==========================================================
    ' OPEN SEARCH HISTORY WINDOW
    ' ==========================================================
    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        Try
            Dim historyForm As New SearchHistory()
            historyForm.Show()
            historyForm.BringToFront()
        Catch ex As Exception
            MessageBox.Show("Error opening search history: " & ex.Message)
        End Try
    End Sub

    Private Sub count_Click(sender As Object, e As EventArgs) Handles count.Click

    End Sub
End Class
