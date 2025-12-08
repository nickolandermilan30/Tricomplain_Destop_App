<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountUser
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
        Label3 = New Label()
        driver = New DataGridView()
        Commuter = New DataGridView()
        Label2 = New Label()
        Admin = New DataGridView()
        Label1 = New Label()
        CType(driver, ComponentModel.ISupportInitialize).BeginInit()
        CType(Commuter, ComponentModel.ISupportInitialize).BeginInit()
        CType(Admin, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Green
        Label3.Location = New Point(757, 41)
        Label3.Name = "Label3"
        Label3.Size = New Size(102, 33)
        Label3.TabIndex = 15
        Label3.Text = "Driver"
        ' 
        ' driver
        ' 
        driver.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        driver.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        driver.Location = New Point(666, 104)
        driver.Name = "driver"
        driver.Size = New Size(283, 509)
        driver.TabIndex = 14
        ' 
        ' Commuter
        ' 
        Commuter.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Commuter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Commuter.Location = New Point(347, 104)
        Commuter.Name = "Commuter"
        Commuter.Size = New Size(283, 509)
        Commuter.TabIndex = 13
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Green
        Label2.Location = New Point(113, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(110, 33)
        Label2.TabIndex = 12
        Label2.Text = "Admin"
        ' 
        ' Admin
        ' 
        Admin.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Admin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Admin.Location = New Point(33, 104)
        Admin.Name = "Admin"
        Admin.Size = New Size(283, 509)
        Admin.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Book Antiqua", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Green
        Label1.Location = New Point(402, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(165, 33)
        Label1.TabIndex = 10
        Label1.Text = "Commuter "
        ' 
        ' AccountUser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 655)
        Controls.Add(Label3)
        Controls.Add(driver)
        Controls.Add(Commuter)
        Controls.Add(Label2)
        Controls.Add(Admin)
        Controls.Add(Label1)
        Name = "AccountUser"
        Text = "AccountUser"
        CType(driver, ComponentModel.ISupportInitialize).EndInit()
        CType(Commuter, ComponentModel.ISupportInitialize).EndInit()
        CType(Admin, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents driver As DataGridView
    Friend WithEvents Commuter As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Admin As DataGridView
    Friend WithEvents Label1 As Label
End Class
