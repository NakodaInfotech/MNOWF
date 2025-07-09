
Imports BL

Public Class ItemInventory

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPINVENTORYNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT ISNULL(ITEMCATEGORYMASTER.ITEMCATEGORY_NAME,'') AS CATEGORY, ISNULL(ITEMMASTER_1.ITEM_NAME,'') AS ITEMNAME, ISNULL(T.ITEMINV_CLOSING,0) AS OPENING", "", " (SELECT     ITEMMASTER.ITEM_NAME, ITEMINVENTORY.ITEMINV_CLOSING, ITEMMASTER.ITEM_ID, HOTELMASTER.HOTEL_NAME FROM ITEMMASTER INNER JOIN ITEMINVENTORY ON ITEMMASTER.ITEM_ID = ITEMINVENTORY.ITEMINV_ITEMID AND ITEMMASTER.ITEM_CMPID = ITEMINVENTORY.ITEMINV_CMPID AND ITEMMASTER.ITEM_LOCATIONID = ITEMINVENTORY.ITEMINV_LOCATIONID AND ITEMMASTER.ITEM_YEARID = ITEMINVENTORY.ITEMINV_YEARID INNER JOIN HOTELMASTER ON ITEMINVENTORY.ITEMINV_HOTELID = HOTELMASTER.HOTEL_ID AND ITEMINVENTORY.ITEMINV_CMPID = HOTELMASTER.HOTEL_CMPID AND ItemInventory.ITEMINV_LOCATIONID = HotelMaster.HOTEL_LOCATIONID And ItemInventory.ITEMINV_YEARID = HotelMaster.HOTEL_YEARID WHERE  (ITEMINVENTORY.ITEMINV_NO = (SELECT  MAX(ITEMINV_NO) AS Expr1 FROM ITEMINVENTORY AS ITEMINVENTORY_1 WHERE (ITEMINV_CMPID = " & CmpId & ") AND (ITEMINV_LOCATIONID = " & Locationid & " ) AND (ITEMINV_YEARID = " & YearId & ")))) AS T INNER JOIN ITEMINVENTORY AS ITEMINVENTORY_2 ON T.ITEM_ID = ITEMINVENTORY_2.ITEMINV_ITEMID RIGHT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 INNER JOIN ITEMCATEGORYMASTER ON ITEMMASTER_1.ITEM_CATEGORYID = ITEMCATEGORYMASTER.ITEMCATEGORY_ID AND ITEMMASTER_1.ITEM_CMPID = ITEMCATEGORYMASTER.ITEMCATEGORY_CMPID AND ITEMMASTER_1.ITEM_LOCATIONID = ITEMCATEGORYMASTER.ITEMCATEGORY_LOCATIONID AND ITEMMASTER_1.ITEM_YEARID = ITEMCATEGORYMASTER.ITEMCATEGORY_YEARID ON ITEMINVENTORY_2.ITEMINV_ITEMID = ITEMMASTER_1.ITEM_ID AND ITEMINVENTORY_2.ITEMINV_CMPID = ITEMMASTER_1.ITEM_CMPID AND ITEMINVENTORY_2.ITEMINV_LOCATIONID = ITEMMASTER_1.ITEM_LOCATIONID AND ITEMINVENTORY_2.ITEMINV_YEARID = ITEMMASTER_1.ITEM_YEARID INNER JOIN HOTELMASTER ON HOTEL_ID = ITEMINVENTORY_2.ITEMINV_HOTELID AND HOTEL_CMPID = ITEMINVENTORY_2.ITEMINV_CMPID AND HOTEL_LOCATIONID = ITEMINVENTORY_2.ITEMINV_LOCATIONID AND HOTEL_YEARID = ITEMINVENTORY_2.ITEMINV_YEARID  ", " AND T.HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND ITEMMASTER_1.ITEM_CMPID = " & CmpId & " AND ITEMMASTER_1.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER_1.ITEM_YEARID = " & YearId)
            'Dim DT As DataTable = OBJCMN.search(" DISTINCT ISNULL(ITEMCATEGORYMASTER.ITEMCATEGORY_NAME,'') AS CATEGORY, ISNULL(ITEMMASTER_1.ITEM_NAME,'') AS ITEMNAME, ISNULL(T.ITEMINV_CLOSING,0) AS OPENING", "", " (SELECT  ITEMMASTER.ITEM_NAME, ITEMINVENTORY.ITEMINV_CLOSING, ITEMMASTER.ITEM_ID FROM ITEMMASTER INNER JOIN ITEMINVENTORY ON ITEMMASTER.ITEM_ID = ITEMINVENTORY.ITEMINV_ITEMID AND ITEMMASTER.ITEM_CMPID = ITEMINVENTORY.ITEMINV_CMPID AND ITEMMASTER.ITEM_LOCATIONID = ITEMINVENTORY.ITEMINV_LOCATIONID AND ITEMMASTER.ITEM_YEARID = ITEMINVENTORY.ITEMINV_YEARID WHERE (ITEMINVENTORY.ITEMINV_NO = (SELECT MAX(ITEMINV_NO) AS Expr1 FROM ITEMINVENTORY AS ITEMINVENTORY_1 WHERE ITEMINV_CMPID = " & CmpId & " AND ITEMINV_LOCATIONID = " & Locationid & " AND ITEMINV_YEARID = " & YearId & " ))) AS T INNER JOIN ITEMINVENTORY AS ITEMINVENTORY_2 ON T.ITEM_ID = ITEMINVENTORY_2.ITEMINV_ITEMID RIGHT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 INNER JOIN ITEMCATEGORYMASTER ON ITEMMASTER_1.ITEM_CATEGORYID = ITEMCATEGORYMASTER.ITEMCATEGORY_ID AND ITEMMASTER_1.ITEM_CMPID = ITEMCATEGORYMASTER.ITEMCATEGORY_CMPID AND ITEMMASTER_1.ITEM_LOCATIONID = ITEMCATEGORYMASTER.ITEMCATEGORY_LOCATIONID AND ITEMMASTER_1.ITEM_YEARID = ITEMCATEGORYMASTER.ITEMCATEGORY_YEARID ON ITEMINVENTORY_2.ITEMINV_ITEMID = ITEMMASTER_1.ITEM_ID AND ITEMINVENTORY_2.ITEMINV_CMPID = ITEMMASTER_1.ITEM_CMPID AND ITEMINVENTORY_2.ITEMINV_LOCATIONID = ITEMMASTER_1.ITEM_LOCATIONID AND ITEMINVENTORY_2.ITEMINV_YEARID = ITEMMASTER_1.ITEM_YEARID INNER JOIN HOTELMASTER ON HOTEL_ID = ITEMINVENTORY_2.ITEMINV_HOTELID AND HOTEL_CMPID = ITEMINVENTORY_2.ITEMINV_CMPID AND HOTEL_LOCATIONID = ITEMINVENTORY_2.ITEMINV_LOCATIONID AND HOTEL_YEARID = ITEMINVENTORY_2.ITEMINV_YEARID  ", " AND HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND ITEMMASTER_1.ITEM_CMPID = " & CmpId & " AND ITEMMASTER_1.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER_1.ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                GRIDITEM.RowCount = 0
                For Each DTROW As DataRow In DT.Rows
                    GRIDITEM.Rows.Add(0, DTROW("CATEGORY"), DTROW("ITEMNAME"), DTROW("OPENING"), 0, 0, 0, 0, "")
                Next
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        EP.Clear()
        tstxtbillno.Clear()
        ITEMDATE.Value = Mydate
        TXTNARR.Clear()
        FILLGRID()
        GETMAX_ITEMNO()
    End Sub

    Sub GETMAX_ITEMNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ITEMINV_NO),0) + 1 ", "ITEMINVENTORY", " AND ITEMINV_cmpid=" & CmpId & " AND ITEMINV_LOCATIONid=" & Locationid & " AND ITEMINV_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTITEMNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub ItemInventory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Or chkchange.CheckState = CheckState.Checked Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Delete
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F1 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJITEM As New ItemInventoryDetails
            OBJITEM.MdiParent = MDIMain
            OBJITEM.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            fillHOTEL(CMBHOTEL, "")
            'FILLGRID()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                
                Dim OBJITEM As New ClsCommon()
                Dim dt As DataTable = OBJITEM.search(" DISTINCT T.ITEMINV_DATE AS ITEMDATE, ISNULL(T.ITEMINV_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMCATEGORYMASTER_1.ITEMCATEGORY_NAME, '') AS ITEMCATEGORY, ISNULL(ITEMMASTER_1.ITEM_NAME, '') AS ITEMNAME, ISNULL(T.ITEMINV_OPSTOCK, 0) AS OPSTOCK, ISNULL(T.ITEMINV_REQ, 0) AS REQ, ISNULL(T.ITEMINV_PASSED, 0) AS PASSED, ISNULL(T.ITEMINV_DAMAGED, 0) AS DAMAGE, ISNULL(T.ITEMINV_CLOSING, 0) AS CLOSING, ISNULL(T.ITEMINV_REMARKS, '') AS REMARKS, ISNULL(T.ITEMINV_NARR, '') AS NARR, ISNULL(T.HOTEL_NAME ,'') AS HOTELNAME ", "", "   (SELECT     ITEMINVENTORY.ITEMINV_DATE, ITEMINVENTORY.ITEMINV_GRIDSRNO, ITEMCATEGORYMASTER.ITEMCATEGORY_NAME, ITEMMASTER.ITEM_NAME, ITEMMASTER.ITEM_ID, ITEMINVENTORY.ITEMINV_OPSTOCK, ITEMINVENTORY.ITEMINV_REQ, ITEMINVENTORY.ITEMINV_PASSED, ITEMINVENTORY.ITEMINV_DAMAGED, ITEMINVENTORY.ITEMINV_CLOSING, ItemInventory.ITEMINV_REMARKS, ItemInventory.ITEMINV_NARR, HotelMaster.HOTEL_NAME FROM ITEMMASTER INNER JOIN ITEMINVENTORY ON ITEMMASTER.ITEM_ID = ITEMINVENTORY.ITEMINV_ITEMID AND ITEMMASTER.ITEM_CMPID = ITEMINVENTORY.ITEMINV_CMPID AND ITEMMASTER.ITEM_LOCATIONID = ITEMINVENTORY.ITEMINV_LOCATIONID AND ITEMMASTER.ITEM_YEARID = ITEMINVENTORY.ITEMINV_YEARID INNER JOIN ITEMCATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = ITEMCATEGORYMASTER.ITEMCATEGORY_ID AND ITEMMASTER.ITEM_CMPID = ITEMCATEGORYMASTER.ITEMCATEGORY_CMPID AND ITEMMASTER.ITEM_LOCATIONID = ITEMCATEGORYMASTER.ITEMCATEGORY_LOCATIONID AND ITEMMASTER.ITEM_YEARID = ITEMCATEGORYMASTER.ITEMCATEGORY_YEARID INNER JOIN HOTELMASTER ON ITEMINVENTORY.ITEMINV_HOTELID = HOTELMASTER.HOTEL_ID AND ITEMINVENTORY.ITEMINV_CMPID = HOTELMASTER.HOTEL_CMPID AND ITEMINVENTORY.ITEMINV_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND ITEMINVENTORY.ITEMINV_YEARID = HOTELMASTER.HOTEL_YEARID WHERE (ITEMINVENTORY.ITEMINV_NO = " & TEMPINVENTORYNO & " AND ITEMINVENTORY.ITEMINV_CMPID =  " & CmpId & " AND ITEMINVENTORY.ITEMINV_LOCATIONID = " & Locationid & " AND ITEMINVENTORY.ITEMINV_YEARID = " & YearId & ")) AS T INNER JOIN ITEMINVENTORY AS ITEMINVENTORY_2 ON T.ITEM_ID = ITEMINVENTORY_2.ITEMINV_ITEMID RIGHT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 INNER JOIN ITEMCATEGORYMASTER AS ITEMCATEGORYMASTER_1 ON ITEMMASTER_1.ITEM_CATEGORYID = ITEMCATEGORYMASTER_1.ITEMCATEGORY_ID AND ITEMMASTER_1.ITEM_CMPID = ITEMCATEGORYMASTER_1.ITEMCATEGORY_CMPID AND ITEMMASTER_1.ITEM_LOCATIONID = ITEMCATEGORYMASTER_1.ITEMCATEGORY_LOCATIONID AND ITEMMASTER_1.ITEM_YEARID = ITEMCATEGORYMASTER_1.ITEMCATEGORY_YEARID ON ITEMINVENTORY_2.ITEMINV_ITEMID = ITEMMASTER_1.ITEM_ID AND ITEMINVENTORY_2.ITEMINV_CMPID = ITEMMASTER_1.ITEM_CMPID AND ITEMINVENTORY_2.ITEMINV_LOCATIONID = ITEMMASTER_1.ITEM_LOCATIONID AND ITEMINVENTORY_2.ITEMINV_YEARID = ITEMMASTER_1.ITEM_YEARID ", "")
                If dt.Rows.Count > 0 Then
                    GRIDITEM.RowCount = 0
                    For Each dr As DataRow In dt.Rows
                        TXTITEMNO.Text = TEMPINVENTORYNO
                        If IsDBNull(dr("ITEMDATE")) = False Then ITEMDATE.Value = Convert.ToDateTime(dr("ITEMDATE")).Date
                        TXTNARR.Text = dr("NARR")
                        CMBHOTEL.Text = dr("HOTELNAME")
                        GRIDITEM.Rows.Add(dr("GRIDSRNO"), dr("ITEMCATEGORY"), dr("ITEMNAME"), Format(Val(dr("OPSTOCK")), "0.00"), Format(Val(dr("REQ")), "0.00"), Format(Val(dr("PASSED")), "0.00"), Format(Val(dr("DAMAGE")), "0.00"), Format(Val(dr("CLOSING")), "0.00"), dr("REMARKS"))
                    Next
                    TOTAL()
                    chkchange.CheckState = CheckState.Checked
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            ToolStripdelete_Click(sender, e)
            DELETE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ITEMDATE.Validating
        If Not datecheck(ITEMDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In GRIDITEM.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno()
            TOTAL()

            Dim alParaval As New ArrayList

            alParaval.Add(Val(CMBHOTEL.Text.Trim))
            alParaval.Add(Format(ITEMDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Val(TXTOPSTOCK.Text.Trim))
            alParaval.Add(Val(TXTREQ.Text.Trim))
            alParaval.Add(Val(TXTPASSED.Text.Trim))
            alParaval.Add(Val(TXTDAMAGED.Text.Trim))
            alParaval.Add(Val(TXTCLOSING.Text.Trim))

            Dim GRIDSRNO As String = ""
            Dim CATEGORY As String = ""
            Dim ITEMNAME As String = ""
            Dim OPSTOCK As String = ""
            Dim REQ As String = ""
            Dim PASSED As String = ""
            Dim DAMAGE As String = ""
            Dim CLOSING As String = ""
            Dim REMARKS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDITEM.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        CATEGORY = row.Cells(GCATEGORY.Index).Value
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        OPSTOCK = Val(row.Cells(GOP.Index).Value)
                        REQ = Val(row.Cells(GREQ.Index).Value)
                        PASSED = Val(row.Cells(GPASSED.Index).Value)
                        DAMAGE = Val(row.Cells(GDAMAGED.Index).Value)
                        CLOSING = Val(row.Cells(GCLOSING.Index).Value)
                        REMARKS = row.Cells(GREMARKS.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        CATEGORY = CATEGORY & "," & row.Cells(GCATEGORY.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value.ToString
                        OPSTOCK = OPSTOCK & "," & Val(row.Cells(GOP.Index).Value)
                        REQ = REQ & "," & Val(row.Cells(GREQ.Index).Value)
                        PASSED = PASSED & "," & Val(row.Cells(GPASSED.Index).Value)
                        DAMAGE = DAMAGE & "," & Val(row.Cells(GDAMAGED.Index).Value)
                        CLOSING = CLOSING & "," & Val(row.Cells(GCLOSING.Index).Value)
                        REMARKS = REMARKS & "," & row.Cells(GREMARKS.Index).Value

                    End If
                End If
            Next


            alParaval.Add(GRIDSRNO)
            alParaval.Add(CATEGORY)
            alParaval.Add(ITEMNAME)
            alParaval.Add(OPSTOCK)
            alParaval.Add(REQ)
            alParaval.Add(PASSED)
            alParaval.Add(DAMAGE)
            alParaval.Add(CLOSING)
            alParaval.Add(REMARKS)
            alParaval.Add(TXTNARR.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJITEM As New ClsItemInventory
            OBJITEM.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJITEM.save()
                MessageBox.Show("Details Added")
                Dim TEMPMSG As Integer = MsgBox("Print Stock Statement?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then PRINTREPORT(DT.Rows(0).Item(0))
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPINVENTORYNO)
                DT = OBJITEM.update()
                MsgBox("Details Updated")
                Dim TEMPMSG As Integer = MsgBox("Print Stock Statement?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then PRINTREPORT(TEMPINVENTORYNO)
            End If

            clear()
            edit = False
            ITEMDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBHOTEL.Text.Trim.Length = 0 Then
            EP.SetError(CMBHOTEL, "Fill Convalescent Name")
            bln = False
        End If

        If GRIDITEM.RowCount = 0 Then
            EP.SetError(ITEMDATE, "Fill Item Details")
            bln = False
        End If

        If Not datecheck(ITEMDATE.Value) Then
            EP.SetError(ITEMDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln
    End Function

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDITEM.RowCount = 0
            TEMPINVENTORYNO = Val(TXTITEMNO.Text) + 1
            GETMAX_ITEMNO()
            clear()
            If Val(TXTITEMNO.Text) - 1 >= TEMPINVENTORYNO Then
                edit = True
                ItemInventory_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDITEM.RowCount = 0
            TEMPINVENTORYNO = Val(TXTITEMNO.Text) - 1
            If TEMPINVENTORYNO > 0 Then
                edit = True
                ItemInventory_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
    End Sub

    Sub DELETE()
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDITEM.RowCount = 0
            TEMPINVENTORYNO = Val(tstxtbillno.Text)
            If TEMPINVENTORYNO > 0 Then
                edit = True
                ItemInventory_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDITEM_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDITEM.CellValidating
        Try
            Dim colNum As Integer = GRIDITEM.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GOP.Index, GREQ.Index, GPASSED.Index, GDAMAGED.Index, GCLOSING.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDITEM.CurrentCell.Value = Nothing Then GRIDITEM.CurrentCell.Value = "0.00"
                        GRIDITEM.CurrentCell.Value = Convert.ToDecimal(GRIDITEM.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                    TOTAL()

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTOPSTOCK.Clear()
            TXTREQ.Clear()
            TXTPASSED.Clear()
            TXTDAMAGED.Clear()
            TXTCLOSING.Clear()
            For Each ROW As DataGridViewRow In GRIDITEM.Rows
                If ROW.Cells(GITEMNAME.Index).Value <> "" Then
                    ROW.Cells(GCLOSING.Index).Value = Convert.ToDecimal((Val(ROW.Cells(GOP.Index).EditedFormattedValue) + Val(ROW.Cells(GPASSED.Index).EditedFormattedValue)) - Val(ROW.Cells(GDAMAGED.Index).EditedFormattedValue))
                    TXTOPSTOCK.Text = Format(Val(TXTOPSTOCK.Text.Trim) + Val(ROW.Cells(GOP.Index).Value), "0.00")
                    TXTREQ.Text = Format(Val(TXTREQ.Text.Trim) + Val(ROW.Cells(GREQ.Index).Value), "0.00")
                    TXTPASSED.Text = Format(Val(TXTPASSED.Text.Trim) + Val(ROW.Cells(GPASSED.Index).Value), "0.00")
                    TXTDAMAGED.Text = Format(Val(TXTDAMAGED.Text.Trim) + Val(ROW.Cells(GDAMAGED.Index).Value), "0.00")
                    TXTCLOSING.Text = Format(Val(TXTCLOSING.Text.Trim) + Val(ROW.Cells(GCLOSING.Index).Value), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPINVENTORYNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal ITEMINVNO As Integer)
        Try
            Dim OBJINV As New InventoryDesign
            OBJINV.MdiParent = MDIMain
            OBJINV.ITEMINVNO = ITEMINVNO
            OBJINV.Show()
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

    Private Sub CMBHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTEL.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Validated
        If CMBHOTEL.Text.Trim <> "" Then FILLGRID()
    End Sub

    Private Sub CMBHOTEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTEL.Validating
        Try
            If CMBHOTEL.Text.Trim <> "" Then HOTELvalidate(CMBHOTEL, CMBCODE, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class