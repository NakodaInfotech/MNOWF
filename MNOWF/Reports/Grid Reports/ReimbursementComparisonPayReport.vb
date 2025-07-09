
Imports BL

Public Class ReimbursementComparisonPayReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ReimbursementComparisonPayReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
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
            Dim WHERECLAUSE As String = " and YEARID=" & YearId
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND PAYDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PAYDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" T.CMPNAME, sum(T.CONTRIBUTION) AS CONTRIBUTION, SUM(T.TOTALCLAIMSMED ) AS TOTALCLAIMSMED, SUM(T.CLAIMEDAMTMED ) AS CLAIMEDAMTMED, SUM(T.AMTMED ) AS AMTMED , SUM(T.TOTALCLAIMSEDU) AS TOTALCLAIMSEDU, SUM(T.CLAIMEDAMTEDU ) AS CLAIMEDAMTEDU , SUM(T.AMTEDU ) AS AMTEDU, (SUM(T.AMTMED ) + SUM(T.AMTEDU ))  AS TOTAL ", "", " (SELECT CLAIMDETAILS.CMPNAME, ISNULL(SUM(DISTINCT(RECEIPTMASTER.receipt_total)),'') AS CONTRIBUTION, 0 AS [TOTALCLAIMSMED], 0 AS CLAIMEDAMTMED, 0 AS AMTMED, 0 AS [TOTALCLAIMSEDU] , 0 AS CLAIMEDAMTEDU, 0 AS AMTEDU FROM RECEIPTMASTER INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id left OUTER JOIN CLAIMDETAILS ON LEDGERS.Acc_yearid = CLAIMDETAILS.YEARID AND LEDGERS.Acc_cmpname = CLAIMDETAILS.CMPNAME WHERE 1=1 " & WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME UNION ALL  SELECT CLAIMDETAILS.CMPNAME, 0 AS CONTRIBUTION, COUNT(CLAIMDETAILS.CLAIMNO) AS [TOTALCLAIMSMED], SUM(CLAIMDETAILS.CLAIMEDAMT) AS CLAIMEDAMTMED, SUM(CLAIMDETAILS.PAYAMT) AS AMTMED, 0 AS [TOTALCLAIMSEDU] , 0 AS CLAIMEDAMTEDU, 0 AS AMTEDU FROM CLAIMDETAILS WHERE TYPE = 'MEDICAL' " & WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME UNION ALL SELECT CLAIMDETAILS.CMPNAME, 0 AS CONTRIBUTION, 0 ,0,0, COUNT(CLAIMDETAILS.CLAIMNO) AS [TOTALCLAIMSEDU], SUM(CLAIMDETAILS.CLAIMEDAMT) AS CLAIMEDAMTEDU, SUM(CLAIMDETAILS.PAYAMT) AS AMTEDU  FROM CLAIMDETAILS WHERE TYPE = 'EDUCATION' " & WHERECLAUSE & " GROUP BY CLAIMDETAILS.CMPNAME ) AS T ", " GROUP BY T.CMPNAME")
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
            GRIDBILL.ExportToXls(PATH, opti)
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