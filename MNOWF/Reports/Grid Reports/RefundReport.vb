
Imports BL
Imports System.Windows.Forms

Public Class RefundReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub RefundReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                Call cmdshowdetails_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RefundReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " and REFUND_CMPID=" & CmpId & " and REFUND_LOCATIONID=" & Locationid & " and REFUND_YEARID=" & YearId
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND PAYMENTMASTER.PAYMENT_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PAYMENTMASTER.PAYMENT_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" REFUNDMASTER.REFUND_INITIALS AS SRNO, REFUNDMASTER.REFUND_DATE AS REFUNDDATE, OFFICERMASTER.OFFICER_name AS NAME, REFUNDMASTER.REFUND_ACNAME AS ACNAME, REFUNDMASTER.REFUND_ACNO AS ACNO, REFUNDMASTER.REFUND_BANK AS BANKNAME, HOTELMASTER.HOTEL_NAME AS HOTELNAME, BOOKINGMASTER.BOOKING_INITIALS AS BOOKINGNO, REFUNDMASTER.REFUND_DEPOSIT AS DEPOSIT, REFUNDMASTER.REFUND_REFUNDAMT AS REFUND, PAYMENTMASTER.PAYMENT_CHQNO AS CHQNO, PAYMENTMASTER.PAYMENT_date AS CHQDATE ", "", " PAYMENTMASTER_DESC INNER JOIN REFUNDMASTER INNER JOIN HOTELMASTER INNER JOIN BOOKINGMASTER ON HOTELMASTER.HOTEL_ID = BOOKINGMASTER.BOOKING_HOTELID ON REFUNDMASTER.REFUND_BOOKNO = BOOKINGMASTER.BOOKING_NO AND REFUNDMASTER.REFUND_CMPID = BOOKINGMASTER.BOOKING_CMPID INNER JOIN OFFICERMASTER ON REFUNDMASTER.REFUND_OFFICERID = OFFICERMASTER.OFFICER_id ON PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS = REFUNDMASTER.REFUND_INITIALS AND PAYMENTMASTER_DESC.PAYMENT_yearid = REFUNDMASTER.REFUND_YEARID INNER JOIN LEDGERS INNER JOIN PAYMENTMASTER ON LEDGERS.Acc_id = PAYMENTMASTER.PAYMENT_accid ON PAYMENTMASTER_DESC.PAYMENT_no = PAYMENTMASTER.PAYMENT_no AND PAYMENTMASTER_DESC.PAYMENT_registerid = PAYMENTMASTER.PAYMENT_registerid AND PAYMENTMASTER_DESC.PAYMENT_yearid = PAYMENTMASTER.PAYMENT_yearid ", WHERECLAUSE)
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

            Dim PATH As String = Application.StartupPath & "\Convalescent Home Refund Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Convalescent Home Refund Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Convalescent Home Refund Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIEWREP.Click
        Try
            Dim OBJBOOK As New BookingDesign
            OBJBOOK.MdiParent = MDIMain
            OBJBOOK.FRMSTRING = "REFPAYREP"
            If chkdate.CheckState = CheckState.Checked Then
                OBJBOOK.FROMDATE = dtfrom.Value.Date
                OBJBOOK.TODATE = dtto.Value.Date
            Else
                OBJBOOK.FROMDATE = AccFrom
                OBJBOOK.TODATE = AccTo
            End If
            OBJBOOK.MdiParent = MDIMain
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
End Class