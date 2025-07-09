
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PLDesign

    Dim RPTPL As New ProfitLossReport
    Dim RPTBS As New BalanceSheetReport

    Public frmstring As String
    Public SHOWNARR As Integer = 0
    Public FROMDATE As Date
    Public TODATE As Date
    Public DUEDATE As Date
    Public CHANGEDUEDATE As Boolean
    Public strsearch As String
    Public PERIOD As String
    Public SIDEDAYS As Integer
    Public CALCDAYS As Integer
    Public INTPER As Double
    Public TDSPER As Double
    Public OVERRIDEDUEDATE As Integer = 1

    Private Sub PLDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PLdesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If frmstring = "BALANCESHEET" Then
                crTables = RPTBS.Database.Tables
            Else
                crTables = RPTPL.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************

            CRPO.SelectionFormula = strsearch
            If frmstring = "BALANCESHEET" Then
                CRPO.ReportSource = RPTBS
                RPTBS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            Else
                CRPO.ReportSource = RPTPL
                RPTPL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        If frmstring = "BALANCESHEET" Then
            tempattachment = "BALANCESHEET"
        Else
            tempattachment = "PROFITLOSS"
        End If

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

            Dim oDfDopt As New DiskFileDestinationOptions
            Dim expo As ExportOptions
            If frmstring = "BALANCESHEET" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\BALANCESHEET.PDF"
                expo = RPTBS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBS.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\PROFITLOSS.PDF"
                expo = RPTPL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPL.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class