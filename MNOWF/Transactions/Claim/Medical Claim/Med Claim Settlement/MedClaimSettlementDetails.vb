
Imports BL

Public Class MedClaimSettlementDetails

    Dim SETTLEREGIG As Integer
    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

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
            Dim dt As DataTable = objclsCMST.search(" MEDCLAIMSETTLEMENT.SETTLE_NO AS srno, MEDCLAIMSETTLEMENT.SETTLE_DATE AS date, MEDCLAIMSETTLEMENT.SETTLE_REQNO AS reqno, MEDCLAIMSETTLEMENT.SETTLE_REQDATE AS reqdate, OFFICERMASTER.OFFICER_name AS officer, FAMILYMASTER.FAMILY_NAME AS relative, MEDCLAIMSETTLEMENT.SETTLE_DIAGNOSIS AS diagnosis, MEDCLAIMSETTLEMENT.SETTLE_DRNAME AS drname, MEDCLAIMSETTLEMENT.SETTLE_HOSPNAME AS hospname, MEDCLAIMSETTLEMENT.SETTLE_CLAIMEDAMT AS claimedamt, MEDCLAIMSETTLEMENT.SETTLE_TOTALAMT AS settleamt, ISNULL(VESSELMASTER.VESSEL_NAME, '') AS VESSEL, ISNULL(RANKMASTER.RANK_NAME,'') AS RANKNAME, ISNULL(COMPANYMASTER.COMPANY_NAME,'') AS CMPNAME, ISNULL(OFFICERMASTER.OFFICER_MUINO,0) AS MUI , REGISTERMASTER.register_name AS REGISTER ", "", "  COMPANYMASTER RIGHT OUTER JOIN OFFICERMASTER ON COMPANYMASTER.COMPANY_ID = OFFICERMASTER.OFFICER_COMPANYID LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID RIGHT OUTER JOIN MEDCLAIMSETTLEMENT INNER JOIN REGISTERMASTER ON MEDCLAIMSETTLEMENT.SETTLE_REGID = REGISTERMASTER.register_id AND MEDCLAIMSETTLEMENT.SETTLE_CMPID = REGISTERMASTER.register_cmpid AND MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID = REGISTERMASTER.register_locationid AND MEDCLAIMSETTLEMENT.SETTLE_YEARID = REGISTERMASTER.register_yearid ON  OFFICERMASTER.OFFICER_id = MEDCLAIMSETTLEMENT.SETTLE_OFFICERID AND OFFICERMASTER.OFFICER_cmpid = MEDCLAIMSETTLEMENT.SETTLE_CMPID AND OFFICERMASTER.OFFICER_locationid = MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = MEDCLAIMSETTLEMENT.SETTLE_YEARID LEFT OUTER JOIN FAMILYMASTER ON MEDCLAIMSETTLEMENT.SETTLE_FAMILYID = FAMILYMASTER.FAMILY_ID AND MEDCLAIMSETTLEMENT.SETTLE_CMPID = FAMILYMASTER.FAMILY_CMPID AND MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND MEDCLAIMSETTLEMENT.SETTLE_YEARID = FAMILYMASTER.FAMILY_YEARID LEFT OUTER JOIN VESSELMASTER ON MEDCLAIMSETTLEMENT.SETTLE_VESSELID = VESSELMASTER.VESSEL_ID ", " AND MEDCLAIMSETTLEMENT.SETTLE_YEARID =" & YearId & " ORDER BY MEDCLAIMSETTLEMENT.SETTLE_NO ")
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
                Dim OBJINV As New MedClaimSettlement
                OBJINV.MdiParent = MDIMain
                OBJINV.edit = editval
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'MEDICAL'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'MEDICAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'MEDICAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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

    Private Sub BOOKINGMasterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MED CLAIM REQUEST'")
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
            PATH = Application.StartupPath & "\Medical Claim Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Medical Claim Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Medical Claim Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class