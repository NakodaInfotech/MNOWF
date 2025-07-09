
Imports DB

Public Class ClsItemInventory

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
            Dim strCommand As String = "SP_TRANS_INVENTORY_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@HOTEL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALOPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALREQ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALPASSED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALDAMAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALCLOSING", alParaval(I)))
                I += 1

                
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMCATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REQ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PASSED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DAMAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CLOSING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
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

    Public Function SELECTINVENTORY() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_INVENTORY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVENTORYNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_INVENTORY_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@HOTEL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALOPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALREQ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALPASSED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALDAMAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALCLOSING", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMCATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REQ", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PASSED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DAMAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CLOSING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@INVENTORYNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_INVENTORY_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@INVENTORYNO", alParaval(0)))
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

#End Region

End Class
