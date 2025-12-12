<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Complaints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Complaints))
        monitor = New Panel()
        LoadingPanel = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Refresh = New Button()
        filterAtoZ = New Button()
        filtertimedate = New Button()
        search = New Button()
        Label3 = New Label()
        searchbox = New TextBox()
        History = New Button()
        Validcomplainbtn = New Button()
        monitor.SuspendLayout()
        SuspendLayout()
        ' 
        ' monitor
        ' 
        monitor.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        monitor.Controls.Add(LoadingPanel)
        monitor.Location = New Point(26, 178)
        monitor.Name = "monitor"
        monitor.Size = New Size(910, 448)
        monitor.TabIndex = 0
        ' 
        ' LoadingPanel
        ' 
        LoadingPanel.Location = New Point(15, 14)
        LoadingPanel.Name = "LoadingPanel"
        LoadingPanel.Size = New Size(11, 12)
        LoadingPanel.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Green
        Label1.Location = New Point(26, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(289, 33)
        Label1.TabIndex = 2
        Label1.Text = "Monitor Complaints"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Book Antiqua", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Green
        Label2.Location = New Point(26, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(209, 26)
        Label2.TabIndex = 3
        Label2.Text = "Manage Complaints"
        ' 
        ' Refresh
        ' 
        Refresh.BackColor = Color.ForestGreen
        Refresh.FlatStyle = FlatStyle.Flat
        Refresh.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Refresh.ForeColor = Color.White
        Refresh.Location = New Point(126, 123)
        Refresh.Name = "Refresh"
        Refresh.Size = New Size(109, 38)
        Refresh.TabIndex = 4
        Refresh.Text = "Refresh"
        Refresh.TextImageRelation = TextImageRelation.TextBeforeImage
        Refresh.UseCompatibleTextRendering = True
        Refresh.UseVisualStyleBackColor = False
        ' 
        ' filterAtoZ
        ' 
        filterAtoZ.BackColor = Color.Transparent
        filterAtoZ.BackgroundImage = CType(resources.GetObject("filterAtoZ.BackgroundImage"), Image)
        filterAtoZ.BackgroundImageLayout = ImageLayout.Zoom
        filterAtoZ.FlatStyle = FlatStyle.Flat
        filterAtoZ.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        filterAtoZ.ForeColor = Color.White
        filterAtoZ.Location = New Point(69, 124)
        filterAtoZ.Name = "filterAtoZ"
        filterAtoZ.Size = New Size(37, 37)
        filterAtoZ.TabIndex = 5
        filterAtoZ.TextImageRelation = TextImageRelation.TextBeforeImage
        filterAtoZ.UseCompatibleTextRendering = True
        filterAtoZ.UseVisualStyleBackColor = False
        ' 
        ' filtertimedate
        ' 
        filtertimedate.BackColor = Color.Transparent
        filtertimedate.BackgroundImage = CType(resources.GetObject("filtertimedate.BackgroundImage"), Image)
        filtertimedate.BackgroundImageLayout = ImageLayout.Zoom
        filtertimedate.FlatStyle = FlatStyle.Flat
        filtertimedate.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        filtertimedate.ForeColor = Color.White
        filtertimedate.Location = New Point(26, 124)
        filtertimedate.Name = "filtertimedate"
        filtertimedate.Size = New Size(37, 37)
        filtertimedate.TabIndex = 6
        filtertimedate.TextImageRelation = TextImageRelation.TextBeforeImage
        filtertimedate.UseCompatibleTextRendering = True
        filtertimedate.UseVisualStyleBackColor = False
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        search.BackColor = Color.YellowGreen
        search.FlatStyle = FlatStyle.Flat
        search.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        search.ForeColor = Color.White
        search.Location = New Point(848, 73)
        search.Name = "search"
        search.Size = New Size(88, 34)
        search.TabIndex = 18
        search.Text = "Search"
        search.TextImageRelation = TextImageRelation.TextBeforeImage
        search.UseCompatibleTextRendering = True
        search.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(481, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 33)
        Label3.TabIndex = 17
        Label3.Text = "Search:"
        ' 
        ' searchbox
        ' 
        searchbox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        searchbox.BorderStyle = BorderStyle.FixedSingle
        searchbox.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchbox.Location = New Point(599, 73)
        searchbox.Multiline = True
        searchbox.Name = "searchbox"
        searchbox.Size = New Size(233, 34)
        searchbox.TabIndex = 16
        ' 
        ' History
        ' 
        History.BackColor = Color.DarkGoldenrod
        History.FlatStyle = FlatStyle.Flat
        History.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        History.ForeColor = Color.White
        History.Location = New Point(241, 123)
        History.Name = "History"
        History.Size = New Size(89, 38)
        History.TabIndex = 19
        History.Text = "History"
        History.TextImageRelation = TextImageRelation.TextBeforeImage
        History.UseCompatibleTextRendering = True
        History.UseVisualStyleBackColor = False
        ' 
        ' Validcomplainbtn
        ' 
        Validcomplainbtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Validcomplainbtn.BackColor = Color.ForestGreen
        Validcomplainbtn.FlatStyle = FlatStyle.Flat
        Validcomplainbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Validcomplainbtn.ForeColor = Color.White
        Validcomplainbtn.Location = New Point(599, 124)
        Validcomplainbtn.Name = "Validcomplainbtn"
        Validcomplainbtn.Size = New Size(337, 38)
        Validcomplainbtn.TabIndex = 20
        Validcomplainbtn.Text = "Valid Complains"
        Validcomplainbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        Validcomplainbtn.UseCompatibleTextRendering = True
        Validcomplainbtn.UseVisualStyleBackColor = False
        ' 
        ' Complaints
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 655)
        Controls.Add(Validcomplainbtn)
        Controls.Add(History)
        Controls.Add(search)
        Controls.Add(filtertimedate)
        Controls.Add(Label3)
        Controls.Add(filterAtoZ)
        Controls.Add(searchbox)
        Controls.Add(Refresh)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(monitor)
        FormBorderStyle = FormBorderStyle.None
        Name = "Complaints"
        Text = "Complaints"
        monitor.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents monitor As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LoadingPanel As Panel
    Friend WithEvents Refresh As Button
    Friend WithEvents filterAtoZ As Button
    Friend WithEvents filtertimedate As Button
    Friend WithEvents search As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents History As Button
    Friend WithEvents Validcomplainbtn As Button
End Class
