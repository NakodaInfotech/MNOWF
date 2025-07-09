
Imports BL

Public Class RefundDetails


    Dim BOOKINGREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub RefundDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" REFUNDMASTER.REFUND_NO AS SRNO, REFUNDMASTER.REFUND_DATE AS DATE, OFFICERMASTER.OFFICER_name AS OFFICERNAME, ISNULL(COMPANYMASTER.COMPANY_NAME,'') AS CMPNAME, ISNULL(RANKMASTER.RANK_NAME,'') AS RANK, REFUNDMASTER.REFUND_BOOKNO AS BOOKINGNO, REFUNDMASTER.REFUND_AMT AS AMT, REFUNDMASTER.REFUND_DEPOSIT AS DEPOSIT, REFUNDMASTER.REFUND_BALANCE AS BALANCE ", "", " REFUNDMASTER INNER JOIN OFFICERMASTER ON REFUNDMASTER.REFUND_OFFICERID = OFFICERMASTER.OFFICER_id AND REFUNDMASTER.REFUND_CMPID = OFFICERMASTER.OFFICER_cmpid AND REFUNDMASTER.REFUND_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND REFUNDMASTER.REFUND_YEARID = OFFICERMASTER.OFFICER_yearid LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_YEARID AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_LOCATIONID AND OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_CMPID AND OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID LEFT OUTER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID AND OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_CMPID AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_YEARID ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
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
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJINV As New Refund
                OBJINV.MdiParent = MDIMain
                OBJINV.edit = editval
                OBJINV.TEMPREFUNDNO = billno
                OBJINV.Show()
                'Me.Close()
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

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefundDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL BOOKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid(" and REFUND_CMPID = " & CmpId & " AND REFUND_LOCATIONID = " & Locationid & " AND REFUND_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Refund Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Refund Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Refund Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class