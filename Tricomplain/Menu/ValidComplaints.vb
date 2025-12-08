Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Text

Public Class ValidComplaints

    Private firebaseBase As String = "https://tricomplain-default-rtdb.firebaseio.com/commuter complaint"
    Private firebaseDeleted As String = "https://tricomplain-default-rtdb.firebaseio.com/deleted complaints"
    Private firebaseSearchHistory As String = "https://tricomplain-default-rtdb.firebaseio.com/search history.json"

    Private AllData As JObject
    Private SearchHistoryData As JObject

    ' ============================================================
    ' FORM LOAD
    ' ============================================================
    Private Async Sub ValidComplaints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValidComplain.AutoScroll = True
        AddHandler ValidComplain.Scroll, Sub() ValidComplain.Invalidate()
        AddHandler searchbox.TextChanged, AddressOf SearchBox_TextChanged
        LoadingPanel.Visible = True
        Await LoadValidComplaints()
        LoadingPanel.Visible = False
        Await LoadSearchHistory()
    End Sub

    Private Async Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        LoadingPanel.Visible = True
        Await LoadValidComplaints()
        LoadingPanel.Visible = False
        Await LoadSearchHistory()
    End Sub

    ' ============================================================
    ' LOAD ONLY VALID COMPLAINTS
    ' ============================================================
    Private Async Function LoadValidComplaints() As Task
        Dim firebaseUrl As String = firebaseBase & ".json"

        Using client As New HttpClient()
            Dim response As String = Await client.GetStringAsync(firebaseUrl)

            If String.IsNullOrEmpty(response) OrElse response = "null" Then
                ValidComplain.Controls.Clear()
                AllData = Nothing
                Return
            End If

            AllData = JObject.Parse(response)
        End Using

        ValidComplain.Controls.Clear()
        Dim y As Integer = 10

        For Each item In AllData
            Dim key As String = item.Key
            Dim c = item.Value
            Dim status As String = c("status")?.ToString()

            If status <> "valid" Then Continue For

            Dim card As Panel = CreateCard(
                key,
                c("ticketNo")?.ToString(),
                c("date")?.ToString(),
                c("time")?.ToString(),
                c("destination")?.ToString(),
                c("violation")?.ToString(),
                If(c("fileUrls") IsNot Nothing AndAlso c("fileUrls").HasValues, c("fileUrls")(0).ToString(), ""),
                status
            )

            card.Tag = key
            card.Top = y
            ValidComplain.Controls.Add(card)
            y += card.Height + 12
        Next
    End Function

    ' ============================================================
    ' CREATE CARD — FULL WIDTH + CLEAN UI
    ' ============================================================
    Private Function CreateCard(commuter As String, ticket As String, [date] As String,
                                time As String, destination As String, violation As String,
                                imgUrl As String, status As String) As Panel

        Dim fullWidth As Integer = ValidComplain.Width - 35

        Dim card As New Panel With {
            .Width = fullWidth,
            .Height = 210,
            .BackColor = Color.FromArgb(235, 245, 255),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblTitle As New Label With {
            .Text = "🧑 " & commuter & "   |   🎫 Ticket: " & ticket,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Top = 8,
            .Left = 12,
            .ForeColor = Color.DarkBlue,
            .AutoSize = True
        }

        Dim lblInfo As New Label With {
            .Text = "📅 " & [date] & "    🕒 " & time & vbCrLf &
                    "🎯 Destination: " & destination & vbCrLf &
                    "⚠️ Violation: " & violation,
            .Font = New Font("Segoe UI", 10),
            .Top = 45,
            .Left = 12,
            .Width = card.Width - 180,
            .Height = 90
        }

        ' VIEW IMAGE BUTTON
        Dim btnViewImage As New Button With {
            .Width = 150,
            .Height = 120,
            .Left = card.Width - 165,
            .Top = 30,
            .BackColor = Color.LightSteelBlue,
            .FlatStyle = FlatStyle.Flat,
            .Text = "View Image"
        }
        btnViewImage.FlatAppearance.BorderSize = 0

        AddHandler btnViewImage.Click,
            Sub()
                If imgUrl <> "" Then
                    ShowImage(imgUrl)
                Else
                    MessageBox.Show("No image uploaded.")
                End If
            End Sub

        ' BUTTON BAR
        Dim btnY As Integer = 160
        Dim btnW As Integer = 125
        Dim btnH As Integer = 40
        Dim x As Integer = 12

        ' MARK INVALID
        Dim btnSwitch As New Button With {
            .Width = btnW,
            .Height = btnH,
            .Left = x,
            .Top = btnY,
            .BackColor = Color.LightGray,
            .FlatStyle = FlatStyle.Flat,
            .Text = "Mark Invalid"
        }
        AddHandler btnSwitch.Click,
            Async Sub()
                Await ToggleStatus(commuter, status)
            End Sub
        card.Controls.Add(btnSwitch)

        x += btnW + 10

        ' MESSAGE
        Dim btnMessage As New Button With {
            .Width = btnW,
            .Height = btnH,
            .Left = x,
            .Top = btnY,
            .BackColor = Color.LightBlue,
            .FlatStyle = FlatStyle.Flat,
            .Text = "Message"
        }
        AddHandler btnMessage.Click,
            Sub()
                Dim m As New Message(commuter)
                m.ShowDialog()
            End Sub
        card.Controls.Add(btnMessage)

        x += btnW + 10

        ' FRANCHISE
        Dim btnFranchise As New Button With {
            .Width = btnW,
            .Height = btnH,
            .Left = x,
            .Top = btnY,
            .BackColor = Color.LightGreen,
            .FlatStyle = FlatStyle.Flat,
            .Text = "Franchise"
        }
        AddHandler btnFranchise.Click,
            Sub()
                Dim f As New FranchiseForm()
                f.ShowDialog()
            End Sub
        card.Controls.Add(btnFranchise)

        x += btnW + 10

        ' DELETE
        Dim btnDelete As New Button With {
            .Width = 45,
            .Height = btnH,
            .Left = x,
            .Top = btnY,
            .BackColor = Color.LightCoral,
            .FlatStyle = FlatStyle.Flat,
            .Text = "🗑️"
        }
        AddHandler btnDelete.Click,
            Async Sub()
                Dim r = MessageBox.Show("Delete complaint?", "Confirm", MessageBoxButtons.YesNo)
                If r = DialogResult.Yes Then
                    Await MoveToDeleted(commuter)
                    Await LoadValidComplaints()
                End If
            End Sub
        card.Controls.Add(btnDelete)

        ' ADD CONTROLS
        card.Controls.Add(lblTitle)
        card.Controls.Add(lblInfo)
        card.Controls.Add(btnViewImage)

        Return card
    End Function

    ' ============================================================
    ' TOGGLE STATUS
    ' ============================================================
    Private Async Function ToggleStatus(key As String, current As String) As Task
        Dim newStatus As String = If(current = "valid", "invalid", "valid")
        Dim url As String = firebaseBase & "/" & key & ".json"
        Dim body As String = "{""status"":""" & newStatus & """}"

        Using client As New HttpClient()
            Dim content As New StringContent(body, Encoding.UTF8, "application/json")
            Dim req = New HttpRequestMessage(New HttpMethod("PATCH"), url) With {.Content = content}
            Await client.SendAsync(req)
        End Using

        Await LoadValidComplaints()
    End Function

    ' ============================================================
    ' DELETE COMPLAINT
    ' ============================================================
    Private Async Function MoveToDeleted(key As String) As Task
        Using client As New HttpClient()
            Dim origUrl As String = firebaseBase & "/" & key & ".json"
            Dim data As String = Await client.GetStringAsync(origUrl)
            If data = "null" Then Exit Function

            Dim newUrl As String = firebaseDeleted & "/" & key & ".json"
            Dim content As New StringContent(data, Encoding.UTF8, "application/json")
            Await client.PutAsync(newUrl, content)
            Await client.DeleteAsync(origUrl)
        End Using
    End Function

    ' ============================================================
    ' LOAD SEARCH HISTORY
    ' ============================================================
    Private Async Function LoadSearchHistory() As Task
        Using client As New HttpClient()
            Try
                Dim response As String = Await client.GetStringAsync(firebaseSearchHistory)
                SearchHistoryData = If(response = "null", New JObject(), JObject.Parse(response))
            Catch
                SearchHistoryData = New JObject()
            End Try
        End Using
    End Function

    ' ============================================================
    ' IMAGE VIEWER
    ' ============================================================
    Private Sub ShowImage(url As String)
        Dim f As New Form With {
            .Width = 550,
            .Height = 450,
            .Text = "Image Viewer",
            .StartPosition = FormStartPosition.CenterScreen
        }

        Dim pic As New PictureBox With {
            .Dock = DockStyle.Fill,
            .SizeMode = PictureBoxSizeMode.Zoom
        }

        Try
            Dim wc As New Net.WebClient()
            Dim bytes = wc.DownloadData(url)
            Using ms As New IO.MemoryStream(bytes)
                pic.Image = Image.FromStream(ms)
            End Using
        Catch
        End Try

        f.Controls.Add(pic)
        f.ShowDialog()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        MyBase.Close()

    End Sub

    ' ============================================================
    ' SEARCH FUNCTION
    ' ============================================================
    Private Async Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles searchbox.TextChanged

        If AllData Is Nothing Then Exit Sub

        Dim query As String = searchbox.Text.Trim().ToLower()

        ValidComplain.Controls.Clear()

        ' If search box empty → show all again
        If query = "" Then
            Await LoadValidComplaints()

            Return
        End If

        Dim y As Integer = 10
        Dim found As Boolean = False

        For Each item In AllData
            Dim key As String = item.Key
            Dim c = item.Value
            Dim status As String = c("status")?.ToString()

            ' Only show valid complaints
            If status <> "valid" Then Continue For

            ' 🔥 Convert all possible searchable fields to lowercase
            Dim ticket As String = c("ticketNo")?.ToString()?.ToLower()
            Dim destination As String = c("destination")?.ToString()?.ToLower()
            Dim violation As String = c("violation")?.ToString()?.ToLower()
            Dim dateVal As String = c("date")?.ToString()?.ToLower()
            Dim timeVal As String = c("time")?.ToString()?.ToLower()
            Dim commuterId As String = key.ToLower()

            ' 🔍 Check if search matches anything
            Dim match As Boolean =
                (ticket IsNot Nothing AndAlso ticket.Contains(query)) OrElse
                (destination IsNot Nothing AndAlso destination.Contains(query)) OrElse
                (violation IsNot Nothing AndAlso violation.Contains(query)) OrElse
                (dateVal IsNot Nothing AndAlso dateVal.Contains(query)) OrElse
                (timeVal IsNot Nothing AndAlso timeVal.Contains(query)) OrElse
                (commuterId.Contains(query))

            If match Then
                found = True

                Dim imgUrl As String = ""
                If c("fileUrls") IsNot Nothing AndAlso c("fileUrls").HasValues Then
                    imgUrl = c("fileUrls")(0).ToString()
                End If

                Dim card As Panel = CreateCard(
                    key,
                    c("ticketNo")?.ToString(),
                    c("date")?.ToString(),
                    c("time")?.ToString(),
                    c("destination")?.ToString(),
                    c("violation")?.ToString(),
                    imgUrl,
                    status
                )

                card.Top = y
                ValidComplain.Controls.Add(card)
                y += card.Height + 12
            End If
        Next

        If Not found Then
            Dim lbl As New Label With {
                .Text = "No results found.",
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.Red,
                .AutoSize = True,
                .Top = 20,
                .Left = 20
            }
            ValidComplain.Controls.Add(lbl)
        End If
    End Sub

End Class
