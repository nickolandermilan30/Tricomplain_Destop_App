<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Forgot
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
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        Label1 = New Label()
        email = New TextBox()
        password = New TextBox()
        change = New Button()
        back = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources._552838925_1143202073978236_7425182187908131052_n
        PictureBox1.Location = New Point(354, 36)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(136, 131)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 14
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(106, 282)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 13
        Label2.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(138, 215)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 25)
        Label1.TabIndex = 12
        Label1.Text = "Email:"
        ' 
        ' email
        ' 
        email.BorderStyle = BorderStyle.FixedSingle
        email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email.Location = New Point(216, 215)
        email.Multiline = True
        email.Name = "email"
        email.Size = New Size(441, 29)
        email.TabIndex = 11
        ' 
        ' password
        ' 
        password.BorderStyle = BorderStyle.FixedSingle
        password.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        password.Location = New Point(216, 278)
        password.Multiline = True
        password.Name = "password"
        password.Size = New Size(441, 29)
        password.TabIndex = 10
        ' 
        ' change
        ' 
        change.Anchor = AnchorStyles.Bottom
        change.BackColor = Color.SkyBlue
        change.FlatStyle = FlatStyle.Flat
        change.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        change.ForeColor = Color.White
        change.Location = New Point(276, 344)
        change.Name = "change"
        change.Size = New Size(307, 48)
        change.TabIndex = 9
        change.Text = "Change password"
        change.TextImageRelation = TextImageRelation.TextBeforeImage
        change.UseCompatibleTextRendering = True
        change.UseVisualStyleBackColor = False
        ' 
        ' back
        ' 
        back.Anchor = AnchorStyles.Bottom
        back.BackColor = Color.Crimson
        back.FlatStyle = FlatStyle.Flat
        back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        back.ForeColor = Color.White
        back.Location = New Point(276, 413)
        back.Name = "back"
        back.Size = New Size(307, 48)
        back.TabIndex = 8
        back.Text = "Back"
        back.TextImageRelation = TextImageRelation.TextBeforeImage
        back.UseCompatibleTextRendering = True
        back.UseVisualStyleBackColor = False
        ' 
        ' Forgot
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(852, 499)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(email)
        Controls.Add(password)
        Controls.Add(change)
        Controls.Add(back)
        Name = "Forgot"
        Text = "Forgot"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents email As TextBox
    Friend WithEvents password As TextBox
    Friend WithEvents change As Button
    Friend WithEvents back As Button
End Class
