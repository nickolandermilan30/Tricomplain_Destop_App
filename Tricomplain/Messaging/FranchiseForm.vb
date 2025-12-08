Imports System.Drawing.Printing
Imports System.IO

Public Class FranchiseForm

    Private WithEvents PD As New PrintDocument
    Private LogoImg As Image

    Private Sub View_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imgPath As String = Path.Combine(Application.StartupPath, "Images\tricycle_logo.png")
        If File.Exists(imgPath) Then
            LogoImg = Image.FromFile(imgPath)
        Else
            MessageBox.Show("Logo file not found!")
        End If

        PrintPreviewControl1.Document = PD
        PrintPreviewControl1.Zoom = 1.0
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim PPD As New PrintPreviewDialog
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim g = e.Graphics
        Dim fTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fSub As New Font("Arial", 11, FontStyle.Regular)
        Dim fNormal As New Font("Arial", 10)
        Dim y As Integer = 40

        ' --- LOGO ---
        If LogoImg IsNot Nothing Then
            g.DrawImage(LogoImg, 50, y - 20, 110, 110)
        End If

        ' ----------------------------  
        ' CENTERED HEADER TEXT  
        ' ----------------------------
        Dim pageWidth = e.PageBounds.Width

        CenterText(g, "Republic of the Philippines", fSub, Brushes.Black, pageWidth, y) : y += 20
        CenterText(g, "Province of Iloilo", fSub, Brushes.Black, pageWidth, y) : y += 20
        CenterText(g, "MUNICIPALITY OF BAROTAC NUEVO", fSub, Brushes.Black, pageWidth, y) : y += 20
        CenterText(g, "OFFICE OF THE SANGGUNIANG BAYAN", fSub, Brushes.Black, pageWidth, y) : y += 40

        ' --- TITLE ---
        Dim title As String = "FRANCHISE CONFIRMATION / VERIFICATION"
        Dim titleWidth As Single = g.MeasureString(title, fTitle).Width
        Dim centerX As Integer = (e.PageBounds.Width - titleWidth) \ 2
        g.DrawString(title, fTitle, Brushes.Black, centerX, y)
        y += 60

        ' --- SHORT LINES ---
        DrawShortLineField(g, "Name of Operator:", 50, y) : y += 30
        DrawShortLineField(g, "Address:", 50, y) : y += 30

        ' === RIGHT SIDE FIELDS ===
        g.DrawString("Date: ___________________", fNormal, Brushes.Black, 500, y - 55)
        g.DrawString("Franchise No.: ____________", fNormal, Brushes.Black, 500, y - 30)
        g.DrawString("TIN No.: ________________", fNormal, Brushes.Black, 500, y - 5)

        ' === Classification ===
        g.DrawString("Classification of Tricycle: ( ) Public Utility     ( ) Private Utility", fNormal, Brushes.Black, 50, y)
        y += 30

        DrawShortLineField(g, "Validity Period:", 50, y) : y += 30
        g.DrawString("Expiry Date: _______________", fNormal, Brushes.Black, 500, y - 30)

        DrawLineField(g, "Date Granted:", 50, y) : y += 30
        DrawLineField(g, "Authorized No. of Unit:", 50, y) : y += 30
        DrawLineField(g, "Authorized Route:", 50, y) : y += 30
        DrawLineField(g, "Registering Agency:", 50, y) : y += 55

        ' === TABLE HEADER + ONE ROW ===
        Dim tableX As Integer = 50
        Dim tableY As Integer = y
        Dim tableWidth As Integer = 700
        Dim rowHeight As Integer = 30

        Dim colMake As Integer = 150
        Dim colMotor As Integer = 180
        Dim colChassis As Integer = 180
        Dim colPlate As Integer = 190

        ' Header row
        g.DrawRectangle(Pens.Black, tableX, tableY, tableWidth, rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake, tableY, tableX + colMake, tableY + rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake + colMotor, tableY, tableX + colMake + colMotor, tableY + rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake + colMotor + colChassis, tableY, tableX + colMake + colMotor + colChassis, tableY + rowHeight)

        g.DrawString("MAKE", fNormal, Brushes.Black, tableX + 10, tableY + 8)
        g.DrawString("MOTOR NO.", fNormal, Brushes.Black, tableX + colMake + 10, tableY + 8)
        g.DrawString("CHASSIS NO.", fNormal, Brushes.Black, tableX + colMake + colMotor + 10, tableY + 8)
        g.DrawString("PLATE NO.", fNormal, Brushes.Black, tableX + colMake + colMotor + colChassis + 10, tableY + 8)

        ' Data row
        tableY += rowHeight
        g.DrawRectangle(Pens.Black, tableX, tableY, tableWidth, rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake, tableY, tableX + colMake, tableY + rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake + colMotor, tableY, tableX + colMake + colMotor, tableY + rowHeight)
        g.DrawLine(Pens.Black, tableX + colMake + colMotor + colChassis, tableY, tableX + colMake + colMotor + colChassis, tableY + rowHeight)

        y = tableY + rowHeight + 20

        ' === PURPOSE ===
        g.DrawString("Purpose:", fNormal, Brushes.Black, 50, y) : y += 20
        g.DrawString("( ) Loss of OR/CR", fNormal, Brushes.Black, 70, y) : y += 20
        g.DrawString("( ) Change Unit", fNormal, Brushes.Black, 70, y) : y += 20
        g.DrawString("( ) Others: ________    Specify: ________", fNormal, Brushes.Black, 70, y)
        y += 50

        ' === FEES ===
        g.DrawString("CLEARED AS TO PAYMENT:", fNormal, Brushes.Black, 50, y) : y += 25
        g.DrawString("20____ Supervision Fee / Confirmation", fNormal, Brushes.Black, 70, y) : y += 20
        g.DrawString("20____ Increase Rate Fee", fNormal, Brushes.Black, 70, y) : y += 35

        g.DrawString("O.R No.: ____________", fNormal, Brushes.Black, 50, y) : y += 20
        g.DrawString("Amount: _____________", fNormal, Brushes.Black, 50, y) : y += 20
        g.DrawString("Date: _______________", fNormal, Brushes.Black, 50, y)
        y += 80

        ' === SIGNATURES ===
        g.DrawString("RHADY JOY D. RONQUILLO", fSub, Brushes.Black, 50, y)
        g.DrawString("Municipal Treasurer", fNormal, Brushes.Black, 50, y + 20)

        g.DrawString("APPROVED BY THE SANGGUNIANG BAYAN", fSub, Brushes.Black, 400, y)
        g.DrawString("This 4th day of NOVEMBER 2019", fNormal, Brushes.Black, 400, y + 20)
        g.DrawString("As Per Resolution No. _____, 2019", fNormal, Brushes.Black, 400, y + 40)

        y += 140

        g.DrawString("HON. HERNAN G. BIRON, JR.", fSub, Brushes.Black, 400, y)
        g.DrawString("Municipal Vice-Mayor/Presiding Officer", fNormal, Brushes.Black, 400, y + 20)

    End Sub

    ' ----------------- HELPERS -----------------

    Private Sub DrawLineField(g As Graphics, labelText As String, x As Integer, y As Integer)
        Dim f As New Font("Arial", 10)
        g.DrawString(labelText, f, Brushes.Black, x, y)
        g.DrawLine(Pens.Black, x + 150, y + 12, x + 650, y + 12)
    End Sub

    Private Sub DrawShortLineField(g As Graphics, labelText As String, x As Integer, y As Integer)
        Dim f As New Font("Arial", 10)
        g.DrawString(labelText, f, Brushes.Black, x, y)
        g.DrawLine(Pens.Black, x + 150, y + 12, x + 400, y + 12)
    End Sub

    ' ----------------- CENTER TEXT HELPER -----------------
    Private Sub CenterText(g As Graphics, text As String, font As Font, brush As Brush, pageWidth As Integer, y As Integer)
        Dim textWidth = g.MeasureString(text, font).Width
        Dim centerX = (pageWidth - textWidth) / 2
        g.DrawString(text, font, brush, centerX, y)
    End Sub

End Class
