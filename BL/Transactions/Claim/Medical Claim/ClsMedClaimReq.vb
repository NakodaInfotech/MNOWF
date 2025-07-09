
Imports DB

Public Class ClsMedClaimReq
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save Journal
            Dim strCommand As String = "SP_TRANS_MEDCLAIMREQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REQDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AUTHOFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AUTHOTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOJ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PATIENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DIAGNOSIS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ILLFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ILLTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOSPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOSPADD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DRNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VESSEL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSCCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKADD", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALCLAIMED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALMAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CLAIMED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTCLAIM() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MEDCLAIMREQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function update() As DataTable
        Dim DT As DataTable
        Try
            'update Journal Entry
            Dim strCommand As String = "SP_TRANS_MEDCLAIMREQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REQDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AUTHOFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AUTHOTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOJ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PATIENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DIAGNOSIS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ILLFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ILLTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOSPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOSPADD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DRNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VESSEL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSCCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKADD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALCLAIMED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALMAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CLAIMED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_MEDCLAIMREQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CLOSE() As Integer
        Dim INTRES As Integer
        Try
            Dim strCommand As String = "SP_TRANS_MEDCLAIMREQ_CLOSE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
