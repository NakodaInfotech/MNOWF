
Imports DB

Public Class ClsDocumentOutward


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

#Region "Function"

    Public Function SAVE() As DataTable
        Dim DT As DataTable

        Try

            'save GROUP OF HOTELS
            Dim strCommand As String = "SP_TRANS_DOCUMENTOUTWARD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOCTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OUTMODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOCDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function update() As Integer
        Dim intResult As Integer

        Try

            'save gradeMaster
            Dim strCommand As String = "SP_TRANS_DOCUMENTOUTWARD_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOCTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OUTMODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DOCDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OUTWARDNO", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As DataTable
        Dim DT As DataTable

        Try

            'save gradeMaster
            Dim strCommand As String = "SP_TRANS_DOCUMENTOUTWARD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@OUTWARDNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETDOC() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_TRANS_SELECT_DOCUMENTOUTWARD"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region


End Class
