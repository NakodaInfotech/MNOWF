
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class payment_advice
    Public FORMULA As String
    Public TEMPREQNO As Integer
    Public payno As Integer
    Public DIRECTPRINT As Boolean = False
    Public OFFICERNAME As String
    Public NOOFCOPIES As Integer = 1
    Public DIRECTMAIL As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public payname As String
    Public REGNAME As String
    Public FRMSTRING As String
    Dim obj_paytype As New Paymentreport
    Dim OBJCHQPAY As New ChqPayment
    Dim OBJREFUND As New PaymentRefundReport
    Dim OBJCLAIM As New PaymentClaimReport
    Public DIRECTWHATSAPP As Boolean = False
    Public MULTIPAYNO As String
    Dim TEMPATTACHMENT As String
    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()

            If FRMSTRING = "CLAIM" Then
                TEMPATTACHMENT = "Claim-Payment Voucher_" & payno
            Else
                TEMPATTACHMENT = "Payment Voucher_" & payno
            End If

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.OFFICERNAME = OFFICERNAME
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF")
            OBJWHATSAPP.FILENAME.Add(TEMPATTACHMENT & ".pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub payment_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub payment_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strsearch As String
        strsearch = ""

        Try
            If DIRECTPRINT = True And DIRECTWHATSAPP = False Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If


            If DIRECTWHATSAPP = True Then
                PRINTDIRECTADVICE()
                Exit Sub
            End If




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

            If FRMSTRING = "CHQPRINT" Then
                crTables = OBJCHQPAY.Database.Tables
            ElseIf FRMSTRING = "CLAIM" Then
                crTables = OBJCLAIM.Database.Tables
            ElseIf FRMSTRING = "REFUND" Then
                crTables = OBJREFUND.Database.Tables
            Else
                crTables = obj_paytype.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CHQPRINT" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJCHQPAY
            ElseIf FRMSTRING = "CLAIM" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJCLAIM
            ElseIf FRMSTRING = "REFUND" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJREFUND
            Else
                strsearch = strsearch & "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.CMPID} = " & CmpId & " and {PAYMENT_REPORT.LOCATIONID} = " & Locationid & " and {PAYMENT_REPORT.YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = obj_paytype
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



            If FRMSTRING = "CLAIM" Then
                OBJ = New PaymentClaimReport
            Else
                OBJ = New Paymentreport
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


                If FRMSTRING = "CLAIM" Then
                    TEMPATTACHMENT = "Claim-Payment Voucher_" & payno
                Else
                    TEMPATTACHMENT = "Payment Voucher_" & payno
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
        Dim tempattachment As String


        Try
            Dim objmail As New SendMail
            If FRMSTRING = "CLAIM" Then
                tempattachment = "Claim-Payment Voucher_" & payno
                objmail.subject = "Claimreport"
            ElseIf FRMSTRING = "REFUND" Then
                tempattachment = "REFUNDREPORT"
                objmail.subject = "Refundreport"
            Else
                tempattachment = "Payment Voucher_" & payno
                objmail.subject = "Paymentreport"
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

    Sub PRINTDIRECTLYTOPRINTER()

        Dim OBJ As Object = New ChqPayment

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

        crTables = OBJ.Database.Tables
        For Each crTable In crTables
            crtableLogonInfo = crTable.LogOnInfo
            crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)
        Next

        CRPO.SelectionFormula = " {PAYMENTMASTER.PAYMENT_NO} in " & MULTIPAYNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
        CRPO.ReportSource = OBJ

    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions


            If FRMSTRING = "CLAIM" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Claim-Payment Voucher_" & payno & ".PDF"
                expo = OBJCLAIM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJCLAIM.Export()
            ElseIf FRMSTRING = "REFUND" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\REFUNDREPORT.PDF"
                expo = OBJREFUND.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJREFUND.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\Payment Voucher_" & payno & ".PDF"
                expo = obj_paytype.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                obj_paytype.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class