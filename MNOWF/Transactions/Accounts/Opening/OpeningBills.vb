
Imports System.ComponentModel
Imports BL

Public Class OpeningBills

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public edit As Boolean
    Public TEMPREGNAME As String
    Public TEMPNAME As String

    Dim regabbr, reginitial As String
    Dim regid As Integer
    Dim temprow As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        'clearing textboxes
        EP.Clear()
        txtopening.Clear()
        lbldrcropening.Text = ""
        CMBNAME.Text = ""
        CMBACCCODE.Text = ""
        GRIDOPENING.RowCount = 0
        LBLTOTAL.Text = 0.0

        TXTSRNO.Text = GRIDOPENING.RowCount + 1
        CMBTYPE.SelectedIndex = 0
        TXTBILLNO.Clear()
        TXTREQNO.Clear()
        CMBOFFICER.Text = ""
        CMBCATEGORY.Text = ""
        CMBPATIENT.Text = ""
        TXTCLAIMAMT.Clear()
        CMBCLAIMTYPE.SelectedIndex = 0

        TXTBANK.Clear()
        TXTBRANCH.Clear()
        TXTACNAME.Clear()
        TXTACNO.Clear()
        TXTIFSCCODE.Clear()
        TXTDIAGNOSIS.Clear()
        TXTHOSPNAME.Clear()
        TXTHOSPADD.Clear()
        CMBCOURSE.Text = ""
        CMBCOURSEYEAR.Text = ""
        TXTINSTNAME.Clear()
        TXTUNINAME.Clear()
        CMBVESSEL.Text = ""

        TXTYEAR.Clear()
        BILLDATE.Value = Mydate
        TXTAMT.Clear()


        regabbr = ""
        reginitial = ""


        CMBNAME.Enabled = True
        CMBACCCODE.Enabled = True

        edit = False
        GRIDDOUBLECLICK = False

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')  and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress, TXTCLAIMAMT.KeyPress
        numdotkeypress(e, TXTAMT, Me)
    End Sub

    Private Sub txtBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBILLNO.KeyPress, TXTREQNO.KeyPress
        numkeypress(e, TXTBILLNO, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Name")
                BLN = False
            End If

            If GRIDOPENING.RowCount = 0 Then
                EP.SetError(TXTAMT, "Enter Bill Details")
                BLN = False
            End If


            'CHECK WHETHER OPENINGTOTAL MATCHES WITH THE OPENING BAL IN LEDGERS
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ACC_OPBAL, ACC_DRCR", "", " LEDGERS", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'")
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows(0).Item(0)) <> Val(LBLTOTAL.Text.Trim) Then
                    MsgBox("Total Does not match in Ledgers", MsgBoxStyle.Critical)
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub OpeningBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            Call ToolStripdelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OpeningBills_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillledger(CMBNAME, edit, " and acc_YEARid = " & YearId)
            FILLOFFICER(CMBOFFICER, False, "")
            FILLCATEGORY(CMBCATEGORY, False)
            FILLFAMILY(CMBPATIENT, False)
            FILLCOURSE(CMBCOURSE, False)
            FILLCOURSEYEAR(CMBCOURSEYEAR, False)
            FILLVESSEL(CMBVESSEL, False)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY, LEDGERS.ACC_OPBAL AS OPBAL, LEDGERS.ACC_DRCR AS DRCR", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    txtopening.Text = Format(Val(DT.Rows(0).Item("OPBAL")), "0.00")
                    lbldrcropening.Text = DT.Rows(0).Item("DRCR")

                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        CMBTYPE.Text = "PURCHASE"
                    Else
                        CMBTYPE.Text = "SALE"
                    End If
                    edit = True
                End If

                CMBNAME.Enabled = False
                CMBACCCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' or groupmaster.group_SECONDARY = 'Indirect Income' or groupmaster.group_SECONDARY = 'Direct Income') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBNAME.Text.Trim <> "" Then ledgervalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If TXTBILLNO.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then
                FILLGRIDOPENING()
                'Else
                '    Call txtbillno_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDOPENING()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" OPENINGBILL.BILL_GRIDSRNO AS GRIDSRNO, OPENINGBILL.BILL_TYPE AS BILLTYPE, OPENINGBILL.BILL_NO AS BILLNO, ISNULL(OPENINGBILL.BILL_REQNO, 0) AS REQNO, ISNULL(OFFICERMASTER.OFFICER_name, '') AS OFFICER, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY, ISNULL(FAMILYMASTER.FAMILY_NAME, '') AS PATIENT, ISNULL(OPENINGBILL.BILL_CLAIMAMT, 0) AS CLAIMAMT,  ISNULL(OPENINGBILL.BILL_CLAIMTYPE, 'MEDICAL') AS CLAIMTYPE,  ISNULL(OPENINGBILL.BILL_BANKNAME, '') AS BANKNAME, ISNULL(OPENINGBILL.BILL_BRANCH, '') AS BRANCH, ISNULL(OPENINGBILL.BILL_ACNAME, '') AS ACNAME, ISNULL(OPENINGBILL.BILL_ACNO, '') AS ACNO, ISNULL(OPENINGBILL.BILL_IFSCCODE, '') AS IFSCCODE, ISNULL(OPENINGBILL.BILL_DIAGNOSIS, '') AS DIAGNOSIS, ISNULL(OPENINGBILL.BILL_HOSPNAME, '') AS HOSPNAME, ISNULL(OPENINGBILL.BILL_HOSPADD, '') AS HOSPADD, ISNULL(COURSEMASTER.COURSE_NAME, '') AS COURSENAME, ISNULL(COURSEYEARMASTER.COURSEYEAR_NAME, '') AS COURSEYEAR, ISNULL(OPENINGBILL.BILL_INSTNAME, '') AS INSTNAME, ISNULL(OPENINGBILL.BILL_UNINAME, '') AS UNINAME, OPENINGBILL.BILL_YEAR AS YEAR, OPENINGBILL.BILL_DATE AS BILLDATE, OPENINGBILL.BILL_AMT AS AMT, OPENINGBILL.BILL_AMTPAIDREC AS AMTPAIDREC, OPENINGBILL.BILL_EXTRAAMT AS EXTRAAMT, OPENINGBILL.BILL_RETURN AS [RETURN], OPENINGBILL.BILL_BALANCE AS BALANCE, ISNULL(VESSEL_NAME,'') AS VESSEL ", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN FAMILYMASTER ON OPENINGBILL.BILL_PATIENTID = FAMILYMASTER.FAMILY_ID LEFT OUTER JOIN CATEGORYMASTER ON OPENINGBILL.BILL_CATEGORYID = CATEGORYMASTER.CATEGORY_ID LEFT OUTER JOIN OFFICERMASTER ON OPENINGBILL.BILL_OFFICERID = OFFICERMASTER.OFFICER_id LEFT OUTER JOIN COURSEYEARMASTER ON OPENINGBILL.BILL_COURSEYEARID = COURSEYEARMASTER.COURSEYEAR_ID LEFT OUTER JOIN COURSEMASTER ON OPENINGBILL.BILL_COURSEID = COURSEMASTER.COURSE_ID LEFT OUTER JOIN VESSELMASTER ON OPENINGBILL.BILL_VESSELID = VESSEL_ID", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    GRIDOPENING.Rows.Add(ROW("GRIDSRNO"), ROW("BILLTYPE"), Val(ROW("BILLNO")), Val(ROW("REQNO")), ROW("OFFICER"), ROW("CATEGORY"), ROW("PATIENT"), Val(ROW("CLAIMAMT")), ROW("CLAIMTYPE"), ROW("BANKNAME"), ROW("BRANCH"), ROW("ACNAME"), ROW("ACNO"), ROW("IFSCCODE"), ROW("DIAGNOSIS"), ROW("HOSPNAME"), ROW("HOSPADD"), ROW("COURSENAME"), ROW("COURSEYEAR"), ROW("INSTNAME"), ROW("UNINAME"), ROW("VESSEL"), ROW("YEAR"), Format(Convert.ToDateTime(ROW("BILLDATE")).Date, "dd/MM/yyyy"), Format(Val(ROW("AMT")), "0.00"), Format(Val(ROW("AMTPAIDREC")), "0.00"), Format(Val(ROW("EXTRAAMT")), "0.00"), Format(Val(ROW("RETURN")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"))
                    If Val(ROW("AMTPAIDREC")) > 0 Then GRIDOPENING.Rows(GRIDOPENING.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim INTRESULT As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(CMBNAME.Text.Trim)
            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim TYPE As String = ""
            Dim BILLNO As String = ""
            Dim REQNO As String = ""
            Dim OFFICER As String = ""
            Dim CATEGORY As String = ""
            Dim PATIENT As String = ""
            Dim CLAIMAMT As String = ""
            Dim CLAIMTYPE As String = ""
            Dim BANKNAME As String = ""
            Dim BRANCH As String = ""
            Dim ACNAME As String = ""
            Dim ACNO As String = ""
            Dim IFSCCODE As String = ""
            Dim DIAGNOSIS As String = ""
            Dim HOSPNAME As String = ""
            Dim HOSPADD As String = ""
            Dim COURSENAME As String = ""
            Dim COURSEYEAR As String = ""
            Dim INSTNAME As String = ""
            Dim UNINAME As String = ""
            Dim VESSEL As String = ""
            Dim YEAR As String = ""
            Dim BILLDATE As String = ""
            Dim AMT As String = ""
            Dim AMTPAIDREC As String = ""
            Dim EXTRAAMT As String = ""
            Dim [RETURN] As String = ""
            Dim BALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDOPENING.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        TYPE = row.Cells(GBILLTYPE.Index).Value
                        BILLNO = Val(row.Cells(GBILLNO.Index).Value)
                        REQNO = Val(row.Cells(GBILLNO.Index).Value)
                        OFFICER = row.Cells(GBILLNO.Index).Value.ToString
                        CATEGORY = row.Cells(GBILLNO.Index).Value.ToString
                        PATIENT = row.Cells(GBILLNO.Index).Value.ToString
                        CLAIMAMT = Val(row.Cells(GBILLNO.Index).Value)
                        CLAIMTYPE = row.Cells(GCLAIMTYPE.Index).Value

                        BANKNAME = row.Cells(GBANK.Index).Value
                        BRANCH = row.Cells(GBRANCH.Index).Value
                        ACNAME = row.Cells(GACNAME.Index).Value
                        ACNO = row.Cells(GACNO.Index).Value
                        IFSCCODE = row.Cells(GIFSCCODE.Index).Value
                        DIAGNOSIS = row.Cells(GDIAGNOSIS.Index).Value
                        HOSPNAME = row.Cells(GHOSPNAME.Index).Value
                        HOSPADD = row.Cells(GHOSPADD.Index).Value
                        COURSENAME = row.Cells(GCOURSENAME.Index).Value
                        COURSEYEAR = row.Cells(GCOURSEYEAR.Index).Value
                        INSTNAME = row.Cells(GINSTNAME.Index).Value
                        UNINAME = row.Cells(GUNINAME.Index).Value
                        VESSEL = row.Cells(GVESSEL.Index).Value

                        YEAR = row.Cells(GYEAR.Index).Value
                        BILLDATE = Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        AMT = Val(row.Cells(GAMT.Index).Value)
                        AMTPAIDREC = Val(row.Cells(GAMTPAIDREC.Index).Value)
                        EXTRAAMT = Val(row.Cells(GEXTRAAMT.Index).Value)
                        [RETURN] = Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = Val(row.Cells(GBALANCE.Index).Value)
                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                        TYPE = TYPE & "|" & row.Cells(GBILLTYPE.Index).Value
                        BILLNO = BILLNO & "|" & Val(row.Cells(GBILLNO.Index).Value)
                        REQNO = REQNO & "|" & Val(row.Cells(GBILLNO.Index).Value)
                        OFFICER = OFFICER & "|" & row.Cells(GBILLNO.Index).Value.ToString
                        CATEGORY = CATEGORY & "|" & row.Cells(GBILLNO.Index).Value.ToString
                        PATIENT = PATIENT & "|" & row.Cells(GBILLNO.Index).Value.ToString
                        CLAIMAMT = CLAIMAMT & "|" & Val(row.Cells(GBILLNO.Index).Value)
                        CLAIMTYPE = CLAIMTYPE & "|" & row.Cells(GCLAIMTYPE.Index).Value

                        BANKNAME = BANKNAME & "|" & row.Cells(GBANK.Index).Value
                        BRANCH = BRANCH & "|" & row.Cells(GBRANCH.Index).Value
                        ACNAME = ACNAME & "|" & row.Cells(GACNAME.Index).Value
                        ACNO = ACNO & "|" & row.Cells(GACNO.Index).Value
                        IFSCCODE = IFSCCODE & "|" & row.Cells(GIFSCCODE.Index).Value
                        DIAGNOSIS = DIAGNOSIS & "|" & row.Cells(GDIAGNOSIS.Index).Value
                        HOSPNAME = HOSPNAME & "|" & row.Cells(GHOSPNAME.Index).Value
                        HOSPADD = HOSPADD & "|" & row.Cells(GHOSPADD.Index).Value
                        COURSENAME = COURSENAME & "|" & row.Cells(GCOURSENAME.Index).Value
                        COURSEYEAR = COURSEYEAR & "|" & row.Cells(GCOURSEYEAR.Index).Value
                        INSTNAME = INSTNAME & "|" & row.Cells(GINSTNAME.Index).Value
                        UNINAME = UNINAME & "|" & row.Cells(GUNINAME.Index).Value
                        VESSEL = VESSEL & "|" & row.Cells(GVESSEL.Index).Value

                        YEAR = YEAR & "|" & row.Cells(GYEAR.Index).Value
                        BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        AMT = AMT & "|" & Val(row.Cells(GAMT.Index).Value)
                        AMTPAIDREC = AMTPAIDREC & "|" & Val(row.Cells(GAMTPAIDREC.Index).Value)
                        EXTRAAMT = EXTRAAMT & "|" & Val(row.Cells(GEXTRAAMT.Index).Value)
                        [RETURN] = [RETURN] & "|" & Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = BALANCE & "|" & Val(row.Cells(GBALANCE.Index).Value)

                    End If
                End If
            Next


            alparaval.Add(GRIDSRNO)
            alparaval.Add(TYPE)
            alparaval.Add(BILLNO)
            alparaval.Add(REQNO)
            alparaval.Add(OFFICER)
            alparaval.Add(CATEGORY)
            alparaval.Add(PATIENT)
            alparaval.Add(CLAIMAMT)
            alparaval.Add(CLAIMTYPE)

            alparaval.Add(BANKNAME)
            alparaval.Add(BRANCH)
            alparaval.Add(ACNAME)
            alparaval.Add(ACNO)
            alparaval.Add(IFSCCODE)
            alparaval.Add(DIAGNOSIS)
            alparaval.Add(HOSPNAME)
            alparaval.Add(HOSPADD)
            alparaval.Add(COURSENAME)
            alparaval.Add(COURSEYEAR)
            alparaval.Add(INSTNAME)
            alparaval.Add(UNINAME)
            alparaval.Add(VESSEL)

            alparaval.Add(YEAR)
            alparaval.Add(BILLDATE)
            alparaval.Add(AMT)
            alparaval.Add(AMTPAIDREC)
            alparaval.Add(EXTRAAMT)
            alparaval.Add([RETURN])
            alparaval.Add(BALANCE)


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CODE = '" & CMBACCCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                    alparaval.Add("PURCHASE REGISTER")
                    alparaval.Add("PURCHASE")
                Else
                    alparaval.Add("SALE REGISTER")
                    alparaval.Add("SALE")
                End If
            End If


            Dim OBJOPENING As New ClsOpening
            OBJOPENING.alParaval = alparaval

            'If edit = False Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            INTRESULT = OBJOPENING.save()
            MessageBox.Show("Details Added")

            'End If
            clear()
            edit = False
            CMBNAME.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        LBLTOTAL.Text = 0.0
        For Each row As DataGridViewRow In GRIDOPENING.Rows
            LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) + row.Cells(GAMT.Index).Value, "0.00")
        Next
    End Sub

    Sub FILLGRID()
        Try
            For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                If (GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And temprow <> ROW.Index) Then
                    If Val(ROW.Cells(GBILLNO.Index).Value) = Val(TXTBILLNO.Text.Trim) And ROW.Cells(GYEAR.Index).Value = TXTYEAR.Text.Trim Then
                        MsgBox("Bill No Already Present in Grid below", MsgBoxStyle.Critical)
                        TXTSRNO.Focus()
                        Exit Sub
                    End If
                End If
            Next

            If GRIDDOUBLECLICK = False Then
                GRIDOPENING.Rows.Add(TXTSRNO.Text.Trim, CMBTYPE.Text.Trim, Val(TXTBILLNO.Text.Trim), Val(TXTREQNO.Text.Trim), CMBOFFICER.Text.Trim, CMBCATEGORY.Text.Trim, CMBPATIENT.Text.Trim, Val(TXTCLAIMAMT.Text.Trim), CMBCLAIMTYPE.Text.Trim, TXTBANK.Text.Trim, TXTBRANCH.Text.Trim, TXTACNAME.Text.Trim, TXTACNO.Text.Trim, TXTIFSCCODE.Text.Trim, TXTDIAGNOSIS.Text.Trim, TXTHOSPNAME.Text.Trim, TXTHOSPADD.Text.Trim, CMBCOURSE.Text.Trim, CMBCOURSEYEAR.Text.Trim, TXTINSTNAME.Text.Trim, TXTUNINAME.Text.Trim, CMBVESSEL.Text.Trim, TXTYEAR.Text.Trim, Format(BILLDATE.Value.Date, "dd/MM/yyyy"), Val(TXTAMT.Text.Trim), 0, 0, 0, 0)
                getsrno(GRIDOPENING)
            Else
                GRIDOPENING.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
                GRIDOPENING.Item(GBILLTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
                GRIDOPENING.Item(GBILLNO.Index, temprow).Value = Val(TXTBILLNO.Text.Trim)
                GRIDOPENING.Item(GREQNO.Index, temprow).Value = Val(TXTREQNO.Text.Trim)
                GRIDOPENING.Item(GOFFNAME.Index, temprow).Value = CMBOFFICER.Text.Trim
                GRIDOPENING.Item(GCATEGORY.Index, temprow).Value = CMBCATEGORY.Text.Trim
                GRIDOPENING.Item(GPATIENT.Index, temprow).Value = CMBPATIENT.Text.Trim
                GRIDOPENING.Item(GCLAIMEDAMT.Index, temprow).Value = Val(TXTCLAIMAMT.Text.Trim)
                GRIDOPENING.Item(GCLAIMTYPE.Index, temprow).Value = CMBCLAIMTYPE.Text.Trim

                GRIDOPENING.Item(GBANK.Index, temprow).Value = TXTBANK.Text.Trim
                GRIDOPENING.Item(GBRANCH.Index, temprow).Value = TXTBRANCH.Text.Trim
                GRIDOPENING.Item(GACNAME.Index, temprow).Value = TXTACNAME.Text.Trim
                GRIDOPENING.Item(GACNO.Index, temprow).Value = TXTACNO.Text.Trim
                GRIDOPENING.Item(GIFSCCODE.Index, temprow).Value = TXTIFSCCODE.Text.Trim
                GRIDOPENING.Item(GDIAGNOSIS.Index, temprow).Value = TXTDIAGNOSIS.Text.Trim
                GRIDOPENING.Item(GHOSPNAME.Index, temprow).Value = TXTHOSPNAME.Text.Trim
                GRIDOPENING.Item(GHOSPADD.Index, temprow).Value = TXTHOSPADD.Text.Trim
                GRIDOPENING.Item(GCOURSENAME.Index, temprow).Value = CMBCOURSE.Text.Trim
                GRIDOPENING.Item(GCOURSEYEAR.Index, temprow).Value = CMBCOURSEYEAR.Text.Trim
                GRIDOPENING.Item(GINSTNAME.Index, temprow).Value = TXTINSTNAME.Text.Trim
                GRIDOPENING.Item(GUNINAME.Index, temprow).Value = TXTUNINAME.Text.Trim
                GRIDOPENING.Item(GVESSEL.Index, temprow).Value = CMBVESSEL.Text.Trim

                GRIDOPENING.Item(GYEAR.Index, temprow).Value = TXTYEAR.Text.Trim
                GRIDOPENING.Item(GBILLDATE.Index, temprow).Value = Format(BILLDATE.Value.Date, "dd/MM/yyyy")
                GRIDOPENING.Item(GAMT.Index, temprow).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If
            total()

            GRIDOPENING.FirstDisplayedScrollingRowIndex = GRIDOPENING.RowCount - 1

            TXTSRNO.Clear()
            TXTBILLNO.Clear()
            TXTREQNO.Clear()
            CMBOFFICER.Text = ""
            CMBCATEGORY.Text = ""
            CMBPATIENT.Text = ""
            TXTCLAIMAMT.Clear()

            TXTBANK.Clear()
            TXTBRANCH.Clear()
            TXTACNAME.Clear()
            TXTACNO.Clear()
            TXTIFSCCODE.Clear()
            TXTDIAGNOSIS.Clear()
            TXTHOSPNAME.Clear()
            TXTHOSPADD.Clear()
            CMBCOURSE.Text = ""
            CMBCOURSEYEAR.Text = ""
            TXTINSTNAME.Clear()
            TXTUNINAME.Clear()
            CMBVESSEL.Text = ""

            TXTYEAR.Clear()
            BILLDATE.Value = Mydate
            TXTAMT.Clear()
            TXTSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDOPENING.CellDoubleClick
        Try

            If Val(GRIDOPENING.Rows(e.RowIndex).Cells(GAMTPAIDREC.Index).Value) > 0 Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If e.RowIndex >= 0 And GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDOPENING.Item(GBILLTYPE.Index, e.RowIndex).Value.ToString
                TXTBILLNO.Text = Val(GRIDOPENING.Item(GBILLNO.Index, e.RowIndex).Value)
                TXTREQNO.Text = Val(GRIDOPENING.Item(GREQNO.Index, e.RowIndex).Value)
                CMBOFFICER.Text = GRIDOPENING.Item(GOFFNAME.Index, e.RowIndex).Value.ToString
                CMBCATEGORY.Text = GRIDOPENING.Item(GCATEGORY.Index, e.RowIndex).Value.ToString
                CMBPATIENT.Text = GRIDOPENING.Item(GPATIENT.Index, e.RowIndex).Value.ToString
                TXTCLAIMAMT.Text = Val(GRIDOPENING.Item(GCLAIMEDAMT.Index, e.RowIndex).Value)
                CMBCLAIMTYPE.Text = GRIDOPENING.Item(GCLAIMTYPE.Index, e.RowIndex).Value.ToString

                TXTBANK.Text = GRIDOPENING.Item(GBANK.Index, e.RowIndex).Value.ToString
                TXTBRANCH.Text = GRIDOPENING.Item(GBRANCH.Index, e.RowIndex).Value.ToString
                TXTACNAME.Text = GRIDOPENING.Item(GACNAME.Index, e.RowIndex).Value.ToString
                TXTACNO.Text = GRIDOPENING.Item(GACNO.Index, e.RowIndex).Value.ToString
                TXTIFSCCODE.Text = GRIDOPENING.Item(GIFSCCODE.Index, e.RowIndex).Value.ToString
                TXTDIAGNOSIS.Text = GRIDOPENING.Item(GDIAGNOSIS.Index, e.RowIndex).Value.ToString
                TXTHOSPNAME.Text = GRIDOPENING.Item(GHOSPNAME.Index, e.RowIndex).Value.ToString
                TXTHOSPADD.Text = GRIDOPENING.Item(GHOSPADD.Index, e.RowIndex).Value.ToString
                CMBCOURSE.Text = GRIDOPENING.Item(GCOURSENAME.Index, e.RowIndex).Value.ToString
                CMBCOURSEYEAR.Text = GRIDOPENING.Item(GCOURSEYEAR.Index, e.RowIndex).Value.ToString
                TXTINSTNAME.Text = GRIDOPENING.Item(GINSTNAME.Index, e.RowIndex).Value.ToString
                TXTUNINAME.Text = GRIDOPENING.Item(GUNINAME.Index, e.RowIndex).Value.ToString
                CMBVESSEL.Text = GRIDOPENING.Item(GVESSEL.Index, e.RowIndex).Value.ToString

                TXTYEAR.Text = GRIDOPENING.Item(GYEAR.Index, e.RowIndex).Value.ToString
                BILLDATE.Value = Convert.ToDateTime(GRIDOPENING.Item(GBILLDATE.Index, e.RowIndex).Value).Date
                TXTAMT.Text = Val(GRIDOPENING.Item(GAMT.Index, e.RowIndex).Value)

                temprow = e.RowIndex
                CMBTYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDOPENING.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            'if REC/PAYMERNT IS MADE THEN DONT ALLOW TO DELETE
            If Val(GRIDOPENING.Rows(GRIDOPENING.CurrentRow.Index).Cells(GAMTPAIDREC.Index).Value) > 0 Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete Bill No " & GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBNAME.Text.Trim)
                    ALPARAVAL.Add(GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJOP.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJOP.DELETE

                    GRIDOPENING.Rows.RemoveAt(GRIDOPENING.CurrentRow.Index)
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If

        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Enabled = True
        CMBNAME.Focus()
    End Sub

    Private Sub txtamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            If TXTSRNO.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)
            If TXTSRNO.Text.Trim.Length > 0 And Val(TXTAMT.Text) > 0 And Val(TXTBILLNO.Text.Trim) > 0 And Val(TXTREQNO.Text.Trim) > 0 And CMBOFFICER.Text.Trim <> "" And CMBCATEGORY.Text.Trim <> "" And CMBPATIENT.Text.Trim <> "" And TXTYEAR.Text.Trim <> "" And CMBTYPE.Text <> "" Then
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        TXTSRNO.Text = GRIDOPENING.RowCount + 1
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete All Bills of " & CMBNAME.Text.Trim, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening

                    For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(CMBNAME.Text.Trim)
                        ALPARAVAL.Add(ROW.Cells(GBILLNO.Index).Value)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJOP.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJOP.DELETE

                    Next
                    clear()
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJOP As New OpeningBillDetails
            OBJOP.MdiParent = MDIMain
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub OpeningBills_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If TEMPNAME <> "" Then
                CMBNAME.Text = TEMPNAME
                cmbname_Validated(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOFFICER.Enter
        Try
            If CMBOFFICER.Text.Trim = "" Then FILLOFFICER(CMBOFFICER, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOFFICER.Validating
        Try
            If CMBOFFICER.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICER, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPATIENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPATIENT.Enter
        Try
            If CMBPATIENT.Text.Trim = "" Then FILLFAMILY(CMBPATIENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPATIENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPATIENT.Validating
        Try
            If CMBPATIENT.Text.Trim <> "" Then FAMILYVALIDATE(CMBPATIENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOURSE.Enter
        Try
            If CMBCOURSE.Text.Trim = "" Then FILLCOURSE(CMBCOURSE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOURSE.Validating
        Try
            If CMBCOURSE.Text.Trim <> "" Then COURSEVALIDATE(CMBCOURSE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSEYEAR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOURSEYEAR.Enter
        Try
            If CMBCOURSEYEAR.Text.Trim = "" Then FILLCOURSEYEAR(CMBCOURSEYEAR, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOURSEYEAR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOURSEYEAR.Validating
        Try
            If CMBCOURSEYEAR.Text.Trim <> "" Then COURSEYEARVALIDATE(CMBCOURSEYEAR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVESSEL_Enter(sender As Object, e As EventArgs) Handles CMBVESSEL.Enter
        Try
            If CMBVESSEL.Text.Trim = "" Then FILLVESSEL(CMBVESSEL, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVESSEL_Validating(sender As Object, e As CancelEventArgs) Handles CMBVESSEL.Validating
        Try
            If CMBVESSEL.Text.Trim <> "" Then VESSELVALIDATE(CMBVESSEL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class