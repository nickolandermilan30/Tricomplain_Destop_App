<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        email = New TextBox()
        newpassword = New TextBox()
        changepass = New Button()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' email
        ' 
        email.BorderStyle = BorderStyle.FixedSingle
        email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email.Location = New Point(99, 78)
        email.Multiline = True
        email.Name = "email"
        email.Size = New Size(341, 25)
        email.TabIndex = 0
        ' 
        ' newpassword
        ' 
        newpassword.BorderStyle = BorderStyle.FixedSingle
        newpassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        newpassword.Location = New Point(169, 143)
        newpassword.Multiline = True
        newpassword.Name = "newpassword"
        newpassword.Size = New Size(271, 25)
        newpassword.TabIndex = 1
        ' 
        ' changepass
        ' 
        changepass.Anchor = AnchorStyles.Bottom
        changepass.BackColor = Color.SkyBlue
        changepass.FlatStyle = FlatStyle.Flat
        changepass.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        changepass.ForeColor = Color.White
        changepass.Location = New Point(244, 199)
        changepass.Name = "changepass"
        changepass.Size = New Size(196, 48)
        changepass.TabIndex = 2
        changepass.Text = "Change Password"
        changepass.TextImageRelation = TextImageRelation.TextBeforeImage
        changepass.UseCompatibleTextRendering = True
        changepass.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(29, 78)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 25)
        Label1.TabIndex = 5
        Label1.Text = "Email:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(29, 143)
        Label2.Name = "Label2"
        Label2.Size = New Size(140, 25)
        Label2.TabIndex = 6
        Label2.Text = "New Password:"
        ' 
        ' ChangePassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(492, 269)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(changepass)
        Controls.Add(newpassword)
        Controls.Add(email)
        Name = "ChangePassword"
        Text = "ChangePassword"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents email As TextBox
    Friend WithEvents newpassword As TextBox
    Friend WithEvents changepass As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
