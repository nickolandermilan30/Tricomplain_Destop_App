<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FranchiseForm
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
        Panel2 = New Panel()
        Panel1 = New Panel()
        btn_Print = New Button()
        PrintPreviewControl1 = New PrintPreviewControl()
        prntDoc_ANNEX_A = New Printing.PrintDocument()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(988, 37)
        Panel2.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btn_Print)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 552)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(988, 43)
        Panel1.TabIndex = 3
        ' 
        ' btn_Print
        ' 
        btn_Print.BackColor = Color.MediumSeaGreen
        btn_Print.Dock = DockStyle.Right
        btn_Print.FlatStyle = FlatStyle.Popup
        btn_Print.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btn_Print.ForeColor = SystemColors.Window
        btn_Print.Location = New Point(829, 0)
        btn_Print.Margin = New Padding(2)
        btn_Print.Name = "btn_Print"
        btn_Print.Size = New Size(159, 43)
        btn_Print.TabIndex = 0
        btn_Print.Text = "Print"
        btn_Print.UseVisualStyleBackColor = False
        ' 
        ' PrintPreviewControl1
        ' 
        PrintPreviewControl1.AutoZoom = False
        PrintPreviewControl1.Dock = DockStyle.Fill
        PrintPreviewControl1.Document = prntDoc_ANNEX_A
        PrintPreviewControl1.Location = New Point(0, 0)
        PrintPreviewControl1.Margin = New Padding(2)
        PrintPreviewControl1.Name = "PrintPreviewControl1"
        PrintPreviewControl1.Size = New Size(988, 595)
        PrintPreviewControl1.TabIndex = 5
        PrintPreviewControl1.Zoom = 1.09R
        ' 
        ' FranchiseForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(988, 595)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PrintPreviewControl1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "FranchiseForm"
        Text = "Franchise"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Print As Button
    Friend WithEvents PrintPreviewControl1 As PrintPreviewControl
    Friend WithEvents prntDoc_ANNEX_A As Printing.PrintDocument
End Class
