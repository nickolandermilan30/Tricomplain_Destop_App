<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Franchise
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Franchise))
        Label1 = New Label()
        upload = New Button()
        back = New Button()
        search = New TextBox()
        Label2 = New Label()
        find = New Button()
        clear = New Button()
        unarchive = New Button()
        Panel1 = New Panel()
        btnrefresh = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Label1.AutoSize = True
        Label1.Font = New Font("PMingLiU-ExtB", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(291, 55)
        Label1.Name = "Label1"
        Label1.Size = New Size(597, 47)
        Label1.TabIndex = 3
        Label1.Text = "FRANCHISE MANAGEMENT"
        ' 
        ' upload
        ' 
        upload.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        upload.BackColor = Color.LightSkyBlue
        upload.FlatStyle = FlatStyle.Flat
        upload.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        upload.ForeColor = Color.White
        upload.Location = New Point(830, 817)
        upload.Margin = New Padding(3, 4, 3, 4)
        upload.Name = "upload"
        upload.Size = New Size(251, 63)
        upload.TabIndex = 4
        upload.Text = "ADD"
        upload.TextImageRelation = TextImageRelation.TextBeforeImage
        upload.UseCompatibleTextRendering = True
        upload.UseVisualStyleBackColor = False
        ' 
        ' back
        ' 
        back.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        back.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        back.FlatStyle = FlatStyle.Flat
        back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        back.ForeColor = Color.White
        back.Location = New Point(31, 816)
        back.Margin = New Padding(3, 4, 3, 4)
        back.Name = "back"
        back.Size = New Size(251, 63)
        back.TabIndex = 5
        back.Text = "BACK"
        back.TextImageRelation = TextImageRelation.TextBeforeImage
        back.UseCompatibleTextRendering = True
        back.UseVisualStyleBackColor = False
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        search.BorderStyle = BorderStyle.FixedSingle
        search.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        search.Location = New Point(168, 137)
        search.Margin = New Padding(3, 4, 3, 4)
        search.Multiline = True
        search.Name = "search"
        search.Size = New Size(476, 53)
        search.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(31, 141)
        Label2.Name = "Label2"
        Label2.Size = New Size(133, 41)
        Label2.TabIndex = 18
        Label2.Text = "SEARCH:"
        ' 
        ' find
        ' 
        find.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        find.BackColor = Color.CadetBlue
        find.FlatStyle = FlatStyle.Flat
        find.Font = New Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        find.ForeColor = Color.WhiteSmoke
        find.Location = New Point(652, 137)
        find.Margin = New Padding(3, 4, 3, 4)
        find.Name = "find"
        find.Size = New Size(136, 53)
        find.TabIndex = 20
        find.Text = "FIND"
        find.TextImageRelation = TextImageRelation.TextBeforeImage
        find.UseCompatibleTextRendering = True
        find.UseVisualStyleBackColor = False
        ' 
        ' clear
        ' 
        clear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        clear.BackColor = Color.Salmon
        clear.FlatStyle = FlatStyle.Flat
        clear.Font = New Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        clear.ForeColor = Color.WhiteSmoke
        clear.Location = New Point(792, 137)
        clear.Margin = New Padding(3, 4, 3, 4)
        clear.Name = "clear"
        clear.Size = New Size(136, 53)
        clear.TabIndex = 20
        clear.Text = "CLEAR"
        clear.TextImageRelation = TextImageRelation.TextBeforeImage
        clear.UseCompatibleTextRendering = True
        clear.UseVisualStyleBackColor = False
        ' 
        ' unarchive
        ' 
        unarchive.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        unarchive.BackColor = Color.YellowGreen
        unarchive.FlatStyle = FlatStyle.Flat
        unarchive.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        unarchive.ForeColor = Color.White
        unarchive.Location = New Point(571, 817)
        unarchive.Margin = New Padding(3, 4, 3, 4)
        unarchive.Name = "unarchive"
        unarchive.Size = New Size(251, 63)
        unarchive.TabIndex = 21
        unarchive.Text = "UNARCHIVE"
        unarchive.TextImageRelation = TextImageRelation.TextBeforeImage
        unarchive.UseCompatibleTextRendering = True
        unarchive.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.White
        Panel1.Location = New Point(31, 219)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1039, 575)
        Panel1.TabIndex = 22
        ' 
        ' refresh
        ' 
        btnrefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnrefresh.BackColor = Color.RoyalBlue
        btnrefresh.FlatStyle = FlatStyle.Flat
        btnrefresh.Font = New Font("Segoe UI Emoji", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnrefresh.ForeColor = Color.WhiteSmoke
        btnrefresh.Location = New Point(932, 137)
        btnrefresh.Margin = New Padding(3, 4, 3, 4)
        btnrefresh.Name = "refresh"
        btnrefresh.Size = New Size(136, 53)
        btnrefresh.TabIndex = 23
        btnrefresh.Text = "REFRESH"
        btnrefresh.TextImageRelation = TextImageRelation.TextBeforeImage
        btnrefresh.UseCompatibleTextRendering = True
        btnrefresh.UseVisualStyleBackColor = False
        ' 
        ' Franchise
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1118, 907)
        Controls.Add(find)
        Controls.Add(btnrefresh)
        Controls.Add(Panel1)
        Controls.Add(unarchive)
        Controls.Add(clear)
        Controls.Add(Label2)
        Controls.Add(search)
        Controls.Add(back)
        Controls.Add(upload)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Franchise"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Franchise"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents upload As Button
    Friend WithEvents back As Button
    Friend WithEvents search As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents find As Button
    Friend WithEvents clear As Button
    Friend WithEvents unarchive As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnrefresh As Button
End Class
