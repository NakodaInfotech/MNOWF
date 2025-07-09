
Imports BL

Public Class Correspondence

    Dim SELECTDT As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPCORRESNO As Integer
    Public ARRLIST As New ArrayList
    Dim DTWHATSAPP As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBTYPE.Focus()
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()

        CMBTYPE.SelectedIndex = 0
        TXTCORRESPONDENCENO.Clear()
        CMBTYPE.Enabled = True
        TXTREQNO.Clear()
        CORRESPONDENCEDATE.Value = Mydate
        RECDDATE.Value = Mydate

        TXTNAME.Clear()
        TXTOFFICERNAME.Clear()
        TXTCATEGORY.Clear()
        TXTFAMILY.Clear()
        TXTRELATION.Clear()
        txtremarks.Clear()
        TXTRECDREMARKS.Clear()
        TXTPARA1.Clear()
        TXTPARA2.Clear()

        GETMAXNO_CORRESNO()

        CMDSHOWDETAILS.Enabled = True
        LBLWHATSAPP.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLCLOSED.Visible = False
        FILLGRID()

    End Sub

    Sub GETMAXNO_CORRESNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CORRES_NO),0) + 1 ", "CORRESPONDENCE", " AND CORRES_cmpid=" & CmpId & " AND CORRES_LOCATIONid=" & Locationid & " AND CORRES_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCORRESPONDENCENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub Correspondence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Or chkchange.CheckState = CheckState.Checked Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                DELETE()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Delete
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                'e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F1 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJCORRESDTLS As New CorrespondenceDetails
            OBJCORRESDTLS.MdiParent = MDIMain
            OBJCORRESDTLS.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Correspondence_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CAST('0' AS BIT) AS DONE, NARRATION_NAME AS NARRATION, NARRATION_ID AS NARRID ", "", " NARRATIONMASTER ", " and NARRATION_TYPE ='" & CMBEMP.Text.Trim & "' AND NARRATION_CMPID = " & CmpId & " AND NARRATION_LOCATIONID = " & Locationid & " AND NARRATION_YEARID = " & YearId)
            gridBilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Correspondence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CORRESPONDENCE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()

            If ARRLIST.Count > 0 Then
                TXTREQNO.Text = ARRLIST.Item(0)
                CMBTYPE.Text = ARRLIST.Item(1)
                TXTOFFICERNAME.Text = ARRLIST.Item(2)
                TXTCATEGORY.Text = ARRLIST.Item(3)
                TXTFAMILY.Text = ARRLIST.Item(4)
                TXTRELATION.Text = ARRLIST.Item(5)
            End If


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCOR As New ClsCorrespondence()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPCORRESNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCOR.alParaval = ALPARAVAL
                dt = OBJCOR.SELECTCORRES

                If dt.Rows.Count > 0 Then

                    CMBEMP.Text = dt.Rows(0).Item("EMPTYPE")
                    FILLGRID()
                    CMDSHOWDETAILS.Enabled = False

                    For Each dr As DataRow In dt.Rows

                        TXTCORRESPONDENCENO.Text = TEMPCORRESNO

                        CMBTYPE.Text = dr("TYPE")
                        CMBTYPE.Enabled = False

                        CHKLEAVE.Checked = Convert.ToBoolean(dr("LEAVE"))
                        DTLEAVEFROM.Value = Convert.ToDateTime(dr("LEAVEFROM")).Date
                        DTLEAVETO.Value = Convert.ToDateTime(dr("LEAVETO")).Date

                        CORRESPONDENCEDATE.Value = Convert.ToDateTime(dr("DATE")).Date
                        TXTREQNO.Text = dr("REQNO")

                        TXTOFFICERNAME.Text = dr("NAME")
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTPARA1.Text = Convert.ToString(dr("PARA1"))
                        TXTPARA2.Text = Convert.ToString(dr("PARA2"))

                        RECDDATE.Value = Convert.ToDateTime(dr("RECDDATE")).Date
                        TXTCATEGORY.Text = Convert.ToString(dr("CATEGORY"))
                        TXTRELATION.Text = Convert.ToString(dr("RELATION"))
                        TXTFAMILY.Text = Convert.ToString(dr("FAMILY"))
                        TXTNAME.Text = Convert.ToString(dr("CONTACTPERSON"))

                        TXTRECDREMARKS.Text = Convert.ToString(dr("RECDREMARKS"))

                        For I As Integer = 0 To gridbill.RowCount - 1
                            Dim DTR As DataRow = gridbill.GetDataRow(I)
                            If DTR("NARRID") = dr("NARRID") Then DTR("DONE") = True
                        Next

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            LBLCLOSED.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        If Convert.ToBoolean(dr("SENDWHATSAPP")) = True Then LBLWHATSAPP.Visible = True
                    Next
                    chkchange.CheckState = CheckState.Checked
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDT.Clear()
            Dim OBJSELECTORR As New SelectClaimReq
            OBJSELECTORR.FRMSTRING = CMBTYPE.Text.Trim
            OBJSELECTORR.ShowDialog()
            SELECTDT = OBJSELECTORR.DT

            Dim i As Integer = 0
            If SELECTDT.Rows.Count > 0 Then
                TXTREQNO.Text = SELECTDT.Rows(0).Item("REQNO")
                TXTOFFICERNAME.Text = SELECTDT.Rows(0).Item("NAME")
                TXTFAMILY.Text = SELECTDT.Rows(0).Item("FAMILY")
                TXTRELATION.Text = SELECTDT.Rows(0).Item("RELATION")
                TXTCATEGORY.Text = SELECTDT.Rows(0).Item("CATEGORY")
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBEMP.Text.Trim)
            alParaval.Add(CMBTYPE.Text.Trim)

            alParaval.Add(CHKLEAVE.Checked)

            alParaval.Add(Format(DTLEAVEFROM.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(DTLEAVETO.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(CORRESPONDENCEDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTREQNO.Text.Trim)
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTOFFICERNAME.Text.Trim)
            alParaval.Add(TXTFAMILY.Text.Trim)
            alParaval.Add(TXTRELATION.Text.Trim)
            alParaval.Add(TXTCATEGORY.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(Format(RECDDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTRECDREMARKS.Text.Trim)

            Dim NARRAID As String = ""
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(ROW("DONE")) = True Then
                    If NARRAID = "" Then
                        NARRAID = ROW("NARRID")
                    Else
                        NARRAID = NARRAID & "," & ROW("NARRID")
                    End If
                End If
            Next

            alParaval.Add(NARRAID)

            alParaval.Add(TXTPARA1.Text.Trim)
            alParaval.Add(TXTPARA2.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJCORR As New ClsCorrespondence
            OBJCORR.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJCORR.save()
                TEMPCORRESNO = DT.Rows(0).Item(0)
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCORRESNO)
                DT = OBJCORR.update()
                MsgBox("Details Updated")
            End If


            Call PrintToolStripButton_Click(sender, e)


            If TXTRECDREMARKS.Text.Trim <> "" Then
                Call cmdclose_Click(sender, e)
            End If


            clear()
            edit = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If RECDDATE.Value.Date < CORRESPONDENCEDATE.Value.Date Then
            EP.SetError(RECDDATE, "Enter Proper Recd Date")
            bln = False
        End If

        If CMBEMP.Text.Trim.Length = 0 Then
            EP.SetError(CMBEMP, "Select Type")
            bln = False
        End If

        If TXTREQNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTREQNO, "Select Claim Request")
            bln = False
        End If

        If TXTOFFICERNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTOFFICERNAME, "Select Officer Name")
            bln = False
        End If

        If TXTFAMILY.Text.Trim.Length = 0 Then
            EP.SetError(TXTFAMILY, "Select Claim Request")
            bln = False
        End If

        If TXTRELATION.Text.Trim.Length = 0 Then
            EP.SetError(TXTRELATION, "Select Claim Request")
            bln = False
        End If

        'If txtremarks.Text.Trim = "" Then
        '    EP.SetError(txtremarks, "Enter Remarks")
        '    bln = False
        'End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Correspondence Closed")
            bln = False
        End If

        Return bln

    End Function

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TXTFAMILY.Clear()
LINE1:
            TEMPCORRESNO = Val(TXTCORRESPONDENCENO.Text) + 1
            GETMAXNO_CORRESNO()
            Dim MAXNO As Integer = TXTCORRESPONDENCENO.Text.Trim
            clear()
            If Val(TXTCORRESPONDENCENO.Text) - 1 >= TEMPCORRESNO Then
                edit = True
                Correspondence_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TXTFAMILY.Text.Trim = "" And TEMPCORRESNO < MAXNO Then
                TXTCORRESPONDENCENO.Text = TEMPCORRESNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TXTFAMILY.Clear()
LINE1:
            TEMPCORRESNO = Val(TXTCORRESPONDENCENO.Text) - 1
            If TEMPCORRESNO > 0 Then
                edit = True
                Correspondence_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TXTFAMILY.Text.Trim = "" And TEMPCORRESNO > 1 Then
                TXTCORRESPONDENCENO.Text = TEMPCORRESNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
        clear()
        edit = False
    End Sub

    Sub DELETE()
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = False Then
                MsgBox("Delete Allowed for Saved Correspondence only", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Then
                MsgBox("Correspondence Locked, Delete not Allowed", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim ALPARAVAL As New ArrayList
            Dim OBJMED As New ClsCorrespondence
            ALPARAVAL.Add(TEMPCORRESNO)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)
            OBJMED.alParaval = ALPARAVAL

            Dim DT As DataTable = OBJMED.Delete
            If DT.Rows.Count > 0 Then MsgBox(DT.Rows(0).Item(0))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            TEMPCORRESNO = Val(tstxtbillno.Text)
            If TEMPCORRESNO > 0 Then
                edit = True
                Correspondence_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub



            Dim DOCSREQD As String = ""
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If ROW("DONE") = True Then
                    'ADDING IN DTWHATSAPP
                    DOCSREQD = DOCSREQD & "**" & ROW("NARRATION") & "*" & vbCrLf
                End If
            Next

            If txtremarks.Text.Trim <> "" Then DOCSREQD = DOCSREQD & "**" & txtremarks.Text.Trim & "*" & vbCrLf

            Dim OBJWHATSAPP As New SendWhatsapp
            Dim OBJCMN As New ClsCommon
            OBJWHATSAPP.OFFICERNAME = TXTOFFICERNAME.Text.Trim
            OBJWHATSAPP.MSG = "Dear Sir,
While reviewing your " & CMBTYPE.Text.Trim & " Reimbursement Claim No: " & Val(TXTREQNO.Text.Trim) & ".For your " & TXTRELATION.Text.Trim & " treatment, we require additional documents for verification. Could you please provide the following documents :  

" & DOCSREQD & "

Once we receive the above required documents, we will expedite the processing of your reimbursement.

If you have any further query please feel free to reach out for assistance on our Email mail@mnowf.com or Telephone No:022 49680968. Mob No: +918828326202

Thank you for your cooperation
Best Regards,
The Merchant Navy Officers’ Welfare Fund"
            OBJWHATSAPP.ShowDialog()
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If TXTRECDREMARKS.Text.Trim = "" Then
                    EP.SetError(TXTRECDREMARKS, "Please fill Recd Remarks")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Close Correspondence?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are You sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim OBJCORR As New ClsCorrespondence
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPCORRESNO)
                        ALPARAVAL.Add(Format(RECDDATE.Value.Date, "MM/dd/yyyy"))
                        ALPARAVAL.Add(TXTRECDREMARKS.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJCORR.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJCORR.CLOSE()

                        MsgBox("Req Closed")

                    End If
                End If
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If TEMPCORRESNO > 0 Then
                Dim TEMPMSG As Integer
                If CMBEMP.Text.Trim = "COMPANY" Then
                    TEMPMSG = MsgBox("Print Company Letter?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJCORRES As New CorrespondenceDesign
                        OBJCORRES.MdiParent = MDIMain
                        OBJCORRES.CORRESNO = TEMPCORRESNO
                        OBJCORRES.FRMSTRING = "COMPANY"
                        OBJCORRES.Show()
                    End If
                Else
                    TEMPMSG = MsgBox("Print Officer Letter?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJCORRES As New CorrespondenceDesign
                        OBJCORRES.MdiParent = MDIMain
                        OBJCORRES.CORRESNO = TEMPCORRESNO
                        OBJCORRES.FRMSTRING = "OFFICER"
                        OBJCORRES.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEMP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEMP.Validated
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class