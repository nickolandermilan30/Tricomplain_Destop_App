Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class ValidComplaints
    Private FirebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/"
    Private FirebaseSecret As String = "aScxTGOEQP00AtvnSaATvyxx9MOPlaCwUJXJhXnI"
    Private StorageBaseUrl As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o/"

    Private allValidComplaints As New List(Of JObject) ' Store all complaints for searching

    Private Sub ValidComplaints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        validcomplaintslist.AutoScroll = True
        validcomplaintslist.FlowDirection = FlowDirection.TopDown
        validcomplaintslist.WrapContents = False
        validcomplaintslist.BackColor = Color.White
        validcomplaintslist.Padding = New Padding(10, 5, 10, 5)
        LoadValidComplaints()
    End Sub

    ' === Load Only Valid Complaints ===
    Private Sub LoadValidComplaints()
        validcomplaintslist.Controls.Clear()

        ' Header row with better alignment
        Dim header As New Panel()
        header.Width = validcomplaintslist.Width - 20
        header.Height = 40
        header.BorderStyle = BorderStyle.FixedSingle
        header.BackColor = Color.FromArgb(240, 240, 240)
        header.Margin = New Padding(0, 0, 0, 10)

        ' BN NUMBER - Aligns with BN number in subcontainer
        Dim lblBN As New Label() With {
        .Text = "BN NUMBER",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.FromArgb(64, 64, 64),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 130,
        .Location = New Point(15, 10)
    }

        ' VIOLATION - Aligns with violation in subcontainer
        Dim lblViolation As New Label() With {
        .Text = "VIOLATION",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.FromArgb(64, 64, 64),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 200,
        .Location = New Point(170, 10)
    }

        ' DATE TIME - Aligns with date/time in subcontainer
        Dim lblDateTime As New Label() With {
        .Text = "DATE/TIME",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.FromArgb(64, 64, 64),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 150,
        .Location = New Point(380, 10)
    }

        ' DESTINATION - Aligns with destination in subcontainer
        Dim lblDestination As New Label() With {
        .Text = "DESTINATION",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.FromArgb(64, 64, 64),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 130,
        .Location = New Point(550, 10)
    }

        ' ACTIONS - Aligns with action buttons in subcontainer
        Dim lblAction As New Label() With {
        .Text = "ACTIONS",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .ForeColor = Color.FromArgb(64, 64, 64),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 150,
        .Location = New Point(750, 10)
    }

        header.Controls.AddRange({lblBN, lblViolation, lblDateTime, lblDestination, lblAction})
        validcomplaintslist.Controls.Add(header)

        ' Load from Firebase
        LoadComplaints("commuter complaint", "COMMUTER COMPLAINTS")
    End Sub

    ' === Load complaints from Firebase ===
    Private Sub LoadComplaints(nodeName As String, sectionTitle As String)
        Try
            Dim url As String = FirebaseUrl & nodeName & ".json?auth=" & FirebaseSecret
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"

            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim responseText As String = reader.ReadToEnd()
                    If String.IsNullOrWhiteSpace(responseText) OrElse responseText = "null" Then Exit Sub

                    Dim json As JObject = JObject.Parse(responseText)

                    ' Section Title
                    Dim sectionPanel As New Panel() With {.Width = validcomplaintslist.Width - 20, .Height = 35, .BackColor = Color.FromArgb(210, 210, 210)}
                    Dim lblSection As New Label() With {.Text = sectionTitle, .Font = New Font("Segoe UI", 11, FontStyle.Bold), .Location = New Point(10, 7), .AutoSize = True}
                    sectionPanel.Controls.Add(lblSection)
                    validcomplaintslist.Controls.Add(sectionPanel)

                    ' Filter valid complaints
                    allValidComplaints.Clear()
                    For Each complaint In json.Properties()
                        Dim data As JObject = complaint.Value
                        If data("status")?.ToString() = "valid" Then
                            data("firebaseKey") = complaint.Name
                            allValidComplaints.Add(data)
                        End If
                    Next

                    ' Sort descending by date + time
                    allValidComplaints = allValidComplaints.OrderByDescending(Function(o)
                                                                                  Dim dt As DateTime
                                                                                  DateTime.TryParse(o("date")?.ToString() & " " & o("time")?.ToString(), dt)
                                                                                  Return dt
                                                                              End Function).ToList()

                    ' Show all grouped by BN number
                    DisplayComplaints(allValidComplaints, "commuter complaint")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading valid complaints (" & nodeName & "): " & ex.Message)
        End Try
    End Sub

    ' === Display complaints given a list ===
    Private Sub DisplayComplaints(complaints As List(Of JObject), nodeName As String)
        ' Remove old items except header
        While validcomplaintslist.Controls.Count > 1
            validcomplaintslist.Controls.RemoveAt(1)
        End While

        ' Group by BN number
        Dim grouped = complaints.GroupBy(Function(c) c("ticketNo")?.ToString())

        For Each grp In grouped
            Dim bnNumber As String = grp.Key
            Dim list As List(Of JObject) = grp.ToList()

            ' Header row for BN
            Dim headerPanel As New Panel() With {
                .Width = validcomplaintslist.Width - 20,
                .Height = 40,
                .BackColor = Color.FromArgb(245, 245, 245),
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(0, 4, 0, 0)
            }

            Dim lblBNHeader As New Label() With {
                .Text = "BN Number: " & bnNumber,
                .Font = New Font("Segoe UI Semibold", 10),
                .Location = New Point(15, 10),
                .AutoSize = True
            }

            Dim btnDrop As New Button() With {
                .Text = "▼",
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .Width = 30, .Height = 30,
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.FromArgb(230, 230, 230),
                .Location = New Point(headerPanel.Width - 45, 5),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
            btnDrop.FlatAppearance.BorderSize = 0

            headerPanel.Controls.Add(lblBNHeader)
            headerPanel.Controls.Add(btnDrop)
            validcomplaintslist.Controls.Add(headerPanel)

            ' Subcontainer for details
            Dim subContainer As New FlowLayoutPanel() With {
                .Width = validcomplaintslist.Width - 20,
                .AutoSize = True,
                .FlowDirection = FlowDirection.TopDown,
                .WrapContents = False,
                .Visible = False,
                .BackColor = Color.WhiteSmoke
            }

            For Each comp As JObject In list
                Dim violation As String = comp("violation")?.ToString()
                Dim destination As String = comp("destination")?.ToString()
                Dim time As String = comp("time")?.ToString()
                Dim dateStr As String = comp("date")?.ToString()
                Dim fileUrlRaw As JToken = comp("fileUrls")
                Dim actualFileUrl As String = ""

                If fileUrlRaw IsNot Nothing Then
                    If fileUrlRaw.Type = JTokenType.Array Then
                        actualFileUrl = fileUrlRaw(0).ToString()
                    ElseIf fileUrlRaw.Type = JTokenType.String Then
                        actualFileUrl = fileUrlRaw.ToString()
                    End If
                End If

                If Not actualFileUrl.StartsWith("http") Then
                    Dim encodedPath As String = Uri.EscapeDataString(nodeName & "/" & actualFileUrl)
                    actualFileUrl = StorageBaseUrl & encodedPath & "?alt=media"
                End If

                ' Complaint row
                Dim itemPanel As New Panel() With {
                    .Width = subContainer.Width - 30,
                    .Height = 35,
                    .BackColor = Color.White,
                    .Margin = New Padding(10, 2, 10, 2),
                    .BorderStyle = BorderStyle.FixedSingle
                }

                Dim lblBNValue As New Label() With {.Text = bnNumber, .Font = New Font("Segoe UI", 9),
                    .Width = 150, .Location = New Point(15, 9)}

                Dim lblViolation As New Label() With {.Text = If(String.IsNullOrEmpty(violation), "No Violation", violation),
                    .Font = New Font("Segoe UI", 9), .Width = 200, .Location = New Point(160, 9)}

                Dim lblDateTime As New Label() With {.Text = $"{dateStr} {time}", .Font = New Font("Segoe UI", 9),
                    .Width = 150, .Location = New Point(370, 6)}

                Dim lblDestination As New Label() With {.Text = destination, .Font = New Font("Segoe UI", 9),
                    .Width = 120, .Location = New Point(550, 6)}

                Dim btnMsg As New Button() With {.Text = "Msg", .Width = 65, .Height = 27,
                    .Location = New Point(710, 3), .BackColor = Color.FromArgb(210, 240, 210),
                    .FlatStyle = FlatStyle.Flat}
                btnMsg.FlatAppearance.BorderSize = 0
                btnMsg.Tag = New Dictionary(Of String, String) From {
                    {"TicketNo", bnNumber}, {"Violation", violation},
                    {"Destination", destination}, {"Time", time}
                }
                AddHandler btnMsg.Click, AddressOf Message_Click

                Dim btnView As New Button() With {.Text = "View", .Width = 65, .Height = 27,
                    .Location = New Point(780, 3), .BackColor = Color.FromArgb(200, 230, 250),
                    .FlatStyle = FlatStyle.Flat, .Tag = actualFileUrl}
                btnView.FlatAppearance.BorderSize = 0
                AddHandler btnView.Click, AddressOf InlineAttachmentView

                itemPanel.Controls.AddRange({lblBNValue, lblViolation, lblDateTime, lblDestination, btnMsg, btnView})
                subContainer.Controls.Add(itemPanel)
            Next

            validcomplaintslist.Controls.Add(subContainer)

            ' Dropdown toggle handler
            AddHandler btnDrop.Click,
                Sub()
                    subContainer.Visible = Not subContainer.Visible
                    btnDrop.Text = If(subContainer.Visible, "▲", "▼")
                End Sub
        Next
    End Sub

    ' === Search BN number ===
    Private Sub searchbtn_Click(sender As Object, e As EventArgs) Handles searchbtn.Click
        Dim searchText As String = searchvalid.Text.Trim()
        If String.IsNullOrEmpty(searchText) Then
            DisplayComplaints(allValidComplaints, "commuter complaint")
            Exit Sub
        End If

        Dim filtered As List(Of JObject) = allValidComplaints.Where(Function(c) c("ticketNo")?.ToString() = searchText).ToList()
        If filtered.Count = 0 Then
            MessageBox.Show("No complaints found for BN Number: " & searchText)
            Exit Sub
        End If

        DisplayComplaints(filtered, "commuter complaint")
    End Sub

    ' === Inline Attachment Viewer ===
    Private Sub InlineAttachmentView(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim fileUrl As String = TryCast(btn.Tag, String)
        Dim parentPanel As Panel = CType(btn.Parent, Panel)

        If String.IsNullOrEmpty(fileUrl) Then
            MessageBox.Show("No file attached.")
            Exit Sub
        End If

        Try
            Dim existingPic = parentPanel.Controls.OfType(Of PictureBox)().FirstOrDefault()
            If existingPic IsNot Nothing Then
                parentPanel.Controls.Remove(existingPic)
                parentPanel.Height = 35
                btn.Text = "View"
                Exit Sub
            End If

            If fileUrl.EndsWith(".jpg") OrElse fileUrl.EndsWith(".png") OrElse fileUrl.EndsWith(".jpeg") Then
                Dim pic As New PictureBox() With {
                    .Width = 700, .Height = 200, .Location = New Point(15, 40),
                    .SizeMode = PictureBoxSizeMode.Zoom, .ImageLocation = fileUrl
                }
                parentPanel.Controls.Add(pic)
                parentPanel.Height = 250
                btn.Text = "Hide"
            Else
                Process.Start(New ProcessStartInfo(fileUrl) With {.UseShellExecute = True})
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to display image: " & ex.Message)
        End Try
    End Sub

    ' === Message Form Handler ===
    Private Sub Message_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As Button = CType(sender, Button)
            Dim info = TryCast(btn.Tag, Dictionary(Of String, String))
            If info Is Nothing Then Exit Sub

            Dim msgForm As New Message()
            msgForm.stikerno.Text = info("TicketNo")
            msgForm.violation.Text = info("Violation")
            msgForm.detination.Text = info("Destination")
            msgForm.Label6.Text = info("Time")
            msgForm.ComplaintType = "commuter complaint"
            msgForm.TicketNumber = info("TicketNo")
            msgForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening message form: " & ex.Message)
        End Try
    End Sub

    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        Close()
        MonitorComplaints.Show()
    End Sub
End Class
