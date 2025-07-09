
Imports DB

Public Class ClsExpenseVoucher

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
        Try
            'save NONPURCHASE 
            Dim strCommand As String = "SP_TRANS_PURCHASE_NONPURCHASE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NPDATE", alParaval(2)))

                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TAX", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(19)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@DRNAME", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@amount", alParaval(25)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update NONPURCHASE
            Dim strCommand As String = "SP_TRANS_PURCHASE_NONPURCHASE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NPDATE", alParaval(2)))

                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TAX", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(19)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@DRNAME", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@amount", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@NPNO", alParaval(26)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectNONpurchase() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTNONPURCHASE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NPNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_PURCHASE_NONPURCHASE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NPNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
