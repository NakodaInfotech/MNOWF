
Imports BL
Imports System.Windows.Forms

Public Class OccupancyReport

    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub OccupancyReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                Call cmdshowdetails_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OccupancyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " and BOOKING_CMPID=" & CmpId & " and BOOKING_LOCATIONID=" & Locationid & " and BOOKING_YEARID=" & YearId
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND BOOKING_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKING_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" BOOKINGMASTER.BOOKING_INITIALS AS BOOKINGNO, BOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, OFFICERMASTER.OFFICER_name AS NAME, COMPANYMASTER.COMPANY_NAME AS CMPNAME, RANKMASTER.RANK_NAME AS RANK, OFFICERMASTER.OFFICER_EMPCODE AS EMPCODE, OFFICERMASTER.OFFICER_MUINO AS MUINO, ISNULL(BOOKINGMASTER.BOOKING_INSAFOSMA,'') AS INSAFOSMA, HOTELMASTER.HOTEL_NAME AS HOTELNAME, BOOKINGMASTER.BOOKING_PAX AS DEPENDENTS, BOOKINGMASTER.BOOKING_ROOMNO AS ROOMNO, BOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, BOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, BOOKINGMASTER.BOOKING_NIGHTS AS DAYS, BOOKINGMASTER.BOOKING_AMT AS BOOKINGAMT, BOOKINGMASTER.BOOKING_DEPOSIT AS DEPOSIT, BOOKINGMASTER.BOOKING_REMARKS AS REMARKS ", "", " BOOKINGMASTER INNER JOIN OFFICERMASTER ON BOOKINGMASTER.BOOKING_OFFICERID = OFFICERMASTER.OFFICER_id AND BOOKINGMASTER.BOOKING_CMPID = OFFICERMASTER.OFFICER_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND BOOKINGMASTER.BOOKING_YEARID = OFFICERMASTER.OFFICER_yearid INNER JOIN HOTELMASTER ON BOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND BOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_CMPID AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_YEARID AND OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID INNER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_CMPID AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_YEARID AND OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID ", WHERECLAUSE)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Convalescent Home Occupancy Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Convalescent Home Occupancy Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Convalescent Home Occupancy Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, , " Statement of the financial Year " & PERIOD, , , True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class