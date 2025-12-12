<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        HomeToolStripMenuItem = New ToolStripMenuItem()
        ComplaintsToolStripMenuItem = New ToolStripMenuItem()
        DeletedComaplaintsToolStripMenuItem = New ToolStripMenuItem()
        logout = New ToolStripMenuItem()
        AccountsToolStripMenuItem = New ToolStripMenuItem()
        Panel = New Panel()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.SkyBlue
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuStrip1.GripMargin = New Padding(2, 2, 0, 5)
        MenuStrip1.Items.AddRange(New ToolStripItem() {HomeToolStripMenuItem, ComplaintsToolStripMenuItem, DeletedComaplaintsToolStripMenuItem, logout, AccountsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(4, 2, 0, 2)
        MenuStrip1.Size = New Size(222, 573)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' HomeToolStripMenuItem
        ' 
        HomeToolStripMenuItem.BackColor = Color.PaleGreen
        HomeToolStripMenuItem.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        HomeToolStripMenuItem.ForeColor = Color.Black
        HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        HomeToolStripMenuItem.Size = New Size(213, 34)
        HomeToolStripMenuItem.Text = "Home"
        ' 
        ' ComplaintsToolStripMenuItem
        ' 
        ComplaintsToolStripMenuItem.BackColor = Color.PaleGreen
        ComplaintsToolStripMenuItem.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComplaintsToolStripMenuItem.ForeColor = Color.Black
        ComplaintsToolStripMenuItem.Name = "ComplaintsToolStripMenuItem"
        ComplaintsToolStripMenuItem.Size = New Size(213, 34)
        ComplaintsToolStripMenuItem.Text = "Complaints"
        ' 
        ' DeletedComaplaintsToolStripMenuItem
        ' 
        DeletedComaplaintsToolStripMenuItem.BackColor = Color.PaleGreen
        DeletedComaplaintsToolStripMenuItem.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DeletedComaplaintsToolStripMenuItem.Name = "DeletedComaplaintsToolStripMenuItem"
        DeletedComaplaintsToolStripMenuItem.Size = New Size(213, 34)
        DeletedComaplaintsToolStripMenuItem.Text = "Deleted Comaplaints"
        ' 
        ' logout
        ' 
        logout.Alignment = ToolStripItemAlignment.Right
        logout.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        logout.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        logout.Name = "logout"
        logout.Size = New Size(213, 34)
        logout.Text = "Log Out"
        ' 
        ' AccountsToolStripMenuItem
        ' 
        AccountsToolStripMenuItem.Alignment = ToolStripItemAlignment.Right
        AccountsToolStripMenuItem.BackColor = Color.YellowGreen
        AccountsToolStripMenuItem.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        AccountsToolStripMenuItem.Size = New Size(156, 34)
        AccountsToolStripMenuItem.Text = "Accounts"
        ' 
        ' Panel
        ' 
        Panel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel.Location = New Point(225, 0)
        Panel.Name = "Panel"
        Panel.Size = New Size(819, 574)
        Panel.TabIndex = 1
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Window
        ClientSize = New Size(1044, 573)
        Controls.Add(Panel)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "Home"
        Text = "Tricomplaints"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComplaintsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeletedComaplaintsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents logout As ToolStripMenuItem
    Friend WithEvents Panel As Panel
    Friend WithEvents AccountsToolStripMenuItem As ToolStripMenuItem
End Class
