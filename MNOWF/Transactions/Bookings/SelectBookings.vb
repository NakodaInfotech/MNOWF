
Imports BL
Imports System.Windows.Forms

Public Class SelectBookings

    Dim ROW As Integer = 0
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SelectBookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectBookings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" and dbo.BOOKINGMASTER.BOOKING_REFUNDED ='FALSE' order by dbo.BOOKINGMASTER.BOOKING_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" DISTINCT CAST(0 AS BIT) AS CHK, BOOKING_NO AS SRNO, BOOKING_DATE AS DATE, OFFICERMASTER.OFFICER_name AS NAME, ISNULL(COMPANYMASTER.COMPANY_NAME, '') AS CMPNAME, RANKMASTER.RANK_NAME AS RANK, OFFICERMASTER.OFFICER_EMPCODE AS EMPCODE, OFFICERMASTER.OFFICER_MUINO AS MUINO, BOOKING_ARRIVAL AS ARRIVAL, BOOKING_DEPARTURE AS DEPARTURE, BOOKING_AMT AS AMT, BOOKING_DEPOSIT AS DEPOSIT ", "", "    BOOKINGMASTER INNER JOIN OFFICERMASTER ON BOOKING_OFFICERID = OFFICERMASTER.OFFICER_id LEFT OUTER JOIN OFFICERMASTER_DESC ON OFFICERMASTER.OFFICER_id = OFFICERMASTER_DESC.OFFICER_ID INNER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID INNER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("BOOKINGNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("CMPNAME")
            DT.Columns.Add("RANK")
            DT.Columns.Add("EMPCODE")
            DT.Columns.Add("MUINO")
            DT.Columns.Add("AMT")
            DT.Columns.Add("DEPOSIT")
            

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("SRNO"), dtrow("NAME"), dtrow("CMPNAME"), dtrow("RANK"), dtrow("EMPCODE"), dtrow("MUINO"), dtrow("AMT"), dtrow("DEPOSIT"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
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

LINE1:
            If ROW = 0 Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(I)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        ROW = I
                        Exit For
                    End If
                Next
            Else
                Dim dtrow As DataRow = gridbill.GetDataRow(ROW)
                If Convert.ToBoolean(dtrow("CHK")) = False Then
                    ROW = 0
                    GoTo LINE1
                End If
            End If

            If Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = True And e.RowHandle <> ROW Then
                e.Valid = False
                gridbill.SetColumnError(gridbill.Columns("CHK"), "Only 1 row can be selected at a time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            ElseIf Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = False And e.RowHandle = ROW Then
                ROW = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class