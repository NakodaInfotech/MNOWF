Imports BL

Public Class MergeParameter
    Public EDIT As Boolean

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        Try
            If cmbtype.Text.Trim = "COMPANY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCOMPANY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLCOMPANY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "FAMILY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLFAMILY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLFAMILY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "HOTEL" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillHOTEL(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillHOTEL(cmbReplace, EDIT)
            ElseIf cmbtype.Text = "OFFICER" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLOFFICER(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLOFFICER(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "RANK" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLRANK(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLRANK(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "RELATION" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLRELATION(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLRELATION(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "AREA" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLAREA(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillAREA(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillcity(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillcity(cmbReplace)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLSTATE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillSTATE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillCOUNTRY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCOUNTRY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCATEGORY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLCATEGORY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CHARGES" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCHARGES(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLCHARGES(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "COURSE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCOURSE(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLCOURSE(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "COURSEYEAR" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCOURSEYEAR(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLCOURSEYEAR(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "DOCTYPE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLDOCTYPE(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLDOCTYPE(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "INMODE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLINMODE(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLINMODE(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "SENTBY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLSENTBY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLSENTBY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "GROUP" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLGROUPOFHOTELS(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLGROUPOFHOTELS(cmbReplace)
                
               
           
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbOldName.Text.Trim = cmbReplace.Text.Trim Then
                EP.SetError(cmbReplace, " Please Fill Diff. Value!")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Cursor.Current = Cursors.WaitCursor
            Dim alParaval As New ArrayList
            Dim intresult As Integer

            alParaval.Add(cmbtype.Text)
            alParaval.Add(cmbOldName.Text)
            alParaval.Add(cmbReplace.Text)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)

            Dim OBJMFG As New ClsCommon()
            OBJMFG.alParaval = alParaval
            intresult = OBJMFG.mergeparameter()
            MsgBox("Item Merge Successfully")
            cmbtype.Text = ""
            cmbOldName.Text = ""
            cmbReplace.Text = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class