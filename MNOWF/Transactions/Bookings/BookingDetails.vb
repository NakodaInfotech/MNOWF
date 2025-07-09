
Imports BL

Public Class BookingDetails

    Dim BOOKINGREGID As Integer
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

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  BOOKINGMASTER.BOOKING_no AS SRNO, BOOKINGMASTER.BOOKING_DATE AS DATE, BOOKINGMASTER.BOOKING_INWARDNO AS INWARDNO, SENTBYMASTER.SENTBY_NAME AS SENTBY, OFFICERMASTER.OFFICER_name AS OFFICER, ISNULL(BOOKINGMASTER.BOOKING_INSAFOSMA,'') AS INSAFOSMA, HOTELMASTER.HOTEL_NAME AS HOTEL, BOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, BOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, BOOKINGMASTER.BOOKING_ROOMS AS ROOMS, BOOKINGMASTER.BOOKING_NIGHTS AS NIGHTS, BOOKINGMASTER.BOOKING_AMT AS AMT ", "", "   BOOKINGMASTER INNER JOIN REGISTERMASTER ON BOOKINGMASTER.BOOKING_REGID = REGISTERMASTER.register_id AND BOOKINGMASTER.BOOKING_CMPID = REGISTERMASTER.register_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = REGISTERMASTER.register_locationid AND BOOKINGMASTER.BOOKING_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN HOTELMASTER ON BOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND BOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID LEFT OUTER JOIN OFFICERMASTER ON BOOKINGMASTER.BOOKING_OFFICERID = OFFICERMASTER.OFFICER_id AND BOOKINGMASTER.BOOKING_CMPID = OFFICERMASTER.OFFICER_cmpid AND BOOKINGMASTER.BOOKING_LOCATIONID = OFFICERMASTER.OFFICER_locationid AND BOOKINGMASTER.BOOKING_YEARID = OFFICERMASTER.OFFICER_yearid LEFT OUTER JOIN SENTBYMASTER ON BOOKINGMASTER.BOOKING_SENTBYID = SENTBYMASTER.SENTBY_ID AND BOOKINGMASTER.BOOKING_CMPID = SENTBYMASTER.SENTBY_CMPID AND BOOKINGMASTER.BOOKING_LOCATIONID = SENTBYMASTER.SENTBY_LOCATIONID AND BOOKINGMASTER.BOOKING_YEARID = SENTBYMASTER.SENTBY_YEARID ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                'gridbill.Columns(0).Width = 60
                'gridbill.Columns(1).Width = 70
                'gridbill.Columns(2).Width = 80
                'gridbill.Columns(3).Width = 130
                'gridbill.Columns(4).Width = 130
                'gridbill.Columns(5).Width = 130
                'gridbill.Columns(6).Width = 80
                'gridbill.Columns(7).Width = 80
                'gridbill.Columns(8).Width = 70
                'gridbill.Columns(9).Width = 70
                'gridbill.Columns(10).Width = 70

                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15

            Else
                gridbilldetails.DataSource = dt
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
                Dim OBJINV As New Booking
                OBJINV.MdiParent = MDIMain
                OBJINV.edit = editval
                OBJINV.TEMPBOOKNO = billno
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'BOOKING'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'BOOKING' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'BOOKING' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    BOOKINGREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.BOOKINGMASTER.BOOKING_cmpid=" & CmpId & " and dbo.BOOKINGMASTER.BOOKING_LOCATIONid=" & Locationid & " and dbo.BOOKINGMASTER.BOOKING_YEARid=" & YearId & " AND BOOKINGMASTER.BOOKING_regid = " & BOOKINGREGID & " order by dbo.BOOKINGMASTER.BOOKING_no ")
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
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKINGMasterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL BOOKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Booking Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class