
Imports BL
Imports System.Windows.Forms

Public Class BookingOutstanding

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub BookingOutstanding_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub BookingOutstanding_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " AND BOOKING_BALANCE > 0 and BOOKING_CMPID=" & CmpId & " and BOOKING_LOCATIONID=" & Locationid & " and BOOKING_YEARID=" & YearId
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'BY NEHA
            dt = objclsCMST.search(" BOOKINGMASTER.BOOKING_INITIALS AS SRNO, BOOKINGMASTER.BOOKING_DATE AS DATE, OFFICERMASTER.OFFICER_name AS NAME, BOOKINGMASTER.BOOKING_BANKNAME AS BANKNAME, BOOKINGMASTER.BOOKING_CHQNO AS CHQNO, HOTELMASTER.HOTEL_NAME AS HOTELNAME,BOOKINGMASTER.BOOKING_INITIALS AS BOOKINGNO, BOOKINGMASTER.BOOKING_DEPOSIT AS DEPOSIT, BOOKINGMASTER.BOOKING_AMT AS BOOKAMT ", "", " HOTELMASTER INNER JOIN OFFICERMASTER INNER JOIN BOOKINGMASTER ON OFFICERMASTER.OFFICER_id = BOOKINGMASTER.BOOKING_OFFICERID AND OFFICERMASTER.OFFICER_cmpid = BOOKINGMASTER.BOOKING_CMPID AND OFFICERMASTER.OFFICER_locationid = BOOKINGMASTER.BOOKING_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = BOOKINGMASTER.BOOKING_YEARID ON HOTELMASTER.HOTEL_ID = BOOKINGMASTER.BOOKING_HOTELID AND HOTELMASTER.HOTEL_YEARID = BOOKINGMASTER.BOOKING_YEARID", WHERECLAUSE)


            'dt = objclsCMST.search(" BOOKINGMASTER.BOOKING_INITIALS AS SRNO, BOOKINGMASTER.BOOKING_DATE AS DATE, OFFICERMASTER.OFFICER_name AS NAME, BOOKINGMASTER.BOOKING_BANKNAME AS BANKNAME, BOOKINGMASTER.BOOKING_CHQNO AS CHQNO, HOTELMASTER.HOTEL_NAME AS HOTELNAME, BOOKINGMASTER.BOOKING_INITIALS AS BOOKINGNO, BOOKINGMASTER.BOOKING_DEPOSIT AS DEPOSIT, BOOKINGMASTER.BOOKING_AMT AS BOOKAMT ", "", " BOOKINGMASTER INNER JOIN HOTELMASTER INNER JOIN BOOKINGMASTER ON HOTELMASTER.HOTEL_ID = BOOKINGMASTER.BOOKING_HOTELID AND HOTELMASTER.HOTEL_CMPID = BOOKINGMASTER.BOOKING_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = BOOKINGMASTER.BOOKING_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = BOOKINGMASTER.BOOKING_YEARID ON BOOKINGMASTER.BOOKING_CMPID = BOOKINGMASTER.BOOKING_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = BOOKINGMASTER.BOOKING_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = BOOKINGMASTER.BOOKING_YEARID AND BOOKINGMASTER.BOOKING_BOOKNO = BOOKINGMASTER.BOOKING_NO INNER JOIN OFFICERMASTER ON BOOKINGMASTER.BOOKING_OFFICERID = OFFICERMASTER.OFFICER_id AND BOOKINGMASTER.BOOKING_CMPID = OFFICERMASTER.OFFICER_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND BOOKINGMASTER.BOOKING_YEARID = OFFICERMASTER.OFFICER_yearid ", WHERECLAUSE)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Convalescent Home Outstanding Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Convalescent Home Outstanding Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Convalescent Home Outstanding Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class