
Imports BL

Public Class HomePage

    Private Sub acc_cmd_Click() Handles ACC_CMD.Click
        Try
            Dim objacc As New AccountsDetails
            objacc.frmstring = "ACCOUNTS"
            objacc.MdiParent = MDIMain
            objacc.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTEL_CMD_Click() Handles HOTEL_CMD.Click
        Try
            Dim OBJHOTEL As New HotelDetails
            OBJHOTEL.MdiParent = MDIMain
            OBJHOTEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYMENT_CMD_Click() Handles PAYMENT_CMD.Click
        Try
            Dim objpay As New PaymentMaster
            objpay.MdiParent = MDIMain
            objpay.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEIPT_CMD_Click() Handles RECEIPT_CMD.Click
        Try
            Dim objrec As New Receipt
            objrec.MdiParent = MDIMain
            objrec.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRA_CMD_Click() Handles CONTRA_CMD.Click
        Try
            Dim objcontra As New ContraEntry
            objcontra.MdiParent = MDIMain
            objcontra.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BANK_CMD_Click() Handles BANK_CMD.Click
        Try
            Dim objbank As New BankRegister
            objbank.MdiParent = MDIMain
            objbank.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LEDGER_CMD_Click() Handles LEDGER_CMD.Click
        Try
            Dim objledger As New RegisterDetails
            objledger.MdiParent = MDIMain
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNAL_CMD_Click() Handles JOURNAL_CMD.Click
        Try
            Dim objjv As New journal
            objjv.MdiParent = MDIMain
            objjv.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblacccentre.Click
        Call acc_cmd_Click()
    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLHOTEL.Click
        Call HOTEL_CMD_Click()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLPAY.Click
        Call PAYMENT_CMD_Click()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLREC.Click
        Call RECEIPT_CMD_Click()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLCONTRA.Click
        Call CONTRA_CMD_Click()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLBANK.Click
        Call BANK_CMD_Click()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLLEDGER.Click
        Call LEDGER_CMD_Click()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLVOUCHER.Click
        Call VOUCHER_CMD_Click()
    End Sub

    Private Sub VOUCHER_CMD_Click() Handles VOUCHER_CMD.Click
        Try
            Dim OBJNP As New ExpenseVoucher
            OBJNP.FRMSTRING = "NONPURCHASE"
            OBJNP.MdiParent = MDIMain
            OBJNP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLJV.Click
        Call JOURNAL_CMD_Click()
    End Sub

    Private Sub HomePage_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HomePage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    LBLCHECKIN.Left = Me.Width
        '    Dim WHERECLAUSE As String = " AND BOOKING_ARRIVAL = '" & Format(DateAdd(DateInterval.Day, 1, Mydate), "MM/dd/yyyy") & "'"
        '    If UserName <> "Admin" Then WHERECLAUSE = " AND BOOKEDBYMASTER.BOOKEDBY_NAME = ' " & UserName & "'"

        '    Dim CHECKINNAMES As String = "There is No Check In for Tomorrow."
        '    Dim objclsCMST As New ClsCommonMaster
        '    Dim dt As DataTable = objclsCMST.search("  HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS [DATE], GUESTMASTER.GUEST_NAME AS GUESTNAME , HOTELMASTER.HOTEL_NAME AS HOTELNAME,  HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_PICKUPDETAILS AS PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME aS BOOKEDBY, BOOKING_SALEBALANCE AS BALANCE, BOOKING_BOOKTYPE AS TYPE ", "", " HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN BOOKEDBYMASTER ON HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", WHERECLAUSE & " AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_CMPID =" & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
        '    If dt.Rows.Count > 0 Then
        '        CHECKINNAMES = ""
        '        For Each ROW As DataRow In dt.Rows
        '            CHECKINNAMES = CHECKINNAMES & ROW("BOOKINGNO") & " - " & ROW("GUESTNAME") & " - " & ROW("HOTELNAME") & "                        "
        '        Next
        '    End If
        '    LBLCHECKIN.Text = CHECKINNAMES

        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub OFFICER_CMD_Click() Handles OFFICER_CMD.Click
        Try
            Dim OBJOFFICER As New OfficerDetails
            OBJOFFICER.MdiParent = MDIMain
            OBJOFFICER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLOFFICER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLOFFICER.Click
        Call OFFICER_CMD_Click()
    End Sub

    Private Sub MECLAIMREQ_CMD_Click() Handles MECLAIMREQ_CMD.Click
        Try
            Dim OBJMEDREQ As New MedClaimReq
            OBJMEDREQ.MdiParent = MDIMain
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLMEDCLAIMREQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLMEDCLAIMREQ.Click
        Call MECLAIMREQ_CMD_Click()
    End Sub

    Private Sub EDUCLAIMREQ_CMD_Click() Handles EDUCLAIMREQ_CMD.Click
        Try
            Dim OBJEDUREQ As New EduClaimRequest
            OBJEDUREQ.MdiParent = MDIMain
            OBJEDUREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLEDUCLAIMREQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLEDUCLAIMREQ.Click
        Call EDUCLAIMREQ_CMD_Click()
    End Sub

    Private Sub MEDCLAIMSETTLE_CMD_Click() Handles MEDCLAIMSETTLE_CMD.Click
        Try
            Dim OBJMEDREQ As New MedClaimSettlement
            OBJMEDREQ.MdiParent = MDIMain
            OBJMEDREQ.FRMSTRING = "MEDICAL"
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLMEDCLAIMSETTLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLMEDCLAIMSETTLE.Click
        Call MEDCLAIMSETTLE_CMD_Click()
    End Sub

    Private Sub EDUCLAIMSETTLE_CMD_Click() Handles EDUCLAIMSETTLE_CMD.Click
        Try
            Dim OBJeduREQ As New EduClaimSettlement
            OBJeduREQ.MdiParent = MDIMain
            OBJeduREQ.FRMSTRING = "EDUCATION"
            OBJeduREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLEDUCLAIMSETTLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLEDUCLAIMSETTLE.Click
        Call EDUCLAIMSETTLE_CMD_Click()
    End Sub

    Private Sub REFUND_CMD_Click() Handles REFUND_CMD.Click
        Try
            Dim OBJREFUND As New Refund
            OBJREFUND.MdiParent = MDIMain
            OBJREFUND.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLREFUND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLREFUND.Click
        Call REFUND_CMD_Click()
    End Sub

    Private Sub HOTELBOOKING_CMD_Click() Handles HOTELBOOKING_CMD.Click
        Try
            Dim OBJBOOK As New Booking
            OBJBOOK.MdiParent = MDIMain
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LBLBOOKING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLBOOKING.Click
        Call HOTELBOOKING_CMD_Click()
    End Sub

End Class