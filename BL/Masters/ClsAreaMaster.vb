
Imports DB

Public Class ClsAreaMaster

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
        'Dim AREAid, AREAid, countryid As Integer

        'Dim objTrans As SqlClient.SqlTransaction
        'objTrans = objDBOperation.StartNewTransaction
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@AREA_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_remark", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AREA_transfer", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATEAREA() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@AREA_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@AREA_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@AREA_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@AREA_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@AREA_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@AREA_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@AREA_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@AREAid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region


End Class
