
Imports BL

Public Class SelectBills

    Public CMPNAME As String = ""
    Public BILLNO As String = ""

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            BILLNO = gridrec.GetFocusedRowCellValue("SRNO")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable
            dt = OBJCMN.search(" * ", "", " (SELECT BOOKING_INITIALS AS SRNO, OFFICERMASTER.OFFICER_NAME AS OFFICERNAME, HOTELMASTER.HOTEL_NAME AS NAME, BOOKINGMASTER.BOOKING_GTOTAL AS BILLAMT, BOOKINGMASTER.BOOKING_BALANCE AS BALAMT, 'BOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM BOOKINGMASTER INNER JOIN OFFICERMASTER ON BOOKINGMASTER.BOOKING_OFFICERID = OFFICERMASTER.OFFICER_ID AND BOOKINGMASTER.BOOKING_CMPID = OFFICERMASTER.OFFICER_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = OFFICERMASTER.OFFICER_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = OFFICERMASTER.OFFICER_YEARID INNER JOIN HOTELMASTER ON BOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_id AND BOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_locationid And BOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_yearid) AS T ", tepmcondition & " AND T.BALAMT > 0 AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID =" & YearId & " ORDER BY T.TYPE, T.BILLNO ")
            griddetails.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectBills_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Receipt.SELECTEDBILLNO = ""
            Dim CONDITION As String = ""
            If CMPNAME <> "" Then CONDITION = " AND T.OFFICERNAME = '" & CMPNAME & "' "
            fillgrid(CONDITION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridrec_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridrec.DoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class