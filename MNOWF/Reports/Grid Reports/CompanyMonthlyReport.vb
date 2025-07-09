
Imports BL
Imports System.Windows.Forms

Public Class CompanyMonthlyReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CompanyMonthlyReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CompanyMonthlyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommon
            Dim ALPARAVAL As New ArrayList

            If CMBTYPE.Text.Trim <> "" Then
                ALPARAVAL.Add(" AND TYPE = '" & CMBTYPE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            Else
                ALPARAVAL.Add(" AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            End If
            objclsCMST.alParaval = ALPARAVAL
            Dim dt As DataTable = objclsCMST.GETCMPMONTHLY()
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

            Dim PATH As String = Application.StartupPath & "\(Company Wise)Monthly Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "(Company Wise)Monthly Report"
            gridbill.ExportToXls(PATH, opti)

            Dim HEAD As String = "Monthly Reimbursement (Company Wise) for the Financial Year " & Format(AccFrom, "dd/MM/yyyy") & "-" & Format(AccTo, "dd/MM/yyyy")
            If CMBTYPE.Text.Trim <> "" Then HEAD = CMBTYPE.Text.Trim & " Monthly Reimbursement (Company Wise) for " & CMBTYPE.Text.Trim & " for the Financial Year " & Format(AccFrom, "dd/MM/yyyy") & "-" & Format(AccTo, "dd/MM/yyyy")
            EXCELCMPHEADER(PATH, HEAD, gridbill.VisibleColumns.Count + gridbill.GroupCount, , AccFrom & " - " & AccTo, , , True)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class