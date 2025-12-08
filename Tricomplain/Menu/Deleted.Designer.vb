<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Deleted
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Deleted))
        deletedlistcomplaints = New Panel()
        Label1 = New Label()
        searchbox = New TextBox()
        Label2 = New Label()
        History = New Button()
        filtertimedate = New Button()
        filterAtoZ = New Button()
        search = New Button()
        count = New Label()
        SuspendLayout()
        ' 
        ' deletedlistcomplaints
        ' 
        deletedlistcomplaints.Location = New Point(30, 150)
        deletedlistcomplaints.Name = "deletedlistcomplaints"
        deletedlistcomplaints.Size = New Size(929, 386)
        deletedlistcomplaints.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Book Antiqua", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(30, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(361, 44)
        Label1.TabIndex = 3
        Label1.Text = "Deleted Complaints"
        ' 
        ' searchbox
        ' 
        searchbox.BorderStyle = BorderStyle.FixedSingle
        searchbox.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchbox.Location = New Point(148, 96)
        searchbox.Multiline = True
        searchbox.Name = "searchbox"
        searchbox.Size = New Size(258, 34)
        searchbox.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(30, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 33)
        Label2.TabIndex = 10
        Label2.Text = "Search:"
        ' 
        ' History
        ' 
        History.Anchor = AnchorStyles.Bottom
        History.BackColor = Color.DarkGoldenrod
        History.FlatStyle = FlatStyle.Flat
        History.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        History.ForeColor = Color.White
        History.Location = New Point(810, 96)
        History.Name = "History"
        History.Size = New Size(149, 48)
        History.TabIndex = 12
        History.Text = "History"
        History.TextImageRelation = TextImageRelation.TextBeforeImage
        History.UseCompatibleTextRendering = True
        History.UseVisualStyleBackColor = False
        ' 
        ' filtertimedate
        ' 
        filtertimedate.Anchor = AnchorStyles.Bottom
        filtertimedate.BackColor = Color.Transparent
        filtertimedate.BackgroundImage = CType(resources.GetObject("filtertimedate.BackgroundImage"), Image)
        filtertimedate.BackgroundImageLayout = ImageLayout.Zoom
        filtertimedate.FlatStyle = FlatStyle.Flat
        filtertimedate.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        filtertimedate.ForeColor = Color.White
        filtertimedate.Location = New Point(724, 107)
        filtertimedate.Name = "filtertimedate"
        filtertimedate.Size = New Size(37, 37)
        filtertimedate.TabIndex = 14
        filtertimedate.TextImageRelation = TextImageRelation.TextBeforeImage
        filtertimedate.UseCompatibleTextRendering = True
        filtertimedate.UseVisualStyleBackColor = False
        ' 
        ' filterAtoZ
        ' 
        filterAtoZ.Anchor = AnchorStyles.Bottom
        filterAtoZ.BackColor = Color.Transparent
        filterAtoZ.BackgroundImage = CType(resources.GetObject("filterAtoZ.BackgroundImage"), Image)
        filterAtoZ.BackgroundImageLayout = ImageLayout.Zoom
        filterAtoZ.FlatStyle = FlatStyle.Flat
        filterAtoZ.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        filterAtoZ.ForeColor = Color.White
        filterAtoZ.Location = New Point(767, 107)
        filterAtoZ.Name = "filterAtoZ"
        filterAtoZ.Size = New Size(37, 37)
        filterAtoZ.TabIndex = 13
        filterAtoZ.TextImageRelation = TextImageRelation.TextBeforeImage
        filterAtoZ.UseCompatibleTextRendering = True
        filterAtoZ.UseVisualStyleBackColor = False
        ' 
        ' search
        ' 
        search.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        search.BackColor = Color.YellowGreen
        search.FlatStyle = FlatStyle.Flat
        search.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        search.ForeColor = Color.White
        search.Location = New Point(412, 112)
        search.Name = "search"
        search.Size = New Size(117, 34)
        search.TabIndex = 15
        search.Text = "Search"
        search.TextImageRelation = TextImageRelation.TextBeforeImage
        search.UseCompatibleTextRendering = True
        search.UseVisualStyleBackColor = False
        ' 
        ' count
        ' 
        count.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        count.AutoSize = True
        count.Font = New Font("Book Antiqua", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        count.ForeColor = Color.Black
        count.Location = New Point(932, 74)
        count.Name = "count"
        count.Size = New Size(45, 19)
        count.TabIndex = 16
        count.Text = "0/100"
        ' 
        ' Deleted
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 563)
        Controls.Add(count)
        Controls.Add(search)
        Controls.Add(filtertimedate)
        Controls.Add(filterAtoZ)
        Controls.Add(History)
        Controls.Add(Label2)
        Controls.Add(searchbox)
        Controls.Add(Label1)
        Controls.Add(deletedlistcomplaints)
        Name = "Deleted"
        Text = "Deleted"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents deletedlistcomplaints As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents History As Button
    Friend WithEvents filtertimedate As Button
    Friend WithEvents filterAtoZ As Button
    Friend WithEvents search As Button
    Friend WithEvents count As Label
End Class
