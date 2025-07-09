
Imports BL

Public Class ShowCorrespondence

    Public FRMSTRING As String
    Public REQNO As Integer

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ShowCorrespondence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ShowCorrespondence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CORRES_NO AS SRNO, CORRES_DATE AS DATE, CORRES_REMARKS AS REMARKS, CORRES_RECDDATE AS RECDDATE, ISNULL(CORRES_RECDREMARKS,'') AS RECDREMARKS, CORRES_CLOSED AS CLOSED ", "", " CORRESPONDENCE ", " AND CORRES_TYPE = '" & FRMSTRING & "' AND CORRES_REQNO = " & REQNO & " AND CORRES_CMPID = " & CmpId & " AND CORRES_LOCATIONID = " & Locationid & " AND CORRES_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDCORRES.Rows.Add(DTROW("SRNO"), Format(DTROW("DATE"), "dd/MM/yyyy"), DTROW("REMARKS"), Format(DTROW("RECDDATE"), "dd/MM/yyyy"), DTROW("RECDREMARKS"), DTROW("CLOSED"))
                    If Convert.ToBoolean(DTROW("CLOSED")) = True Then GRIDCORRES.Rows(GRIDCORRES.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                GRIDCORRES.ClearSelection()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            For Each ROW As DataGridViewRow In GRIDCORRES.SelectedRows
                Dim OBJCORRES As New Correspondence
                OBJCORRES.MdiParent = MDIMain
                OBJCORRES.edit = True
                OBJCORRES.TEMPCORRESNO = ROW.Cells(0).Value.ToString
                OBJCORRES.Show()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECPAY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCORRES.CellDoubleClick
        Try
            SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class