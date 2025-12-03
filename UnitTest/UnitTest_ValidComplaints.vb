Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq

<TestClass>
Public Class UnitTest_ValidComplaints

    ' Helper to create instance of ValidComplaints
    Private Function CreateValidComplaintsInstance() As Object
        Dim vcType As Type = Nothing
        For Each asm In AppDomain.CurrentDomain.GetAssemblies()
            vcType = asm.GetType("ValidComplaints")
            If vcType IsNot Nothing Then Exit For
            For Each t In asm.GetTypes()
                If t.Name = "ValidComplaints" Then
                    vcType = t
                    Exit For
                End If
            Next
            If vcType IsNot Nothing Then Exit For
        Next

        If vcType Is Nothing Then
            Assert.Fail("Could not find type 'ValidComplaints'. Ensure UnitTest project references main project.")
        End If

        Dim instance = Activator.CreateInstance(vcType)

        ' Inject a FlowLayoutPanel for validcomplaintslist
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public
        Dim panelField = vcType.GetField("validcomplaintslist", flags)
        If panelField IsNot Nothing Then
            panelField.SetValue(instance, New FlowLayoutPanel())
        End If

        ' Inject a search TextBox
        Dim searchField = vcType.GetField("searchvalid", flags)
        If searchField IsNot Nothing Then
            searchField.SetValue(instance, New TextBox())
        End If

        Return instance
    End Function

    <TestMethod>
    Public Sub FormLoad_ShouldInitializePanel()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim loadMethod = vcType.GetMethod("ValidComplaints_Load", flags)
        Assert.IsNotNull(loadMethod, "ValidComplaints_Load method not found")

        ' Act & Assert
        Try
            loadMethod.Invoke(instance, New Object() {instance, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("ValidComplaints_Load threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub DisplayComplaints_ShouldAddPanels()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim displayMethod = vcType.GetMethod("DisplayComplaints", flags)
        Assert.IsNotNull(displayMethod, "DisplayComplaints method not found")

        ' Prepare mock complaint
        Dim complaint As New JObject() From {
            {"ticketNo", "12345"},
            {"violation", "No Helmet"},
            {"destination", "Station A"},
            {"date", "2025-12-03"},
            {"time", "12:00"},
            {"status", "valid"}
        }
        Dim complaints As New List(Of JObject) From {complaint}

        ' Act
        displayMethod.Invoke(instance, New Object() {complaints, "commuter complaint"})

        ' Assert
        Dim panelField = vcType.GetField("validcomplaintslist", flags)
        Dim panel = CType(panelField.GetValue(instance), FlowLayoutPanel)
        Assert.IsTrue(panel.Controls.Count > 0, "DisplayComplaints did not add panels")
    End Sub

    <TestMethod>
    Public Sub Searchbtn_Click_WithEmpty_ShouldReloadAll()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim searchField = vcType.GetField("searchvalid", flags)
        Dim txtBox As New TextBox()
        txtBox.Text = ""
        searchField.SetValue(instance, txtBox)

        Dim searchBtnMethod = vcType.GetMethod("searchbtn_Click", flags)
        Assert.IsNotNull(searchBtnMethod, "searchbtn_Click method not found")

        ' Act & Assert
        Try
            searchBtnMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("searchbtn_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub InlineAttachmentView_ShouldAddPictureBox()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim inlineMethod = vcType.GetMethod("InlineAttachmentView", flags)
        Assert.IsNotNull(inlineMethod, "InlineAttachmentView method not found")

        ' Create parent panel and button
        Dim parentPanel As New Panel()
        Dim btn As New Button() With {.Tag = "https://dummyurl.com/image.jpg", .Parent = parentPanel}

        ' Act
        Try
            inlineMethod.Invoke(instance, New Object() {btn, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("InlineAttachmentView threw exception: " & ex.Message)
        End Try

        ' Assert
        Assert.IsTrue(parentPanel.Controls.OfType(Of PictureBox)().Any(), "PictureBox was not added")
    End Sub

    <TestMethod>
    Public Sub Message_Click_ShouldOpenMessageForm()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim msgMethod = vcType.GetMethod("Message_Click", flags)
        Assert.IsNotNull(msgMethod, "Message_Click method not found")

        ' Create button with tag
        Dim btn As New Button()
        btn.Tag = New Dictionary(Of String, String) From {
            {"TicketNo", "123"},
            {"Violation", "Late"},
            {"Destination", "Station A"},
            {"Time", "12:00"}
        }

        ' Act & Assert
        Try
            msgMethod.Invoke(instance, New Object() {btn, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("Message_Click threw exception: " & ex.Message)
        End Try
    End Sub

    <TestMethod>
    Public Sub Backbtn_Click_ShouldCloseForm()
        ' Arrange
        Dim instance = CreateValidComplaintsInstance()
        Dim vcType = instance.GetType()
        Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public

        Dim backMethod = vcType.GetMethod("backbtn_Click", flags)
        Assert.IsNotNull(backMethod, "backbtn_Click not found")

        ' Act & Assert
        Try
            backMethod.Invoke(instance, New Object() {Nothing, EventArgs.Empty})
        Catch ex As Exception
            Assert.Fail("backbtn_Click threw exception: " & ex.Message)
        End Try
    End Sub

End Class
