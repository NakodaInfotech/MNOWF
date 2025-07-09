
Imports BL
Imports System.Windows.Forms

Public Class MedReqOutstanding

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub MedReqOutstanding_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub MedReqOutstanding_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("  and dbo.MEDCLAIMREQ.REQ_DONE='FALSE'  and dbo.MEDCLAIMREQ.REQ_CLOSE='FALSE' and dbo.MEDCLAIMREQ.REQ_CMPID=" & CmpId & " and dbo.MEDCLAIMREQ.REQ_locationid=" & Locationid & " and dbo.MEDCLAIMREQ.REQ_yearid=" & YearId & " order by dbo.MEDCLAIMREQ.REQ_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  MEDCLAIMREQ.REQ_NO AS SRNO, MEDCLAIMREQ.REQ_DATE AS REQDATE, MEDCLAIMREQ.REQ_INWARDNO AS INWARDNO, ISNULL(SENTBYMASTER.SENTBY_NAME, '') AS SENTBY, MEDCLAIMREQ.REQ_RECDATE AS RECDATE, OFFICERMASTER.OFFICER_name AS NAME, ISNULL(COMPANYMASTER.COMPANY_NAME, '') AS CMPNAME, RANKMASTER.RANK_NAME AS RANK, OFFICERMASTER.OFFICER_EMPCODE AS EMPCODE, OFFICERMASTER.OFFICER_MUINO AS MUINO, MEDCLAIMREQ.REQ_AUTHOFROM AS AUTHOFROM, MEDCLAIMREQ.REQ_AUTHOTO AS AUTHOTO, MEDCLAIMREQ.REQ_DOJ AS DOJ, ISNULL(FAMILYMASTER.FAMILY_NAME, '') AS PATIENT, ISNULL(RELATIONMASTER.RELATION_NAME, '') AS RELATION, ISNULL(MEDCLAIMREQ.REQ_DIAGNOSIS, '') AS DIAGNOSIS, ISNULL(MEDCLAIMREQ.REQ_HOSPNAME, '') AS HOSPNAME, ISNULL(MEDCLAIMREQ.REQ_HOSPADD, '') AS HOSPADD, ISNULL(MEDCLAIMREQ.REQ_DRNAME, '') AS DRNAME, ISNULL(MEDCLAIMREQ.REQ_BANK, '') AS BANK, ISNULL(MEDCLAIMREQ.REQ_BRANCH, '') AS BRANCH, ISNULL(MEDCLAIMREQ.REQ_ACNAME, '') AS ACNAME, ISNULL(MEDCLAIMREQ.REQ_ACNO, '') AS ACNO, ISNULL(MEDCLAIMREQ.REQ_BANKADD, '') AS BANKADD, ISNULL(MEDCLAIMREQ.REQ_REMARKS, '') AS REMARKS, MEDCLAIMREQ.REQ_CLAIMEDAMT AS CLAIMAMT ", "", " MEDCLAIMREQ INNER JOIN OFFICERMASTER ON MEDCLAIMREQ.REQ_OFFICERID = OFFICERMASTER.OFFICER_id AND MEDCLAIMREQ.REQ_CMPID = OFFICERMASTER.OFFICER_cmpid AND MEDCLAIMREQ.REQ_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND MEDCLAIMREQ.REQ_YEARID = OFFICERMASTER.OFFICER_yearid INNER JOIN OFFICERMASTER_DESC ON OFFICERMASTER.OFFICER_cmpid = OFFICERMASTER_DESC.OFFICER_CMPID AND OFFICERMASTER.OFFICER_locationid = OFFICERMASTER_DESC.OFFICER_locationid AND OFFICERMASTER.OFFICER_yearid = OFFICERMASTER_DESC.OFFICER_yearid AND OFFICERMASTER.OFFICER_id = OFFICERMASTER_DESC.OFFICER_ID INNER JOIN FAMILYMASTER ON MEDCLAIMREQ.REQ_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = FAMILYMASTER.FAMILY_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = FAMILYMASTER.FAMILY_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID AND MEDCLAIMREQ.REQ_CMPID = FAMILYMASTER.FAMILY_CMPID AND MEDCLAIMREQ.REQ_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND MEDCLAIMREQ.REQ_YEARID = FAMILYMASTER.FAMILY_YEARID INNER JOIN RELATIONMASTER ON OFFICERMASTER_DESC.OFFICER_RELATIONID = RELATIONMASTER.RELATION_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = RELATIONMASTER.RELATION_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = RELATIONMASTER.RELATION_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = RELATIONMASTER.RELATION_YEARID INNER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID AND OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_CMPID AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_YEARID INNER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID AND OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_CMPID AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_YEARID LEFT OUTER JOIN SENTBYMASTER ON MEDCLAIMREQ.REQ_YEARID = SENTBYMASTER.SENTBY_YEARID AND MEDCLAIMREQ.REQ_LOCATIONID = SENTBYMASTER.SENTBY_LOCATIONID AND MEDCLAIMREQ.REQ_CMPID = SENTBYMASTER.SENTBY_CMPID AND MEDCLAIMREQ.REQ_SENTBYID = SENTBYMASTER.SENTBY_ID ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal reqno As Integer)
        Try
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Medical Pending Request Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Medical Pending Request Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Medical Pending Request Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, , AccFrom & " - " & AccTo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class