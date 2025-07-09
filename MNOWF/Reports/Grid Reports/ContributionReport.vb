
Imports BL
Imports System.Windows.Forms

Public Class ContributionReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ContributionReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ContributionReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" LEDGERS.Acc_cmpname AS CMPNAME, COUNT(OFFICERMASTER.OFFICER_name) AS TOTALOFFICERS, RECEIPTMASTER.RECEIPT_YEAR AS CONTRIYEAR, ISNULL(SUM(DISTINCT RECEIPTMASTER.receipt_total), '') AS CONTRIBUTION, ISNULL(RECEIPTMASTER.RECEIPT_CHQNO, '') AS CHQNO, RECEIPTMASTER.receipt_date AS DATE, ISNULL(SUM(DISTINCT RECEIPTMASTER.receipt_total), '') AS CONTRIBUTION, ISNULL(RECEIPTMASTER.RECEIPT_CHQNO, '') AS CHQNO, RECEIPTMASTER.receipt_date AS DATE , ROUND((ISNULL(SUM(DISTINCT RECEIPTMASTER.receipt_total), '') /  (SELECT SUM(RECEIPTMASTER.receipt_total) FROM LEDGERS INNER JOIN COMPANYMASTER ON LEDGERS.Acc_cmpname = COMPANYMASTER.COMPANY_NAME AND LEDGERS.Acc_cmpid = COMPANYMASTER.COMPANY_CMPID AND LEDGERS.Acc_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND LEDGERS.Acc_yearid = COMPANYMASTER.COMPANY_YEARID INNER JOIN RECEIPTMASTER ON LEDGERS.Acc_cmpid = RECEIPTMASTER.receipt_cmpid AND LEDGERS.Acc_locationid = RECEIPTMASTER.receipt_locationid AND LEDGERS.Acc_yearid = RECEIPTMASTER.receipt_yearid AND LEDGERS.Acc_id = RECEIPTMASTER.receipt_ledgerid)) *100  ,0 ) AS [PERCENT] ", "", " COMPANYMASTER INNER JOIN OFFICERMASTER ON COMPANYMASTER.COMPANY_ID = OFFICERMASTER.OFFICER_COMPANYID AND COMPANYMASTER.COMPANY_CMPID = OFFICERMASTER.OFFICER_cmpid AND COMPANYMASTER.COMPANY_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND COMPANYMASTER.COMPANY_YEARID = OFFICERMASTER.OFFICER_yearid INNER JOIN RECEIPTMASTER INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid ON COMPANYMASTER.COMPANY_NAME = LEDGERS.Acc_cmpname AND COMPANYMASTER.COMPANY_CMPID = LEDGERS.Acc_cmpid AND COMPANYMASTER.COMPANY_LOCATIONID = LEDGERS.Acc_locationid And COMPANYMASTER.COMPANY_YEARID = LEDGERS.Acc_yearid", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " GROUP BY LEDGERS.Acc_cmpname, RECEIPTMASTER.RECEIPT_YEAR, ISNULL(RECEIPTMASTER.RECEIPT_CHQNO, ''), RECEIPTMASTER.receipt_date")
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

            Dim PATH As String = Application.StartupPath & "\Contribution Received Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Contribution Received Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Contribution Received Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, , AccFrom & " - " & AccTo, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class