Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Drawing

Public Class SearchHistory

    ' Firebase URL ng search history
    Private firebaseSearchHistory As String = "https://tricomplain-default-rtdb.firebaseio.com/search history.json"

    Private Async Sub SearchHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ListBox font to monospace for aligned columns
        listsearch.Font = New Font("Consolas", 10, FontStyle.Regular)
        Await LoadSearchHistory()
    End Sub

    ' =====================================================================
    ' LOAD SEARCH HISTORY FROM FIREBASE
    ' =====================================================================
    Private Async Function LoadSearchHistory() As Threading.Tasks.Task
        listsearch.Items.Clear()

        Using client As New HttpClient()
            Try
                Dim response As String = Await client.GetStringAsync(firebaseSearchHistory)

                If String.IsNullOrEmpty(response) OrElse response = "null" Then
                    listsearch.Items.Add("No search history found.")
                    Return
                End If

                Dim data As JObject = JObject.Parse(response)

                ' Add header
                listsearch.Items.Add(String.Format("{0,-10}  {1,-12}  {2,-10}", "Search", "Date", "Time"))
                listsearch.Items.Add(New String("-"c, 36)) ' separator line

                ' Add each history item to the ListBox
                For Each item In data
                    Dim ticket As String = If(item.Value("ticket") IsNot Nothing, item.Value("ticket").ToString(), "N/A")
                    Dim [date] As String = If(item.Value("date") IsNot Nothing, item.Value("date").ToString(), "N/A")
                    Dim time As String = If(item.Value("time") IsNot Nothing, item.Value("time").ToString(), "N/A")

                    ' Format string with padding
                    Dim displayText As String = String.Format("{0,-10}  {1,-12}  {2,-10}", ticket, [date], time)
                    listsearch.Items.Add(displayText)
                Next

            Catch ex As Exception
                MessageBox.Show("Error loading search history: " & ex.Message)
            End Try
        End Using
    End Function

    ' =====================================================================
    ' LISTBOX ITEM SELECTED (OPTIONAL)
    ' =====================================================================
    Private Sub listsearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listsearch.SelectedIndexChanged
        ' Placeholder for future: show details if needed
    End Sub

    ' =====================================================================
    ' CLOSE BUTTON
    ' =====================================================================
    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

End Class
