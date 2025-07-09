
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class CorrespondenceDesign

    Public FRMSTRING As String
    Public OFFICERNAME As String
    Public FORMULA As String
    Public DIRECTWHATSAPP As Boolean
    Public CORRESNO As Integer
    Public BOOKINGNO As Integer

    Dim RPTCMP As New CorresCmpReport
    Dim RPTOFFICER As New CorresOffReport

    Private Sub CorrespondenceDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CorrespondenceDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

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

            If FRMSTRING = "COMPANY" Then
                crTables = RPTCMP.Database.Tables
            Else
                crTables = RPTOFFICER.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            strsearch = strsearch & "  {CORRESPONDENCE.CORRES_NO}= " & CORRESNO & " and {CORRESPONDENCE.CORRES_CMPID} = " & CmpId & " and {CORRESPONDENCE.CORRES_LOCATIONID} = " & Locationid & " and {CORRESPONDENCE.CORRES_YEARID} = " & YearId
            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "COMPANY" Then
                CRPO.ReportSource = RPTCMP
            Else
                CRPO.ReportSource = RPTOFFICER
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

        Try
            Dim objmail As New SendMail
            If FRMSTRING = "COMPANY" Then
                tempattachment = "Company Letter"
                objmail.subject = "Company Letter"
            Else
                tempattachment = "Officer Letter"
                objmail.subject = "Officer Letter"
            End If
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

            If FRMSTRING = "COMPANY" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Company Letter.PDF"
                expo = RPTCMP.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCMP.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\Officer Letter.PDF"
                expo = RPTOFFICER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOFFICER.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class