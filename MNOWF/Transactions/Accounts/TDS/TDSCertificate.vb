
Imports BL

Public Class TDSCertificate

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsTDSCertificate

        ALPARAVAL.Add(cmbname.Text.Trim)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(AccFrom)
            'COZ DATE WONT BE IN ACCOUNTING YEAR
            If CmpName = "TRANSFER DATA" Then
                ALPARAVAL.Add(Now.Date)
            Else
                ALPARAVAL.Add(AccTo)
            End If
        End If

        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        dt = objregister.GETALL
        
        griddetails.DataSource = dt

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND LEDGERS.ACC_TDSAC = 'TRUE' and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND LEDGERS.ACC_TDSAC = 'TRUE' and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TDSAC = 'TRUE' and ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCertificate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCertificate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillname(cmbname, False, " AND LEDGERS.ACC_TDSAC = 'TRUE' and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
            'fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim ALPARAVAL As New ArrayList
            Dim OBJTDS As New ClsTDSCertificate

            Dim INTRESULT As Integer

            Dim BILLINITIALS As String = ""
            Dim BILLAMT As String = ""
            Dim TDSAMT As String = ""
            Dim CHALLANNO As String = ""
            Dim CHALLANDATE As String = ""
            Dim CERTNO As String = ""
            Dim QTR1 As String = ""
            Dim QTR2 As String = ""
            Dim QTR3 As String = ""
            Dim QTR4 As String = ""

            If gridregister.FilterPanelText <> "" Then gridregister.ActiveFilterEnabled = False

            For i As Integer = 0 To gridregister.DataRowCount - 1
                Dim dtrow As DataRow = gridregister.GetDataRow(i)
                If dtrow("CERTNO").ToString <> "" Then

                    If BILLINITIALS = "" Then
                        BILLINITIALS = dtrow("BILLNO").ToString
                        BILLAMT = dtrow("BILLAMT").ToString
                        TDSAMT = dtrow("TDSAMT").ToString
                        CHALLANNO = dtrow("CHALLANNO").ToString
                        CHALLANDATE = Format(Convert.ToDateTime(dtrow("CHALLANDATE")).Date, "MM/dd/yyyy")
                        CERTNO = dtrow("CERTNO").ToString
                        QTR1 = dtrow("QTR1").ToString
                        QTR2 = dtrow("QTR2").ToString
                        QTR3 = dtrow("QTR3").ToString
                        QTR4 = dtrow("QTR4").ToString
                    Else
                        BILLINITIALS = BILLINITIALS & "," & dtrow("BILLNO").ToString
                        BILLAMT = BILLAMT & "," & dtrow("BILLAMT").ToString
                        TDSAMT = TDSAMT & "," & dtrow("TDSAMT").ToString
                        CHALLANNO = CHALLANNO & "," & dtrow("CHALLANNO").ToString
                        CHALLANDATE = CHALLANDATE & "," & Format(Convert.ToDateTime(dtrow("CHALLANDATE")).Date, "MM/dd/yyyy")
                        CERTNO = CERTNO & "," & dtrow("CERTNO").ToString
                        QTR1 = QTR1 & "," & dtrow("QTR1").ToString
                        QTR2 = QTR2 & "," & dtrow("QTR2").ToString
                        QTR3 = QTR3 & "," & dtrow("QTR3").ToString
                        QTR4 = QTR4 & "," & dtrow("QTR4").ToString
                    End If

                End If
            Next


            ALPARAVAL.Add(cmbname.Text.Trim)
            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If

            ALPARAVAL.Add(BILLINITIALS)
            ALPARAVAL.Add(BILLAMT)
            ALPARAVAL.Add(TDSAMT)
            ALPARAVAL.Add(CHALLANNO)
            ALPARAVAL.Add(CHALLANDATE)
            ALPARAVAL.Add(CERTNO)
            ALPARAVAL.Add(QTR1)
            ALPARAVAL.Add(QTR2)
            ALPARAVAL.Add(QTR3)
            ALPARAVAL.Add(QTR4)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)

            OBJTDS.alParaval = ALPARAVAL
            INTRESULT = OBJTDS.SAVE()
            MsgBox("Details Saved")

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\TDS Certificate Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "TDS Certificate Details"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "TDS Certificate Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim OBJTDS As New TDSFilter
            OBJTDS.MdiParent = MDIMain
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class