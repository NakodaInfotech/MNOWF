Imports System.ComponentModel
Imports BL

Public Class EduClaimSettlementDetails

    Dim SETTLEREGIG As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub BOOKINGMasterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" EDUCLAIMSETTLEMENT.SETTLE_NO AS srno, EDUCLAIMSETTLEMENT.SETTLE_DATE AS date, EDUCLAIMSETTLEMENT.SETTLE_REQNO AS reqno, EDUCLAIMSETTLEMENT.SETTLE_REQDATE AS reqdate, OFFICERMASTER.OFFICER_name AS officer, FAMILYMASTER.FAMILY_NAME AS relative, EDUCLAIMSETTLEMENT.SETTLE_COURSE AS course, EDUCLAIMSETTLEMENT.SETTLE_INSTITUTE AS institute, EDUCLAIMSETTLEMENT.SETTLE_UNIVERSITY AS university, EDUCLAIMSETTLEMENT.SETTLE_CLAIMEDAMT AS claimedamt, EDUCLAIMSETTLEMENT.SETTLE_TOTALAMT AS settleamt, ISNULL(VESSELMASTER.VESSEL_NAME, '') AS VESSEL, RANKMASTER.RANK_NAME as RANKNAME, COMPANYMASTER.COMPANY_NAME AS CMPNAME, OFFICERMASTER.OFFICER_MUINO AS MUI, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS [REGISTER] ", "", "   OFFICERMASTER LEFT OUTER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID RIGHT OUTER JOIN EDUCLAIMSETTLEMENT INNER JOIN REGISTERMASTER ON EDUCLAIMSETTLEMENT.SETTLE_REGID = REGISTERMASTER.register_id AND EDUCLAIMSETTLEMENT.SETTLE_CMPID = REGISTERMASTER.register_cmpid AND EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID = REGISTERMASTER.register_locationid AND EDUCLAIMSETTLEMENT.SETTLE_YEARID = REGISTERMASTER.register_yearid ON OFFICERMASTER.OFFICER_id = EDUCLAIMSETTLEMENT.SETTLE_OFFICERID AND OFFICERMASTER.OFFICER_cmpid = EDUCLAIMSETTLEMENT.SETTLE_CMPID AND OFFICERMASTER.OFFICER_locationid = EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = EDUCLAIMSETTLEMENT.SETTLE_YEARID LEFT OUTER JOIN FAMILYMASTER ON EDUCLAIMSETTLEMENT.SETTLE_FAMILYID = FAMILYMASTER.FAMILY_ID AND EDUCLAIMSETTLEMENT.SETTLE_CMPID = FAMILYMASTER.FAMILY_CMPID AND EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND EDUCLAIMSETTLEMENT.SETTLE_YEARID = FAMILYMASTER.FAMILY_YEARID LEFT OUTER JOIN VESSELMASTER ON EDUCLAIMSETTLEMENT.SETTLE_VESSELID = VESSELMASTER.VESSEL_ID ", " AND EDUCLAIMSETTLEMENT.SETTLE_YEARID=" & YearId & " ORDER BY EDUCLAIMSETTLEMENT.SETTLE_NO ")
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
                Dim OBJINV As New EduClaimSettlement
                OBJINV.MdiParent = MDIMain
                OBJINV.EDIT = editval
                OBJINV.TEMPSETTLENO = billno
                OBJINV.TEMPREG = cmbregister.Text

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

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " And register_type = 'EDUCATION'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EDUCATION' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("srno"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("srno"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlendPanel1_Click(sender As Object, e As EventArgs) Handles BlendPanel1.Click

    End Sub

    Private Sub BOOKINGMasterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EDU CLAIM REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Education Claim Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Education Claim Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Education Claim Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'EDUCATION' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    SETTLEREGIG = dt.Rows(0).Item(0)
                    fillgrid()
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class