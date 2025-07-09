
Imports BL
Imports System.Windows.Forms

Public Class AccountsMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public tempAccountsName As String
    Public TEMPGROUPNAME As String
    Public tempAccountsCode As String
    Dim tempAccountId As Integer
    Public tempTYPE As String = "ACCOUNTS"

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AccountsMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If frmstring = "CUSTOMER" Then

                dt = objclscommon.search("customer_cmpname", "", " CUSTOMERMASTER ", " and CUSTOMER_cmpid = " & CmpId & " and CUSTOMER_locationid = " & Locationid & " and CUSTOMER_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "customer_cmpname"
                    cmbcmpname.DataSource = dt
                    cmbcmpname.DisplayMember = "customer_cmpname"
                    cmbcmpname.Text = tempAccountsName
                End If

            ElseIf frmstring = "VENDOR" Then

                dt = objclscommon.search("VENDOR_cmpname", "", " VENDORMaster ", " and VENDOR_cmpid = " & CmpId & " and VENDOR_locationid = " & Locationid & " and VENDOR_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "VENDOR_cmpname"
                    cmbcmpname.DataSource = dt
                    cmbcmpname.DisplayMember = "VENDOR_cmpname"
                    cmbcmpname.Text = tempAccountsName
                End If

            ElseIf frmstring = "ACCOUNTS" Then

                dt = objclscommon.search("acc_cmpname", "", " ACCOUNTSMaster ", " and acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "acc_cmpname"
                    cmbcmpname.DataSource = dt
                    cmbcmpname.DisplayMember = "acc_cmpname"
                    cmbcmpname.Text = tempAccountsName
                End If

            ElseIf frmstring = "EMPLOYEE" Then

                dt = objclscommon.search("EMP_cmpname", "", " EMPLOYEEMaster ", " and EMP_cmpid = " & CmpId & " and EMP_locationid = " & Locationid & " and EMP_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_cmpname"
                    cmbcmpname.DataSource = dt
                    cmbcmpname.DisplayMember = "EMP_cmpname"
                    cmbcmpname.Text = tempAccountsName
                End If

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMPCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If frmstring = "CUSTOMER" Then

                dt = objclscommon.search("customer_CODE", "", " CUSTOMERMASTER ", " and CUSTOMER_cmpid = " & CmpId & " and CUSTOMER_locationid = " & Locationid & " and CUSTOMER_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "customer_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "customer_CODE"
                    CMBCODE.Text = tempAccountsCode
                End If

            ElseIf frmstring = "VENDOR" Then

                dt = objclscommon.search("VENDOR_CODE", "", " VENDORMaster ", " and VENDOR_cmpid = " & CmpId & " and VENDOR_locationid = " & Locationid & " and VENDOR_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "VENDOR_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "VENDOR_CODE"
                    CMBCODE.Text = tempAccountsCode
                End If

            ElseIf frmstring = "ACCOUNTS" Then

                dt = objclscommon.search("acc_CODE", "", " ACCOUNTSMaster ", " and acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "acc_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "acc_CODE"
                    CMBCODE.Text = tempAccountsCode
                End If

            ElseIf frmstring = "EMPLOYEE" Then

                dt = objclscommon.search("EMP_CODE", "", " EMPLOYEEMaster ", " and EMP_cmpid = " & CmpId & " and EMP_locationid = " & Locationid & " and EMP_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "EMP_CODE"
                    CMBCODE.Text = tempAccountsCode
                End If

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid =" & CmpId & " and area_Locationid =" & Locationid & " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_name"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

        If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME, " AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
        fillDEDUCTEETYPE(CMBDEDUCTEETYPE)

    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbhotelname.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Validated
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Details of " & CMBHOTELNAME.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(HOTELMASTER.HOTEL_ADD,'') AS [ADD], ISNULL(HOTELMASTER.HOTEL_ADD1,'') AS ADD1, ISNULL(HOTELMASTER.HOTEL_ADD2,'') AS ADD2, ISNULL(AREAMASTER.area_name,'') AS AREANAME, ISNULL(HOTELMASTER.HOTEL_STD,'') AS STD, ISNULL(CITYMASTER.city_name,'') AS CITYNAME, ISNULL(HOTELMASTER.HOTEL_ZIPCODE,'') AS ZIPCODE, ISNULL(STATEMASTER.state_name,'') AS STATENAME, ISNULL(COUNTRYMASTER.country_name,'') AS COUNTRYNAME, ISNULL(HOTELMASTER.HOTEL_ALTNO,'') AS ALTNO, ISNULL(HOTELMASTER.HOTEL_PHONENO,'') AS PHONENO, ISNULL(HOTELMASTER.HOTEL_MOBILENO,'') AS MOBILENO, ISNULL(HOTELMASTER.HOTEL_FAXNO,'') AS FAXNO, ISNULL(HOTELMASTER.HOTEL_WEBSITE,'') AS WEBSITE, ISNULL(HOTELMASTER.HOTEL_EMAILID,'') AS EMAILADD ", "", " HOTELMASTER LEFT OUTER JOIN COUNTRYMASTER ON HOTELMASTER.HOTEL_YEARID = COUNTRYMASTER.country_yearid AND HOTELMASTER.HOTEL_CMPID = COUNTRYMASTER.country_cmpid AND HOTELMASTER.HOTEL_LOCATIONID = COUNTRYMASTER.country_locationid AND HOTELMASTER.HOTEL_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON HOTELMASTER.HOTEL_YEARID = STATEMASTER.state_yearid AND HOTELMASTER.HOTEL_LOCATIONID = STATEMASTER.state_locationid AND HOTELMASTER.HOTEL_CMPID = STATEMASTER.state_cmpid AND HOTELMASTER.HOTEL_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON HOTELMASTER.HOTEL_YEARID = AREAMASTER.area_yearid AND HOTELMASTER.HOTEL_LOCATIONID = AREAMASTER.area_locationid AND HOTELMASTER.HOTEL_CMPID = AREAMASTER.area_cmpid AND HOTELMASTER.HOTEL_AREAID = AREAMASTER.area_id", " AND HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        txtadd.Text = DT.Rows(0).Item("ADD")
                        txtadd1.Text = DT.Rows(0).Item("ADD1")
                        txtadd2.Text = DT.Rows(0).Item("ADD2")
                        cmbarea.Text = DT.Rows(0).Item("AREANAME")
                        txtstd.Text = DT.Rows(0).Item("STD")
                        cmbcity.Text = DT.Rows(0).Item("CITYNAME")
                        txtzipcode.Text = DT.Rows(0).Item("ZIPCODE")
                        cmbstate.Text = DT.Rows(0).Item("STATENAME")
                        cmbcountry.Text = DT.Rows(0).Item("COUNTRYNAME")
                        txtaltno.Text = DT.Rows(0).Item("ALTNO")
                        txttel1.Text = DT.Rows(0).Item("PHONENO")
                        txtmobile.Text = DT.Rows(0).Item("MOBILENO")
                        txtfax.Text = DT.Rows(0).Item("FAXNO")
                        txtwebsite.Text = DT.Rows(0).Item("WEBSITE")
                        cmbemail.Text = DT.Rows(0).Item("EMAILADD")
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbhotelname.Validating
        Try
            If cmbhotelname.Text.Trim <> "" Then HOTELvalidate(cmbhotelname, cmbhotelcode, e, Me, txthoteladd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccountsMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            If frmstring = "CUSTOMER" Then
                DTROW = USERRIGHTS.Select("FormName = 'CUSTOMER MASTER'")
            ElseIf frmstring = "VENDOR" Then
                DTROW = USERRIGHTS.Select("FormName = 'SUPPLIER MASTER'")
            ElseIf frmstring = "ACCOUNTS" Then
                DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            ElseIf frmstring = "EMPLOYEE" Then
                DTROW = USERRIGHTS.Select("FormName = 'EMPLOYEE MASTER'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            FILLCMPNAME()
            FILLCMPCODE()
            cmbgroup.Text = TEMPGROUPNAME

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Me.Text = "Accounts Master"
            Dim OBJACC As New ClsAccountsMaster
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(tempAccountsName)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJACC.alParaval = ALPARAVAL
            If edit = True Then dttable = OBJACC.GETACCOUNTS

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    tempAccountId = Val(dttable.Rows(0).Item(0))
                    cmbcmpname.Text = dttable.Rows(0).Item(1).ToString
                    txtname.Text = dttable.Rows(0).Item(2).ToString
                    cmbgroup.Text = dttable.Rows(0).Item(3).ToString
                    txtopbal.Text = Val(dttable.Rows(0).Item(4).ToString)
                    cmbdrcrrs.Text = dttable.Rows(0).Item(5).ToString
                    txtadd1.Text = dttable.Rows(0).Item(6).ToString
                    txtadd2.Text = dttable.Rows(0).Item(7).ToString
                    cmbarea.Text = dttable.Rows(0).Item(8).ToString
                    cmbcity.Text = dttable.Rows(0).Item(9).ToString
                    cmbstate.Text = dttable.Rows(0).Item(10).ToString

                    txtzipcode.Text = dttable.Rows(0).Item(11).ToString

                    cmbcountry.Text = dttable.Rows(0).Item(12).ToString
                    txtstd.Text = dttable.Rows(0).Item(13).ToString

                    txtresino.Text = dttable.Rows(0).Item(14).ToString
                    txtaltno.Text = dttable.Rows(0).Item(15).ToString

                    txttel1.Text = dttable.Rows(0).Item(16).ToString
                    txtmobile.Text = dttable.Rows(0).Item(17).ToString

                    txtfax.Text = dttable.Rows(0).Item(18).ToString
                    txtwebsite.Text = dttable.Rows(0).Item(19).ToString
                    cmbemail.Text = dttable.Rows(0).Item(20).ToString
                    txtcrdays.Text = Val(dttable.Rows(0).Item(21).ToString)
                    txtcrlimit.Text = Val(dttable.Rows(0).Item(22).ToString)
                    txtpanno.Text = dttable.Rows(0).Item(23).ToString
                    txtexciseno.Text = dttable.Rows(0).Item(24).ToString
                    txtrange.Text = dttable.Rows(0).Item(25).ToString
                    txtdivision.Text = dttable.Rows(0).Item(26).ToString
                    txtcstno.Text = dttable.Rows(0).Item(27).ToString
                    txttinno.Text = dttable.Rows(0).Item(28).ToString
                    txtstno.Text = dttable.Rows(0).Item(29).ToString
                    txtvatno.Text = dttable.Rows(0).Item(30).ToString
                    txtkstno.Text = dttable.Rows(0).Item(31).ToString
                    txtadd.Text = dttable.Rows(0).Item(32).ToString
                    txtshipadd.Text = dttable.Rows(0).Item(33).ToString
                    txtremarks.Text = dttable.Rows(0).Item(34).ToString

                    CMBCODE.Text = dttable.Rows(0).Item("CODE").ToString
                    tempAccountsCode = dttable.Rows(0).Item("CODE").ToString


                    If dttable.Rows(0).Item("DEDUCTEETYPE") <> "" Then
                        CHKTDSAPP.CheckState = CheckState.Checked
                        CMBDEDUCTEETYPE.Text = dttable.Rows(0).Item("DEDUCTEETYPE")
                        If dttable.Rows(0).Item("ISLOWER") = True Then
                            CMBISLOWER.Text = "Yes"
                            CMBSECTION.Enabled = True
                        Else
                            CMBISLOWER.Text = "No"
                        End If
                        CMBSECTION.Text = dttable.Rows(0).Item("SECTION")

                        TXTTDSRATE.Text = Format(Val(dttable.Rows(0).Item("TDSRATE")), "0.00")
                        If CMBSECTION.Text.Trim = "197" Then
                            TXTTDSRATE.Enabled = True
                        Else
                            TXTTDSRATE.Enabled = False
                        End If

                        If dttable.Rows(0).Item("SURCHARGE") = True Then
                            CMBSURCHARGE.Text = "Yes"
                        Else
                            CMBSURCHARGE.Text = "No"
                        End If
                        TXTLIMIT.Text = dttable.Rows(0).Item("LIMIT")
                    Else
                        CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If

                    CHKTDS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSAC"))
                    CMBNATURE.Text = dttable.Rows(0).Item("NATURE")

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub add()
        txtadd.Clear()
        If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
        If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

        If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

        txtadd.Text = txtadd.Text & "" & cmbcity.Text.Trim

        If txtzipcode.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & vbNewLine
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbstate.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbcountry.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(cmbcmpname.Text.Trim)
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbgroup.Text.Trim)
            alParaval.Add(txtopbal.Text.Trim)
            alParaval.Add(cmbdrcrrs.Text.Trim)
            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtcrdays.Text.Trim)
            alParaval.Add(txtcrlimit.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(txtpanno.Text.Trim)
            alParaval.Add(txtexciseno.Text.Trim)
            alParaval.Add(txtrange.Text.Trim)
            alParaval.Add(txtdivision.Text.Trim)
            alParaval.Add(txtcstno.Text.Trim)
            alParaval.Add(txttinno.Text.Trim)
            alParaval.Add(txtstno.Text.Trim)
            alParaval.Add(txtvatno.Text.Trim)
            alParaval.Add(txtkstno.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtshipadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(CMBCODE.Text.Trim)


            'TDS
            '*******************************
            alParaval.Add(CHKTDSAPP.CheckState)
            alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)

            If CMBISLOWER.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSECTION.Text.Trim)
            alParaval.Add(Val(TXTTDSRATE.Text.Trim))

            If CMBSURCHARGE.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Val(TXTLIMIT.Text.Trim))
            '*******************************

            alParaval.Add(CHKTDS.CheckState)
            alParaval.Add(CMBNATURE.Text.Trim)

            Dim objAccountsMaster As New ClsAccountsMaster
            objAccountsMaster.alParaval = alParaval
            objAccountsMaster.frmstring = frmstring

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAccountsMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempAccountId)
                IntResult = objAccountsMaster.update()
                MsgBox("Details Updated")
            End If

            clear()
            cmbcmpname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        'TDS
        CHKTDS.CheckState = CheckState.Unchecked
        CMBNATURE.Text = ""

        CHKTDSAPP.CheckState = CheckState.Unchecked
        GROUPTDS.Enabled = False
        CMBDEDUCTEETYPE.Text = ""
        CMBISLOWER.SelectedIndex = 0
        CMBSECTION.SelectedIndex = 0
        TXTTDSRATE.Clear()
        CMBSURCHARGE.SelectedIndex = 0
        TXTTDSRATE.Enabled = False
        CMBSECTION.Enabled = False

        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtaltno.Clear()
        cmbcmpname.Text = ""
        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtcstno.Clear()
        txtdivision.Clear()
        cmbemail.Text = ""
        txtexciseno.Clear()
        txtfax.Clear()
        txtkstno.Clear()
        txtmobile.Clear()
        txtname.Clear()
        txtopbal.Clear()
        txtpanno.Clear()
        txtrange.Clear()
        txtremarks.Clear()
        txtresino.Clear()
        txtshipadd.Clear()
        txtstd.Clear()
        txtstno.Clear()
        txttel1.Clear()
        txttinno.Clear()
        txtvatno.Clear()
        txtwebsite.Clear()
        txtzipcode.Clear()
        cmbarea.Text = ""
        cmbcity.Text = ""
        cmbcountry.Text = ""
        cmbdrcrrs.Text = ""
        cmbgroup.Text = ""
        cmbstate.Text = ""
        CMBCODE.Text = ""
        tempAccountsName = ""
        cmbcmpname.Text = ""
        edit = False
        CMBHOTELNAME.Text = ""

        If frmstring = "CUSTOMER" Then
            Me.Text = "Customer Master"
            cmbgroup.Text = "Sundry Debtors"
        ElseIf frmstring = "VENDOR" Then
            Me.Text = "Supplier Master"
            cmbgroup.Text = "Sundry Creditors"
        ElseIf frmstring = "ACCOUNTS" Then
            Me.Text = "Accounts Master"
        ElseIf frmstring = "EMPLOYEE" Then
            Me.Text = "Employee Master"
        End If
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbcmpname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcmpname, "Fill Company Name")
            bln = False
        End If

        If CHKTDS.CheckState = CheckState.Unchecked Then CMBNATURE.Text = ""

        If CHKTDS.CheckState = CheckState.Checked And CMBNATURE.Text.Trim = "" Then
            Ep.SetError(CMBNATURE, "Select Nature Of Payment")
            bln = False
        End If


        If CMBCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCODE, "Fill Company Code")
            bln = False
        End If

        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group")
            bln = False
        End If


       

       
        'Code for checking ...User should not allow to edit Build In Ledger which we were Create through Store Procedure
        'If cmbcmpname.Text.Trim = "Opening A/C" Or cmbcmpname.Text.Trim = "Profit & Loss A/C" Then
        '    Ep.SetError(cmbcmpname, "Build In Ledger Can't edit")
        '    bln = False
        'End If

        If UserName <> "Admin" Then
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "S.T. 1.03%"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "PACKAGE PURCHASE"
                    bln_4_case = False
                Case "INTERNATIONAL PURCHASE"
                    bln_4_case = False
                Case "AIRLINE PURCHASE"
                    bln_4_case = False
                Case "TRANSFER PURCHASE"
                    bln_4_case = False
                Case "BRANCH TRANSFER"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "PACKAGE SALE"
                    bln_4_case = False
                Case "Sale Book Return"
                    bln_4_case = False
                Case "Pur Book Return"
                    bln_4_case = False
                Case "INTERNATIONAL SALE"
                    bln_4_case = False
                Case "AIRLINE SALE"
                    bln_4_case = False
                Case "TRANSFER SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Agent Commission"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
                Case "Direct Payment"
                    bln_4_case = False
                Case "Pur Disc"
                    bln_4_case = False
                Case "Pur Comm"
                    bln_4_case = False
                Case "Pur Tax"
                    bln_4_case = False
                Case "Pur Add-Tax"
                    bln_4_case = False
                Case "Pur Other Chgs"
                    bln_4_case = False
                Case "Pur Round Off"
                    bln_4_case = False

            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot edit")
                bln = False
            End If
        End If
        Return bln
    End Function

    Private Sub cmbgroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.GotFocus
        Try
            If cmbgroup.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    cmbgroup.DataSource = dt
                    cmbgroup.DisplayMember = "group_name"
                    cmbgroup.Text = ""
                End If
                cmbgroup.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.GotFocus
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(cmbcountry.Text)
                                cmbcountry.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub txtcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try

    '        pcase(cmbcmpname)
    '        If (edit = False) Or (edit = True And tempAccountsName <> cmbcmpname.Text.Trim) Then
    '            'for search
    '            Dim objclscommon As New ClsCommonMaster
    '            Dim dt As New DataTable
    '            If frmstring = "CUSTOMER" Then
    '                dt = objclscommon.search("customer_cmpname", "", "CustomerMaster", " and customer_cmpname = '" & cmbcmpname.Text.Trim & "' and customer_cmpid =" & CmpId & " and customer_Locationid =" & Locationid & " and customer_Yearid =" & YearId)
    '            ElseIf frmstring = "VENDOR" Then
    '                dt = objclscommon.search("Vendor_cmpname", "", "VendorMaster", " and Vendor_cmpname = '" & cmbcmpname.Text.Trim & "' and Vendor_cmpid = " & CmpId & " and Vendor_Locationid = " & Locationid & " and Vendor_Yearid = " & YearId)
    '            ElseIf frmstring = "ACCOUNTS" Then
    '                dt = objclscommon.search("acc_cmpname", "", "AccountsMaster", " and acc_cmpname = '" & cmbcmpname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_Locationid = " & Locationid & " and acc_Yearid = " & YearId)
    '            ElseIf frmstring = "EMPLOYEE" Then
    '                dt = objclscommon.search("Emp_cmpname", "", "EmployeeMaster", " and Emp_cmpname = '" & cmbcmpname.Text.Trim & "' and Emp_cmpid = " & CmpId & " and Emp_Locationid = " & Locationid & " and Emp_Yearid = " & YearId)
    '            End If
    '            If dt.Rows.Count > 0 Then
    '                MsgBox("Company Name Already Exists", MsgBoxStyle.Critical, "MNOWF")
    '                e.Cancel = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbarea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.GotFocus
        Try
            If cmbarea.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    cmbarea.DataSource = dt
                    cmbarea.DisplayMember = "area_name"
                    cmbarea.Text = ""
                End If
                cmbarea.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then
                pcase(cmbarea)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbarea.Text.Trim
                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbarea.Text = a
                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbarea.DataSource
                        If cmbarea.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbarea.Text)
                                cmbarea.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then
                pcase(cmbgroup)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbgroup.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        cmbgroup.Text = a
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = cmbgroup.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbgroup.DataSource
                            If cmbgroup.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(cmbgroup.Text)
                                cmbgroup.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        pcase(txtname)
    End Sub

    Private Sub txtadd1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd1.Validating
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd2.Validating
        pcase(txtadd2)
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress
        numdotkeypress(e, txtcrdays, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdotkeypress(e, txtcrlimit, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numdotkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numdotkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub cmbcmpname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcmpname.Enter
        Try
            If cmbcmpname.Text.Trim = "" Then
                FILLCMPNAME()
                cmbcmpname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcmpname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcmpname.Validating
        Try
            If cmbcmpname.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then

                    dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
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

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "S.T. 1.03%"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "PACKAGE PURCHASE"
                    bln_4_case = False
                Case "INTERNATIONAL PURCHASE"
                    bln_4_case = False
                Case "AIRLINE PURCHASE"
                    bln_4_case = False
                Case "TRANSFER PURCHASE"
                    bln_4_case = False
                Case "BRANCH TRANSFER"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "PACKAGE SALE"
                    bln_4_case = False
                Case "INTERNATIONAL SALE"
                    bln_4_case = False
                Case "Sale Book Return"
                    bln_4_case = False
                Case "Pur Book Return"
                    bln_4_case = False
                Case "AIRLINE SALE"
                    bln_4_case = False
                Case "TRANSFER SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Agent Commission"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
                Case "Direct Payment"
                    bln_4_case = False
                Case "Pur Disc"
                    bln_4_case = False
                Case "Pur Comm"
                    bln_4_case = False
                Case "Pur Tax"
                    bln_4_case = False
                Case "Pur Add-Tax"
                    bln_4_case = False
                Case "Pur Other Chgs"
                    bln_4_case = False
                Case "Pur Round Off"
                    bln_4_case = False

            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot Delete")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                Ep.Clear()
                If Not DELETEERRORVALID() Then
                    Exit Sub
                End If

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempAccountsName)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJACC As New ClsAccountsMaster
                OBJACC.alParaval = ALPARAVAL
                OBJACC.frmstring = frmstring
                Dim DT As DataTable = OBJACC.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                FILLCMPCODE()
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBCODE.Text) <> LCase(tempAccountsCode)) Then
                    dt = objclscommon.search("ACC_CODE", "", " LEDGERS", " AND ACC_CODE = '" & CMBCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Code Already Exists", MsgBoxStyle.Critical, "MNOWF")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkcopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcopy.CheckedChanged
        Try
            txtadd.Clear()
            If chkcopy.CheckState = CheckState.Checked Then
                If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
                If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

                If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

                If cmbcity.Text.Trim <> "" Then txtadd.Text = txtadd.Text & ", " & cmbcity.Text.Trim

                If txtzipcode.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & "," & vbNewLine
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbstate.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim & ","
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbcountry.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim & "."
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBILL.Click
        Try
            If edit = True Then
                Dim OBJOPENING As New OpeningBills
                OBJOPENING.MdiParent = MDIMain
                OBJOPENING.TEMPNAME = cmbcmpname.Text.Trim
                OBJOPENING.Show()
            Else
                MsgBox("Entry Allowed in Edit mode only", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTDSAPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTDSAPP.CheckedChanged
        Try
            If cmbgroup.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable = objcmn.search(" GROUP_SECONDARY", "", " GROUPMASTER", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        GROUPTDS.Enabled = CHKTDSAPP.CheckState
                    Else
                        MsgBox("Not Applicable for this Group")
                        CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTEETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEDUCTEETYPE.Enter
        Try
            If CMBDEDUCTEETYPE.Text.Trim = "" Then fillDEDUCTEETYPE(CMBDEDUCTEETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBISLOWER_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBISLOWER.Validating
        Try
            CMBSECTION.Text = ""
            If CMBISLOWER.Text = "Yes" Then
                CMBSECTION.Enabled = True
                CMBSECTION.Focus()
            Else
                CMBSECTION.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSECTION_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSECTION.Validating
        Try
            TXTTDSRATE.Clear()
            If CMBSECTION.Text = "197" Then
                TXTTDSRATE.Enabled = True
                TXTTDSRATE.Focus()
            Else
                TXTTDSRATE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTEETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEDUCTEETYPE.Validating
        Try
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DEDUCTEETYPE_NAME", "", " DEDUCTEETYPEMASTER", " AND DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If DT.Rows.Count = 0 Then
                    MsgBox("Select Proper Deductee", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub TXTTDSRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTDSRATE.KeyPress
        numdotkeypress(e, TXTTDSRATE, Me)
    End Sub

    Private Sub TXTLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLIMIT.KeyPress
        numdotkeypress(e, TXTLIMIT, Me)
    End Sub

    Private Sub txtpanno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpanno.Validating
        Try
            If txtpanno.Text.Trim > "" Then

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTDS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTDS.CheckedChanged
        Try
            If CHKTDS.CheckState = CheckState.Checked Then

            Else

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNATURE.Enter
        Try
            If CMBNATURE.Text.Trim = "" Then FILLNATURE(CMBNATURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNATURE.Validating
        Try
            If CMBNATURE.Text.Trim <> "" Then NATUREVALIDATE(CMBNATURE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class