Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class ValidReport
    Private FirebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/"
    Private FirebaseSecret As String = "aScxTGOEQP00AtvnSaATvyxx9MOPlaCwUJXJhXnI"

    Private Sub ValidReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupFlowLayout()
        LoadValidComplaints()
    End Sub

    ' === Setup FlowLayoutPanel ===
    Private Sub SetupFlowLayout()
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.WrapContents = False
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Padding = New Padding(10)
    End Sub

    ' === Load all valid complaints ===
    Private Sub LoadValidComplaints()
        FlowLayoutPanel1.Controls.Clear()

        ' Add section for commuter complaints
        AddSectionTitle("COMMUTER COMPLAINTS")
        LoadComplaints("commuter complaint")
    End Sub

    ' === Add section title ===
    Private Sub AddSectionTitle(titleText As String)
        Dim titlePanel As New Panel() With {
            .Width = 720,
            .Height = 40,
            .BackColor = Color.FromArgb(230, 230, 230)
        }

        Dim titleLabel As New Label() With {
            .Text = titleText,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(10, 10)
        }

        titlePanel.Controls.Add(titleLabel)
        FlowLayoutPanel1.Controls.Add(titlePanel)
    End Sub

    ' === Load complaints by node ===
    Private Sub LoadComplaints(nodeName As String)
        Try
            Dim url As String = $"{FirebaseUrl}{nodeName}.json?auth={FirebaseSecret}"
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"

            Using response As WebResponse = request.GetResponse()
                Using dataStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(dataStream)
                        Dim jsonText As String = reader.ReadToEnd()

                        If String.IsNullOrWhiteSpace(jsonText) OrElse jsonText = "null" Then Exit Sub

                        Dim allComplaints As JObject = JObject.Parse(jsonText)

                        For Each item In allComplaints.Properties()
                            Dim complaint As JObject = item.Value
                            Dim status As String = complaint("status")?.ToString()

                            ' Only show valid complaints
                            If status = "valid" Then
                                Dim ticketNo As String = complaint("ticketNo")?.ToString()
                                Dim violation As String = complaint("violation")?.ToString()
                                Dim message As String = complaint("message")?.ToString()

                                AddComplaintBox(ticketNo, violation, message)
                            End If
                        Next
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading " & nodeName & ": " & ex.Message)
        End Try
    End Sub

    ' === Add each complaint row ===
    Private Sub AddComplaintBox(ticketNo As String, violation As String, message As String)
        Dim boxPanel As New Panel() With {
            .Width = 720,
            .Height = 100,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.White,
            .Margin = New Padding(5)
        }

        ' Sticker/BN No.
        Dim lblTicketTitle As New Label() With {
            .Text = "Sticker/BN No.:",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Location = New Point(10, 10),
            .AutoSize = True
        }

        Dim lblTicket As New Label() With {
            .Text = ticketNo,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Location = New Point(10, 30),
            .AutoSize = True
        }

        ' Violations
        Dim lblViolationTitle As New Label() With {
            .Text = "Violations:",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Location = New Point(240, 10),
            .AutoSize = True
        }

        Dim lblViolation As New Label() With {
            .Text = "1. " & violation,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Location = New Point(240, 30),
            .AutoSize = True
        }

        ' Message / Penalty
        Dim lblMessageTitle As New Label() With {
            .Text = "Message / Penalty:",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Location = New Point(460, 10),
            .AutoSize = True
        }

        Dim lblMessage As New Label() With {
            .Text = message,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Location = New Point(460, 30),
            .Size = New Size(240, 60),
            .AutoEllipsis = True
        }

        ' Add all controls to box panel
        boxPanel.Controls.Add(lblTicketTitle)
        boxPanel.Controls.Add(lblTicket)
        boxPanel.Controls.Add(lblViolationTitle)
        boxPanel.Controls.Add(lblViolation)
        boxPanel.Controls.Add(lblMessageTitle)
        boxPanel.Controls.Add(lblMessage)

        FlowLayoutPanel1.Controls.Add(boxPanel)
    End Sub

    ' === Reload Button ===
    Private Sub reload_Click(sender As Object, e As EventArgs) Handles reload.Click
        LoadValidComplaints()
    End Sub

    ' === Back Button ===
    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        Dim monitor As New MonitorComplaints()
        monitor.Show()
        Me.Close()
    End Sub
End Class
