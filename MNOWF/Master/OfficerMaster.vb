
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class OfficerMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public TEMPOFFICERNAME As String
    Dim TEMPOFFICERID As Integer
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Dim RESPONSE As String = ""
    Public PATH As New ArrayList
    Public FILENAME As New ArrayList
    'Dim Amount As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub OfficerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        FILLOFFICER(CMBNAME, edit)
        FILLRANK(CMBRANK, edit)
        FILLCOMPANY(CMBCMPNAME, edit)
        FILLFAMILY(CMBFAMILY, edit)
        FILLRELATION(CMBRELATION, edit)
    End Sub

    Private Sub OfficerMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OFFICER MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            fillcmb()

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJOFFICER As New ClsOfficerMaster
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPOFFICERNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJOFFICER.alParaval = ALPARAVAL
                Dim DTTABLE As DataTable = OBJOFFICER.GETOFFICER

                If DTTABLE.Rows.Count > 0 Then
                    For Each ROW As DataRow In DTTABLE.Rows
                        TEMPOFFICERID = ROW("OFFICERID")
                        TXTOFFICERNO.Text = ROW("OFFICERID")
                        CMBNAME.Text = ROW("NAME")
                        CMBRANK.Text = ROW("RANK")
                        CMBCMPNAME.Text = ROW("COMPANY")
                        TXTEMPCODE.Text = ROW("EMPCODE")

                        DOJ.Text = Convert.ToDateTime(ROW("DOJ")).Date
                        DECDATE.Text = Convert.ToDateTime(ROW("DECDATE")).Date

                        CHKINDIAN.Checked = Convert.ToBoolean(ROW("INDIAN"))
                        CHKCONTRACT.Checked = Convert.ToBoolean(ROW("CONTRACT"))
                        CHKCONTRIBUTION.Checked = Convert.ToBoolean(ROW("CONTRIBUTION"))
                        CHKDONATION.Checked = Convert.ToBoolean(ROW("DONATION"))

                        txtstd.Text = ROW("STD")
                        txtmobile.Text = ROW("MOBILE")
                        txtfax.Text = ROW("FAX")
                        txtresino.Text = ROW("RESINO")
                        TXTMUINO.Text = ROW("MUINO")
                        cmbemail.Text = ROW("EMAIL")

                        TXTSERVICE.Text = ROW("SERVICE")
                        txtadd.Text = ROW("ADD")
                        TXTREMARKS.Text = ROW("REMARKS")

                        If IsDBNull(ROW("SRNO")) = False Then GRIDDETAILS.Rows.Add(ROW("SRNO"), ROW("FAMILY"), Format(Convert.ToDateTime(ROW("DOB")).Date, "dd/MM/yyyy"), ROW("AGE"), ROW("RELATION"))
                    Next
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

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBRANK.Text.Trim)
            alParaval.Add(CMBCMPNAME.Text.Trim)
            alParaval.Add(TXTEMPCODE.Text.Trim)
            alParaval.Add(Format(DOJ.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CHKINDIAN.CheckState)
            alParaval.Add(CHKCONTRACT.CheckState)
            alParaval.Add(CHKCONTRIBUTION.CheckState)
            alParaval.Add(CHKDONATION.CheckState)
            alParaval.Add(Format(DECDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(TXTMUINO.Text.Trim)
            alParaval.Add(TXTSERVICE.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim FAMILY As String = ""
            Dim DOB As String = ""
            Dim AGE As String = ""
            Dim RELATION As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDETAILS.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        FAMILY = row.Cells(GFAMILY.Index).Value
                        DOB = Format(Convert.ToDateTime(row.Cells(GDOB.Index).Value).Date, "MM/dd/yyyy")
                        AGE = row.Cells(GAGE.Index).Value
                        RELATION = row.Cells(GRELATION.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        FAMILY = FAMILY & "," & row.Cells(GFAMILY.Index).Value
                        DOB = DOB & "," & Format(Convert.ToDateTime(row.Cells(GDOB.Index).Value).Date, "MM/dd/yyyy")
                        AGE = AGE & "," & row.Cells(GAGE.Index).Value
                        RELATION = RELATION & "," & row.Cells(GRELATION.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(FAMILY)
            alParaval.Add(DOB)
            alParaval.Add(AGE)
            alParaval.Add(RELATION)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJOFFICER As New ClsOfficerMaster
            OBJOFFICER.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJOFFICER.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                edit = False
                alParaval.Add(TEMPOFFICERID)
                IntResult = OBJOFFICER.update()
                MsgBox("Details Updated")
            End If

            clear()
            CMBCMPNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        TXTSERVICE.Clear()
        txtadd.Clear()
        TXTREMARKS.Clear()

        CMBNAME.Text = ""
        CMBRANK.Text = ""
        CMBCMPNAME.Text = ""
        TXTEMPCODE.Clear()

        DOJ.Value = Mydate
        CHKINDIAN.CheckState = CheckState.Checked
        CHKCONTRIBUTION.CheckState = CheckState.Unchecked
        CHKDONATION.CheckState = CheckState.Unchecked
        DECDATE.Value = Mydate

        txtstd.Clear()
        txtmobile.Clear()
        txtresino.Clear()
        txtfax.Clear()
        cmbemail.Text = ""
        TXTMUINO.Clear()

        TXTSRNO.Clear()
        CMBFAMILY.Text = ""
        DOB.Value = Mydate
        TXTAGE.Clear()
        CMBRELATION.Text = ""

        GRIDDETAILS.RowCount = 0

        GETMAX_OFFICERNO()

    End Sub

    Sub GETMAX_OFFICERNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(OFFICER_ID),0) + 1 ", "OFFICERMASTER", " AND OFFICER_cmpid=" & CmpId & " AND OFFICER_LOCATIONid=" & Locationid & " AND OFFICER_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTOFFICERNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Officer's Name")
            bln = False
        End If

        If CMBCMPNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBCMPNAME, "Fill Company Name")
            bln = False
        End If

        If CMBRANK.Text.Trim.Length = 0 Then
            EP.SetError(CMBRANK, "Fill Officer's Rank")
            bln = False
        End If

        If GRIDDETAILS.RowCount = 0 Then
            EP.SetError(CMBNAME, "Fill Officer's Family Details")
            bln = False
        End If

        If txtmobile.Text.Trim = "" Then
            EP.SetError(txtmobile, "Fill Officer's Mobile No")
            bln = False
        End If

        Return bln
    End Function

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numdotkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub txtstd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstd.KeyPress
        numdotkeypress(e, txtstd, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLOFFICER(CMBNAME, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCMPNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCMPNAME.Enter
        Try
            If CMBCMPNAME.Text.Trim = "" Then FILLCOMPANY(CMBCMPNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCMPNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBRANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRANK.Enter
        Try
            If CMBRANK.Text.Trim = "" Then FILLRANK(CMBRANK, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbRANK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBRANK.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbFAMILY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBFAMILY.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbRELATION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBRELATION.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                pcase(CMBNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPOFFICERNAME)) Then
                    dt = objclscommon.search("OFFICER_NAME", "", " OFFICERMASTER", " AND OFFICER_NAME = '" & CMBNAME.Text.Trim & "' AND OFFICER_CMPID = " & CmpId & " AND OFFICER_LOCATIONID = " & Locationid & " AND OFFICER_YEARID = " & YearId)
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDDETAILS.Rows.Add(Val(TXTSRNO.Text.Trim), CMBFAMILY.Text.Trim, Format(DOB.Value.Date, "dd/MM/yyyy"), Val(TXTAGE.Text.Trim), CMBRELATION.Text.Trim)
            getsrno(GRIDDETAILS)
        ElseIf gridDoubleClick = True Then

            GRIDDETAILS.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
            GRIDDETAILS.Item(GFAMILY.Index, temprow).Value = CMBFAMILY.Text.Trim
            GRIDDETAILS.Item(GDOB.Index, temprow).Value = Format(DOB.Value.Date, "dd/MM/yyyy")
            GRIDDETAILS.Item(GAGE.Index, temprow).Value = TXTAGE.Text.Trim
            GRIDDETAILS.Item(GRELATION.Index, temprow).Value = CMBRELATION.Text.Trim

            gridDoubleClick = False

        End If
        GRIDDETAILS.FirstDisplayedScrollingRowIndex = GRIDDETAILS.RowCount - 1

        TXTSRNO.Clear()
        CMBFAMILY.Text = ""
        DOB.Value = Mydate
        TXTAGE.Clear()
        CMBRELATION.Text = ""
        TXTSRNO.Focus()

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCMPNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCMPNAME.Validating
        Try
            If CMBCMPNAME.Text.Trim <> "" Then COMPANYVALIDATE(CMBCMPNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFAMILY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFAMILY.Enter
        Try
            If CMBFAMILY.Text.Trim = "" Then FILLFAMILY(CMBFAMILY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFAMILY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFAMILY.Validating
        Try
            If CMBFAMILY.Text.Trim <> "" Then FAMILYVALIDATE(CMBFAMILY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRANK.Validating
        Try
            If CMBRANK.Text.Trim <> "" Then RANKVALIDATE(CMBRANK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRELATION.Enter
        Try
            If CMBRELATION.Text.Trim = "" Then FILLRELATION(CMBRELATION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRELATION.Validating
        Try
            If CMBRELATION.Text.Trim <> "" Then RELATIONVALIDATE(CMBRELATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbemail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbemail.Validating
        Try
            If cmbemail.Text.Trim <> "" Then EMAILVALIDATE(cmbemail, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRELATION.Validated
        Try
            If CMBFAMILY.Text.Trim <> "" And Val(TXTAGE.Text.Trim) > 0 And CMBRELATION.Text.Trim <> "" Then
                EP.Clear()
                If Not CHECKFAMILY() Then
                    Exit Sub
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKFAMILY() As Boolean
        Try
            Dim BLN As Boolean = True

            For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
                If (ROW.Cells(GFAMILY.Index).Value = CMBFAMILY.Text.Trim And gridDoubleClick = False) Or (gridDoubleClick = True And temprow <> Val(TXTSRNO.Text.Trim) - 1) Then
                    EP.SetError(CMBRELATION, "Family Member Already Present in Grid Below")
                    BLN = False
                End If
            Next

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDDETAILS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDDETAILS.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDDETAILS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDDETAILS.Item(GSRNO.Index, e.RowIndex).Value
                CMBFAMILY.Text = GRIDDETAILS.Item(GFAMILY.Index, e.RowIndex).Value
                DOB.Text = GRIDDETAILS.Item(GDOB.Index, e.RowIndex).Value.ToString
                TXTAGE.Text = GRIDDETAILS.Item(GAGE.Index, e.RowIndex).Value.ToString
                CMBRELATION.Text = GRIDDETAILS.Rows(e.RowIndex).Cells(GRELATION.Index).Value
                temprow = e.RowIndex
                TXTSRNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDETAILS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDDETAILS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDDETAILS.Rows.RemoveAt(GRIDDETAILS.CurrentRow.Index)
                getsrno(GRIDDETAILS)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDDETAILS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDDETAILS.Rows(GRIDDETAILS.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub DOB_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DOB.Validating
        Try
            TXTAGE.Text = DateDiff(DateInterval.Year, DOB.Value.Date, Now.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKINDIAN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKINDIAN.CheckedChanged
        Try
            If CHKINDIAN.CheckState = CheckState.Checked Then CHKCONTRACT.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKCONTRACT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKCONTRACT.CheckedChanged
        Try
            If CHKCONTRACT.CheckState = CheckState.Checked Then CHKINDIAN.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKCONTRIBUTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCONTRIBUTION.CheckedChanged
        Try
            If CHKCONTRIBUTION.CheckState = CheckState.Checked Then CHKDONATION.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKDONATION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKDONATION.CheckedChanged
        Try
            If CHKDONATION.CheckState = CheckState.Checked Then CHKCONTRIBUTION.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtadd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd.Validated
        pcase(txtadd)
    End Sub

    Private Sub CMDQRCODE_Click(sender As Object, e As EventArgs) Handles CMDQRCODE.Click
        Try


            Dim DT As New DataTable
            Dim OBJBOOK As New ClsCommon

            If edit = True Then SENDWHATSAPP(TEMPOFFICERID)
            'DT = OBJBOOK.Execute_Any_String("UPDATE BOOKINGMASTER SET BOOKING_SENDWHATSAPP = 1 FROM BOOKINGMASTER INNER JOIN REGISTERMASTER On BOOKINGMASTER.BOOKING_REGID = REGISTERMASTER.register_id WHERE BOOKING_NO = '" & TEMPOFFICERNAME & "'  AND BOOKING_YEARID = " & YearId, "", "")
            'LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Async Sub SENDWHATSAPP(TEMPBOOKNO As Integer)
        Try
            If Not errorvalid() Then
                Exit Sub
            End If
            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim Amount As Double = 0.0
            Amount = InputBox("Enter the Amount", "Officers Amount in QR code")
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If
            'FOR SENDING QRCODE

            PATH.Add(Application.StartupPath & "\BHIMUPI.jpeg")
            FILENAME.Add("BHIMUPI.jpeg")
            For I As Integer = 0 To PATH.Count - 1
                RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & txtmobile.Text.Trim, PATH(I), FILENAME(I))
            Next
            Dim OBJWHATSAPP As New SendWhatsapp
            Dim OBJCMN As New ClsCommon
            OBJWHATSAPP.OFFICERNAME = CMBNAME.Text.Trim

            OBJWHATSAPP.MSG = "Dear Sir," & vbCrLf & "
" & vbCrLf & "
We are delighted to confirm your booking at our convalescent home. Please find attached the QR Code and bank details for your payment:" & vbCrLf & "" & vbCrLf & "
Name: The Merchant Navy Officer Welfare Fund" & vbCrLf & "
Account No: 000310100025938." & vbCrLf & "
IFSC Code: BKID0000001" & vbCrLf & "
Branch: 70/80, M. G. Road, P. B. No: 238, Mumbai 4000023." & vbCrLf & "
" & vbCrLf & "
Kindly make the payment of Rs " & Val(Amount) & " using the provided information. Following the successful transaction, we will issue the allotment letter for your reference." & vbCrLf & "
" & vbCrLf & "
If you have any queries, please feel free to reach out for assistance at our email address:" & vbCrLf & "
mail@mnowf.com or Telephone us at 022 22619321 / 022 49680968." & vbCrLf & "
" & vbCrLf & "
" & vbCrLf & "
Regards,
The Merchant Navy Officers’ Welfare Fund"
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCALCDOB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCALCDOB.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCALCDOB_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCALCDOB.Validated
        If Val(TXTCALCDOB.Text) > 0 Then DOB.Value = DateAdd(DateInterval.Year, Val(TXTCALCDOB.Text) * (-1), Now.Date)
    End Sub

    Private Sub TXTSERVICE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSERVICE.Validating
        pcase(TXTSERVICE)
    End Sub
End Class