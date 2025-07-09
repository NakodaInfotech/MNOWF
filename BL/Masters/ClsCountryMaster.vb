
Imports DB

Public Class ClsCountryMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function save() As Integer

        Dim intResult As Integer
        'Dim COUNTRYid, COUNTRYid, countryid As Integer

        'Dim objTrans As SqlClient.SqlTransaction
        'objTrans = objDBOperation.StartNewTransaction
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@COUNTRY_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_remark", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COUNTRY_transfer", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATECOUNTRY() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@COUNTRY_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@COUNTRY_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@COUNTRYid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region


End Class
