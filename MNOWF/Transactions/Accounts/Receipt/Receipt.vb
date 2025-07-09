
Imports BL
Imports System.Windows.Forms

Public Class Receipt

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDDESCDOUBLECLICK As Boolean
    Public edit As Boolean
    Public TEMPRECEIPTNO As Integer
    Public TEMPREGNAME As String
    Dim recregabbr, recreginitial As String
    Dim recregid As Integer
    Dim temprow, TEMPDESCROW As Integer
    Dim temprecodate As Date
    Dim CHQNO As String = ""
    Public Shared SELECTEDBILLNO As String

    'REQD FOR AUTO DATA POPULATION AS PER ELYSIUM'S REQUIREMENT
    Public TEMPAUTOENTRY As Boolean = False
    Public TEMPAMT As Double
    Public TEMPNAME As String
    Public TEMPACCNAME As String
    Public TEMPBANKNAME As String
    Public TEMPCHQNAME As String
    Public TEMPBILLNO As String



    'FOR ADDING NEW CHKCOL IN GRIDBILL
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Sub clear()

        'clearing textboxes
        EP.Clear()
        tstxtbillno.Clear()
        lblbilltotal.Text = ""
        cmbname.Text = ""
        cmbname.Enabled = True
        cmbaccname.Text = ""
        CMBCATEGORYLEDGER.Text = ""
        txtchqamt.Clear()
        txtchqno.Clear()
        txtcramt.Clear()
        txtledgerbal.Clear()
        txtchqbal.Clear()
        lblbaldrcr.Text = ""
        tstxtbillno.Clear()
        txtbillno.Clear()
        chkselectall.Checked = False
        TXTINVTOTAL.Clear()
        txttotal.Clear()
        txtdesctotal.Clear()
        txtremarks.Clear()
        txtinwords.Clear()
        txtsrno.Clear()
        cmbpaytype.SelectedIndex = 0
        txtamt.Clear()
        cmbbillno.Text = ""
        txtnarr.Clear()
        cmbbillno.Items.Clear()
        cmbbillno.Enabled = False
        txtsrno.Clear()

        CHKRECO.CheckState = CheckState.Unchecked
        RECODATE.Value = Mydate

        LBLRECO.Visible = False
        RECODATE.Visible = False
        CMDRECO.Visible = False

        txtdescsrno.Clear()
        cmbledgername.Text = ""
        txtdescnarr.Clear()
        txtdescamt.Clear()

        TXTBANKNAME.Clear()

        recregabbr = ""
        recreginitial = ""

        gridbill.DataSource = Nothing
        gridpayment.RowCount = 0

        Gbdesc.Enabled = False
        gridpaydesc.RowCount = 0
        gridpayment.RowCount = 0
        GRIDDESC.RowCount = 0
        getmaxno_receiptmaster()

        'accdate.Value = Mydate
        edit = False
        GRIDDOUBLECLICK = False
        GRIDDESCDOUBLECLICK = False

        lbllocked.Visible = False
        PBlock.Visible = False

    End Sub

    Sub getmaxno_receiptmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(RECEIPT_NO),0) + 1 ", "RECEIPTMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = RECEIPT_REGISTERID AND REGISTER_CMPID = RECEIPT_CMPID AND REGISTER_LOCATIONID = RECEIPT_LOCATIONID AND REGISTER_YEARID = RECEIPT_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'RECEIPT' AND RECEIPT_cmpid=" & CmpId & " AND RECEIPT_LOCATIONid=" & Locationid & " AND RECEIPT_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtaccno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and groupmaster.group_SECONDARY = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " And acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.GotFocus
        txtamt.SelectAll()
    End Sub

    Private Sub txtinwords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinwords.GotFocus
        txtinwords.SelectAll()
    End Sub

    Private Sub txttotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.GotFocus
        txttotal.SelectAll()
    End Sub

    Private Sub txtaccno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaccno.GotFocus
        txtaccno.SelectAll()
    End Sub

    Private Sub txtremarks_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.GotFocus
        txtremarks.SelectAll()
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        numdotkeypress(e, txtamt, Me)
    End Sub

    Private Sub txttotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        numdotkeypress(e, txttotal, Me)
    End Sub

    Private Sub txtremarks_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.Validated
        'pcase(txtremarks)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If lbllocked.Visible = True And UserName <> "Admin" Then
                EP.SetError(lbllocked, "Reco Done, Receipt Locked")
                BLN = False
            End If

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Select Register Name")
                BLN = False
            End If

            If CMBCATEGORYLEDGER.Text.Trim.Length = 0 Then
                EP.SetError(CMBCATEGORYLEDGER, "Select Ledger Name")
                BLN = False
            End If

            'If cmbname.Text.Trim.Length = 0 Then
            '    EP.SetError(cmbname, "Select Name")
            '    BLN = False
            'End If

            If cmbaccname.Text.Trim.Length = 0 Then
                EP.SetError(cmbaccname, "Select Account Name")
                BLN = False
            End If

            If gridpayment.RowCount = 0 Then
                EP.SetError(txtchqno, "Enter Receipt Details")
                BLN = False
            End If

            If chkchange.CheckState = CheckState.Unchecked Then
                EP.SetError(txtchqno, "Enter Receipt Details")
                BLN = False
            End If

            If txtchqamt.Text.Trim.Length = 0 Then
                EP.SetError(txtchqamt, "Enter Specified Amt")
                BLN = False
            End If

            If Val(txtchqamt.Text.Trim) <> Val(txttotal.Text.Trim) Then
                EP.SetError(txttotal, "Total does not match Specified Amt")
                BLN = False
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Bank A/C" Or DT.Rows(0).Item(0) = "Bank OD A/C" Then
                    'DONT MANDATE CHQ NO AS THERE ARE RTGS ENTRIES AS WELL
                    'If txtchqno.Text.Trim.Length = 0 Then
                    '    EP.SetError(txtchqno, "Enter Chq No.")
                    '    BLN = False
                    'End If
                    If txtchqno.Text.Trim.Length = 0 Then
                        Dim TEMPMSG As Integer = MsgBox("Chq No. is Blank, Proceed?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbNo Then
                            EP.SetError(txtchqno, "Enter Chq No.")
                            BLN = False
                        End If
                    End If
                ElseIf DT.Rows(0).Item(0) = "Cash In Hand" Then
                    txtchqno.Clear()
                End If
            End If



            If Not datecheck(accdate.Value) Then
                EP.SetError(accdate, "Date Not in Current Accounting Year")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Receipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            Call ToolStripdelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F1 Then
            tstxtbillno.Focus()
        ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
            Call toolprevious_Click(sender, e)
        ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
            Call toolnext_Click(sender, e)
        End If
    End Sub

    Private Sub Receipt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub CMBCATEGORYLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORYLEDGER.Validating
        Try
            If CMBCATEGORYLEDGER.Text.Trim <> "" Then ledgervalidate(CMBCATEGORYLEDGER, CMBACCCODE, e, Me, txtadd, " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Receipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'RECEIPT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            getmaxno_receiptmaster()
            
            'GET DEFAULT BANK (FIRST ADD A NEW COLUMN OF DEFAULT IN ALL MASTERS AND IN LEDGERS VIEW)
            'Dim objcommon As New ClsCommonMaster
            'Dim dt As New DataTable
            'dt = objcommon.search(" acc_cmpname", "", " ledgers", " and acc_default = true and acc_cmpid = " & CmpId)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCLRECEIPT As New ClsReceiptMaster()
                dt = OBJCLRECEIPT.selectbill_edit(TEMPRECEIPTNO, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then

                    gridpayment.RowCount = 0
                    gridpaydesc.RowCount = 0
                    GRIDDESC.RowCount = 0

                    For Each dr As DataRow In dt.Rows

                        txtaccno.Text = TEMPRECEIPTNO
                        cmbregister.Text = Convert.ToString(dr("REGISTERNAME"))
                        accdate.Value = Convert.ToDateTime(dr("ACCDATE"))
                        cmbaccname.Text = Convert.ToString(dr("ACCNAME"))
                        CMBCATEGORYLEDGER.Text = Convert.ToString(dr("CATEGORYLEDGER"))
                        cmbname.Text = Convert.ToString(dr("LEDGERNAME"))
                        TXTBANKNAME.Text = Convert.ToString(dr("BANKNAME"))

                        txtchqamt.Text = Convert.ToString(Format(dr("CHQAMT"), "0.00"))
                        txtchqno.Text = Convert.ToString(dr("CHQNO"))
                        CHQNO = txtchqno.Text
                        TXTYEAR.Text = dr("YEAR")
                        txtremarks.Text = Convert.ToString(dr("remarks"))

                        If dr("RECODATE") = "" Then
                            CHKRECO.CheckState = CheckState.Unchecked

                            LBLRECO.Visible = False
                            RECODATE.Visible = False
                            CMDRECO.Visible = False

                            lbllocked.Visible = False
                            PBlock.Visible = False

                        Else
                            CHKRECO.CheckState = CheckState.Checked
                            Dim MYSTR As String = dr("RECODATE")
                            If dr("RECODATE").ToString.Substring(2, 1) = "/" Then
                                MYSTR = dr("RECODATE").ToString.Substring(3, 2) & "-" & dr("RECODATE").ToString.Substring(0, 2) & "-" & dr("RECODATE").ToString.Substring(6, 4)
                                RECODATE.Value = Format(Convert.ToDateTime(MYSTR).Date, "dd/MM/yyyy")
                            Else
                                RECODATE.Value = Format(Convert.ToDateTime(dr("RECODATE")).Date, "dd/MM/yyyy")
                            End If

                            lbllocked.Visible = True
                            PBlock.Visible = True

                            LBLRECO.Visible = True
                            RECODATE.Visible = True
                            CMDRECO.Visible = True

                        End If

                        gridpayment.Rows.Add(0, dr("GRIDSRNO"), dr("PAYTYPE").ToString, dr("BILLINITIALS").ToString, dr("NARR").ToString, Format(dr("AMT"), "0.00"))
                    Next

                    Dim OBJCMN As New ClsCommon
                    Dim DT1 As DataTable = OBJCMN.search(" RECEIPTMASTER_GRIDDESC.RECEIPT_DESCGRIDSRNO AS DESCGRIDSRNO, LEDGERS.Acc_cmpname AS DESCLEDGERNAME, RECEIPTMASTER_GRIDDESC.RECEIPT_DESCGRIDREMARKS AS DESCNARR, RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT AS DESCAMT, RECEIPTMASTER_GRIDDESC.RECEIPT_PAYGRIDSRNO AS PAYGRIDSRNO, RECEIPT_PAYBILLINITIALS AS PAYBILLINITIALS ", "", "  RECEIPTMASTER_GRIDDESC INNER JOIN LEDGERS ON RECEIPTMASTER_GRIDDESC.RECEIPT_DESCLEDGERID = LEDGERS.Acc_id AND RECEIPTMASTER_GRIDDESC.RECEIPT_CMPID = LEDGERS.Acc_cmpid AND RECEIPTMASTER_GRIDDESC.RECEIPT_LOCATIONID = LEDGERS.Acc_locationid AND RECEIPTMASTER_GRIDDESC.RECEIPT_YEARID = LEDGERS.Acc_yearid INNER JOIN REGISTERMASTER ON RECEIPTMASTER_GRIDDESC.RECEIPT_REGISTERID = REGISTERMASTER.register_id AND RECEIPTMASTER_GRIDDESC.RECEIPT_CMPID = REGISTERMASTER.register_cmpid AND RECEIPTMASTER_GRIDDESC.RECEIPT_LOCATIONID = REGISTERMASTER.register_locationid AND RECEIPTMASTER_GRIDDESC.RECEIPT_YEARID = REGISTERMASTER.register_yearid", " AND (RECEIPTMASTER_GRIDDESC.receipt_no = " & TEMPRECEIPTNO & ") AND (REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "') AND (RECEIPTMASTER_GRIDDESC.RECEIPT_cmpid = " & CmpId & ") AND (RECEIPTMASTER_GRIDDESC.RECEIPT_locationid = " & Locationid & ") AND (RECEIPTMASTER_GRIDDESC.RECEIPT_YEARid = " & YearId & ")")
                    For Each DR1 As DataRow In DT1.Rows
                        GRIDDESC.Rows.Add(DR1("DESCGRIDSRNO").ToString, DR1("DESCLEDGERNAME").ToString, DR1("DESCNARR").ToString, Format(DR1("DESCAMT"), "0.00"), DR1("PAYGRIDSRNO"), DR1("PAYBILLINITIALS").ToString)
                        gridpayment.Rows(DR1("PAYGRIDSRNO") - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    Next

                    'filling gridINVOICE
                    fillgridINVOICE()

                    cmbregister.Enabled = False
                    cmbname.Focus()
                    chkchange.CheckState = CheckState.Checked
                    total()
                End If
            End If
            gridpayment.ClearSelection()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then cmbname.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and Acc_YEARid = " & YearId)
            If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                fillgridINVOICE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(descgridsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getpaysrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gridsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            Dim DTTABLE As DataTable

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(cmbregister.Text.Trim)
            alparaval.Add(accdate.Value)
            alparaval.Add(cmbaccname.Text.Trim)
            alparaval.Add(CMBCATEGORYLEDGER.Text.Trim)
            alparaval.Add(cmbname.Text.Trim)
            alparaval.Add(Val(txtchqamt.Text))
            alparaval.Add(txtchqno.Text.Trim)
            alparaval.Add(txtremarks.Text.Trim)
            alparaval.Add(txtinwords.Text.Trim)

            If CHKRECO.CheckState = CheckState.Checked Then
                alparaval.Add(Format(RECODATE.Value.Date, "MM/dd/yyyy"))
            Else
                alparaval.Add("")
            End If

            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim pgridsrno As String = ""
            Dim paytype As String = ""
            Dim billINITIALS As String = ""
            Dim narr As String = ""
            Dim amt As String = ""

            Dim dgridsrno As String = ""
            Dim descledgername As String = ""
            Dim descnarration As String = ""
            Dim descamount As String = ""
            Dim DESCPAYGRIDSRNO As String = ""
            Dim DESCPAYBILLINITIALS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridpayment.Rows
                If row.Cells(gridsrno.Index).Value <> Nothing Then
                    If pgridsrno = "" Then

                        pgridsrno = row.Cells(gridsrno.Index).Value.ToString
                        paytype = row.Cells(gpaytype.Index).Value
                        billINITIALS = row.Cells(gbillno.Index).Value.ToString
                        narr = row.Cells(gdesc.Index).Value
                        amt = row.Cells(gamt.Index).Value
                    Else

                        pgridsrno = pgridsrno & "|" & row.Cells(gridsrno.Index).Value.ToString
                        paytype = paytype & "|" & row.Cells(gpaytype.Index).Value
                        billINITIALS = billINITIALS & "|" & row.Cells(gbillno.Index).Value.ToString
                        narr = narr & "|" & row.Cells(gdesc.Index).Value
                        amt = amt & "|" & row.Cells(gamt.Index).Value
                    End If
                End If
            Next


            For Each row As Windows.Forms.DataGridViewRow In GRIDDESC.Rows
                If row.Cells(descgridsrno.Index).Value <> Nothing Then
                    If dgridsrno = "" Then

                        dgridsrno = row.Cells(DSRNO.Index).Value.ToString
                        descledgername = row.Cells(DNAME.Index).Value
                        descnarration = row.Cells(DNARR.Index).Value
                        descamount = row.Cells(DAMT.Index).Value.ToString
                        DESCPAYGRIDSRNO = row.Cells(DPAYGRIDSRNO.Index).Value.ToString
                        DESCPAYBILLINITIALS = row.Cells(DPAYBILLINITIALS.Index).Value.ToString

                    Else

                        dgridsrno = dgridsrno & "|" & row.Cells(DSRNO.Index).Value.ToString
                        descledgername = descledgername & "|" & row.Cells(DNAME.Index).Value.ToString
                        descnarration = descnarration & "|" & row.Cells(DNARR.Index).Value
                        descamount = descamount & "|" & row.Cells(DAMT.Index).Value.ToString
                        DESCPAYGRIDSRNO = DESCPAYGRIDSRNO & "|" & row.Cells(DPAYGRIDSRNO.Index).Value.ToString
                        DESCPAYBILLINITIALS = DESCPAYBILLINITIALS & "|" & row.Cells(DPAYBILLINITIALS.Index).Value.ToString

                    End If
                End If
            Next


            alparaval.Add(pgridsrno)
            alparaval.Add(paytype)
            alparaval.Add(billINITIALS)
            alparaval.Add(narr)
            alparaval.Add(amt)

            alparaval.Add(dgridsrno)
            alparaval.Add(descledgername)
            alparaval.Add(descnarration)
            alparaval.Add(descamount)
            alparaval.Add(DESCPAYGRIDSRNO)
            alparaval.Add(DESCPAYBILLINITIALS)
            alparaval.Add(TXTBANKNAME.Text.Trim)
            alparaval.Add(TXTYEAR.Text.Trim)


            Dim OBJCLRECEIPT As New ClsReceiptMaster
            OBJCLRECEIPT.alParaval = alparaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJCLRECEIPT.save()
                MessageBox.Show("Details Added")
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPRECEIPTNO)
                Dim IntResult As Integer = OBJCLRECEIPT.update()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPRECEIPTNO)

            End If
            clear()
            edit = False
            accdate.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellClick
        Try
            If e.RowIndex >= 0 Then
                With gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVBALAMT").Index).Value

                        Dim A As System.ComponentModel.CancelEventArgs
                        txtamt_Validating(sender, A)

                    End If
                    total()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        TXTINVTOTAL.Text = 0.0
        txtdesctotal.Text = 0.0
        txttotal.Text = 0.0
        txtchqbal.Text = 0.0

        For Each row As DataGridViewRow In gridpayment.Rows
            txttotal.Text = Format(Val(txttotal.Text) + row.Cells(gamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridpaydesc.Rows
            txtdesctotal.Text = Format(Val(txtdesctotal.Text) + row.Cells(descamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridbill.Rows
            If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(gridbill.Columns("INVBALAMT").Index).Value, "0.00")
        Next

        If Val(txtchqamt.Text) <> 0 Then
            txtchqbal.Text = Format(Val(txtchqamt.Text) - Val(txttotal.Text), "0.00")
            txtinwords.Text = CurrencyToWord(txtchqamt.Text)
        End If

    End Sub

    Sub fillcmbbillno()
        If cmbbillno.Items.Count > 0 Then cmbbillno.Items.Clear()
        For Each row As DataGridViewRow In gridbill.Rows
            If Convert.ToBoolean(row.Cells(gridbill.Columns("INVCHK").Index).Value) = True Then
                cmbbillno.Items.Add(row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value.ToString())
            End If
        Next
        If cmbbillno.Items.Count > 0 Then cmbbillno.SelectedIndex = (0)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If edit = False Then
                If GRIDDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, temprow).Value)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If cmbpaytype.Text.Trim = "Against Bill" Then
                        Dim BALAMT As Double = 0
                        For Each ROW As DataGridViewRow In GRIDDESC.Rows
                            If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                                BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                            End If
                        Next

                        If Val(txtamt.Text) + Val(BALAMT) > Val(lblbilltotal.Text) Then
                            EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If

            ElseIf edit = True Then
                If GRIDDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If cmbpaytype.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                        End If

                        Dim BALAMT As Double = 0
                        For Each ROW As DataGridViewRow In GRIDDESC.Rows
                            If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                                BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                            End If
                        Next

                        If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                            EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, temprow).Value)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If cmbpaytype.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                        End If

                        Dim BALAMT As Double = 0
                        For Each ROW As DataGridViewRow In GRIDDESC.Rows
                            If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                                BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                            End If
                        Next

                        If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                            EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function DESCAMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim BALANCEAMT As Double = 0

            'checking WHETHER TOTAL OF AMT IS GREATER THEN BAL AMT OR NOT
            For Each ROW As DataGridViewRow In gridbill.Rows
                If ROW.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value = LBLPAYBILLINITIALS.Text.Trim Then
                    BALANCEAMT = ROW.Cells(gridbill.Columns("INVBALAMT").Index).Value
                End If
            Next


            If edit = False Then
                If GRIDDESCDOUBLECLICK = False Then
                    If (Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(txtdesctotal.Text)) > Val(BALANCEAMT) Then
                        EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                Else
                    If ((Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(txtdesctotal.Text)) - Val(gridpaydesc.Item(descamt.Index, TEMPDESCROW).Value)) > Val(BALANCEAMT) Then
                        EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                End If
            Else
                Dim MAXALLOWEDVALUE As Double = 0
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & LBLPAYBILLINITIALS.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MAXALLOWEDVALUE = Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT")) + BALANCEAMT
                End If
                DT.Clear()

                MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(gridpayment.Rows(Val(LBLPAYGRIDSRNO.Text) - 1).Cells(gamt.Index).Value)
                If GRIDDESCDOUBLECLICK = True Then
                    MAXALLOWEDVALUE = MAXALLOWEDVALUE + Val(gridpaydesc.Rows(TEMPDESCROW).Cells(descamt.Index).Value)
                End If

                For Each ROW As DataGridViewRow In gridpaydesc.Rows
                    MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(ROW.Cells(descamt.Index).Value)
                Next

                If Val(txtdescamt.Text) > Val(MAXALLOWEDVALUE) Then
                    EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()
        Try
            EP.Clear()
            If Not AMOUNTVALIDATE() Then
                txtsrno.Focus()
                Exit Sub
            End If

            Dim AMT As Double = txtamt.Text
            If edit = False Then
                If cmbpaytype.Text = "Against Bill" And Val(txtamt.Text) > Val(lblbilltotal.Text) And Val(lblbilltotal.Text) <> 0 Then
                    txtamt.Text = Val(lblbilltotal.Text)
                End If
            End If
            If GRIDDOUBLECLICK = False Then

                gridpayment.Rows.Add(0, txtsrno.Text.Trim, cmbpaytype.Text.Trim, cmbbillno.Text.Trim, txtnarr.Text.Trim, Val(txtamt.Text.Trim))
                getpaysrno(gridpayment)
            Else
                gridpayment.Item(1, temprow).Value = txtsrno.Text.Trim
                gridpayment.Item(2, temprow).Value = cmbpaytype.Text.Trim
                gridpayment.Item(3, temprow).Value = cmbbillno.Text.Trim
                gridpayment.Item(4, temprow).Value = txtnarr.Text.Trim
                gridpayment.Item(5, temprow).Value = Val(txtamt.Text.Trim)

                GRIDDOUBLECLICK = False
            End If
            If edit = False Then
                txtamt.Text = Format(Val(AMT) - Val(txtamt.Text), "0.00")
            Else
                txtamt.Clear()
            End If

            total()
            gridpayment.FirstDisplayedScrollingRowIndex = gridpayment.RowCount - 1

            txtsrno.Clear()
            cmbpaytype.SelectedIndex = 0
            cmbbillno.Text = ""
            lblbilltotal.Text = ""
            cmbbillno.Enabled = False
            txtnarr.Clear()
            'txtamt.Clear() DONT CLEAR THE AMT COZ BAL AMT OF THE CHQ COMES AGAIN
            txtsrno.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridDESC()
        Try

            EP.Clear()
            If Not DESCAMOUNTVALIDATE() Then
                txtdescsrno.Focus()
                Exit Sub
            End If

            fillEXTRAGRID()
            If GRIDDESCDOUBLECLICK = False Then
                gridpaydesc.Rows.Add(txtdescsrno.Text.Trim, cmbledgername.Text.Trim, txtdescnarr.Text.Trim, Val(txtdescamt.Text.Trim), LBLPAYGRIDSRNO.Text, LBLPAYBILLINITIALS.Text)
                getsrno(gridpaydesc)
            Else
                gridpaydesc.Item(descgridsrno.Index, TEMPDESCROW).Value = txtdescsrno.Text.Trim
                gridpaydesc.Item(gname.Index, TEMPDESCROW).Value = cmbledgername.Text.Trim
                gridpaydesc.Item(descnarr.Index, TEMPDESCROW).Value = txtdescnarr.Text.Trim
                gridpaydesc.Item(descamt.Index, TEMPDESCROW).Value = Val(txtdescamt.Text.Trim)
                gridpaydesc.Item(PAYGRIDSRNO.Index, TEMPDESCROW).Value = LBLPAYGRIDSRNO.Text.Trim
                gridpaydesc.Item(PAYBILLINITIALS.Index, TEMPDESCROW).Value = LBLPAYBILLINITIALS.Text.Trim
                GRIDDESCDOUBLECLICK = False
            End If
            total()

            gridpaydesc.FirstDisplayedScrollingRowIndex = gridpaydesc.RowCount - 1

            txtdescsrno.Clear()
            cmbledgername.Text = ""
            txtdescnarr.Text = ""
            txtdescamt.Clear()
            txtdescsrno.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillEXTRAGRID()
        Try

            If GRIDDESCDOUBLECLICK = False Then
                GRIDDESC.Rows.Add(txtdescsrno.Text.Trim, cmbledgername.Text.Trim, txtdescnarr.Text.Trim, Val(txtdescamt.Text.Trim), LBLPAYGRIDSRNO.Text, LBLPAYBILLINITIALS.Text)
            Else

                'FIRST GETTING ROWNO WITH RESPECT TO GRIDPAYDESC'S SRNO AND PAYMENT'S GRIDSRNO
                Dim ROWNO As Integer = 0
                For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    If ROW.Cells(DSRNO.Index).Value = txtdescsrno.Text And ROW.Cells(DPAYGRIDSRNO.Index).Value = LBLPAYGRIDSRNO.Text Then
                        ROWNO = ROW.Index
                        Exit For
                    End If
                Next

                GRIDDESC.Item(DSRNO.Index, ROWNO).Value = txtdescsrno.Text.Trim
                GRIDDESC.Item(DNAME.Index, ROWNO).Value = cmbledgername.Text.Trim
                GRIDDESC.Item(DNARR.Index, ROWNO).Value = txtdescnarr.Text.Trim
                GRIDDESC.Item(DAMT.Index, ROWNO).Value = Val(txtdescamt.Text.Trim)
                GRIDDESC.Item(DPAYGRIDSRNO.Index, ROWNO).Value = LBLPAYGRIDSRNO.Text.Trim
                GRIDDESC.Item(DPAYBILLINITIALS.Index, ROWNO).Value = LBLPAYBILLINITIALS.Text.Trim
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaccname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaccname.Enter
        Try
            'OPEN BANK A/C AND BANK OD A/C
            If cmbaccname.Text.Trim = "" Then fillledger(cmbaccname, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR groupmaster.group_SECONDARY = 'BANK OD A/C' OR groupmaster.group_SECONDARY = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaccname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbaccname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Sub SETGRIDINVOICE(ByVal DT As DataTable)
        Try
            DT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
            gridbill.DataSource = DT
            If a = 0 Then
                gridbill.Columns.Insert(0, col)
                a = 1
            End If

            gridbill.Columns(0).Width = 40
            gridbill.Columns(0).Name = "INVCHK"
            gridbill.Columns(0).HeaderText = ""
            gridbill.Columns(0).ReadOnly = True

            gridbill.Columns(1).Width = 80
            gridbill.Columns(1).Name = "INVBILLINITIALS"
            gridbill.Columns(1).HeaderText = "Bill No."
            gridbill.Columns(1).ReadOnly = True

            gridbill.Columns(2).Width = 80
            gridbill.Columns(2).Name = "INVBILLDATE"
            gridbill.Columns(2).HeaderText = "Bill Date"
            gridbill.Columns(2).ReadOnly = True

            gridbill.Columns(3).Width = 100
            gridbill.Columns(3).Name = "INVBALAMT"
            gridbill.Columns(3).HeaderText = "Bal. Amt"
            gridbill.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridbill.Columns(3).DefaultCellStyle.Format = "N2"
            gridbill.Columns(3).ReadOnly = True

            gridbill.Columns(4).Width = 100
            gridbill.Columns(4).Name = "INVBILLAMT"
            gridbill.Columns(4).HeaderText = "Bill Amt"
            gridbill.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridbill.Columns(4).DefaultCellStyle.Format = "N2"
            gridbill.Columns(4).ReadOnly = True

            gridbill.Columns(5).Visible = False
            gridbill.Columns(5).Name = "INVBILLTYPE"

            gridbill.Columns(6).Visible = False
            gridbill.Columns(6).Name = "INVBILLNO"

            gridbill.Columns(7).Visible = False
            gridbill.Columns(7).Name = "INVREGNAME"

            gridbill.Columns(8).Visible = False
            gridbill.Columns(8).Name = "INVCUSNAME"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridINVOICE()

        gridbill.DataSource = Nothing
        TXTINVTOTAL.Clear()
        'getting from INVOICEMASTER

        Dim objpayment As New ClsReceiptMaster
        Dim DT As New DataTable
        DT = objpayment.GETBILLS(CmpId, cmbname.Text.Trim, Locationid, YearId)
        If DT.Rows.Count > 0 Then
            SETGRIDINVOICE(DT)

            'Dim DTROW As DataRow
            'For Each DTROW In DT.Rows
            '    gridbill.Rows.Add(0, DTROW("BILLINITIALS"), Format(DTROW("BILLDATE"), "dd/MM/yyyy"), Val(DTROW("BALAMT")), Val(DTROW("BILLAMT")), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
            'Next
        End If

    End Sub

    Private Sub gridpayment_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpayment.CellClick
        Try

            If e.RowIndex < 0 Then Exit Sub

            Dim N As Integer = 0

            'CHECKING SIMILAR Enquiry Numbers
            For i As Integer = 0 To gridpayment.RowCount - 1
                With gridpayment.Rows(i).Cells(GCHK.Index)
                    If .Value = True Then
                        N = gridpayment.Rows(i).Cells(gridsrno.Index).Value
                    End If
                End With
            Next


            If e.RowIndex >= 0 And e.ColumnIndex = GCHK.Index And gridpayment.Rows(e.RowIndex).Cells(gpaytype.Index).Value = "Against Bill" Then
                With gridpayment.Rows(e.RowIndex).Cells(GCHK.Index)
                    If Convert.ToBoolean(.Value) = True Then
                        .Value = False
                        Gbdesc.Enabled = False
                        txtdescsrno.Clear()
                        cmbledgername.Text = ""
                        txtdescnarr.Clear()
                        txtdescamt.Clear()
                        gridpaydesc.RowCount = 0

                    Else
                        If (gridpayment.Rows(e.RowIndex).Cells(gridsrno.Index).Value = N) Or N = 0 Then
                            .Value = True
                            Gbdesc.Enabled = True
                            LBLPAYGRIDSRNO.Text = gridpayment.Rows(e.RowIndex).Cells(gridsrno.Index).Value
                            LBLPAYBILLINITIALS.Text = gridpayment.Rows(e.RowIndex).Cells(gbillno.Index).Value
                            GETDESCDATA(LBLPAYGRIDSRNO.Text)
                            total()
                            txtdescsrno.Focus()
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDESCDATA(ByVal ROWNO As Integer)
        Try
            gridpaydesc.RowCount = 0
            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                If ROW.Cells(DPAYGRIDSRNO.Index).Value = ROWNO Then
                    gridpaydesc.Rows.Add(ROW.Cells(DSRNO.Index).Value, ROW.Cells(DNAME.Index).Value, ROW.Cells(DNARR.Index).Value, ROW.Cells(DAMT.Index).Value, ROWNO, ROW.Cells(DPAYBILLINITIALS.Index).Value)
                End If
            Next
            getsrno(gridpaydesc)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridPAYMENT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpayment.CellDoubleClick
        Try

            If e.RowIndex >= 0 And gridpayment.Item(gridsrno.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = gridpayment.Item(gridsrno.Index, e.RowIndex).Value.ToString
                cmbpaytype.Text = gridpayment.Item(gpaytype.Index, e.RowIndex).Value.ToString
                cmbbillno.Text = gridpayment.Item(gbillno.Index, e.RowIndex).Value.ToString

                If cmbbillno.Text.Trim <> "" Then
                    cmbbillno.Enabled = True

                    'GETTING AMT OF THE SELECTED BILL
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALANCE", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT BOOKING_INITIALS AS BILLINITIALS, BOOKING_BALANCE AS BALANCE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM BOOKINGMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE ) AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        lblbilltotal.Text = Format(DT.Rows(0).Item("BALANCE"), "0.00")
                    End If
                End If

                txtnarr.Text = gridpayment.Item(gdesc.Index, e.RowIndex).Value.ToString
                txtamt.Text = gridpayment.Item(gamt.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                txtsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridRECEIPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpayment.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            'REMOVE ROWS FROM GRIDDESC
            gridpaydesc.RowCount = 0
            cmbledgername.Text = ""
            txtdescnarr.Clear()
            txtdescamt.Clear()
            txtdescsrno.Clear()
            Gbdesc.Enabled = False
1:
            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                If ROW.Cells(DPAYGRIDSRNO.Index).Value = gridpayment.Rows(gridpayment.CurrentRow.Index).Cells(gridsrno.Index).Value Then
                    GRIDDESC.Rows.RemoveAt(ROW.Index)
                    GoTo 1
                ElseIf ROW.Cells(DPAYGRIDSRNO.Index).Value > gridpayment.Rows(gridpayment.CurrentRow.Index).Cells(gridsrno.Index).Value Then
                    ROW.Cells(DPAYGRIDSRNO.Index).Value = ROW.Cells(DPAYGRIDSRNO.Index).Value - 1
                End If
            Next

            gridpayment.Rows.RemoveAt(gridpayment.CurrentRow.Index)
            total()
            getpaysrno(gridpayment)
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
LINE1:
            TEMPRECEIPTNO = Val(txtaccno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_receiptmaster()
            Dim MAXNO As Integer = txtaccno.Text.Trim
            clear()
            If Val(txtaccno.Text) - 1 >= TEMPRECEIPTNO Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And GRIDDESC.RowCount = 0 And TEMPRECEIPTNO < MAXNO Then
                txtaccno.Text = TEMPRECEIPTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
LINE1:
            TEMPRECEIPTNO = Val(txtaccno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPRECEIPTNO > 0 Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And GRIDDESC.RowCount = 0 And TEMPRECEIPTNO > 1 Then
                txtaccno.Text = TEMPRECEIPTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJRECDTLS As New ReceiptDetails
            OBJRECDTLS.MdiParent = MDIMain
            OBJRECDTLS.Show()
            OBJRECDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Private Sub cmbaccname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaccname.Validating
        Try
            If cmbaccname.Text.Trim <> "" Then ledgervalidate(cmbaccname, CMBACCCODE, e, Me, txtadd, " AND (GROUPMASTER.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.group_SECONDARY = 'BANK OD A/C' OR GROUPMASTER.group_SECONDARY = 'CASH IN HAND') AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbillno.Validating
        Try

            If txtbillno.Text.Trim <> "" Then

                txtbillno.Text = UCase(txtbillno.Text)
                'CHECKING WHETHER BILL IS ALREADY PRSENT IN GRID OR NOT
                'IF PRESENT THEN CHECK IT
                For Each row As DataGridViewRow In gridbill.Rows
                    If row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value.ToString = txtbillno.Text.Trim Then
                        row.Cells(gridbill.Columns("INVCHK").Index).Value = 1
                        txtbillno.Clear()
                        txtbillno.Focus()
                        total()

                        'DIRECTLY ADDING IN GRID (AS PRE DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = row.Cells(gridbill.Columns("INVBALAMT").Index).Value
                        txtamt_Validating(sender, e)

                        Exit Sub
                    End If
                Next


                'IF BILL IS NOT PRESENT IN GRID THEN ADD THE BILL IN GRID
                Dim OBJCMN As New ClsCommon
                'CHECKING IN OPENINGBILL
                Dim DT As DataTable = OBJCMN.search("BILL_INITIALS AS BILLINITIALS, BILL_DATE AS BILLDATE, BILL_BALANCE AS BALAMT, BILL_AMT AS BILLAMT, 'OPENING' AS BILLTYPE, BILL_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTERMASTER.register_id AND BILL_CMPID = REGISTERMASTER.register_cmpid AND BILL_LOCATIONID = REGISTERMASTER.register_locationid AND BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON BILL_LEDGERID = LEDGERS.Acc_id AND BILL_CMPID = LEDGERS.Acc_cmpid AND BILL_LOCATIONID = LEDGERS.Acc_locationid AND BILL_YEARID = LEDGERS.Acc_yearid ", " AND ( BILL_INITIALS = '" & txtbillno.Text.Trim & "') AND BILL_BALANCE > 0  AND (BILL_cmpid = " & CmpId & ") AND (BILL_locationid = " & Locationid & ") AND (BILL_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If


                'CHECKING IN BOOKINGMASTER
                DT = OBJCMN.search("BOOKING_INITIALS AS BILLINITIALS, BOOKING_DATE AS BILLDATE, BOOKING_BALANCE AS BALAMT, BOOKING_GTOTAL AS BILLAMT, 'BOOKING' AS BILLTYPE, BOOKING_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " BOOKINGMASTER INNER JOIN REGISTERMASTER ON BOOKING_REGID = REGISTERMASTER.register_id AND BOOKING_CMPID = REGISTERMASTER.register_cmpid AND BOOKING_LOCATIONID = REGISTERMASTER.register_locationid AND BOOKING_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON BOOKING_LEDGERID = LEDGERS.Acc_id AND BOOKING_CMPID = LEDGERS.Acc_cmpid AND BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND BOOKING_YEARID = LEDGERS.Acc_yearid ", " AND ( BOOKING_INITIALS = '" & txtbillno.Text.Trim & "') AND BOOKING_BALANCE > 0  AND (BOOKING_cmpid = " & CmpId & ") AND (BOOKING_locationid = " & Locationid & ") AND (BOOKING_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If



               'CHECKING IN JOURNAL
                DT = OBJCMN.search("JOURNALMASTER.journal_initials, JOURNALMASTER.journal_date, SUM(JOURNALMASTER.journal_debit) - (JOURNALMASTER.JOURNAL_AMT + JOURNALMASTER.journal_tds) AS BALAMT, SUM(JOURNALMASTER.journal_debit) AS BILLAMT, 'JOURNAL' AS BILLTYPE, JOURNALMASTER.journal_no AS BILLNO, REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " REGISTERMASTER INNER JOIN JOURNALMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.journal_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.journal_cmpid AND REGISTERMASTER.register_locationid = JOURNALMASTER.journal_locationid AND REGISTERMASTER.register_yearid = JOURNALMASTER.journal_yearid INNER JOIN LEDGERS ON JOURNALMASTER.journal_yearid = LEDGERS.Acc_yearid AND JOURNALMASTER.journal_locationid = LEDGERS.Acc_locationid AND JOURNALMASTER.journal_cmpid = LEDGERS.Acc_cmpid AND JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id ", " AND ( JOURNALMASTER.JOURNAL_INITIALS = '" & txtbillno.Text.Trim & "') AND ((JOURNALMASTER.journal_amt + JOURNALMASTER.journal_tds) < JOURNALMASTER.journal_debit)  AND (JOURNALMASTER.journal_cmpid = " & CmpId & ") AND (JOURNALMASTER.journal_locationid = " & Locationid & ") AND (JOURNALMASTER.journal_yearid = " & YearId & ") GROUP BY JOURNALMASTER.journal_initials, JOURNALMASTER.journal_date, JOURNALMASTER.journal_amt, JOURNALMASTER.journal_tds,  JOURNALMASTER.journal_no, REGISTERMASTER.register_name, LEDGERS.ACC_CMPNAME ")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If



                'CHECKING IN NONPURCHASE
                DT = OBJCMN.search("NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_BALANCE AS BALAMT, NONPURCHASE.NP_TOTALAMT AS BILLAMT, 'EXPENSE' AS BILLTYPE, NONPURCHASE.NP_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id AND NONPURCHASE.NP_CMPID = REGISTERMASTER.register_cmpid AND NONPURCHASE.NP_LOCATIONID = REGISTERMASTER.register_locationid AND NONPURCHASE.NP_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid AND NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid ", " AND ( NONPURCHASE.NP_INITIALS = '" & txtbillno.Text.Trim & "') AND NONPURCHASE.NP_BALANCE > 0  AND (NONPURCHASE.NP_cmpid = " & CmpId & ") AND (NONPURCHASE.NP_locationid = " & Locationid & ") AND (NONPURCHASE.NP_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If

                For Each ROW As DataGridViewRow In gridbill.Rows
                    If ROW.Cells("INVBILLINITIALS").Value = txtbillno.Text.Trim Then ROW.Cells("INVCHK").Value = 1
                Next
                total()
                txtbillno.Clear()
                txtbillno.Focus()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbbillno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbillno.GotFocus
        fillcmbbillno()
    End Sub

    Private Sub chkselectall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkselectall.CheckedChanged
        For Each row As DataGridViewRow In gridbill.Rows
            row.Cells(gridbill.Columns("INVCHK").Index).Value = chkselectall.CheckState
        Next
        total()
    End Sub

    Private Sub cmbbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbillno.Validating
        Try

            lblbilltotal.Text = ""

            If cmbbillno.Text.Trim <> "" Then
                cmbbillno.Text = UCase(cmbbillno.Text)

                'CHECKING WHETHER THE BILL IS VALID OR NOT
                Dim BLN As Boolean = False
                For Each ITEMS As Object In cmbbillno.Items
                    If ITEMS.ToString = cmbbillno.Text.Trim Then
                        BLN = True
                    End If
                Next
                If Not BLN Then
                    MsgBox("Invalid Bill No.", MsgBoxStyle.Critical, "MNOWF")
                    cmbbillno.Focus()
                    Exit Sub
                End If



                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT BOOKING_INITIALS AS BILLINITIALS, BOOKING_BALANCE AS BALANCE, BOOKING_CMPID AS CMPID , BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM BOOKINGMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE ) AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    lblbilltotal.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamt.Validating

        Try

            If txtsrno.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)

            If txtsrno.Text.Trim.Length > 0 And Val(txtamt.Text) > 0 Then
                If cmbpaytype.Text = "Against Bill" And cmbbillno.Text.Trim = "" Then
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "MNOWF")
                    cmbpaytype.Focus()
                    Exit Sub
                End If

                If cmbbillno.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In gridpayment.Rows
                        If (ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And ROW.Index <> temprow) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "MNOWF")
                            cmbpaytype.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                fillgrid()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'RECEIPT'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_receiptmaster()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    recregabbr = dt.Rows(0).Item(0).ToString
                    recreginitial = dt.Rows(0).Item(1).ToString
                    recregid = dt.Rows(0).Item(2)
                    getmaxno_receiptmaster()
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

    Private Sub accdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles accdate.Validating
        If Not datecheck(accdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Receipt Entry Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                If tempmsg = vbYes Then

                    Dim OBJREC As New ClsReceiptMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPRECEIPTNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJREC.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJREC.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                PRINTREPORT(TEMPRECEIPTNO)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal RECNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Print Booking Receipt?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim objrec As New receipt_advice
                objrec.RECEIPTNO = Val(RECNO)
                objrec.FRMSTRING = "BOOKING"
                objrec.REGNAME = cmbregister.Text.Trim
                objrec.MdiParent = MDIMain
                objrec.Show()
            End If

            TEMPMSG = MsgBox("Print Contribution Receipt?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim objrec As New receipt_advice
                objrec.RECEIPTNO = Val(RECNO)
                objrec.FRMSTRING = "CONTRI"
                objrec.REGNAME = cmbregister.Text.Trim
                objrec.MdiParent = MDIMain
                objrec.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchqno.KeyPress
        Try
            'numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchqno.Validating
        Try
            'AS PER REQ OF SALMAN BHAI
            'If txtchqno.Text.Trim <> "" Then
            '    'checking whether CHQNO IS ALREADY PAID WITH THE SAME BANK OR NOT....
            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.search(" RECEIPT_INITIALS", "", " RECEIPTMASTER INNER JOIN LEDGERS ON ACC_CMPID = RECEIPT_CMPID AND ACC_LOCATIONID = RECEIPT_LOCATIONID AND ACC_YEARID = RECEIPT_YEARID AND ACC_ID = RECEIPT_ACCID", " AND RECEIPT_CHQNO = '" & txtchqno.Text.Trim & "' AND ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND RECEIPT_CMPID = " & CmpId & " AND RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPT_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then
            '        If (edit = False) Or (edit = True And CHQNO <> txtchqno.Text.Trim) Then
            '            MsgBox("Chq. No. Already Present with this Bank in Receipt No." & DT.Rows(0).Item(0), MsgBoxStyle.Critical, "MNOWF")
            '            e.Cancel = True
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If gridpayment.RowCount > 0 Then
                txtsrno.Text = Val(gridpayment.Rows(gridpayment.RowCount - 1).Cells(gridsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtdescsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescsrno.GotFocus
        If GRIDDESCDOUBLECLICK = False Then
            If gridpaydesc.RowCount > 0 Then
                txtdescsrno.Text = Val(gridpaydesc.Rows(gridpaydesc.RowCount - 1).Cells(descgridsrno.Index).Value) + 1
            Else
                txtdescsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub cmbpaytype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.SelectedIndexChanged
        Try
            lblbilltotal.Text = ""
            cmbbillno.Text = ""
            If cmbpaytype.Text = "Against Bill" Then
                cmbbillno.Enabled = True
            Else
                cmbbillno.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbpaytype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.Validated
        Try
            If cmbpaytype.Text = "Against Bill" Then cmbbillno.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdescamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdescamt.Validating
        Try
            If txtdescsrno.Text.Trim.Length = 0 Then txtdescsrno_GotFocus(sender, e)

            If txtdescsrno.Text.Trim.Length > 0 And Val(txtdescamt.Text) > 0 And cmbledgername.Text.Trim <> "" Then
                fillgridDESC()
            Else
                MsgBox("Fill Details")
                cmbledgername.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpaydesc_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpaydesc.CellDoubleClick
        Try
            If e.RowIndex >= 0 And gridpaydesc.Item(gridsrno.Index, e.RowIndex).Value <> Nothing Then
                GRIDDESCDOUBLECLICK = True
                txtdescsrno.Text = gridpaydesc.Item(descgridsrno.Index, e.RowIndex).Value.ToString
                cmbledgername.Text = gridpaydesc.Item(gname.Index, e.RowIndex).Value.ToString
                txtdescnarr.Text = gridpaydesc.Item(descnarr.Index, e.RowIndex).Value.ToString
                txtdescamt.Text = gridpaydesc.Item(descamt.Index, e.RowIndex).Value.ToString
                LBLPAYGRIDSRNO.Text = gridpaydesc.Item(PAYGRIDSRNO.Index, e.RowIndex).Value.ToString
                LBLPAYBILLINITIALS.Text = gridpaydesc.Item(PAYBILLINITIALS.Index, e.RowIndex).Value.ToString

                TEMPDESCROW = e.RowIndex
                txtdescsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpaydesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpaydesc.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                'if LINE IS IN EDIT MODE (GRIDDESCDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
                If GRIDDESCDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'REMOVING ROWS FROM GRIDDESC
1:
                For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    If ROW.Cells(DPAYGRIDSRNO.Index).Value = gridpaydesc.Rows(gridpaydesc.CurrentRow.Index).Cells(PAYGRIDSRNO.Index).Value Then
                        GRIDDESC.Rows.RemoveAt(ROW.Index)
                        GoTo 1
                    End If
                Next

                gridpaydesc.Rows.RemoveAt(gridpaydesc.CurrentRow.Index)
                total()
                getsrno(gridpaydesc)
                txtdescsrno.Focus()

                'AGAIN INSERT THE COMPLETE GRIDPAYDESC IN GRIDDESC
                For Each ROW As DataGridViewRow In gridpaydesc.Rows
                    GRIDDESC.Rows.Add(ROW.Cells(descgridsrno.Index).Value, ROW.Cells(gname.Index).Value, ROW.Cells(descnarr.Index).Value, ROW.Cells(descamt.Index).Value, ROW.Cells(PAYGRIDSRNO.Index).Value, ROW.Cells(PAYBILLINITIALS.Index).Value)
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbledgername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbledgername.GotFocus
        Try
            'OPEN ALL LEDGERS
            If cmbledgername.Text.Trim = "" Then fillledger(cmbledgername, edit, " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbledgername_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbledgername.Validating
        Try
            If cmbledgername.Text.Trim <> "" Then ledgervalidate(cmbledgername, CMBACCCODE, e, Me, txtadd, " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbledgername_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbledgername.Validated
        If cmbledgername.Text.Trim = "" Then txtremarks.Focus()
    End Sub

    Private Sub txtchqamt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtchqamt.Validated
        Try
            If Val(txtamt.Text) = 0 Then txtamt.Text = Val(txtchqamt.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
            TEMPRECEIPTNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            clear()
            If TEMPRECEIPTNO > 0 Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Receipt_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            fillledger(cmbname, edit, " and acc_YEARid = " & YearId)
            fillledger(CMBCATEGORYLEDGER, edit, " and acc_YEARid = " & YearId)
            fillledger(cmbledgername, edit, " and acc_YEARid = " & YearId)
            fillledger(cmbaccname, edit, " and (groupmaster.group_secondary = 'BANK A/C' OR groupmaster.group_secondary = 'BANK OD A/C' OR groupmaster.group_secondary = 'CASH IN HAND') and acc_YEARid = " & YearId)
            fillregister(cmbregister, " and register_type = 'RECEIPT'")


            If TEMPAUTOENTRY = True Then
                'GET AUTO DATA POPULATION AS PER ELYSIUM'S REQUIREMENT
                Dim A As System.ComponentModel.CancelEventArgs
                cmbname.Focus()
                If TEMPACCNAME = "" Then
                    cmbaccname.Text = "Cash In Hand"
                Else
                    cmbaccname.Text = TEMPACCNAME
                End If
                txtchqno.Text = TEMPCHQNAME
                TXTBANKNAME.Text = TEMPBANKNAME
                cmbname.Text = TEMPNAME
                cmbname_Validating(sender, A)
                txtchqamt.Text = Format(Val(TEMPAMT), "0.00")
                txtamt.Text = Format(Val(TEMPAMT), "0.00")

                chkchange.CheckState = CheckState.Checked

                'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                cmbpaytype.Text = "Against Bill"
                cmbbillno.Text = TEMPBILLNO
                cmbbillno.Enabled = True
                txtnarr.Clear()
                lblbilltotal.Text = TEMPAMT

                txtamt_Validating(sender, A)
            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDRECO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDRECO.Click
        Try
            Dim objbankreco As New BankReco
            objbankreco.txtname.Text = cmbaccname.Text.Trim
            objbankreco.chkAll.CheckState = CheckState.Checked
            objbankreco.dtfrom.Value = getfirstdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.dtto.Value = getlastdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.MdiParent = MDIMain
            objbankreco.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            SELECTEDBILLNO = ""
            Dim OBJSELECTBILL As New SelectBills
            OBJSELECTBILL.ShowDialog()

            If SELECTEDBILLNO.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" LEDGERS.ACC_CMPNAME AS NAME", "", " BOOKINGMASTER INNER JOIN LEDGERS ON BOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND BOOKING_CMPID = LEDGERS.Acc_cmpid AND BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND BOOKING_YEARID = LEDGERS.Acc_yearid ", " AND BOOKING_INITIALS = '" & SELECTEDBILLNO & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID =" & YearId)
                If DT.Rows.Count > 0 Then
                    cmbname.Text = DT.Rows(0).Item("NAME")
                    cmbname.Enabled = False
                    fillgridINVOICE()
                    txtchqamt.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class