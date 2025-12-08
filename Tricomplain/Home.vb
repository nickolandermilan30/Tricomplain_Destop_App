Public Class Home

    ' ============================================
    ' FUNCTION: LOAD A FORM INSIDE PANEL
    ' ============================================
    Private Sub LoadFormToPanel(frm As Form)
        Panel.Controls.Clear()          ' Remove previous content
        frm.TopLevel = False            ' Form inside panel
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill       ' Fill the panel
        Panel.Controls.Add(frm)         ' Add to panel
        frm.Show()                      ' Show form
    End Sub

    ' ============================================
    ' LOAD DEFAULT PAGE WHEN HOME OPENS
    ' ============================================
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As New HomePage()     ' Load HomePage by default
        LoadFormToPanel(f)
    End Sub


    ' ============================================
    ' HOME MENU CLICK
    ' ============================================
    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Dim f As New HomePage()
        LoadFormToPanel(f)
    End Sub


    ' ============================================
    ' COMPLAINTS MENU CLICK
    ' ============================================
    Private Sub ComplaintsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplaintsToolStripMenuItem.Click
        Dim f As New Complaints()
        LoadFormToPanel(f)
    End Sub


    ' ============================================
    ' DELETED COMPLAINTS MENU CLICK
    ' ============================================
    Private Sub DeletedComaplaintsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletedComaplaintsToolStripMenuItem.Click
        Dim f As New Deleted()
        LoadFormToPanel(f)
    End Sub


    Private Sub AccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsToolStripMenuItem.Click
        Dim f As New AccountUser()
        LoadFormToPanel(f)
    End Sub

    ' ============================================
    ' LOGOUT BUTTON (WITH CONFIRMATION)
    ' ============================================
    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click

        Dim result As DialogResult =
            MessageBox.Show("Are you sure you want to log out?",
                            "Logout Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim l As New Login()
            l.Show()
            Me.Hide()
        End If

    End Sub

End Class
