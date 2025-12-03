Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq

<TestClass>
Public Class ValidReportTests

    <TestMethod>
    Public Sub LoadComplaints_ShouldFilterValidOnly()
        ' Sample data
        Dim json = "{
            'c1': {'ticketNo':'BN001','status':'valid','violation':'Speeding','message':'Fine 100'},
            'c2': {'ticketNo':'BN002','status':'invalid','violation':'Late','message':'Warning'}
        }"
        Dim allComplaints As JObject = JObject.Parse(json)

        Dim validList = New List(Of JObject)
        For Each item In allComplaints.Properties()
            Dim complaint As JObject = item.Value
            If complaint("status")?.ToString() = "valid" Then
                validList.Add(complaint)
            End If
        Next

        Assert.AreEqual(1, validList.Count)
        Assert.AreEqual("BN001", validList(0)("ticketNo").ToString())
    End Sub

End Class
