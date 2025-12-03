Public Class Home
    Private Sub franchise_Click(sender As Object, e As EventArgs) Handles Franchise.Click
        Dim frm As New Franchise()
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub monitor_Click(sender As Object, e As EventArgs) Handles monitor.Click
        Dim frm As New MonitorComplaints()
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class