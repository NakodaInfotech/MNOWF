Imports BL

Public Class CategoryMaster

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If txtname.Text.Trim <> "" Then
                If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                    If frmString = "CATEGORY" Then
                        dt = objclscommon.search("category_name", "", "CategoryMaster", " and category_name = '" & txtname.Text.Trim & "' and category_cmpid =" & CmpId & "   and category_locationid = " & Locationid & "  and category_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Category Name Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "MATERIAL TYPE" Then
                        dt = objclscommon.search("material_name", "", "MaterialTypeMaster", " and material_name = '" & txtname.Text.Trim & "' and material_cmpid = " & CmpId & " and material_LOCAtionid = " & Locationid & " and material_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Material Type Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "COURSE" Then
                        dt = objclscommon.search("COURSE_name", "", "COURSEMaster", " and COURSE_name = '" & txtname.Text.Trim & "' and COURSE_cmpid = " & CmpId & "  and COURSE_LOCATIONid = " & Locationid & "  and COURSE_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("COURSE Name Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "COURSEYEAR" Then
                        dt = objclscommon.search("COURSEYEAR_name", "", "COURSEYEARMaster", " and COURSEYEAR_name = '" & txtname.Text.Trim & "' and COURSEYEAR_cmpid = " & CmpId & "  and COURSEYEAR_LOCATIONid = " & Locationid & "  and COURSEYEAR_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("COURSEYEAR Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "RANK" Then
                        dt = objclscommon.search("RANK_name", "", "RANKMaster", " and RANK_name = '" & txtname.Text.Trim & "' and RANK_cmpid = " & CmpId & "  and RANK_LOCATIONid = " & Locationid & "  and RANK_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("RANK Name Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "COMPANY" Then
                        dt = objclscommon.search("COMPANY_name", "", "COMPANYMaster", " and COMPANY_name = '" & txtname.Text.Trim & "' and COMPANY_cmpid = " & CmpId & " and COMPANY_LOCATIONid = " & Locationid & " and COMPANY_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("COMPANY Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "NARRATION" Then
                        dt = objclscommon.search("NARRATION_name", "", "NARRATIONMaster", " and NARRATION_name = '" & txtname.Text.Trim & "' and NARRATION_cmpid = " & CmpId & " and NARRATION_LOCATIONid = " & Locationid & " and NARRATION_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("NARRATION Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "DOCTYPE" Then
                        dt = objclscommon.search("DOCTYPE_name", "", "DOCTYPEMaster", " and DOCTYPE_name = '" & txtname.Text.Trim & "' and DOCTYPE_cmpid = " & CmpId & " and DOCTYPE_LOCATIONid = " & Locationid & " and DOCTYPE_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("DOCTYPE Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "SENTBY" Then
                        dt = objclscommon.search("SENTBY_name", "", "SENTBYMaster", " and SENTBY_name = '" & txtname.Text.Trim & "' and SENTBY_cmpid = " & CmpId & " and SENTBY_LOCATIONid = " & Locationid & " and SENTBY_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("SENTBY Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "ITEMCATEGORY" Then
                        dt = objclscommon.search("ITEMCATEGORY_name", "", "ITEMCATEGORYMaster", " and ITEMCATEGORY_name = '" & txtname.Text.Trim & "' and ITEMCATEGORY_cmpid = " & CmpId & " and ITEMCATEGORY_LOCATIONid = " & Locationid & " and ITEMCATEGORY_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Item Category Already Exists", MsgBoxStyle.Critical, "MNOWF")
                            e.Cancel = True
                        End If
                    End If
                End If
                pcase(txtname)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "CATEGORY" Then
                Dim objclscategorymaster As New ClsCategoryMaster
                objclscategorymaster.alParaval = alParaval

                If edit = False Then
                    alParaval.Add(cmbregister.Text.Trim)

                    IntResult = objclscategorymaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(cmbregister.Text.Trim)
                    alParaval.Add(TempID)
                    IntResult = objclscategorymaster.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "COURSE" Then
                Dim OBJCOURSE As New ClsCourseMaster
                OBJCOURSE.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJCOURSE.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJCOURSE.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "COURSEYEAR" Then
                Dim OBJCOURSEYEAR As New ClsCourseYearMaster
                OBJCOURSEYEAR.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJCOURSEYEAR.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJCOURSEYEAR.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "RANK" Then
                Dim OBJRANK As New ClsRankMaster
                OBJRANK.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJRANK.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJRANK.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "COMPANY" Then
                Dim OBJCOMPANY As New ClsCompanyMaster
                OBJCOMPANY.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJCOMPANY.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJCOMPANY.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "NARRATION" Then
                Dim OBJNARRATION As New ClsNARRATIONMaster
                OBJNARRATION.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJNARRATION.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJNARRATION.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "DOCTYPE" Then
                Dim OBJDOCTYPE As New ClsDocTypeMaster
                OBJDOCTYPE.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJDOCTYPE.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJDOCTYPE.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "SENTBY" Then
                Dim OBJSENTBY As New ClsSentByMaster
                OBJSENTBY.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJSENTBY.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJSENTBY.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "ITEMCATEGORY" Then
                Dim OBJITEMCATEGORY As New ClsItemCategory
                OBJITEMCATEGORY.alParaval = alParaval

                If edit = False Then
                    IntResult = OBJITEMCATEGORY.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    alParaval.Add(TempID)
                    IntResult = OBJITEMCATEGORY.Update()
                    MsgBox("Details Updated")
                End If

            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If
        If frmString = "CATERGORY" Then
            If cmbregister.Text.Trim.Length = 0 Then
                Ep.SetError(cmbregister, "Fill Register")
                bln = False
            End If
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
       
        If frmString = "CATEGORY" Then
            lblregister.Visible = True
            cmbregister.Visible = True

        Else
            lblregister.Visible = False
            cmbregister.Visible = False
        End If
        cmbregister.Text = ""

        txtremarks.Clear()
    End Sub

    Private Sub CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Oemcomma Then
            'e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub CategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            lblregister.Visible = False
            cmbregister.Visible = False
            If frmString = "CATEGORY" Then
                lblregister.Visible = True
                cmbregister.Visible = True
                Me.Text = "Category Master"
                lblgroup.Text = "Category"
                lbl.Text = "Enter Category" & vbNewLine & "(e.g.  DENTAL, MATERNITY,..., etc. )"
                If edit = True Then
                    dttable = objCommon.search("  CATEGORYMASTER.CATEGORY_NAME, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME,  ISNULL(CATEGORY_REMARKS,'') AS REMARKS", "", "  CATEGORYMASTER left outer JOIN REGISTERMASTER ON CATEGORYMASTER.CATEGORY_REGISTERID = REGISTERMASTER.register_id AND CATEGORYMASTER.CATEGORY_CMPID = REGISTERMASTER.register_cmpid AND CATEGORYMASTER.CATEGORY_LOCATIONID = REGISTERMASTER.register_locationid AND CATEGORYMASTER.CATEGORY_YEARID = REGISTERMASTER.register_yearid", " and category_id = " & TempID & " and category_cmpid = " & CmpId & "   and category_locationid = " & Locationid & "  and category_yearid = " & YearId)
                    cmbregister.Text = dttable.Rows(0).Item("REGNAME")
                End If

            ElseIf frmString = "MATERIAL TYPE" Then

                Me.Text = "Material Master"
                lblgroup.Text = "Material"
                lbl.Text = "Enter Material Type " & vbNewLine & "(e.g.  Raw,Trading Material..., etc. )"
                If edit = True Then dttable = objCommon.search(" material_name, MATERIAL_REMARKS AS REMARKS", "", "MaterialTypeMaster", " and material_id = " & TempID & "  and material_cmpid = " & CmpId & " and material_LOCAtionid = " & Locationid & " and material_YEARid = " & YearId)

            ElseIf frmString = "RANK" Then

                Me.Text = "RANK Master"
                lblgroup.Text = "RANK"
                lbl.Text = "Enter Rank" & vbNewLine & "(e.g.  Captain, Cadet..., etc. )"
                If edit = True Then dttable = objCommon.search(" RANK_name, RANK_REMARKS AS REMARKS", "", "RANKMaster", " and RANK_id = " & TempID & " and RANK_cmpid = " & CmpId & "  and RANK_LOCATIONid = " & Locationid & "  and RANK_YEARid = " & YearId)

            ElseIf frmString = "COMPANY" Then

                Me.Text = "COMPANY Master"
                lblgroup.Text = "COMPANY"
                gb.Text = "Address"
                lbl.Text = "Enter Company Name" & vbNewLine & "(e.g.  Shipping Company..., etc. )"
                If edit = True Then dttable = objCommon.search(" COMPANY_name as COMPANYNAME , COMPANY_REMARKS AS REMARKS ", "", "COMPANYMaster", " and COMPANY_id = " & TempID & " and COMPANY_cmpid = " & CmpId & " and COMPANY_LOCATIONid = " & Locationid & " and COMPANY_YEARid = " & YearId)

            ElseIf frmString = "NARRATION" Then

                Me.Text = "NARRATION Master"
                lblgroup.Text = "NARRATION"
                lbl.Text = "Enter NARRATION Name" '& vbNewLine & "(e.g.  Shipping NARRATION..., etc. )"
                If edit = True Then dttable = objCommon.search(" NARRATION_name, NARRATION_REMARKS AS REMARKS", "", "NARRATIONMaster", " and NARRATION_id = " & TempID & " and NARRATION_cmpid = " & CmpId & " and NARRATION_LOCATIONid = " & Locationid & " and NARRATION_YEARid = " & YearId)

            ElseIf frmString = "DOCTYPE" Then

                Me.Text = "DOCTYPE Master"
                lblgroup.Text = "DOCTYPE"
                lbl.Text = "Enter DOCTYPE Name" & vbNewLine & "(e.g.  Shipping DOCTYPE..., etc. )"
                If edit = True Then dttable = objCommon.search(" DOCTYPE_name, DOCTYPE_REMARKS AS REMARKS", "", "DOCTYPEMaster", " and DOCTYPE_id = " & TempID & " and DOCTYPE_cmpid = " & CmpId & " and DOCTYPE_LOCATIONid = " & Locationid & " and DOCTYPE_YEARid = " & YearId)

            ElseIf frmString = "SENTBY" Then

                Me.Text = "SENTBY Master"
                lblgroup.Text = "SENTBY"
                lbl.Text = "Enter SENTBY Name" & vbNewLine & "(e.g.  Shipping SENTBY..., etc. )"
                If edit = True Then dttable = objCommon.search(" SENTBY_name, SENTBY_REMARKS AS REMARKS", "", "SENTBYMaster", " and SENTBY_id = " & TempID & " and SENTBY_cmpid = " & CmpId & " and SENTBY_LOCATIONid = " & Locationid & " and SENTBY_YEARid = " & YearId)

            ElseIf frmString = "ITEMCATEGORY" Then

                Me.Text = "ITEMCATEGORY Master"
                lblgroup.Text = "ITEMCATEGORY"
                lbl.Text = "Enter ITEMCATEGORY Name" & vbNewLine & "(e.g.  Laundry, Electronic Items,..., etc. )"
                If edit = True Then dttable = objCommon.search(" ITEMCATEGORY_name, ITEMCATEGORY_REMARKS AS REMARKS", "", "ITEMCATEGORYMaster", " and ITEMCATEGORY_id = " & TempID & " and ITEMCATEGORY_cmpid = " & CmpId & " and ITEMCATEGORY_LOCATIONid = " & Locationid & " and ITEMCATEGORY_YEARid = " & YearId)

            ElseIf frmString = "COURSE" Then

                Me.Text = "Course Master"
                lblgroup.Text = "Course"
                lbl.Text = "Enter Course Name"
                If edit = True Then dttable = objCommon.search(" COURSE_name, COURSE_REMARKS AS REMARKS", "", "COURSEMaster", " and COURSE_id = " & TempID & " and COURSE_YEARid = " & YearId)

            ElseIf frmString = "COURSEYEAR" Then

                Me.Text = "Course Year Master"
                lblgroup.Text = "Course Year"
                lbl.Text = "Enter Course Year"
                If edit = True Then dttable = objCommon.search(" COURSEYEAR_name, COURSEYEAR_REMARKS AS REMARKS", "", "COURSEYEARMaster", " and COURSEYEAR_id = " & TempID & " and COURSEYEAR_YEARid = " & YearId)

            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and (register_type = 'EDUCATION' OR register_type = 'MEDICAL')")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EDUCATION' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and (register_type = 'EDUCATION' OR register_type = 'MEDICAL') and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If frmString = "CATEGORY" Then

                    Dim tempmsg As Integer = MsgBox("Delete Category Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJCAT As New ClsCategoryMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(cmbregister.Text.Trim)
                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJCAT.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJCAT.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "RANK" Then

                    Dim tempmsg As Integer = MsgBox("Delete Rank Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJRANK As New ClsRankMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJRANK.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJRANK.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "COMPANY" Then

                    Dim tempmsg As Integer = MsgBox("Delete Company Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJCOMPANY As New ClsCompanyMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJCOMPANY.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJCOMPANY.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "NARRATION" Then

                    Dim tempmsg As Integer = MsgBox("Delete NARRATION Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJNARRATION As New ClsNARRATIONMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJNARRATION.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJNARRATION.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "DOCTYPE" Then

                    Dim tempmsg As Integer = MsgBox("Delete DOCTYPE Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJDOCTYPE As New ClsDocTypeMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJDOCTYPE.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJDOCTYPE.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "SENTBY" Then

                    Dim tempmsg As Integer = MsgBox("Delete SENTBY Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJSENTBY As New ClsSentByMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJSENTBY.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJSENTBY.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                ElseIf frmString = "ITEMCATEGORY" Then

                    Dim tempmsg As Integer = MsgBox("Delete Item Category Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then

                        Dim OBJDOCTYPE As New ClsItemCategory
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(txtname.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJDOCTYPE.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJDOCTYPE.DELETE()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
End Class