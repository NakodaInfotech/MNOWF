Imports System.ComponentModel
Imports BL

Public Class EduClaimRequest

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPREQNO As Integer
    Public Shared SELECTDOC As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, edit)
            If cmbcategory.Text.Trim = "" Then FILLCATEGORY(cmbcategory, edit)
            FILLVESSEL(CMBVESSEL, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()
        TXTCOPY.Clear()

        txtinwardno.Clear()
        cmdselectdoc.Enabled = True
        txtsentby.Clear()
        recdate.Value = Mydate

        txtreqno.Clear()
        reqdate.Value = Mydate

        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        cmbchild.Items.Clear()

        TXTCMPNAME.Clear()
        TXTRANK.Clear()
        TXTEMPCODE.Clear()
        leavefrom.Value = Mydate
        leavetill.Value = Mydate
        doj.Value = Mydate
        TXTMUINO.Clear()
        cmbchild.Text = ""
        txtrelation.Clear()
        CMBCOURSE.Text = ""
        CMBCOURSEYEAR.Text = ""

        txtinstname.Clear()
        txtuniadd.Clear()
        txtuniname.Clear()
        CMBVESSEL.Text = ""

        txtbank.Clear()
        txtbranch.Clear()
        txtacname.Clear()
        txtacno.Clear()
        TXTIFSCCODE.Clear()
        txtbankadd.Clear()

        txtclaimed.Clear()
        txtmax.Clear()
        txtinwords.Clear()
        TXTREMARKS.Clear()

        cmbcategory.Text = ""
        cmbcategory.Enabled = True
        griddetails.RowCount = 0
        txtclaimed.Clear()

        GETMAXNO_REQNO()

        lbllocked.Visible = False
        PBlock.Visible = False
        LBLCLOSED.Visible = False

    End Sub

    Sub GETMAXNO_REQNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(REQ_NO),0) + 1 ", "eduCLAIMREQ", " AND REQ_cmpid=" & CmpId & " AND REQ_LOCATIONid=" & Locationid & " AND REQ_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtreqno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub CMDSELECTDOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectdoc.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDOC.Clear()
            Dim OBJSELECTIN As New SelectInward
            OBJSELECTIN.frmstring = "EDU"
            OBJSELECTIN.ShowDialog()

            Dim i As Integer = 0
            If SELECTDOC.Rows.Count > 0 Then
                txtinwardno.Text = SELECTDOC.Rows(0).Item("INWARDNO")
                txtsentby.Text = SELECTDOC.Rows(0).Item("SENTBY")
                recdate.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("RECDATE")).Date, "dd/MM/yyyy")
                CMBNAME.Focus()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub eduicalClaimRequest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                Call cmddelete_Click(sender, e)
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
            Dim OBJeduDTLS As New EduClaimReqDetails
            OBJeduDTLS.MdiParent = MDIMain
            OBJeduDTLS.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EduClaimRequest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub eduicalClaimRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'edu CLAIM REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            FILLCMB()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCLAIM As New ClsEduClaimReq()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPREQNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCLAIM.alParaval = ALPARAVAL
                dt = OBJCLAIM.SELECTCLAIM()

                If dt.Rows.Count > 0 Then

                    txtreqno.Text = TEMPREQNO
                    reqdate.Value = Convert.ToDateTime(dt.Rows(0).Item("REQDATE")).Date
                    txtinwardno.Text = dt.Rows(0).Item("INWARDNO")
                    cmdselectdoc.Enabled = False

                    txtsentby.Text = dt.Rows(0).Item("SENTBY")
                    recdate.Value = Convert.ToDateTime(dt.Rows(0).Item("RECDATE")).Date

                    CMBNAME.Text = dt.Rows(0).Item("NAME")
                    CMBNAME.Enabled = False

                    TXTCMPNAME.Text = dt.Rows(0).Item("CMPNAME")
                    TXTRANK.Text = dt.Rows(0).Item("RANK")
                    TXTEMPCODE.Text = dt.Rows(0).Item("EMPCODE")
                    TXTMUINO.Text = dt.Rows(0).Item("MUINO")

                    leavefrom.Value = Convert.ToDateTime(dt.Rows(0).Item("LEAVEFROM")).Date
                    leavetill.Value = Convert.ToDateTime(dt.Rows(0).Item("LEAVETO")).Date
                    doj.Value = Convert.ToDateTime(dt.Rows(0).Item("DOJ")).Date

                    GETFAMILYNAME()
                    cmbchild.Text = dt.Rows(0).Item("child")
                    txtrelation.Text = dt.Rows(0).Item("RELATION")
                    CMBCOURSE.Text = dt.Rows(0).Item("COURSE")
                    CMBCOURSEYEAR.Text = dt.Rows(0).Item("COURSEYEAR")

                    txtinstname.Text = dt.Rows(0).Item("INSTNAME")
                    txtuniname.Text = dt.Rows(0).Item("UNINAME")
                    txtuniadd.Text = dt.Rows(0).Item("UNIADD")
                    CMBVESSEL.Text = dt.Rows(0).Item("VESSEL")

                    txtbank.Text = dt.Rows(0).Item("BANK")
                    txtbranch.Text = dt.Rows(0).Item("BRANCH")
                    txtacname.Text = dt.Rows(0).Item("ACNAME")
                    txtacno.Text = dt.Rows(0).Item("ACNO")
                    TXTIFSCCODE.Text = dt.Rows(0).Item("IFSCCODE")
                    txtbankadd.Text = dt.Rows(0).Item("BANKADD")


                    TXTREMARKS.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))

                    If Convert.ToBoolean(dt.Rows(0).Item("DONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    If Convert.ToBoolean(dt.Rows(0).Item("CLOSED")) = True Then
                        LBLCLOSED.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                    cmbcategory.Text = dt.Rows(0).Item("CATEGORY")
                    'cmbcategory.Enabled = False


                    For Each dr As DataRow In dt.Rows
                        griddetails.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("claimed")), "0.00"), Format(Val(dr("MAX")), "0.00"))
                    Next
                    TOTAL()
                    chkchange.CheckState = CheckState.Checked
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            DELETE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In griddetails.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno()

            Dim alParaval As New ArrayList

            alParaval.Add(Format(reqdate.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(txtinwardno.Text.Trim)
            alParaval.Add(txtsentby.Text.Trim)
            alParaval.Add(Format(recdate.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Format(leavefrom.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(leavetill.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(doj.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(cmbchild.Text.Trim)
            alParaval.Add(CMBCOURSE.Text.Trim)
            alParaval.Add(CMBCOURSEYEAR.Text.Trim)

            alParaval.Add(txtinstname.Text.Trim)
            alParaval.Add(txtuniname.Text.Trim)
            alParaval.Add(txtuniadd.Text.Trim)
            alParaval.Add(CMBVESSEL.Text.Trim)
            alParaval.Add(txtbank.Text.Trim)
            alParaval.Add(txtbranch.Text.Trim)
            alParaval.Add(txtacname.Text.Trim)
            alParaval.Add(txtacno.Text.Trim)
            alParaval.Add(TXTIFSCCODE.Text.Trim)
            alParaval.Add(txtbankadd.Text.Trim)
            alParaval.Add(Val(txtclaimed.Text.Trim))
            alParaval.Add(Val(txtmax.Text.Trim))
            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim CHARGES As String = ""
            Dim claimed As String = ""
            Dim MAX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In griddetails.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = row.Cells(GCHARGES.Index).Value
                        claimed = row.Cells(GCLAIMAMT.Index).Value.ToString
                        MAX = row.Cells(GMAXALLOWED.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = CHARGES & "," & row.Cells(GCHARGES.Index).Value
                        claimed = claimed & "," & row.Cells(GCLAIMAMT.Index).Value.ToString
                        MAX = MAX & "," & row.Cells(GMAXALLOWED.Index).Value

                    End If
                End If
            Next


            alParaval.Add(cmbcategory.Text.Trim)
            alParaval.Add(GRIDSRNO)
            alParaval.Add(CHARGES)
            alParaval.Add(claimed)
            alParaval.Add(MAX)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJREQ As New ClsEduClaimReq
            OBJREQ.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJREQ.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPREQNO)
                DT = OBJREQ.update()
                MsgBox("Details Updated")
            End If

            clear()
            edit = False
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'If txtsentby.Text.Trim.Length = 0 Then
        '    EP.SetError(txtsentby, "Select Inward Document")
        '    bln = False
        'End If

        If CMBCOURSE.Text.Trim = "" Then
            EP.SetError(CMBCOURSE, "Select Course")
            bln = False
        End If

        If CMBCOURSEYEAR.Text.Trim = "" Then
            EP.SetError(CMBCOURSEYEAR, "Select Course Year")
            bln = False
        End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Claim Closed, Claim Locked")
            bln = False
        End If

        'AS PER REQUEST
        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Claim Reimbursed, Claim Locked")
        '    bln = False
        'End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Officer's Name")
            bln = False
        End If

        If cmbchild.Text.Trim.Length = 0 Then
            EP.SetError(cmbchild, "Select Family Member's Name")
            bln = False
        End If

        If txtrelation.Text.Trim.Length = 0 Then
            EP.SetError(txtrelation, "Select Family Member's Name")
            bln = False
        End If

        If txtinstname.Text.Trim.Length = 0 Then
            EP.SetError(txtinstname, "Enter Hospital Name for Claim")
            bln = False
        End If

        If txtuniadd.Text.Trim.Length = 0 Then
            EP.SetError(txtuniadd, "Enter Hospital Address for Claim")
            bln = False
        End If

        If txtuniname.Text.Trim.Length = 0 Then
            EP.SetError(txtuniname, "Enter Doctor's Name for Claim")
            bln = False
        End If

        If cmbcategory.Text.Trim.Length = 0 Then
            EP.SetError(cmbcategory, "Select Category")
            bln = False
        End If

        If griddetails.RowCount = 0 Then
            EP.SetError(cmbcategory, "Select Category")
            bln = False
        End If

        If Val(txtinwardno.Text.Trim) > 0 And edit = False Then
            'CHECKING WHETHER INWARD NO IS LOCKED OR NOT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DOCIN_DONE ", "", " DOCUMENTINWARD", " AND DOCIN_NO = " & Val(txtinwardno.Text.Trim) & " AND DOCIN_CMPID = " & CmpId & " AND DOCIN_LOCATIONID = " & Locationid & " AND DOCIN_YEARID = " & YearId)
            If Convert.ToBoolean(DT.Rows(0).Item(0)) = True Then
                EP.SetError(txtinwardno, "Inward No Locked")
                bln = False
            End If
        End If

        'If Val(txtclaimed.Text.Trim) = 0 Then
        '    EP.SetError(txtclaimed, "Enter claimed Amt")
        '    bln = False
        'End If

        'If Not datecheck(reqdate.Value) Then
        '    EP.SetError(reqdate, "Date Not in Current Accounting Year")
        '    bln = False
        'End If

        Return bln

    End Function

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, edit, " AND OFFICER_INDIAN = 'TRUE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJOFFICER As New SelectOfficer
                OBJOFFICER.ShowDialog()
                If OBJOFFICER.TEMPNAME <> "" Then CMBNAME.Text = OBJOFFICER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJOFFICER As New ClsOfficerMaster
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(CMBNAME.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJOFFICER.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJOFFICER.GETOFFICER
                If DT.Rows.Count > 0 Then
                    TXTRANK.Text = DT.Rows(0).Item("RANK")
                    TXTCMPNAME.Text = DT.Rows(0).Item("COMPANY")
                    TXTEMPCODE.Text = DT.Rows(0).Item("EMPCODE")
                    TXTMUINO.Text = DT.Rows(0).Item("MUINO")
                    doj.Value = Format(DT.Rows(0).Item("DOJ"), "dd/MM/yyyy")
                End If

                CMBNAME.Enabled = False

                txtrelation.Clear()
                GETFAMILYNAME()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETFAMILYNAME()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" FAMILYMASTER.FAMILY_NAME AS FAMILY", "", " OFFICERMASTER_DESC INNER JOIN OFFICERMASTER ON OFFICERMASTER_DESC.OFFICER_ID = OFFICERMASTER.OFFICER_id AND OFFICERMASTER_DESC.OFFICER_CMPID = OFFICERMASTER.OFFICER_cmpid AND OFFICERMASTER_DESC.OFFICER_locationid = OFFICERMASTER.OFFICER_locationid AND OFFICERMASTER_DESC.OFFICER_yearid = OFFICERMASTER.OFFICER_yearid INNER JOIN FAMILYMASTER ON OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = FAMILYMASTER.FAMILY_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = FAMILYMASTER.FAMILY_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID", " AND OFFICERMASTER.OFFICER_NAME = '" & CMBNAME.Text.Trim & "' AND OFFICERMASTER.OFFICER_CMPID = " & CmpId & " AND OFFICERMASTER.OFFICER_LOCATIONID = " & Locationid & " AND OFFICERMASTER.OFFICER_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "FAMILY"
                cmbchild.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    cmbchild.Items.Add(ROW("FAMILY"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then OFFICERVALIDATE(CMBNAME, e, Me, " AND OFFICER_INDIAN = 'TRUE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPATIENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbchild.Enter
        Try
            If CMBNAME.Text.Trim <> "" Then GETFAMILYNAME()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPATIENT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbchild.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" RELATIONMASTER.RELATION_NAME AS RELATION", "", " OFFICERMASTER_DESC INNER JOIN OFFICERMASTER ON OFFICERMASTER_DESC.OFFICER_ID = OFFICERMASTER.OFFICER_id AND OFFICERMASTER_DESC.OFFICER_CMPID = OFFICERMASTER.OFFICER_cmpid AND OFFICERMASTER_DESC.OFFICER_locationid = OFFICERMASTER.OFFICER_locationid AND OFFICERMASTER_DESC.OFFICER_yearid = OFFICERMASTER.OFFICER_yearid INNER JOIN FAMILYMASTER ON OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = FAMILYMASTER.FAMILY_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = FAMILYMASTER.FAMILY_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID INNER JOIN RELATIONMASTER ON OFFICERMASTER_DESC.OFFICER_RELATIONID = RELATIONMASTER.RELATION_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = RELATIONMASTER.RELATION_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = RELATIONMASTER.RELATION_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = RELATIONMASTER.RELATION_YEARID", " AND FAMILY_NAME = '" & cmbchild.Text.Trim & "' AND OFFICERMASTER.OFFICER_NAME = '" & CMBNAME.Text.Trim & "' AND OFFICERMASTER.OFFICER_CMPID = " & CmpId & " AND OFFICERMASTER.OFFICER_LOCATIONID = " & Locationid & " AND OFFICERMASTER.OFFICER_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then txtrelation.Text = DT.Rows(0).Item("RELATION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            griddetails.RowCount = 0
LINE1:
            TEMPREQNO = Val(txtreqno.Text) + 1
            GETMAXNO_REQNO()
            Dim MAXNO As Integer = txtreqno.Text.Trim
            clear()
            If Val(txtreqno.Text) - 1 >= TEMPREQNO Then
                edit = True
                eduicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If griddetails.RowCount = 0 And TEMPREQNO < MAXNO Then
                txtreqno.Text = TEMPREQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            griddetails.RowCount = 0
LINE1:
            TEMPREQNO = Val(txtreqno.Text) - 1
            If TEMPREQNO > 0 Then
                edit = True
                eduicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If griddetails.RowCount = 0 And TEMPREQNO > 1 Then
                txtreqno.Text = TEMPREQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
    End Sub

    Sub DELETE()
        Try
            If edit = False Then Exit Sub
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If lbllocked.Visible = True Then
                MsgBox("Unable To Delete, Entry Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Wish to Delete Request?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJREQ As New ClsEduClaimReq
            OBJREQ.alParaval.Add(TEMPREQNO)
            OBJREQ.alParaval.Add(CmpId)
            OBJREQ.alParaval.Add(0)
            OBJREQ.alParaval.Add(YearId)

            Dim DT As DataTable = OBJREQ.Delete
            MsgBox("Request Deleted Successfully")
            edit = False
            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            griddetails.RowCount = 0
            TEMPREQNO = Val(tstxtbillno.Text)
            If TEMPREQNO > 0 Then
                edit = True
                eduicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then FILLCATEGORY(cmbcategory, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles griddetails.CellValidating
        Try
            Dim colNum As Integer = griddetails.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GCLAIMAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If griddetails.CurrentCell.Value = Nothing Then griddetails.CurrentCell.Value = "0.00"
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                    TOTAL()

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            txtclaimed.Clear()
            txtmax.Clear()
            For Each ROW As DataGridViewRow In griddetails.Rows
                ROW.Cells(GCLAIMAMT.Index).Value = Convert.ToDecimal(ROW.Cells(GCLAIMAMT.Index).EditedFormattedValue)
                txtclaimed.Text = Format(Val(txtclaimed.Text.Trim) + Val(ROW.Cells(GCLAIMAMT.Index).EditedFormattedValue), "0.00")
                txtmax.Text = Format(Val(txtmax.Text.Trim) + Val(ROW.Cells(GMAXALLOWED.Index).EditedFormattedValue), "0.00")
            Next

            If Val(txtclaimed.Text.Trim) > 0 Then txtinwords.Text = CurrencyToWord(Val(txtclaimed.Text.Trim))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CATEGORYCONFIG.CATEGORY_GRIDSRNO AS GRIDSRNO, CHARGESMASTER.CHARGES_NAME AS CHARGES, CATEGORYCONFIG.CATEGORY_MAX AS MAX", "", " CATEGORYCONFIG INNER JOIN CATEGORYMASTER ON CATEGORYCONFIG.CATEGORY_ID = CATEGORYMASTER.CATEGORY_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CATEGORYMASTER.CATEGORY_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CATEGORYMASTER.CATEGORY_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CATEGORYMASTER.CATEGORY_YEARID INNER JOIN CHARGESMASTER ON CATEGORYCONFIG.CATEGORY_CHARGESID = CHARGESMASTER.CHARGES_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CHARGESMASTER.CHARGES_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CHARGESMASTER.CHARGES_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CHARGESMASTER.CHARGES_YEARID ", " AND CATEGORYMASTER.CATEGORY_NAME = '" & cmbcategory.Text.Trim & "' AND CATEGORYCONFIG.CATEGORY_CMPID = " & CmpId & " AND CATEGORYCONFIG.CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORYCONFIG.CATEGORY_YEARID = " & YearId & " ORDER BY CATEGORYCONFIG.CATEGORY_GRIDSRNO")
            If DT.Rows.Count > 0 Then
                If griddetails.RowCount > 0 Then
                    Dim TEMPMSG As Integer = MsgBox("Delete All Rows from Grid?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        griddetails.RowCount = 0
                    Else
                        cmbcategory.Focus()
                        Exit Sub
                    End If
                End If
                For Each ROW As DataRow In DT.Rows
                    griddetails.Rows.Add(ROW("GRIDSRNO"), ROW("CHARGES"), 0, ROW("MAX"))
                Next
                TOTAL()
                'cmbcategory.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Close Req?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are You sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim OBJREQ As New ClsEduClaimReq
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPREQNO)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJREQ.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJREQ.CLOSE()

                        MsgBox("Req Closed")
                        reqdate.Focus()

                    End If
                End If
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOURSE.Enter
        Try
            If CMBCOURSE.Text.Trim = "" Then FILLCOURSE(CMBCOURSE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSEYEAR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOURSEYEAR.Enter
        Try
            If CMBCOURSEYEAR.Text.Trim = "" Then FILLCOURSEYEAR(CMBCOURSEYEAR, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOURSE.Validating
        Try
            If CMBCOURSE.Text.Trim <> "" Then COURSEVALIDATE(CMBCOURSE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSEYEAR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOURSEYEAR.Validating
        Try
            If CMBCOURSEYEAR.Text.Trim <> "" Then COURSEYEARVALIDATE(CMBCOURSEYEAR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If edit = True Then
                Dim OBJCOR As New ShowCorrespondence
                OBJCOR.FRMSTRING = "EDUCATION"
                OBJCOR.REQNO = TEMPREQNO
                OBJCOR.MdiParent = MDIMain
                OBJCOR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles griddetails.Enter
        Try
            If griddetails.RowCount > 0 Then griddetails.Rows(0).Cells(GCLAIMAMT.Index).Selected = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuniname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuniname.Validated
        Try
            pcase(txtuniname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuniadd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuniadd.Validated
        Try
            pcase(txtuniadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtinstname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinstname.Validated
        Try
            pcase(txtinstname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBANK_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbank.Validated
        pcase(txtbank)
    End Sub

    Private Sub TXTBANKADD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbankadd.Validated
        pcase(txtbankadd)
    End Sub

    Private Sub TXTBRANCH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbranch.Validated
        pcase(txtbranch)
    End Sub

    Private Sub TXTACNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtacname.Validated
        pcase(txtacname)
    End Sub

    Private Sub CORRES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORRES.Click
        Try
            If edit = True Then
                Dim ARRLIST As New ArrayList
                Dim OBJCORR As New Correspondence
                OBJCORR.MdiParent = MDIMain
                ARRLIST.Add(TEMPREQNO)
                ARRLIST.Add("EDUCATION")
                ARRLIST.Add(CMBNAME.Text.Trim)
                ARRLIST.Add(cmbcategory.Text.Trim)
                ARRLIST.Add(cmbchild.Text.Trim)
                ARRLIST.Add(txtrelation.Text.Trim)
                OBJCORR.ARRLIST = ARRLIST
                OBJCORR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        numkeypress(e, TXTCOPY, Me)
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If edit = False And TXTCOPY.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Request No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim dt As New DataTable
                    Dim OBJCLAIM As New ClsEduClaimReq()
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJCLAIM.alParaval = ALPARAVAL
                    dt = OBJCLAIM.SELECTCLAIM()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            CMBNAME.Text = dr("NAME")
                            CMBNAME.Enabled = False

                            TXTCMPNAME.Text = dr("CMPNAME")
                            TXTRANK.Text = dr("RANK")
                            TXTEMPCODE.Text = dr("EMPCODE")
                            TXTMUINO.Text = dr("MUINO")

                            leavefrom.Value = Convert.ToDateTime(dr("LEAVEFROM")).Date
                            leavetill.Value = Convert.ToDateTime(dr("LEAVETO")).Date
                            doj.Value = Convert.ToDateTime(dr("DOJ")).Date

                            GETFAMILYNAME()
                            cmbchild.Text = dr("child")
                            txtrelation.Text = dr("RELATION")
                            CMBCOURSE.Text = dr("COURSE")
                            CMBCOURSEYEAR.Text = dr("COURSEYEAR")

                            txtinstname.Text = dr("INSTNAME")
                            txtuniname.Text = dr("UNINAME")
                            txtuniadd.Text = dr("UNIADD")
                            CMBVESSEL.Text = dr("VESSEL")

                            txtbank.Text = dr("BANK")
                            txtbranch.Text = dr("BRANCH")
                            txtacname.Text = dr("ACNAME")
                            txtacno.Text = dr("ACNO")
                            TXTIFSCCODE.Text = dr("IFSCCODE")
                            txtbankadd.Text = dr("BANKADD")


                            TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                            cmbcategory.Text = dr("CATEGORY")

                            griddetails.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("claimed")), "0.00"), Format(Val(dr("MAX")), "0.00"))
                        Next
                        TOTAL()
                        chkchange.CheckState = CheckState.Checked
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVESSEL_Enter(sender As Object, e As EventArgs) Handles CMBVESSEL.Enter
        Try
            If CMBVESSEL.Text.Trim = "" Then FILLVESSEL(CMBVESSEL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVESSEL_Validating(sender As Object, e As CancelEventArgs) Handles CMBVESSEL.Validating
        Try
            If CMBVESSEL.Text.Trim <> "" Then VESSELVALIDATE(CMBVESSEL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class