
Imports BL
Imports System.Windows.Forms

Public Class EduReqOutstanding

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub EduReqOutstanding_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub EduReqOutstanding_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" and dbo.EDUCLAIMREQ.REQ_DONE = 'FALSE' AND dbo.EDUCLAIMREQ.REQ_CLOSE = 'FALSE' and dbo.EDUCLAIMREQ.REQ_CMPID=" & CmpId & " and dbo.EDUCLAIMREQ.REQ_locationid=" & Locationid & " and dbo.EDUCLAIMREQ.REQ_yearid=" & YearId & " order by dbo.EDUCLAIMREQ.REQ_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  EDUCLAIMREQ.REQ_NO AS SRNO, EDUCLAIMREQ.REQ_DATE AS REQDATE, EDUCLAIMREQ.REQ_INWARDNO AS INWARDNO, ISNULL(SENTBYMASTER.SENTBY_NAME, '') AS SENTBY, EDUCLAIMREQ.REQ_RECDATE AS RECDATE, OFFICERMASTER.OFFICER_name AS NAME, ISNULL(COMPANYMASTER.COMPANY_NAME, '') AS CMPNAME, RANKMASTER.RANK_NAME AS RANK, OFFICERMASTER.OFFICER_EMPCODE AS EMPCODE, OFFICERMASTER.OFFICER_MUINO AS MUINO, EDUCLAIMREQ.REQ_LEAVEFROM AS LEAVEFROM, EDUCLAIMREQ.REQ_LEAVETO AS LEAVETO, EDUCLAIMREQ.REQ_DOJ AS DOJ, ISNULL(FAMILYMASTER.FAMILY_NAME, '') AS CHILD, ISNULL(RELATIONMASTER.RELATION_NAME, '') AS RELATION, ISNULL(COURSEMASTER.COURSE_NAME, '') AS COURSE, ISNULL(COURSEYEARMASTER.COURSEYEAR_NAME, '') AS COURSEYEAR,  ISNULL(EDUCLAIMREQ.REQ_INSTNAME, '') AS INSTNAME, ISNULL(EDUCLAIMREQ.REQ_UNIADD, '') AS UNIADD, ISNULL(EDUCLAIMREQ.REQ_UNINAME, '') AS UNINAME, ISNULL(EDUCLAIMREQ.REQ_BANK, '') AS BANK, ISNULL(EDUCLAIMREQ.REQ_BRANCH, '') AS BRANCH, ISNULL(EDUCLAIMREQ.REQ_ACNAME, '') AS ACNAME, ISNULL(EDUCLAIMREQ.REQ_ACNO, '') AS ACNO, ISNULL(EDUCLAIMREQ.REQ_BANKADD, '') AS BANKADD, ISNULL(EDUCLAIMREQ.REQ_REMARKS, '') AS REMARKS ", "", "     EDUCLAIMREQ INNER JOIN OFFICERMASTER ON EDUCLAIMREQ.REQ_OFFICERID = OFFICERMASTER.OFFICER_id AND EDUCLAIMREQ.REQ_CMPID = OFFICERMASTER.OFFICER_cmpid AND EDUCLAIMREQ.REQ_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND EDUCLAIMREQ.REQ_YEARID = OFFICERMASTER.OFFICER_yearid INNER JOIN OFFICERMASTER_DESC ON OFFICERMASTER.OFFICER_cmpid = OFFICERMASTER_DESC.OFFICER_CMPID AND OFFICERMASTER.OFFICER_locationid = OFFICERMASTER_DESC.OFFICER_locationid AND OFFICERMASTER.OFFICER_yearid = OFFICERMASTER_DESC.OFFICER_yearid AND OFFICERMASTER.OFFICER_id = OFFICERMASTER_DESC.OFFICER_ID INNER JOIN FAMILYMASTER ON EDUCLAIMREQ.REQ_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_FAMILYID = FAMILYMASTER.FAMILY_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = FAMILYMASTER.FAMILY_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = FAMILYMASTER.FAMILY_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = FAMILYMASTER.FAMILY_YEARID AND EDUCLAIMREQ.REQ_CMPID = FAMILYMASTER.FAMILY_CMPID AND EDUCLAIMREQ.REQ_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND EDUCLAIMREQ.REQ_YEARID = FAMILYMASTER.FAMILY_YEARID LEFT OUTER JOIN COURSEMASTER ON EDUCLAIMREQ.REQ_COURSEID = COURSE_ID AND EDUCLAIMREQ.REQ_CMPID = COURSE_CMPID AND EDUCLAIMREQ.REQ_LOCATIONID = COURSE_LOCATIONID AND EDUCLAIMREQ.REQ_YEARID = COURSE_YEARID LEFT OUTER JOIN COURSEYEARMASTER ON EDUCLAIMREQ.REQ_COURSEYEARID = COURSEYEAR_ID AND EDUCLAIMREQ.REQ_CMPID = COURSEYEAR_CMPID AND EDUCLAIMREQ.REQ_LOCATIONID = COURSEYEAR_LOCATIONID AND EDUCLAIMREQ.REQ_YEARID = COURSEYEAR_YEARID INNER JOIN RELATIONMASTER ON OFFICERMASTER_DESC.OFFICER_RELATIONID = RELATIONMASTER.RELATION_ID AND OFFICERMASTER_DESC.OFFICER_CMPID = RELATIONMASTER.RELATION_CMPID AND OFFICERMASTER_DESC.OFFICER_locationid = RELATIONMASTER.RELATION_LOCATIONID AND OFFICERMASTER_DESC.OFFICER_yearid = RELATIONMASTER.RELATION_YEARID INNER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID AND OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_CMPID AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_YEARID INNER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID AND OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_CMPID AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_YEARID LEFT OUTER JOIN SENTBYMASTER ON EDUCLAIMREQ.REQ_YEARID = SENTBYMASTER.SENTBY_YEARID AND EDUCLAIMREQ.REQ_LOCATIONID = SENTBYMASTER.SENTBY_LOCATIONID AND EDUCLAIMREQ.REQ_CMPID = SENTBYMASTER.SENTBY_CMPID AND EDUCLAIMREQ.REQ_SENTBYID = SENTBYMASTER.SENTBY_ID ", tepmcondition)
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
                Dim objEDUClaimRequest As New EduClaimRequest
                objEDUClaimRequest.MdiParent = MDIMain
                objEDUClaimRequest.edit = editval
                objEDUClaimRequest.TEMPREQNO = reqno
                objEDUClaimRequest.Show()
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

            Dim PATH As String = Application.StartupPath & "\Education Pending Request Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Education Pending Request Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Education Pending Request Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, , AccFrom & " - " & AccTo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class