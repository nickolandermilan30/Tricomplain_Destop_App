Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Text

Public Class Complaints

    Private firebaseBase As String = "https://tricomplain-default-rtdb.firebaseio.com/commuter complaint"
    Private firebaseDeleted As String = "https://tricomplain-default-rtdb.firebaseio.com/deleted complaints"
    Private firebaseSearchHistory As String = "https://tricomplain-default-rtdb.firebaseio.com/search history.json"

    Private AllData As JObject
    Private SearchHistoryData As JObject

    ' ============================================================
    ' FORM LOAD
    ' ============================================================
    Private Async Sub Complaints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        monitor.AutoScroll = True
        AddHandler monitor.Scroll, Sub() monitor.Invalidate()

        LoadingPanel.Visible = True
        Await LoadComplaints()
        LoadingPanel.Visible = False
        Await LoadSearchHistory()
    End Sub

    Private Async Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        LoadingPanel.Visible = True
        Await LoadComplaints()
        LoadingPanel.Visible = False
        Await LoadSearchHistory()
    End Sub

    ' ============================================================
    ' LOAD INVALID COMPLAINTS
    ' ============================================================
    Private Async Function LoadComplaints() As Task
        Dim firebaseUrl As String = firebaseBase & ".json"

        Using client As New HttpClient()
            Dim response As String = Await client.GetStringAsync(firebaseUrl)

            If response Is Nothing OrElse response = "null" Then
                monitor.Controls.Clear()
                AllData = Nothing
                Return
            End If

            AllData = JObject.Parse(response)
        End Using

        DisplayCards(AllData)
    End Function


    ' ============================================================
    ' DISPLAY CARDS
    ' ============================================================
    Private Sub DisplayCards(data As JObject)
        monitor.Controls.Clear()
        Dim y As Integer = 10

        For Each p As JProperty In data.Properties()
            Dim key As String = p.Name
            Dim c = p.Value
            Dim status As String = c("status")?.ToString()

            If status = "valid" Then Continue For

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

            card.Top = y
            monitor.Controls.Add(card)
            y += card.Height + 10
        Next
    End Sub


    ' ============================================================
    ' CREATE CARD
    ' ============================================================
    Private Function CreateCard(commuter As String, ticket As String, [date] As String,
                                time As String, destination As String, violation As String,
                                imgUrl As String, status As String) As Panel

        Dim card As New Panel With {
            .Width = monitor.Width - 25,
            .Height = 220,
            .BackColor = Color.FromArgb(240, 248, 255),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblTitle As New Label With {
            .Text = "🧑 " & commuter & " | 🎫 " & ticket,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Top = 5, .Left = 10, .AutoSize = True
        }

        Dim lblInfo As New Label With {
            .Text = "📅 " & [date] & "    🕒 " & time & vbCrLf &
                    "🎯 " & destination & vbCrLf &
                    "⚠️ " & violation,
            .Font = New Font("Segoe UI", 9),
            .Top = 35, .Left = 10,
            .Width = card.Width - 180, .Height = 120
        }

        Dim btnViewImage As New Button With {
            .Width = 150, .Height = 120,
            .Left = card.Width - 170,
            .Top = 25,
            .BackColor = Color.LightSteelBlue,
            .FlatStyle = FlatStyle.Flat,
            .Text = "View Image"
        }
        btnViewImage.FlatAppearance.BorderSize = 0

        AddHandler btnViewImage.Click,
            Sub()
                If imgUrl <> "" Then
                    Dim v As New ImageViewer(imgUrl)
                    v.ShowDialog()
                Else
                    MessageBox.Show("No image uploaded.")
                End If
            End Sub

        Dim btnSwitch As New Button With {
            .Width = 160, .Height = 40,
            .Left = 10, .Top = 160,
            .BackColor = Color.LightGray,
            .FlatStyle = FlatStyle.Flat,
            .Text = "Mark Valid"
        }

        AddHandler btnSwitch.Click,
            Async Sub()
                Await ToggleStatus(commuter, status)
            End Sub

        Dim btnDelete As New Button With {
            .Width = 50, .Height = 40,
            .Left = 180, .Top = 160,
            .BackColor = Color.LightCoral,
            .FlatStyle = FlatStyle.Flat,
            .Text = "🗑️"
        }

        AddHandler btnDelete.Click,
            Async Sub()
                Dim r = MessageBox.Show("Delete complaint?", "Confirm", MessageBoxButtons.YesNo)
                If r = DialogResult.Yes Then
                    Await MoveToDeleted(commuter)
                    Await LoadComplaints()
                End If
            End Sub

        card.Controls.Add(lblTitle)
        card.Controls.Add(lblInfo)
        card.Controls.Add(btnViewImage)
        card.Controls.Add(btnSwitch)
        card.Controls.Add(btnDelete)

        Return card
    End Function



    ' ============================================================
    ' SORT BY DATE/TIME
    ' ============================================================
    Private Sub filtertimedate_Click(sender As Object, e As EventArgs) Handles filtertimedate.Click
        If AllData Is Nothing Then Exit Sub

        Dim sorted As New JObject(
            From p In AllData.Properties()
            Let c = p.Value
            Where c("status")?.ToString() <> "valid"
            Let dt = DateTime.Parse(c("date").ToString() & " " & c("time").ToString())
            Order By dt Descending
            Select New JProperty(p.Name, p.Value)
        )

        DisplayCards(sorted)
    End Sub



    ' ============================================================
    ' SORT A–Z / 1–10
    ' ============================================================
    Private Sub filterAtoZ_Click(sender As Object, e As EventArgs) Handles filterAtoZ.Click
        If AllData Is Nothing Then Exit Sub

        Dim sorted As New JObject(
            From p In AllData.Properties()
            Let c = p.Value
            Where c("status")?.ToString() <> "valid"
            Order By CInt(c("ticketNo").ToString())
            Select New JProperty(p.Name, p.Value)
        )

        DisplayCards(sorted)
    End Sub



    ' ============================================================
    ' MARK VALID
    ' ============================================================
    Private Async Function ToggleStatus(key As String, current As String) As Task
        Dim url As String = firebaseBase & "/" & key & ".json"
        Dim body As String = "{""status"":""valid""}"

        Using client As New HttpClient()
            Dim content As New StringContent(body, Encoding.UTF8, "application/json")
            Await client.PatchAsync(url, content)
        End Using

        Await LoadComplaints()
    End Function



    ' ============================================================
    ' MOVE TO DELETED
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
    ' SEARCH HISTORY LOAD
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
    ' SEARCH INVALID ONLY
    ' ============================================================
    Private Async Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        Dim keyword As String = searchbox.Text.Trim()

        If keyword = "" Then
            Await LoadComplaints()
            Return
        End If

        If Not IsTicketInHistory(keyword) Then
            Await SaveSearchHistory(keyword)
            Await LoadSearchHistory()
        End If

        If AllData Is Nothing Then Return

        Dim results As New JObject(
            From p In AllData.Properties()
            Let c = p.Value
            Where c("status")?.ToString() <> "valid" AndAlso
                  c("ticketNo")?.ToString() = keyword
            Select New JProperty(p.Name, p.Value)
        )

        DisplayCards(results)
    End Sub



    Private Function IsTicketInHistory(ticket As String) As Boolean
        For Each item In SearchHistoryData
            If item.Value("ticket")?.ToString() = ticket Then Return True
        Next
        Return False
    End Function



    Private Async Function SaveSearchHistory(ticket As String) As Task
        Using client As New HttpClient()
            Dim json As String =
                "{""ticket"":""" & ticket & """," &
                """date"":""" & Date.Now.ToString("yyyy-MM-dd") & """," &
                """time"":""" & Date.Now.ToString("HH:mm:ss") & """}"

            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            Await client.PostAsync(firebaseSearchHistory, content)
        End Using
    End Function

    ' ==========================
    '   VALID COMPLAINT BUTTON
    ' ==========================
    Private Sub Validcomplainbtn_Click(sender As Object, e As EventArgs) Handles Validcomplainbtn.Click
        Dim frm As New ValidComplaints()
        frm.Show()
    End Sub


    ' ==========================
    '   HISTORY BUTTON
    ' ==========================
    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        Dim frm As New SearchHistory()
        frm.Show()
    End Sub

End Class




' ============================================================
' IMAGE VIEWER
' ============================================================
Public Class ImageViewer
    Inherits Form

    Public Sub New(url As String)
        Me.Width = 550
        Me.Height = 450
        Me.Text = "Image Viewer"
        Me.StartPosition = FormStartPosition.CenterScreen

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

        Controls.Add(pic)
    End Sub
End Class



' ============================================================
' PATCH EXTENSION
' ============================================================
Module HttpClientExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Function PatchAsync(client As HttpClient, uri As String, content As HttpContent) As Task(Of HttpResponseMessage)
        Dim req = New HttpRequestMessage(HttpMethod.Patch, uri) With {.Content = content}
        Return client.SendAsync(req)
    End Function
End Module
