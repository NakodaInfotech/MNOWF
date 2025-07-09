
Imports BL
Imports System.Windows.Forms

Public Class OfficerDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub OfficerDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OfficerDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OFFICER MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillgridname()
        Dim dttable As New DataTable
        Dim OBJOFFICER As New ClsOfficerMaster
        OBJOFFICER.alParaval.Add("")
        OBJOFFICER.alParaval.Add(CmpId)
        OBJOFFICER.alParaval.Add(Locationid)
        OBJOFFICER.alParaval.Add(YearId)
        dttable = OBJOFFICER.GETOFFICER
        If dttable.Rows.Count > 0 Then
            gridname.DataSource = dttable
            gridledger.Columns(0).Width = 180
            gridledger.Columns(1).Width = 100
            gridledger.Columns(2).Width = 150
        End If
    End Sub

    Sub getdetails(ByRef name As String)
        If name <> Nothing Then
            Dim dttable As New DataTable
            Dim OBJOFFICER As New ClsOfficerMaster
            OBJOFFICER.alParaval.Add(name)
            OBJOFFICER.alParaval.Add(CmpId)
            OBJOFFICER.alParaval.Add(Locationid)
            OBJOFFICER.alParaval.Add(YearId)
            dttable = OBJOFFICER.GETOFFICER

            cleartextbox()

            If dttable.Rows.Count > 0 Then
                For Each ROW As DataRow In dttable.Rows
                    TXTOFFICERNO.Text = ROW("OFFICERID")
                    TXTNAME.Text = ROW("NAME")
                    TXTRANK.Text = ROW("RANK")
                    TXTCMPNAME.Text = ROW("COMPANY")
                    TXTEMPCODE.Text = ROW("EMPCODE")

                    DOJ.Text = Convert.ToDateTime(ROW("DOJ")).Date
                    DECDATE.Text = Convert.ToDateTime(ROW("DECDATE")).Date

                    CHKINDIAN.Checked = Convert.ToBoolean(ROW("INDIAN"))
                    CHKCONTRACT.Checked = Convert.ToBoolean(ROW("CONTRACT"))
                    CHKCONTRIBUTION.Checked = Convert.ToBoolean(ROW("CONTRIBUTION"))
                    CHKDONATION.Checked = Convert.ToBoolean(ROW("DONATION"))

                    txtstd.Text = ROW("STD")
                    txtmobile.Text = ROW("MOBILE")
                    txtfax.Text = ROW("FAX")
                    TXTRESINO.Text = ROW("RESINO")
                    TXTMUINO.Text = ROW("MUINO")
                    txtemail.Text = ROW("EMAIL")

                    TXTSERVICE.Text = ROW("SERVICE")
                    txtadd.Text = ROW("ADD")
                    TXTREMARKS.Text = ROW("REMARKS")

                    If IsDBNull(ROW("SRNO")) = False Then GRIDFAMILY.Rows.Add(ROW("SRNO"), ROW("FAMILY"), Format(Convert.ToDateTime(ROW("DOB")).Date, "dd/MM/yyyy"), ROW("AGE"), ROW("RELATION"))
                Next

            End If
        End If
    End Sub

    Sub cleartextbox()

        TXTOFFICERNO.Clear()
        TXTNAME.Clear()
        TXTRANK.Clear()
        TXTCMPNAME.Clear()
        TXTEMPCODE.Clear()

        DOJ.Value = Mydate
        DECDATE.Value = Mydate
        CHKINDIAN.CheckState = CheckState.Checked
        CHKCONTRIBUTION.CheckState = CheckState.Unchecked
        CHKDONATION.CheckState = CheckState.Unchecked

        txtstd.Clear()
        TXTRESINO.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtemail.Clear()
        TXTMUINO.Clear()

        TXTSERVICE.Clear()
        TXTREMARKS.Clear()
        txtadd.Clear()


        GRIDFAMILY.RowCount = 0

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim OBJOFFICER As New OfficerMaster
                OBJOFFICER.MdiParent = MDIMain
                OBJOFFICER.edit = editval
                OBJOFFICER.TEMPOFFICERNAME = name
                OBJOFFICER.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            gettrans(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            gettrans(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub gettrans(ByRef name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim WHERE As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                WHERE = WHERE & " AND T.DATE >= '" & Format(dtfromdate.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dttodate.Value.Date, "MM/dd/yyyy") & "'"
            End If
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" T.TYPE,T.REQNO, T.CLAIMNO,T.PATIENTNAME,T.DATE,T.CLAIMEDAMT ,T.PAIDAMT, T.CHQNO, T.CHQDATE, T.YEARNAME ", "", " (SELECT 'MEDSETTLEMENT' AS TYPE, 'MED-' + CAST(MEDCLAIMSETTLEMENT.SETTLE_REQNO AS VARCHAR(20)) AS REQNO, 'MED-' + CAST(MEDCLAIMSETTLEMENT.SETTLE_NO AS VARCHAR) AS CLAIMNO, FAMILYMASTER.FAMILY_NAME AS PATIENTNAME, MEDCLAIMSETTLEMENT.SETTLE_DATE AS DATE, MEDCLAIMSETTLEMENT.SETTLE_CLAIMEDAMT AS CLAIMEDAMT, CASE WHEN MEDCLAIMSETTLEMENT.SETTLE_AMTPAID <> 0 THEN MEDCLAIMSETTLEMENT.SETTLE_AMTPAID ELSE OPENINGBILL.BILL_AMTPAIDREC END AS PAIDAMT, (CASE WHEN ISNULL(PAYMENTMASTER.PAYMENT_CHQNO, '') <> '' THEN ISNULL(PAYMENTMASTER.PAYMENT_CHQNO, '') ELSE ISNULL(OPPAYMENTMASTER.PAYMENT_CHQNO, '') END) AS CHQNO, CASE WHEN OPPAYMENTMASTER.PAYMENT_date IS NOT NULL THEN OPPAYMENTMASTER.PAYMENT_date ELSE PAYMENTMASTER.PAYMENT_date END AS CHQDATE, CAST(YEAR(YEARMASTER.year_startdate) AS VARCHAR) + ' - ' + CAST(YEAR(YEARMASTER.year_enddate) AS VARCHAR) AS YEARNAME FROM PAYMENTMASTER_DESC INNER JOIN PAYMENTMASTER ON PAYMENTMASTER_DESC.PAYMENT_no = PAYMENTMASTER.PAYMENT_no AND PAYMENTMASTER_DESC.PAYMENT_yearid = PAYMENTMASTER.PAYMENT_yearid RIGHT OUTER JOIN OPENINGBILL INNER JOIN PAYMENTMASTER_DESC AS OPPAYMENTMASTER_DESC INNER JOIN PAYMENTMASTER AS OPPAYMENTMASTER ON OPPAYMENTMASTER_DESC.PAYMENT_no = OPPAYMENTMASTER.PAYMENT_no AND OPPAYMENTMASTER_DESC.PAYMENT_registerid = OPPAYMENTMASTER.PAYMENT_registerid AND OPPAYMENTMASTER_DESC.PAYMENT_yearid = OPPAYMENTMASTER.PAYMENT_yearid ON OPENINGBILL.BILL_INITIALS = OPPAYMENTMASTER_DESC.PAYMENT_BILLINITIALS AND OPENINGBILL.BILL_LEDGERID = OPPAYMENTMASTER.PAYMENT_ledgerid AND OPENINGBILL.BILL_YEARID = OPPAYMENTMASTER_DESC.PAYMENT_yearid RIGHT OUTER JOIN MEDCLAIMSETTLEMENT INNER JOIN OFFICERMASTER ON MEDCLAIMSETTLEMENT.SETTLE_OFFICERID = OFFICERMASTER.OFFICER_id INNER JOIN YEARMASTER ON YEARMASTER.year_id = MEDCLAIMSETTLEMENT.SETTLE_YEARID INNER JOIN FAMILYMASTER ON MEDCLAIMSETTLEMENT.SETTLE_FAMILYID = FAMILYMASTER.FAMILY_ID ON OPENINGBILL.BILL_REQNO = MEDCLAIMSETTLEMENT.SETTLE_REQNO AND OPENINGBILL.BILL_NO = MEDCLAIMSETTLEMENT.SETTLE_NO ON PAYMENTMASTER.PAYMENT_ledgerid = MEDCLAIMSETTLEMENT.SETTLE_LEDGERID AND PAYMENTMASTER_DESC.PAYMENT_yearid = MEDCLAIMSETTLEMENT.SETTLE_YEARID AND PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS = MEDCLAIMSETTLEMENT.SETTLE_INITIALS WHERE (OFFICERMASTER.OFFICER_name = '" & name & "') UNION ALL SELECT 'MEDREQ' AS TYPE, 'MED-' + CAST(dbo.MEDCLAIMREQ.REQ_NO AS VARCHAR) AS REQNO, '' AS CLAIMNO, FAMILYMASTER.FAMILY_NAME AS PATIENTNAME, dbo.MEDCLAIMREQ.REQ_DATE AS DATE, dbo.MEDCLAIMREQ.REQ_CLAIMEDAMT AS CLAIMEDAMT, 0 AS PAIDAMT, '' AS CHQNO, NULL AS CHQDATE,  CAST(YEAR(year_startdate) AS VARCHAR)  + ' - ' + CAST(YEAR(year_enddate) AS VARCHAR)  AS YEARNAME   FROM dbo.MEDCLAIMREQ INNER JOIN dbo.OFFICERMASTER ON dbo.MEDCLAIMREQ.REQ_OFFICERID = dbo.OFFICERMASTER.OFFICER_id AND  dbo.MEDCLAIMREQ.REQ_CMPID = dbo.OFFICERMASTER.OFFICER_cmpid AND dbo.MEDCLAIMREQ.REQ_LOCATIONID = dbo.OFFICERMASTER.OFFICER_locationid And dbo.MEDCLAIMREQ.REQ_YEARID = dbo.OFFICERMASTER.OFFICER_yearid INNER JOIN YEARMASTER ON year_id = REQ_YEARID INNER JOIN FAMILYMASTER ON MEDCLAIMREQ.REQ_FAMILYID = FAMILYMASTER.FAMILY_ID AND MEDCLAIMREQ.REQ_CMPID = FAMILYMASTER.FAMILY_CMPID AND MEDCLAIMREQ.REQ_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND MEDCLAIMREQ.REQ_YEARID = FAMILYMASTER.FAMILY_YEARID  WHERE OFFICER_NAME = '" & name & "'  UNION ALL SELECT 'EDUREQ' AS TYPE, 'EDU-' + CAST(dbo.EDUCLAIMREQ.REQ_NO AS VARCHAR) AS REQNO, '' AS CLAIMNO, FAMILYMASTER.FAMILY_NAME AS PATIENTNAME,  dbo.EDUCLAIMREQ.REQ_DATE AS DATE, dbo.EDUCLAIMREQ.REQ_CLAIMEDAMT AS CLAIEDUAMT, 0 AS PAIDAMT, '' AS CHQNO, NULL AS CHQDATE, CAST(YEAR(year_startdate) AS VARCHAR)  + ' - ' + CAST(YEAR(year_enddate) AS VARCHAR)  AS YEARNAME   FROM  dbo.EDUCLAIMREQ INNER JOIN dbo.OFFICERMASTER ON dbo.EDUCLAIMREQ.REQ_OFFICERID = dbo.OFFICERMASTER.OFFICER_id AND dbo.EDUCLAIMREQ.REQ_CMPID = dbo.OFFICERMASTER.OFFICER_cmpid AND dbo.EDUCLAIMREQ.REQ_LOCATIONID = dbo.OFFICERMASTER.OFFICER_locationid And dbo.EDUCLAIMREQ.REQ_YEARID = dbo.OFFICERMASTER.OFFICER_yearid INNER JOIN YEARMASTER ON year_id = REQ_YEARID INNER JOIN FAMILYMASTER ON EDUCLAIMREQ.REQ_FAMILYID = FAMILYMASTER.FAMILY_ID AND EDUCLAIMREQ.REQ_CMPID = FAMILYMASTER.FAMILY_CMPID AND EDUCLAIMREQ.REQ_LOCATIONID = FAMILYMASTER.FAMILY_LOCATIONID AND EDUCLAIMREQ.REQ_YEARID = FAMILYMASTER.FAMILY_YEARID  WHERE OFFICER_NAME = '" & name & "' UNION ALL SELECT     'EDUSETTLEMENT' AS TYPE, 'EDU-' + CAST(EDUCLAIMSETTLEMENT.SETTLE_REQNO AS VARCHAR(20)) AS REQNO, 'EDU-' + CAST(EDUCLAIMSETTLEMENT.SETTLE_NO AS VARCHAR) AS CLAIMNO, FAMILYMASTER.FAMILY_NAME AS PATIENTNAME, EDUCLAIMSETTLEMENT.SETTLE_DATE AS DATE, EDUCLAIMSETTLEMENT.SETTLE_CLAIMEDAMT AS CLAIMEDAMT, case WHEN EDUCLAIMSETTLEMENT.SETTLE_AMTPAID <> 0 THEN EDUCLAIMSETTLEMENT.SETTLE_AMTPAID ELSE OPENINGBILL.BILL_AMTPAIDREC END AS PAIDAMT, CASE WHEN ISNULL(PAYMENTMASTER.PAYMENT_CHQNO, '') <> '' THEN ISNULL(PAYMENTMASTER.PAYMENT_CHQNO, '') ELSE ISNULL(OPPAYMENTMASTER.PAYMENT_CHQNO, '') END AS CHQNO, CASE WHEN OPPAYMENTMASTER.PAYMENT_date IS NOT NULL THEN OPPAYMENTMASTER.PAYMENT_date ELSE PAYMENTMASTER.PAYMENT_date END AS CHQDATE, CAST(YEAR(YEARMASTER.year_startdate) AS VARCHAR) + ' - ' + CAST(YEAR(YEARMASTER.year_enddate) AS VARCHAR) AS YEARNAME FROM OPENINGBILL LEFT OUTER JOIN PAYMENTMASTER AS OPPAYMENTMASTER LEFT OUTER JOIN PAYMENTMASTER_DESC AS OPPAYMENTMASTER_DESC ON OPPAYMENTMASTER.PAYMENT_no = OPPAYMENTMASTER_DESC.PAYMENT_no AND OPPAYMENTMASTER.PAYMENT_registerid = OPPAYMENTMASTER_DESC.PAYMENT_registerid AND OPPAYMENTMASTER.PAYMENT_yearid = OPPAYMENTMASTER_DESC.PAYMENT_yearid ON OPENINGBILL.BILL_LEDGERID = OPPAYMENTMASTER.PAYMENT_ledgerid AND OPENINGBILL.BILL_INITIALS = OPPAYMENTMASTER_DESC.PAYMENT_BILLINITIALS AND OPENINGBILL.BILL_YEARID = OPPAYMENTMASTER_DESC.PAYMENT_yearid RIGHT OUTER JOIN PAYMENTMASTER_DESC INNER JOIN PAYMENTMASTER ON PAYMENTMASTER_DESC.PAYMENT_no = PAYMENTMASTER.PAYMENT_no AND PAYMENTMASTER_DESC.PAYMENT_yearid = PAYMENTMASTER.PAYMENT_yearid RIGHT OUTER JOIN EDUCLAIMSETTLEMENT INNER JOIN OFFICERMASTER ON EDUCLAIMSETTLEMENT.SETTLE_OFFICERID = OFFICERMASTER.OFFICER_id INNER JOIN YEARMASTER ON YEARMASTER.year_id = EDUCLAIMSETTLEMENT.SETTLE_YEARID INNER JOIN FAMILYMASTER ON EDUCLAIMSETTLEMENT.SETTLE_FAMILYID = FAMILYMASTER.FAMILY_ID ON PAYMENTMASTER.PAYMENT_ledgerid = EDUCLAIMSETTLEMENT.SETTLE_LEDGERID AND PAYMENTMASTER_DESC.PAYMENT_yearid = EDUCLAIMSETTLEMENT.SETTLE_YEARID AND PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS = EDUCLAIMSETTLEMENT.SETTLE_INITIALS ON OPENINGBILL.BILL_REQNO = EDUCLAIMSETTLEMENT.SETTLE_REQNO AND OPENINGBILL.BILL_NO = EDUCLAIMSETTLEMENT.SETTLE_NO WHERE (OFFICERMASTER.OFFICER_name = '" & name & "')) AS T ", WHERE & " order BY T.DATE DESC")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfromdate.Enabled = chkdate.CheckState
            dttodate.Enabled = chkdate.CheckState
            gettrans(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dttodate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dttodate.Validated
        Try
            gettrans(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXCEL.Click
        Try
            Dim OBJOFFICER As New OfficerFilter
            OBJOFFICER.MdiParent = MDIMain
            OBJOFFICER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINTHISTORY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINTHISTORY.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Officer History.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Checked Then PERIOD = dtfromdate.Value.Date & " - " & dttodate.Value.Date Else PERIOD = " Till - " & AccTo

            opti.SheetName = "Officer History"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Officer History", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class