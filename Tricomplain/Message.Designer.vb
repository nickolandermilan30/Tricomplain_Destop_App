<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Message
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Message))
        Label1 = New Label()
        msg = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        stikerno = New Label()
        violation = New Label()
        Label5 = New Label()
        detination = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        submit = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        Label1.Location = New Point(346, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(275, 106)
        Label1.TabIndex = 0
        Label1.Text = "VALID"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' msg
        ' 
        msg.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        msg.BorderStyle = BorderStyle.FixedSingle
        msg.Location = New Point(25, 415)
        msg.Margin = New Padding(3, 4, 3, 4)
        msg.Multiline = True
        msg.Name = "msg"
        msg.Size = New Size(899, 285)
        msg.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(54, 193)
        Label2.Name = "Label2"
        Label2.Size = New Size(138, 32)
        Label2.TabIndex = 2
        Label2.Text = "Sticker No:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(54, 271)
        Label3.Name = "Label3"
        Label3.Size = New Size(125, 32)
        Label3.TabIndex = 3
        Label3.Text = "Violation:"
        ' 
        ' stikerno
        ' 
        stikerno.AutoSize = True
        stikerno.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        stikerno.Location = New Point(186, 193)
        stikerno.Name = "stikerno"
        stikerno.Size = New Size(61, 32)
        stikerno.TabIndex = 4
        stikerno.Text = "N/A"
        ' 
        ' violation
        ' 
        violation.AutoSize = True
        violation.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        violation.Location = New Point(186, 271)
        violation.Name = "violation"
        violation.Size = New Size(61, 32)
        violation.TabIndex = 5
        violation.Text = "N/A"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(616, 193)
        Label5.Name = "Label5"
        Label5.Size = New Size(153, 32)
        Label5.TabIndex = 6
        Label5.Text = "Destination:"
        ' 
        ' detination
        ' 
        detination.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        detination.AutoSize = True
        detination.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        detination.Location = New Point(778, 193)
        detination.Name = "detination"
        detination.Size = New Size(61, 32)
        detination.TabIndex = 7
        detination.Text = "N/A"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(616, 271)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 32)
        Label4.TabIndex = 8
        Label4.Text = "Time:"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(725, 271)
        Label6.Name = "Label6"
        Label6.Size = New Size(61, 32)
        Label6.TabIndex = 9
        Label6.Text = "N/A"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(25, 359)
        Label7.Name = "Label7"
        Label7.Size = New Size(215, 32)
        Label7.TabIndex = 10
        Label7.Text = "Message/Penalty:"
        ' 
        ' submit
        ' 
        submit.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        submit.BackColor = Color.ForestGreen
        submit.FlatStyle = FlatStyle.Flat
        submit.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        submit.ForeColor = Color.Transparent
        submit.Location = New Point(25, 725)
        submit.Margin = New Padding(3, 4, 3, 4)
        submit.Name = "submit"
        submit.Size = New Size(899, 93)
        submit.TabIndex = 11
        submit.Text = "SUBMIT"
        submit.TextImageRelation = TextImageRelation.TextBeforeImage
        submit.UseCompatibleTextRendering = True
        submit.UseVisualStyleBackColor = False
        ' 
        ' Message
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(962, 832)
        Controls.Add(submit)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(detination)
        Controls.Add(Label5)
        Controls.Add(violation)
        Controls.Add(stikerno)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(msg)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Message"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Message"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents msg As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents stikerno As Label
    Friend WithEvents violation As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents detination As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents submit As Button
End Class
