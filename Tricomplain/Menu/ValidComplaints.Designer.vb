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
        ValidComplain = New Panel()
        Close = New Button()
        LoadingPanel = New Panel()
        Refresh = New Button()
        Label3 = New Label()
        searchbox = New TextBox()
        SuspendLayout()
        ' 
        ' ValidComplain
        ' 
        ValidComplain.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ValidComplain.Location = New Point(34, 100)
        ValidComplain.Name = "ValidComplain"
        ValidComplain.Size = New Size(707, 363)
        ValidComplain.TabIndex = 1
        ' 
        ' Close
        ' 
        Close.BackColor = Color.Crimson
        Close.FlatStyle = FlatStyle.Flat
        Close.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Close.ForeColor = Color.White
        Close.Location = New Point(252, 483)
        Close.Name = "Close"
        Close.Size = New Size(286, 56)
        Close.TabIndex = 20
        Close.Text = "Close"
        Close.TextImageRelation = TextImageRelation.TextBeforeImage
        Close.UseCompatibleTextRendering = True
        Close.UseVisualStyleBackColor = False
        ' 
        ' LoadingPanel
        ' 
        LoadingPanel.Location = New Point(758, 74)
        LoadingPanel.Name = "LoadingPanel"
        LoadingPanel.Size = New Size(11, 12)
        LoadingPanel.TabIndex = 21
        ' 
        ' Refresh
        ' 
        Refresh.BackColor = Color.ForestGreen
        Refresh.FlatStyle = FlatStyle.Flat
        Refresh.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Refresh.ForeColor = Color.White
        Refresh.Location = New Point(34, 483)
        Refresh.Name = "Refresh"
        Refresh.Size = New Size(195, 56)
        Refresh.TabIndex = 5
        Refresh.Text = "Refresh"
        Refresh.TextImageRelation = TextImageRelation.TextBeforeImage
        Refresh.UseCompatibleTextRendering = True
        Refresh.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(35, 38)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 33)
        Label3.TabIndex = 23
        Label3.Text = "Search:"
        ' 
        ' searchbox
        ' 
        searchbox.BorderStyle = BorderStyle.FixedSingle
        searchbox.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchbox.Location = New Point(153, 38)
        searchbox.Multiline = True
        searchbox.Name = "searchbox"
        searchbox.Size = New Size(588, 34)
        searchbox.TabIndex = 22
        ' 
        ' ValidComplaints
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(770, 563)
        Controls.Add(Label3)
        Controls.Add(searchbox)
        Controls.Add(Refresh)
        Controls.Add(LoadingPanel)
        Controls.Add(Close)
        Controls.Add(ValidComplain)
        Name = "ValidComplaints"
        Text = "ValidComplaints"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ValidComplain As Panel
    Friend WithEvents Close As Button
    Friend WithEvents LoadingPanel As Panel
    Friend WithEvents Refresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents searchbox As TextBox
End Class
