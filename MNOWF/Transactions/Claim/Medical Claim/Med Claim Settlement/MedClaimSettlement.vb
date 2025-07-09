
Imports System.ComponentModel
Imports BL

Public Class MedClaimSettlement

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPSETTLENO As Integer
    Public TEMPREQNO As Integer
    Public FRMSTRING As String
    Public TEMPREG As String
    Public Shared SELECTDOC As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub FILLCMB()
        Try
            FILLOFFICER(CMBNAME, EDIT)
            FILLCATEGORY(CMBCATEGORY, EDIT)
            FILLVESSEL(CMBVESSEL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETEDUSUPP()
        Try
            If FRMSTRING = "MEDSUPP" Then
                Me.Text = "Med Supplimentary Claim"
                LBLPRE.Visible = True
                TXTPRESETTLEAMT.Visible = True

                If TXTREQNO.Text.Trim <> "" Then
                    'GET PRESETTLEAMT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" SETTLE_TOTALAMT AS SETTLEAMT", "", " MEDCLAIMSETTLEMENT", " AND SETTLE_REQNO = " & TXTREQNO.Text.Trim & " and SETTLE_TYPE = 'MEDICAL' AND SETTLE_CMPID = " & CmpId & " AND SETTLE_LOCATIONID  =  " & Locationid & " AND SETTLE_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTPRESETTLEAMT.Text = Val(DT.Rows(0).Item("SETTLEAMT"))
                End If
            Else
                Me.Text = "Med Claim Settlement"
                LBLPRE.Visible = False
                TXTPRESETTLEAMT.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()
        TXTSEARCHREQNO.Clear()
        TXTCOPY.Clear()

        GETEDUSUPP()

        CMDSELECTREQ.Enabled = True

        TXTINWARDNO.Clear()
        CMDSELECTDOC.Enabled = True
        TXTSENTBY.Clear()
        RECDATE.Value = Mydate

        txtsettleno.Clear()
        SETTLEDATE.Value = Mydate
        TXTREQNO.Clear()
        TXTREQNO.ReadOnly = False
        REQDATE.Value = Mydate

        CMBNAME.Text = ""
        CMBNAME.Enabled = True

        TXTCMPNAME.Clear()
        TXTRANK.Clear()
        TXTMUINO.Clear()
        TXTEMPCODE.Clear()
        DOJ.Value = Mydate
        AUTHOFROM.Value = Mydate
        AUTHOTILL.Value = Mydate

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
        TXTTOTALAMT.Clear()
        txtinwords.Clear()
        TXTREMARKS.Clear()

        CMBCATEGORY.Text = ""
        CMBCATEGORY.Enabled = True
        GRIDDETAILS.RowCount = 0

        TXTCLAIMED.Clear()

        GETMAXNO_SETTLENO()
        GETMAXNO_REQNO()

        PBCORR.Visible = False
        LBLCLOSED.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        PBPAID.Visible = False
        LBLWHATSAPP.Visible = False

        CHKVERIFIED.CheckState = CheckState.Unchecked
        CHKVERIFIED.Enabled = EDIT

    End Sub

    Sub GETMAXNO_SETTLENO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SETTLE_NO),0) + 1 ", "MEDCLAIMSETTLEMENT", " AND SETTLE_cmpid=" & CmpId & " AND SETTLE_LOCATIONid=" & Locationid & " AND SETTLE_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtsettleno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub GETMAXNO_REQNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SETTLE_REQNO),0) + 1 ", "MEDCLAIMSETTLEMENT", " AND SETTLE_cmpid=" & CmpId & " AND SETTLE_LOCATIONid=" & Locationid & " AND SETTLE_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTREQNO.Text = Val(DTTABLE.Rows(0).Item(0))
        End If
    End Sub

    Private Sub CMDSELECTREQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTREQ.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDOC.Clear()
            Dim OBJSELECTORR As New SelectClaimReq
            OBJSELECTORR.FRMSTRING = FRMSTRING

            OBJSELECTORR.ShowDialog()
            SELECTDOC = OBJSELECTORR.DT
            Dim i As Integer = 0
            If SELECTDOC.Rows.Count > 0 Then
                GRIDDETAILS.RowCount = 0
                TXTREQNO.Text = Val(SELECTDOC.Rows(0).Item("REQNO"))
                REQDATE.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("REQDATE")).Date, "dd/MM/yyyy")
                SETTLEDATE.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("REQDATE")).Date, "dd/MM/yyyy")
                CMBNAME.Text = SELECTDOC.Rows(0).Item("NAME")
                TXTCMPNAME.Text = SELECTDOC.Rows(0).Item("CMPNAME")
                TXTRANK.Text = SELECTDOC.Rows(0).Item("RANK")
                TXTMUINO.Text = SELECTDOC.Rows(0).Item("MUINO")
                CMBNAME_Validated(sender, e)
                AUTHOFROM.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("AUTHOFROM")).Date, "dd/MM/yyyy")
                AUTHOTILL.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("AUTHOTO")).Date, "dd/MM/yyyy")
                ILLNESSFROM.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("ILLFROM")).Date, "dd/MM/yyyy")
                ILLNESSTILL.Value = Format(Convert.ToDateTime(SELECTDOC.Rows(0).Item("ILLTO")).Date, "dd/MM/yyyy")


                TXTACNAME.Text = SELECTDOC.Rows(0).Item("ACNAME")
                TXTACNO.Text = SELECTDOC.Rows(0).Item("ACNO")
                TXTBANK.Text = SELECTDOC.Rows(0).Item("BANK")
                TXTBRANCH.Text = SELECTDOC.Rows(0).Item("BRANCH")
                TXTBANKADD.Text = SELECTDOC.Rows(0).Item("BANKADD")
                TXTIFSCCODE.Text = SELECTDOC.Rows(0).Item("IFSCCODE")


                CMBCATEGORY.Text = SELECTDOC.Rows(0).Item("CATEGORY")
                CMBPATIENT.Text = SELECTDOC.Rows(0).Item("FAMILY")
                TXTRELATION.Text = SELECTDOC.Rows(0).Item("RELATION")
                TXTDIAGNOSIS.Text = SELECTDOC.Rows(0).Item("DIAGNOSIS")
                TXTHOSPNAME.Text = SELECTDOC.Rows(0).Item("HOSPNAME")
                TXTHOSPADD.Text = SELECTDOC.Rows(0).Item("HOSPADD")
                TXTDRNAME.Text = SELECTDOC.Rows(0).Item("DRNAME")
                CMBVESSEL.Text = SELECTDOC.Rows(0).Item("VESSEL")

                Dim objclsCMST As New ClsCommonMaster
                Dim DT As DataTable = objclsCMST.search(" T.CATEGORY, T.charges, (T.claim - ISNULL(MEDCLAIMSETTLEMENT_DESC.SETTLE_AMT,0)) AS CLAIM, T.register, T.MAXVAL", "", "  (SELECT CATEGORYMASTER.CATEGORY_NAME AS CATEGORY, CHARGESMASTER.CHARGES_NAME AS charges, MEDCLAIMREQ_DESC.REQ_CLAIMED AS claim, REGISTERMASTER.register_name AS register, ISNULL(MEDCLAIMREQ_DESC.REQ_MAX, 0) AS MAXVAL, MEDCLAIMREQ_DESC.REQ_NO, MEDCLAIMREQ_DESC.REQ_CMPID, MEDCLAIMREQ_DESC.REQ_LOCATIONID, MEDCLAIMREQ_DESC.REQ_YEARID, ISNULL(MEDCLAIMSETTLEMENT.SETTLE_NO,0) AS SETTLE_NO, CHARGESMASTER.CHARGES_ID, MEDCLAIMREQ_DESC.REQ_GRIDSRNO AS GRIDSRNO FROM MEDCLAIMREQ_DESC LEFT OUTER JOIN CATEGORYMASTER ON MEDCLAIMREQ_DESC.REQ_CATEGORYID = CATEGORYMASTER.CATEGORY_ID AND MEDCLAIMREQ_DESC.REQ_CMPID = CATEGORYMASTER.CATEGORY_CMPID AND MEDCLAIMREQ_DESC.REQ_LOCATIONID = CATEGORYMASTER.CATEGORY_LOCATIONID AND MEDCLAIMREQ_DESC.REQ_YEARID = CATEGORYMASTER.CATEGORY_YEARID LEFT OUTER JOIN CHARGESMASTER ON MEDCLAIMREQ_DESC.REQ_CHARGESID = CHARGESMASTER.CHARGES_ID AND MEDCLAIMREQ_DESC.REQ_CMPID = CHARGESMASTER.CHARGES_CMPID AND MEDCLAIMREQ_DESC.REQ_LOCATIONID = CHARGESMASTER.CHARGES_LOCATIONID AND MEDCLAIMREQ_DESC.REQ_YEARID = CHARGESMASTER.CHARGES_YEARID LEFT OUTER JOIN MEDCLAIMSETTLEMENT ON MEDCLAIMREQ_DESC.REQ_NO = MEDCLAIMSETTLEMENT.SETTLE_REQNO AND MEDCLAIMREQ_DESC.REQ_CMPID = MEDCLAIMSETTLEMENT.SETTLE_CMPID AND MEDCLAIMREQ_DESC.REQ_LOCATIONID = MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID AND MEDCLAIMREQ_DESC.REQ_YEARID = MEDCLAIMSETTLEMENT.SETTLE_YEARID LEFT OUTER JOIN REGISTERMASTER ON CATEGORYMASTER.CATEGORY_REGISTERID = REGISTERMASTER.register_id AND CATEGORYMASTER.CATEGORY_CMPID = REGISTERMASTER.register_cmpid AND CATEGORYMASTER.CATEGORY_LOCATIONID = REGISTERMASTER.register_locationid AND CategoryMaster.CATEGORY_YEARID = RegisterMaster.register_yearid WHERE dbo.MEDCLAIMREQ_DESC.REQ_NO=" & SELECTDOC.Rows(0).Item("REQNO") & " and dbo.MEDCLAIMREQ_DESC.REQ_CMPID=" & CmpId & " and dbo.MEDCLAIMREQ_DESC.REQ_locationid=" & Locationid & " and dbo.MEDCLAIMREQ_DESC.REQ_yearid=" & YearId & ") AS T LEFT OUTER JOIN MEDCLAIMSETTLEMENT_DESC ON T.REQ_CMPID = MEDCLAIMSETTLEMENT_DESC.SETTLE_CMPID AND T.REQ_LOCATIONID = MEDCLAIMSETTLEMENT_DESC.SETTLE_LOCATIONID AND T.REQ_YEARID = MEDCLAIMSETTLEMENT_DESC.SETTLE_YEARID AND T.CHARGES_ID = MEDCLAIMSETTLEMENT_DESC.SETTLE_CHARGESID AND T.SETTLE_NO = MEDCLAIMSETTLEMENT_DESC.SETTLE_NO ", " ORDER BY T.GRIDSRNO ")
                If DT.Rows.Count > 0 Then
                    cmbregister.Text = DT.Rows(0).Item("register")
                    For i = 0 To DT.Rows.Count - 1
                        GRIDDETAILS.Rows.Add(i + 1, DT.Rows(i).Item("charges"), DT.Rows(i).Item("claim"), 0.0, Val(DT.Rows(i).Item("MAXVAL")))
                    Next
                    TOTAL()
                End If
                GETEDUSUPP()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub MedicalClaimSETTLEMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
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
            Dim OBJMEDDTLS As New MedClaimSettlementDetails
            OBJMEDDTLS.MdiParent = MDIMain
            OBJMEDDTLS.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedicalClaimSETTLEment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MED CLAIM REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillregister(cmbregister, " and register_type = 'MEDICAL'")
            clear()
            FILLCMB()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCLAIM As New ClsMedClaimsettlement()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPSETTLENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCLAIM.alParaval = ALPARAVAL
                dt = OBJCLAIM.SELECTCLAIM()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        FRMSTRING = Convert.ToString(dr("FRMSTRING"))
                        GETEDUSUPP()


                        cmbregister.Text = Convert.ToString(dr("REGISTERNAME"))
                        txtsettleno.Text = TEMPSETTLENO
                        SETTLEDATE.Value = Convert.ToDateTime(dr("SETTLEDATE")).Date

                        TXTREQNO.Text = Val(dr("REQNO"))
                        TEMPREQNO = Val(dr("REQNO"))
                        TXTREQNO.ReadOnly = True
                        REQDATE.Value = Convert.ToDateTime(dr("REQDATE")).Date

                        TXTINWARDNO.Text = dr("INWARDNO")
                        CMDSELECTDOC.Enabled = False
                        TXTSENTBY.Text = dr("SENTBY")
                        RECDATE.Value = Convert.ToDateTime(dr("RECDATE")).Date

                        CMDSELECTREQ.Enabled = False


                        CMBNAME.Text = dr("NAME")
                        CMBNAME.Enabled = False
                        TXTCMPNAME.Text = dr("CMPNAME")
                        TXTRANK.Text = dr("RANK")
                        TXTEMPCODE.Text = dr("EMPCODE")
                        TXTMUINO.Text = dr("MUINO")
                        DOJ.Value = Convert.ToDateTime(dr("DOJ")).Date
                        AUTHOFROM.Value = Convert.ToDateTime(dr("AUTHOFROM")).Date
                        AUTHOTILL.Value = Convert.ToDateTime(dr("AUTHOTO")).Date

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

                        TXTAMTPAID.Text = dr("AMTPAID")
                        TXTEXTRAAMT.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("RETURN")
                        TXTBALANCE.Text = dr("BALANCE")

                        CHKVERIFIED.Checked = Convert.ToBoolean(dr("VERIFIED"))

                        If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


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
                        GRIDDETAILS.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("CLAIMED")), "0.00"), Format(Val(dr("SETTLEAMT")), "0.00"), Format(Val(dr("MAXAMT")), "0.00"))
                        If Convert.ToBoolean(dr("SENDWHATSAPP")) = True Then LBLWHATSAPP.Visible = True
                    Next

                    'CHECK WHETHER CORRESPONDENCE IS DONE OR NOT 
                    'IF DONE THE SHOW LABEL
                    'WE HAVE REMOVED YEARID CLAUSE AS WE WANT CORRESPONDENCE LOCK ON LOAD, IF WE HAVE FETCHED REQ NO FROM LAST YEAR, 
                    'AND CORRE Is DONE IN LAST YEAR, DONE BY GULKIT
                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search("CORRES_NO AS CORRESNO", "", " CORRESPONDENCE ", " AND CORRES_TYPE = 'MEDICAL' AND CORRES_REQNO = " & TEMPREQNO)
                    If dt.Rows.Count > 0 Then
                        PBCORR.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    cmbregister.Enabled = False
                    TOTAL()
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
            If Not ERRORVALID() Then
                Exit Sub
            End If

            getsrno()

            Dim alParaval As New ArrayList

            alParaval.Add(FRMSTRING)
            alParaval.Add(Format(SETTLEDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(TXTREQNO.Text.Trim)
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
            alParaval.Add(Val(TXTTOTALAMT.Text.Trim))
            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim CHARGES As String = ""
            Dim CLAIMED As String = ""
            Dim amt As String = ""
            Dim MAX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDETAILS.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = row.Cells(GCHARGES.Index).Value
                        CLAIMED = row.Cells(GCLAIMAMT.Index).Value.ToString
                        amt = row.Cells(GSETTLEAMT.Index).Value
                        MAX = row.Cells(gmax.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = CHARGES & "," & row.Cells(GCHARGES.Index).Value
                        CLAIMED = CLAIMED & "," & row.Cells(GCLAIMAMT.Index).Value.ToString
                        amt = amt & "," & row.Cells(GSETTLEAMT.Index).Value
                        MAX = MAX & "," & row.Cells(gmax.Index).Value

                    End If
                End If
            Next


            alParaval.Add(CMBCATEGORY.Text.Trim)
            alParaval.Add(GRIDSRNO)
            alParaval.Add(CHARGES)
            alParaval.Add(CLAIMED)
            alParaval.Add(amt)
            alParaval.Add(MAX)

            alParaval.Add(Val(TXTAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBALANCE.Text.Trim))

            alParaval.Add(CHKVERIFIED.Checked)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJSETTLE As New ClsMedClaimsettlement
            OBJSETTLE.alParaval = alParaval
            Dim DT As DataTable

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJSETTLE.SAVE()
                MessageBox.Show("Details Added")
                If Val(TXTTOTALAMT.Text.Trim) > 0 Then
                    Dim TEMPMSG As Integer = MsgBox("Print Approval Letter?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then PRINTREPORT(DT.Rows(0).Item(0))
                End If

            Else
                    If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSETTLENO)
                DT = OBJSETTLE.UPDATE()
                MsgBox("Details Updated")
                If Val(TXTTOTALAMT.Text.Trim) > 0 Then
                    Dim TEMPMSG As Integer = MsgBox("Print Approval Letter?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then PRINTREPORT(TEMPSETTLENO)
                End If
            End If

            clear()
            EDIT = False
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Claim Closed, Claim Locked")
            bln = False
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

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
        '    EP.SetError(TXTTOTALAMT, "Enter Settlement Amt")
        '    bln = False
        'End If


        Dim OBJCMN As New ClsCommon
        If Val(TXTINWARDNO.Text.Trim) > 0 And EDIT = False Then
            'CHECKING WHETHER INWARD NO IS LOCKED OR NOT
            Dim DT As DataTable = OBJCMN.search(" DOCIN_DONE ", "", " DOCUMENTINWARD", " AND DOCIN_NO = " & Val(TXTINWARDNO.Text.Trim) & " AND DOCIN_CMPID = " & CmpId & " AND DOCIN_LOCATIONID = " & Locationid & " AND DOCIN_YEARID = " & YearId)
            If Convert.ToBoolean(DT.Rows(0).Item(0)) = True Then
                EP.SetError(TXTINWARDNO, "Inward No Locked")
                bln = False
            End If
        End If


        If TXTREQNO.Text <> "" And EDIT = False And FRMSTRING <> "MEDSUPP" Then
            Dim dttable As DataTable = OBJCMN.search(" ISNULL(MEDCLAIMSETTLEMENT.SETTLE_REQNO,0)  AS REQNO", "", " MEDCLAIMSETTLEMENT ", "  AND MEDCLAIMSETTLEMENT.SETTLE_REQNO=" & TXTREQNO.Text.Trim & " AND MEDCLAIMSETTLEMENT.SETTLE_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                EP.SetError(TXTREQNO, "Request No Already Exist")
                bln = False
            End If
        End If


        'CHECKING MAXVAL
        For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
            'GET MAXALLOWED FROM CATEGORY CONFIG
            'COZ MANY TIMES IT CREATES ERROR HERE
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CATEGORYCONFIG.CATEGORY_MAX, 0) AS CHARGESMAX, ISNULL(CATEGORYCONFIG.CATEGORY_MAXCATEGORY, 0) AS OVERALLMAX ", "", " CATEGORYCONFIG INNER JOIN CATEGORYMASTER ON CATEGORYCONFIG.CATEGORY_ID = CATEGORYMASTER.CATEGORY_ID INNER JOIN CHARGESMASTER ON CATEGORYCONFIG.CATEGORY_CHARGESID = CHARGESMASTER.CHARGES_ID ", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND CHARGESMASTER.CHARGES_NAME = '" & ROW.Cells(GCHARGES.Index).Value & "' AND CATEGORYCONFIG.CATEGORY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows(0).Item("CHARGESMAX")) > 0 And (Val(DT.Rows(0).Item("CHARGESMAX")) < Val(ROW.Cells(GSETTLEAMT.Index).Value)) Then
                    EP.SetError(TXTTOTALAMT, "Amt Exceeds Max Allowed")
                    bln = False
                End If
            End If
        Next


        If Val(TXTTOTALAMT.Text.Trim) > Val(TXTCLAIMED.Text.Trim) Then
            EP.SetError(TXTTOTALAMT, "Amt Exceeds Claimed Amount")
            bln = False
        End If


        Return bln

    End Function

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDDETAILS.RowCount = 0
LINE1:
            TEMPSETTLENO = Val(txtsettleno.Text) + 1
            GETMAXNO_SETTLENO()
            Dim MAXNO As Integer = txtsettleno.Text.Trim
            clear()
            If Val(txtsettleno.Text) - 1 >= TEMPSETTLENO Then
                EDIT = True
                MedicalClaimSETTLEment_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDDETAILS.RowCount = 0 And TEMPSETTLENO < MAXNO Then
                txtsettleno.Text = TEMPSETTLENO
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
            TEMPSETTLENO = Val(txtsettleno.Text) - 1
            If TEMPSETTLENO > 0 Then
                EDIT = True
                MedicalClaimSETTLEment_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDDETAILS.RowCount = 0 And TEMPSETTLENO > 1 Then
                txtsettleno.Text = TEMPSETTLENO
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
            If EDIT = False Then
                MsgBox("Delete Allowed for Saved Settlements only", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Then
                MsgBox("Settlement Locked, Delete not Allowed", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If LBLCLOSED.Visible = True Then
                MsgBox("Settlement Closed, Delete not Allowed", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            Dim ALPARAVAL As New ArrayList
            Dim OBJMED As New ClsMedClaimsettlement
            ALPARAVAL.Add(TEMPSETTLENO)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)
            OBJMED.alParaval = ALPARAVAL

            Dim DT As DataTable = OBJMED.DELETE
            If DT.Rows.Count > 0 Then MsgBox(DT.Rows(0).Item(0))
            EDIT = False
            clear()
            cmbregister.Enabled = True
            cmbregister.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDDETAILS.RowCount = 0
            TEMPSETTLENO = Val(tstxtbillno.Text)
            TEMPREG = cmbregister.Text.Trim
            If TEMPSETTLENO > 0 Then
                EDIT = True
                MedicalClaimSETTLEment_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDDETAILS.CellValidating
        Try
            Dim colNum As Integer = GRIDDETAILS.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GSETTLEAMT.Index, GCLAIMAMT.Index
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
            TXTTOTALAMT.Clear()
            For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
                ROW.Cells(GSETTLEAMT.Index).Value = Convert.ToDecimal(Val(ROW.Cells(GSETTLEAMT.Index).EditedFormattedValue))
                TXTCLAIMED.Text = Format(Val(TXTCLAIMED.Text.Trim) + Val(ROW.Cells(GCLAIMAMT.Index).Value), "0.00")
                TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(ROW.Cells(GSETTLEAMT.Index).Value), "0.00")
            Next

            If Val(TXTTOTALAMT.Text.Trim) > 0 Then txtinwords.Text = CurrencyToWord(Val(TXTTOTALAMT.Text.Trim))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'MEDICAL'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'MEDICAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            GETMAXNO_SETTLENO()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'MEDICAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    GETMAXNO_SETTLENO()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CATEGORYCONFIG.CATEGORY_GRIDSRNO AS GRIDSRNO, CHARGESMASTER.CHARGES_NAME AS CHARGES, CATEGORYCONFIG.CATEGORY_MAX AS MAX, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS REGNAME", "", " CATEGORYCONFIG INNER JOIN CATEGORYMASTER ON CATEGORYCONFIG.CATEGORY_ID = CATEGORYMASTER.CATEGORY_ID AND CATEGORYCONFIG.CATEGORY_YEARID = CATEGORYMASTER.CATEGORY_YEARID INNER JOIN CHARGESMASTER ON CATEGORYCONFIG.CATEGORY_CHARGESID = CHARGESMASTER.CHARGES_ID LEFT OUTER JOIN REGISTERMASTER ON CATEGORYMASTER.CATEGORY_REGISTERID = REGISTERMASTER.REGISTER_ID", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND CATEGORYCONFIG.CATEGORY_CMPID = " & CmpId & " AND CATEGORYCONFIG.CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORYCONFIG.CATEGORY_YEARID = " & YearId & " ORDER BY CATEGORYCONFIG.CATEGORY_GRIDSRNO")
            If DT.Rows.Count > 0 Then
                cmbregister.Text = DT.Rows(0).Item("REGNAME")
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
                    GRIDDETAILS.Rows.Add(ROW("GRIDSRNO"), ROW("CHARGES"), 0, 0, ROW("MAX"))
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

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Close Req?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are You sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim OBJREQ As New ClsMedClaimsettlement
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPSETTLENO)
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

    Private Sub GRIDDETAILS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDETAILS.Enter
        Try
            If GRIDDETAILS.RowCount > 0 Then GRIDDETAILS.Rows(0).Cells(GSETTLEAMT.Index).Selected = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If EDIT = True Then
                If PBPAID.Visible = True Then
                    Dim OBJPAY As New ShowRecPay
                    OBJPAY.MdiParent = MDIMain

                    'GETTING INITIALS
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" SETTLE_INITIALS AS INITIALS ", "", " MEDCLAIMSETTLEMENT", " AND SETTLE_NO = " & TEMPSETTLENO & " AND SETTLE_CMPID = " & CmpId & " AND SETTLE_LOCATIONID = " & Locationid & " AND SETTLE_YEARID = " & YearId)
                    OBJPAY.PURBILLINITIALS = DT.Rows(0).Item(0)
                    OBJPAY.SALEBILLINITIALS = DT.Rows(0).Item(0)
                    OBJPAY.Show()
                End If

                If PBCORR.Visible = True Then
                    Dim OBJCOR As New ShowCorrespondence
                    OBJCOR.FRMSTRING = "MEDICAL"
                    OBJCOR.REQNO = TEMPREQNO
                    OBJCOR.MdiParent = MDIMain
                    OBJCOR.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPSETTLENO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SETTLENO As Integer)
        Try
            Dim OBJCLAIM As New ClaimDesign
            OBJCLAIM.MdiParent = MDIMain
            OBJCLAIM.FRMSTRING = "MEDICAL"
            OBJCLAIM.SETTLENO = SETTLENO
            OBJCLAIM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSEARCHREQNO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSEARCHREQNO.Validated
        Try
            If Val(TXTSEARCHREQNO.Text.Trim) > 0 Then
                'GET SETTLEMENTNO FIRST
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("SETTLE_NO AS SETTLENO", "", "MEDCLAIMSETTLEMENT", " AND SETTLE_REQNO = " & Val(TXTSEARCHREQNO.Text.Trim) & " AND SETTLE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    tstxtbillno.Text = DT.Rows(0).Item("SETTLENO")

                    GRIDDETAILS.RowCount = 0
                    TEMPSETTLENO = Val(tstxtbillno.Text)
                    TEMPREG = cmbregister.Text.Trim
                    If TEMPSETTLENO > 0 Then
                        EDIT = True
                        MedicalClaimSETTLEment_Load(sender, e)
                    Else
                        clear()
                        EDIT = False
                    End If
                Else
                    MsgBox("Invalid Req No", MsgBoxStyle.Critical)
                    TXTSEARCHREQNO.Clear()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, EDIT, " AND OFFICER_INDIAN = 'TRUE'")
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
                    TXTCMPNAME.Text = DT.Rows(0).Item("COMPANY")
                    TXTRANK.Text = DT.Rows(0).Item("RANK")
                    TXTMUINO.Text = DT.Rows(0).Item("MUINO")
                    DOJ.Value = Format(DT.Rows(0).Item("DOJ"), "dd/MM/yyyy")
                    TXTEMPCODE.Text = DT.Rows(0).Item("EMPCODE")
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

    Private Sub CMDSELECTDOC_Click(sender As Object, e As EventArgs) Handles CMDSELECTDOC.Click
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

    Private Sub TXTACNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTACNAME.Validated
        pcase(TXTACNAME)
    End Sub

    Private Sub CORRES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORRES.Click
        Try
            If EDIT = True Then

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

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If EDIT = False And TXTCOPY.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Request No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJCLAIM As New ClsMedClaimsettlement

                    'GET SETTLEMENTNO OF REQUEST AND THEN PASS
                    Dim OBJCMN As New ClsCommon
                    Dim DTS As DataTable = OBJCMN.search(" ISNULL(SETTLE_NO,0) AS SETTLENO ", "", " MEDCLAIMSETTLEMENT ", " AND SETTLE_REQNO = " & Val(TXTCOPY.Text.Trim) & " AND SETTLE_YEARID = " & YearId)

                    ALPARAVAL.Add(Val(DTS.Rows(0).Item("SETTLENO")))
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

                            GRIDDETAILS.Rows.Add(dr("GRIDSRNO"), dr("CHARGES"), Format(Val(dr("CLAIMED")), "0.00"), 0, Format(Val(dr("MAXAMT")), "0.00"))
                        Next
                        TOTAL()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVESSEL_Enter(sender As Object, e As EventArgs) Handles CMBVESSEL.Enter
        Try
            If CMBVESSEL.Text.Trim = "" Then FILLVESSEL(CMBVESSEL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREGWHATSAPP_Click(sender As Object, e As EventArgs) Handles CMDREGWHATSAPP.Click
        Try
            Dim DT As New DataTable
            Dim OBJBOOK As New ClsCommon

            If EDIT = True Then SENDWHATSAPP(Val(TXTREQNO.Text.Trim), "Dear Sir,
We hereby acknowledge the receipt of your Medical Reimbursement Claim on " & SETTLEDATE.Text & ", which has been duly registered under Claim No: " & Val(TXTREQNO.Text.Trim) & ". Our dedicated team will commence the processing of your claim promptly. If all necessary documents are found to be in order, your claim will be reimbursed within 45 working days. If any additional documentation be required for the expeditious settlement of your claim, we will communicate the same to you.
If you have any further query please feel free to reach out for assistance on our Email mail@mnowf.com or Telephone No:022 49680968 Mob No: +918828326202
Thank you for your prompt submission.

Regards,
The Merchant Navy Officers’ Welfare Fund")

            DT = OBJBOOK.Execute_Any_String("UPDATE MEDCLAIMSETTLEMENT SET SETTLE_SENDWHATSAPP = 1 FROM MEDCLAIMSETTLEMENT INNER JOIN REGISTERMASTER On MEDCLAIMSETTLEMENT.SETTLE_REGID = REGISTERMASTER.register_id WHERE SETTLE_NO = " & TEMPSETTLENO & " AND REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "'  AND SETTLE_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSETTLEWHATSAPP_Click(sender As Object, e As EventArgs) Handles CMDSETTLEWHATSAPP.Click
        Try
            Dim DT As New DataTable
            Dim OBJBOOK As New ClsCommon

            If EDIT = True Then SENDWHATSAPP(Val(TXTREQNO.Text.Trim), "Dear Sir,
In process of reviewing your Medical Reimbursement Claim No: " & Val(TXTREQNO.Text.Trim) & ". We have found your documents in order and your claim has been approved for Rs " & Val(TXTTOTALAMT.Text.Trim) & ".

Once we initiated payment with the bank we will inform you accordingly.

If you have any further query please feel free to reach out for assistance on our Email mail@mnowf.com or Telephone No: 022 22619321/022 49680968.

Regards,
The Merchant Navy Officers’ Welfare Fund")

            DT = OBJBOOK.Execute_Any_String("UPDATE MEDCLAIMSETTLEMENT SET SETTLE_SENDWHATSAPP = 1 FROM MEDCLAIMSETTLEMENT INNER JOIN REGISTERMASTER On MEDCLAIMSETTLEMENT.SETTLE_REGID = REGISTERMASTER.register_id WHERE SETTLE_NO = " & TEMPSETTLENO & " AND REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "'  AND SETTLE_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(TEMPSETTLENO As Integer, MESSAGE As String)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech On 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.OFFICERNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.MSG = MESSAGE
            OBJWHATSAPP.ShowDialog()

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

    Private Sub TXTREQNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTREQNO.Validating
        Try
            If FRMSTRING = "MEDSUPP" Then Exit Sub
            If (Val(TXTREQNO.Text.Trim) <> 0 And EDIT = False) Or (EDIT = True And TEMPREQNO <> Val(TXTREQNO.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(MEDCLAIMSETTLEMENT.SETTLE_REQNO,0)  AS REQNO", "", " MEDCLAIMSETTLEMENT ", "  AND MEDCLAIMSETTLEMENT.SETTLE_REQNO=" & TXTREQNO.Text.Trim & " AND MEDCLAIMSETTLEMENT.SETTLE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Request No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREQNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTREQNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class