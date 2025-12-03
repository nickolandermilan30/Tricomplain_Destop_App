<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class View
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View))
        back = New Button()
        replace = New Button()
        Label1 = New Label()
        bnnumber = New TextBox()
        changebnnumber = New Button()
        File_Display = New Panel()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' back
        ' 
        back.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        back.BackColor = Color.LightCoral
        back.FlatStyle = FlatStyle.Flat
        back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        back.ForeColor = Color.WhiteSmoke
        back.Location = New Point(80, 672)
        back.Margin = New Padding(3, 4, 3, 4)
        back.Name = "back"
        back.Size = New Size(331, 75)
        back.TabIndex = 12
        back.Text = "CLOSE"
        back.TextImageRelation = TextImageRelation.TextBeforeImage
        back.UseCompatibleTextRendering = True
        back.UseVisualStyleBackColor = False
        ' 
        ' replace
        ' 
        replace.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        replace.BackColor = Color.SkyBlue
        replace.FlatStyle = FlatStyle.Flat
        replace.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        replace.ForeColor = Color.White
        replace.Location = New Point(80, 444)
        replace.Margin = New Padding(3, 4, 3, 4)
        replace.Name = "replace"
        replace.Size = New Size(331, 75)
        replace.TabIndex = 16
        replace.Text = "REPLACE FILE"
        replace.TextImageRelation = TextImageRelation.TextBeforeImage
        replace.UseCompatibleTextRendering = True
        replace.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(161, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(185, 41)
        Label1.TabIndex = 17
        Label1.Text = "BN NUMBER"
        ' 
        ' bnnumber
        ' 
        bnnumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        bnnumber.BorderStyle = BorderStyle.FixedSingle
        bnnumber.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        bnnumber.Location = New Point(80, 101)
        bnnumber.Margin = New Padding(3, 4, 3, 4)
        bnnumber.Multiline = True
        bnnumber.Name = "bnnumber"
        bnnumber.Size = New Size(331, 61)
        bnnumber.TabIndex = 18
        ' 
        ' changebnnumber
        ' 
        changebnnumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        changebnnumber.BackColor = Color.CadetBlue
        changebnnumber.FlatStyle = FlatStyle.Flat
        changebnnumber.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold)
        changebnnumber.ForeColor = Color.WhiteSmoke
        changebnnumber.Location = New Point(80, 345)
        changebnnumber.Margin = New Padding(3, 4, 3, 4)
        changebnnumber.Name = "changebnnumber"
        changebnnumber.Size = New Size(331, 84)
        changebnnumber.TabIndex = 19
        changebnnumber.Text = "CHANGE BN NUMBER"
        changebnnumber.TextImageRelation = TextImageRelation.TextBeforeImage
        changebnnumber.UseCompatibleTextRendering = True
        changebnnumber.UseVisualStyleBackColor = False
        ' 
        ' File_Display
        ' 
        File_Display.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        File_Display.Location = New Point(80, 184)
        File_Display.Margin = New Padding(3, 4, 3, 4)
        File_Display.Name = "File_Display"
        File_Display.Size = New Size(331, 99)
        File_Display.TabIndex = 20
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.BackColor = Color.RoyalBlue
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(80, 534)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(331, 75)
        Button1.TabIndex = 21
        Button1.Text = "VIEW FILE"
        Button1.TextImageRelation = TextImageRelation.TextBeforeImage
        Button1.UseCompatibleTextRendering = True
        Button1.UseVisualStyleBackColor = False
        ' 
        ' View
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(511, 788)
        Controls.Add(Button1)
        Controls.Add(File_Display)
        Controls.Add(changebnnumber)
        Controls.Add(bnnumber)
        Controls.Add(Label1)
        Controls.Add(replace)
        Controls.Add(back)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "View"
        StartPosition = FormStartPosition.CenterScreen
        Text = "View"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents back As Button
    Friend WithEvents replace As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bnnumber As TextBox
    Friend WithEvents changebnnumber As Button



    Friend WithEvents File_Display As Panel
    Friend WithEvents Button1 As Button
End Class
