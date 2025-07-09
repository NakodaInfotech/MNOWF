
Imports BL

Public Class SelectOfficer

    Public STRSEARCH As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPNAME, TEMPCODE As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectOfficer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectOfficer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OFFICER MASTER'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID("")
            cmbname.Text = "Name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" OFFICERMASTER.OFFICER_name AS OFFICERNAME, RANK_NAME AS RANK, COMPANY_NAME AS COMPANY, OFFICER_MUINO AS MUINO, OFFICER_EMPCODE AS EMPCODE", "", " OFFICERMASTER LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_cmpid AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_locationid AND OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_yearid AND OFFICERMASTER.OFFICER_RANKid = RANKMASTER.RANK_id LEFT OUTER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYid = COMPANYMASTER.COMPANY_id AND OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_cmpid AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_locationid AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_yearid", STRSEARCH & WHERECLAUSE & " AND OFFICER_CMPID = " & CmpId & " AND OFFICER_LOCATIONID = " & Locationid & " AND OFFICER_YEARID = " & YearId & " order by OFFICERMASTER.OFFICER_name")
            GRIDHOTEL.DataSource = DT

            GRIDHOTEL.Columns(0).HeaderText = "Officer Name"
            GRIDHOTEL.Columns(0).Width = 260

            GRIDHOTEL.Columns(1).HeaderText = "Rank"
            GRIDHOTEL.Columns(1).Width = 100

            GRIDHOTEL.Columns(2).HeaderText = "Company"
            GRIDHOTEL.Columns(2).Width = 150

            GRIDHOTEL.Columns(3).HeaderText = "MUI No"
            GRIDHOTEL.Columns(3).Width = 70

            GRIDHOTEL.Columns(3).HeaderText = "Emp Code"
            GRIDHOTEL.Columns(3).Width = 70


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND OFFICERMASTER.OFFICER_NAME = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Rank" Then
                        FILLGRID(" AND RANK_NAME = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Company" Then
                        FILLGRID(" AND COMPANY_NAME= '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "MUI No" Then
                        FILLGRID(" AND OFFICER_MUINO = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Emp Code" Then
                        FILLGRID(" AND OFFICER_EMPCODE = '" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND OFFICERMASTER.OFFICER_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Rank" Then
                        FILLGRID(" AND RANK_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Company" Then
                        FILLGRID(" AND COMPANY_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "MUI No" Then
                        FILLGRID(" AND OFFICER_MUINO LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Emp Code" Then
                        FILLGRID(" AND OFFICER_EMPCODE  LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If

                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDHOTEL.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPNAME = ""
                TEMPCODE = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.CellDoubleClick
        Try
            If GRIDHOTEL.Rows.Count > 0 Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDHOTEL.Item(0, GRIDHOTEL.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDHOTEL.RowCount > 0) Then
                Dim OBJOFFICER As New OfficerMaster
                OBJOFFICER.MdiParent = MDIMain
                OBJOFFICER.edit = editval
                OBJOFFICER.TEMPOFFICERNAME = name
                OBJOFFICER.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class