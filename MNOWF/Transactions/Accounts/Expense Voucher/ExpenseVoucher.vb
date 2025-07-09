
Imports BL
Imports System.Windows.Forms

Public Class ExpenseVoucher

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPEXPNO As Integer     'used for non purchase no while editing
    Dim temprow As Integer
    Public partyref As String      'used for refno while edit mode
    Dim PURregid As Integer
    Dim PURregabbr, PURreginitial As String
    Public TEMPREGNAME As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        gridGRN.Enabled = True
        EP.Clear()
        npdate.Value = Mydate
        partybilldate.Value = Mydate
        lbltotalamt.Text = 0
        lbltotalqty.Text = 0
        cmbtax.Text = ""
        txttax.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        cmbname.Text = ""
        TXTADD.Clear()
        txtrefno.Clear()
        TXTNP.Clear()
        cmbdrname.Text = ""
        txtnote.Clear()
        TXTQTY.Clear()
        TXTRATE.Clear()
        txtamt.Clear()
        txtremarks.Clear()
        gridGRN.RowCount = 0
        partyref = ""
        TXTBAL.Clear()
        TXTAMTREC.Clear()
        TXTTDS.Clear()


        getmaxno()
        gridDoubleClick = False

        If gridGRN.RowCount > 0 Then
            txtsrno.Text = Val(gridGRN.Rows(gridGRN.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        If cmbregister.Text <> "" Then
            If FRMSTRING = "NONPURCHASE" Then
                DTTABLE = getmax(" isnull(max(NP_NO),0) + 1 ", "  NONPURCHASE left outer JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID AND REGISTER_CMPID = NP_CMPID AND REGISTER_LOCATIONID = NP_LOCATIONID AND REGISTER_YEARID = NP_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'EXPENSE' AND NP_cmpid=" & CmpId & " AND NONPURCHASE.NP_LOCATIONID = " & Locationid & " AND NP_YEARID = " & YearId)
            Else
                DTTABLE = getmax(" isnull(max(NONINV_NO),0) + 1 ", "  NONINVPURCHASE left outer JOIN REGISTERMASTER ON REGISTER_ID = NONINV_REGISTERID AND REGISTER_CMPID = NONINV_CMPID AND REGISTER_LOCATIONID = NONINV_LOCATIONID AND REGISTER_YEARID = NONINV_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND NONINV_cmpid=" & CmpId & " AND NONINV_LOCATIONID = " & Locationid & " AND NONINV_YEARID = " & YearId)
            End If
            If DTTABLE.Rows.Count > 0 Then
                TXTNP.Text = DTTABLE.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub NonPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.KeyCode = Keys.Oemcomma Then
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

    Private Sub NonPurchase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub NonPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VOUCHER ENTRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor
            clear()
            If FRMSTRING = "NONPURCHASE" Then
                fillregister(cmbregister, " and register_type = 'EXPENSE'")
            Else
                fillregister(cmbregister, " and register_type = 'PURCHASE'")
            End If
            If cmbregister.Items.Count > 0 Then cmbregister.SelectedIndex = (0)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbdrname.Text.Trim = "" Then fillledger(cmbdrname, edit, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
            filltax(cmbtax, edit)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPEXPNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                If FRMSTRING = "NONPURCHASE" Then

                    Dim objclsNP As New ClsExpenseVoucher
                    objclsNP.alParaval = ALPARAVAL
                    dt = objclsNP.selectNONpurchase()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            TXTNP.Text = TEMPEXPNO
                            cmbregister.Text = Convert.ToString(dr("REGNAME"))
                            cmbname.Text = Convert.ToString(dr("NAME"))
                            npdate.Value = dr("DATE")
                            txtrefno.Text = dr("REFNO")
                            partyref = txtrefno.Text.Trim
                            partybilldate.Value = dr("PARTYBILLDATE")
                            txtremarks.Text = Convert.ToString(dr("Remarks"))
                            TXTAMTREC.Text = dr("AMTPAID")
                            TXTTDS.Text = dr("EXTRAAMT")
                            TXTBAL.Text = dr("BALANCE")
                            cmbtax.Text = dr("TAXNAME")
                            txttax.Text = dr("TAXAMT")
                            If Val(dr("gridsrno").ToString) <> 0 Then
                                gridGRN.Rows.Add(dr("gridsrno").ToString, dr("DRNAME").ToString, dr("NOTE").ToString, dr("qty").ToString, dr("rate").ToString, dr("amt").ToString)
                            End If
                        Next

                    End If

                ElseIf FRMSTRING = "PURCHASE" Then

                    Dim objclsNP As New ClsExpenseVoucher
                    objclsNP.alParaval = ALPARAVAL
                    dt = objclsNP.selectNONpurchase()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            TXTNP.Text = TEMPEXPNO
                            cmbregister.Text = Convert.ToString(dr("register_name"))
                            cmbname.Text = Convert.ToString(dr("vendorname"))
                            npdate.Value = dr("NP_DATE")
                            txtrefno.Text = dr("NP_REFNO")
                            partyref = txtrefno.Text.Trim
                            partybilldate.Value = dr("NP_PARTYBILLDATE")
                            txtremarks.Text = Convert.ToString(dr("NP_Remarks"))
                            TXTAMTREC.Text = dr("NP_AMTPAID")
                            TXTTDS.Text = dr("NP_TDS")
                            TXTBAL.Text = dr("NP_BALANCE")
                            cmbtax.Text = dr("TAXNAME")
                            txttax.Text = dr("TAXAMT")
                            If Val(dr("NP_gridsrno").ToString) <> 0 Then
                                gridGRN.Rows.Add(dr("NP_gridsrno").ToString, dr("DRNAME").ToString, dr("NP_NOTE").ToString, dr("NP_qty").ToString, dr("NP_rate").ToString, dr("NP_amt").ToString)
                            End If
                        Next

                    End If

                End If

                cmbregister.Enabled = False
                cmbname.Focus()
                chkchange.CheckState = CheckState.Checked
                total()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim IntResult As Integer

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If (edit = False And txtrefno.Text.Trim.Length > 0) Or (edit = True And LCase(txtrefno.Text.Trim) <> LCase(partyref)) Then
                If Not VALIDATEREFNO() Then
                    EP.SetError(txtrefno, "Party Ref. Already Exists")
                    Exit Sub
                End If
            End If

            

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(npdate.Value)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(partybilldate.Value)
            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(lbltotalamt.Text))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text))
            alParaval.Add(Val(txtroundoff.Text))
            alParaval.Add(Val(txtgrandtotal.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTAMTREC.Text.Trim)
            alParaval.Add(TXTTDS.Text.Trim)
            alParaval.Add(TXTBAL.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim drname As String = ""
            Dim note As String = ""
            Dim qty As String = ""
            Dim rate As String = ""
            Dim amount As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridGRN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(0).Value.ToString
                        drname = row.Cells(1).Value.ToString
                        note = row.Cells(2).Value.ToString
                        qty = Val(row.Cells(3).Value.ToString)
                        rate = Val(row.Cells(4).Value.ToString)
                        amount = Val(row.Cells(5).Value.ToString)
                    Else
                        gridsrno = gridsrno & "," & row.Cells(0).Value.ToString
                        drname = drname & "," & row.Cells(1).Value.ToString
                        note = note & "," & row.Cells(2).Value.ToString
                        qty = qty & "," & Val(row.Cells(3).Value.ToString)
                        rate = rate & "," & Val(row.Cells(4).Value.ToString)
                        amount = amount & "," & Val(row.Cells(5).Value.ToString)
                    End If
                End If
            Next



            alParaval.Add(gridsrno)
            alParaval.Add(drname)
            alParaval.Add(note)
            alParaval.Add(qty)
            alParaval.Add(rate)
            alParaval.Add(amount)

            Dim objclsNP As New ClsExpenseVoucher
            objclsNP.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsNP.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPEXPNO)
                IntResult = objclsNP.Update()
                MsgBox("Details Updated")
            End If
            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Enter Register Name")
                bln = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If


            If txtrefno.Text.Trim.Length = 0 Then
                EP.SetError(txtrefno, "Please Fill Party Bill No.")
                bln = False
            End If

            If gridGRN.RowCount = 0 Then
                EP.SetError(txtamt, "Please Fill Proper Entries")
                bln = False
            End If


            If Not datecheck(npdate.Value) Then
                EP.SetError(npdate, "Date Not in Current Accounting Year")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            'If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub total()

        lbltotalqty.Text = 0.0
        lbltotalamt.Text = 0.0
        txttax.Text = 0.0
        txtroundoff.Text = 0.0

        If gridGRN.RowCount > 0 Then
            For Each row As DataGridViewRow In gridGRN.Rows
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(3).Value), "0.00")
                lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(5).Value), "0.00")
            Next

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                txttax.Text = Format(Val(Val(dt.Rows(0).Item(1)) * Val(lbltotalamt.Text)) / 100, "0.00")
            End If
            txtgrandtotal.Text = Format(Val(lbltotalamt.Text) + Val(txttax.Text), "0")

            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(lbltotalamt.Text) + Val(txttax.Text)), "0.00")
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
        End If

    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridGRN.RowCount = 0
            TEMPEXPNO = Val(TXTNP.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPEXPNO > 0 Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridGRN.RowCount = 0
            TEMPEXPNO = Val(TXTNP.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno()
            clear()
            If Val(TXTNP.Text) - 1 >= TEMPEXPNO Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
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
            Dim objNPdetails As New ExpenseVoucherDetails
            objNPdetails.MdiParent = MDIMain
            objNPdetails.Show()
            objNPdetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId
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
            'If cmbname.Text.Trim <> "" Then LEDGERVALIDATE(cmbname, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub npdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles npdate.Validating
        If Not datecheck(npdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'EXPENSE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURregabbr = dt.Rows(0).Item(0).ToString
                    PURreginitial = dt.Rows(0).Item(1).ToString
                    PURregid = dt.Rows(0).Item(2)
                    getmaxno()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdrname.GotFocus
        Try
            If cmbdrname.Text.Trim = "" Then fillledger(cmbdrname, edit, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' and GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbdrname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbdrname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdrname.Validating
        Try
            If cmbdrname.Text.Trim <> "" Then ledgervalidate(cmbdrname, CMBDRCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' and GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        If Val(TXTQTY.Text) > 0 And Val(TXTRATE.Text) > 0 Then
            txtamt.Text = Val(TXTQTY.Text) * Val(TXTRATE.Text)
        End If
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try
            If (edit = False And txtrefno.Text.Trim.Length > 0) Or (edit = True And LCase(txtrefno.Text.Trim) <> LCase(partyref)) Then
                If VALIDATEREFNO() = False Then
                    MsgBox("Party Ref. Already Exists", MsgBoxStyle.Critical, "MNOWF")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function VALIDATEREFNO() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(partyref) <> txtrefno.Text.Trim) Then
                'for search
                Dim objclscommon As New ClsCommon()
                Dim dt As New DataTable
                dt = objclscommon.search(" NONPURCHASE.NP_refno, LEDGERS.ACC_cmpname", "", " dbo.NONPURCHASE INNER JOIN dbo.LEDGERS ON dbo.LEDGERS.ACC_id = dbo.NONPURCHASE.NP_ledgerid AND dbo.NONPURCHASE.NP_cmpid = dbo.LEDGERS.ACC_cmpid AND dbo.NONPURCHASE.NP_locationid = dbo.LEDGERS.ACC_locationid AND dbo.NONPURCHASE.NP_yearid = dbo.LEDGERS.ACC_yearid ", " and NONPURCHASE.NP_refno = '" & txtrefno.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' and dbo.NONPURCHASE.NP_cmpid=" & CmpId & " and dbo.NONPURCHASE.NP_locationid=" & Locationid & " and dbo.NONPURCHASE.NP_yearid=" & YearId)
                If dt.Rows.Count > 0 Then BLN = False
            End If
            Return BLN
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridGRN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridGRN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If temprow = gridGRN.CurrentRow.Index And gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridGRN.Rows.RemoveAt(gridGRN.CurrentRow.Index)
                total()
                getsrno(gridGRN)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtamount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamt.Validating
        Try
            If cmbdrname.Text.Trim <> "" And Val(txtamt.Text.Trim) <> 0 And txtsrno.Text.Trim > 0 Then
                fillgrid()
                total()
            Else
                MsgBox("Fill Proper Details", MsgBoxStyle.Critical, "MNOWF")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridGRN.Enabled = True
        If gridDoubleClick = False Then
            gridGRN.Rows.Add(Val(txtsrno.Text.Trim), cmbdrname.Text.Trim, txtnote.Text.Trim, Val(TXTQTY.Text.Trim), Val(TXTRATE.Text.Trim), Val(txtamt.Text.Trim))
            getsrno(gridGRN)
        ElseIf gridDoubleClick = True Then

            gridGRN.Item(0, temprow).Value = txtsrno.Text.Trim
            gridGRN.Item(1, temprow).Value = cmbdrname.Text.Trim
            gridGRN.Item(2, temprow).Value = txtnote.Text.Trim
            gridGRN.Item(3, temprow).Value = TXTQTY.Text.Trim
            gridGRN.Item(4, temprow).Value = TXTRATE.Text.Trim
            gridGRN.Item(5, temprow).Value = txtamt.Text.Trim
            gridDoubleClick = False

        End If
        gridGRN.FirstDisplayedScrollingRowIndex = gridGRN.RowCount - 1

        txtsrno.Clear()
        cmbdrname.Text = ""
        txtnote.Text = ""
        TXTQTY.Clear()
        TXTRATE.Clear()
        txtamt.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridGRN.CellDoubleClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridGRN.Item(0, e.RowIndex).Value <> Nothing Then

            gridDoubleClick = True
            txtsrno.Text = gridGRN.Item(0, e.RowIndex).Value
            cmbdrname.Text = gridGRN.Item(1, e.RowIndex).Value
            txtnote.Text = gridGRN.Item(2, e.RowIndex).Value.ToString
            TXTQTY.Text = gridGRN.Item(3, e.RowIndex).Value.ToString
            TXTRATE.Text = gridGRN.Item(4, e.RowIndex).Value.ToString
            txtamt.Text = gridGRN.Item(5, e.RowIndex).Value.ToString
            temprow = e.RowIndex
            txtsrno.Focus()

        End If
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridGRN.RowCount > 0 Then
                txtsrno.Text = Val(gridGRN.Rows(gridGRN.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridGRN.RowCount = 0
            TEMPEXPNO = Val(tstxtbillno.Text)
            If TEMPEXPNO > 0 Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub partybilldate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles partybilldate.Validating
        If Not datecheck(partybilldate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
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

                Dim tempmsg As Integer = MsgBox("Delete Contra Entry Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                If tempmsg = vbYes Then

                    Dim OBJNONPURCHASE As New ClsExpenseVoucher
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPEXPNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJNONPURCHASE.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJNONPURCHASE.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class