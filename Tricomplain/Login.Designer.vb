<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Register = New Button()
        loginnow = New Button()
        password = New TextBox()
        email = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        forgetpass = New LinkLabel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Register
        ' 
        Register.Anchor = AnchorStyles.Bottom
        Register.BackColor = Color.SkyBlue
        Register.FlatStyle = FlatStyle.Flat
        Register.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.White
        Register.Location = New Point(148, 378)
        Register.Name = "Register"
        Register.Size = New Size(196, 48)
        Register.TabIndex = 0
        Register.Text = "Register"
        Register.TextImageRelation = TextImageRelation.TextBeforeImage
        Register.UseCompatibleTextRendering = True
        Register.UseVisualStyleBackColor = False
        ' 
        ' loginnow
        ' 
        loginnow.Anchor = AnchorStyles.Bottom
        loginnow.BackColor = Color.SkyBlue
        loginnow.FlatStyle = FlatStyle.Flat
        loginnow.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        loginnow.ForeColor = Color.White
        loginnow.Location = New Point(393, 378)
        loginnow.Name = "loginnow"
        loginnow.Size = New Size(196, 48)
        loginnow.TabIndex = 1
        loginnow.Text = "Login now"
        loginnow.TextImageRelation = TextImageRelation.TextBeforeImage
        loginnow.UseCompatibleTextRendering = True
        loginnow.UseVisualStyleBackColor = False
        ' 
        ' password
        ' 
        password.BorderStyle = BorderStyle.FixedSingle
        password.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        password.Location = New Point(148, 288)
        password.Multiline = True
        password.Name = "password"
        password.Size = New Size(441, 29)
        password.TabIndex = 2
        ' 
        ' email
        ' 
        email.BorderStyle = BorderStyle.FixedSingle
        email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email.Location = New Point(148, 225)
        email.Multiline = True
        email.Name = "email"
        email.Size = New Size(441, 29)
        email.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(70, 225)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 25)
        Label1.TabIndex = 4
        Label1.Text = "Email:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(38, 292)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 5
        Label2.Text = "Password:"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources._552838925_1143202073978236_7425182187908131052_n
        PictureBox1.Location = New Point(286, 46)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(136, 131)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' forgetpass
        ' 
        forgetpass.AutoSize = True
        forgetpass.Location = New Point(495, 332)
        forgetpass.Name = "forgetpass"
        forgetpass.Size = New Size(94, 15)
        forgetpass.TabIndex = 7
        forgetpass.TabStop = True
        forgetpass.Text = "Forget password"
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(676, 483)
        Controls.Add(forgetpass)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(email)
        Controls.Add(password)
        Controls.Add(loginnow)
        Controls.Add(Register)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Home"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Register As Button
    Friend WithEvents loginnow As Button
    Friend WithEvents password As TextBox
    Friend WithEvents email As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents forgetpass As LinkLabel

End Class
