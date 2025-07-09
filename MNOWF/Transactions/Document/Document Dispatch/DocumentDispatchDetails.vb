
Imports BL

Public Class DocumentDispatchDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean

    Private Sub DocumentDispatchDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJDOC As New ClsDocumentOutward
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJDOC.alParaval = ALPARAVAL
            Dim dt As DataTable = OBJDOC.GETDOC()
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridcontra.FocusedRowHandle = gridcontra.RowCount - 1
                gridcontra.TopRowIndex = gridcontra.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridcontra.RowCount > 0) Then
                Dim OBJDOC As New DocumentDispatch
                OBJDOC.MdiParent = MDIMain
                OBJDOC.edit = editval
                OBJDOC.TEMPOUTWARDNO = billno
                OBJDOC.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcontra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridcontra.DoubleClick
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("OUTWARDNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DocumentDispatchDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DOCUMENT OUTWARD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("OUTWARDNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Document Outward Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Document Outward Details"
            gridcontra.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Document Outward Details", gridcontra.VisibleColumns.Count + gridcontra.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

End Class