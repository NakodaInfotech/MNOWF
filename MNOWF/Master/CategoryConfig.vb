
Imports BL

Public Class CategoryConfig

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public edit As Boolean
    Dim temprow As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        'clearing textboxes
        EP.Clear()
        CMBCATEGORY.Text = ""
        TXTCATEGORYMAX.Clear()

        TXTSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTMAX.Clear()

        GRIDBILL.RowCount = 0

        CMBCATEGORY.Enabled = True

        edit = False
        GRIDDOUBLECLICK = False

    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Validated
        Try
            If CMBCATEGORY.Text.Trim <> "" Then
                FILLGRIDBILL()
                CMBCATEGORY.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCATEGORYMAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCATEGORYMAX.KeyPress
        numdotkeypress(e, TXTCATEGORYMAX, Me)
    End Sub

    Private Sub TXTMAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMAX.KeyPress
        numdotkeypress(e, TXTMAX, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBCATEGORY.Text.Trim.Length = 0 Then
                EP.SetError(CMBCATEGORY, "Select Category")
                BLN = False
            End If

            If GRIDBILL.RowCount = 0 Then
                EP.SetError(TXTMAX, "Enter Category Details")
                BLN = False
            End If


            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CategoryConfig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdsave_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdsave_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CategoryConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CATEGORY MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCATEGORY(CMBCATEGORY, edit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDBILL()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CATEGORYCONFIG.CATEGORY_MAXCATEGORY AS MAXCATEGORY, CATEGORYCONFIG.CATEGORY_GRIDSRNO AS GRIDSRNO, CHARGESMASTER.CHARGES_NAME AS CHARGES, CATEGORYCONFIG.CATEGORY_MAX AS MAX", "", "  CATEGORYCONFIG INNER JOIN CATEGORYMASTER ON CATEGORYCONFIG.CATEGORY_ID = CATEGORYMASTER.CATEGORY_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CATEGORYMASTER.CATEGORY_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CATEGORYMASTER.CATEGORY_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CATEGORYMASTER.CATEGORY_YEARID INNER JOIN CHARGESMASTER ON CATEGORYCONFIG.CATEGORY_CHARGESID = CHARGESMASTER.CHARGES_ID AND CATEGORYCONFIG.CATEGORY_CMPID = CHARGESMASTER.CHARGES_CMPID AND CATEGORYCONFIG.CATEGORY_LOCATIONID = CHARGESMASTER.CHARGES_LOCATIONID AND CATEGORYCONFIG.CATEGORY_YEARID = CHARGESMASTER.CHARGES_YEARID ", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND CATEGORYCONFIG.CATEGORY_CMPID = " & CmpId & " AND CATEGORYCONFIG.CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORYCONFIG.CATEGORY_YEARID = " & YearId & " ORDER BY CATEGORYCONFIG.CATEGORY_GRIDSRNO")
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    TXTCATEGORYMAX.Text = ROW("MAXCATEGORY")
                    GRIDBILL.Rows.Add(ROW("GRIDSRNO"), ROW("CHARGES"), Format(Val(ROW("MAX")), "0.00"))
                Next
                edit = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim INTRESULT As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(CMBCATEGORY.Text.Trim)
            alparaval.Add(Val(TXTCATEGORYMAX.Text.Trim))
            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim CHARGES As String = ""
            Dim MAX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBILL.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = row.Cells(GCHARGES.Index).Value.ToString
                        MAX = row.Cells(GMAXALLOWED.Index).Value
                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        CHARGES = CHARGES & "," & row.Cells(GCHARGES.Index).Value.ToString
                        MAX = MAX & "," & row.Cells(GMAXALLOWED.Index).Value

                    End If
                End If
            Next


            alparaval.Add(GRIDSRNO)
            alparaval.Add(CHARGES)
            alparaval.Add(MAX)



            Dim OBJCATEGORY As New ClsCategoryConfig
            OBJCATEGORY.alParaval = alparaval

            'If edit = False Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            INTRESULT = OBJCATEGORY.save()
            MessageBox.Show("Details Added")

            'End If
            clear()
            edit = False
            CMBCATEGORY.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            For Each ROW As DataGridViewRow In GRIDBILL.Rows
                If (GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And temprow <> ROW.Index) Then
                    If ROW.Cells(GCHARGES.Index).Value = CMBCHARGES.Text.Trim Then
                        MsgBox("Charges Already Present in Grid below", MsgBoxStyle.Critical)
                        TXTSRNO.Focus()
                        Exit Sub
                    End If
                End If
            Next

            If GRIDDOUBLECLICK = False Then
                GRIDBILL.Rows.Add(TXTSRNO.Text.Trim, CMBCHARGES.Text.Trim, Val(TXTMAX.Text.Trim))
                getsrno(GRIDBILL)
            Else
                GRIDBILL.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
                GRIDBILL.Item(GCHARGES.Index, temprow).Value = CMBCHARGES.Text.Trim
                GRIDBILL.Item(GMAXALLOWED.Index, temprow).Value = TXTMAX.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

            TXTSRNO.Clear()
            CMBCHARGES.Text = ""
            TXTMAX.Clear()
            TXTSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBILL.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDBILL.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBCHARGES.Text = GRIDBILL.Item(GCHARGES.Index, e.RowIndex).Value.ToString
                TXTMAX.Text = GRIDBILL.Item(GMAXALLOWED.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete " & GRIDBILL.Item(GCHARGES.Index, GRIDBILL.CurrentRow.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCATEGORY As New ClsCategoryConfig
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBCATEGORY.Text.Trim)
                    ALPARAVAL.Add(GRIDBILL.Item(GCHARGES.Index, GRIDBILL.CurrentRow.Index).Value)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJCATEGORY.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJCATEGORY.DELETE

                End If
            End If

            GRIDBILL.Rows.RemoveAt(GRIDBILL.CurrentRow.Index)
            getsrno(GRIDBILL)

        End If

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBCATEGORY.Enabled = True
        CMBCATEGORY.Focus()
    End Sub

    Private Sub TXTMAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMAX.Validating
        Try
            If TXTSRNO.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)

            If TXTSRNO.Text.Trim.Length > 0 And CMBCHARGES.Text.Trim <> "" Then
                FILLGRID()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDBILL.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDBILL.Rows(GRIDBILL.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete All Charges of " & CMBCATEGORY.Text.Trim, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCATEGORY As New ClsCategoryConfig

                    For Each ROW As DataGridViewRow In GRIDBILL.Rows
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(CMBCATEGORY.Text.Trim)
                        ALPARAVAL.Add(ROW.Cells(GCHARGES.Index).Value)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJCATEGORY.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJCATEGORY.DELETE

                    Next
                    clear()
                    getsrno(GRIDBILL)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            FILLCHARGES(CMBCHARGES, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            CHARGESVALIDATE(CMBCHARGES, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class