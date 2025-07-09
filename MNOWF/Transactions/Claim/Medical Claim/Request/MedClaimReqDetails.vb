
Imports BL
Imports System.Windows.Forms

Public Class MedClaimReqDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MED CLAIM REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.MEDCLAIMREQ.REQ_yearid=" & YearId & " order by dbo.MEDCLAIMREQ.REQ_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  MEDCLAIMREQ.REQ_NO AS SRNO, MEDCLAIMREQ.REQ_DATE AS REQDATE, MEDCLAIMREQ.REQ_INWARDNO AS INWARDNO, ISNULL(SENTBYMASTER.SENTBY_NAME, '') AS SENTBY, MEDCLAIMREQ.REQ_RECDATE AS RECDATE, OFFICERMASTER.OFFICER_name AS NAME, ISNULL(COMPANYMASTER.COMPANY_NAME, '') AS CMPNAME, RANKMASTER.RANK_NAME AS RANK, OFFICERMASTER.OFFICER_EMPCODE AS EMPCODE, OFFICERMASTER.OFFICER_MUINO AS MUINO, MEDCLAIMREQ.REQ_AUTHOFROM AS AUTHOFROM, MEDCLAIMREQ.REQ_AUTHOTO AS AUTHOTO, MEDCLAIMREQ.REQ_DOJ AS DOJ, ISNULL(FAMILYMASTER.FAMILY_NAME, '') AS PATIENT, ISNULL(RELATIONMASTER.RELATION_NAME, '') AS RELATION, ISNULL(MEDCLAIMREQ.REQ_DIAGNOSIS, '') AS DIAGNOSIS, ISNULL(MEDCLAIMREQ.REQ_HOSPNAME, '') AS HOSPNAME, ISNULL(MEDCLAIMREQ.REQ_HOSPADD, '') AS HOSPADD, ISNULL(MEDCLAIMREQ.REQ_DRNAME, '') AS DRNAME, ISNULL(MEDCLAIMREQ.REQ_BANK, '') AS BANK, ISNULL(MEDCLAIMREQ.REQ_BRANCH, '') AS BRANCH, ISNULL(MEDCLAIMREQ.REQ_ACNAME, '') AS ACNAME, ISNULL(MEDCLAIMREQ.REQ_ACNO, '') AS ACNO, ISNULL(MEDCLAIMREQ.REQ_BANKADD, '') AS BANKADD, ISNULL(MEDCLAIMREQ.REQ_REMARKS, '') AS REMARKS, MEDCLAIMREQ.REQ_CLAIMEDAMT AS CLAIMAMT,   MEDCLAIMREQ.REQ_DONE AS DONE, ISNULL(VESSEL_NAME,'') AS VESSEL ", "", "     MEDCLAIMREQ INNER JOIN OFFICERMASTER ON MEDCLAIMREQ.REQ_OFFICERID = OFFICERMASTER.OFFICER_id INNER JOIN OFFICERMASTER_DESC ON OFFICERMASTER.OFFICER_id = OFFICERMASTER_DESC.OFFICER_ID INNER JOIN FAMILYMASTER ON MEDCLAIMREQ.REQ_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID AND MEDCLAIMREQ.REQ_YEARID = FAMILYMASTER.FAMILY_YEARID INNER JOIN RELATIONMASTER ON OFFICERMASTER_DESC.OFFICER_RELATIONID = RELATIONMASTER.RELATION_ID LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID LEFT OUTER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID LEFT OUTER JOIN SENTBYMASTER ON MEDCLAIMREQ.REQ_SENTBYID = SENTBYMASTER.SENTBY_ID LEFT OUTER JOIN VESSELMASTER ON REQ_VESSELID = VESSEL_ID", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal reqno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objMEDClaimRequest As New MedClaimReq
                objMEDClaimRequest.MdiParent = MDIMain
                objMEDClaimRequest.edit = editval
                objMEDClaimRequest.TEMPREQNO = reqno
                objMEDClaimRequest.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                If ROW("DONE") = "TRUE" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\MED Req Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Medical Request Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Medical Request Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class