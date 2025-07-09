
Imports DB

Public Class ClsRefund

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
            Dim strCommand As String = "SP_TRANS_REFUND_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REFUNDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPOSIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFUND", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKADD", alParaval(I)))
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

    Public Function SELECTREFUND() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_REFUND_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REFUNDNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_REFUND_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REFUNDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPOSIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFUND", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKADD", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@REFUNDNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_REFUND_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REFUNDNO", alParaval(0)))
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
