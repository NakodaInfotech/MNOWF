
Imports BL
Imports System.Windows.Forms

Public Class RefundOutstanding

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub RefundOutstanding_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RefundOutstanding_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " AND REFUND_BALANCE > 0 and REFUND_CMPID=" & CmpId & " and REFUND_LOCATIONID=" & Locationid & " and REFUND_YEARID=" & YearId
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" REFUNDMASTER.REFUND_INITIALS AS SRNO, REFUNDMASTER.REFUND_DATE AS REFUNDDATE, OFFICERMASTER.OFFICER_name AS NAME, REFUNDMASTER.REFUND_ACNAME AS ACNAME, REFUNDMASTER.REFUND_ACNO AS ACNO, REFUNDMASTER.REFUND_BANK AS BANKNAME, HOTELMASTER.HOTEL_NAME AS HOTELNAME, BOOKINGMASTER.BOOKING_INITIALS AS BOOKINGNO, REFUNDMASTER.REFUND_DEPOSIT AS DEPOSIT, REFUNDMASTER.REFUND_REFUNDAMT AS REFUND ", "", " REFUNDMASTER INNER JOIN HOTELMASTER INNER JOIN BOOKINGMASTER ON HOTELMASTER.HOTEL_ID = BOOKINGMASTER.BOOKING_HOTELID AND HOTELMASTER.HOTEL_CMPID = BOOKINGMASTER.BOOKING_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = BOOKINGMASTER.BOOKING_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = BOOKINGMASTER.BOOKING_YEARID ON REFUNDMASTER.REFUND_CMPID = BOOKINGMASTER.BOOKING_CMPID AND REFUNDMASTER.REFUND_LOCATIONID = BOOKINGMASTER.BOOKING_LOCATIONID AND REFUNDMASTER.REFUND_YEARID = BOOKINGMASTER.BOOKING_YEARID AND REFUNDMASTER.REFUND_BOOKNO = BOOKINGMASTER.BOOKING_NO INNER JOIN OFFICERMASTER ON REFUNDMASTER.REFUND_OFFICERID = OFFICERMASTER.OFFICER_id AND REFUNDMASTER.REFUND_CMPID = OFFICERMASTER.OFFICER_cmpid AND REFUNDMASTER.REFUND_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND REFUNDMASTER.REFUND_YEARID = OFFICERMASTER.OFFICER_yearid ", WHERECLAUSE)
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

            Dim PATH As String = Application.StartupPath & "\Convalescent Home Refund Outstanding Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Convalescent Home Refund Outstanding Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Convalescent Home Refund Outstanding Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class