

Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class BookingDesign

    Public FORMULA As String
    Public FROMDATE As Date
    Public TODATE As Date
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public OFFICERNAME As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1
    Dim TEMPATTACHMENT As String

    Dim RPTREFDTLS As New RefundPayReport
    Dim RPTBOOKING As New AllotmentLetter

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()

            If FRMSTRING = "REFPAYREP" Then
                TEMPATTACHMENT = "REFUND_" & BOOKINGNO
            Else
                TEMPATTACHMENT = "ALLOTMENTLETTER_" & BOOKINGNO
            End If

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.OFFICERNAME = OFFICERNAME
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF")
            OBJWHATSAPP.FILENAME.Add(tempattachment & ".pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


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

    Private Sub BookingDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BookingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTADVICE()
                Exit Sub
            End If


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

            If FRMSTRING = "REFPAYREP" Then
                crTables = RPTREFDTLS.Database.Tables
            Else
                crTables = RPTBOOKING.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "REFPAYREP" Then
                getFromToDate()
                RPTREFDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'From " & FROMDATE & " To " & TODATE & "'"
                CRPO.SelectionFormula = "({@DATE} in date " & fromD & " to date " & toD & ") and {REFUNDMASTER.REFUND_YEARID} = " & YearId
                CRPO.ReportSource = RPTREFDTLS
            Else
                strsearch = strsearch & "  {BOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " and {BOOKINGMASTER.BOOKING_CMPID} = " & CmpId & " and {BOOKINGMASTER.BOOKING_LOCATIONID} = " & Locationid & " and {BOOKINGMASTER.BOOKING_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = RPTBOOKING
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
                    TEMPATTACHMENT = "REFUND_" & BOOKINGNO
                Else
                    TEMPATTACHMENT = "ALLOTMENTLETTER_" & BOOKINGNO
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
            If FRMSTRING = "REFPAYREP" Then
                tempattachment = "REFUND" & BOOKINGNO
                objmail.subject = "Refundreport"
            Else
                tempattachment = "ALLOTMENTLETTER"
                objmail.subject = "ALLOTMENTLETTER"
            End If
            objmail.attachment = Application.StartupPath & "\" & tempattachment & "_" & Val(BOOKINGNO) & ".PDF"
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


            If FRMSTRING = "REFPAYREP" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\REFUND_" & Val(BOOKINGNO) & ".PDF"
                expo = RPTREFDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREFDTLS.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\ALLOTMENTLETTER_" & Val(BOOKINGNO) & ".PDF"
                expo = RPTBOOKING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBOOKING.Export()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class