Public Class InvestmentFilter

    Public frmstring As String
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public edit As Boolean

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, DTFROM.Value.Date)
        a2 = DatePart(DateInterval.Month, DTFROM.Value.Date)
        a3 = DatePart(DateInterval.Year, DTFROM.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, DTTO.Value.Date)
        a12 = DatePart(DateInterval.Month, DTTO.Value.Date)
        a13 = DatePart(DateInterval.Year, DTTO.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub Filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Filter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CHKTILLDATE.Checked = False
        DTTO.Enabled = CHKTILLDATE.CheckState
        fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
    End Sub

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKTILLDATE.CheckedChanged
        DTTO.Enabled = CHKTILLDATE.CheckState
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim OBJINV As New InvestmentDesign
            OBJINV.STRSEARCH = " {INVESTMENTMASTER.INVE_CMPID} = " & CmpId

            getFromToDate()
            If CHKFROMDATE.Checked = True Then
                OBJINV.FROMDATE = DTFROM.Value.Date
                OBJINV.STRSEARCH = OBJINV.STRSEARCH & " AND DATE({INVESTMENTMASTER.INVE_MATURITYDATE}) >= DATE(" & Format(DTFROM.Value.Date, "yyyy,MM,dd") & ")"
                OBJINV.PERIOD = "INVESTMENT DETAILS FROM DATE - (" & Format(DTFROM.Value.Date, "dd/MM/yyyy") & ")"
            Else
                OBJINV.FROMDATE = AccFrom
                OBJINV.PERIOD = "INVESTMENT DETAILS FROM DATE - (" & Format(AccFrom.Date, "dd/MM/yyyy") & ")"
            End If


            If CHKTILLDATE.Checked = True Then
                OBJINV.TODATE = DTTO.Value.Date
                OBJINV.STRSEARCH = OBJINV.STRSEARCH & " AND DATE({INVESTMENTMASTER.INVE_MATURITYDATE}) <= DATE(" & Format(DTTO.Value.Date, "yyyy,MM,dd") & ")"
                OBJINV.PERIOD = OBJINV.PERIOD & " TILL DATE - (" & Format(DTTO.Value.Date, "dd/MM/yyyy") & ")"
            Else
                OBJINV.TODATE = AccTo
                OBJINV.PERIOD = OBJINV.PERIOD & " TILL DATE - (" & Format(AccTo.Date, "dd/MM/yyyy") & ")"
            End If

            If CMBBANK.Text.Trim <> "" Then OBJINV.STRSEARCH = OBJINV.STRSEARCH & " AND {LEDGERS.ACC_CMPNAME} = '" & CMBBANK.Text.Trim & "'"

            OBJINV.MdiParent = MDIMain
            OBJINV.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANK.Enter
        Try
            'OPEN BANK A/C AND BANK OD A/C
            'If CMBBANK.Text.Trim = "" Then fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR groupmaster.group_SECONDARY = 'BANK OD A/C' OR groupmaster.group_SECONDARY = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBBANK.Text.Trim = "" Then fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBANK.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANK.Validating
        Try
            'If CMBBANK.Text.Trim <> "" Then ledgervalidate(CMBBANK, CMBACCCODE, e, Me, txtadd, " AND (GROUPMASTER.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.group_SECONDARY = 'BANK OD A/C' OR GROUPMASTER.group_SECONDARY = 'CASH IN HAND') AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If CMBBANK.Text.Trim <> "" Then ledgervalidate(CMBBANK, CMBACCCODE, e, Me, txtadd, " AND (GROUPMASTER.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class