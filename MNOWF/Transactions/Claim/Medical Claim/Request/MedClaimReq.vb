
Imports System.ComponentModel
Imports BL

Public Class MedClaimReq

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPREQNO As Long
    Public Shared SELECTDOC As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLCMB()
        Try
            FILLOFFICER(CMBNAME, edit)
            FILLCATEGORY(CMBCATEGORY, edit)
            FILLVESSEL(CMBVESSEL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()
        TXTCOPY.Clear()

        TXTINWARDNO.Clear()
        CMDSELECTDOC.Enabled = True
        TXTSENTBY.Clear()
        RECDATE.Value = Mydate

        TXTREQNO.Clear()
        REQDATE.Value = Mydate

        CMBNAME.Text = ""
        CMBNAME.Enabled = True

        TXTCMPNAME.Clear()
        TXTRANK.Clear()
        TXTEMPCODE.Clear()
        AUTHOFROM.Value = Mydate
        AUTHOTILL.Value = Mydate
        DOJ.Value = Mydate
        TXTMUINO.Clear()

        CMBPATIENT.Text = ""
        CMBPATIENT.Items.Clear()

        TXTRELATION.Clear()
        TXTDIAGNOSIS.Clear()
        ILLNESSFROM.Value = Mydate
        ILLNESSTILL.Value = Mydate

        TXTHOSPNAME.Clear()
        TXTHOSPADD.Clear()
        TXTDRNAME.Clear()
        CMBVESSEL.Text = ""

        TXTBANK.Clear()
        TXTBRANCH.Clear()
        TXTACNAME.Clear()
        TXTACNO.Clear()
        TXTIFSCCODE.Clear()
        TXTBANKADD.Clear()

        TXTCLAIMED.Clear()
        TXTMAX.Clear()
        txtinwords.Clear()
        TXTREMARKS.Clear()

        CMBCATEGORY.Text = ""
        CMBCATEGORY.Enabled = True
        GRIDDETAILS.RowCount = 0

        TXTCLAIMED.Clear()

        GETMAXNO_REQNO()

        PBCORR.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLCLOSED.Visible = False

    End Sub

    Sub GETMAXNO_REQNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(REQ_NO),0) + 1 ", "MEDCLAIMREQ", " AND REQ_cmpid=" & CmpId & " AND REQ_LOCATIONid=" & Locationid & " AND REQ_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTREQNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub CMDSELECTDOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTDOC.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDOC.Clear()
            Dim OBJSELECTIN As New SelectInward
            OBJSELECTIN.frmstring = "MED"
            OBJSELECTIN.ShowDialog()

            Dim i As Integer = 0
            If SELECTDOC.Rows.Count > 0 Then
                TXTINWARDNO.Text = SELECTDOC.Rows(0).Item("INWARDNO")
                TXTSENTBY.Text = SELECTDOC.Rows(0).Item("SENTBY")
                RECDATE.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("RECDATE")).Date, "dd/MM/yyyy")
                CMBNAME.Focus()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub MedicalClaimRequest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim OBJMEDDTLS As New MedClaimReqDetails
            OBJMEDDTLS.MdiParent = MDIMain
            OBJMEDDTLS.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedicalClaimRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MED CLAIM REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            clear()
            FILLCMB()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCLAIM As New ClsMedClaimReq()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPREQNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCLAIM.alParaval = ALPARAVAL
                dt = OBJCLAIM.SELECTCLAIM()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTREQNO.Text = TEMPREQNO
                        REQDATE.Value = Convert.ToDateTime(dr("REQDATE")).Date
                        TXTINWARDNO.Text = dr("INWARDNO")
                        CMDSELECTDOC.Enabled = False

                        TXTSENTBY.Text = dr("SENTBY")
                        RECDATE.Value = Convert.ToDateTime(dr("RECDATE")).Date

                        CMBNAME.Text = dr("NAME")
                        CMBNAME.Enabled = False

                        GETFAMILYNAME()

                        TXTCMPNAME.Text = dr("CMPNAME")
                        TXTRANK.Text = dr("RANK")
                        TXTEMPCODE.Text = dr("EMPCODE")
                        TXTMUINO.Text = dr("MUINO")

                        AUTHOFROM.Value = Convert.ToDateTime(dr("AUTHOFROM")).Date
                        AUTHOTILL.Value = Convert.ToDateTime(dr("AUTHOTO")).Date
                        DOJ.Value = Convert.ToDateTime(dr("DOJ")).Date

                        GETFAMILYNAME()
                        CMBPATIENT.Text = dr("PATIENT")
                        TXTRELATION.Text = dr("RELATION")
                        TXTDIAGNOSIS.Text = dr("DIAGNOSIS")

                        ILLNESSFROM.Value = Convert.ToDateTime(dr("ILLFROM")).Date
                        ILLNESSTILL.Value = Convert.ToDateTime(dr("ILLTO")).Date

                        TXTHOSPNAME.Text = dr("HOSPNAME")
                        TXTHOSPADD.Text = dr("HOSPADD")
                        TXTDRNAME.Text = dr("DRNAME")
                        CMBVESSEL.Text = dr("VESSEL")

                        TXTBANK.Text = dr("BANK")
                        TXTBRANCH.Text = dr("BRANCH")
                        TXTACNAME.Text = dr("ACNAME")
                        TXTACNO.Text = dr("ACNO")
                        TXTIFSCCODE.Text = dr("IFSCCODE")
                        TXTBANKADD.Text = dr("BANKADD")


                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            LBLCLOSED.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        CMBCATEGORY.Text = dr("CATEGORY")
                        'CMBCATEGORY.Enabled = False

                        GRIDDETAILS.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("CLAIMED")), "0.00"), Format(Val(dr("MAX")), "0.00"))
                    Next

                    'CHECK WHETHER CORRESPONDENCE IS DONE OR NOT 
                    'IF DONE THE SHOW LABEL
                    'WE HAVE REMOVED YEARID CLAUSE AS WE WANT CORRESPONDENCE LOCK ON LOAD, IF WE HAVE FETCHED REQ NO FROM LAST YEAR, 
                    'AND CORRE Is DONE IN LAST YEAR, DONE BY GULKIT
                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search("CORRES_NO AS CORRESNO", "", " CORRESPONDENCE ", " AND CORRES_REQNO = " & TEMPREQNO)
                    If dt.Rows.Count > 0 Then
                        PBCORR.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


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
            For Each row As DataGridViewRow In GRIDDETAILS.Rows
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

            alParaval.Add(Format(REQDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTINWARDNO.Text.Trim)
            alParaval.Add(TXTSENTBY.Text.Trim)
            alParaval.Add(Format(RECDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Format(AUTHOFROM.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(AUTHOTILL.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(DOJ.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBPATIENT.Text.Trim)
            alParaval.Add(TXTDIAGNOSIS.Text.Trim)
            alParaval.Add(Format(ILLNESSFROM.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(ILLNESSTILL.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTHOSPNAME.Text.Trim)
            alParaval.Add(TXTHOSPADD.Text.Trim)
            alParaval.Add(TXTDRNAME.Text.Trim)
            alParaval.Add(CMBVESSEL.Text.Trim)
            alParaval.Add(TXTBANK.Text.Trim)
            alParaval.Add(TXTBRANCH.Text.Trim)
            alParaval.Add(TXTACNAME.Text.Trim)
            alParaval.Add(TXTACNO.Text.Trim)
            alParaval.Add(TXTIFSCCODE.Text.Trim)
            alParaval.Add(TXTBANKADD.Text.Trim)
            alParaval.Add(Val(TXTCLAIMED.Text.Trim))
            alParaval.Add(Val(TXTMAX.Text.Trim))
            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim CHARGES As String = ""
            Dim CLAIMED As String = ""
            Dim MAX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDETAILS.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = row.Cells(GCHARGES.Index).Value
                        CLAIMED = row.Cells(GCLAIMAMT.Index).Value.ToString
                        MAX = row.Cells(GMAXALLOWED.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = CHARGES & "," & row.Cells(GCHARGES.Index).Value
                        CLAIMED = CLAIMED & "," & row.Cells(GCLAIMAMT.Index).Value.ToString
                        MAX = MAX & "," & row.Cells(GMAXALLOWED.Index).Value

                    End If
                End If
            Next


            alParaval.Add(CMBCATEGORY.Text.Trim)
            alParaval.Add(GRIDSRNO)
            alParaval.Add(CHARGES)
            alParaval.Add(CLAIMED)
            alParaval.Add(MAX)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJREQ As New ClsMedClaimReq
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

        'DONE BY SALMAN ON 10-01-12
        'If TXTSENTBY.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTSENTBY, "Select Inward Document")
        '    bln = False
        'End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Claim Closed, Claim Locked")
            bln = False
        End If

        'AS PER USER'S REQD
        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Claim Reimbursed, Claim Locked")
        '    bln = False
        'End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Officer's Name")
            bln = False
        End If

        If CMBPATIENT.Text.Trim.Length = 0 Then
            EP.SetError(CMBPATIENT, "Select Family Member's Name")
            bln = False
        End If

        If TXTRELATION.Text.Trim.Length = 0 Then
            EP.SetError(TXTRELATION, "Select Family Member's Name")
            bln = False
        End If

        If TXTDIAGNOSIS.Text.Trim.Length = 0 Then
            EP.SetError(TXTDIAGNOSIS, "Enter Diagnosis for Claim")
            bln = False
        End If

        'If TXTHOSPNAME.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTHOSPNAME, "Enter Hospital Name for Claim")
        '    bln = False
        'End If

        If TXTHOSPADD.Text.Trim.Length = 0 Then
            EP.SetError(TXTHOSPADD, "Enter Hospital Address for Claim")
            bln = False
        End If

        If TXTDRNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTDRNAME, "Enter Doctor's Name for Claim")
            bln = False
        End If

        If CMBCATEGORY.Text.Trim.Length = 0 Then
            EP.SetError(CMBCATEGORY, "Select Category")
            bln = False
        End If

        If GRIDDETAILS.RowCount = 0 Then
            EP.SetError(CMBCATEGORY, "Select Category")
            bln = False
        End If

        'If Val(TXTCLAIMED.Text.Trim) = 0 Then
        '    EP.SetError(TXTCLAIMED, "Enter Claimed Amt")
        '    bln = False
        'End If

        If Val(TXTINWARDNO.Text.Trim) > 0 And edit = False Then
            'CHECKING WHETHER INWARD NO IS LOCKED OR NOT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DOCIN_DONE ", "", " DOCUMENTINWARD", " AND DOCIN_NO = " & Val(TXTINWARDNO.Text.Trim) & " AND DOCIN_CMPID = " & CmpId & " AND DOCIN_LOCATIONID = " & Locationid & " AND DOCIN_YEARID = " & YearId)
            If Convert.ToBoolean(DT.Rows(0).Item(0)) = True Then
                EP.SetError(TXTINWARDNO, "Inward No Locked")
                bln = False
            End If
        End If


        'If Not datecheck(REQDATE.Value) Then
        '    EP.SetError(REQDATE, "Date Not in Current Accounting Year")
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
                    DOJ.Value = Format(DT.Rows(0).Item("DOJ"), "dd/MM/yyyy")
                End If

                CMBNAME.Enabled = False

                TXTRELATION.Clear()
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
                CMBPATIENT.Items.Clear()
                For Each row As DataRow In DT.Rows
                    CMBPATIENT.Items.Add(row("FAMILY"))
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

    Private Sub CMBPATIENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPATIENT.Enter
        Try
            If CMBNAME.Text.Trim <> "" Then GETFAMILYNAME()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPATIENT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPATIENT.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" RELATIONMASTER.RELATION_NAME AS RELATION", "", " OFFICERMASTER_DESC INNER JOIN OFFICERMASTER ON OFFICERMASTER_DESC.OFFICER_ID = OFFICERMASTER.OFFICER_id AND OFFICERMASTER_DESC.OFFICER_CMPID = OFFICERMASTER.OFFICER_cmpid AND OFFICERMASTER_DESC.OFFICER_locationid = OFFICERMASTER.OFFICER_locationid AND OFFICERMASTER_DESC.OFFICER_yearid = OFFICERMASTER.OFFICER_yearid INNER JOIN FAMILYMASTER ON OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = FAMILYMASTER.FAMILY_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = FAMILYMASTER.FAMILY_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID INNER JOIN RELATIONMASTER ON OFFICERMASTER_DESC.OFFICER_RELATIONID = RELATIONMASTER.RELATION_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = RELATIONMASTER.RELATION_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = RELATIONMASTER.RELATION_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = RELATIONMASTER.RELATION_YEARID", " AND FAMILY_NAME = '" & CMBPATIENT.Text.Trim & "' AND OFFICERMASTER.OFFICER_NAME = '" & CMBNAME.Text.Trim & "' AND OFFICERMASTER.OFFICER_CMPID = " & CmpId & " AND OFFICERMASTER.OFFICER_LOCATIONID = " & Locationid & " AND OFFICERMASTER.OFFICER_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTRELATION.Text = DT.Rows(0).Item("RELATION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDDETAILS.RowCount = 0
LINE1:
            TEMPREQNO = Val(TXTREQNO.Text) + 1
            GETMAXNO_REQNO()
            Dim MAXNO As Integer = TXTREQNO.Text.Trim
            clear()
            If Val(TXTREQNO.Text) - 1 >= TEMPREQNO Then
                edit = True
                MedicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDDETAILS.RowCount = 0 And TEMPREQNO < MAXNO Then
                TXTREQNO.Text = TEMPREQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDDETAILS.RowCount = 0
LINE1:
            TEMPREQNO = Val(TXTREQNO.Text) - 1
            If TEMPREQNO > 0 Then
                edit = True
                MedicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDDETAILS.RowCount = 0 And TEMPREQNO > 1 Then
                TXTREQNO.Text = TEMPREQNO
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

            Dim OBJREQ As New ClsMedClaimReq
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
            GRIDDETAILS.RowCount = 0
            TEMPREQNO = Val(tstxtbillno.Text)
            If TEMPREQNO > 0 Then
                edit = True
                MedicalClaimRequest_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDDETAILS.CellValidating
        Try
            Dim colNum As Integer = GRIDDETAILS.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GCLAIMAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDDETAILS.CurrentCell.Value = Nothing Then GRIDDETAILS.CurrentCell.Value = "0.00"
                        GRIDDETAILS.CurrentCell.Value = Convert.ToDecimal(GRIDDETAILS.Item(colNum, e.RowIndex).Value)
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
            TXTCLAIMED.Clear()
            TXTMAX.Clear()
            For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
                ROW.Cells(GCLAIMAMT.Index).Value = Convert.ToDecimal(ROW.Cells(GCLAIMAMT.Index).EditedFormattedValue)
                TXTCLAIMED.Text = Format(Val(TXTCLAIMED.Text.Trim) + Val(ROW.Cells(GCLAIMAMT.Index).Value), "0.00")
                TXTMAX.Text = Format(Val(TXTMAX.Text.Trim) + Val(ROW.Cells(GMAXALLOWED.Index).EditedFormattedValue), "0.00")
            Next

            If Val(TXTCLAIMED.Text.Trim) > 0 Then txtinwords.Text = CurrencyToWord(Val(TXTCLAIMED.Text.Trim))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CATEGORYCONFIG.CATEGORY_GRIDSRNO AS GRIDSRNO, CHARGESMASTER.CHARGES_NAME AS CHARGES, CATEGORYCONFIG.CATEGORY_MAX AS MAX", "", " CATEGORYCONFIG INNER JOIN CATEGORYMASTER ON CATEGORYCONFIG.CATEGORY_ID = CATEGORYMASTER.CATEGORY_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CATEGORYMASTER.CATEGORY_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CATEGORYMASTER.CATEGORY_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CATEGORYMASTER.CATEGORY_YEARID INNER JOIN CHARGESMASTER ON CATEGORYCONFIG.CATEGORY_CHARGESID = CHARGESMASTER.CHARGES_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CHARGESMASTER.CHARGES_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CHARGESMASTER.CHARGES_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CHARGESMASTER.CHARGES_YEARID ", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND CATEGORYCONFIG.CATEGORY_CMPID = " & CmpId & " AND CATEGORYCONFIG.CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORYCONFIG.CATEGORY_YEARID = " & YearId & " ORDER BY CATEGORYCONFIG.CATEGORY_GRIDSRNO")
            If DT.Rows.Count > 0 Then
                If GRIDDETAILS.RowCount > 0 Then
                    Dim TEMPMSG As Integer = MsgBox("Delete All Rows from Grid?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        GRIDDETAILS.RowCount = 0
                    Else
                        CMBCATEGORY.Focus()
                        Exit Sub
                    End If
                End If
                For Each ROW As DataRow In DT.Rows
                    GRIDDETAILS.Rows.Add(ROW("GRIDSRNO"), ROW("CHARGES"), 0, ROW("MAX"))
                Next
                TOTAL()
                'cmbcategory.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
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

                Dim TEMPMSG As Integer = MsgBox("Wish to Close Req?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are You sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim OBJREQ As New ClsMedClaimReq
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPREQNO)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJREQ.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJREQ.CLOSE()

                        MsgBox("Req Closed")
                        REQDATE.Focus()

                    End If
                End If
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If edit = True Then
                Dim OBJCOR As New ShowCorrespondence
                OBJCOR.FRMSTRING = "MEDICAL"
                OBJCOR.REQNO = TEMPREQNO
                OBJCOR.MdiParent = MDIMain
                OBJCOR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDIAGNOSIS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDIAGNOSIS.Validated
        pcase(TXTDIAGNOSIS)
    End Sub

    Private Sub TXTDRNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDRNAME.Validated
        pcase(TXTDRNAME)
    End Sub

    Private Sub TXTBANK_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBANK.Validated
        pcase(TXTBANK)
    End Sub

    Private Sub TXTBANKADD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBANKADD.Validated
        pcase(TXTBANKADD)
    End Sub

    Private Sub TXTBRANCH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBRANCH.Validated
        pcase(TXTBRANCH)
    End Sub

    Private Sub TXTHOSPADD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHOSPADD.Validated
        pcase(TXTHOSPADD)
    End Sub

    Private Sub TXTHOSPNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHOSPNAME.Validated
        pcase(TXTHOSPNAME)
    End Sub

    Private Sub GRIDDETAILS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDETAILS.Enter
        Try
            If GRIDDETAILS.RowCount > 0 Then GRIDDETAILS.Rows(0).Cells(GCLAIMAMT.Index).Selected = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTACNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTACNAME.Validated
        pcase(TXTACNAME)
    End Sub

    Private Sub CORRES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORRES.Click
        Try
            If edit = True Then

                If PBCORR.Visible = True Then
                    MsgBox("Correspondence Already Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim ARRLIST As New ArrayList
                Dim OBJCORR As New Correspondence
                OBJCORR.MdiParent = MDIMain
                ARRLIST.Add(TEMPREQNO)
                ARRLIST.Add("MEDICAL")
                ARRLIST.Add(CMBNAME.Text.Trim)
                ARRLIST.Add(CMBCATEGORY.Text.Trim)
                ARRLIST.Add(CMBPATIENT.Text.Trim)
                ARRLIST.Add(TXTRELATION.Text.Trim)
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

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJCLAIM As New ClsMedClaimReq

                    ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJCLAIM.alParaval = ALPARAVAL
                    Dim dt As DataTable = OBJCLAIM.SELECTCLAIM()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows


                            CMBNAME.Text = dr("NAME")
                            CMBNAME.Enabled = False

                            GETFAMILYNAME()

                            TXTCMPNAME.Text = dr("CMPNAME")
                            TXTRANK.Text = dr("RANK")
                            TXTEMPCODE.Text = dr("EMPCODE")
                            TXTMUINO.Text = dr("MUINO")

                            AUTHOFROM.Value = Convert.ToDateTime(dr("AUTHOFROM")).Date
                            AUTHOTILL.Value = Convert.ToDateTime(dr("AUTHOTO")).Date
                            DOJ.Value = Convert.ToDateTime(dr("DOJ")).Date

                            GETFAMILYNAME()
                            CMBPATIENT.Text = dr("PATIENT")
                            TXTRELATION.Text = dr("RELATION")
                            TXTDIAGNOSIS.Text = dr("DIAGNOSIS")

                            ILLNESSFROM.Value = Convert.ToDateTime(dr("ILLFROM")).Date
                            ILLNESSTILL.Value = Convert.ToDateTime(dr("ILLTO")).Date

                            TXTHOSPNAME.Text = dr("HOSPNAME")
                            TXTHOSPADD.Text = dr("HOSPADD")
                            TXTDRNAME.Text = dr("DRNAME")
                            CMBVESSEL.Text = dr("VESSEL")

                            TXTBANK.Text = dr("BANK")
                            TXTBRANCH.Text = dr("BRANCH")
                            TXTACNAME.Text = dr("ACNAME")
                            TXTACNO.Text = dr("ACNO")
                            TXTIFSCCODE.Text = dr("IFSCCODE")
                            TXTBANKADD.Text = dr("BANKADD")


                            TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                            CMBCATEGORY.Text = dr("CATEGORY")
                            'CMBCATEGORY.Enabled = False

                            GRIDDETAILS.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("CLAIMED")), "0.00"), Format(Val(dr("MAX")), "0.00"))
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