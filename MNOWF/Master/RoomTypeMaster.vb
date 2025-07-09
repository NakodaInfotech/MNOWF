
Imports BL

Public Class RoomTypeMaster

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                If FRMSTRING = "ROOMTYPE" Then
                    dt = objclscommon.search("ROOMTYPE_name", "", "ROOMTYPEMaster", " and ROOMTYPE_name = '" & txtname.Text.Trim & "' and ROOMTYPE_cmpid =" & CmpId & " and ROOMTYPE_Locationid =" & Locationid & " and ROOMTYPE_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Room Type Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "HOTELTYPE" Then
                    dt = objclscommon.search("HOTELTYPE_name", "", "HOTELTYPEMaster", " and HOTELTYPE_name = '" & txtname.Text.Trim & "' and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_Locationid = " & Locationid & " and HOTELTYPE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Hotel Type Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "GROUPOFHOTELS" Then
                    dt = objclscommon.search("GROUPOFHOTELS_name", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_name = '" & txtname.Text.Trim & "' and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_Locationid = " & Locationid & " and GROUPOFHOTELS_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Group Of Hotels Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "AMENITIES" Then
                    dt = objclscommon.search("AMENITIES_name", "", "AMENITIESMaster", " and AMENITIES_name = '" & txtname.Text.Trim & "' and AMENITIES_cmpid = " & CmpId & " and AMENITIES_Locationid = " & Locationid & " and AMENITIES_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Amenities Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "SOURCE" Then
                    dt = objclscommon.search("SOURCE_name", "", "SOURCEMaster", " and SOURCE_name = '" & txtname.Text.Trim & "' and SOURCE_cmpid = " & CmpId & " and SOURCE_Locationid = " & Locationid & " and SOURCE_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Source Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        BLN = False
                    End If
                End If
            End If
            pcase(txtname)
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
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

            If FRMSTRING = "ROOMTYPE" Then
                Dim OBJROOM As New ClsRoomTypeMaster
                OBJROOM.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJROOM.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJROOM.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "HOTELTYPE" Then
                Dim OBJHOTEL As New ClsHotelTypeMaster
                OBJHOTEL.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJHOTEL.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJHOTEL.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "GROUPOFHOTELS" Then
                Dim OBJGROUP As New ClsGroupOfHotelsMaster
                OBJGROUP.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJGROUP.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJGROUP.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "AMENITIES" Then
                Dim OBJAMENITIES As New ClsAmenitiesMaster
                OBJAMENITIES.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJAMENITIES.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJAMENITIES.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "SOURCE" Then
                Dim OBJSOURCE As New ClsSourceMaster
                OBJSOURCE.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJSOURCE.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJSOURCE.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "BOOKEDBY" Then
                Dim OBJSOURCE As New ClsSourceMaster
                OBJSOURCE.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJSOURCE.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJSOURCE.update()
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
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If Not VALIDATENAME() Then
            EP.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub ROOMTYPEMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub RoomTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DT As New DataTable
            Dim OBJCOMMON As New ClsCommon

            If FRMSTRING = "ROOMTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ROOMTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Room Type Master"
                lblgroup.Text = "Room Type"
                lbl.Text = "Enter Room Type" & vbCrLf & "(e.g. Deluxe, Standard,..,etc.)"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" ROOMTYPE_name, ROOMTYPE_REMARKS", "", "ROOMTYPEMaster", " and ROOMTYPE_id = " & TempID & " and ROOMTYPE_cmpid = " & CmpId & " and ROOMTYPE_locationid = " & Locationid & " and ROOMTYPE_yearid = " & YearId)


            ElseIf FRMSTRING = "HOTELTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTELTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Hotel Type Master"
                lblgroup.Text = "Hotel Type"
                lbl.Text = "Enter Hotel Type" & vbCrLf & "(e.g. Hotel, Resorts,..,etc.)"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" HOTELTYPE_name, HOTELTYPE_REMARKS", "", "HOTELTYPEMaster", " and HOTELTYPE_id = " & TempID & " and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_locationid = " & Locationid & " and HOTELTYPE_yearid = " & YearId)


            ElseIf FRMSTRING = "GROUPOFHOTELS" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP OF HOTELS'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Group Of Hotels"
                lblgroup.Text = "Group"
                lbl.Text = "Enter Group Name"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" GROUPOFHOTELS_name, GROUPOFHOTELS_REMARKS", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_id = " & TempID & " and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_locationid = " & Locationid & " and GROUPOFHOTELS_yearid = " & YearId)

            ElseIf FRMSTRING = "AMENITIES" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AMENITIES MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Amenities Master"
                lblgroup.Text = "Amenities"
                lbl.Text = "Enter Amenities"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" AMENITIES_name, AMENITIES_REMARKS", "", "AMENITIESMaster", " and AMENITIES_id = " & TempID & " and AMENITIES_cmpid = " & CmpId & " and AMENITIES_locationid = " & Locationid & " and AMENITIES_yearid = " & YearId)

            End If
            If edit = True Then
                txtname.Text = DT.Rows(0).Item(0)
                txtremarks.Text = DT.Rows(0).Item(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class