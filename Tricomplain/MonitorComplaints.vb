Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class MonitorComplaints

    Private FirebaseUrl As String = "https://tricomplain-default-rtdb.firebaseio.com/"
    Private FirebaseSecret As String = "aScxTGOEQP00AtvnSaATvyxx9MOPlaCwUJXJhXnI"
    Private StorageBaseUrl As String = "https://firebasestorage.googleapis.com/v0/b/tricomplain.firebasestorage.app/o/"

    ' === Form Load ===
    Private Sub MonitorComplaints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupFlowLayout()
        LoadAllComplaints()
    End Sub

    Private Sub SetupFlowLayout()
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.WrapContents = False
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
    End Sub

    ' === MAIN LOADER ===
    Private Sub LoadAllComplaints()
        FlowLayoutPanel1.Controls.Clear()

        ' Header
        Dim header As New Panel() With {.Width = 700, .Height = 40, .BorderStyle = BorderStyle.FixedSingle}
        Dim lblLeft As New Label() With {.Text = "VIOLATIONS & ATTACHMENTS", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True}
        Dim lblRight As New Label() With {.Text = "VALID OR INVALID", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(500, 10), .AutoSize = True}
        Dim divider As New Label() With {.BorderStyle = BorderStyle.Fixed3D, .AutoSize = False, .Width = 2, .Height = 40, .Location = New Point(430, 0)}

        header.Controls.Add(lblLeft)
        header.Controls.Add(lblRight)
        header.Controls.Add(divider)
        FlowLayoutPanel1.Controls.Add(header)

        ' Load complaint sections
        LoadComplaints("commuter complaint", "COMMUTER COMPLAINTS")
    End Sub

    ' === LOAD COMPLAINTS WITH DATE + TIME SORTING ===
    Private Sub LoadComplaints(nodeName As String, sectionTitle As String)
        Try
            Dim url As String = $"{FirebaseUrl}{nodeName}.json?auth={FirebaseSecret}"
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"

            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim jsonText As String = reader.ReadToEnd()
                    If String.IsNullOrWhiteSpace(jsonText) OrElse jsonText = "null" Then Exit Sub

                    Dim json As JObject = JObject.Parse(jsonText)

                    ' === Convert to sortable list ===
                    Dim complaintList As New List(Of JObject)
                    For Each c In json.Properties()
                        Dim o As JObject = c.Value
                        o("firebaseKey") = c.Name
                        complaintList.Add(o)
                    Next

                    ' === SORT BY DATE + TIME (newest first) ===
                    complaintList = complaintList _
                        .OrderByDescending(Function(o)
                                               Dim dateStr As String = o("date")?.ToString()
                                               Dim timeStr As String = o("time")?.ToString()
                                               Dim dt As DateTime
                                               If DateTime.TryParse(dateStr & " " & timeStr, dt) Then
                                                   Return dt
                                               End If
                                               Return DateTime.MinValue
                                           End Function) _
                        .ToList()

                    ' === SECTION TITLE ===
                    Dim sectionPanel As New Panel() With {.Width = 700, .Height = 30}
                    Dim lblSection As New Label() With {
                        .Text = sectionTitle,
                        .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                        .ForeColor = Color.DarkBlue,
                        .Location = New Point(5, 5),
                        .AutoSize = True
                    }
                    sectionPanel.Controls.Add(lblSection)
                    FlowLayoutPanel1.Controls.Add(sectionPanel)

                    ' === DISPLAY SORTED COMPLAINT ROWS ===
                    For Each data As JObject In complaintList
                        Dim ticketNo As String = data("ticketNo")?.ToString()
                        Dim violation As String = data("violation")?.ToString()
                        Dim status As String = data("status")?.ToString()
                        Dim firebaseKey As String = data("firebaseKey")?.ToString()

                        Dim fileUrlRaw As JToken = data("fileUrls")
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

                        ' === ROW PANEL ===
                        Dim panel As New Panel() With {.Width = 700, .Height = 120, .BorderStyle = BorderStyle.FixedSingle}

                        Dim lblSticker As New Label() With {
                            .Text = "STICKER/BN NO.: " & ticketNo,
                            .Font = New Font("Segoe UI", 9),
                            .Location = New Point(10, 10),
                            .AutoSize = True
                        }

                        Dim lblViolation As New Label() With {
                            .Text = "VIOLATION: " & violation,
                            .Font = New Font("Segoe UI", 9),
                            .Location = New Point(10, 35),
                            .AutoSize = True
                        }

                        Dim btnAttach As New Button() With {
                            .Text = "📎  VIEW ATTACHMENT",
                            .Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold),
                            .FlatStyle = FlatStyle.Flat,
                            .ForeColor = Color.White,
                            .BackColor = Color.FromArgb(52, 152, 219),
                            .Width = 350,
                            .Height = 35,
                            .Location = New Point(10, 65),
                            .Tag = actualFileUrl,
                            .Cursor = Cursors.Hand
                        }
                        btnAttach.FlatAppearance.BorderSize = 0
                        AddHandler btnAttach.Click, AddressOf Attachment_Click

                        Dim divider As New Label() With {
                            .BorderStyle = BorderStyle.Fixed3D,
                            .AutoSize = False,
                            .Width = 2,
                            .Height = 120,
                            .Location = New Point(430, 0)
                        }

                        Dim chkValid As New CheckBox() With {
                            .Text = "VALID",
                            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                            .Location = New Point(460, 30),
                            .Tag = $"{nodeName}/{firebaseKey}"
                        }

                        Dim chkInvalid As New CheckBox() With {
                            .Text = "INVALID",
                            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                            .Location = New Point(460, 60),
                            .Tag = $"{nodeName}/{firebaseKey}"
                        }

                        If status = "valid" Then chkValid.Checked = True
                        If status = "invalid" Then chkInvalid.Checked = True

                        AddHandler chkValid.CheckedChanged, Sub()
                                                                If chkValid.Checked Then
                                                                    chkInvalid.Checked = False
                                                                    SaveStatus(chkValid.Tag.ToString(), "valid")
                                                                Else
                                                                    chkInvalid.Checked = False
                                                                    SaveStatus(chkValid.Tag.ToString(), "")
                                                                End If
                                                            End Sub

                        AddHandler chkInvalid.CheckedChanged, Sub()
                                                                  If chkInvalid.Checked Then
                                                                      chkValid.Checked = False
                                                                      SaveStatus(chkInvalid.Tag.ToString(), "invalid")
                                                                  Else
                                                                      chkValid.Checked = False
                                                                      SaveStatus(chkInvalid.Tag.ToString(), "")
                                                                  End If
                                                              End Sub

                        Dim btnDelete As New Button() With {
                            .Text = "🗑 DELETE",
                            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                            .FlatStyle = FlatStyle.Flat,
                            .ForeColor = Color.White,
                            .BackColor = Color.FromArgb(231, 76, 60),
                            .Width = 100,
                            .Height = 30,
                            .Location = New Point(580, 45),
                            .Tag = $"{nodeName}/{firebaseKey}",
                            .Cursor = Cursors.Hand
                        }
                        btnDelete.FlatAppearance.BorderSize = 0
                        AddHandler btnDelete.Click, AddressOf DeleteComplaint

                        panel.Controls.Add(lblSticker)
                        panel.Controls.Add(lblViolation)
                        panel.Controls.Add(btnAttach)
                        panel.Controls.Add(divider)
                        panel.Controls.Add(chkValid)
                        panel.Controls.Add(chkInvalid)
                        panel.Controls.Add(btnDelete)
                        FlowLayoutPanel1.Controls.Add(panel)
                    Next

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading " & nodeName & ": " & ex.Message)
        End Try
    End Sub

    ' === ATTACHMENT ===
    Private Sub Attachment_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim fileUrl As String = TryCast(btn.Tag, String)
        Dim parentPanel As Panel = CType(btn.Parent, Panel)

        If String.IsNullOrEmpty(fileUrl) Then
            MessageBox.Show("No attachment found.")
            Exit Sub
        End If

        Try
            ' Hide if already showing
            Dim existingPic = parentPanel.Controls.OfType(Of PictureBox)().FirstOrDefault()
            If existingPic IsNot Nothing Then
                parentPanel.Controls.Remove(existingPic)
                parentPanel.Height = 120
                btn.Text = "📎 VIEW ATTACHMENT"
                Exit Sub
            End If

            ' If image → inline preview
            If fileUrl.EndsWith(".jpg") OrElse fileUrl.EndsWith(".png") OrElse fileUrl.EndsWith(".jpeg") Then

                Dim pic As New PictureBox() With {
                    .Width = 680,
                    .Height = 200,
                    .Location = New Point(10, 110),
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .ImageLocation = fileUrl
                }

                parentPanel.Controls.Add(pic)
                parentPanel.Height = 330
                btn.Text = "HIDE ATTACHMENT"

            Else
                ' If file → open externally
                Process.Start(New ProcessStartInfo(fileUrl) With {.UseShellExecute = True})
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to open attachment: " & ex.Message)
        End Try
    End Sub

    ' === SAVE STATUS ===
    Private Sub SaveStatus(path As String, status As String)
        Try
            Dim url As String = $"{FirebaseUrl}{path}/status.json?auth={FirebaseSecret}"
            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "PUT"

            Dim data As String = $"""{status}"""
            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(data)
            request.ContentType = "application/json"
            request.ContentLength = bytes.Length

            Using stream = request.GetRequestStream()
                stream.Write(bytes, 0, bytes.Length)
            End Using

            request.GetResponse()

        Catch ex As Exception
            MessageBox.Show("Error saving status: " & ex.Message)
        End Try
    End Sub

    ' === DELETE ===
    Private Sub DeleteComplaint(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim path As String = btn.Tag.ToString()

        If MessageBox.Show("Delete this complaint?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                Dim url As String = $"{FirebaseUrl}{path}.json?auth={FirebaseSecret}"
                Dim request As WebRequest = WebRequest.Create(url)
                request.Method = "DELETE"
                request.GetResponse()
                MessageBox.Show("Complaint deleted.")
                LoadAllComplaints()

            Catch ex As Exception
                MessageBox.Show("Error deleting: " & ex.Message)
            End Try
        End If
    End Sub

    ' === BUTTONS ===
    Private Sub reload_Click(sender As Object, e As EventArgs) Handles reload.Click
        LoadAllComplaints()
    End Sub

    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        Dim f As New Home()
        f.Show()
        Me.Close()
    End Sub

    Private Sub validbtn_Click(sender As Object, e As EventArgs) Handles validbtn.Click
        Dim frm As New ValidComplaints()
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub penalty_Click(sender As Object, e As EventArgs) Handles penalty.Click
        Dim frm As New ValidReport()
        frm.Show()
        Me.Hide()
    End Sub

End Class
