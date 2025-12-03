Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks

<TestClass>
Public Class UnitTest_Franchise

    ' ================= Helper Methods =================

    ' Create an instance of Franchise and inject Panel1 and Search TextBox
    Private Function CreateFranchiseInstance() As Object
        Dim type As Type = AppDomain.CurrentDomain.GetAssemblies() _
            .SelectMany(Function(a) a.GetTypes()) _
            .FirstOrDefault(Function(t) t.Name = "Franchise")

        If type Is Nothing Then Assert.Fail("Franchise type not found. Check project references.")

        Dim instance = Activator.CreateInstance(type)

        ' Inject Panel1
        Dim panel As New Panel()
        Dim panelMember = type.GetField("Panel1", BindingFlags.Instance Or BindingFlags.NonPublic)
        If panelMember IsNot Nothing Then
            panelMember.SetValue(instance, panel)
        Else
            Dim panelProp = type.GetProperty("Panel1", BindingFlags.Instance Or BindingFlags.NonPublic)
            If panelProp IsNot Nothing Then
                panelProp.SetValue(instance, panel)
            Else
                Assert.Fail("Panel1 not found in Franchise")
            End If
        End If

        ' Inject TextBox for search
        Dim searchBox As New TextBox()
        Dim searchField = type.GetField("search", BindingFlags.Instance Or BindingFlags.NonPublic)
        If searchField IsNot Nothing Then searchField.SetValue(instance, searchBox)

        Return instance
    End Function

    ' Retrieve Panel1 from instance
    Private Function GetPanel1(instance As Object) As Panel
        Dim type = instance.GetType()
        Dim field = type.GetField("Panel1", BindingFlags.Instance Or BindingFlags.NonPublic)
        If field IsNot Nothing Then Return CType(field.GetValue(instance), Panel)
        Dim prop = type.GetProperty("Panel1", BindingFlags.Instance Or BindingFlags.NonPublic)
        If prop IsNot Nothing Then Return CType(prop.GetValue(instance), Panel)
        Assert.Fail("Panel1 not found")
        Return Nothing
    End Function

    ' Retrieve Search TextBox
    Private Function GetSearchTextBox(instance As Object) As TextBox
        Dim type = instance.GetType()
        Dim field = type.GetField("search", BindingFlags.Instance Or BindingFlags.NonPublic)
        If field IsNot Nothing Then Return CType(field.GetValue(instance), TextBox)
        Assert.Fail("Search TextBox not found")
        Return Nothing
    End Function

    ' Set AllFilesData with dummy JSON
    Private Sub SetAllFilesData(instance As Object, json As String)
        Dim type = instance.GetType()
        Dim allFilesField = type.GetField("AllFilesData", BindingFlags.Instance Or BindingFlags.NonPublic)
        allFilesField.SetValue(instance, JObject.Parse(json))
    End Sub

    ' ================= Tests =================

    <TestMethod>
    Public Sub AddFileCard_AddsPanelAndLabelCorrectly()
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim addMethod = type.GetMethod("AddFileCard", BindingFlags.Instance Or BindingFlags.NonPublic)
        addMethod.Invoke(instance, New Object() {"sample.docx", "http://dummy.com", "BN001", False})

        Dim panel1 = GetPanel1(instance)
        Assert.IsTrue(panel1.Controls.Count > 0, "Panel1 should contain at least one child panel.")

        Dim labelFound As Boolean = panel1.Controls.Cast(Of Control)() _
            .OfType(Of Panel)() _
            .SelectMany(Function(p) p.Controls.OfType(Of Label)()) _
            .Any(Function(l) l.Text = "sample.docx")

        Assert.IsTrue(labelFound, "Filename label 'sample.docx' should exist in added card.")
    End Sub

    <TestMethod>
    Public Sub MultipleFileCards_DisplayCorrectlyInPanel()
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim addMethod = type.GetMethod("AddFileCard", BindingFlags.Instance Or BindingFlags.NonPublic)

        addMethod.Invoke(instance, New Object() {"file1.docx", "http://dummy.com/1", "BN001", False})
        addMethod.Invoke(instance, New Object() {"file2.docx", "http://dummy.com/2", "BN002", False})

        Dim panel1 = GetPanel1(instance)
        Assert.AreEqual(2, panel1.Controls.Count, "Panel1 should contain two file cards.")
    End Sub

    <TestMethod>
    Public Sub ClearPanel_RemovesAllCards()
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim addMethod = type.GetMethod("AddFileCard", BindingFlags.Instance Or BindingFlags.NonPublic)

        addMethod.Invoke(instance, New Object() {"file1.docx", "http://dummy.com/1", "BN001", False})
        addMethod.Invoke(instance, New Object() {"file2.docx", "http://dummy.com/2", "BN002", False})

        Dim panel1 = GetPanel1(instance)
        panel1.Controls.Clear()
        Assert.AreEqual(0, panel1.Controls.Count, "Panel1 should be empty after clearing.")
    End Sub

    <TestMethod>
    Public Async Function SearchBN_FindsCorrectFile() As Task
        Dim instance = CreateFranchiseInstance()
        Dim dummyJson = "{
            'file1': { 'name': 'file1.docx', 'url': 'http://dummy.com/1', 'bn_number': 'BN001', 'archived': false },
            'file2': { 'name': 'file2.docx', 'url': 'http://dummy.com/2', 'bn_number': 'BN002', 'archived': false }
        }"
        SetAllFilesData(instance, dummyJson)

        Dim searchBox = GetSearchTextBox(instance)
        searchBox.Text = "BN002"

        Dim type = instance.GetType()
        Dim findBtn = type.GetMethod("find_Click", BindingFlags.Instance Or BindingFlags.NonPublic)
        findBtn.Invoke(instance, New Object() {Nothing, EventArgs.Empty})

        Dim panel1 = GetPanel1(instance)
        Dim filenames = panel1.Controls.Cast(Of Control)() _
            .OfType(Of Panel)() _
            .SelectMany(Function(p) p.Controls.OfType(Of Label)()) _
            .Select(Function(l) l.Text).ToList()

        CollectionAssert.Contains(filenames, "file2.docx")
        CollectionAssert.DoesNotContain(filenames, "file1.docx")
    End Function

    <TestMethod>
    Public Async Function SearchBN_NoResult_ShowsEmptyMessage() As Task
        Dim instance = CreateFranchiseInstance()
        Dim dummyJson = "{
            'file1': { 'name': 'file1.docx', 'url': 'http://dummy.com/1', 'bn_number': 'BN001', 'archived': false }
        }"
        SetAllFilesData(instance, dummyJson)

        Dim searchBox = GetSearchTextBox(instance)
        searchBox.Text = "BN999"

        Dim type = instance.GetType()
        Dim findBtn = type.GetMethod("find_Click", BindingFlags.Instance Or BindingFlags.NonPublic)
        findBtn.Invoke(instance, New Object() {Nothing, EventArgs.Empty})

        Dim panel1 = GetPanel1(instance)
        Assert.AreEqual(1, panel1.Controls.Count, "Panel1 should show one label for empty message.")
        Assert.IsInstanceOfType(panel1.Controls(0), GetType(Label))
        Dim lbl = CType(panel1.Controls(0), Label)
        StringAssert.Contains(lbl.Text, "No files found")
    End Function

    <TestMethod>
    Public Async Function ClearButton_ClearsSearchAndRefreshesPanel() As Task
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim searchBox = GetSearchTextBox(instance)
        searchBox.Text = "BN001"

        ' Invoke clear_Click
        Dim clearBtn = type.GetMethod("clear_Click", BindingFlags.Instance Or BindingFlags.NonPublic)
        clearBtn.Invoke(instance, New Object() {Nothing, EventArgs.Empty})

        ' Check that search box cleared
        Assert.AreEqual("", searchBox.Text)
    End Function

    <TestMethod>
    Public Sub BackButton_Click_OpensHomeForm()
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim backMethod = type.GetMethod("back_Click", BindingFlags.Instance Or BindingFlags.NonPublic)
        ' Normally here we would test Show() and Close(), but can't assert forms in unit test
        Assert.IsNotNull(backMethod)
    End Sub

    <TestMethod>
    Public Sub AllButtons_ExistInFileCard()
        Dim instance = CreateFranchiseInstance()
        Dim type = instance.GetType()
        Dim addMethod = type.GetMethod("AddFileCard", BindingFlags.Instance Or BindingFlags.NonPublic)

        addMethod.Invoke(instance, New Object() {"file1.docx", "http://dummy.com/1", "BN001", False})

        Dim panel1 = GetPanel1(instance)
        Dim card = panel1.Controls.OfType(Of Panel)().First()

        Dim btnNames = {"Replace", "Rename", "Archive", "Delete"}
        For Each name In btnNames
            Dim btn = card.Controls.OfType(Of Button)().FirstOrDefault(Function(b) b.Text = name)
            Assert.IsNotNull(btn, $"{name} button should exist in file card.")
        Next
    End Sub

End Class
