<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        monitor = New Button()
        Franchise = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' monitor
        ' 
        monitor.Anchor = AnchorStyles.Bottom
        monitor.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        monitor.FlatStyle = FlatStyle.Flat
        monitor.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        monitor.ForeColor = Color.Black
        monitor.Location = New Point(547, 562)
        monitor.Margin = New Padding(3, 4, 3, 4)
        monitor.Name = "monitor"
        monitor.Size = New Size(382, 93)
        monitor.TabIndex = 1
        monitor.Text = "MONITOR COMPLAINTS"
        monitor.TextImageRelation = TextImageRelation.TextBeforeImage
        monitor.UseCompatibleTextRendering = True
        monitor.UseVisualStyleBackColor = False
        ' 
        ' Franchise
        ' 
        Franchise.Anchor = AnchorStyles.Bottom
        Franchise.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        Franchise.FlatStyle = FlatStyle.Flat
        Franchise.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Franchise.ForeColor = Color.Black
        Franchise.Location = New Point(127, 562)
        Franchise.Margin = New Padding(3, 4, 3, 4)
        Franchise.Name = "Franchise"
        Franchise.Size = New Size(382, 93)
        Franchise.TabIndex = 0
        Franchise.Text = "MANAGE FRANCHISE"
        Franchise.TextImageRelation = TextImageRelation.TextBeforeImage
        Franchise.UseCompatibleTextRendering = True
        Franchise.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Black", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(180, 126)
        Label1.Name = "Label1"
        Label1.Size = New Size(731, 67)
        Label1.TabIndex = 2
        Label1.Text = "FRANCHISE MANAGEMENT"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Black", 28.2F, FontStyle.Bold)
        Label2.Location = New Point(465, 244)
        Label2.Name = "Label2"
        Label2.Size = New Size(142, 67)
        Label2.TabIndex = 3
        Label2.Text = "AND"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Black", 28.2F, FontStyle.Bold)
        Label3.Location = New Point(162, 360)
        Label3.Name = "Label3"
        Label3.Size = New Size(736, 67)
        Label3.TabIndex = 4
        Label3.Text = "COMPLAINTS MONITORING"
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1058, 789)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(monitor)
        Controls.Add(Franchise)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Home"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Home"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Franchise As Button
    Friend WithEvents monitor As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label

End Class
