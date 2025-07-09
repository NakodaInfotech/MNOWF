
Imports DB

Public Class ClsBooking

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
            Dim strCommand As String = "SP_TRANS_BOOKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INSAFOSMA", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ROOMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPOSIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHQDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAXNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ROOMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BDATE", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
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

    Public Function SELECTBOOKING() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_BOOKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SENTBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INSAFOSMA", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ROOMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAX", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPOSIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHQDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAXNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ROOMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BDATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(1)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_CLOSE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
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
