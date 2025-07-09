
Imports BL

Public Class Booking

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPBOOKNO As Integer
    Public TEMPREG As String
    Public Shared SELECTDOC As New DataTable
    Dim GRIDDOUBLECLICK As Boolean
    Dim temprow As Integer
    Public TEMPCONTACTPERSON As Integer


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub TOTAL()
        Try
            TXTGTOTAL.Text = Format(Val(TXTAMT.Text.Trim) + Val(TXTDEPOSIT.Text.Trim), "0.00")
            If Val(TXTGTOTAL.Text.Trim) > 0 Then TXTINWORDS.Text = CurrencyToWord(Val(TXTGTOTAL.Text.Trim))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            FILLOFFICER(CMBNAME, edit)
            fillHOTEL(CMBHOTEL, "")
            FILLRELATION(CMBRELATION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()

        TXTINWARDNO.Clear()
        cmdselectdoc.Enabled = True
        TXTSENTBY.Clear()
        RECDATE.Value = Mydate

        TXTBOOKINGNO.Clear()
        BOOKDATE.Value = Mydate

        CMBNAME.Text = ""
        CMBNAME.Enabled = True

        TXTCMPNAME.Clear()
        TXTRANK.Clear()
        TXTEMPCODE.Clear()
        TXTMUINO.Clear()
        CMBINSAFOSMA.Text = ""

        CMBHOTEL.Text = ""

        ARRDATE.Value = Mydate
        DEPARTUREDATE.Value = DateAdd(DateInterval.Day, 1, Mydate)

        TXTROOMS.Text = 1
        TXTPAX.Clear()
        TXTAMT.Clear()
        TXTDEPOSIT.Clear()
        TXTBANKNAME.Clear()
        TXTCHQNO.Clear()
        CHQDATE.Value = Mydate
        TXTNIGHTS.Text = 1

        TXTSRNO.Clear()
        TXTNAME.Clear()
        TXTAGE.Clear()
        CMBRELATION.Text = ""
        GRIDPAX.RowCount = 0
        GRIDBOOKINGS.RowCount = 0
        GRIDBOOKINGS.ColumnCount = 0

        TXTINWORDS.Clear()
        TXTREMARKS.Clear()

        GETMAX_BOOKNO()

        lbllocked.Visible = False
        PBlock.Visible = False
        PBRECD.Visible = False
        PBREFUND.Visible = False
        LBLCLOSED.Visible = False
        LBLWHATSAPP.Visible = False

    End Sub

    Sub GETMAX_BOOKNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(BOOKING_NO),0) + 1 ", "BOOKINGMASTER", " AND BOOKING_cmpid=" & CmpId & " AND BOOKING_LOCATIONid=" & Locationid & " AND BOOKING_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTBOOKINGNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub CMDSELECTDOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectdoc.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            SELECTDOC.Clear()
            Dim OBJSELECTIN As New SelectInward
            OBJSELECTIN.frmstring = "BOOK"
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

    Private Sub Bookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            Dim OBJBOOKING As New BookingDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Bookings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub Bookings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL BOOKING'")
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
                Dim OBJBOOKING As New ClsBooking()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPBOOKNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                dt = OBJBOOKING.SELECTBOOKING()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTBOOKINGNO.Text = TEMPBOOKNO
                        cmbregister.Text = TEMPREG
                        BOOKDATE.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                        TXTINWARDNO.Text = dr("INWARDNO")
                        cmdselectdoc.Enabled = False

                        TXTSENTBY.Text = dr("SENTBY")
                        RECDATE.Value = Convert.ToDateTime(dr("RECDATE")).Date

                        CMBNAME.Text = dr("NAME")
                        'CMBNAME.Enabled = False

                        TXTCMPNAME.Text = dr("CMPNAME")
                        TXTRANK.Text = dr("RANK")
                        TXTEMPCODE.Text = dr("EMPCODE")
                        TXTMUINO.Text = dr("MUINO")
                        CMBINSAFOSMA.Text = dr("INSAFOSMA")

                        CMBHOTEL.Text = dr("HOTELNAME")
                        ARRDATE.Value = Convert.ToDateTime(dr("ARRIVAL")).Date
                        DEPARTUREDATE.Value = Convert.ToDateTime(dr("DEPARTURE")).Date

                        TXTROOMS.Text = dr("ROOMS")
                        TXTPAX.Text = dr("PAX")
                        TXTNIGHTS.Text = dr("NIGHTS")
                        TXTAMT.Text = dr("AMT")
                        TXTDEPOSIT.Text = dr("DEPOSIT")
                        TXTBANKNAME.Text = dr("BANKNAME")
                        TXTCHQNO.Text = dr("CHQNO")
                        CHQDATE.Value = Convert.ToDateTime(dr("CHQDATE")).Date
                        TXTGTOTAL.Text = Format(Val(TXTAMT.Text.Trim) + Val(TXTDEPOSIT.Text.Trim), "0.00")

                        TXTAMTREC.Text = dr("AMTREC")
                        TXTEXTRAAMT.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("RETURN")
                        TXTBALANCE.Text = dr("BALANCE")


                        If Val(dr("AMTREC")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBRECD.Visible = True
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

                        If Convert.ToBoolean(dr("REFUNDED")) = True Then
                            lbllocked.Visible = True
                            PBREFUND.Visible = True
                        End If

                        GRIDPAX.Rows.Add(dr("GRIDSRNO"), dr("PAXNAME"), Val(dr("AGE")), dr("RELATION"))
                        If Convert.ToBoolean(dr("SENDWHATSAPP")) = True Then LBLWHATSAPP.Visible = True
                    Next
                    cmbregister.Enabled = False
                    GETROOMS()
                    TXTINWORDS.Text = CurrencyToWord(Val(TXTAMT.Text.Trim))
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

    Private Sub ARRDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ARRDATE.Validating
        'If Not datecheck(ARRDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
        TOTALNIGHTS()
        GETROOMS()
    End Sub

    Private Sub BOOKDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BOOKDATE.Validating
        'If Not datecheck(BOOKDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub DEPARTUREDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEPARTUREDATE.Validating
        'If Not datecheck(DEPARTUREDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
        TOTALNIGHTS()
        GETROOMS()
    End Sub

    Sub GETROOMS()
        Try

            If CMBHOTEL.Text.Trim <> "" And ARRDATE.Value.Date < DEPARTUREDATE.Value.Date Then

                GRIDBOOKINGS.RowCount = 0
                GRIDBOOKINGS.ColumnCount = 0

                'ADDING COLUMS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER INNER JOIN HOTELMASTER_ROOMDESC ON HOTELMASTER.HOTEL_ID = HOTELMASTER_ROOMDESC.HOTEL_ID AND HOTELMASTER.HOTEL_CMPID = HOTELMASTER_ROOMDESC.HOTEL_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = HOTELMASTER_ROOMDESC.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME ='" & CMBHOTEL.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        Dim OBJ As New DataGridViewCheckBoxColumn
                        OBJ.Name = "G" & ROW("ROOMTYPE")
                        OBJ.HeaderText = ROW("ROOMTYPE")
                        OBJ.Width = 90
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        GRIDBOOKINGS.Columns.Add(OBJ)
                    Next
                End If


                'ADDING ROWS
                For I As Integer = 0 To DateDiff(DateInterval.Day, ARRDATE.Value.Date, DEPARTUREDATE.Value.Date) - 1
                    GRIDBOOKINGS.Rows.Add()
                    GRIDBOOKINGS.Rows(I).HeaderCell.Value = Format(DateAdd(DateInterval.Day, I, ARRDATE.Value.Date), "dd/MM/yy")
                Next
                GRIDBOOKINGS.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GRIDBOOKINGS.RowHeadersWidth = 90


                'SET READ ONLY TO FILLED ROOMS
                DT = OBJCMN.search("ROOMNO, BDATE, BOOKINGNO", "", " INVENTORY", " AND HOTELNAME = '" & CMBHOTEL.Text.Trim & "' AND BDATE BETWEEN '" & Format(ARRDATE.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(DEPARTUREDATE.Value.Date, "MM/dd/yyyy") & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                        For Each COL As DataGridViewColumn In GRIDBOOKINGS.Columns
                            Dim DTROW() As DataRow = DT.Select("BDATE = '" & Convert.ToDateTime(ROW.HeaderCell.Value).Date & "'")
                            If DTROW.Length > 0 Then
                                For I As Integer = 0 To DTROW.Count - 1
                                    If DTROW(I).Item("ROOMNO") = COL.HeaderText Then
                                        ROW.Cells(COL.Index).ReadOnly = True
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        If edit = True And DTROW(I).Item("BOOKINGNO") = TEMPBOOKNO Then
                                            ROW.Cells(COL.Index).ReadOnly = False
                                            ROW.Cells(COL.Index).Value = True
                                            ROW.Cells(COL.Index).Style.BackColor = Color.LightGreen
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If


                GRIDBOOKINGS.ClearSelection()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In GRIDPAX.Rows
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

            alParaval.Add(Format(BOOKDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTINWARDNO.Text.Trim)
            alParaval.Add(cmbregister.Text.Trim)

            alParaval.Add(TXTSENTBY.Text.Trim)
            alParaval.Add(Format(RECDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBINSAFOSMA.Text.Trim)
            alParaval.Add(CMBHOTEL.Text.Trim)
            alParaval.Add(Format(ARRDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(DEPARTUREDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTROOMS.Text.Trim)
            alParaval.Add(TXTPAX.Text.Trim)
            alParaval.Add(TXTNIGHTS.Text.Trim)
            alParaval.Add(Val(TXTAMT.Text.Trim))
            alParaval.Add(Val(TXTDEPOSIT.Text.Trim))
            alParaval.Add(TXTBANKNAME.Text.Trim)
            alParaval.Add(TXTCHQNO.Text.Trim)
            alParaval.Add(Format(CHQDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTINWORDS.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim PAXNAME As String = ""
            Dim AGE As String = ""
            Dim RELATION As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPAX.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        PAXNAME = row.Cells(GNAME.Index).Value
                        AGE = row.Cells(GAGE.Index).Value.ToString
                        RELATION = row.Cells(GRELATION.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        PAXNAME = PAXNAME & "," & row.Cells(GNAME.Index).Value
                        AGE = AGE & "," & row.Cells(GAGE.Index).Value.ToString
                        RELATION = RELATION & "," & row.Cells(GRELATION.Index).Value

                    End If
                End If
            Next


            alParaval.Add(GRIDSRNO)
            alParaval.Add(PAXNAME)
            alParaval.Add(AGE)
            alParaval.Add(RELATION)

            Dim ROOMNO As String = ""
            Dim BDATE As String = ""
            For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                For Each COL As DataGridViewColumn In GRIDBOOKINGS.Columns
                    If Convert.ToBoolean(ROW.Cells(COL.Index).Value) = True Then
                        If ROOMNO = "" Then
                            ROOMNO = COL.HeaderText
                            BDATE = Format(Convert.ToDateTime(ROW.HeaderCell.Value).Date, "MM/dd/yyyy")
                        Else
                            ROOMNO = ROOMNO & "," & COL.HeaderText
                            BDATE = BDATE & "," & Format(Convert.ToDateTime(ROW.HeaderCell.Value).Date, "MM/dd/yyyy")
                        End If
                    End If
                Next
            Next


            If ROOMNO = "" Or BDATE = "" Then
                EP.SetError(DEPARTUREDATE, "Select Rooms")
                Exit Sub
            End If

            alParaval.Add(ROOMNO)
            alParaval.Add(BDATE)


            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBALANCE.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJBOOKING As New ClsBooking
            OBJBOOKING.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJBOOKING.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBOOKNO)
                DT = OBJBOOKING.update()
                MsgBox("Details Updated")
            End If


            Dim TEMPMSG As Integer = MsgBox("Print Allotment Letter?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJBOOK As New BookingDesign
                OBJBOOK.BOOKINGNO = DT.Rows(0).Item(0)
                OBJBOOK.MdiParent = MDIMain
                OBJBOOK.Show()
            End If


            'OPEN RECEIPT FORM DIRECTLY 
            If Val(TXTGTOTAL.Text.Trim) > 0 And edit = False Then
                TEMPMSG = MsgBox("Add Receipt?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJREC As New Receipt
                    OBJREC.TEMPAUTOENTRY = True
                    OBJREC.TEMPAMT = Val(TXTGTOTAL.Text.Trim)

                    'GETTING INITIALS
                    Dim OBJCMN As New ClsCommon
                    Dim DTN As DataTable = OBJCMN.search(" BOOKING_INITIALS ", "", " BOOKINGMASTER", " AND BOOKING_NO = " & DT.Rows(0).Item(0) & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                    OBJREC.TEMPBILLNO = DTN.Rows(0).Item(0)
                    OBJREC.TEMPNAME = CMBNAME.Text.Trim
                    OBJREC.TEMPBANKNAME = TXTBANKNAME.Text.Trim
                    OBJREC.TEMPCHQNAME = TXTCHQNO.Text.Trim
                    OBJREC.TEMPACCNAME = "Saving Bank A/C - B O I - Mumbai"
                    OBJREC.MdiParent = MDIMain
                    OBJREC.Show()
                End If
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

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register")
            bln = False
        End If

        'as per requirement
        'If TXTINWARDNO.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTINWARDNO, "Select Inward Document")
        '    bln = False
        'End If

        'If TXTSENTBY.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTSENTBY, "Select Inward Document")
        '    bln = False
        'End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Booking Closed, Booking Locked")
            bln = False
        End If

        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Booking Cleared, Booking Locked")
        '    bln = False
        'End If

        If PBREFUND.Visible = True Then
            EP.SetError(PBREFUND, "Booking Closed, Amt Refunded")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Officer's Name")
            bln = False
        End If

        If CMBHOTEL.Text.Trim.Length = 0 Then
            EP.SetError(CMBHOTEL, "Select Hotel Name")
            bln = False
        End If

        If Val(TXTAMT.Text.Trim) = 0 Then
            EP.SetError(TXTAMT, "Amount Cannot be 0")
            bln = False
        End If

        If Val(TXTROOMS.Text.Trim) = 0 Then
            EP.SetError(TXTROOMS, "Rooms Cannot be 0")
            bln = False
        End If

        If Val(TXTPAX.Text.Trim) = 0 Then
            EP.SetError(TXTPAX, "Dependants Cannot be 0")
            bln = False
        End If

        If Val(TXTPAX.Text.Trim) <> GRIDPAX.RowCount Then
            EP.SetError(TXTPAX, "No. Of Dependants in Grid does not Match")
            bln = False
        End If

        If Val(TXTNIGHTS.Text.Trim) = 0 Then
            EP.SetError(TXTNIGHTS, "Nights Cannot be 0")
            bln = False
        End If

        If GRIDPAX.RowCount = 0 Then
            EP.SetError(CMBRELATION, "Enter No. Of Dependants")
            bln = False
        End If

        'If Not datecheck(BOOKDATE.Value) Then
        '    EP.SetError(BOOKDATE, "Date Not in Current Accounting Year")
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


        'CHECKING ROOMS VALIDATIONS
        'CHECK WHETHER ROOMS AS SELECTED IN ALL ROWS OR NOT
        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            For Each COL As DataGridViewColumn In GRIDBOOKINGS.Columns
                If ROW.Cells(COL.Index).Value = True Then
                    bln = True
                    GoTo LINE1
                Else
                    bln = False
                End If
            Next
            If bln = False Then
                EP.SetError(TXTROOMS, "Select Proper Rooms")
                Exit For
            End If
LINE1:
        Next
        'CHECK WHETHER ROOMS SELECTED AS NOT GREATER OR LESS THEN SPECIFIED ROOMS
        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            Dim TROOMS As Integer = 0
            For Each COL As DataGridViewColumn In GRIDBOOKINGS.Columns
                If ROW.Cells(COL.Index).Value = True Then TROOMS += 1
            Next
            If TROOMS <> Val(TXTROOMS.Text.Trim) Then
                EP.SetError(TXTROOMS, "Select Proper Rooms")
                bln = False
            End If
        Next


        If ARRDATE.Value.Date > DEPARTUREDATE.Value.Date Then
            EP.SetError(DEPARTUREDATE, "Check-Out Date Cannot be after Check-In Date")
            bln = False
        End If

        Return bln

    End Function

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, edit)
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
            If CMBNAME.Text.Trim <> "" And edit = False Then
                Dim OBJOFFICER As New ClsOfficerMaster
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(CMBNAME.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJOFFICER.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJOFFICER.GETOFFICER
                If DT.Rows.Count > 0 Then
                    GRIDPAX.RowCount = 0
                    For Each ROW As DataRow In DT.Rows
                        TXTRANK.Text = ROW("RANK")
                        TXTCMPNAME.Text = ROW("COMPANY")
                        TXTEMPCODE.Text = ROW("EMPCODE")
                        TXTMUINO.Text = ROW("MUINO")
                        If ROW("SRNO") <> 0 Then GRIDPAX.Rows.Add(0, ROW("FAMILY"), ROW("AGE"), ROW("RELATION"))
                    Next
                    getsrno()
                End If

                'CMBNAME.Enabled = False

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then OFFICERVALIDATE(CMBNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPAX.RowCount = 0
LINE1:
            TEMPBOOKNO = Val(TXTBOOKINGNO.Text) + 1
            TEMPREG = cmbregister.Text.Trim
            GETMAX_BOOKNO()
            Dim MAXNO As Integer = TXTBOOKINGNO.Text.Trim
            clear()
            If Val(TXTBOOKINGNO.Text) - 1 >= TEMPBOOKNO Then
                edit = True
                Bookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDPAX.RowCount = 0 And TEMPBOOKNO < MAXNO Then
                TXTBOOKINGNO.Text = TEMPBOOKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDPAX.RowCount = 0
LINE1:
            TEMPBOOKNO = Val(TXTBOOKINGNO.Text) - 1
            TEMPREG = cmbregister.Text.Trim
            If TEMPBOOKNO > 0 Then
                edit = True
                Bookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDPAX.RowCount = 0 And TEMPBOOKNO > 1 Then
                TXTBOOKINGNO.Text = TEMPBOOKNO
                GoTo LINE1
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

            If lbllocked.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Wish to Delete Booking?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJBOOKING As New ClsBooking
            OBJBOOKING.alParaval.Add(TEMPBOOKNO)
            OBJBOOKING.alParaval.Add(YearId)

            Dim DTTABLE As DataTable = OBJBOOKING.Delete()
            MsgBox("Bookings Deleted", MsgBoxStyle.Critical)
            edit = False
            clear()
            BOOKDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDPAX.RowCount = 0
            TEMPBOOKNO = Val(tstxtbillno.Text)
            TEMPREG = cmbregister.Text.Trim
            If TEMPBOOKNO > 0 Then
                edit = True
                Bookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTALNIGHTS()
        Try
            If ARRDATE.Value.Date < DEPARTUREDATE.Value.Date Then
                TXTNIGHTS.Text = DateDiff(DateInterval.Day, ARRDATE.Value.Date, DEPARTUREDATE.Value.Date)
            Else
                MsgBox("Departure Date Cannot be after Arrival Date")
            End If
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

                Dim TEMPMSG As Integer = MsgBox("Wish to Pospone Booking?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are You sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim OBJBOOKING As New ClsBooking
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPBOOKNO)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJBOOKING.CLOSE()

                        MsgBox("Booking Postpone.....")
                        BOOKDATE.Focus()

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
                Dim OBJPAY As New ShowRecPay
                OBJPAY.MdiParent = MDIMain

                'GETTING INITIALS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_INITIALS AS INITIALS ", "", " BOOKINGMASTER", " AND BOOKING_NO = " & TEMPBOOKNO & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                OBJPAY.PURBILLINITIALS = DT.Rows(0).Item(0)
                OBJPAY.SALEBILLINITIALS = DT.Rows(0).Item(0)
                OBJPAY.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Enter
        Try
            If CMBHOTEL.Text.Trim = "" Then fillHOTEL(CMBHOTEL, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTEL.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Validated
        Try
            GETROOMS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTEL.Validating
        Try
            If CMBHOTEL.Text.Trim <> "" Then HOTELvalidate(CMBHOTEL, CMBCODE, e, Me, TXTADD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROOMS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROOMS.KeyPress, TXTCOPY.KeyPress, tstxtbillno.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROOMS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTROOMS.Validated
        Try
            If Val(TXTROOMS.Text.Trim) > 0 Then TOTALNIGHTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        Try
            numdotkeypress(e, TXTAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAMT.Validated
        Try
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDPAX.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDPAX.Rows(GRIDPAX.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMBRELATION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRELATION.Enter
        Try
            If CMBRELATION.Text.Trim = "" Then FILLRELATION(CMBRELATION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRELATION.Validated
        Try
            If TXTSRNO.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)
            If TXTSRNO.Text.Trim.Length > 0 And TXTNAME.Text.Trim <> "" And CMBRELATION.Text.Trim <> "" Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDPAX.Rows.Add(TXTSRNO.Text.Trim, TXTNAME.Text.Trim, Val(TXTAGE.Text.Trim), CMBRELATION.Text.Trim)
                getsrno()
            Else
                GRIDPAX.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
                GRIDPAX.Item(GNAME.Index, temprow).Value = TXTNAME.Text.Trim
                GRIDPAX.Item(GAGE.Index, temprow).Value = Val(TXTAGE.Text.Trim)
                GRIDPAX.Item(GRELATION.Index, temprow).Value = CMBRELATION.Text.Trim
                
                GRIDDOUBLECLICK = False
            End If

            TXTSRNO.Clear()
            TXTNAME.Clear()
            TXTAGE.Clear()
            CMBRELATION.Text = ""
            TXTSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRELATION.Validating
        Try
            If CMBRELATION.Text.Trim <> "" Then RELATIONVALIDATE(CMBRELATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGE.KeyPress
        Try
            numkeypress(e, TXTAGE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPAX.KeyPress
        Try
            numkeypress(e, TXTPAX, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAX_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPAX.CellDoubleClick
        Try

            If e.RowIndex >= 0 And GRIDPAX.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPAX.Item(GSRNO.Index, e.RowIndex).Value.ToString
                TXTNAME.Text = GRIDPAX.Item(GNAME.Index, e.RowIndex).Value.ToString
                TXTAGE.Text = GRIDPAX.Item(GAGE.Index, e.RowIndex).Value.ToString
                CMBRELATION.Text = GRIDPAX.Item(GRELATION.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                TXTSRNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPAX.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPAX.Rows.RemoveAt(GRIDPAX.CurrentRow.Index)
                getsrno()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                With GRIDBOOKINGS.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If .ReadOnly = False Then
                        If .Value = True Then
                            .Value = False
                        Else
                            .Value = True
                        End If
                        GETAMT(e.ColumnIndex, .Value)
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETAMT(ByVal COL As Integer, ByVal VALUE As Boolean)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  ISNULL(HOTELMASTER_ROOMDESC.HOTEL_RATE,0) AS RATE", "", " HOTELMASTER INNER JOIN HOTELMASTER_ROOMDESC ON HOTELMASTER.HOTEL_ID = HOTELMASTER_ROOMDESC.HOTEL_ID AND HOTELMASTER.HOTEL_CMPID = HOTELMASTER_ROOMDESC.HOTEL_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = HOTELMASTER_ROOMDESC.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows(0).Item("RATE")) > 0 Then
                    If VALUE = True Then
                        TXTAMT.Text = Format(Val(TXTAMT.Text.Trim) + Val(DT.Rows(0).Item("RATE")), "0.00")
                    Else
                        TXTAMT.Text = Format(Val(TXTAMT.Text.Trim) - Val(DT.Rows(0).Item("RATE")), "0.00")
                    End If
                    TOTAL()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'BOOKING'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'BOOKING' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            GETMAX_BOOKNO()

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
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'BOOKING' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    GETMAX_BOOKNO()
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

    Private Sub TXTDEPOSIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDEPOSIT.KeyPress
        numdotkeypress(e, TXTDEPOSIT, Me)
    End Sub

    Private Sub TXTDEPOSIT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDEPOSIT.Validated
        Try
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True And PBRECD.Visible = True Then
                Dim OBJBOOK As New BookingDesign
                OBJBOOK.BOOKINGNO = TEMPBOOKNO
                OBJBOOK.MdiParent = MDIMain
                OBJBOOK.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            Dim DT As New DataTable
            Dim OBJBOOK As New ClsCommon

            If edit = True Then SENDWHATSAPP(TEMPBOOKNO)
            DT = OBJBOOK.Execute_Any_String("UPDATE BOOKINGMASTER SET BOOKING_SENDWHATSAPP = 1 FROM BOOKINGMASTER INNER JOIN REGISTERMASTER On BOOKINGMASTER.BOOKING_REGID = REGISTERMASTER.register_id WHERE BOOKING_NO = " & TEMPBOOKNO & " AND REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "'  AND BOOKING_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(TEMPBOOKNO As Integer)

        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub



            Dim WHATSAPPNO As String = ""
            Dim OBJWA As New BookingDesign
            OBJWA.MdiParent = MDIMain
            OBJWA.DIRECTPRINT = True
            OBJWA.FRMSTRING = "ALLOTMENTLETTER"
            OBJWA.DIRECTWHATSAPP = True
            OBJWA.OFFICERNAME = CMBNAME.Text.Trim
            OBJWA.FORMULA = "{BOOKINGMASTER.BOOKING_NO}=" & Val(TEMPBOOKNO) & " and {BOOKINGMASTER.BOOKING_yearid}=" & YearId
            OBJWA.BOOKINGNO = TEMPBOOKNO
            OBJWA.NOOFCOPIES = 1
            OBJWA.Show()
            OBJWA.Close()



            Dim OBJWHATSAPP As New SendWhatsapp
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(HOTEL_PERSON,'') AS CARETAKER, ISNULL(HOTEL_MOBILENO,'') AS MOBILENO", "", " HOTELMASTER", " AND HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND HOTEL_YEARID = " & YearId)
            OBJWHATSAPP.OFFICERNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.MSG = "Dear Sir,

We are Pleased to confirm your booking at our convalescent home *" & CMBHOTEL.Text.Trim & "*. 
Please find attached allotment letter no : *" & Val(TEMPBOOKNO) & "* Dated-*" & BOOKDATE.Text & "*, and instructions for your reference. Kindly contact the Caretaker, (" & DT.Rows(0).Item("CARETAKER") & "), on " & DT.Rows(0).Item("MOBILENO") & " for your convenience.

If you require further information, please feel free to reach out for assistance. On our email mail@mnowf.com or Telephone no:022 49680968 Mob No: 8828326202

Regards.
The Merchant Navy Officers’ Welfare Fund"
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\ALLOTMENTLETTER_" & Val(TEMPBOOKNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("ALLOTMENTLETTER_" & Val(TEMPBOOKNO) & ".pdf")




            'FOR ADDING RECEIPT 
            DT = OBJCMN.search("RECEIPT_NO AS RECNO, REGISTERMASTER.REGISTER_NAME AS REGNAME", "", " RECEIPTMASTER_DESC INNER JOIN BOOKINGMASTER ON BOOKING_INITIALS = RECEIPT_BILLINITIALS AND BOOKING_YEARID = receipt_yearid INNER JOIN  REGISTERMASTER ON receipt_registerid = register_id ", " AND BOOKINGMASTER.BOOKING_NO = " & Val(TEMPBOOKNO) & " AND BOOKINGMASTER.BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim OBJREC As New receipt_advice
                OBJREC.MdiParent = MDIMain
                OBJREC.DIRECTPRINT = True
                OBJREC.FRMSTRING = "BOOKING"
                OBJREC.DIRECTWHATSAPP = True
                OBJREC.OFFICERNAME = CMBNAME.Text.Trim
                OBJREC.FORMULA = " {receiptmaster.receipt_no}= " & Val(DT.Rows(0).Item("RECNO")) & " and {REGISTERMASTER.REGISTER_NAME}= '" & DT.Rows(0).Item("REGNAME") & "' and {receiptmaster.receipt_yearid}=" & YearId
                OBJREC.RECEIPTNO = Val(DT.Rows(0).Item("RECNO"))
                OBJREC.REGNAME = DT.Rows(0).Item("REGNAME")
                OBJREC.NOOFCOPIES = 1
                OBJREC.Show()
                OBJREC.Close()
                OBJWHATSAPP.PATH.Add(Application.StartupPath & "\RECEIPT VOUCHER_" & Val(DT.Rows(0).Item("RECNO")) & ".pdf")
                OBJWHATSAPP.FILENAME.Add("RECEIPT VOUCHER_" & Val(DT.Rows(0).Item("RECNO")) & ".pdf")
            End If


            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCARETAKERMSG_Click(sender As Object, e As EventArgs) Handles CMDCARETAKERMSG.Click
        Try
            Dim DT As New DataTable
            Dim OBJBOOK As New ClsCommon

            If edit = True Then SENDWHATSAPPCARETAKER(TEMPBOOKNO)
            DT = OBJBOOK.Execute_Any_String("UPDATE BOOKINGMASTER SET BOOKING_SENDWHATSAPP = 1 FROM BOOKINGMASTER INNER JOIN REGISTERMASTER On BOOKINGMASTER.BOOKING_REGID = REGISTERMASTER.register_id WHERE BOOKING_NO = " & TEMPBOOKNO & " AND REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "'  AND BOOKING_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPPCARETAKER(TEMPBOOKNO As Integer)

        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub



            Dim WHATSAPPNO As String = ""
            Dim OBJWA As New BookingDesign
            OBJWA.MdiParent = MDIMain
            OBJWA.DIRECTPRINT = True
            OBJWA.FRMSTRING = "ALLOTMENTLETTER"
            OBJWA.DIRECTWHATSAPP = True
            OBJWA.OFFICERNAME = CMBNAME.Text.Trim
            OBJWA.FORMULA = "{BOOKINGMASTER.BOOKING_NO}=" & Val(TEMPBOOKNO) & " and {BOOKINGMASTER.BOOKING_yearid}=" & YearId
            OBJWA.BOOKINGNO = TEMPBOOKNO
            OBJWA.NOOFCOPIES = 1
            OBJWA.Show()
            OBJWA.Close()


            'GET MOBILENO OF CARETAKER
            Dim OBJWHATSAPP As New SendWhatsapp
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(HOTEL_PERSON,'') AS CARETAKER, ISNULL(HOTEL_MOBILENO,'') AS MOBILENO", "", " HOTELMASTER", " AND HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then OBJWHATSAPP.AUTOCCNO = DT.Rows(0).Item("MOBILENO")
            OBJWHATSAPP.MSG = "Dear Mr. " & DT.Rows(0).Item("CARETAKER") & ",

We are Pleased to inform you that Officer *" & CMBNAME.Text.Trim & "* has booked a room at the Convalescent Home located at *" & CMBHOTEL.Text.Trim & "* under Allotment Letter No: *" & Val(TEMPBOOKNO) & " Dated-" & BOOKDATE.Text & "*. Please find the attached Allotment Letter for your reference. Kindly make arrangements accordingly to ensure his comfortable stay. 

Regards.
The Merchant Navy Officers’ Welfare Fund"
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\ALLOTMENTLETTER_" & Val(TEMPBOOKNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("ALLOTMENTLETTER_" & Val(TEMPBOOKNO) & ".pdf")




            ''FOR ADDING RECEIPT 
            'DT = OBJCMN.search("RECEIPT_NO AS RECNO, REGISTERMASTER.REGISTER_NAME AS REGNAME", "", " RECEIPTMASTER_DESC INNER JOIN BOOKINGMASTER ON BOOKING_INITIALS = RECEIPT_BILLINITIALS AND BOOKING_YEARID = receipt_yearid INNER JOIN  REGISTERMASTER ON receipt_registerid = register_id ", " AND BOOKINGMASTER.BOOKING_NO = " & Val(TEMPBOOKNO) & " AND BOOKINGMASTER.BOOKING_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    Dim OBJREC As New receipt_advice
            '    OBJREC.MdiParent = MDIMain
            '    OBJREC.DIRECTPRINT = True
            '    OBJREC.FRMSTRING = "REFPAYREP"
            '    OBJREC.DIRECTWHATSAPP = True
            '    OBJREC.OFFICERNAME = CMBNAME.Text.Trim
            '    OBJREC.FORMULA = " {receiptmaster.receipt_no}= " & Val(DT.Rows(0).Item("RECNO")) & " and {REGISTERMASTER.REGISTER_NAME}= '" & DT.Rows(0).Item("REGNAME") & "' and {receiptmaster.receipt_yearid}=" & YearId
            '    OBJREC.RECEIPTNO = Val(DT.Rows(0).Item("RECNO"))
            '    OBJREC.REGNAME = DT.Rows(0).Item("REGNAME")
            '    OBJREC.NOOFCOPIES = 1
            '    OBJREC.Show()
            '    OBJREC.Close()
            '    OBJWHATSAPP.PATH.Add(Application.StartupPath & "\RECEIPT VOUCHER_" & Val(DT.Rows(0).Item("RECNO")) & ".pdf")
            '    OBJWHATSAPP.FILENAME.Add("RECEIPT VOUCHER_" & Val(DT.Rows(0).Item("RECNO")) & ".pdf")
            'End If


            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBANKNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBANKNAME.Validated
        pcase(TXTBANKNAME)
    End Sub

    Private Sub CMDOCCUPANCY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOCCUPANCY.Click
        Try
            Dim OBJINV As New Inventory
            OBJINV.MdiParent = MDIMain
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(sender As Object, e As EventArgs) Handles TXTCOPY.Validated
        Try
            Dim dt As New DataTable
            Dim OBJBOOKING As New ClsBooking()
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJBOOKING.alParaval = ALPARAVAL
            dt = OBJBOOKING.SELECTBOOKING()

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows

                    BOOKDATE.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                    TXTINWARDNO.Text = dr("INWARDNO")

                    TXTSENTBY.Text = dr("SENTBY")
                    RECDATE.Value = Convert.ToDateTime(dr("RECDATE")).Date

                    CMBNAME.Text = dr("NAME")

                    TXTCMPNAME.Text = dr("CMPNAME")
                    TXTRANK.Text = dr("RANK")
                    TXTEMPCODE.Text = dr("EMPCODE")
                    TXTMUINO.Text = dr("MUINO")
                    CMBINSAFOSMA.Text = dr("INSAFOSMA")

                    CMBHOTEL.Text = dr("HOTELNAME")
                    ARRDATE.Value = Convert.ToDateTime(dr("ARRIVAL")).Date
                    DEPARTUREDATE.Value = Convert.ToDateTime(dr("DEPARTURE")).Date

                    TXTROOMS.Text = dr("ROOMS")
                    TXTPAX.Text = dr("PAX")
                    TXTNIGHTS.Text = dr("NIGHTS")
                    TXTAMT.Text = dr("AMT")
                    TXTDEPOSIT.Text = dr("DEPOSIT")
                    TXTBANKNAME.Text = dr("BANKNAME")
                    TXTCHQNO.Text = dr("CHQNO")
                    CHQDATE.Value = Convert.ToDateTime(dr("CHQDATE")).Date
                    TXTGTOTAL.Text = Format(Val(TXTAMT.Text.Trim) + Val(TXTDEPOSIT.Text.Trim), "0.00")

                    TXTAMTREC.Text = dr("AMTREC")
                    TXTEXTRAAMT.Text = dr("EXTRAAMT")
                    TXTRETURN.Text = dr("RETURN")
                    TXTBALANCE.Text = dr("BALANCE")

                    TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))

                    GRIDPAX.Rows.Add(dr("GRIDSRNO"), dr("PAXNAME"), Val(dr("AGE")), dr("RELATION"))
                Next
                GETROOMS()
                TXTINWORDS.Text = CurrencyToWord(Val(TXTAMT.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class