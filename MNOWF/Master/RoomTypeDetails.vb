
Imports BL

Public Class RoomTypeDetails

    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub rOOMtYPEDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for edit
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.KeyCode = Windows.Forms.Keys.A) Then   'for Exit
            showform(False, "", 0)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RoomTypeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "ROOMTYPE" Then
                Me.Text = "Room Type Master"
            ElseIf FRMSTRING = "HOTELTYPE" Then
                Me.Text = "Hotel Type Master"
            ElseIf FRMSTRING = "GROUPOFHOTELS" Then
                Me.Text = "Group Of Hotels"
            ElseIf FRMSTRING = "AMENITIES" Then
                Me.Text = "Amenities Master"
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If FRMSTRING = "ROOMTYPE" Then
            dttable = objClsCommon.search(" ROOMTYPE_name, ROOMTYPE_id", "", "ROOMTYPEmaster", " and ROOMTYPE_cmpid = " & CmpId & " and ROOMTYPE_Locationid = " & Locationid & " and ROOMTYPE_Yearid = " & YearId)
        ElseIf FRMSTRING = "HOTELTYPE" Then
            dttable = objClsCommon.search(" HOTELTYPE_name, HOTELTYPE_id", "", "HOTELtypemaster", " and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_Locationid = " & Locationid & " and HOTELTYPE_Yearid = " & YearId)
        ElseIf FRMSTRING = "GROUPOFHOTELS" Then
            dttable = objClsCommon.search(" GROUPOFHOTELS_name, GROUPOFHOTELS_id", "", "GROUPOFHOTELSmaster", " and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_Locationid = " & Locationid & " and GROUPOFHOTELS_Yearid = " & YearId)
        ElseIf FRMSTRING = "AMENITIES" Then
            dttable = objClsCommon.search(" AMENITIES_name, AMENITIES_id", "", "AMENITIESmaster", " and AMENITIES_cmpid = " & CmpId & " and AMENITIES_Locationid = " & Locationid & " and AMENITIES_Yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"

        gridgroup.Columns(0).Width = 250
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try
            Dim OBJROOM As New RoomTypeMaster
            OBJROOM.edit = editval
            OBJROOM.MdiParent = MDIMain
            OBJROOM.FRMSTRING = FRMSTRING
            OBJROOM.TempName = name
            OBJROOM.TempID = id
            OBJROOM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridgroup.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

End Class