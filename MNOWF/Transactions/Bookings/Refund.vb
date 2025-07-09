
Imports BL

Public Class Refund

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPREFUNDNO As Integer
    Public Shared SELECTDOC As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()

        TXTREFUNDNO.Clear()
        cmdselectdoc.Enabled = True
        TXTBOOKINGNO.Clear()
        REFUNDDATE.Value = Mydate

        TXTOFFICERNAME.Clear()
        TXTCMPNAME.Clear()
        TXTRANK.Clear()
        TXTEMPCODE.Clear()
        TXTMUINO.Clear()
        TXTAMT.Clear()
        TXTDEPOSIT.Clear()
        TXTREFUND.Clear()

        TXTBANK.Clear()
        TXTBRANCH.Clear()
        TXTACNAME.Clear()
        TXTACNO.Clear()
        TXTBANKADD.Clear()

        TXTAMTREC.Clear()
        TXTEXTRAAMT.Clear()
        TXTRETURN.Clear()
        TXTBALANCE.Clear()

        CMDSHOWDETAILS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        PBPAID.Visible = False

        GETMAX_REFUNDNO()

    End Sub

    Sub GETMAX_REFUNDNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(REFUND_NO),0) + 1 ", "REFUNDMASTER", " AND REFUND_cmpid=" & CmpId & " AND REFUND_LOCATIONid=" & Locationid & " AND REFUND_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTREFUNDNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub CMDSELECTDOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectdoc.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDOC.Clear()
            Dim OBJSELECTBOOK As New SelectBookings
            SELECTDOC = OBJSELECTBOOK.DT
            OBJSELECTBOOK.ShowDialog()

            Dim i As Integer = 0
            If SELECTDOC.Rows.Count > 0 Then
                TXTBOOKINGNO.Text = SELECTDOC.Rows(0).Item("BOOKINGNO")
                TXTOFFICERNAME.Text = SELECTDOC.Rows(0).Item("NAME")
                TXTCMPNAME.Text = SELECTDOC.Rows(0).Item("CMPNAME")
                TXTRANK.Text = SELECTDOC.Rows(0).Item("RANK")
                TXTEMPCODE.Text = SELECTDOC.Rows(0).Item("EMPCODE")
                TXTMUINO.Text = SELECTDOC.Rows(0).Item("MUINO")
                TXTAMT.Text = Format(Val(SELECTDOC.Rows(0).Item("AMT")), "0.00")
                TXTDEPOSIT.Text = Format(Val(SELECTDOC.Rows(0).Item("DEPOSIT")), "0.00")
                TXTREFUND.Focus()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Refund_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim OBJREFUND As New RefundDetails
            OBJREFUND.MdiParent = MDIMain
            OBJREFUND.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Refund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub Refund_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL BOOKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJREFUND As New ClsRefund()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPREFUNDNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJREFUND.alParaval = ALPARAVAL
                dt = OBJREFUND.SELECTREFUND()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTREFUNDNO.Text = TEMPREFUNDNO
                        REFUNDDATE.Value = Convert.ToDateTime(dr("DATE")).Date
                        TXTBOOKINGNO.Text = dr("BOOKINGNO")
                        cmdselectdoc.Enabled = False

                        TXTOFFICERNAME.Text = dr("OFFICERNAME")
                        TXTCMPNAME.Text = dr("CMPNAME")
                        TXTRANK.Text = dr("RANK")
                        TXTEMPCODE.Text = dr("EMPCODE")
                        TXTMUINO.Text = dr("MUINO")

                        TXTAMT.Text = dr("AMT")
                        TXTDEPOSIT.Text = dr("DEPOSIT")
                        TXTREFUND.Text = dr("REFUND")

                        TXTAMTREC.Text = dr("AMTPAID")
                        TXTEXTRAAMT.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("RETURN")
                        TXTBALANCE.Text = dr("BALANCE")

                        TXTBANK.Text = dr("BANK")
                        TXTBRANCH.Text = dr("BRANCH")
                        TXTACNAME.Text = dr("ACNAME")
                        TXTACNO.Text = dr("ACNO")
                        TXTBANKADD.Text = dr("BANKADD")


                        If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    chkchange.CheckState = CheckState.Checked
                    TXTREFUND.Focus()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            ToolStripdelete_Click(sender, e)
            DELETE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles REFUNDDATE.Validating
        If Not datecheck(REFUNDDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(REFUNDDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTBOOKINGNO.Text.Trim)
            alParaval.Add(TXTOFFICERNAME.Text.Trim)
            alParaval.Add(Val(TXTAMT.Text.Trim))
            alParaval.Add(Val(TXTDEPOSIT.Text.Trim))
            alParaval.Add(Val(TXTREFUND.Text.Trim))

            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBALANCE.Text.Trim))

            alParaval.Add(TXTBANK.Text.Trim)
            alParaval.Add(TXTBRANCH.Text.Trim)
            alParaval.Add(TXTACNAME.Text.Trim)
            alParaval.Add(TXTACNO.Text.Trim)
            alParaval.Add(TXTBANKADD.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJREFUND As New ClsRefund
            OBJREFUND.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJREFUND.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPREFUNDNO)
                DT = OBJREFUND.update()
                MsgBox("Details Updated")
            End If


            'OPEN PAYMENT FORM DIRECTLY 
            If Val(TXTREFUND.Text.Trim) > 0 And edit = False Then
                Dim TEMPMSG As Integer = MsgBox("Add Payment?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJPAY As New PaymentMaster
                    OBJPAY.TEMPAUTOENTRY = True
                    OBJPAY.TEMPAMT = Val(TXTREFUND.Text.Trim)
                    OBJPAY.TEMPREGISTER = "REFUND REGISTER"
                    OBJPAY.TEMPBILLNO = "REF-" & DT.Rows(0).Item(0)
                    OBJPAY.TEMPNAME = TXTOFFICERNAME.Text.Trim
                    OBJPAY.MdiParent = MDIMain
                    OBJPAY.Show()
                End If
            End If


            clear()
            edit = False
            TXTREFUND.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTAMT.Text.Trim) = 0 Then
            EP.SetError(TXTAMT, "Amount Cannot be 0")
            bln = False
        End If

        If Val(TXTDEPOSIT.Text.Trim) = 0 Then
            EP.SetError(TXTDEPOSIT, "Deposit Cannot be 0")
            bln = False
        End If

        If Val(TXTREFUND.Text.Trim) = 0 Then
            EP.SetError(TXTREFUND, "Refund Cannot be 0")
            bln = False
        End If

        If Val(TXTREFUND.Text.Trim) > Val(TXTDEPOSIT.Text.Trim) Then
            EP.SetError(TXTREFUND, "Refund Cannot be greater then Deposit")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Amount Refunded, Refund Locked")
            bln = False
        End If

        If Val(TXTBOOKINGNO.Text.Trim) = 0 Then
            EP.SetError(TXTBOOKINGNO, "Select Booking")
            bln = False
        End If


        If Not datecheck(REFUNDDATE.Value) Then
            EP.SetError(REFUNDDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPREFUNDNO = Val(TXTREFUNDNO.Text) + 1
            GETMAX_REFUNDNO()
            clear()
            If Val(TXTREFUNDNO.Text) - 1 >= TEMPREFUNDNO Then
                edit = True
                Refund_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPREFUNDNO = Val(TXTREFUNDNO.Text) - 1
            If TEMPREFUNDNO > 0 Then
                edit = True
                Refund_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
    End Sub

    Sub DELETE()
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            TEMPREFUNDNO = Val(tstxtbillno.Text)
            If TEMPREFUNDNO > 0 Then
                edit = True
                Refund_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREFUND_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREFUND.KeyPress
        numdotkeypress(e, TXTREFUND, Me)
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If edit = True Then
                Dim OBJPAY As New ShowRecPay
                OBJPAY.MdiParent = MDIMain

                'GETTING INITIALS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" REFUND_NO AS INITIALS ", "", " REFUNDMASTER", " AND REFUND_NO = " & TEMPREFUNDNO & " AND REFUND_CMPID = " & CmpId & " AND REFUND_LOCATIONID = " & Locationid & " AND REFUND_YEARID = " & YearId)
                OBJPAY.PURBILLINITIALS = "REF-" & DT.Rows(0).Item(0)
                OBJPAY.SALEBILLINITIALS = "REF-" & DT.Rows(0).Item(0)
                OBJPAY.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTACNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTACNAME.Validated
        pcase(TXTACNAME)
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
End Class