
Imports BL

Public Class journal

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Public edit As Boolean
    Dim temprefno As String
    Dim jvregabbr, jvreginitial As String
    Dim jvregid As Integer
    Dim temprow As Integer
    Dim tempamt, temptds As Double
    Dim temprecodate As Date    'for recodate
    Public tempjvno As Integer
    Public TEMPREGNAME As String
    Public Shared SELECTEDBILLNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Private Sub txtremarks_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.Validated
        pcase(txtremarks)
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        cmbname.Text = ""
        txtremarks.Clear()
        jvregabbr = ""
        jvreginitial = ""
        gridDoubleClick = False
        'journaldate.Value = Mydate
        cmbtype.Text = ""
        cmbpaytype.Text = ""
        txtrefno.Clear()
        txtrefno.ReadOnly = False
        txtdebit.Clear()
        txtcredit.Clear()
        gridjournal.RowCount = 0
        txtremarks.Clear()

        TXTTOTALDR.Text = 0.0
        TXTTOTALCR.Text = 0.0

        lbllocked.Visible = False
        PBlock.Visible = False

        edit = False
        getmaxno_journalmaster()

    End Sub

    Sub getmaxno_journalmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JOURNAL_NO),0) + 1 ", "JOURNALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = JOURNAL_REGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND JOURNAL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then txtjournalno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub journaldate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles journaldate.Validating
        'If Not datecheck(journaldate.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_journalmaster()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated

        If cmbtype.SelectedIndex = 0 Then
            txtcredit.ReadOnly = False
            txtdebit.ReadOnly = True
        Else
            txtcredit.ReadOnly = True
            txtdebit.ReadOnly = False
        End If
    End Sub

    Private Sub cmbpaytype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.Validated
        If cmbpaytype.Text = "On Account" Then
            txtrefno.ReadOnly = True
        Else
            txtrefno.ReadOnly = False
        End If
    End Sub

    Private Sub txtrefno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrefno.GotFocus
        'If txtrefno.Text.Trim = "" And cmbpaytype.Text <> "On Account" Then
        '    txtrefno.Text = Val(txtjournalno.Text)
        'ElseIf txtrefno.Text.Trim <> "" And cmbpaytype.Text = "On Account" Then
        '    txtrefno.Clear()
        'End If
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try

            EP.Clear()
            If cmbtype.Text.Trim <> "" And txtrefno.Text.Trim <> "" And gridDoubleClick = False And edit = False Then
                ' GETTING BILL DETAILS DIRECTLY FROM REFNO
                If Not GETBILL(txtrefno.Text.Trim) Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If


            'If txtrefno.Text.Trim.Length > 0 And cmbname.Text.Trim.Length > 0 Then
            '    If (edit = False) Or (edit = True And LCase(temprefno) <> txtrefno.Text.Trim) Then
            '        Dim a As String
            '        a = txtrefno.Text.Trim
            '        'for search
            '        Dim objclscommon As New ClsCommon()
            '        Dim dt As New DataTable
            '        dt = objclscommon.search(" JournalMaster.Journal_refno, LEDGERS.ACC_cmpname", "", " JournalMaster inner join LEDGERS on LEDGERS.ACC_id = JournalMaster.Journal_ledgerid and JournalMaster.Journal_cmpid = LEDGERS.ACC_cmpid and JournalMaster.Journal_LOCATIONid = LEDGERS.ACC_LOCATIONid and JournalMaster.Journal_YEARid = LEDGERS.ACC_YEARid ", " and JournalMaster.Journal_refno = '" & txtrefno.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' and JournalMaster.Journal_cmpid = " & CmpId & " and JournalMaster.Journal_LOCATIONid = " & Locationid & " and JournalMaster.Journal_YEARid = " & YearId)
            '        If dt.Rows.Count > 0 Then
            '            MsgBox("Party Ref. Already Exists", MsgBoxStyle.Critical, "MNOWF")
            '            e.Cancel = True
            '            Exit Sub
            '        End If
            '    End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In gridjournal.Rows
                If Val(row.Cells(0).Value) > 0 Then row.Cells(8).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try

            Dim alParaval As New ArrayList

            EP.Clear()
            If Not errorvalid() Then
                alParaval.Add(tempjvno)
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno()



            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(journaldate.Value)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim type As String = ""
            Dim name As String = ""
            Dim paytype As String = ""
            Dim refno As String = ""
            Dim debit As String = ""
            Dim credit As String = ""
            Dim gridsrno As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridjournal.Rows
                If row.Cells(1).Value <> Nothing Then
                    If type = "" Then
                        type = row.Cells(0).Value.ToString
                        name = row.Cells(1).Value
                        paytype = row.Cells(2).Value.ToString
                        refno = row.Cells(3).Value
                        debit = row.Cells(4).Value
                        credit = row.Cells(5).Value
                        gridsrno = row.Cells(8).Value
                    Else
                        type = type & "," & row.Cells(0).Value.ToString
                        name = name & "," & row.Cells(1).Value
                        paytype = paytype & "," & row.Cells(2).Value.ToString
                        refno = refno & "," & row.Cells(3).Value
                        debit = debit & "," & row.Cells(4).Value
                        credit = credit & "," & row.Cells(5).Value
                        gridsrno = gridsrno & "," & row.Cells(8).Value
                    End If
                End If
            Next

            alParaval.Add(type)
            alParaval.Add(name)
            alParaval.Add(paytype)
            alParaval.Add(refno)
            alParaval.Add(debit)
            alParaval.Add(credit)
            alParaval.Add(gridsrno)

            Dim objclsjvmaster As New ClsJournalMaster()
            objclsjvmaster.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = objclsjvmaster.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempjvno)
                alParaval.Add(tempamt)
                alParaval.Add(temptds)
                'alParaval.Add(temprecodate)
                DT = objclsjvmaster.update()
                MsgBox("Details Updated")
            End If

            'ACCOUNTS ENTRY TO BE DONE HERE COZ LOOP IS NOT POSSIBLE IN SP
            txtjournalno.Text = DT.Rows(0).Item(0)
            ACCOUNTSENTRY(DT.Rows(0).Item(0))
            clear()
            edit = False
            journaldate.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY(ByVal JVNO As Integer)
        Try
            Dim OBJJV As New ClsJournalMaster
            Dim INTRESULT As Integer

            If edit = True Then
                Dim ALP As New ArrayList
                ALP.Add(TEMPREGNAME)
                ALP.Add(JVNO)
                ALP.Add(CmpId)
                ALP.Add(Locationid)
                ALP.Add(YearId)
                OBJJV.alP = ALP
                INTRESULT = OBJJV.ACCDELETE()
            End If

            Dim tempcredit, creditbal, tempdebit, debitbal As Double
            Dim tempr As Integer    'for row no of grid
            Dim I, J As Integer     'FOR LOOP

            tempcredit = 0
            creditbal = 0
            tempdebit = 0
            debitbal = 0
            tempr = 0

            For I = 0 To gridjournal.RowCount - 1
                If gridjournal.Item(0, I).Value.ToString = "Cr" Then
                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempcredit = Val(gridjournal.Item(5, I).Value.ToString)
                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (creditbal > 0)
                            If J < gridjournal.RowCount Then

                                Dim ALPARAVAL As New ArrayList

                                ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME FROMID

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Dr" Then

                                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If

                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(journaldate.Value)                        'JOURNAL DATE
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()

                                    End If
                                End If

                                J = J + 1
                            Else
                                creditbal = 0
                            End If
                        End While


                    End If

                ElseIf gridjournal.Item(0, I).Value.ToString = "Dr" Then

                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempdebit = Val(gridjournal.Item(4, I).Value.ToString)
                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (debitbal > 0)
                            If J < gridjournal.RowCount Then
                                Dim ALPARAVAL As New ArrayList

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Cr" Then

                                        'getting ledgerid
                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString) 'ADDING NAME FROMID

                                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, I).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, J).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If


                                        ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(journaldate.Value)                        'JOURNAL DATE
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()


                                    End If
                                End If

                                J = J + 1
                            Else
                                debitbal = 0
                            End If
                        End While


                    End If

                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Journal Locked")
                bln = False
            End If
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        If gridjournal.RowCount = 0 Then
            EP.SetError(txtcredit, "Enter Transactions")
            bln = False
        End If

        'cheking whether cr and dr is equal or not
        Dim tempdebit, tempcredit As Double
        For Each row As DataGridViewRow In gridjournal.Rows
            If row.Cells(2).Value = "" Then
                EP.SetError(txtcredit, "Fill PayType")
                bln = False
            End If
            tempdebit = Format(Val(tempdebit) + Val(row.Cells(4).Value), "0.00")
            tempcredit = Format(Val(tempcredit) + Val(row.Cells(5).Value), "0.00")
        Next
        If Val(tempdebit) <> Val(tempcredit) Then
            EP.SetError(txtcredit, "Total Does Not Match")
            bln = False
        End If


        'If Not datecheck(journaldate.Value) Then
        '    EP.SetError(journaldate, "Date Not in Current Accounting Year")
        '    bln = False
        'End If

        Return bln

    End Function

    Private Sub Journal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call ToolStripdelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
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

    Private Sub Journal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    jvregabbr = dt.Rows(0).Item(0).ToString
                    jvreginitial = dt.Rows(0).Item(1).ToString
                    jvregid = dt.Rows(0).Item(2)
                    getmaxno_journalmaster()
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

    Private Sub txtjournalno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjournalno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True

            If edit = False Then
                If gridDoubleClick = False Then
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If (cmbtype.Text = "Dr" And Val(txtdebit.Text) > Val(TXTBILLAMT.Text)) Or (cmbtype.Text = "Cr" And Val(txtcredit.Text) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If ((cmbtype.Text = "Dr" And (Val(txtdebit.Text) - Val(gridjournal.Item(GDEBIT.Index, temprow).Value))) > Val(TXTBILLAMT.Text)) Or ((cmbtype.Text = "Cr" And (Val(txtcredit.Text) - Val(gridjournal.Item(GCREDIT.Index, temprow).Value))) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                End If

                'ElseIf edit = True Then
                '    If gridDoubleClick = False Then
                '        'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                '        If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                '            EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                '            BLN = False
                '        End If

                '        If cmbpaytype.Text.Trim = "Against Bill" Then
                '            Dim MAXALLOWEDVALUE As Double = 0
                '            Dim OBJCMN As New ClsCommon
                '            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                '            If DT.Rows.Count > 0 Then
                '                MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                '            End If

                '            Dim BALAMT As Double = 0
                '            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                '                If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                '                    BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                '                End If
                '            Next

                '            If Val(txtamt.Text) > Val(MAXALLOWEDVALUE) Then
                '                EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                '                BLN = False
                '            End If

                '        End If

                '    Else
                '        'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                '        If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, temprow).Value)) > Val(txtchqamt.Text) Then
                '            EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                '            BLN = False
                '        End If

                '        If cmbpaytype.Text.Trim = "Against Bill" Then
                '            Dim MAXALLOWEDVALUE As Double = 0
                '            Dim OBJCMN As New ClsCommon
                '            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                '            If DT.Rows.Count > 0 Then
                '                MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                '            End If

                '            Dim BALAMT As Double = 0
                '            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                '                If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                '                    BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                '                End If
                '            Next

                '            If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                '                EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                '                BLN = False
                '            End If

                '        End If
                '    End If
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtcredit_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcredit.Validating
        Try
            If (Val(txtcredit.Text) <> 0 Or Val(txtdebit.Text) <> 0) And cmbname.Text.Trim <> "" And cmbtype.Text.Trim <> "" Then

                If cmbtype.Text.Trim = "Against Bill" Then
                    EP.Clear()
                    If Not AMOUNTVALIDATE() Then
                        Exit Sub
                    End If
                End If

                'If cmbpaytype.Text <> "On Account" And txtrefno.Text.Trim <> "" Then
                If cmbtype.Text = "Dr" Then
                    txtcredit.Clear()
                Else
                    txtdebit.Clear()
                End If

                'If Not checkledger() Then
                '    MsgBox("Ledger already Present in Grid below")
                '    Exit Sub
                'End If

                fillgrid()
                txtdebit.Clear()
                txtcredit.Clear()
                txtrefno.Clear()
                cmbpaytype.SelectedIndex = 0
                cmbname.Text = ""
                cmbtype.Focus()
                'Else
                '    MsgBox("Enter Ref No.")
                '    txtrefno.Focus()
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkledger() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In gridjournal.Rows
                If (gridDoubleClick = True And temprow <> row.Index) Or gridDoubleClick = False Then
                    If cmbname.Text.Trim = row.Cells(1).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        'GETTING CURRENT BALANCE FROM TRIAL BALANCE
        Dim OBJCOMMON As New ClsCommon
        Dim DT As New DataTable
        Dim BAL As String = String.Empty
        Dim DRCR As String = String.Empty
        DT = OBJCOMMON.search(" (CASE WHEN DR-CR>0 THEN DR-CR ELSE CR-DR END), (CASE WHEN DR-CR>0 THEN 'Dr' ELSE 'Cr' END)", "", " TRIALBALANCE", " AND NAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            BAL = DT.Rows(0).Item(0)
            DRCR = DT.Rows(0).Item(1)
        End If

        If gridDoubleClick = False Then

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) & "Cr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) & "Dr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            End If

        ElseIf gridDoubleClick = True Then

            gridjournal.Item(0, temprow).Value = cmbtype.Text
            gridjournal.Item(1, temprow).Value = cmbname.Text.Trim
            gridjournal.Item(2, temprow).Value = cmbpaytype.Text
            gridjournal.Item(3, temprow).Value = txtrefno.Text.Trim
            gridjournal.Item(4, temprow).Value = Format(Val(txtdebit.Text), "0.00")
            gridjournal.Item(5, temprow).Value = Format(Val(txtcredit.Text), "0.00")
            gridjournal.Item(6, temprow).Value = ""
            gridDoubleClick = False

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) * (-1) & "Cr"
                End If
                gridjournal.Item(7, temprow).Value = BAL
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) * (-1) & "Dr"
                End If
                gridjournal.Item(7, temprow).Value = BAL
            End If
        End If

        TOTAL()
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALCR.Text = 0.0
            TXTTOTALDR.Text = 0.0

            For Each ROW As DataGridViewRow In gridjournal.Rows
                If Val(ROW.Cells(GDEBIT.Index).Value) > 0 Or Val(ROW.Cells(GCREDIT.Index).Value) > 0 Then
                    TXTTOTALDR.Text = Format(Val(TXTTOTALDR.Text.Trim) + Val(ROW.Cells(GDEBIT.Index).Value), "0.00")
                    TXTTOTALCR.Text = Format(Val(TXTTOTALCR.Text.Trim) + Val(ROW.Cells(GCREDIT.Index).Value), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridjournal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjournal.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridjournal.Rows.RemoveAt(gridjournal.CurrentRow.Index)
            TOTAL()
        End If
    End Sub

    Private Sub gridjournal_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridjournal.CellDoubleClick
        If e.RowIndex >= 0 And gridjournal.Item(0, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            temprow = e.RowIndex
            cmbtype.Text = gridjournal.Item(0, e.RowIndex).Value
            cmbname.Text = gridjournal.Item(1, e.RowIndex).Value
            cmbpaytype.Text = gridjournal.Item(2, e.RowIndex).Value
            txtrefno.Text = gridjournal.Item(3, e.RowIndex).Value
            txtdebit.Text = gridjournal.Item(4, e.RowIndex).Value
            txtcredit.Text = gridjournal.Item(5, e.RowIndex).Value
            cmbtype.Focus()
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objjvdtls As New JournalDetails
            objjvdtls.MdiParent = MDIMain
            objjvdtls.Show()
            objjvdtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Journal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOURNAL VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillregister(cmbregister, " and register_type = 'JOURNAL'")
            getmaxno_journalmaster()
            fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsJV As New ClsJournalMaster()
                dt = objclsJV.selectjournal_edit(tempjvno, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtjournalno.Text = tempjvno
                        cmbregister.Text = TEMPREGNAME
                        journaldate.Value = Convert.ToDateTime(dr("JOURNAL_date"))
                        tempamt = Convert.ToString(dr("JOURNAL_AMT"))
                        temptds = Convert.ToString(dr("JOURNAL_TDS"))
                        txtremarks.Text = Convert.ToString(dr("JOURNAL_remarks"))
                        gridjournal.Rows.Add(dr("JOURNAL_TYPE").ToString, dr("ACC_CMPNAME").ToString, dr("JOURNAL_PAYTYPE").ToString, dr("JOURNAL_REFNO").ToString, Val(dr("JOURNAL_DEBIT")), Val(dr("JOURNAL_CREDIT")), 0)
                        If IsDBNull(dr("JOURNAL_recodate")) = False Then temprecodate = Convert.ToDateTime(dr("JOURNAL_recodate"))

                        If dr("JOURNAL_PAYTYPE") = "Against Bill" Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    TOTAL()
                    cmbregister.Enabled = False
                    cmbtype.Focus()
                    chkchange.CheckState = CheckState.Checked
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_SECONDARY NOT IN ('CASH IN HAND','BANK A/C','BANK OD A/C') and acc_cmpid = " & CmpId)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'OPEN ALL LEDGERS
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBCODE, e, Me, TXTADD, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_journalmaster()
            Dim MAXNO As Integer = txtjournalno.Text.Trim
            clear()
            If Val(txtjournalno.Text) - 1 >= tempjvno Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno < MAXNO Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno > 1 Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Journal Entry Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                If tempmsg = vbYes Then

                    Dim OBJJV As New ClsJournalMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(tempjvno)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJJV.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJJV.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridjournal.RowCount = 0
            tempjvno = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If cmbname.Text.Trim <> "" Then

                SELECTEDBILLNO = ""
                txtrefno.Clear()
                TXTBILLAMT.Clear()

                Dim OBJSELECTBILL As New SelectBills
                OBJSELECTBILL.CMPNAME = cmbname.Text.Trim
                OBJSELECTBILL.ShowDialog()
                If OBJSELECTBILL.BILLNO <> "" Then SELECTEDBILLNO = OBJSELECTBILL.BILLNO

                If SELECTEDBILLNO.Trim <> "" Then
                    If Not GETBILL(SELECTEDBILLNO) Then
                        Exit Sub
                    End If
                    txtrefno.Focus()
                End If
            Else
                MsgBox("Select Name")
                cmbname.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function GETBILL(ByVal BILLNO As String) As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" * ", "", " (SELECT     OPENINGBILL.BILL_INITIALS AS BILLINITIALS, OPENINGBILL.BILL_BALANCE AS BALANCE, OPENINGBILL.BILL_CMPID AS CMPID, OPENINGBILL.BILL_LOCATIONID AS LOCATIONID, OPENINGBILL.BILL_YEARID AS YEARID, 'OPENING' AS BILLTYPE, Acc_cmpname AS NAME FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL.BILL_LOCATIONID = LEDGERS.Acc_locationid And OPENINGBILL.BILL_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     EDUCLAIMSETTLEMENT.SETTLE_INITIALS AS BILLINITIALS, EDUCLAIMSETTLEMENT.SETTLE_BALANCE AS BALANCE, EDUCLAIMSETTLEMENT.SETTLE_CMPID AS CMPID, EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID AS LOCATIONID, EDUCLAIMSETTLEMENT.SETTLE_YEARID AS YEARID, 'EDUCATION' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM EDUCLAIMSETTLEMENT INNER JOIN LEDGERS ON EDUCLAIMSETTLEMENT.SETTLE_LEDGERID = LEDGERS.Acc_id AND EDUCLAIMSETTLEMENT.SETTLE_CMPID = LEDGERS.Acc_cmpid AND EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID = LEDGERS.Acc_locationid AND EduClaimSettlement.SETTLE_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     MEDCLAIMSETTLEMENT.SETTLE_INITIALS AS BILLINITIALS, MEDCLAIMSETTLEMENT.SETTLE_BALANCE AS BALANCE, MEDCLAIMSETTLEMENT.SETTLE_CMPID AS CMPID, MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID AS LOCATIONID, MEDCLAIMSETTLEMENT.SETTLE_YEARID AS YEARID, 'MEDICAL' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM MEDCLAIMSETTLEMENT INNER JOIN LEDGERS ON MEDCLAIMSETTLEMENT.SETTLE_LEDGERID = LEDGERS.Acc_id AND MEDCLAIMSETTLEMENT.SETTLE_CMPID = LEDGERS.Acc_cmpid AND MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID = LEDGERS.Acc_locationid AND MedClaimSettlement.SETTLE_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     CAST(REFUNDMASTER.REFUND_INITIALS AS VARCHAR) AS BILLINITIALS, REFUNDMASTER.REFUND_BALANCE AS BALANCE,  REFUNDMASTER.REFUND_CMPID AS CMPID, REFUNDMASTER.REFUND_LOCATIONID AS LOCATIONID, REFUNDMASTER.REFUND_YEARID AS YEARID, 'REFUND' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM REFUNDMASTER INNER JOIN LEDGERS ON REFUNDMASTER.REFUND_LEDGERID = LEDGERS.Acc_id AND REFUNDMASTER.REFUND_CMPID = LEDGERS.Acc_cmpid AND REFUNDMASTER.REFUND_LOCATIONID = LEDGERS.Acc_locationid And REFUNDMASTER.REFUND_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     CAST(SALARYMASTER.SAL_INITIALS AS VARCHAR) AS BILLINITIALS, SALARYMASTER.SAL_BALANCE AS BALANCE, SALARYMASTER.SAL_CMPID AS CMPID, SALARYMASTER.SAL_LOCATIONID AS LOCATIONID, SALARYMASTER.SAL_YEARID AS YEARID, 'SALARY' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_EMPID = LEDGERS.Acc_id AND SALARYMASTER.SAL_CMPID = LEDGERS.Acc_cmpid AND SalaryMaster.SAL_LOCATIONID = LEDGERS.Acc_locationid And SalaryMaster.SAL_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_BALANCE AS BALANCE, NONPURCHASE.NP_CMPID AS CMPID,  NONPURCHASE.NP_LOCATIONID AS LOCATIONID, NONPURCHASE.NP_YEARID AS YEARID, 'NONPURCHASE' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid And NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     BOOKINGMASTER.BOOKING_INITIALS AS BILLINITIALS, BOOKINGMASTER.BOOKING_BALANCE AS BALANCE, BOOKINGMASTER.BOOKING_CMPID AS CMPID, BOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, BOOKINGMASTER.BOOKING_YEARID AS YEARID, 'BOOKING' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM BOOKINGMASTER INNER JOIN LEDGERS ON BOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND BOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid And BOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT     JOURNALMASTER.journal_initials AS BILLINITIALS, SUM(JOURNALMASTER.journal_debit) - (JOURNALMASTER.journal_amt + JOURNALMASTER.journal_tds) AS BALANCE, JOURNALMASTER.journal_cmpid AS CMPID, JOURNALMASTER.journal_locationid AS LOCATIONID, JOURNALMASTER.journal_yearid AS YEARID, 'JOURNAL' AS BILLTYPE, LEDGERS.Acc_cmpname AS NAME FROM JOURNALMASTER INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id AND JOURNALMASTER.journal_cmpid = LEDGERS.Acc_cmpid AND JOURNALMASTER.journal_locationid = LEDGERS.Acc_locationid And JOURNALMASTER.journal_yearid = LEDGERS.Acc_yearid GROUP BY JOURNALMASTER.journal_initials, JOURNALMASTER.journal_amt, JOURNALMASTER.journal_tds, JOURNALMASTER.journal_cmpid, JOURNALMASTER.journal_locationid, JOURNALMASTER.journal_yearid, LEDGERS.Acc_cmpname ) AS T ", " AND T.BILLINITIALS =  '" & BILLNO & "'  AND T.BALANCE > 0 AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID =" & YearId & " ORDER BY T.BILLTYPE, T.BILLINITIALS")
            If dt.Rows.Count > 0 Then
                cmbname.Text = dt.Rows(0).Item("NAME")
                txtrefno.Text = BILLNO
                cmbpaytype.Text = "Against Bill"
                TXTBILLAMT.Text = Val(dt.Rows(0).Item("BALANCE"))
                If cmbtype.Text = "Dr" Then
                    txtdebit.Text = Val(dt.Rows(0).Item("BALANCE"))
                Else
                    txtcredit.Text = Val(dt.Rows(0).Item("BALANCE"))
                End If
            Else
                EP.SetError(txtcredit, "Invalid Bill No")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    Try
    '        For I As Integer = 1 To 2880
    '            tempjvno = I
    '            TEMPREGNAME = "JOURNAL REGISTER"
    '            clear()
    '            edit = True
    '            Journal_Load(sender, e)
    '            cmdok_Click(sender, e)
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class