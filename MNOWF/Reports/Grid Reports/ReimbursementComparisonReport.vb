
Imports BL
Imports System.Windows.Forms

Public Class ReimbursementComparisonReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ReimbursementComparisonReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ReimbursementComparisonReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " and CMPID=" & CmpId & " and LOCATIONID=" & Locationid & " and YEARID=" & YearId
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND CLAIMDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CLAIMDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" T.CMPNAME, T.CONTRIBUTION, SUM(T.TOTALCLAIMSMED ) AS TOTALCLAIMSMED, SUM(T.CLAIMEDAMTMED ) AS CLAIMEDAMTMED, SUM(T.AMTMED ) AS AMTMED , SUM(T.PERCENTMED ) AS PERCENTMED, SUM(T.TOTALCLAIMSEDU) AS TOTALCLAIMSEDU, SUM(T.CLAIMEDAMTEDU ) AS CLAIMEDAMTEDU , SUM(T.AMTEDU ) AS AMTEDU, SUM(T.PERCENTEDU ) AS PERCENTEDU, (SUM(T.AMTMED ) + SUM(T.AMTEDU ))  AS TOTAL, ROUND((((SUM(T.AMTMED ) + SUM(T.AMTEDU )) / (SELECT SUM(PAYAMT) FROM CLAIMDETAILS WHERE 1=1 " & WHERECLAUSE & " )) * 100),2)  AS [FINALPERCENT] ", "", " (SELECT CLAIMDETAILS.CMPNAME, ISNULL(SUM(DISTINCT(RECEIPTMASTER.receipt_total)),'') AS CONTRIBUTION, COUNT(CLAIMDETAILS.CLAIMNO) AS [TOTALCLAIMSMED], SUM(CLAIMDETAILS.CLAIMEDAMT) AS CLAIMEDAMTMED, SUM(CLAIMDETAILS.PAYAMT) AS AMTMED , ROUND(((SUM(PAYAMT) / (SELECT SUM(PAYAMT) FROM CLAIMDETAILS WHERE TYPE = 'MEDICAL' " & WHERECLAUSE & " )) * 100),2)  AS [PERCENTMED], 0 AS TOTALCLAIMSEDU, 0 AS CLAIMEDAMTEDU, 0 AS AMTEDU, 0 AS PERCENTEDU FROM RECEIPTMASTER INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid RIGHT OUTER JOIN CLAIMDETAILS ON LEDGERS.Acc_cmpid = CLAIMDETAILS.CMPID AND LEDGERS.Acc_locationid = CLAIMDETAILS.LOCATIONID AND LEDGERS.Acc_yearid = CLAIMDETAILS.YEARID AND LEDGERS.Acc_cmpname = CLAIMDETAILS.CMPNAME WHERE TYPE = 'MEDICAL' " & WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME UNION ALL SELECT CLAIMDETAILS.CMPNAME, ISNULL(SUM(DISTINCT(RECEIPTMASTER.receipt_total)),'') AS CONTRIBUTION, 0 ,0,0,0, COUNT(CLAIMDETAILS.CLAIMNO) AS [TOTALCLAIMSEDU], SUM(CLAIMDETAILS.CLAIMEDAMT) AS CLAIMEDAMTEDU, SUM(CLAIMDETAILS.PAYAMT) AS AMTEDU , ROUND(((SUM(PAYAMT) / (SELECT SUM(PAYAMT) FROM CLAIMDETAILS WHERE TYPE = 'EDUCATION' " & WHERECLAUSE & ")) * 100),2)  AS [PERCENTEDU] FROM RECEIPTMASTER INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid RIGHT OUTER JOIN CLAIMDETAILS ON LEDGERS.Acc_cmpid = CLAIMDETAILS.CMPID AND LEDGERS.Acc_locationid = CLAIMDETAILS.LOCATIONID AND LEDGERS.Acc_yearid = CLAIMDETAILS.YEARID AND LEDGERS.Acc_cmpname = CLAIMDETAILS.CMPNAME WHERE TYPE = 'EDUCATION' " & WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME ) AS T ", " GROUP BY T.CMPNAME, T.CONTRIBUTION ")
            GRIDBILLDETAILS.DataSource = dt
            If dt.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Reimbursement Comparison Report (Company Wise).XLS"
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


            opti.SheetName = "Reimbursement Comparison Report (Company Wise)"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Reimbursement Comparison Report (Company Wise)", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
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