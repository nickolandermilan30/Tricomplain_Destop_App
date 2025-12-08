<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Message
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
        textmsg = New TextBox()
        Send = New Button()
        Close = New Button()
        SuspendLayout()
        ' 
        ' textmsg
        ' 
        textmsg.BorderStyle = BorderStyle.FixedSingle
        textmsg.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        textmsg.Location = New Point(12, 23)
        textmsg.Multiline = True
        textmsg.Name = "textmsg"
        textmsg.Size = New Size(349, 269)
        textmsg.TabIndex = 4
        ' 
        ' Send
        ' 
        Send.Anchor = AnchorStyles.Bottom
        Send.BackColor = Color.SkyBlue
        Send.FlatStyle = FlatStyle.Flat
        Send.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Send.ForeColor = Color.White
        Send.Location = New Point(12, 313)
        Send.Name = "Send"
        Send.Size = New Size(349, 48)
        Send.TabIndex = 5
        Send.Text = "Send"
        Send.TextImageRelation = TextImageRelation.TextBeforeImage
        Send.UseCompatibleTextRendering = True
        Send.UseVisualStyleBackColor = False
        ' 
        ' Close
        ' 
        Close.Anchor = AnchorStyles.Bottom
        Close.BackColor = Color.Red
        Close.FlatStyle = FlatStyle.Flat
        Close.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Close.ForeColor = Color.White
        Close.Location = New Point(12, 378)
        Close.Name = "Close"
        Close.Size = New Size(349, 48)
        Close.TabIndex = 6
        Close.Text = "Close"
        Close.TextImageRelation = TextImageRelation.TextBeforeImage
        Close.UseCompatibleTextRendering = True
        Close.UseVisualStyleBackColor = False
        ' 
        ' Message
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(373, 450)
        Controls.Add(Close)
        Controls.Add(Send)
        Controls.Add(textmsg)
        Name = "Message"
        Text = "Message"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents textmsg As TextBox
    Friend WithEvents Send As Button
    Friend WithEvents Close As Button
End Class
