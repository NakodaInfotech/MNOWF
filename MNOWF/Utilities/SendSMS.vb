
Imports System.IO
Imports System.Net

Public Class SendSMS

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim SourceStream As System.IO.Stream
            Dim myRequest As System.Net.HttpWebRequest = WebRequest.Create("http://s1.freesmsapi.com/messages/send?skey=b53d83a8d614ceda6b7560cf8c876309&message=" & txtmailbody.Text.Trim & "&senderid=Bits&recipient=" & txtmobileno.Text.Trim)
            myRequest.Credentials = CredentialCache.DefaultCredentials
            Dim webResponse As WebResponse = myRequest.GetResponse
            SourceStream = webResponse.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(webResponse.GetResponseStream())
            Dim str As String = reader.ReadLine()
            MsgBox(str)

            txtmailbody.Clear()
            txtmobileno.Clear()
            txtmobileno.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SendSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for ok
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemSemicolon Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class