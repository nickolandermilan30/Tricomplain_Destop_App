Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class HomePage

    Private firebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/commuter complaint.json"
    Private AllData As JObject   ' store full firebase data for search

    Private Async Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        Await LoadComplaints()
    End Sub

    ' =======================================
    '   CREATE COLUMNS WITH ORDER YOU WANT
    ' =======================================
    Private Sub SetupGrid()
        Complaints.Columns.Clear()

        Complaints.Columns.Add("id", "ID")                     ' 1
        Complaints.Columns.Add("ticketNo", "Ticket No")        ' 2
        Complaints.Columns.Add("date", "Date")                 ' 3
        Complaints.Columns.Add("destination", "Destination")   ' 4
        Complaints.Columns.Add("message", "Message")           ' 5
        Complaints.Columns.Add("status", "Status")             ' 6
        Complaints.Columns.Add("time", "Time")                 ' 7
        Complaints.Columns.Add("violation", "Violation")       ' 8

        Complaints.AllowUserToAddRows = False
    End Sub

    ' =======================================
    '           LOAD ALL COMPLAINTS
    ' =======================================
    Private Async Function LoadComplaints() As Task
        Try
            Using client As New HttpClient()
                Dim response As String = Await client.GetStringAsync(firebaseUrl)

                If String.IsNullOrWhiteSpace(response) OrElse response = "null" Then
                    MessageBox.Show("No complaints found.")
                    Return
                End If

                AllData = JObject.Parse(response) ' store in memory

                DisplayData(AllData) ' show all data
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading complaints: " & ex.Message)
        End Try

    End Function

    ' =======================================
    '      DISPLAY DATA IN DATAGRIDVIEW
    ' =======================================
    Private Sub DisplayData(data As JObject)
        Complaints.Rows.Clear()

        For Each item In data
            Dim obj = CType(item.Value, JObject)

            Complaints.Rows.Add(
                item.Key,                           ' ID
                obj("ticketNo")?.ToString(),        ' Ticket after ID
                obj("date")?.ToString(),
                obj("destination")?.ToString(),
                obj("message")?.ToString(),
                obj("status")?.ToString(),
                obj("time")?.ToString(),
                obj("violation")?.ToString()
            )
        Next
    End Sub

    ' =======================================
    '            SEARCH TICKET NO
    ' =======================================
    Private Sub searchbox_TextChanged(sender As Object, e As EventArgs) Handles searchbox.TextChanged
        If AllData Is Nothing Then Exit Sub

        Dim keyword As String = searchbox.Text.Trim()

        If keyword = "" Then
            DisplayData(AllData)                      ' show all again
            Return
        End If

        ' FILTER BY ticket number only
        Dim filtered As New JObject()

        For Each item In AllData
            Dim obj = CType(item.Value, JObject)
            Dim ticket = obj("ticketNo")?.ToString()

            If ticket IsNot Nothing AndAlso ticket.Contains(keyword) Then
                filtered.Add(item.Key, obj)
            End If
        Next

        DisplayData(filtered)
    End Sub

    Private Sub Complaints_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Complaints.CellContentClick

    End Sub

End Class
