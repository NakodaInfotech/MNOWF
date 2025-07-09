
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class SalarySlipDesign

    Public SALNO As Integer
    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""

    Dim RPTSAL As New SalarySlipReport
    Dim RPTSTATEMENT As New SalaryStatementReport

    Private Sub SalarySlipDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalarySlipDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   
        Try

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "SALARY" Then
                crTables = RPTSAL.Database.Tables
            ElseIf FRMSTRING = "SALSTATEMENT" Then
                crTables = RPTSTATEMENT.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************


            CRPO.SelectionFormula = WHERECLAUSE
            If FRMSTRING = "SALARY" Then
                CRPO.ReportSource = RPTSAL
            ElseIf FRMSTRING = "SALSTATEMENT" Then
                CRPO.ReportSource = RPTSTATEMENT
            End If



            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()

        Dim tempattachment As String = ""
        If FRMSTRING = "SALARY" Then tempattachment = "Salary Slip" Else tempattachment = "Salary Statement"
        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            If FRMSTRING = "SALARY" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Salary Slip.PDF"
                expo = RPTSAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSAL.Export()

            ElseIf FRMSTRING = "SALSTATEMENT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Salary Statement.PDF"
                expo = RPTSTATEMENT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTATEMENT.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class