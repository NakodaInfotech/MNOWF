
Imports BL
Imports System.Windows.Forms

Public Class AccountsDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub AccountsDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            cmdedit_Click(sender, e)
        End If
    End Sub

    Private Sub AccountsDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgridname(Optional ByVal whereclause As String = "")
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CUSTOMER" Then
            dttable = objClsCommon.search(" Customer_cmpname, CUSTOMER_CODE AS Code, GroupMaster.group_name", "", " CustomerMaster inner join GroupMaster on Group_id = Customer_groupid and Group_cmpid = Customer_cmpid and Group_locationid = Customer_locationid and Group_yearid = Customer_yearid ", whereclause & " and Customer_cmpid = " & CmpId & " and Customer_locationid = " & Locationid & " and Customer_yearid = " & YearId & "  order by Customer_cmpname")
        ElseIf frmstring = "VENDOR" Then
            dttable = objClsCommon.search(" Vendor_cmpname, vendor_code as Code, GroupMaster.group_name", "", " VendorMaster inner join GroupMaster on Group_id = Vendor_groupid and Group_cmpid = Vendor_cmpid and Group_locationid = Vendor_locationid and Group_yearid = Vendor_yearid", whereclause & " and Vendor_cmpid = " & CmpId & " and Vendor_locationid = " & Locationid & " and Vendor_yearid = " & YearId & " order by Vendor_cmpname")
        ElseIf frmstring = "EMPLOYEE" Then
            dttable = objClsCommon.search(" Emp_cmpname, Emp_Code as Code, GroupMaster.group_name", "", " EmployeeMaster inner join GroupMaster on Group_id = Emp_groupid and Group_cmpid = Emp_cmpid and Group_locationid = Emp_locationid and Group_yearid = Emp_yearid", whereclause & " and Emp_cmpid = " & CmpId & " and Emp_locationid = " & Locationid & " and Emp_yearid = " & YearId & " order by Emp_cmpname")
        ElseIf frmstring = "ACCOUNTS" Then
            dttable = objClsCommon.search(" Acc_cmpname, Acc_Code as Code, GroupMaster.group_name", "", " AccountsMaster inner join GroupMaster on Group_id = Acc_groupid and Group_cmpid = Acc_cmpid and Group_locationid = Acc_locationid and Group_yearid = Acc_yearid", whereclause & " and Acc_cmpid = " & CmpId & " and Acc_locationid = " & Locationid & " and Acc_yearid = " & YearId & " order by Acc_cmpname")
        End If

        'gridname.DataSource = dttable
        'gridname.Columns(0).HeaderText = "Company Name"
        'gridname.Columns(1).HeaderText = "Code"
        'gridname.Columns(2).HeaderText = "Group"

        ''gridname.Columns.Add("balance", "Balance")

        'gridname.Columns(0).Width = 225
        'gridname.Columns(1).Width = 100
        'gridname.Columns(2).Visible = False
        'gridname.Columns(2).Width = 75

        Dim ALPARAVAL As New ArrayList
        Dim OBJACC As New ClsAccountsMaster

        ALPARAVAL.Add("")
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        OBJACC.alParaval = ALPARAVAL
        dttable = OBJACC.GETACCOUNTS
        gridname.DataSource = dttable

    End Sub

    'Private Sub gridname_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Try
    '        If e.RowIndex = -1 Then
    '            Exit Sub
    '        End If
    '        If gridname.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
    '            showform(True, gridname.Item(0, gridname.CurrentRow.Index).Value)
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub gridname_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If gridname.Rows(e.RowIndex).Cells(0).Value <> Nothing Then getdetails(gridname.Rows(e.RowIndex).Cells(0).Value.ToString)
    'End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            If Convert.ToBoolean(gridledger.GetFocusedRowCellValue("LOCKED")) = True Then
                MsgBox("Fixed Ledger Can't Edit", MsgBoxStyle.Critical)
                Exit Sub
            End If
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        If frmstring = "CUSTOMER" Then
            dttable = objClsCommon.search(" dbo.CustomerMaster.Customer_cmpname, dbo.CustomerMaster.Customer_name, dbo.GroupMaster.group_name, dbo.CustomerMaster.Customer_opbal, dbo.CustomerMaster.Customer_drcr, dbo.CustomerMaster.Customer_add1, dbo.CustomerMaster.Customer_add2, dbo.AreaMaster.area_name, dbo.CityMaster.city_name, dbo.CustomerMaster.Customer_zipcode, dbo.StateMaster.state_name, dbo.CountryMaster.country_name, dbo.CustomerMaster.Customer_std, dbo.CustomerMaster.Customer_resino, dbo.CustomerMaster.Customer_altno, dbo.CustomerMaster.Customer_phone, dbo.CustomerMaster.Customer_mobile, dbo.CustomerMaster.Customer_fax, dbo.CustomerMaster.Customer_website, dbo.CustomerMaster.Customer_email, dbo.CustomerMaster.Customer_crdays, dbo.CustomerMaster.Customer_crlimit, dbo.CustomerMaster.Customer_panno, dbo.CustomerMaster.Customer_exciseno, dbo.CustomerMaster.Customer_range, dbo.CustomerMaster.Customer_division, dbo.CustomerMaster.Customer_cstno, dbo.CustomerMaster.Customer_tinno, dbo.CustomerMaster.Customer_stno, dbo.CustomerMaster.Customer_vatno, dbo.CustomerMaster.Customer_kstno, dbo.CustomerMaster.Customer_add, dbo.CustomerMaster.Customer_shippingadd, dbo.CustomerMaster.Customer_remarks, dbo.CustomerMaster.Customer_code", "", " dbo.CustomerMaster LEFT OUTER JOIN dbo.CityMaster ON dbo.CustomerMaster.Customer_yearid = dbo.CityMaster.city_yearid AND dbo.CustomerMaster.Customer_locationid = dbo.CityMaster.city_locationid AND dbo.CustomerMaster.Customer_cmpid = dbo.CityMaster.city_cmpid AND dbo.CustomerMaster.Customer_cityid = dbo.CityMaster.city_id LEFT OUTER JOIN dbo.AreaMaster ON dbo.CustomerMaster.Customer_yearid = dbo.AreaMaster.area_yearid AND dbo.CustomerMaster.Customer_locationid = dbo.AreaMaster.area_locationid AND dbo.CustomerMaster.Customer_cmpid = dbo.AreaMaster.area_cmpid AND dbo.CustomerMaster.Customer_areaid = dbo.AreaMaster.area_id LEFT OUTER JOIN dbo.GroupMaster ON dbo.CustomerMaster.Customer_yearid = dbo.GroupMaster.group_yearid AND dbo.CustomerMaster.Customer_groupid = dbo.GroupMaster.group_id AND dbo.CustomerMaster.Customer_cmpid = dbo.GroupMaster.group_cmpid AND dbo.CustomerMaster.Customer_locationid = dbo.GroupMaster.group_locationid LEFT OUTER JOIN dbo.StateMaster ON dbo.CustomerMaster.Customer_yearid = dbo.StateMaster.state_yearid AND dbo.CustomerMaster.Customer_locationid = dbo.StateMaster.state_locationid AND dbo.CustomerMaster.Customer_cmpid = dbo.StateMaster.state_cmpid AND dbo.CustomerMaster.Customer_stateid = dbo.StateMaster.state_id LEFT OUTER JOIN dbo.CountryMaster ON dbo.CustomerMaster.Customer_locationid = dbo.CountryMaster.country_locationid AND dbo.CustomerMaster.Customer_yearid = dbo.CountryMaster.country_yearid AND dbo.CustomerMaster.Customer_cmpid = dbo.CountryMaster.country_cmpid AND dbo.CustomerMaster.Customer_countryid = dbo.CountryMaster.country_id", " and Customer_cmpname = '" & name & "' and Customer_cmpid = " & CmpId & " and Customer_Locationid = " & Locationid & " and Customer_yearid = " & YearId)
        ElseIf frmstring = "VENDOR" Then
            dttable = objClsCommon.search(" dbo.VendorMaster.Vendor_cmpname, dbo.VendorMaster.Vendor_name, dbo.GroupMaster.group_name, dbo.VendorMaster.Vendor_opbal, dbo.VendorMaster.Vendor_drcr, dbo.VendorMaster.Vendor_add1, dbo.VendorMaster.Vendor_add2, dbo.AreaMaster.area_name, dbo.CityMaster.city_name, dbo.VendorMaster.Vendor_zipcode, dbo.StateMaster.state_name, dbo.CountryMaster.country_name, dbo.VendorMaster.Vendor_std, dbo.VendorMaster.Vendor_resino, dbo.VendorMaster.Vendor_altno, dbo.VendorMaster.Vendor_phone, dbo.VendorMaster.Vendor_mobile, dbo.VendorMaster.Vendor_fax, dbo.VendorMaster.Vendor_website, dbo.VendorMaster.Vendor_email, dbo.VendorMaster.Vendor_crdays, dbo.VendorMaster.Vendor_crlimit, dbo.VendorMaster.Vendor_panno, dbo.VendorMaster.Vendor_exciseno, dbo.VendorMaster.Vendor_range, dbo.VendorMaster.Vendor_division, dbo.VendorMaster.Vendor_cstno, dbo.VendorMaster.Vendor_tinno, dbo.VendorMaster.Vendor_stno, dbo.VendorMaster.Vendor_vatno, dbo.VendorMaster.Vendor_kstno, dbo.VendorMaster.Vendor_add, dbo.VendorMaster.Vendor_shippingadd, dbo.VendorMaster.Vendor_remarks, dbo.VendorMaster.Vendor_code", "", "  dbo.VendorMaster LEFT OUTER JOIN dbo.CountryMaster ON dbo.VendorMaster.Vendor_yearid = dbo.CountryMaster.country_yearid AND dbo.VendorMaster.Vendor_locationid = dbo.CountryMaster.country_locationid AND dbo.VendorMaster.Vendor_cmpid = dbo.CountryMaster.country_cmpid AND dbo.VendorMaster.Vendor_countryid = dbo.CountryMaster.country_id LEFT OUTER JOIN dbo.StateMaster ON dbo.VendorMaster.Vendor_yearid = dbo.StateMaster.state_yearid AND dbo.VendorMaster.Vendor_locationid = dbo.StateMaster.state_locationid AND dbo.VendorMaster.Vendor_cmpid = dbo.StateMaster.state_cmpid AND dbo.VendorMaster.Vendor_stateid = dbo.StateMaster.state_id LEFT OUTER JOIN dbo.GroupMaster ON dbo.VendorMaster.Vendor_yearid = dbo.GroupMaster.group_yearid AND dbo.VendorMaster.Vendor_groupid = dbo.GroupMaster.group_id AND dbo.VendorMaster.Vendor_cmpid = dbo.GroupMaster.group_cmpid AND dbo.VendorMaster.Vendor_locationid = dbo.GroupMaster.group_locationid LEFT OUTER JOIN dbo.AreaMaster ON dbo.VendorMaster.Vendor_yearid = dbo.AreaMaster.area_yearid AND dbo.VendorMaster.Vendor_locationid = dbo.AreaMaster.area_locationid AND dbo.VendorMaster.Vendor_cmpid = dbo.AreaMaster.area_cmpid AND dbo.VendorMaster.Vendor_areaid = dbo.AreaMaster.area_id LEFT OUTER JOIN dbo.CityMaster ON dbo.VendorMaster.Vendor_yearid = dbo.CityMaster.city_yearid AND dbo.VendorMaster.Vendor_locationid = dbo.CityMaster.city_locationid AND dbo.VendorMaster.Vendor_cmpid = dbo.CityMaster.city_cmpid AND dbo.VendorMaster.Vendor_cityid = dbo.CityMaster.city_id", " and Vendor_Cmpname = '" & name & "' and Vendor_cmpid = " & CmpId & " and Vendor_Locationid = " & Locationid & " and Vendor_yearid = " & YearId)
        ElseIf frmstring = "EMPLOYEE" Then
            dttable = objClsCommon.search(" dbo.EmployeeMaster.Emp_cmpname, dbo.EmployeeMaster.Emp_name, dbo.GroupMaster.group_name, dbo.EmployeeMaster.Emp_opbal, dbo.EmployeeMaster.Emp_drcr, dbo.EmployeeMaster.Emp_add1, dbo.EmployeeMaster.Emp_add2, dbo.AreaMaster.area_name, dbo.CityMaster.city_name, dbo.EmployeeMaster.Emp_zipcode, dbo.StateMaster.state_name, dbo.CountryMaster.country_name, dbo.EmployeeMaster.Emp_std, dbo.EmployeeMaster.Emp_resino, dbo.EmployeeMaster.Emp_altno, dbo.EmployeeMaster.Emp_phone, dbo.EmployeeMaster.Emp_mobile, dbo.EmployeeMaster.Emp_fax, dbo.EmployeeMaster.Emp_website, dbo.EmployeeMaster.Emp_email, dbo.EmployeeMaster.Emp_crdays, dbo.EmployeeMaster.Emp_crlimit, dbo.EmployeeMaster.Emp_panno, dbo.EmployeeMaster.Emp_exciseno, dbo.EmployeeMaster.Emp_range, dbo.EmployeeMaster.Emp_division, dbo.EmployeeMaster.Emp_cstno, dbo.EmployeeMaster.Emp_tinno, dbo.EmployeeMaster.Emp_stno, dbo.EmployeeMaster.Emp_vatno, dbo.EmployeeMaster.Emp_kstno, dbo.EmployeeMaster.Emp_add, dbo.EmployeeMaster.Emp_shippingadd, dbo.EmployeeMaster.Emp_remarks,dbo.EmployeeMaster.Emp_code", "", " dbo.EmployeeMaster LEFT OUTER JOIN dbo.AreaMaster ON dbo.EmployeeMaster.Emp_yearid = dbo.AreaMaster.area_yearid AND dbo.EmployeeMaster.Emp_locationid = dbo.AreaMaster.area_locationid AND dbo.EmployeeMaster.Emp_cmpid = dbo.AreaMaster.area_cmpid AND dbo.EmployeeMaster.Emp_areaid = dbo.AreaMaster.area_id LEFT OUTER JOIN dbo.GroupMaster ON dbo.EmployeeMaster.Emp_yearid = dbo.GroupMaster.group_yearid AND dbo.EmployeeMaster.Emp_groupid = dbo.GroupMaster.group_id AND dbo.EmployeeMaster.Emp_cmpid = dbo.GroupMaster.group_cmpid AND dbo.EmployeeMaster.Emp_locationid = dbo.GroupMaster.group_locationid LEFT OUTER JOIN dbo.StateMaster ON dbo.EmployeeMaster.Emp_cmpid = dbo.StateMaster.state_cmpid AND dbo.EmployeeMaster.Emp_locationid = dbo.StateMaster.state_locationid AND dbo.EmployeeMaster.Emp_yearid = dbo.StateMaster.state_yearid AND dbo.EmployeeMaster.Emp_stateid = dbo.StateMaster.state_id LEFT OUTER JOIN dbo.CountryMaster ON dbo.EmployeeMaster.Emp_yearid = dbo.CountryMaster.country_yearid AND dbo.EmployeeMaster.Emp_locationid = dbo.CountryMaster.country_locationid AND dbo.EmployeeMaster.Emp_cmpid = dbo.CountryMaster.country_cmpid AND dbo.EmployeeMaster.Emp_countryid = dbo.CountryMaster.country_id LEFT OUTER JOIN dbo.CityMaster ON dbo.EmployeeMaster.Emp_yearid = dbo.CityMaster.city_yearid AND dbo.EmployeeMaster.Emp_locationid = dbo.CityMaster.city_locationid AND dbo.EmployeeMaster.Emp_cmpid = dbo.CityMaster.city_cmpid AND  dbo.EmployeeMaster.Emp_cityid = dbo.CityMaster.city_id", " and Emp_cmpname ='" & name & "' and Emp_cmpid = " & CmpId & " and Emp_Locationid = " & Locationid & " and Emp_Yearid = " & YearId)
        ElseIf frmstring = "ACCOUNTS" Then
            dttable = objClsCommon.search(" dbo.AccountsMaster.Acc_cmpname, dbo.AccountsMaster.Acc_name, dbo.GroupMaster.group_name, dbo.AccountsMaster.Acc_opbal, dbo.AccountsMaster.Acc_drcr, dbo.AccountsMaster.Acc_add1, dbo.AccountsMaster.Acc_add2, dbo.AreaMaster.area_name, dbo.CityMaster.city_name, dbo.AccountsMaster.Acc_zipcode, dbo.StateMaster.state_name, dbo.CountryMaster.country_name, dbo.AccountsMaster.Acc_std, dbo.AccountsMaster.Acc_resino, dbo.AccountsMaster.Acc_altno, dbo.AccountsMaster.Acc_phone, dbo.AccountsMaster.Acc_mobile, dbo.AccountsMaster.Acc_fax, dbo.AccountsMaster.Acc_website, dbo.AccountsMaster.Acc_email, dbo.AccountsMaster.Acc_crdays, dbo.AccountsMaster.Acc_crlimit, dbo.AccountsMaster.Acc_panno, dbo.AccountsMaster.Acc_exciseno, dbo.AccountsMaster.Acc_range, dbo.AccountsMaster.Acc_division, dbo.AccountsMaster.Acc_cstno, dbo.AccountsMaster.Acc_tinno, dbo.AccountsMaster.Acc_stno, dbo.AccountsMaster.Acc_vatno, dbo.AccountsMaster.Acc_kstno, dbo.AccountsMaster.Acc_add, dbo.AccountsMaster.Acc_shippingadd, dbo.AccountsMaster.Acc_remarks,dbo.AccountsMaster.Acc_code", "", "  dbo.AccountsMaster LEFT OUTER JOIN dbo.CityMaster ON dbo.AccountsMaster.Acc_yearid = dbo.CityMaster.city_yearid AND dbo.AccountsMaster.Acc_locationid = dbo.CityMaster.city_locationid AND dbo.AccountsMaster.Acc_cmpid = dbo.CityMaster.city_cmpid AND dbo.AccountsMaster.Acc_cityid = dbo.CityMaster.city_id LEFT OUTER JOIN dbo.CountryMaster ON dbo.AccountsMaster.Acc_yearid = dbo.CountryMaster.country_yearid AND dbo.AccountsMaster.Acc_locationid = dbo.CountryMaster.country_locationid AND dbo.AccountsMaster.Acc_cmpid = dbo.CountryMaster.country_cmpid AND dbo.AccountsMaster.Acc_countryid = dbo.CountryMaster.country_id LEFT OUTER JOIN dbo.StateMaster ON dbo.AccountsMaster.Acc_yearid = dbo.StateMaster.state_yearid AND dbo.AccountsMaster.Acc_locationid = dbo.StateMaster.state_locationid AND dbo.AccountsMaster.Acc_cmpid = dbo.StateMaster.state_cmpid AND dbo.AccountsMaster.Acc_stateid = dbo.StateMaster.state_id LEFT OUTER JOIN dbo.GroupMaster ON dbo.AccountsMaster.Acc_yearid = dbo.GroupMaster.group_yearid AND dbo.AccountsMaster.Acc_groupid = dbo.GroupMaster.group_id AND dbo.AccountsMaster.Acc_cmpid = dbo.GroupMaster.group_cmpid AND dbo.AccountsMaster.Acc_locationid = dbo.GroupMaster.group_locationid LEFT OUTER JOIN dbo.AreaMaster ON dbo.AccountsMaster.Acc_yearid = dbo.AreaMaster.area_yearid AND dbo.AccountsMaster.Acc_locationid = dbo.AreaMaster.area_locationid AND dbo.AccountsMaster.Acc_cmpid = dbo.AreaMaster.area_cmpid AND dbo.AccountsMaster.Acc_areaid = dbo.AreaMaster.area_id", " and Acc_cmpname = '" & name & "' and Acc_cmpid = " & CmpId & " and Acc_Locationid = " & Locationid & " and Acc_Yearid = " & YearId)
        End If

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            txtcmpname.Text = dttable.Rows(0).Item(0).ToString
            txtcusname.Text = dttable.Rows(0).Item(1).ToString
            txtgroup.Text = dttable.Rows(0).Item(2).ToString
            txtopbal.Text = Val(dttable.Rows(0).Item(3).ToString)
            txtdrcr.Text = dttable.Rows(0).Item(4).ToString
            txtadd1.Text = dttable.Rows(0).Item(5).ToString
            txtadd2.Text = dttable.Rows(0).Item(6).ToString
            txtarea.Text = dttable.Rows(0).Item(7).ToString
            txtcity.Text = dttable.Rows(0).Item(8).ToString
            txtzipcode.Text = dttable.Rows(0).Item(9).ToString
            txtstate.Text = dttable.Rows(0).Item(10).ToString
            txtcountry.Text = dttable.Rows(0).Item(11).ToString
            txtstd.Text = dttable.Rows(0).Item(12).ToString
            txtresino.Text = dttable.Rows(0).Item(13).ToString
            txtaltno.Text = dttable.Rows(0).Item(14).ToString
            txttel1.Text = dttable.Rows(0).Item(15).ToString
            txtmobile.Text = dttable.Rows(0).Item(16).ToString
            txtfax.Text = dttable.Rows(0).Item(17).ToString
            txtwebsite.Text = dttable.Rows(0).Item(18).ToString
            txtemail.Text = dttable.Rows(0).Item(19).ToString
            txtcrdays.Text = Val(dttable.Rows(0).Item(20).ToString)
            txtcrlimit.Text = Val(dttable.Rows(0).Item(21).ToString)
            txtpanno.Text = dttable.Rows(0).Item(22).ToString
            txtexciseno.Text = dttable.Rows(0).Item(23).ToString
            txtrange.Text = dttable.Rows(0).Item(24).ToString
            txtdivision.Text = dttable.Rows(0).Item(25).ToString
            txtcstno.Text = dttable.Rows(0).Item(26).ToString
            txttinno.Text = dttable.Rows(0).Item(27).ToString
            txtstno.Text = dttable.Rows(0).Item(28).ToString
            txtvatno.Text = dttable.Rows(0).Item(29).ToString
            txtkstno.Text = dttable.Rows(0).Item(30).ToString
            txtadd.Text = dttable.Rows(0).Item(31).ToString
            txtshipadd.Text = dttable.Rows(0).Item(32).ToString
            txtnotes.Text = dttable.Rows(0).Item(33).ToString
            txtcode.Text = dttable.Rows(0).Item(34).ToString
        End If

    End Sub

    Sub cleartextbox()
        txtcmpname.Clear()
        txtcusname.Clear()
        txtgroup.Clear()
        txtopbal.Clear()
        txtdrcr.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtarea.Clear()
        txtcity.Clear()
        txtzipcode.Clear()
        txtstate.Clear()
        txtcountry.Clear()
        txtstd.Clear()
        txtresino.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()
        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtpanno.Clear()
        txtexciseno.Clear()
        txtrange.Clear()
        txtdivision.Clear()
        txtcstno.Clear()
        txttinno.Clear()
        txtstno.Clear()
        txtvatno.Clear()
        txtkstno.Clear()
        txtadd.Clear()
        txtshipadd.Clear()
        txtnotes.Clear()
        txtcode.Clear()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            'showform(True, gridname.Item(0, gridname.CurrentRow.Index).Value)

            If Convert.ToBoolean(gridledger.GetFocusedRowCellValue("LOCKED")) = True Then
                MsgBox("Fixed Ledger Can't Edit", MsgBoxStyle.Critical)
                Exit Sub
            End If

            showform(True, gridledger.GetFocusedRowCellValue("NAME"))

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

            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objaccountsmaster As New AccountsMaster
                objaccountsmaster.MdiParent = MDIMain
                objaccountsmaster.edit = editval
                objaccountsmaster.frmstring = frmstring
                objaccountsmaster.tempAccountsName = name
                objaccountsmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtstd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstd.KeyPress
        numdotkeypress(e, txtstd, Me)
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

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress
        numdotkeypress(e, txtcrdays, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdotkeypress(e, txtcrlimit, Me)
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class