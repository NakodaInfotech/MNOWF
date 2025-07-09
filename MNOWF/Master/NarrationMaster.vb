
Imports BL

Public Class NarrationMaster

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
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                dt = objclscommon.search("NARRATION_name", "", "NARRATIONMaster", " and NARRATION_name = '" & txtname.Text.Trim & "' and NARRATION_cmpid = " & CmpId & " and NARRATION_LOCATIONid = " & Locationid & " and NARRATION_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("NARRATION Already Exists", MsgBoxStyle.Critical, "MNOWF")
                    e.Cancel = True
                End If
            End If
            pcase(txtname)
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

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJNARRATION As New ClsNarrationMaster
            OBJNARRATION.alParaval = alParaval

            If edit = False Then
                IntResult = OBJNARRATION.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                alParaval.Add(TempID)
                IntResult = OBJNARRATION.Update()
                MsgBox("Details Updated")
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

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Fill Type")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        cmbregister.Text = ""
        txtremarks.Clear()
    End Sub

    Private Sub NarrationMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub NarrationMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            If edit = True Then dttable = objCommon.search(" NARRATION_name, NARRATION_TYPE AS TYPE", "", "NARRATIONMaster", " and NARRATION_id = " & TempID & " and NARRATION_cmpid = " & CmpId & " and NARRATION_LOCATIONid = " & Locationid & " and NARRATION_YEARid = " & YearId)
            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                cmbregister.Text = dttable.Rows(0).Item("TYPE").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                Dim tempmsg As Integer = MsgBox("Delete NARRATION Permanently?", MsgBoxStyle.YesNo, "MNOWF")
                If tempmsg = vbYes Then

                    Dim OBJNARRATION As New ClsNarrationMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TempID)

                    OBJNARRATION.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJNARRATION.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)
                    edit = False
                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class