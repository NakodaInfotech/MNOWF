
Imports DB

Public Class ClsCorrespondence

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
            Dim strCommand As String = "SP_TRANS_CORRESPONDENCE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@EMPTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVEFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVETO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CORRESDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FAMILY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARRID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARA1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARA2", alParaval(I)))
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

    Public Function SELECTCORRES() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_CORRESPONDENCE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CORRESNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_CORRESPONDENCE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@EMPTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVEFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVETO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CORRESDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OFFICERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FAMILY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RELATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARRID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARA1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARA2", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CORRESNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_CORRESPONDENCE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CORRESNO", alParaval(0)))
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
            Dim strCommand As String = "SP_TRANS_CORRESPONDENCE_CLOSE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CORRESNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@RECDDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@RECDREMARKS", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(5)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
