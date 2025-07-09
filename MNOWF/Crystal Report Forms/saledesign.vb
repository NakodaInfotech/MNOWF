Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class saledesign

    Dim rpts As New saledetails
    Dim rptssum As New salesummary
    Dim rptinv As New Invoice
    Public strsumm As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public INVNO As Integer
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String


    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, FROMDATE)
        a2 = DatePart(DateInterval.Month, FROMDATE)
        a3 = DatePart(DateInterval.Year, FROMDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TODATE)
        a12 = DatePart(DateInterval.Month, TODATE)
        a13 = DatePart(DateInterval.Year, TODATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub saledesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub saledesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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

            If strsumm = "" Then
                crTables = rpts.Database.Tables
            ElseIf strsumm = "Invoice" Then
                crTables = rptinv.Database.Tables
            Else
                crTables = rptssum.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            'If strsumm = "" Then
            '    crParameterFieldDefinitions = rpts.DataDefinition.ParameterFields
            'Else
            '    crParameterFieldDefinitions = rptssum.DataDefinition.ParameterFields
            'End If



            
            'crParameterValues.Clear()
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'crParameterDiscreteValue.Value = FROMDATE.Date
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'crParameterDiscreteValue.Value = TODATE.Date
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            getFromToDate()

            If strsumm <> "Invoice" Then
                strsearch = strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                '{REPORT_SP_INVOICESUMMARY.INVOICE_date}>='" & Format(FROMDATE, "MM/dd/yyyy") & "' and {REPORT_SP_INVOICESUMMARY.INVOICE_date}<='" & Format(TODATE, "MM/dd/yyyy") & "'
                strsearch = strsearch & "  and {REPORT_SP_INVOICESUMMARY.INVOICE_cmpid}=" & CmpId & " and {REPORT_SP_INVOICESUMMARY.INVOICE_locationid}=" & Locationid & " and {REPORT_SP_INVOICESUMMARY.INVOICE_yearid}=" & YearId
            Else
                crParameterFieldDefinitions = rptinv.DataDefinition.ParameterFields
                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues

                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = registername
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@REGISTERNAME")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = Locationid
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = YearId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = INVNO
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@IBILL_NO")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            End If

            CRPO.SelectionFormula = strsearch
            If strsumm = "" Then
                CRPO.ReportSource = rpts
            ElseIf strsumm = "Invoice" Then
                CRPO.ReportSource = rptinv
            Else
                CRPO.ReportSource = rptssum
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

        If strsumm = "" Then
            tempattachment = "SALEDETAILS"
        Else
            tempattachment = "SALESUMMARY"
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
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If strsumm = "" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SALEDETAILS.PDF"
                expo = rpts.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rpts.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\SALESUMMARY.PDF"
                expo = rptssum.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptssum.Export()
            End If

            

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class