
Imports DB

Public Class ClsOpening

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

    Public Function save() As Integer
        Dim INTRESULT As Integer
        Try
            'save OPENING BILLS
            Dim strCommand As String = "SP_TRANS_OPENINGBILLS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))

                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OFFICER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PATIENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLAIMAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLAIMTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IFSCCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIAGNOSIS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOSPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOSPADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COURSENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COURSEYEAR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNINAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VESSEL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@YEAR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMTPAIDREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGTYPE", alParaval(I)))
                I = I + 1

            End With

            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As Integer
        Dim INTRESULT As Integer
        Try
            'save OPENING BILLS
            Dim strCommand As String = "SP_TRANS_OPENINGBILLS_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With

            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function OPENINGSAVE() As Integer
        Dim INTRESULT As Integer
        Try
            'save OPENING BILLS
            Dim strCommand As String = "SP_TRANS_OPENINGBALANCE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEBIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CREDIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region


End Class
