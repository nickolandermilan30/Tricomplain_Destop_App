<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchHistory
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
        close = New Button()
        listsearch = New ListBox()
        SuspendLayout()
        ' 
        ' close
        ' 
        close.Anchor = AnchorStyles.Bottom
        close.BackColor = Color.Crimson
        close.FlatStyle = FlatStyle.Flat
        close.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        close.ForeColor = Color.White
        close.Location = New Point(12, 381)
        close.Name = "close"
        close.Size = New Size(373, 48)
        close.TabIndex = 16
        close.Text = "Close"
        close.TextImageRelation = TextImageRelation.TextBeforeImage
        close.UseCompatibleTextRendering = True
        close.UseVisualStyleBackColor = False
        ' 
        ' listsearch
        ' 
        listsearch.FormattingEnabled = True
        listsearch.ItemHeight = 15
        listsearch.Location = New Point(12, 12)
        listsearch.Name = "listsearch"
        listsearch.Size = New Size(373, 349)
        listsearch.TabIndex = 17
        ' 
        ' SearchHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(397, 450)
        Controls.Add(listsearch)
        Controls.Add(close)
        Name = "SearchHistory"
        Text = "SearchHistory"
        ResumeLayout(False)
    End Sub
    Friend WithEvents close As Button
    Friend WithEvents listsearch As ListBox
End Class
