
Imports BL

Public Class Attendence

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Attendence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then
                Call cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDATT.RowCount > 0 Then
                If GRIDATT.SelectedRows.Count >= 0 Then
                    Dim OBJATT As New AttendenceDetails
                    OBJATT.MdiParent = MDIMain
                    OBJATT.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATE()
        Try
            If CMBMONTH.Text.Trim = "January" Then
                dtfrom.Value = "01/01/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "February" Then
                dtfrom.Value = "01/02/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "March" Then
                dtfrom.Value = "01/03/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "April" Then
                dtfrom.Value = "01/04/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "May" Then
                dtfrom.Value = "01/05/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "June" Then
                dtfrom.Value = "01/06/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "July" Then
                dtfrom.Value = "01/07/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "August" Then
                dtfrom.Value = "01/08/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "September" Then
                dtfrom.Value = "01/09/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "October" Then
                dtfrom.Value = "01/10/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "November" Then
                dtfrom.Value = "01/11/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "December" Then
                dtfrom.Value = "01/12/" & Year(AccFrom)
            End If
            dtto.Value = dtfrom.Value.AddMonths(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GETDATE()
            GETATT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETATT()
        Try
            If dtfrom.Value.Date < dtto.Value.Date Then
                GRIDATT.RowCount = 0
                GRIDATT.ColumnCount = 0

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable

                DTDAY.Value = dtfrom.Value
                'ADDING COLUMS
                For I As Integer = 1 To DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
                    Dim OBJ As New DataGridViewCheckBoxColumn
                    OBJ.Name = "G" & I
                    OBJ.HeaderText = I
                    OBJ.Width = 30
                    OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                    OBJ.Resizable = DataGridViewTriState.False

                    'If DAY IS SUNDAY THEN CHANGE THE COLOR

                    If DTDAY.Value.DayOfWeek = DayOfWeek.Sunday Then
                        OBJ.DefaultCellStyle.BackColor = Color.Pink
                        'OBJ.ReadOnly = True
                    Else
                        'IF IT IS IN HOLIDAYMASTER THEN PINK COLOR 
                        DT = OBJCMN.search(" HOLIDAY_REMARKS", "", " HOLIDAYMASTER", " AND HOLIDAY_DATE = '" & Format(DTDAY.Value.Date, "MM/dd/yyyy") & "' AND HOLIDAY_CMPID = " & CmpId & " AND HOLIDAY_LOCATIONID = " & Locationid & " AND HOLIDAY_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            OBJ.DefaultCellStyle.BackColor = Color.LightPink
                            'OBJ.ReadOnly = True
                        Else
                            OBJ.DefaultCellStyle.BackColor = Color.LightGreen
                        End If
                    End If


                    'OBJ.ReadOnly = True
                    GRIDATT.Columns.Add(OBJ)
                    If DTDAY.Value.DayOfWeek = DayOfWeek.Sunday Then GRIDATT.Columns(GRIDATT.ColumnCount - 1).ReadOnly = True
                    DTDAY.Value = DateAdd(DateInterval.Day, I, dtfrom.Value.Date)

                Next

                'ADD 3MORE COLUMNS
                For I = 0 To 2
                    If I = 0 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GTOTAL"
                        OBJ.HeaderText = "Total Days"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        OBJ.DefaultCellStyle.BackColor = Color.LightBlue
                        GRIDATT.Columns.Add(OBJ)
                    ElseIf I = 1 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GPRESENT"
                        OBJ.HeaderText = "Present"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        OBJ.DefaultCellStyle.BackColor = Color.Yellow
                        GRIDATT.Columns.Add(OBJ)
                    ElseIf I = 2 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GABSENT"
                        OBJ.HeaderText = "Absent"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        OBJ.DefaultCellStyle.BackColor = Color.LightGreen
                        GRIDATT.Columns.Add(OBJ)
                    End If
                Next
                


                'ADDING ROWS
                DT = OBJCMN.search(" EMP_NAME AS EMPNAME", "", " EMPLOYEEMASTER ", " AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        GRIDATT.Rows.Add()
                        GRIDATT.Rows(GRIDATT.RowCount - 1).HeaderCell.Value = ROW("EMPNAME")
                    Next
                    GRIDATT.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    GRIDATT.RowHeadersWidth = 130
                End If


                'SET ATTENDENCE
                Dim TPRESENT As Integer = 0
                DT = OBJCMN.search(" DISTINCT  EMPLOYEEMASTER.EMP_NAME AS EMPNAME, DAY(ATTENDENCE.ATT_DATE) AS ATTDATE ", "", " ATTENDENCE INNER JOIN EMPLOYEEMASTER ON ATTENDENCE.ATT_EMPID = EMPLOYEEMASTER.EMP_id AND ATTENDENCE.ATT_CMPID = EMPLOYEEMASTER.EMP_cmpid AND ATTENDENCE.ATT_LOCATIONID = EMPLOYEEMASTER.EMP_locationid AND ATTENDENCE.ATT_YEARID = EMPLOYEEMASTER.EMP_yearid", " AND ATT_DATE BETWEEN '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND ATT_CMPID = " & CmpId & " AND ATT_LOCATIONID = " & Locationid & " AND ATT_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataGridViewRow In GRIDATT.Rows
                        For Each COL As DataGridViewColumn In GRIDATT.Columns
                            Dim DTROW() As DataRow = DT.Select("EMPNAME = '" & (ROW.HeaderCell.Value) & "'")
                            If DTROW.Length > 0 Then
                                For I As Integer = 0 To DTROW.Count - 1
                                    If Convert.ToString(DTROW(I).Item("ATTDATE")) = COL.HeaderText.ToString Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        ROW.Cells(COL.Index).Value = True
                                        TPRESENT += 1
                                    ElseIf COL.HeaderText = "Total Days" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.LightBlue
                                        ROW.Cells(COL.Index).Value = DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
                                    ElseIf COL.HeaderText = "Present" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        ROW.Cells(COL.Index).Value = TPRESENT
                                    ElseIf COL.HeaderText = "Absent" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.LightGreen
                                        ROW.Cells(COL.Index).Value = (DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date) - TPRESENT)
                                    End If
                                Next
                            End If
                        Next
                        TOTAL(ROW.Index)
                    Next
                    GRIDATT.ClearSelection()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DELETERECORD(ByVal ROW As Integer, ByVal COL As Integer)
        Try

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            'GET ENROLLNO
            Dim OBJCMN As New ClsCommon
            Dim ATT As New ClsAttendence
            Dim DT As DataTable = OBJCMN.search(" EMP_ENROLLNO AS ENROLLNO ", "", " EMPLOYEEMASTER ", " AND EMP_NAME = '" & GRIDATT.Rows(ROW).HeaderCell.Value & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)

            ALPARAVAL.Add(DT.Rows(0).Item("ENROLLNO"))

            DTDAY.Value = DateAdd(DateInterval.Day, Convert.ToDouble(GRIDATT.Columns(COL).HeaderText) - 1, dtfrom.Value.Date)
            ALPARAVAL.Add(DTDAY.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            ATT.alParaval = ALPARAVAL
            DT = ATT.Delete()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDRECORD(ByVal ROW As Integer, ByVal COL As Integer)
        Try

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            Dim ALPARAVAL As New ArrayList
            'GET ENROLLNO
            Dim OBJCMN As New ClsCommon
            Dim ATT As New ClsAttendence
            Dim DT As DataTable = OBJCMN.search(" EMP_ENROLLNO AS ENROLLNO ", "", " EMPLOYEEMASTER ", " AND EMP_NAME = '" & GRIDATT.Rows(ROW).HeaderCell.Value & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)

            ALPARAVAL.Add(DT.Rows(0).Item("ENROLLNO"))

            DTDAY.Value = DateAdd(DateInterval.Day, Convert.ToDouble(GRIDATT.Columns(COL).HeaderText) - 1, dtfrom.Value.Date)
            ALPARAVAL.Add(DTDAY.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            ATT.alParaval = ALPARAVAL
            DT = ATT.save()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDATT_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDATT.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                With GRIDATT.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If e.ColumnIndex < GRIDATT.ColumnCount - 3 Then
                        If .Value = True Then
                            .Value = False

                            Dim OBJCMN As New ClsCommon
                            Dim DT As DataTable
                            DTDAY.Value = DateAdd(DateInterval.Day, Convert.ToDouble(GRIDATT.Columns(e.ColumnIndex).HeaderText) - 1, dtfrom.Value.Date)
                            If DTDAY.Value.DayOfWeek = DayOfWeek.Sunday Then
                                .Style.BackColor = Color.Pink
                            Else
                                'IF IT IS IN HOLIDAYMASTER THEN PINK COLOR 
                                DT = OBJCMN.search(" HOLIDAY_REMARKS", "", " HOLIDAYMASTER", " AND HOLIDAY_DATE = '" & Format(DTDAY.Value.Date, "MM/dd/yyyy") & "' AND HOLIDAY_CMPID = " & CmpId & " AND HOLIDAY_LOCATIONID = " & Locationid & " AND HOLIDAY_YEARID = " & YearId)
                                If DT.Rows.Count > 0 Then
                                    .Style.BackColor = Color.Pink
                                Else
                                    .Style.BackColor = Color.LightGreen
                                End If
                            End If

                            DELETERECORD(e.RowIndex, e.ColumnIndex)
                        Else
                            .Value = True
                            .Style.BackColor = Color.Yellow
                            ADDRECORD(e.RowIndex, e.ColumnIndex)
                        End If
                        TOTAL(e.RowIndex)
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDATT_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDATT.CellValidating
        Try
            If e.RowIndex >= 0 Then TOTAL(e.RowIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL(ByVal ROWINDEX As Integer)
        Try
            GRIDATT.Rows(ROWINDEX).Cells("GTOTAL").Value = 0
            GRIDATT.Rows(ROWINDEX).Cells("GPRESENT").Value = 0
            GRIDATT.Rows(ROWINDEX).Cells("GABSENT").Value = 0

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            For Each COL As DataGridViewColumn In GRIDATT.Columns
                If COL.Index < GRIDATT.ColumnCount - 3 Then
                    DTDAY.Value = DateAdd(DateInterval.Day, Convert.ToDouble(COL.HeaderText) - 1, dtfrom.Value.Date)
                    DT = OBJCMN.search(" HOLIDAY_REMARKS", "", " HOLIDAYMASTER", " AND HOLIDAY_DATE = '" & Format(DTDAY.Value.Date, "MM/dd/yyyy") & "' AND HOLIDAY_CMPID = " & CmpId & " AND HOLIDAY_LOCATIONID = " & Locationid & " AND HOLIDAY_YEARID = " & YearId)
                    If DT.Rows.Count = 0 And DTDAY.Value.DayOfWeek <> DayOfWeek.Sunday Then
                        GRIDATT.Rows(ROWINDEX).Cells("GTOTAL").Value = Val(GRIDATT.Rows(ROWINDEX).Cells("GTOTAL").Value) + 1
                    End If
                    If GRIDATT.Rows(ROWINDEX).Cells(COL.Index).Value = True Then GRIDATT.Rows(ROWINDEX).Cells("GPRESENT").Value = Val(GRIDATT.Rows(ROWINDEX).Cells("GPRESENT").Value) + 1
                    GRIDATT.Rows(ROWINDEX).Cells("GABSENT").Value = Val(GRIDATT.Rows(ROWINDEX).Cells("GTOTAL").Value) - Val(GRIDATT.Rows(ROWINDEX).Cells("GPRESENT").Value)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBMONTH.Text.Trim = "" Then
                EP.SetError(CMBMONTH, "Select Month")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Attendence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYROLL'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class