<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValidComplaints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValidComplaints))
        validcomplaintslist = New FlowLayoutPanel()
        Label1 = New Label()
        backbtn = New Button()
        searchbtn = New Button()
        searchvalid = New TextBox()
        SuspendLayout()
        ' 
        ' validcomplaintslist
        ' 
        validcomplaintslist.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        validcomplaintslist.BackColor = Color.Transparent
        validcomplaintslist.ForeColor = SystemColors.ControlText
        validcomplaintslist.Location = New Point(37, 221)
        validcomplaintslist.Margin = New Padding(3, 4, 3, 4)
        validcomplaintslist.Name = "validcomplaintslist"
        validcomplaintslist.Size = New Size(1026, 496)
        validcomplaintslist.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New Font("PMingLiU-ExtB", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(283, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(600, 47)
        Label1.TabIndex = 8
        Label1.Text = "COMPLAINTS MONITORING"
        ' 
        ' backbtn
        ' 
        backbtn.BackColor = Color.LightCoral
        backbtn.FlatStyle = FlatStyle.Flat
        backbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        backbtn.ForeColor = Color.Transparent
        backbtn.Location = New Point(37, 132)
        backbtn.Margin = New Padding(3, 4, 3, 4)
        backbtn.Name = "backbtn"
        backbtn.Size = New Size(160, 68)
        backbtn.TabIndex = 10
        backbtn.Text = "BACK"
        backbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        backbtn.UseCompatibleTextRendering = True
        backbtn.UseVisualStyleBackColor = False
        ' 
        ' searchbtn
        ' 
        searchbtn.BackColor = Color.MediumSeaGreen
        searchbtn.FlatStyle = FlatStyle.Flat
        searchbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        searchbtn.ForeColor = Color.Transparent
        searchbtn.Location = New Point(903, 132)
        searchbtn.Margin = New Padding(3, 4, 3, 4)
        searchbtn.Name = "searchbtn"
        searchbtn.Size = New Size(160, 68)
        searchbtn.TabIndex = 11
        searchbtn.Text = "SEARCH"
        searchbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        searchbtn.UseCompatibleTextRendering = True
        searchbtn.UseVisualStyleBackColor = False
        ' 
        ' searchvalid
        ' 
        searchvalid.BorderStyle = BorderStyle.FixedSingle
        searchvalid.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchvalid.ForeColor = SystemColors.ScrollBar
        searchvalid.Location = New Point(203, 137)
        searchvalid.Margin = New Padding(3, 4, 3, 4)
        searchvalid.Multiline = True
        searchvalid.Name = "searchvalid"
        searchvalid.Size = New Size(692, 55)
        searchvalid.TabIndex = 12
        ' 
        ' ValidComplaints
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1106, 779)
        Controls.Add(searchvalid)
        Controls.Add(searchbtn)
        Controls.Add(backbtn)
        Controls.Add(validcomplaintslist)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "ValidComplaints"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ValidComplaints"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents validcomplaintslist As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents backbtn As Button
    Friend WithEvents searchbtn As Button
    Friend WithEvents searchvalid As TextBox
End Class
