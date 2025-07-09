
Imports BL

Public Class CategoryDetails

    Public frmstring As String      'Used for form Category or GRade

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CategoryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CATEGORY" Then
            dttable = objClsCommon.search(" category_name, category_id", "", "categorymaster", " and category_cmpid = " & CmpId & "   and category_locationid = " & Locationid & "  and category_yearid = " & YearId)
        ElseIf frmstring = "MATERIAL TYPE" Then
            dttable = objClsCommon.search(" material_name, material_id", "", "materialtypemaster", " and material_cmpid = " & CmpId & " and material_LOCAtionid = " & Locationid & " and material_YEARid = " & YearId)
        ElseIf frmstring = "RANK" Then
            dttable = objClsCommon.search(" RANK_name, RANK_id", "", "RANKmaster", " and RANK_cmpid = " & CmpId & "  and RANK_LOCATIONid = " & Locationid & "  and RANK_YEARid = " & YearId)
        ElseIf frmstring = "COMPANY" Then
            dttable = objClsCommon.search(" COMPANY_name, COMPANY_id", "", "COMPANYmaster", " and COMPANY_cmpid = " & CmpId & " and COMPANY_LOCATIONid = " & Locationid & " and COMPANY_YEARid = " & YearId)
        ElseIf frmstring = "NARRATION" Then
            dttable = objClsCommon.search(" NARRATION_name, NARRATION_id", "", "NARRATIONmaster", " and NARRATION_cmpid = " & CmpId & " and NARRATION_LOCATIONid = " & Locationid & " and NARRATION_YEARid = " & YearId)
        ElseIf frmstring = "DOCTYPE" Then
            dttable = objClsCommon.search(" DOCTYPE_name, DOCTYPE_id", "", "DOCTYPEmaster", " and DOCTYPE_cmpid = " & CmpId & " and DOCTYPE_LOCATIONid = " & Locationid & " and DOCTYPE_YEARid = " & YearId)
        ElseIf frmstring = "ITEMCATEGORY" Then
            dttable = objClsCommon.search(" ITEMCATEGORY_name, ITEMCATEGORY_id", "", "ITEMCATEGORYmaster", " and ITEMCATEGORY_cmpid = " & CmpId & " and ITEMCATEGORY_LOCATIONid = " & Locationid & " and ITEMCATEGORY_YEARid = " & YearId)
        ElseIf frmstring = "SENTBY" Then
            dttable = objClsCommon.search(" SENTBY_name, SENTBY_id", "", "SENTBYmaster", " and SENTBY_cmpid = " & CmpId & " and SENTBY_LOCATIONid = " & Locationid & " and SENTBY_YEARid = " & YearId)
        ElseIf frmstring = "COURSE" Then
            dttable = objClsCommon.search(" COURSE_name, COURSE_id", "", "COURSEmaster", " and COURSE_YEARid = " & YearId)
        ElseIf frmstring = "COURSEYEAR" Then
            dttable = objClsCommon.search(" COURSEYEAR_name, COURSEYEAR_id", "", "COURSEYEARmaster", " and COURSEYEAR_YEARid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        If dttable.Rows.Count > 0 Then
            gridgroup.Columns(0).HeaderText = "Name"

            gridgroup.Columns(0).Width = 250
            gridgroup.Columns(1).Visible = False
            gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
            If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1
        End If
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
            If frmstring = "NARRATION" Then
                Dim objCategorymaster As New NarrationMaster
                objCategorymaster.edit = editval
                objCategorymaster.MdiParent = MDIMain
                objCategorymaster.TempName = name
                objCategorymaster.TempID = id
                objCategorymaster.Show()
            Else
                Dim objCategorymaster As New CategoryMaster
                objCategorymaster.edit = editval
                objCategorymaster.MdiParent = MDIMain
                objCategorymaster.frmString = frmstring
                objCategorymaster.TempName = name
                objCategorymaster.TempID = id
                objCategorymaster.Show()
            End If
            
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