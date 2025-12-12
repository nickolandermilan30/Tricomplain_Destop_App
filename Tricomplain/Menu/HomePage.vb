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
        Complaints.Columns.Add("ticketNo", "Bn No")            ' 2
        Complaints.Columns.Add("date", "Date")                 ' 3
        Complaints.Columns.Add("destination", "Destination")   ' 4
        Complaints.Columns.Add("message", "Message")           ' 5
        Complaints.Columns.Add("status", "Status")             ' 6
        Complaints.Columns.Add("time", "Time")                 ' 7
        Complaints.Columns.Add("violation", "Violation")       ' 8

        Complaints.AllowUserToAddRows = False
        Complaints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
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
                obj("ticketNo")?.ToString(),        ' Ticket No
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

    ' =======================================
    '    SHOW FULL COMPLAINT ON CLICK
    ' =======================================
    Private Sub Complaints_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Complaints.CellContentClick
        If e.RowIndex < 0 Then Exit Sub  ' ignore header clicks

        Dim selectedRow As DataGridViewRow = Complaints.Rows(e.RowIndex)

        ' Create a new Form to show details
        Dim detailForm As New Form With {
            .Text = "Complaint Details",
            .Size = New Size(700, 600),
            .StartPosition = FormStartPosition.CenterParent
        }

        ' Create a multiline TextBox to show all details
        Dim txtDetails As New TextBox With {
            .Multiline = True,
            .ReadOnly = True,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 12),
            .ScrollBars = ScrollBars.Vertical
        }

        ' Build content
        Dim content As String = $"ID: {selectedRow.Cells("id").Value}{Environment.NewLine}" &
                                $"BN No: {selectedRow.Cells("ticketNo").Value}{Environment.NewLine}" &
                                $"Date: {selectedRow.Cells("date").Value}{Environment.NewLine}" &
                                $"Destination: {selectedRow.Cells("destination").Value}{Environment.NewLine}" &
                                $"Message: {selectedRow.Cells("message").Value}{Environment.NewLine}" &
                                $"Status: {selectedRow.Cells("status").Value}{Environment.NewLine}" &
                                $"Time: {selectedRow.Cells("time").Value}{Environment.NewLine}" &
                                $"Violation: {selectedRow.Cells("violation").Value}{Environment.NewLine}" &
                                $"============================{Environment.NewLine}" &
                                "Skato / Summary Here"

        txtDetails.Text = content
        detailForm.Controls.Add(txtDetails)

        detailForm.ShowDialog()
    End Sub

End Class
