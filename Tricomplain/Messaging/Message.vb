Imports System.Net.Http
Imports System.Text

Public Class Message

    Private commuterKey As String
    Private firebaseBase As String = "https://tricomplain-default-rtdb.firebaseio.com/commuter complaint"

    '===============================================
    '   RECEIVE COMMUTER KEY FROM COMPLAINTS FORM
    '===============================================
    Public Sub New(key As String)
        InitializeComponent()
        commuterKey = key
    End Sub


    '===============================================
    '   CLOSE BUTTON → CLOSE MESSAGE FORM
    '===============================================
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        MyBase.Close()   ' FIXED: CLOSE FORM PROPERLY
    End Sub



    '===============================================
    '   SEND MESSAGE BUTTON (SAVE TO FIREBASE)
    '===============================================
    Private Async Sub Send_Click(sender As Object, e As EventArgs) Handles Send.Click

        If textmsg.Text.Trim() = "" Then
            MsgBox("Please enter a message", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Escape quotes for safe JSON
        Dim safeMessage As String = textmsg.Text.Replace("""", "'"c)

        Dim updateJson As String =
            "{ ""message"": """ & safeMessage & """ }"

        Dim url As String = firebaseBase & "/" & commuterKey & ".json"

        Dim client As New HttpClient()
        Dim content As New StringContent(updateJson, Encoding.UTF8, "application/json")

        Dim response = Await client.PatchAsync(url, content)

        If response.IsSuccessStatusCode Then
            MsgBox("Message sent!", MsgBoxStyle.Information)
            MyBase.Close()   ' FIXED: CLOSE FORM AFTER SENDING
        Else
            MsgBox("Failed to send message!", MsgBoxStyle.Critical)
        End If

    End Sub

End Class
