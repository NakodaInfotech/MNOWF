
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class ClaimDesign
    Public FORMULA As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1
    Public FRMSTRING As String
    Public TYPE As String = ""
    Dim STRSEARCH As String = ""
    Public SETTLENO As Integer
    Public FROMDATE As Date
    Public TODATE As Date
    Dim TEMPATTACHMENT As String
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Dim RPTACK As New AcknowledgementInReport
    Dim RPTEDU As New EduSettlementApproval
    Dim RPTMED As New MedSettlementApproval
    Dim RPTPAYDTLS As New ClaimPayRegisterReport
    Dim RPTBANKPAYDTLS As New NewBankClaimPayRegisterReport
    'Dim RPTBANKPAYDTLS As New BankClaimPayRegisterReport

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

    Private Sub ClaimDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClaimDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If DIRECTPRINT = True Then
                Transfer()
                Exit Sub
            End If

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table

            If DIRECTPRINT = True Then
                PRINTDIRECTADVICE()
                Exit Sub
            End If

            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "EDUCATION" Then
                crTables = RPTEDU.Database.Tables
            ElseIf FRMSTRING = "PAYMENTREGISTER" Then
                crTables = RPTPAYDTLS.Database.Tables
            ElseIf FRMSTRING = "BANKPAYMENTREGISTER" Then
                crTables = RPTBANKPAYDTLS.Database.Tables
            ElseIf FRMSTRING = "ACKNOWLEDGEMENT" Then
                crTables = RPTACK.Database.Tables
            Else
                crTables = RPTMED.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "EDUCATION" Then
                STRSEARCH = STRSEARCH & "  {EDUCLAIMSETTLEMENT.SETTLE_NO}= " & SETTLENO & " and {EDUCLAIMSETTLEMENT.SETTLE_CMPID} = " & CmpId & " and {EDUCLAIMSETTLEMENT.SETTLE_LOCATIONID} = " & Locationid & " and {EDUCLAIMSETTLEMENT.SETTLE_YEARID} = " & YearId
                CRPO.SelectionFormula = STRSEARCH
                CRPO.ReportSource = RPTEDU
            ElseIf FRMSTRING = "PAYMENTREGISTER" Then
                getFromToDate()
                STRSEARCH = " ({@DATE} in date " & fromD & " to date " & toD & ") "
                If TYPE <> "" Then STRSEARCH = STRSEARCH & " AND {CLAIMDETAILS.TYPE} = '" & TYPE & "' "
                Dim PERIOD As String = "From " & FROMDATE & " To " & TODATE
                STRSEARCH = STRSEARCH & " AND {CLAIMDETAILS.CMPID} = " & CmpId & " and {CLAIMDETAILS.LOCATIONID} = " & Locationid & " and {CLAIMDETAILS.YEARID} = " & YearId
                RPTPAYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                CRPO.SelectionFormula = STRSEARCH
                CRPO.ReportSource = RPTPAYDTLS
            ElseIf FRMSTRING = "BANKPAYMENTREGISTER" Then
                getFromToDate()
                STRSEARCH = " ({@DATE} in date " & fromD & " to date " & toD & ") "
                If TYPE <> "" Then STRSEARCH = STRSEARCH & " AND {CLAIMDETAILS.TYPE} = '" & TYPE & "' "
                Dim PERIOD As String = "From " & FROMDATE & " To " & TODATE
                STRSEARCH = STRSEARCH & " AND {CLAIMDETAILS.YEARID} = " & YearId
                RPTBANKPAYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                CRPO.SelectionFormula = STRSEARCH
                CRPO.ReportSource = RPTBANKPAYDTLS
            ElseIf FRMSTRING = "ACKNOWLEDGEMENT" Then
                STRSEARCH = STRSEARCH & "  {DOCUMENTINWARD.DOCIN_NO}= " & SETTLENO & " and {DOCUMENTINWARD.DOCIN_CMPID} = " & CmpId & " and {DOCUMENTINWARD.DOCIN_LOCATIONID} = " & Locationid & " and {DOCUMENTINWARD.DOCIN_YEARID} = " & YearId
                CRPO.SelectionFormula = STRSEARCH
                CRPO.ReportSource = RPTACK
            Else
                STRSEARCH = STRSEARCH & "  {MEDCLAIMSETTLEMENT.SETTLE_NO}= " & SETTLENO & " and {MEDCLAIMSETTLEMENT.SETTLE_CMPID} = " & CmpId & " and {MEDCLAIMSETTLEMENT.SETTLE_LOCATIONID} = " & Locationid & " and {MEDCLAIMSETTLEMENT.SETTLE_YEARID} = " & YearId
                CRPO.SelectionFormula = STRSEARCH
                CRPO.ReportSource = RPTMED
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

    Sub PRINTDIRECTADVICE()
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
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With


            Dim OBJ As New Object



            If FRMSTRING = "REFPAYREP" Then
                OBJ = New RefundPayReport
            Else
                OBJ = New AllotmentLetter
            End If


            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            OBJ.RecordSelectionFormula = FORMULA

            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions


                If FRMSTRING = "REFPAYREP" Then
                    TEMPATTACHMENT = "REFUND_" & SETTLENO
                Else
                    TEMPATTACHMENT = "ALLOTMENTLETTER_" & SETTLENO
                End If

                oDfDopt.DiskFileName = Application.StartupPath & "\" & TEMPATTACHMENT & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String = ""


        Try
            Dim objmail As New SendMail
            If FRMSTRING = "PAYMENTREGISTER" Then
                tempattachment = "Claim Payment Register"
                objmail.subject = "Claim Payment Register"
            ElseIf FRMSTRING = "ACKNOWLEDGEMENT" Then
                tempattachment = "Acknowledgement"
                objmail.subject = "Acknowledgement"
            Else
                tempattachment = "Approval Letter"
                objmail.subject = "Approval Letter"
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

            If FRMSTRING = "EDUCATION" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Approval Letter.PDF"
                expo = RPTEDU.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTEDU.Export()
            ElseIf FRMSTRING = "BANKPAYMENTREGISTER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Claim Bank Payment Register.xls"
                expo = RPTBANKPAYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.Excel  ' <--- NOT ExcelRecord!

                Dim excelOptions As New ExcelFormatOptions
                excelOptions.ExcelUseConstantColumnWidth = True
                excelOptions.ShowGridLines = True
                excelOptions.ExcelTabHasColumnHeadings = True
                expo.ExportFormatOptions = excelOptions

                expo.DestinationOptions = oDfDopt
                RPTBANKPAYDTLS.Export()

            ElseIf FRMSTRING = "PAYMENTREGISTER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Claim Payment Register.PDF"
                expo = RPTPAYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYDTLS.Export()
            ElseIf FRMSTRING = "ACKNOWLEDGEMENT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Acknowledgement.PDF"
                expo = RPTACK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTACK.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\Approval Letter.PDF"
                expo = RPTMED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMED.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class