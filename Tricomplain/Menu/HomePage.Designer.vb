<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage
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
        Complaints = New DataGridView()
        Label1 = New Label()
        Label3 = New Label()
        searchbox = New TextBox()
        CType(Complaints, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Complaints
        ' 
        Complaints.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Complaints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Complaints.Location = New Point(23, 83)
        Complaints.Name = "Complaints"
        Complaints.Size = New Size(924, 545)
        Complaints.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Green
        Label1.Location = New Point(23, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(289, 33)
        Label1.TabIndex = 3
        Label1.Text = "Monitor Complaints"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(511, 28)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 33)
        Label3.TabIndex = 19
        Label3.Text = "Search:"
        ' 
        ' searchbox
        ' 
        searchbox.BorderStyle = BorderStyle.FixedSingle
        searchbox.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchbox.Location = New Point(629, 28)
        searchbox.Multiline = True
        searchbox.Name = "searchbox"
        searchbox.Size = New Size(318, 34)
        searchbox.TabIndex = 18
        ' 
        ' HomePage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 655)
        Controls.Add(Label3)
        Controls.Add(searchbox)
        Controls.Add(Label1)
        Controls.Add(Complaints)
        Name = "HomePage"
        Text = "HomePage"
        CType(Complaints, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Complaints As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents searchbox As TextBox
End Class
