
Imports BL

Public Class Inventory

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLCMB()
        Try
            fillHOTEL(CMBHOTEL, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Inventory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Inventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Enter
        Try
            If CMBHOTEL.Text.Trim = "" Then fillHOTEL(CMBHOTEL, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Validated
        Try
            GETROOMS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTEL.Validating
        Try
            If CMBHOTEL.Text.Trim <> "" Then HOTELvalidate(CMBHOTEL, CMBCODE, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ARRDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ARRDATE.Validating
        If Not datecheck(ARRDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
        GETROOMS()
    End Sub

    Private Sub DEPARTUREDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEPARTUREDATE.Validating
        If Not datecheck(DEPARTUREDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
        GETROOMS()
    End Sub

    Sub GETROOMS()
        Try

            If CMBHOTEL.Text.Trim <> "" And ARRDATE.Value.Date < DEPARTUREDATE.Value.Date Then

                GRIDBOOKINGS.RowCount = 0
                GRIDBOOKINGS.ColumnCount = 0

                'ADDING COLUMS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER INNER JOIN HOTELMASTER_ROOMDESC ON HOTELMASTER.HOTEL_ID = HOTELMASTER_ROOMDESC.HOTEL_ID AND HOTELMASTER.HOTEL_CMPID = HOTELMASTER_ROOMDESC.HOTEL_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = HOTELMASTER_ROOMDESC.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME ='" & CMBHOTEL.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "G" & ROW("ROOMTYPE")
                        OBJ.HeaderText = ROW("ROOMTYPE")
                        OBJ.Width = 130
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        GRIDBOOKINGS.Columns.Add(OBJ)
                    Next
                End If


                'ADDING ROWS
                For I As Integer = 0 To DateDiff(DateInterval.Day, ARRDATE.Value.Date, DEPARTUREDATE.Value.Date) - 1
                    GRIDBOOKINGS.Rows.Add()
                    GRIDBOOKINGS.Rows(I).HeaderCell.Value = Format(DateAdd(DateInterval.Day, I, ARRDATE.Value.Date), "dd/MM/yy")
                Next
                GRIDBOOKINGS.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GRIDBOOKINGS.RowHeadersWidth = 90


                'SET READ ONLY TO FILLED ROOMS
                DT = OBJCMN.search("ROOMNO, BDATE, OFFICERNAME  ", "", " INVENTORY", " AND HOTELNAME = '" & CMBHOTEL.Text.Trim & "' AND BDATE BETWEEN '" & Format(ARRDATE.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(DEPARTUREDATE.Value.Date, "MM/dd/yyyy") & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                        For Each COL As DataGridViewColumn In GRIDBOOKINGS.Columns
                            Dim DTROW() As DataRow = DT.Select("BDATE = '" & Convert.ToDateTime(ROW.HeaderCell.Value).Date & "'")
                            If DTROW.Length > 0 Then
                                For I As Integer = 0 To DTROW.Count - 1
                                    If DTROW(I).Item("ROOMNO") = COL.HeaderText Then
                                        ROW.Cells(COL.Index).ReadOnly = True
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        ROW.Cells(COL.Index).Value = DTROW(I).Item("OFFICERNAME")
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If


                GRIDBOOKINGS.ClearSelection()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class