
Imports BL

Public Class CheckInList

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CheckInList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0, "BOOKING")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" BOOKINGMASTER.BOOKING_NO AS BOOKINGNO, BOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, OFFICERMASTER.OFFICER_name AS OFFICERNAME, HOTELMASTER.HOTEL_NAME AS HOTELNAME, REGISTERMASTER.register_name AS REGNAME, BOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, BOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, BOOKINGMASTER.BOOKING_REMARKS AS REMARKS, USERMASTER.User_Name AS BOOKEDBY, BOOKINGMASTER.BOOKING_BALANCE AS BALANCE ", "", " BOOKINGMASTER INNER JOIN OFFICERMASTER ON BOOKINGMASTER.BOOKING_OFFICERID = OFFICERMASTER.OFFICER_id AND BOOKINGMASTER.BOOKING_CMPID = OFFICERMASTER.OFFICER_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND BOOKINGMASTER.BOOKING_YEARID = OFFICERMASTER.OFFICER_yearid INNER JOIN HOTELMASTER ON BOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND BOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN REGISTERMASTER ON BOOKINGMASTER.BOOKING_REGID = REGISTERMASTER.register_id AND BOOKINGMASTER.BOOKING_CMPID = REGISTERMASTER.register_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = REGISTERMASTER.register_locationid AND BOOKINGMASTER.BOOKING_YEARID = REGISTERMASTER.register_yearid INNER JOIN USERMASTER ON BOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id ", WHERECLAUSE & " AND BOOKING_CMPID =" & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal REGNAME As String)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New Booking
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKNO = BOOKINGNO
                OBJBOOKING.TEMPREG = REGNAME
                OBJBOOKING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), gridbill.GetFocusedRowCellValue("REGNAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), gridbill.GetFocusedRowCellValue("REGNAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckInList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim WHERECLAUSE As String = " AND BOOKING_ARRIVAL = '" & Format(DateAdd(DateInterval.Day, 1, Mydate), "MM/dd/yyyy") & "' "
            fillgrid(WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim WHERECLAUSE As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                WHERECLAUSE = " AND BOOKING_ARRIVAL >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKING_ARRIVAL <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' "
            Else
                WHERECLAUSE = " AND BOOKING_ARRIVAL = '" & Format(DateAdd(DateInterval.Day, 1, Mydate), "MM/dd/yyyy") & "' "
            End If
            fillgrid(WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class