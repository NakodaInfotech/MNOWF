
Imports BL
Imports System.Windows.Forms

Public Class CompanyReimbursementReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CompanyReimbursementReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub CompanyReimbursementReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " and CMPID=" & CmpId & " and LOCATIONID=" & Locationid & " and YEARID=" & YearId
            If CMBTYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and TYPE = '" & CMBTYPE.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND CLAIMDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CLAIMDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CLAIMDETAILS.CMPNAME, ISNULL(SUM(DISTINCT(RECEIPTMASTER.receipt_total)),'') AS CONTRIBUTION, COUNT(CLAIMDETAILS.CLAIMNO) AS [TOTALCLAIMS], SUM(CLAIMDETAILS.CLAIMEDAMT) AS CLAIMEDAMT, SUM(CLAIMDETAILS.PAYAMT) AS PAYAMT , ROUND(((SUM(PAYAMT) / (SELECT SUM(PAYAMT) FROM CLAIMDETAILS WHERE 1 = 1 " & WHERECLAUSE & " )) * 100),0)  AS [PERCENT] ", "", " RECEIPTMASTER INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid RIGHT OUTER JOIN CLAIMDETAILS ON LEDGERS.Acc_cmpid = CLAIMDETAILS.CMPID AND LEDGERS.Acc_locationid = CLAIMDETAILS.LOCATIONID AND LEDGERS.Acc_yearid = CLAIMDETAILS.YEARID AND LEDGERS.Acc_cmpname = CLAIMDETAILS.CMPNAME ", WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME ")
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

            Dim PATH As String = Application.StartupPath & "\Claim Reimbursement Report (Company Wise).XLS"
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


            opti.SheetName = "Claim Reimbursement Report (Company Wise)"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Claim Reimbursement Report (Company Wise) ", gridbill.VisibleColumns.Count + gridbill.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
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
End Class