<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MonitorComplaints
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonitorComplaints))
        Label1 = New Label()
        backbtn = New Button()
        reload = New Button()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        validbtn = New Button()
        penalty = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("PMingLiU-ExtB", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(287, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(600, 47)
        Label1.TabIndex = 3
        Label1.Text = "COMPLAINTS MONITORING"
        ' 
        ' backbtn
        ' 
        backbtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        backbtn.BackColor = Color.LightCoral
        backbtn.FlatStyle = FlatStyle.Flat
        backbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        backbtn.ForeColor = Color.Transparent
        backbtn.Location = New Point(933, 464)
        backbtn.Margin = New Padding(3, 4, 3, 4)
        backbtn.Name = "backbtn"
        backbtn.Size = New Size(160, 93)
        backbtn.TabIndex = 4
        backbtn.Text = "BACK"
        backbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        backbtn.UseCompatibleTextRendering = True
        backbtn.UseVisualStyleBackColor = False
        ' 
        ' reload
        ' 
        reload.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        reload.BackColor = Color.YellowGreen
        reload.FlatStyle = FlatStyle.Flat
        reload.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        reload.ForeColor = Color.Transparent
        reload.Location = New Point(933, 131)
        reload.Margin = New Padding(3, 4, 3, 4)
        reload.Name = "reload"
        reload.Size = New Size(160, 93)
        reload.TabIndex = 5
        reload.Text = "RELOAD"
        reload.TextImageRelation = TextImageRelation.TextBeforeImage
        reload.UseCompatibleTextRendering = True
        reload.UseVisualStyleBackColor = False
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FlowLayoutPanel1.BackColor = Color.Transparent
        FlowLayoutPanel1.ForeColor = SystemColors.ControlText
        FlowLayoutPanel1.Location = New Point(33, 131)
        FlowLayoutPanel1.Margin = New Padding(3, 4, 3, 4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(879, 583)
        FlowLayoutPanel1.TabIndex = 7
        ' 
        ' validbtn
        ' 
        validbtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        validbtn.BackColor = Color.DodgerBlue
        validbtn.FlatStyle = FlatStyle.Flat
        validbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        validbtn.ForeColor = Color.Transparent
        validbtn.Location = New Point(933, 247)
        validbtn.Margin = New Padding(3, 4, 3, 4)
        validbtn.Name = "validbtn"
        validbtn.Size = New Size(160, 81)
        validbtn.TabIndex = 8
        validbtn.Text = "VALID COMPLAINTS"
        validbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        validbtn.UseCompatibleTextRendering = True
        validbtn.UseVisualStyleBackColor = False
        ' 
        ' penalty
        ' 
        penalty.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        penalty.BackColor = Color.Orchid
        penalty.FlatStyle = FlatStyle.Flat
        penalty.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        penalty.ForeColor = Color.Transparent
        penalty.Location = New Point(933, 356)
        penalty.Margin = New Padding(3, 4, 3, 4)
        penalty.Name = "penalty"
        penalty.Size = New Size(160, 81)
        penalty.TabIndex = 10
        penalty.Text = "MESSAGE AND PENALTY"
        penalty.TextImageRelation = TextImageRelation.TextBeforeImage
        penalty.UseCompatibleTextRendering = True
        penalty.UseVisualStyleBackColor = False
        ' 
        ' MonitorComplaints
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1106, 779)
        Controls.Add(penalty)
        Controls.Add(validbtn)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(reload)
        Controls.Add(backbtn)
        Controls.Add(Label1)
        ForeColor = Color.Black
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "MonitorComplaints"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MonitorComplaints"
        TransparencyKey = Color.Transparent
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents backbtn As Button
    Friend WithEvents reload As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents validbtn As Button
    Friend WithEvents penalty As Button
End Class
