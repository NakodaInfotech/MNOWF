
Imports BL

Public Class SelectHotel

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPHOTELNAME, TEMPHOTELCODE As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectHotel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SelectHotel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID("")
            cmbname.Text = "Name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" HOTELMASTER.HOTEL_NAME AS HOTELNAME, HOTELMASTER.HOTEL_CODE AS CODE, GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME AS [GROUP], CITYMASTER.city_name AS CITY", "", " HOTELMASTER LEFT OUTER JOIN GROUPOFHOTELSMASTER ON HOTELMASTER.HOTEL_HOTELGROUPID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_ID AND HOTELMASTER.HOTEL_CMPID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_YEARID LEFT OUTER JOIN CITYMASTER ON HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid", WHERECLAUSE & " AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
            GRIDHOTEL.DataSource = DT

            GRIDHOTEL.Columns(0).HeaderText = "Hotel Name"
            GRIDHOTEL.Columns(0).Width = 260

            GRIDHOTEL.Columns(1).HeaderText = "Hotel Code"
            GRIDHOTEL.Columns(1).Width = 100

            GRIDHOTEL.Columns(2).HeaderText = "Group Of Hotels"
            GRIDHOTEL.Columns(2).Width = 150

            GRIDHOTEL.Columns(3).HeaderText = "City"
            GRIDHOTEL.Columns(3).Width = 100


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND HOTELMASTER.HOTEL_NAME = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND HOTELMASTER.HOTEL_CODE = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Group" Then
                        FILLGRID(" AND GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME= '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "City" Then
                        FILLGRID(" AND CITYMASTER.CITY_NAME  = '" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND HOTELMASTER.HOTEL_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND HOTELMASTER.HOTEL_CODE LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Group" Then
                        FILLGRID(" AND GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "City" Then
                        FILLGRID(" AND CITYMASTER.CITY_NAME  LIKE '%" & TXTNAME.Text.Trim & "%'")
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
                TEMPHOTELNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                TEMPHOTELCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPHOTELNAME = ""
                TEMPHOTELCODE = ""
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
                Dim OBJHOTEL As New HotelMaster
                OBJHOTEL.MdiParent = MDIMain
                OBJHOTEL.edit = editval
                OBJHOTEL.TEMPHOTELNAME = name
                OBJHOTEL.Show()
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