
Imports BL
Imports System.Windows.Forms

Public Class SelectInward
    Public frmstring As String = ""
    Dim ROW As Integer = 0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectInward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectInward_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" and DOCUMENTINWARD.DOCIN_CMPID=" & CmpId & " and DOCUMENTINWARD.DOCIN_locationid=" & Locationid & " and DOCUMENTINWARD.DOCIN_yearid=" & YearId & " AND DOCUMENTINWARD.DOCIN_DONE='FALSE' ORDER BY DOCUMENTINWARD.DOCIN_NO")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" DOCUMENTINWARD.DOCIN_NO AS INWARDNO, DOCUMENTINWARD.DOCIN_RECDATE AS RECDATE, DOCTYPEMASTER.DOCTYPE_NAME AS DOCTYPE, SENTBYMASTER.SENTBY_NAME AS SENTBY, DOCUMENTINWARD.DOCIN_DOCDATE AS DOCDATE, DOCUMENTINWARD.DOCIN_REMARKS AS REMARKS, DOCUMENTINWARD.DOCIN_DONE AS DONE ", "", " DOCUMENTINWARD INNER JOIN DOCTYPEMASTER ON DOCUMENTINWARD.DOCIN_DOCTYPEID = DOCTYPEMASTER.DOCTYPE_ID AND DOCUMENTINWARD.DOCIN_CMPID = DOCTYPEMASTER.DOCTYPE_CMPID AND DOCUMENTINWARD.DOCIN_LOCATIONID = DOCTYPEMASTER.DOCTYPE_LOCATIONID AND DOCUMENTINWARD.DOCIN_YEARID = DOCTYPEMASTER.DOCTYPE_YEARID INNER JOIN SENTBYMASTER ON DOCUMENTINWARD.DOCIN_SENTBYID = SENTBYMASTER.SENTBY_ID AND DOCUMENTINWARD.DOCIN_CMPID = SENTBYMASTER.SENTBY_CMPID AND DOCUMENTINWARD.DOCIN_LOCATIONID = SENTBYMASTER.SENTBY_LOCATIONID AND DOCUMENTINWARD.DOCIN_YEARID = SENTBYMASTER.SENTBY_YEARID ", TEMPCONDITION)
            gridBilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Dim dt As New DataTable
        dt.Columns.Add("INWARDNO")
        dt.Columns.Add("RECDATE")
        dt.Columns.Add("SENTBY")
        
        For i As Integer = 0 To gridbill.RowCount - 1
            Dim dtrow As DataRow = gridbill.GetDataRow(i)
            If Convert.ToBoolean(dtrow("DONE")) = True Then
                dt.Rows.Add(dtrow("INWARDNO"), dtrow("RECDATE"), dtrow("SENTBY"))
            End If
        Next
        If frmstring = "MED" Then
            MedClaimSettlement.SELECTDOC = dt
        ElseIf frmstring = "EDU" Then
            EduClaimSettlement.SELECTDOC = dt
        ElseIf frmstring = "BOOK" Then
            Booking.SELECTDOC = dt
        End If
        Me.Close()
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        Try
            e.ErrorText = "Only 1 row can be selected at a time"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If ROW = 0 Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(I)
                    If Convert.ToBoolean(dtrow("DONE")) = True Then
                        ROW = I
                        Exit For
                    End If
                Next
            End If

            If Convert.ToBoolean(gridbill.GetFocusedRowCellValue("DONE")) = True And e.RowHandle <> ROW Then
                e.Valid = False
                gridbill.SetColumnError(gridbill.Columns("DONE"), "Only 1 row can be selected at a time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            ElseIf Convert.ToBoolean(gridbill.GetFocusedRowCellValue("DONE")) = False And e.RowHandle = ROW Then
                ROW = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class