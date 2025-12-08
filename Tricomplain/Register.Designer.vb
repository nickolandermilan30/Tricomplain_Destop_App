<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        Label2 = New Label()
        Label1 = New Label()
        email = New TextBox()
        password = New TextBox()
        Label3 = New Label()
        username = New TextBox()
        Registernow = New Button()
        Back = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(57, 324)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 9
        Label2.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(89, 266)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 25)
        Label1.TabIndex = 8
        Label1.Text = "Email:"
        ' 
        ' email
        ' 
        email.BorderStyle = BorderStyle.FixedSingle
        email.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email.Location = New Point(167, 266)
        email.Multiline = True
        email.Name = "email"
        email.Size = New Size(441, 29)
        email.TabIndex = 7
        ' 
        ' password
        ' 
        password.BorderStyle = BorderStyle.FixedSingle
        password.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        password.Location = New Point(167, 320)
        password.Multiline = True
        password.Name = "password"
        password.Size = New Size(441, 29)
        password.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(50, 205)
        Label3.Name = "Label3"
        Label3.Size = New Size(103, 25)
        Label3.TabIndex = 11
        Label3.Text = "Username:"
        ' 
        ' username
        ' 
        username.BorderStyle = BorderStyle.FixedSingle
        username.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        username.Location = New Point(167, 205)
        username.Multiline = True
        username.Name = "username"
        username.Size = New Size(441, 29)
        username.TabIndex = 10
        ' 
        ' Registernow
        ' 
        Registernow.Anchor = AnchorStyles.Bottom
        Registernow.BackColor = Color.SkyBlue
        Registernow.FlatStyle = FlatStyle.Flat
        Registernow.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Registernow.ForeColor = Color.White
        Registernow.Location = New Point(412, 390)
        Registernow.Name = "Registernow"
        Registernow.Size = New Size(196, 48)
        Registernow.TabIndex = 12
        Registernow.Text = "Register now"
        Registernow.TextImageRelation = TextImageRelation.TextBeforeImage
        Registernow.UseCompatibleTextRendering = True
        Registernow.UseVisualStyleBackColor = False
        ' 
        ' Back
        ' 
        Back.Anchor = AnchorStyles.Bottom
        Back.BackColor = Color.SkyBlue
        Back.FlatStyle = FlatStyle.Flat
        Back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Back.ForeColor = Color.White
        Back.Location = New Point(167, 390)
        Back.Name = "Back"
        Back.Size = New Size(196, 48)
        Back.TabIndex = 13
        Back.Text = "Back to login"
        Back.TextImageRelation = TextImageRelation.TextBeforeImage
        Back.UseCompatibleTextRendering = True
        Back.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources._552838925_1143202073978236_7425182187908131052_n
        PictureBox1.Location = New Point(289, 27)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(136, 131)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 14
        PictureBox1.TabStop = False
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(676, 483)
        Controls.Add(PictureBox1)
        Controls.Add(Back)
        Controls.Add(Registernow)
        Controls.Add(Label3)
        Controls.Add(username)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(email)
        Controls.Add(password)
        Name = "Register"
        Text = "Register"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents email As TextBox
    Friend WithEvents password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents username As TextBox
    Friend WithEvents Registernow As Button
    Friend WithEvents Back As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
