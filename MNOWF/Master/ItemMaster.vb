
Imports BL

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim TEMPITEMID As Integer
    Public TEMPITEMNAME As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("CATEGORY_name", "", "CATEGORYMaster", " and CATEGORY_cmpid =" & CmpId & " and CATEGORY_Locationid =" & Locationid & " and CATEGORY_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "CATEGORY_name"
            CMBCATEGORY.DataSource = dt
            CMBCATEGORY.DisplayMember = "CATEGORY_name"
            CMBCATEGORY.Text = ""
        End If
    End Sub

    Sub FILLITEMNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("ITEM_NAME", "", " ITEMMASTER ", " and ITEM_cmpid = " & CmpId & " and ITEM_locationid = " & Locationid & " and ITEM_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ITEM_NAME"
                CMBITEMNAME.DataSource = dt
                CMBITEMNAME.DisplayMember = "ITEM_NAME"
                CMBITEMNAME.Text = TEMPITEMNAME
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            FILLITEMNAME()
            clear()

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ITEM_ID AS ITEMID, ITEMCATEGORYMASTER.ITEMCATEGORY_NAME AS CATEGORY, ITEMMASTER.ITEM_NAME AS ITEMNAME, ITEMMASTER.ITEM_REMARKS AS REMARKS ", "", " ITEMMASTER INNER JOIN ITEMCATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = ITEMCATEGORYMASTER.ITEMCATEGORY_ID AND ITEMMASTER.ITEM_CMPID = ITEMCATEGORYMASTER.ITEMCATEGORY_CMPID AND ITEMMASTER.ITEM_LOCATIONID = ITEMCATEGORYMASTER.ITEMCATEGORY_LOCATIONID AND ITEMMASTER.ITEM_YEARID = ITEMCATEGORYMASTER.ITEMCATEGORY_YEARID ", " AND ITEM_NAME = '" & TEMPITEMNAME & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TEMPITEMID = Val(dttable.Rows(0).Item("ITEMID"))
                    CMBCATEGORY.Text = dttable.Rows(0).Item("CATEGORY").ToString
                    CMBITEMNAME.Text = dttable.Rows(0).Item("ITEMNAME").ToString
                    TXTREMARKS.Text = dttable.Rows(0).Item("REMARKS").ToString
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(CMBCATEGORY.Text.Trim)
            alParaval.Add(CMBITEMNAME.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            

            Dim OBJITEM As New ClsItemMaster
            OBJITEM.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJITEM.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPITEMID)
                IntResult = OBJITEM.update()
                edit = False
                MsgBox("Details Updated")
            End If

            clear()
            CMBCATEGORY.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        CMBCATEGORY.Text = ""
        CMBITEMNAME.Text = ""
        TXTREMARKS.Clear()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBCATEGORY.Text.Trim.Length = 0 Then
            EP.SetError(CMBCATEGORY, "Fill Category Name")
            bln = False
        End If

        If CMBITEMNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEMNAME, "Fill Item Name")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMBCATEGORY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.GotFocus
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLITEMCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCATEGORY.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then ITEMCATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then
                FILLITEMNAME()
                CMBITEMNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then
                pcase(CMBITEMNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBITEMNAME.Text) <> LCase(TEMPITEMNAME)) Then
                    dt = objclscommon.search("ITEM_NAME", "", " ITEMMASTER", " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPITEMNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJITEM As New ClsItemMaster
                OBJITEM.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJITEM.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class