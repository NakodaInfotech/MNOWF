
Imports BL

Public Class OfficerFilter

    Sub FILLCMB()
        Try
            FILLOFFICER(CMBNAME, False)
            FILLCOMPANY(CMBCMPNAME, False)
            FILLRANK(CMBRANK, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OfficerFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OfficerFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then OFFICERVALIDATE(CMBNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCMPNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCMPNAME.Enter
        Try
            If CMBCMPNAME.Text.Trim = "" Then FILLCOMPANY(CMBCMPNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCMPNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBRANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRANK.Enter
        Try
            If CMBRANK.Text.Trim = "" Then FILLRANK(CMBRANK, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbRANK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBRANK.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBCMPNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCMPNAME.Validating
        Try
            If CMBCMPNAME.Text.Trim <> "" Then COMPANYVALIDATE(CMBCMPNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRANK.Validating
        Try
            If CMBRANK.Text.Trim <> "" Then RANKVALIDATE(CMBRANK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim CONDITION As String = " AND OFFICERMASTER.OFFICER_CMPID = " & CmpId & " AND OFFICERMASTER.OFFICER_LOCATIONID = " & Locationid & " AND OFFICERMASTER.OFFICER_YEARID = " & YearId
            If CMBNAME.Text.Trim <> "" Then CONDITION = CONDITION & " AND OFFICERMASTER.OFFICER_NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBCMPNAME.Text.Trim <> "" Then CONDITION = CONDITION & " AND COMPANYMASTER.COMPANY_NAME = '" & CMBCMPNAME.Text.Trim & "'"
            If CMBRANK.Text.Trim <> "" Then CONDITION = CONDITION & " AND RANKMASTER.RANK_NAME = '" & CMBRANK.Text.Trim & "'"

            If CHKINDIAN.Checked = True Then CONDITION = CONDITION & " AND OFFICERMASTER.OFFICER_INDIAN = '" & CHKINDIAN.Checked & "' "
            If CHKCONTRACT.Checked = True Then CONDITION = CONDITION & " AND OFFICERMASTER.OFFICER_CONTRACT = '" & CHKCONTRACT.Checked & "' "
            If CHKCONTRIBUTION.Checked = True Then CONDITION = CONDITION & " AND OFFICERMASTER.OFFICER_CONTRIBUTION = '" & CHKCONTRIBUTION.Checked & "' "
            If CHKDONATION.Checked = True Then CONDITION = CONDITION & " AND OFFICERMASTER.OFFICER_DONATION = '" & CHKDONATION.Checked & "' "


            Dim OBJRPT As New clsReportDesigner("OFFICER DETAILS", System.AppDomain.CurrentDomain.BaseDirectory & "OFFICER DETAILS.xlsx", 2)
            OBJRPT.OFFICERDETAILS(CONDITION, CmpId, Locationid, YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKINDIAN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKINDIAN.CheckedChanged
        Try
            If CHKINDIAN.CheckState = CheckState.Checked Then CHKCONTRACT.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKCONTRACT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKCONTRACT.CheckedChanged
        Try
            If CHKCONTRACT.CheckState = CheckState.Checked Then CHKINDIAN.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKCONTRIBUTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCONTRIBUTION.CheckedChanged
        Try
            If CHKCONTRIBUTION.CheckState = CheckState.Checked Then CHKDONATION.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKDONATION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKDONATION.CheckedChanged
        Try
            If CHKDONATION.CheckState = CheckState.Checked Then CHKCONTRIBUTION.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class