Imports DB

Public Class ClsAccountsMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            If frmstring = "ACCOUNTS" Then
                strcommand = "SP_MASTER_ACCOUNTSMASTER_SAVE"
            ElseIf frmstring = "CUSTOMER" Then
                strcommand = "SP_MASTER_CUSTOMERMASTER_SAVE"
            ElseIf frmstring = "VENDOR" Then
                strcommand = "SP_MASTER_VENDORMASTER_SAVE"
            ElseIf frmstring = "EMPLOYEE" Then
                strcommand = "SP_MASTER_EMPLOYEEMASTER_SAVE"
            End If

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@add1", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@add2", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@std", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@statename", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@resino", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@altno", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@website", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@email", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@panno", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@range", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@division", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@stno", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@kstno", alParaval(30)))
                .Add(New SqlClient.SqlParameter("@add", alParaval(31)))
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(32)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(33)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(34)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(35)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(36)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(37)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(38)))
                .Add(New SqlClient.SqlParameter("@code", alParaval(39)))

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(40)))
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(41)))
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(42)))
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(43)))
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(44)))
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(45)))
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(46)))
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(47)))
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(48)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            If frmstring = "ACCOUNTS" Then
                strcommand = "SP_MASTER_ACCOUNTSMASTER_UPDATE"
            ElseIf frmstring = "CUSTOMER" Then
                strcommand = "SP_MASTER_CUSTOMERMASTER_UPDATE"
            ElseIf frmstring = "VENDOR" Then
                strcommand = "SP_MASTER_VENDORMASTER_UPDATE"
            ElseIf frmstring = "EMPLOYEE" Then
                strcommand = "SP_MASTER_EMPLOYEEMASTER_UPDATE"
            End If

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@add1", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@add2", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@std", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@statename", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@resino", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@altno", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@website", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@email", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@panno", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@range", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@division", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@stno", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@kstno", alParaval(30)))
                .Add(New SqlClient.SqlParameter("@add", alParaval(31)))
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(32)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(33)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(34)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(35)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(36)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(37)))
                .Add(New SqlClient.SqlParameter("@AccountId", alParaval(49)))
                .Add(New SqlClient.SqlParameter("@code", alParaval(39)))

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(40)))
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(41)))
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(42)))
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(43)))
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(44)))
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(45)))
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(46)))
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(47)))
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(48)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            If frmstring = "ACCOUNTS" Then
                strcommand = "SP_MASTER_ACCOUNTSMASTER_DELETE"
            ElseIf frmstring = "CUSTOMER" Then
                strcommand = "SP_MASTER_CUSTOMERMASTER_DELETE"
            ElseIf frmstring = "VENDOR" Then
                strcommand = "SP_MASTER_VENDORMASTER_DELETE"
            ElseIf frmstring = "EMPLOYEE" Then
                strcommand = "SP_MASTER_EMPLOYEEMASTER_DELETE"
            End If

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
                
            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function GETACCOUNTS() As DataTable
        Dim DT As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_SELECT_ACCOUNTS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
            End With

            DT = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region


End Class
