
Imports System.Windows.Forms
Imports BL
Imports DevExpress.Export
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base

Public Class ClaimPaymentRegister

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ClaimPaymentReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ClaimPaymentReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" and PAYINITIALS <> '' and YEARID=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            If CMBTYPE.Text.Trim <> "" Then TEMPCONDITION = TEMPCONDITION & " AND TYPE = '" & CMBTYPE.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then
                TEMPCONDITION = TEMPCONDITION & " AND PAYDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PAYDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' order by SETTLENO"
            Else
                TEMPCONDITION = TEMPCONDITION & " AND PAYDATE = '" & Format(Now.Date, "MM/dd/yyyy") & "' order by SETTLENO"
            End If


            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("*,AMT AS AMOUNT", "", " CLAIMDETAILS ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            GridControl1.DataSource = dt
            If dt.Rows.Count > 0 Then
                GridView1.FocusedRowHandle = GridView1.RowCount - 1
                GridView1.TopRowIndex = GridView1.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SETTLENO As Integer, ByVal TYPE As String)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                If TYPE = "EDUCATION" Or TYPE = "EDUSUPP" Then
                    Dim OBJEDU As New EduClaimSettlement
                    OBJEDU.MdiParent = MDIMain
                    OBJEDU.EDIT = editval
                    OBJEDU.FRMSTRING = TYPE
                    OBJEDU.TEMPSETTLENO = SETTLENO
                    OBJEDU.Show()
                Else
                    Dim OBJMED As New MedClaimSettlement
                    OBJMED.MdiParent = MDIMain
                    OBJMED.EDIT = editval
                    OBJMED.TEMPSETTLENO = SETTLENO
                    OBJMED.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SETTLENO"), gridbill.GetFocusedRowCellValue("TYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SETTLENO"), gridbill.GetFocusedRowCellValue("TYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Claim Payment Details.XLS"
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

            opti.SheetName = "Claim Payment Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Claim Payment Register", gridbill.VisibleColumns.Count + gridbill.GroupCount, , PERIOD, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            fillgrid(" and PAYINITIALS <> '' and CMPID=" & CmpId & " and LOCATIONID=" & Locationid & " and YEARID=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CLAIMREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLAIMREPORT.Click
        Try
            Dim OBJCLAIM As New ClaimDesign
            OBJCLAIM.FRMSTRING = "PAYMENTREGISTER"
            If chkdate.CheckState = CheckState.Checked Then
                OBJCLAIM.FROMDATE = dtfrom.Value.Date
                OBJCLAIM.TODATE = dtto.Value.Date
            Else
                OBJCLAIM.FROMDATE = Mydate
                OBJCLAIM.TODATE = Mydate
            End If
            If CMBTYPE.Text.Trim <> "" Then OBJCLAIM.TYPE = CMBTYPE.Text.Trim
            OBJCLAIM.MdiParent = MDIMain
            OBJCLAIM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click_1(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJCLAIM As New ClaimDesign
                OBJCLAIM.FRMSTRING = "BANKPAYMENTREGISTER"
                If chkdate.CheckState = CheckState.Checked Then
                    OBJCLAIM.FROMDATE = dtfrom.Value.Date
                    OBJCLAIM.TODATE = dtto.Value.Date
                Else
                    OBJCLAIM.FROMDATE = Mydate
                    OBJCLAIM.TODATE = Mydate
                End If
                If CMBTYPE.Text.Trim <> "" Then OBJCLAIM.TYPE = CMBTYPE.Text.Trim
                OBJCLAIM.MdiParent = MDIMain
                OBJCLAIM.Show()
            End If
            If MsgBox("Wish to Print in Excel?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExportDevExpressGridToExcel(GridControl1, CMBTYPE.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ExportDevExpressGridToExcel(gridControl As DevExpress.XtraGrid.GridControl, reportType As String)
        Try



            ' Create export path
            Dim folderPath As String = Application.StartupPath & "\ClaimPaymentRegister" & reportType.Trim
            Dim filePath As String = folderPath & "\ClaimPaymentRegister" & reportType.Trim & ".xlsx"

            ' Create folder if it doesn't exist
            If Not System.IO.Directory.Exists(folderPath) Then
                System.IO.Directory.CreateDirectory(folderPath)
            End If

            ' Export
            gridControl.ExportToXlsx(filePath)

            ' ✅ Add logo and header rows
            AddExcelHeaderWithLogo(filePath, reportType, dtfrom.Value.Date, dtto.Value.Date)

            ' Open file
            Process.Start(filePath)


            MsgBox("Exported to Excel successfully at " & filePath)
        Catch ex As Exception
            MsgBox("Export failed: " & ex.Message)
        End Try
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        If e.IsGetData AndAlso e.Column.FieldName = "SRNO" Then
            e.Value = e.ListSourceRowIndex + 1
        End If
    End Sub

End Class