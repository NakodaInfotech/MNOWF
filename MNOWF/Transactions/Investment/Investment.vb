
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Investment

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDDESCDOUBLECLICK As Boolean
    Public edit As Boolean
    Dim CERTNO As String = ""
    Public TEMPINVESTMENTNO As Integer

    Sub FILLCMB()
        Try
            If CMBBANK.Text.Trim = "" Then fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') and acc_YEARid = " & YearId)
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANK_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBANK.Enter
        Try
            'OPEN BANK A/C AND BANK OD A/C
            'If CMBBANK.Text.Trim = "" Then fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR groupmaster.group_SECONDARY = 'BANK OD A/C' OR groupmaster.group_SECONDARY = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBBANK.Text.Trim = "" Then fillledger(CMBBANK, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBANK.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANK.Validating
        Try
            'If CMBBANK.Text.Trim <> "" Then ledgervalidate(CMBBANK, CMBACCCODE, e, Me, txtadd, " AND (GROUPMASTER.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.group_SECONDARY = 'BANK OD A/C' OR GROUPMASTER.group_SECONDARY = 'CASH IN HAND') AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If CMBBANK.Text.Trim <> "" Then ledgervalidate(CMBBANK, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Investments') AND ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCERTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCERTNO.Validating
        Try
            'AS PER REQ OF SALMAN BHAI
            If TXTCERTNO.Text.Trim <> "" Then
                'checking whether CERT NO. IS ALREADY PRESENT FOR SAME BANK OR NOT....
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(INVE_NO,'')", "", " INVESTMENTMASTER INNER JOIN LEDGERS ON ACC_CMPID = INVE_CMPID AND ACC_YEARID = INVE_YEARID AND ACC_ID = INVE_BANKID", " AND INVE_CERTNO = '" & TXTCERTNO.Text.Trim & "' AND ACC_CMPNAME = '" & CMBBANK.Text.Trim & "' AND INVE_CMPID = " & CmpId & " AND INVE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If (edit = False) Or (edit = True And CERTNO <> TXTCERTNO.Text.Trim) Then
                        MsgBox("Certificate No. Already Present with this Bank in Investment No." & DT.Rows(0).Item(0), MsgBoxStyle.Critical, "MNOWF")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno_INVESTMENTMASTER()
        Dim DTTABLE As DataTable = getmax(" isnull(max(INVE_NO),0) + 1 ", "INVESTMENTMASTER  ", " AND INVE_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTINVENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub Investment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdsave_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F1 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Investment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'RECEIPT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            'clear()
            getmaxno_INVESTMENTMASTER()

            'GET DEFAULT BANK (FIRST ADD A NEW COLUMN OF DEFAULT IN ALL MASTERS AND IN LEDGERS VIEW)
            'Dim objcommon As New ClsCommonMaster
            'Dim dt As New DataTable
            'dt = objcommon.search(" acc_cmpname", "", " ledgers", " and acc_default = true and acc_cmpid = " & CmpId)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList

                Dim OBJCLINVESTMENT As New ClsInvestmentMaster()
                ALPARAVAL.Add(TEMPINVESTMENTNO)
                ALPARAVAL.Add(YearId)
                OBJCLINVESTMENT.alParaval = ALPARAVAL

                dt = OBJCLINVESTMENT.selectinvestment_edit()

                If dt.Rows.Count > 0 Then

                    For Each dr As DataRow In dt.Rows

                        TXTINVENO.Text = TEMPINVESTMENTNO
                        DTINVEDATE.Value = Convert.ToDateTime(dr("INVEDATE"))
                        CMBBANK.Text = dr("BANKNAME")
                        TXTCERTNO.Text = dr("CERTNO")
                        CERTNO = dr("CERTNO")
                        CMBCITY.Text = dr("CITY")
                        DTDEPOSITDATE.Value = Convert.ToDateTime(dr("DEPOSITDATE"))
                        DTMATURITYDATE.Value = Convert.ToDateTime(dr("MATURITYDATE"))
                        TXTAMOUNT.Text = Val(dr("AMOUNT"))
                        TXTROI.Text = Val(dr("ROI"))

                        TXTOLDCERTNO.Text = dr("OLDCERTNO")
                        DTOLDDEPOSITDATE.Value = Convert.ToDateTime(dr("OLDDEPOSITDATE"))
                        DTOLDMATURITYDATE.Value = Convert.ToDateTime(dr("OLDMATURITYDATE"))
                        TXTOLDAMOUNT.Text = Val(dr("OLDAMOUNT"))
                        TXTDIFF.Text = Val(dr("DIFF"))

                        'total()
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            'If Not datecheck(DTINVEDATE.Value) Then
            '    EP.SetError(DTINVEDATE, "Date Not in Current Accounting Year")
            '    BLN = False
            'End If

            If CMBBANK.Text.Trim.Length = 0 Then
                EP.SetError(CMBBANK, "Select Bank Name")
                BLN = False
            End If

            If TXTCERTNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTCERTNO, "Enter Cert No.")
                BLN = False
            End If

            If Convert.ToDateTime(DTDEPOSITDATE.Value).Date >= Convert.ToDateTime(DTMATURITYDATE.Value).Date Then
                BLN = False
                EP.SetError(DTMATURITYDATE, "Deposit Date Cannot be greater than Maturity Date")
            End If

            If TXTAMOUNT.Text.Trim.Length = 0 Then
                EP.SetError(TXTAMOUNT, "Enter Amount")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            Dim DTTABLE As DataTable

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(DTINVEDATE.Value.Date)
            alparaval.Add(CMBBANK.Text.Trim)
            alparaval.Add(TXTCERTNO.Text.Trim)
            alparaval.Add(CMBCITY.Text.Trim)
            alparaval.Add(DTDEPOSITDATE.Value.Date)
            alparaval.Add(DTMATURITYDATE.Value.Date)
            alparaval.Add(Val(TXTAMOUNT.Text))
            alparaval.Add(Val(TXTROI.Text))

            alparaval.Add(TXTOLDCERTNO.Text.Trim)
            alparaval.Add(DTOLDDEPOSITDATE.Value.Date)
            alparaval.Add(DTOLDMATURITYDATE.Value.Date)
            alparaval.Add(Val(TXTOLDAMOUNT.Text))
            alparaval.Add(Val(TXTDIFF.Text))


            alparaval.Add(CmpId)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            'alparaval.Add(0)



            Dim OBJCLINVESTMENT As New ClsInvestmentMaster
            OBJCLINVESTMENT.alParaval = alparaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJCLINVESTMENT.SAVE()
                MessageBox.Show("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPINVESTMENTNO)
                Dim IntResult As Integer = OBJCLINVESTMENT.UPDATE()
                MsgBox("Details Updated")
                edit = False
            End If
            clear()

            DTINVEDATE.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        'clearing textboxes
        EP.Clear()
        tstxtbillno.Clear()
        DTINVEDATE.Value = Mydate
        CMBBANK.Text = ""
        TXTCERTNO.Clear()
        CMBCITY.Text = ""
        DTDEPOSITDATE.Value = Mydate
        DTMATURITYDATE.Value = Mydate
        TXTAMOUNT.Clear()
        TXTROI.Clear()

        TXTOLDCERTNO.Clear()
        DTOLDDEPOSITDATE.Value = Mydate
        DTOLDMATURITYDATE.Value = Mydate
        TXTOLDAMOUNT.Clear()
        TXTDIFF.Clear()

        getmaxno_INVESTMENTMASTER()

        edit = False

        'lbllocked.Visible = False
        'PBlock.Visible = False

    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TXTCERTNO.Text = ""
LINE1:
            TEMPINVESTMENTNO = Val(TXTINVENO.Text) - 1
            'TEMPREG = cmbregister.Text.Trim
            If TEMPINVESTMENTNO > 0 Then
                edit = True
                Investment_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TXTCERTNO.Text.Trim = "" And TEMPINVESTMENTNO > 1 Then
                TXTINVENO.Text = TEMPINVESTMENTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TXTCERTNO.Text = ""
LINE1:
            TEMPINVESTMENTNO = Val(TXTINVENO.Text) + 1
            'TEMPREG = cmbregister.Text.Trim
            getmaxno_INVESTMENTMASTER()
            Dim MAXNO As Integer = TXTINVENO.Text.Trim
            clear()
            If Val(TXTINVENO.Text) - 1 >= TEMPINVESTMENTNO Then
                edit = True
                Investment_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TXTCERTNO.Text.Trim = "" And TEMPINVESTMENTNO < MAXNO Then
                TXTINVENO.Text = TEMPINVESTMENTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            EP.Clear()
            edit = False
            DTINVEDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMOUNT.KeyPress, TXTOLDAMOUNT.KeyPress, TXTROI.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objINVESTMENT As New InvestmentDetails
            objINVESTMENT.MdiParent = MDIMain
            objINVESTMENT.Show()
            objINVESTMENT.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            ToolStripdelete_Click(sender, e)
            'DELETE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
    End Sub

    Sub DELETE()
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            'If lbllocked.Visible = True Then
            '    MsgBox("Booking Locked", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            If MsgBox("Wish to Delete Investment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJBOOKING As New ClsInvestmentMaster
            OBJBOOKING.alParaval.Add(TEMPINVESTMENTNO)
            'OBJBOOKING.alParaval.Add(CmpId)
            OBJBOOKING.alParaval.Add(YearId)

            Dim DTTABLE As DataTable = OBJBOOKING.Delete()
            MsgBox("Investment Deleted", MsgBoxStyle.Critical)
            edit = False
            clear()
            DTINVEDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            'gridpayment.RowCount = 0
            'gridpaydesc.RowCount = 0
            'GRIDDESC.RowCount = 0
            TEMPINVESTMENTNO = Val(tstxtbillno.Text)
            'TEMPREGNAME = cmbregister.Text.Trim
            clear()
            If TEMPINVESTMENTNO > 0 Then
                edit = True
                Investment_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTOLDCERTNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTOLDCERTNO.Validating
        Try
            'FETCH ALL THE DATA 
            If TXTOLDCERTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" INVE_DEPOSITDATE AS DEPOSITDATE, INVE_MATURITYDATE AS MATURITYDATE, INVE_AMOUNT AS AMOUNT, LEDGERS.ACC_CMPNAME AS BANKNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME ", "", " INVESTMENTMASTER INNER JOIN LEDGERS ON ACC_ID = INVE_BANKID LEFT OUTER JOIN CITYMASTER ON INVE_CITYID = CITY_ID", " AND INVE_CERTNO = '" & TXTOLDCERTNO.Text.Trim & "' AND INVE_CMPID = " & CmpId)
                If DT.Rows.Count > 0 Then
                    CMBBANK.Text = DT.Rows(0).Item("BANKNAME")
                    CMBCITY.Text = DT.Rows(0).Item("CITYNAME")
                    TXTOLDAMOUNT.Text = Val(DT.Rows(0).Item("AMOUNT"))
                    DTOLDDEPOSITDATE.Value = Convert.ToDateTime(DT.Rows(0).Item("DEPOSITDATE")).Date
                    DTOLDMATURITYDATE.Value = Convert.ToDateTime(DT.Rows(0).Item("MATURITYDATE")).Date
                    CALC()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTDIFF.Text = Val(TXTAMOUNT.Text.Trim) - Val(TXTOLDAMOUNT.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validating(sender As Object, e As CancelEventArgs) Handles TXTAMOUNT.Validating, TXTOLDAMOUNT.Validating
        CALC()
    End Sub
End Class