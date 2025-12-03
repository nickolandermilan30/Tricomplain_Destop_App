<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Unarchive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Unarchive))
        Label1 = New Label()
        back = New Button()
        Unarchive_panel = New Panel()
        searchvalid = New TextBox()
        Search = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("PMingLiU-ExtB", 28.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(170, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(280, 47)
        Label1.TabIndex = 21
        Label1.Text = "UNARCHIVE"
        ' 
        ' back
        ' 
        back.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        back.BackColor = Color.LightCoral
        back.FlatStyle = FlatStyle.Flat
        back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        back.ForeColor = Color.WhiteSmoke
        back.Location = New Point(418, 731)
        back.Margin = New Padding(3, 4, 3, 4)
        back.Name = "back"
        back.Size = New Size(166, 75)
        back.TabIndex = 20
        back.Text = "CLOSE"
        back.TextImageRelation = TextImageRelation.TextBeforeImage
        back.UseCompatibleTextRendering = True
        back.UseVisualStyleBackColor = False
        ' 
        ' Unarchive_panel
        ' 
        Unarchive_panel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Unarchive_panel.Location = New Point(35, 239)
        Unarchive_panel.Margin = New Padding(3, 4, 3, 4)
        Unarchive_panel.Name = "Unarchive_panel"
        Unarchive_panel.Size = New Size(549, 466)
        Unarchive_panel.TabIndex = 19
        ' 
        ' searchvalid
        ' 
        searchvalid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        searchvalid.BorderStyle = BorderStyle.FixedSingle
        searchvalid.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchvalid.ForeColor = SystemColors.ScrollBar
        searchvalid.Location = New Point(35, 152)
        searchvalid.Margin = New Padding(3, 4, 3, 4)
        searchvalid.Multiline = True
        searchvalid.Name = "searchvalid"
        searchvalid.Size = New Size(373, 55)
        searchvalid.TabIndex = 22
        ' 
        ' Search
        ' 
        Search.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Search.BackColor = Color.LimeGreen
        Search.FlatStyle = FlatStyle.Flat
        Search.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Search.ForeColor = Color.WhiteSmoke
        Search.Location = New Point(427, 152)
        Search.Margin = New Padding(3, 4, 3, 4)
        Search.Name = "Search"
        Search.Size = New Size(158, 56)
        Search.TabIndex = 23
        Search.Text = "Search"
        Search.TextImageRelation = TextImageRelation.TextBeforeImage
        Search.UseCompatibleTextRendering = True
        Search.UseVisualStyleBackColor = False
        ' 
        ' Unarchive
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(625, 838)
        Controls.Add(Search)
        Controls.Add(searchvalid)
        Controls.Add(Label1)
        Controls.Add(back)
        Controls.Add(Unarchive_panel)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Unarchive"
        Text = "Unarchive"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents back As Button
    Friend WithEvents Unarchive_panel As Panel
    Friend WithEvents searchvalid As TextBox
    Friend WithEvents Search As Button
End Class
