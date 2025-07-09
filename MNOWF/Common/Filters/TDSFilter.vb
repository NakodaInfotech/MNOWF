
Imports BL

Public Class TDSFilter

    Dim col As New DataGridViewCheckBoxColumn

    Private Sub TDSFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub  'Dim dt As New DataTable

    Private Sub TDSFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CMBQUARTER.SelectedIndex = 0
        dtfrom.Value = "01/04/" & Year(AccFrom)
        dtfrom.Value = "30/06/" & Year(AccFrom)

        fillgrid()
    End Sub

    Sub fillgrid()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable
            dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            If dt.Rows.Count > 0 Then
                gridledger.DataSource = dt
                gridledger.Columns.Insert(0, col)
                gridledger.Columns(0).Width = 50
                gridledger.Columns(1).Width = 240

                gridledger.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridacc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridledger.CellClick
        If e.RowIndex >= 0 Then
            With gridledger.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        Dim rowno, b As Integer
        fillgrid_search()
        rowno = 0
        For b = 1 To gridledger.RowCount
            txtTempName.Text = gridledger.Item(1, rowno).Value.ToString()
            txtTempName.SelectionStart = 0
            txtTempName.SelectionLength = txtName.TextLength
            If LCase(txtName.Text.Trim) <> LCase(txtTempName.SelectedText.Trim) Then
                gridledger.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Sub fillgrid_search()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable
            dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " AND GROUP_SECONDARY = 'Sundry Creditors' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            If dt.Rows.Count > 0 Then
                gridledger.DataSource = dt
                'gridledger.Columns.Insert(0, col)
                gridledger.Columns(0).Width = 50
                gridledger.Columns(1).Width = 240
                gridledger.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim i As Integer


            Dim OBJTDS As New TDSDesign
            OBJTDS.strsearch = ""

            For i = 0 To gridledger.RowCount - 1
                If gridledger.Item(0, i).Value = True Then
                    If OBJTDS.strsearch = "" Then
                        OBJTDS.strsearch = OBJTDS.strsearch & "  {TDSVIEW.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                    Else
                        OBJTDS.strsearch = OBJTDS.strsearch & " or {TDSVIEW.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                    End If
                End If
            Next
            If OBJTDS.strsearch = "" Then
                MsgBox("NO NAME BEEN SELECTED")
                Exit Sub
            Else
                OBJTDS.strsearch = "(" & OBJTDS.strsearch & ")"
            End If

            OBJTDS.QTR = CMBQUARTER.Text.Trim
            OBJTDS.FROMDATE = dtfrom.Value.Date
            OBJTDS.TODATE = dtto.Value.Date

            OBJTDS.MdiParent = MDIMain
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUARTER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUARTER.Validated
        Try
            If CMBQUARTER.Text.Trim = " Quarter 1" Then
                dtfrom.Value = "01/04/" & Year(AccFrom)
                dtfrom.Value = "30/06/" & Year(AccFrom)
            ElseIf CMBQUARTER.Text.Trim = " Quarter 2" Then
                dtfrom.Value = "01/07/" & Year(AccFrom)
                dtfrom.Value = "30/09/" & Year(AccFrom)
            ElseIf CMBQUARTER.Text.Trim = " Quarter 3" Then
                dtfrom.Value = "01/10/" & Year(AccFrom)
                dtfrom.Value = "31/12/" & Year(AccFrom)
            ElseIf CMBQUARTER.Text.Trim = " Quarter 4" Then
                dtfrom.Value = "01/01/" & Year(AccTo)
                dtfrom.Value = "31/03/" & Year(AccTo)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class