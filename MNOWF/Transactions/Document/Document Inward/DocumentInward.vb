
Imports BL

Public Class DocumentInward

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public TEMPINWARDNO As Integer
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLEDITGRID()
        Try
            GRIDINWARD.RowCount = 0
            Dim ALPARAVAL As New ArrayList
            Dim OBJDOC As New ClsDocumentInward

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJDOC.alParaval = ALPARAVAL

            Dim DT As DataTable = OBJDOC.GETDOC()
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDINWARD.Rows.Add(DTROW("INWARDNO"), Format(Convert.ToDateTime(DTROW("RECDATE")).Date, "dd/MM/yyyy"), DTROW("DOCTYPE"), DTROW("INMODE"), DTROW("SENTBY"), Format(Convert.ToDateTime(DTROW("DOCDATE")).Date, "dd/MM/yyyy"), DTROW("NO"), DTROW("REMARKS"), DTROW("RECDBY"), Val(DTROW("DOCSUSED")), DTROW("DONE"))
                    If Val(DTROW("DOCSUSED")) > 0 Then GRIDINWARD.Rows(GRIDINWARD.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                    If Convert.ToBoolean(DTROW("DONE")) = True Then GRIDINWARD.Rows(GRIDINWARD.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If gridDoubleClick = False Then
                GRIDINWARD.Rows.Add(TXTINWARD.Text.Trim, Format(RECDATE.Value.Date, "dd/MM/yyyy"), CMBDOCTYPE.Text.Trim, CMBINMODE.Text.Trim, CMBSENTBY.Text.Trim, Format(DOCDATE.Value.Date, "dd/MM/yyyy"), Val(TXTNO.Text.Trim), TXTREMARKS.Text.Trim, CMBUSER.Text.Trim, 0, 0)
            ElseIf gridDoubleClick = True Then
                GRIDINWARD.Item(GRECDATE.Index, temprow).Value = Format(RECDATE.Value.Date, "dd/MM/yyyy")
                GRIDINWARD.Item(GDOCTYPE.Index, temprow).Value = CMBDOCTYPE.Text.Trim
                GRIDINWARD.Item(GINMODE.Index, temprow).Value = CMBINMODE.Text.Trim
                GRIDINWARD.Item(GSENTBY.Index, temprow).Value = CMBSENTBY.Text.Trim
                GRIDINWARD.Item(GDOCDATE.Index, temprow).Value = Format(DOCDATE.Value.Date, "dd/MM/yyyy")
                GRIDINWARD.Item(GNO.Index, temprow).Value = TXTNO.Text.Trim
                GRIDINWARD.Item(GREMARKS.Index, temprow).Value = TXTREMARKS.Text.Trim
                GRIDINWARD.Item(GRECDBY.Index, temprow).Value = CMBUSER.Text.Trim
                gridDoubleClick = False
            End If

            If GRIDINWARD.RowCount > 15 Then GRIDINWARD.FirstDisplayedScrollingRowIndex = GRIDINWARD.RowCount - 10

            edit = False
            TXTINWARD.Clear()
            RECDATE.Value = Mydate
            CMBDOCTYPE.Text = ""
            CMBINMODE.Text = ""
            CMBSENTBY.Text = ""
            DOCDATE.Value = Mydate
            TXTNO.Text = 1
            TXTREMARKS.Clear()
            CMBUSER.Text = ""

            TXTINWARD.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            FILLDOCTYPE(CMBDOCTYPE, edit)
            FILLINMODE(CMBINMODE, edit)
            FILLSENTBY(CMBSENTBY, edit)
            FILLUSER(CMBUSER, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DocumentInward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                DELETEDATA(GRIDINWARD.CurrentRow.Index)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F1 Then
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DocumentInward_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DOCUMENT INWARD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            FILLEDITGRID()

            If UserName <> "Admin" Then CMBUSER.Text = UserName


            If edit = True Then
                'GET ROWINDEX FIRST
                For Each ROW As DataGridViewRow In GRIDINWARD.Rows
                    If ROW.Cells(gsrno.Index).Value = TEMPINWARDNO Then
                        If Convert.ToBoolean(ROW.Cells(GDONE.Index).Value) = False And Val(ROW.Cells(GDOCSUSED.Index).Value) = 0 Then
                            GETDATA(ROW.Index)
                        Else
                            CLEAR()
                        End If
                    End If
                Next

            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINWARD_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDINWARD.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And Convert.ToBoolean(GRIDINWARD.Item(GDONE.Index, e.RowIndex).Value) = False And Val(GRIDINWARD.Item(GDOCSUSED.Index, e.RowIndex).Value) = 0 Then
                GETDATA(e.RowIndex)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA(ByVal ROWINDEX As Integer)
        Try
            gridDoubleClick = True
            edit = True
            TEMPINWARDNO = GRIDINWARD.Item(gsrno.Index, ROWINDEX).Value
            TXTINWARD.Text = GRIDINWARD.Item(gsrno.Index, ROWINDEX).Value
            RECDATE.Value = GRIDINWARD.Item(GRECDATE.Index, ROWINDEX).Value
            CMBDOCTYPE.Text = GRIDINWARD.Item(GDOCTYPE.Index, ROWINDEX).Value
            CMBINMODE.Text = GRIDINWARD.Item(GINMODE.Index, ROWINDEX).Value
            CMBSENTBY.Text = GRIDINWARD.Item(GSENTBY.Index, ROWINDEX).Value
            DOCDATE.Value = GRIDINWARD.Item(GDOCDATE.Index, ROWINDEX).Value
            TXTNO.Text = GRIDINWARD.Item(GNO.Index, ROWINDEX).Value
            TXTREMARKS.Text = GRIDINWARD.Item(GREMARKS.Index, ROWINDEX).Value
            CMBUSER.Text = GRIDINWARD.Item(GRECDBY.Index, ROWINDEX).Value
            temprow = ROWINDEX
            RECDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUSER.Enter
        Try
            If CMBUSER.Text.Trim = "" Then FILLUSER(CMBUSER, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUSER.SelectedIndexChanged
        Try
            If UserName <> "Admin" Then CMBUSER.Text = UserName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUSER.Validated
        Try

            If CMBDOCTYPE.Text.Trim <> "" And CMBSENTBY.Text.Trim <> "" And CMBUSER.Text.Trim <> "" Then

                If UserName <> "Admin" Then CMBUSER.Text = UserName

                'FIRST SAVE AND GET MAX INWARD NO THEN FILLGRID
                Dim ALPARAVAL As New ArrayList
                Dim OBJDOC As New ClsDocumentInward

                ALPARAVAL.Add(RECDATE.Value.Date)
                ALPARAVAL.Add(CMBDOCTYPE.Text.Trim)
                ALPARAVAL.Add(CMBINMODE.Text.Trim)
                ALPARAVAL.Add(CMBSENTBY.Text.Trim)
                ALPARAVAL.Add(DOCDATE.Value.Date)
                ALPARAVAL.Add(TXTNO.Text.Trim)
                ALPARAVAL.Add(TXTREMARKS.Text.Trim)
                ALPARAVAL.Add(CMBUSER.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                OBJDOC.alParaval = ALPARAVAL
                If edit = False Then
                    Dim DT As DataTable = OBJDOC.SAVE()
                    TXTINWARD.Text = DT.Rows(0).Item(0)
                ElseIf edit = True Then
                    ALPARAVAL.Add(TEMPINWARDNO)
                    Dim INTRESULT As Integer = OBJDOC.update
                End If

                fillgrid()

            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUSER.Validating
        Try
            If CMBUSER.Text.Trim <> "" Then USERVALIDATE(CMBUSER, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDOCTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDOCTYPE.Enter
        Try
            If CMBDOCTYPE.Text.Trim = "" Then FILLDOCTYPE(CMBDOCTYPE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDOCTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDOCTYPE.Validating
        Try
            If CMBDOCTYPE.Text.Trim <> "" Then DOCTYPEVALIDATE(CMBDOCTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENTBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSENTBY.Enter
        Try
            If CMBSENTBY.Text.Trim = "" Then FILLSENTBY(CMBSENTBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENTBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSENTBY.Validating
        Try
            If CMBSENTBY.Text.Trim <> "" Then SENTBYVALIDATE(CMBSENTBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_INWARDNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DOCIN_NO),0) + 1 ", "DOCUMENTINWARD", " AND DOCIN_cmpid=" & CmpId & " AND DOCIN_LOCATIONid=" & Locationid & " AND DOCIN_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTINWARD.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub TXTINWARD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTINWARD.GotFocus
        Try
            If edit = False Then GETMAX_INWARDNO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINWARD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDINWARD.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                DELETEDATA(GRIDINWARD.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTINWARD.Clear()
            RECDATE.Value = Mydate
            CMBDOCTYPE.Text = ""
            CMBINMODE.Text = ""
            CMBSENTBY.Text = ""
            DOCDATE.Value = Mydate
            TXTNO.Text = 1
            TXTREMARKS.Clear()
            CMBUSER.Text = ""
            tstxtbillno.Clear()

            GETMAX_INWARDNO()

            gridDoubleClick = False
            TXTINWARD.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try

            TEMPINWARDNO = Val(tstxtbillno.Text)
            If TEMPINWARDNO > 0 Then
                edit = True
                DocumentInward_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJDOC As New DocumentInwardDetails
            OBJDOC.MdiParent = MDIMain
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If GRIDINWARD.CurrentRow.Index >= 0 Then DELETEDATA(GRIDINWARD.CurrentRow.Index)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DELETEDATA(ByVal ROWINDEX As Integer)
        Try
            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If gridDoubleClick = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            If Val(GRIDINWARD.Rows(ROWINDEX).Cells(GDOCSUSED.Index).Value) > 0 Then
                MsgBox("Unable to Delete, Row Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Convert.ToBoolean(GRIDINWARD.Rows(ROWINDEX).Cells(GDONE.Index).Value) = True Then
                MsgBox("Unable to Delete, Row Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim TEMPMSG As Integer = MsgBox("Delete Inward No " & GRIDINWARD.Rows(ROWINDEX).Cells(gsrno.Index).Value, MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'delete from DATABASE
                Dim ALPARAVAL As New ArrayList
                Dim OBJDOC As New ClsDocumentInward

                ALPARAVAL.Add(GRIDINWARD.Rows(ROWINDEX).Cells(gsrno.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJDOC.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJDOC.DELETE()
                MsgBox(DT.Rows(0).Item(0), MsgBoxStyle.OkOnly, "MNOWF")
                GRIDINWARD.Rows.RemoveAt(ROWINDEX)

                TXTINWARD.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNO.KeyPress
        Try
            numkeypress(e, TXTNO, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINMODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBINMODE.Enter
        Try
            If CMBINMODE.Text.Trim = "" Then FILLINMODE(CMBINMODE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINMODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBINMODE.Validating
        Try
            If CMBINMODE.Text.Trim <> "" Then INMODEVALIDATE(CMBINMODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                PRINTREPORT(TEMPINWARDNO)
            Else
                PRINTREPORT(GRIDINWARD.CurrentRow.Cells(gsrno.Index).Value)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal INNO As Integer)
        Try
            Dim OBJIN As New ClaimDesign
            OBJIN.MdiParent = MDIMain
            OBJIN.FRMSTRING = "ACKNOWLEDGEMENT"
            OBJIN.SETTLENO = INNO
            OBJIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class