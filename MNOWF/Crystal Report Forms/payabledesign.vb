Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class payabledesign

    Dim rptpsum As New payableoutstandingreport
    Dim RPTPACKOUT As New PackPayableOutstanding
    Dim RPTINTOUT As New IntPayableOutstanding
    Public strsumm As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public FRMSTRING As String

    Private Sub payabledesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub payabledesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "payableoutstanding" Or FRMSTRING = "payableoutstandingsummary" Then
                crTables = rptpsum.Database.Tables
                strsearch = strsearch & " and {HOTELBOOKINGMASTER.BOOKING_CANCELLED}= FALSE and  {HOTELBOOKINGMASTER.BOOKING_AMD_DONE}= FALSE  and  {HOTELBOOKINGMASTER.BOOKING_CMPid}=" & CmpId & " and {HOTELBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and {HOTELBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "PACKAGE PAYABLEOUTSTANDING" Or FRMSTRING = "PACKAGE PAYABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTPACKOUT.Database.Tables
                strsearch = strsearch & " and  {HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED}= False and  {HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE}= False and  {HOLIDAYPACKAGEMASTER.BOOKING_CMPid}=" & CmpId & " and {HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONid}=" & Locationid & " and {HOLIDAYPACKAGEMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTINTOUT.Database.Tables
                strsearch = strsearch & " and  {INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED}= False and  {INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE}= False and  {INTERNATIONALBOOKINGMASTER.BOOKING_CMPid}=" & CmpId & " and {INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and {INTERNATIONALBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************

            CRPO.SelectionFormula = strsearch
            If strsumm = "" Then
                rptpsum.DataDefinition.FormulaFields("txt").Text = 1
                rptpsum.DataDefinition.FormulaFields("TITLE").Text = "'PAYABLE OUTSTANDING DETAILS'"
            Else
                rptpsum.DataDefinition.FormulaFields("txt").Text = 0
                rptpsum.DataDefinition.FormulaFields("TITLE").Text = "'PAYABLE SUMMARY'"
            End If

            If FRMSTRING = "payableoutstanding" Or FRMSTRING = "payableoutstandingsummary" Then
                CRPO.ReportSource = rptpsum
            ElseIf FRMSTRING = "PACKAGE PAYABLEOUTSTANDING" Or FRMSTRING = "PACKAGE PAYABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTPACKOUT
            ElseIf FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTINTOUT
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
        Dim tempattachment As String

        tempattachment = "PAYABLEREPORT"
        
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


            oDfDopt.DiskFileName = Application.StartupPath & "\PAYABLEREPORT.PDF"

            If FRMSTRING = "payableoutstanding" Or FRMSTRING = "payableoutstandingsummary" Then
                expo = rptpsum.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptpsum.Export()
            ElseIf FRMSTRING = "PACKAGE PAYABLEOUTSTANDING" Or FRMSTRING = "PACKAGE PAYABLEOUTSTANDINGSUMMARY" Then
                expo = RPTPACKOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKOUT.Export()
            ElseIf FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDINGSUMMARY" Then
                expo = RPTINTOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINTOUT.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class