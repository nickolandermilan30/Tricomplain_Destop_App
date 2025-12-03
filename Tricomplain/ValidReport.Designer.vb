<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValidReport
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
        Label1 = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        reload = New Button()
        backbtn = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("PMingLiU-ExtB", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(281, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(600, 47)
        Label1.TabIndex = 4
        Label1.Text = "COMPLAINTS MONITORING"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FlowLayoutPanel1.BackColor = Color.Transparent
        FlowLayoutPanel1.ForeColor = SystemColors.ControlText
        FlowLayoutPanel1.Location = New Point(105, 136)
        FlowLayoutPanel1.Margin = New Padding(3, 4, 3, 4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(879, 498)
        FlowLayoutPanel1.TabIndex = 8
        ' 
        ' reload
        ' 
        reload.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        reload.BackColor = Color.YellowGreen
        reload.FlatStyle = FlatStyle.Flat
        reload.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        reload.ForeColor = Color.Transparent
        reload.Location = New Point(325, 662)
        reload.Margin = New Padding(3, 4, 3, 4)
        reload.Name = "reload"
        reload.Size = New Size(220, 67)
        reload.TabIndex = 6
        reload.Text = "RELOAD"
        reload.TextImageRelation = TextImageRelation.TextBeforeImage
        reload.UseCompatibleTextRendering = True
        reload.UseVisualStyleBackColor = False
        ' 
        ' backbtn
        ' 
        backbtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        backbtn.BackColor = Color.DodgerBlue
        backbtn.FlatStyle = FlatStyle.Flat
        backbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        backbtn.ForeColor = Color.Transparent
        backbtn.Location = New Point(605, 662)
        backbtn.Margin = New Padding(3, 4, 3, 4)
        backbtn.Name = "backbtn"
        backbtn.Size = New Size(220, 67)
        backbtn.TabIndex = 9
        backbtn.Text = "BACK"
        backbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        backbtn.UseCompatibleTextRendering = True
        backbtn.UseVisualStyleBackColor = False
        ' 
        ' ValidReport
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1106, 779)
        Controls.Add(backbtn)
        Controls.Add(reload)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(Label1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "ValidReport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ValidReport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents reload As Button
    Friend WithEvents backbtn As Button
End Class
