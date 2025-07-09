
Imports BL

Public Class BankReco

    Dim EDIT As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BankReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objRECO As New ClsBankReco
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            objRECO.alParaval = ALPARAVAL

            If chkAll.CheckState = CheckState.Unchecked Then
                DT = objRECO.GETDATA
                EDIT = False
            Else
                DT = objRECO.GETALLDATA()
                EDIT = True
            End If

            'If DT.Rows.Count > 0 Then
            griddetails.DataSource = DT
            TOTAL()
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            Dim OBJBANKRECO As New ClsBankReco
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJBANKRECO.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJBANKRECO.GETTOTAL
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then txtbalcmp.Text = Format(DT.Rows(0).Item(0), "0.00")
                LBLBOOKDRCR.Text = DT.Rows(0).Item(1)
                If DT.Rows(0).Item(2).ToString <> "" Then txtdr.Text = Format(DT.Rows(0).Item(2), "0.00")
                If DT.Rows(0).Item(3).ToString <> "" Then txtcr.Text = Format(DT.Rows(0).Item(3), "0.00")
                If DT.Rows(0).Item(4).ToString <> "" Then txtbal.Text = Format(DT.Rows(0).Item(4), "0.00")
                LBLBANKDRCR.Text = DT.Rows(0).Item(5)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim OBJRECO As New ClsBankReco
            Dim INTRESULT As Integer
            Dim ALPARAVAL As New ArrayList
            Dim type As String = ""
            Dim BILLINITIALS As String = ""
            Dim billno As String = ""
            Dim recodate As String = ""
            Dim gridsrno As String = ""
            Dim BILLYEARID As String = ""

            If gridBANKRECO.FilterPanelText <> "" Then gridBANKRECO.ActiveFilterEnabled = False

            For i As Integer = 0 To gridBANKRECO.DataRowCount - 1
                Dim dtrow As DataRow = gridBANKRECO.GetDataRow(i)
                If dtrow(3).ToString <> "" Then

                    If type = "" Then
                        type = dtrow(2).ToString
                        BILLINITIALS = dtrow("BillInitials").ToString
                        billno = dtrow(9).ToString
                        recodate = Format(Convert.ToDateTime(dtrow(3)).Date, "MM/dd/yyyy")
                        gridsrno = dtrow(8).ToString
                        BILLYEARID = dtrow("YEARID").ToString
                    Else
                        type = type & "," & dtrow(2).ToString
                        BILLINITIALS = BILLINITIALS & "," & dtrow("BillInitials").ToString
                        billno = billno & "," & dtrow(9).ToString
                        recodate = recodate & "," & Format(Convert.ToDateTime(dtrow(3)).Date, "MM/dd/yyyy")
                        gridsrno = gridsrno & "," & dtrow(8)
                        BILLYEARID = BILLYEARID & "," & dtrow("YEARID").ToString
                    End If

                End If
            Next

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(type)
            ALPARAVAL.Add(BILLINITIALS)
            ALPARAVAL.Add(billno)
            ALPARAVAL.Add(recodate)
            ALPARAVAL.Add(gridsrno)
            ALPARAVAL.Add(BILLYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJRECO.alParaval = ALPARAVAL

            If EDIT = False Then
                INTRESULT = OBJRECO.SAVE()
                MsgBox("Details Saved")
            Else
                INTRESULT = OBJRECO.UPDATE()
                MsgBox("Details Saved")
            End If

            chkAll.CheckState = CheckState.Unchecked
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Print Statement?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJRPT As New clsReportDesigner("BANK STATEMENT", System.AppDomain.CurrentDomain.BaseDirectory & "BANK STATEMENT.xlsx", 2)
                OBJRPT.BANKSTATEMENT(txtname.Text.Trim, dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId)
            Else
                Dim OBJRPT As New clsReportDesigner("BANK RECO", System.AppDomain.CurrentDomain.BaseDirectory & "BANK RECO.xlsx", 2)
                OBJRPT.BANKRECO(txtname.Text.Trim, dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId)
            End If

            'Dim PATH As String
            'PATH = Application.StartupPath & "\Bank Reco.XLS"
            'Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            'opti.ShowGridLines = True
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            'Dim PERIOD As String = dtfrom.Value.Date & " - " & dtto.Value.Date

            'opti.SheetName = "Bank Reco"
            'gridBANKRECO.ExportToXls(PATH, opti)
            'EXCELCMPHEADER(PATH, "Bank Reco", gridBANKRECO.VisibleColumns.Count + gridBANKRECO.GroupCount, txtname.Text.Trim, PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBANKRECO_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridBANKRECO.InvalidRowException
        Try
            e.ErrorText = "Reco Date should be after Bill Date"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBANKRECO_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridBANKRECO.ValidateRow
        Try

            Dim BILLDATE, BANKDATE As Date
            BILLDATE = gridBANKRECO.GetFocusedRowCellValue("BillDate")
            If IsDBNull(gridBANKRECO.GetFocusedRowCellValue("RecoDate")) = True Then
                BANKDATE = BILLDATE
            Else
                BANKDATE = gridBANKRECO.GetFocusedRowCellValue("RecoDate")
            End If

            If BILLDATE > BANKDATE Then e.Valid = False
            gridBANKRECO.SetColumnError(gridBANKRECO.Columns("grecodate"), "Reco Date should be after Bill Date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class