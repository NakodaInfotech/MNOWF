
Imports BL

Public Class E_Mail

    Public attachment As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If cmbfirstadd.Text.Trim <> Nothing Then
                ' sendemail(cmbfirstadd.Text.Trim, txtattachment.Text.Trim, txtmailbody.Text.Trim, txtsubject.Text.Trim, CHKDEC.Checked, CHKDOM.Checked, CHKHOSP.Checked, CHKEDU.Checked, CHKBOOKING.Checked)
            End If
            MsgBox("Mails sent successfully")
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbfirstadd.Text.Trim.Length = 0 Then
            EP.SetError(cmbfirstadd, "Enter Email Address")
        End If
        Return bln
    End Function

    Private Sub SendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.M Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            If cmb.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("email_id", "", "EmailMaster", " and email_cmpid = " & CmpId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Email_id"
                    cmb.DataSource = dt
                    cmb.DisplayMember = "Email_id"
                    cmb.Text = ""
                End If
                cmb.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfirstadd.GotFocus
        Try
            fillcmb(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub cmbvalidate(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            Dim intresult As Integer
            If cmb.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("Email_id", "", "EmailMaster", " and Email_id = '" & cmb.Text.Trim & "' and Email_cmpid = " & CmpId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Email Address not present, Add New?", MsgBoxStyle.YesNo, "Office Manager")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmb.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objEmailmaster As New ClsEmailMaster
                        objEmailmaster.alParaval = alParaval
                        IntResult = objEmailmaster.save()
                        'e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfirstadd.Validating
        Try
            cmbvalidate(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbrowse.Click
        txtattachment.Clear()
        OpenFileDialog1.ShowDialog()

        txtattachment.Text = OpenFileDialog1.FileName
        
    End Sub
End Class