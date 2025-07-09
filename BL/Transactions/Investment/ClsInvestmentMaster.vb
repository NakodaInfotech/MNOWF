
Imports DB

Public Class ClsInvestmentMaster
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

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save investment MASTER
            Dim strCommand As String = "SP_TRANS_INVESTMENTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@INVEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CERTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPOSITDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATURITYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROI", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OLDCERTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDDEPOSITDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDMATURITYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function selectinvestment_edit() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_INVESTMENT_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@INVENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_INVESTMENTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@INVEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CERTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPOSITDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATURITYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROI", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OLDCERTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDDEPOSITDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDMATURITYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVENO", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    'Public Function GETBILLS(ByVal CMPID As Integer, ByVal NAME As String, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As DataTable
    '    Dim dtTable As DataTable
    '    Try

    '        Dim strCommand As String = "SP_TRANS_SELECT_RECEIPTMASTER_GETBILLS"
    '        Dim alParameter As New ArrayList
    '        With alParameter
    '            .Add(New SqlClient.SqlParameter("@NAME", NAME))
    '            .Add(New SqlClient.SqlParameter("@CMPID", CMPID))
    '            .Add(New SqlClient.SqlParameter("@LOCATIONID", LOCATIONID))
    '            .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
    '        End With
    '        dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return dtTable
    'End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_INVESTMENTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@INVENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
