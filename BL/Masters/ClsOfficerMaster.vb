
Imports DB

Public Class ClsOfficerMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_OFFICERMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RANK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMPCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOJ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INDIAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRIBUTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAXNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MUINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAMILY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_OFFICERMASTER_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RANK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMPCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOJ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INDIAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRIBUTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAXNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MUINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAMILY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OFFICERID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_OFFICERMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETOFFICER() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_OFFICER"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
