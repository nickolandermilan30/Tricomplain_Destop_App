<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FillUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FillUp))
        done = New Button()
        uploadbtn = New Button()
        fileshow = New Panel()
        downloadfile = New Button()
        filedisplay = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        back = New Button()
        bnnumber = New TextBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' done
        ' 
        done.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        done.BackColor = Color.SeaGreen
        done.FlatStyle = FlatStyle.Flat
        done.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        done.ForeColor = Color.WhiteSmoke
        done.Location = New Point(779, 799)
        done.Margin = New Padding(3, 4, 3, 4)
        done.Name = "done"
        done.Size = New Size(503, 83)
        done.TabIndex = 11
        done.Text = "DONE"
        done.TextImageRelation = TextImageRelation.TextBeforeImage
        done.UseCompatibleTextRendering = True
        done.UseVisualStyleBackColor = False
        ' 
        ' uploadbtn
        ' 
        uploadbtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        uploadbtn.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        uploadbtn.FlatStyle = FlatStyle.Flat
        uploadbtn.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        uploadbtn.ForeColor = Color.White
        uploadbtn.Location = New Point(1157, 716)
        uploadbtn.Margin = New Padding(3, 4, 3, 4)
        uploadbtn.Name = "uploadbtn"
        uploadbtn.Size = New Size(126, 52)
        uploadbtn.TabIndex = 6
        uploadbtn.Text = "UPLOAD"
        uploadbtn.TextImageRelation = TextImageRelation.TextBeforeImage
        uploadbtn.UseCompatibleTextRendering = True
        uploadbtn.UseVisualStyleBackColor = False
        ' 
        ' fileshow
        ' 
        fileshow.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        fileshow.BackColor = SystemColors.AppWorkspace
        fileshow.Location = New Point(41, 25)
        fileshow.Margin = New Padding(3, 4, 3, 4)
        fileshow.Name = "fileshow"
        fileshow.Size = New Size(696, 839)
        fileshow.TabIndex = 7
        ' 
        ' downloadfile
        ' 
        downloadfile.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        downloadfile.BackColor = Color.OliveDrab
        downloadfile.FlatStyle = FlatStyle.Flat
        downloadfile.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        downloadfile.ForeColor = Color.White
        downloadfile.Location = New Point(41, 889)
        downloadfile.Margin = New Padding(3, 4, 3, 4)
        downloadfile.Name = "downloadfile"
        downloadfile.Size = New Size(697, 83)
        downloadfile.TabIndex = 8
        downloadfile.Text = "DOWNLOAD FILE FIRST "
        downloadfile.TextImageRelation = TextImageRelation.TextBeforeImage
        downloadfile.UseCompatibleTextRendering = True
        downloadfile.UseVisualStyleBackColor = False
        ' 
        ' filedisplay
        ' 
        filedisplay.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        filedisplay.BackColor = SystemColors.ScrollBar
        filedisplay.Location = New Point(779, 716)
        filedisplay.Margin = New Padding(3, 4, 3, 4)
        filedisplay.Name = "filedisplay"
        filedisplay.Size = New Size(373, 52)
        filedisplay.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(765, 123)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 37)
        Label1.TabIndex = 9
        Label1.Text = "Please note:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Red
        Label2.Location = New Point(769, 179)
        Label2.Name = "Label2"
        Label2.Size = New Size(522, 105)
        Label2.TabIndex = 10
        Label2.Text = "You need to download the file first. " & vbCrLf & "After downloading, open the file, complete it, " & vbCrLf & "and then upload it again."
        ' 
        ' back
        ' 
        back.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        back.BackColor = Color.LightCoral
        back.FlatStyle = FlatStyle.Flat
        back.Font = New Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        back.ForeColor = Color.WhiteSmoke
        back.Location = New Point(779, 889)
        back.Margin = New Padding(3, 4, 3, 4)
        back.Name = "back"
        back.Size = New Size(503, 83)
        back.TabIndex = 11
        back.Text = "BACK"
        back.TextImageRelation = TextImageRelation.TextBeforeImage
        back.UseCompatibleTextRendering = True
        back.UseVisualStyleBackColor = False
        ' 
        ' bnnumber
        ' 
        bnnumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        bnnumber.BorderStyle = BorderStyle.FixedSingle
        bnnumber.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        bnnumber.Location = New Point(887, 336)
        bnnumber.Margin = New Padding(3, 4, 3, 4)
        bnnumber.Multiline = True
        bnnumber.Name = "bnnumber"
        bnnumber.Size = New Size(244, 42)
        bnnumber.TabIndex = 20
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Red
        Label3.Location = New Point(769, 337)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 41)
        Label3.TabIndex = 19
        Label3.Text = "BN No:"
        ' 
        ' FillUp
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1334, 999)
        Controls.Add(bnnumber)
        Controls.Add(Label3)
        Controls.Add(back)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(filedisplay)
        Controls.Add(downloadfile)
        Controls.Add(fileshow)
        Controls.Add(uploadbtn)
        Controls.Add(done)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FillUp"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FillUp"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents done As Button
    Friend WithEvents uploadbtn As Button
    Friend WithEvents fileshow As Panel
    Friend WithEvents downloadfile As Button
    Friend WithEvents filedisplay As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents back As Button
    Friend WithEvents bnnumber As TextBox
    Friend WithEvents Label3 As Label
End Class
