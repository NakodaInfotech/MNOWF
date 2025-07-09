Imports BL
Imports WAProAPI

Public Class MDIMain

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITMENU.Click
        Dim TEMPMSG As Integer = MsgBox("Wish to Exit?", MsgBoxStyle.YesNo)
        If TEMPMSG = vbNo Then
            Exit Sub
        End If
        backup()
        End
    End Sub

    'Sub SCROLLERS()
    '    Try
    '        LBLCHECKIN.Left = Me.Width
    '        LBLCHECKIN.Top = StatusStrip2.Top + 2
    '        CHECKIN_CMD.Top = StatusStrip2.Top - 4

    '        Dim WHERECLAUSE As String = " AND INVE_MATURITYDATE <= '" & Format(DateAdd(DateInterval.Month, 1, Mydate), "MM/dd/yyyy") & "' AND INVE_MATURITYDATE > '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
    '        Dim CHECKINNAMES As String = "There is No Check In for Tomorrow."
    '        Dim objclsCMST As New ClsCommonMaster
    '        Dim dt As DataTable = objclsCMST.search(" INVESTMENTMASTER.INVE_NO AS INVNO, INVESTMENTMASTER.INVE_DATE AS DATE, LEDGERS.Acc_cmpname AS BANKNAME, INVESTMENTMASTER.INVE_CERTNO AS CERTNO, ISNULL(CITYMASTER.city_name,'') AS CITYNAME, INVESTMENTMASTER.INVE_DEPOSITDATE AS DEPOSITDATE, INVESTMENTMASTER.INVE_MATURITYDATE AS MATURITYDATE, INVESTMENTMASTER.INVE_AMOUNT AS AMOUNT, INVESTMENTMASTER.INVE_ROI AS ROI ", "", " INVESTMENTMASTER INNER JOIN LEDGERS ON INVESTMENTMASTER.INVE_BANKID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON INVESTMENTMASTER.INVE_CITYID = CITYMASTER.city_id  ", WHERECLAUSE & " AND INVE_YEARID  =" & YearId & " ORDER BY INVE_MATURITYDATE")
    '        If dt.Rows.Count > 0 Then
    '            CHECKINNAMES = ""
    '            For Each ROW As DataRow In dt.Rows
    '                CHECKINNAMES = CHECKINNAMES & ROW("INVNO") & " - " & ROW("BANKNAME") & "    Cert No - " & ROW("CERTNO") & "     Amt - " & Val(ROW("AMOUNT")) & "        Mat Dt. -  " & Format(Convert.ToDateTime(ROW("MATURITYDATE")).Date, "dd/MM/yyyy") & "                          "
    '            Next
    '        End If
    '        LBLCHECKIN.Text = CHECKINNAMES

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub backup()
        Try
            'TAKE BACKUP
            'Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
            'If TEMPMSG = vbYes Then

            '    'CHECKING FOR BACKUP FOLDER
            '    If FileIO.FileSystem.DirectoryExists("D:\TEXPROBACKUP") = False Then FileIO.FileSystem.CreateDirectory("D:\TEXPROBACKUP")

            '    'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
            '    If FileIO.FileSystem.FileExists("D:\TEXPROBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("D:\TEXPROBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database TEXPRO to disk='D:\TEXPROBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
            '    MsgBox("Backup Completed")
            'End If

            Try
                'TAKE BACKUP
                Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    'CHECKING FOR BACKUP FOLDER
                    If FileIO.FileSystem.DirectoryExists("C:\MNOWFBACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\MNOWFBACKUP")

                    'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
                    If FileIO.FileSystem.FileExists("C:\MNOWFBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("D:\MNOWFBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database MNOWF to disk='C:\MNOWFBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
                    MsgBox("Backup Completed")
                End If

            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Exit?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ") ------- USER : " & UCase(UserName)
        CreateUserDSN()
        GETCONN()

        'SCROLLERS()
        'BALANCESCROLLER()

        Dim objcommon As New ClsCommon
        Dim alparaval As New ArrayList
        alparaval.Add(CmpId)
        objcommon.alParaval = alparaval
        LastTransferDate = objcommon.GETTRANSFERDATE()
        'CreateUserDSN1()
        fillYEAR()
        SETENABILITY()
        If UserName = "Admin" Then
            Timer1.Enabled = True
            LBLCHECKIN.Visible = True
        Else
            Timer1.Enabled = False
            LBLCHECKIN.Visible = False
        End If
        If ALLOWWHATSAPP = True Then
            Dim BASEURL As String = GETWHATSAPPBASEURL()
            If BASEURL <> "" Then
                APIMethods.BaseURL = BASEURL
            Else
                MsgBox("Whastapp Base URL Is Missing", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Sub SETENABILITY()
        Try
            Dim objhp As New HomePage
            objhp.MdiParent = Me

            'MASTERS
            objhp.ACC_CMD.Enabled = False
            objhp.lblacccentre.Enabled = False
            objhp.HOTEL_CMD.Enabled = False
            objhp.LBLHOTEL.Enabled = False
            objhp.OFFICER_CMD.Enabled = False
            objhp.LBLOFFICER.Enabled = False

            'TRANSACTIONS
            objhp.MECLAIMREQ_CMD.Enabled = False
            objhp.LBLMEDCLAIMREQ.Enabled = False
            objhp.EDUCLAIMREQ_CMD.Enabled = False
            objhp.LBLEDUCLAIMREQ.Enabled = False
            objhp.MEDCLAIMSETTLE_CMD.Enabled = False
            objhp.LBLMEDCLAIMSETTLE.Enabled = False
            objhp.EDUCLAIMSETTLE_CMD.Enabled = False
            objhp.LBLEDUCLAIMSETTLE.Enabled = False
            objhp.REFUND_CMD.Enabled = False
            objhp.LBLREFUND.Enabled = False
            objhp.HOTELBOOKING_CMD.Enabled = False
            objhp.LBLBOOKING.Enabled = False

            'ACCOUNTS
            objhp.PAYMENT_CMD.Enabled = False
            objhp.LBLPAY.Enabled = False
            objhp.RECEIPT_CMD.Enabled = False
            objhp.LBLREC.Enabled = False
            objhp.CONTRA_CMD.Enabled = False
            objhp.LBLCONTRA.Enabled = False
            objhp.VOUCHER_CMD.Enabled = False
            objhp.LBLVOUCHER.Enabled = False
            objhp.JOURNAL_CMD.Enabled = False
            objhp.LBLJV.Enabled = False


            If UserName = "Admin" Then
                CMP_MASTER.Enabled = True
                ADMIN_MASTER.Enabled = True
                YEAR_MASTER.Enabled = True
                YEARADD.Enabled = True
                OPENINGBILL_MASTER.Enabled = True
                OPENINGBALANCE.Enabled = True
                YEARTRANSFER_MASTER.Enabled = True
            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If

            
            For Each DTROW As DataRow In USERRIGHTS.Rows

                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        objhp.ACC_CMD.Enabled = True
                        objhp.lblacccentre.Enabled = True
                    Else
                        ACCADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ACCEDIT.Enabled = True
                        objhp.ACC_CMD.Enabled = True
                        ACC_TOOL.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EMPLOYEE MASTER" Then
                    If DTROW(1).ToString = True Then
                        EMP_MASTER.Enabled = True
                        EMPADD.Enabled = True
                    Else
                        EMPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EMP_MASTER.Enabled = True
                        EMPEDIT.Enabled = True
                    Else
                        EMPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "OFFICER MASTER" Then
                    If DTROW(1).ToString = True Then
                        OFFICER_MASTER.Enabled = True
                        OFFICERADD.Enabled = True
                        objhp.OFFICER_CMD.Enabled = True
                        objhp.LBLOFFICER.Enabled = True
                        Vessel_Master.Enabled = True
                        VESSELADD.Enabled = True

                    Else
                        ACCADD.Enabled = False
                        VESSELADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OFFICER_MASTER.Enabled = True
                        OFFICEREDIT.Enabled = True
                        OFFICER_TOOL.Enabled = True
                        objhp.OFFICER_CMD.Enabled = True
                        objhp.LBLOFFICER.Enabled = True
                        Vessel_Master.Enabled = True
                        VESSELEDIT.Enabled = True
                    Else
                        OFFICEREDIT.Enabled = False
                        VESSELEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "REGISTER MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REG_MASTER.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "RANK MASTER" Then
                    If DTROW(1).ToString = True Then
                        RANK_MASTER.Enabled = True
                        RANKADD.Enabled = True
                    Else
                        RANKADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        RANK_MASTER.Enabled = True
                        RANKEDIT.Enabled = True
                    Else
                        RANKEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "COMPANY MASTER" Then
                    If DTROW(1).ToString = True Then
                        OFFCOMPANY_MASTER.Enabled = True
                        OFFCOMPANYADD.Enabled = True
                    Else
                        OFFCOMPANYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OFFCOMPANY_MASTER.Enabled = True
                        OFFCOMPANYEDIT.Enabled = True
                    Else
                        OFFCOMPANYEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "NARRATION MASTER" Then
                    If DTROW(1).ToString = True Then
                        NARRATION_MASTER.Enabled = True
                        NARRATIONADD.Enabled = True
                    Else
                        NARRATIONADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        NARRATION_MASTER.Enabled = True
                        NARRATIONEDIT.Enabled = True
                    Else
                        NARRATIONEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CATEGORY MASTER" Then
                    If DTROW(1).ToString = True Then
                        CATEGORY_MASTER.Enabled = True
                        CATEGORYCONFIGURATOR.Enabled = True
                        CATEGORYADD.Enabled = True
                    Else
                        CATEGORYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CATEGORY_MASTER.Enabled = True
                        CATEGORYEDIT.Enabled = True
                        CATEGORYCONFIGURATOR.Enabled = True
                    Else
                        CATEGORYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "COURSE MASTER" Then
                    If DTROW(1).ToString = True Then
                        COURSE_MASTER.Enabled = True
                        COURSEADD.Enabled = True
                    Else
                        CATEGORYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        COURSE_MASTER.Enabled = True
                        COURSEEDIT.Enabled = True
                    Else
                        COURSEEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "COURSEYEAR MASTER" Then
                    If DTROW(1).ToString = True Then
                        COURSEYEAR_MASTER.Enabled = True
                        COURSEYEARADD.Enabled = True
                    Else
                        COURSEYEARADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        COURSEYEAR_MASTER.Enabled = True
                        COURSEYEAREDIT.Enabled = True
                    Else
                        COURSEYEAREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DOCTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        DOCTYPE_MASTER.Enabled = True
                        DOCTYPEADD.Enabled = True
                    Else
                        DOCTYPEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DOCTYPE_MASTER.Enabled = True
                        DOCTYPEEDIT.Enabled = True
                    Else
                        DOCTYPEEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "SENTBY MASTER" Then
                    If DTROW(1).ToString = True Then
                        SENTBY_MASTER.Enabled = True
                        SENTBYADD.Enabled = True
                    Else
                        SENTBYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SENTBY_MASTER.Enabled = True
                        SENTBYEDIT.Enabled = True
                    Else
                        SENTBYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "AMENITIES MASTER" Then
                    If DTROW(1).ToString = True Then
                        AMENITIES_MASTER.Enabled = True
                        AMENITIESADD.Enabled = True
                    Else
                        AMENITIESADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        AMENITIES_MASTER.Enabled = True
                        AMENITIESEDIT.Enabled = True
                    Else
                        AMENITIESEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ROOMTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        ROOM_MASTER.Enabled = True
                        ROOMADD.Enabled = True
                    Else
                        ROOMADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ROOM_MASTER.Enabled = True
                        ROOMEDIT.Enabled = True
                    Else
                        ROOMEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HOTELTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        HOTELTYPE_MASTER.Enabled = True
                        HOTELTYPEADD.Enabled = True
                    Else
                        HOTELTYPEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOTELTYPE_MASTER.Enabled = True
                        HOTELTYPEEDIT.Enabled = True
                    Else
                        HOTELTYPEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "GROUP OF HOTELS" Then
                    If DTROW(1).ToString = True Then
                        HOTELGROUP_MASTER.Enabled = True
                        HOTELGROUPADD.Enabled = True
                    Else
                        HOTELGROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOTELGROUP_MASTER.Enabled = True
                        HOTELGROUPEDIT.Enabled = True
                    Else
                        HOTELGROUPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HOTEL MASTER" Then
                    If DTROW(1).ToString = True Then
                        HOTEL_MASTER.Enabled = True
                        HOTELADD.Enabled = True
                        objhp.HOTEL_CMD.Enabled = True
                        objhp.LBLHOTEL.Enabled = True
                    Else
                        HOTELADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOTEL_MASTER.Enabled = True
                        HOTELEDIT.Enabled = True
                        objhp.HOTEL_CMD.Enabled = True
                        objhp.LBLHOTEL.Enabled = True
                    Else
                        HOTELEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        ITEM_MASTER.Enabled = True
                        ITEMCATEGORY_MASTER.Enabled = True
                        ITEMINVENTORY_MASTER.Enabled = True
                        ITEMADD.Enabled = True
                        ITEMCATEGORYADD.Enabled = True
                        ITEMINVENTORYADD.Enabled = True
                    Else
                        ITEMADD.Enabled = False
                        ITEMCATEGORYADD.Enabled = False
                        ITEMINVENTORYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ITEM_MASTER.Enabled = True
                        ITEMCATEGORY_MASTER.Enabled = True
                        ITEMINVENTORY_MASTER.Enabled = True
                        ITEMEDIT.Enabled = True
                        ITEMCATEGORYEDIT.Enabled = True
                        ITEMINVENTORYEDIT.Enabled = True
                    Else
                        ITEMEDIT.Enabled = False
                        ITEMCATEGORYEDIT.Enabled = False
                        ITEMINVENTORYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "UNIT MASTER" Then
                    If DTROW(1).ToString = True Then
                        UNIT_MASTER.Enabled = True
                        UNITADD.Enabled = True
                    Else
                        UNITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        UNIT_MASTER.Enabled = True
                        UNITEDIT.Enabled = True
                    Else
                        UNITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "LOCATION MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        LOC_MASTER.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "TAX MASTER" Then
                    If DTROW(1).ToString = True Then
                        TAX_MASTER.Enabled = True
                        TAXADD.Enabled = True
                    Else
                        TAXADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TAX_MASTER.Enabled = True
                        TAXEDIT.Enabled = True
                    Else
                        TAXEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "OPENING" Then
                    If DTROW(1).ToString = True Then
                        OPENINGBILL_MASTER.Enabled = True
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OPENINGBILL_MASTER.Enabled = True
                    End If




                    'TRANSACTIONS
                ElseIf DTROW(0).ToString = "DOCUMENT INWARD" Then
                    If DTROW(1).ToString = True Then
                        DOCIN_MASTER.Enabled = True
                        DOCIN_TOOL.Enabled = True
                        DOCINADD.Enabled = True
                    Else
                        DOCINADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DOCIN_MASTER.Enabled = True
                        DOCIN_TOOL.Enabled = True
                        DOCINEDIT.Enabled = True
                    Else
                        DOCINEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DOCUMENT OUTWARD" Then
                    If DTROW(1).ToString = True Then
                        DOCOUT_MASTER.Enabled = True
                        DOCOUT_TOOL.Enabled = True
                        DOCOUTADD.Enabled = True
                    Else
                        DOCOUTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DOCOUT_MASTER.Enabled = True
                        DOCOUT_TOOL.Enabled = True
                        DOCOUTEDIT.Enabled = True
                    Else
                        DOCOUTEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "MED CLAIM REQUEST" Then
                    If DTROW(1).ToString = True Then
                        MEDREQ_MASTER.Enabled = True
                        MEDREQ_TOOL.Enabled = True
                        MEDREQADD.Enabled = True
                        objhp.MECLAIMREQ_CMD.Enabled = True
                        objhp.LBLMEDCLAIMREQ.Enabled = True
                    Else
                        MEDREQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MEDREQ_MASTER.Enabled = True
                        MEDREQ_TOOL.Enabled = True
                        MEDREQEDIT.Enabled = True
                    Else
                        MEDREQEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "MED CLAIM APPROVAL" Then
                    If DTROW(1).ToString = True Then
                        MEDCLAIM_MASTER.Enabled = True
                        MEDSUPP_MASTER.Enabled = True
                        MEDCLAIM_TOOL.Enabled = True
                        MEDCLAIMADD.Enabled = True
                        MEDSUPPADD.Enabled = True
                        objhp.MEDCLAIMSETTLE_CMD.Enabled = True
                        objhp.LBLMEDCLAIMSETTLE.Enabled = True
                    Else
                        MEDCLAIMADD.Enabled = False
                        MEDSUPPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MEDCLAIM_MASTER.Enabled = True
                        MEDSUPP_MASTER.Enabled = True
                        MEDCLAIM_TOOL.Enabled = True
                        MEDCLAIMEDIT.Enabled = True
                        MEDSUPPEDIT.Enabled = True
                    Else
                        MEDCLAIMEDIT.Enabled = False
                        MEDSUPPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EDU CLAIM REQUEST" Then
                    If DTROW(1).ToString = True Then
                        EDUREQ_MASTER.Enabled = True
                        EDUREQ_TOOL.Enabled = True
                        EDUREQADD.Enabled = True
                        objhp.EDUCLAIMREQ_CMD.Enabled = True
                        objhp.LBLEDUCLAIMREQ.Enabled = True
                    Else
                        EDUREQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EDUREQ_MASTER.Enabled = True
                        EDUREQ_TOOL.Enabled = True
                        EDUREQEDIT.Enabled = True
                    Else
                        EDUREQEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EDU CLAIM APPROVAL" Then
                    If DTROW(1).ToString = True Then
                        EDUCLAIM_MASTER.Enabled = True
                        EDUSUPP_MASTER.Enabled = True
                        EDUCLAIM_TOOL.Enabled = True
                        EDUCLAIMADD.Enabled = True
                        EDUSUPPADD.Enabled = True
                        objhp.EDUCLAIMSETTLE_CMD.Enabled = True
                        objhp.LBLEDUCLAIMSETTLE.Enabled = True
                    Else
                        EDUCLAIMADD.Enabled = False
                        EDUSUPPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EDUCLAIM_MASTER.Enabled = True
                        EDUSUPP_MASTER.Enabled = True
                        EDUCLAIM_TOOL.Enabled = True
                        EDUCLAIMEDIT.Enabled = True
                        EDUSUPPEDIT.Enabled = True
                    Else
                        EDUCLAIMEDIT.Enabled = False
                        EDUSUPPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HOTEL BOOKING" Then
                    If DTROW(1).ToString = True Then
                        BOOKING_MASTER.Enabled = True
                        REFUND_MASTER.Enabled = True
                        BOOKING_TOOL.Enabled = True
                        BOOKINGADD.Enabled = True
                        REFUNDADD.Enabled = True
                        objhp.HOTELBOOKING_CMD.Enabled = True
                        objhp.LBLBOOKING.Enabled = True
                        objhp.REFUND_CMD.Enabled = True
                        objhp.LBLREFUND.Enabled = True
                    Else
                        BOOKINGADD.Enabled = False
                        REFUNDADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        BOOKING_MASTER.Enabled = True
                        REFUND_MASTER.Enabled = True
                        BOOKING_TOOL.Enabled = True
                        BOOKINGEDIT.Enabled = True
                        REFUNDEDIT.Enabled = True
                    Else
                        BOOKINGEDIT.Enabled = False
                        REFUNDEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CORRESPONDENCE" Then
                    If DTROW(1).ToString = True Then
                        CORRESPONDENCE_MASTER.Enabled = True
                        CORRESADD.Enabled = True
                    Else
                        CORRESADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CORRESPONDENCE_MASTER.Enabled = True
                        CORRESEDIT.Enabled = True
                    Else
                        CORRESEDIT.Enabled = False
                    End If


                    'ACCOUNTS
                ElseIf DTROW(0).ToString = "PAYMENT" Then
                    If DTROW(1).ToString = True Then
                        PAY_MASTER.Enabled = True
                        PAY_TOOL.Enabled = True
                        PAYADD.Enabled = True
                        objhp.PAYMENT_CMD.Enabled = True
                        objhp.LBLPAY.Enabled = True
                    Else
                        PAYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PAY_MASTER.Enabled = True
                        PAY_TOOL.Enabled = True
                        PAYEDIT.Enabled = True
                    Else
                        PAYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "RECEIPT" Then
                    If DTROW(1).ToString = True Then
                        REC_MASTER.Enabled = True
                        REC_TOOL.Enabled = True
                        RECADD.Enabled = True
                        objhp.RECEIPT_CMD.Enabled = True
                        objhp.LBLREC.Enabled = True
                    Else
                        RECADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REC_MASTER.Enabled = True
                        REC_TOOL.Enabled = True
                        RECEDIT.Enabled = True
                    Else
                        RECEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CONTRA VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        CONTRA_TOOL.Enabled = True
                        CONTRA_MASTER.Enabled = True
                        CONTRAADD.Enabled = True
                        objhp.CONTRA_CMD.Enabled = True
                        objhp.LBLCONTRA.Enabled = True
                    Else
                        CONTRAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CONTRA_TOOL.Enabled = True
                        CONTRA_MASTER.Enabled = True
                        CONTRAEDIT.Enabled = True
                    Else
                        CONTRAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "JOURNAL VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        JV_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        JVADD.Enabled = True
                        objhp.JOURNAL_CMD.Enabled = True
                        objhp.LBLJV.Enabled = True
                    Else
                        JVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JV_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        JVEDIT.Enabled = True
                    Else
                        JVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DEBIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        DEBIT_MASTER.Enabled = True
                        DEBITADD.Enabled = True
                    Else
                        DEBITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEBIT_MASTER.Enabled = True
                        DEBITEDIT.Enabled = True
                    Else
                        DEBITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CREDIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        CREDIT_MASTER.Enabled = True
                        CREDITADD.Enabled = True
                    Else
                        CREDITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CREDIT_MASTER.Enabled = True
                        CREDITEDIT.Enabled = True
                    Else
                        CREDITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "VOUCHER ENTRY" Then
                    If DTROW(1).ToString = True Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHERADD.Enabled = True
                        objhp.VOUCHER_CMD.Enabled = True
                        objhp.LBLVOUCHER.Enabled = True
                    Else
                        VOUCHERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHEREDIT.Enabled = True
                    Else
                        VOUCHEREDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "PAYROLL" Then
                    If DTROW(1).ToString = True Then
                        HOLIDAY_MASTER.Enabled = True
                        ATTENDENCE_MASTER.Enabled = True
                        SALARY_MASTER.Enabled = True
                        SALARYADD.Enabled = True
                    Else
                        ATTENDENCE_MASTER.Enabled = False
                        SALARYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOLIDAY_MASTER.Enabled = True
                        ATTENDENCE_MASTER.Enabled = True
                        SALARY_MASTER.Enabled = True
                        SALARYEDIT.Enabled = True
                    Else
                        ATTENDENCE_MASTER.Enabled = False
                        SALARYEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "TDS" Then
                    If DTROW(1).ToString = True Then
                        TDSCERT_MASTER.Enabled = True
                        TDSCHALLAN_MASTER.Enabled = True
                    Else
                        TDSCERT_MASTER.Enabled = False
                        TDSCHALLAN_MASTER.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TDSCERT_MASTER.Enabled = True
                        TDSCHALLAN_MASTER.Enabled = True
                    Else
                        TDSCERT_MASTER.Enabled = False
                        TDSCHALLAN_MASTER.Enabled = False
                    End If

                End If
            Next

            objhp.Refresh()
            objhp.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillYEAR()
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            Dim whereclause As String = ""
            'If UserName <> "Admin" Then
            '    dt = objcmn.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            '    For Each DTROW As DataRow In dt.Rows
            '        If whereclause = "" Then
            '            whereclause = " AND YEAR_ID IN (" & DTROW(0)
            '        Else
            '            whereclause = whereclause & "," & DTROW(0)
            '        End If
            '    Next
            '    whereclause = whereclause & ")"
            'End If

            dt = objcmn.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            For Each DTROW As DataRow In dt.Rows
                If whereclause = "" Then
                    whereclause = " AND YEAR_ID IN (" & DTROW(0)
                Else
                    whereclause = whereclause & "," & DTROW(0)
                End If
            Next
            whereclause = whereclause & ")"

            dt = objcmn.search("CONVERT(char(11), year_startdate , 6) + '   ---   ' + CONVERT(char(11), year_enddate , 6) ", "", "YearMaster INNER JOIN cmpmaster on cmp_id = year_cmpid", whereclause & " order BY YEAR_ID")
            For Each DTROW As DataRow In dt.Rows
                cmbselectcmp.DropDownItems.Add(DTROW(0))
            Next
            cmbselectcmp.Text = CmpName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click
        Try
            Dim objGroupMaster As New GroupMaster
            objGroupMaster.MdiParent = Me
            objGroupMaster.Show()
            objGroupMaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CITYADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "CITYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATEADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "STATEMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUNTRYADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "COUNTRYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AREAADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "AREAMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AddNewItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELADD.Click
        Try
            Dim OBJHOTEL As New HotelMaster
            OBJHOTEL.MdiParent = Me
            OBJHOTEL.Show()
            OBJHOTEL.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim objAccountMaster As New AccountsMaster
            objAccountMaster.MdiParent = Me
            objAccountMaster.frmstring = "ACCOUNTS"
            objAccountMaster.Show()
            objAccountMaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub addTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXADD.Click
        Try
            Dim objtaxmaster As New Taxmaster
            objtaxmaster.MdiParent = Me
            objtaxmaster.Show()
            objtaxmaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click
        Try
            Dim objGroupDetails As New GroupDetails
            objGroupDetails.MdiParent = Me
            objGroupDetails.Show()
            objGroupDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAccoutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACC_TOOL.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELEDIT.Click
        Try
            Dim OBJHOTEL As New HotelDetails
            OBJHOTEL.MdiParent = Me
            OBJHOTEL.Show()
            OBJHOTEL.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AREAEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "AREAMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CITYEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CITYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATEEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "STATEMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUNTRYEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "COUNTRYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXEDIT.Click

        Try
            Dim objtaxDetails As New TaxDetails
            objtaxDetails.MdiParent = Me
            objtaxDetails.Show()
            objtaxDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PURCHASE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "SALE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "JOURNAL"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CONTRA"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PAYMENT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "RECEIPT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVADD.Click
        Try
            Dim objJournal As New journal
            objJournal.MdiParent = Me
            objJournal.Show()
            objJournal.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins")
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub toolstripPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAY_TOOL.Click
        Try
            Dim OBJPAYMENT As New PaymentMaster
            OBJPAYMENT.MdiParent = Me
            OBJPAYMENT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYADD.Click
        Try
            Dim OBJPAYMENT As New PaymentMaster
            OBJPAYMENT.MdiParent = Me
            OBJPAYMENT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompany.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Cmpdetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JV_TOOL.Click
        Try
            Dim OBJJV As New journal
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVEDIT.Click
        Try
            Dim OBJJVDETAILS As New JournalDetails
            OBJJVDETAILS.MdiParent = Me
            OBJJVDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REC_TOOL.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECADD.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEDIT.Click
        Try
            Dim OBJRECDETAILS As New ReceiptDetails
            OBJRECDETAILS.MdiParent = Me
            OBJRECDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleRegisterToolStripMenuItem2.Click
        Try
            Dim objsalereg As New SaleRegister
            objsalereg.MdiParent = Me
            objsalereg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRegisterToolStripMenuItem2.Click
        Try
            Dim objpurreg As New PurchaseRegister
            objpurreg.MdiParent = Me
            objpurreg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalRegisterToolStripMenuItem2.Click
        Try
            Dim OBJJVREG As New JournalRegister
            OBJJVREG.MdiParent = Me
            OBJJVREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BankBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBookToolStripMenuItem.Click
        Try
            Dim OBJBANKREG As New BankRegister
            OBJBANKREG.MdiParent = Me
            OBJBANKREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
        Try
            Dim OBJCASHREG As New cashregister1
            OBJCASHREG.MdiParent = Me
            OBJCASHREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        Try
            Dim objdaybook As New DayBook
            objdaybook.MdiParent = Me
            objdaybook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewContraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAADD.Click
        Try
            Dim OBJCONTRA As New ContraEntry
            OBJCONTRA.MdiParent = Me
            OBJCONTRA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAEDIT.Click
        Try
            Dim OBJCONTRADETAILS As New ContraDetails
            OBJCONTRADETAILS.MdiParent = Me
            OBJCONTRADETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraRegisterToolStripMenuItem2.Click
        Try
            Dim OBJCONTRAREG As New ContraRegister
            OBJCONTRAREG.MdiParent = Me
            OBJCONTRAREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolstripHome.Click
        Try
            Dim objhp As New HomePage
            objhp.MdiParent = Me
            objhp.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTaxRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTaxRegisterToolStripMenuItem1.Click
        Try
            Dim OBJTAXFILTER As New TaxRegisterFilter
            OBJTAXFILTER.FRMSTRING = "PURCHASE"
            OBJTAXFILTER.MdiParent = Me
            OBJTAXFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalesTaxRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTaxRegisterToolStripMenuItem.Click
        Try
            Dim OBJTAXFILTER As New TaxRegisterFilter
            OBJTAXFILTER.FRMSTRING = "SALES"
            OBJTAXFILTER.MdiParent = Me
            OBJTAXFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub addUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim objuser As New UserMaster
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub editUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim objuser As New UserDetails
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbselectcmp_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmbselectcmp.DropDownItemClicked
        Try
            'close all child forms
            Dim f As Form
            For Each f In MdiChildren
                f.Close()
            Next
            opencmp(e.ClickedItem.ToString())

            Dim objhp As New HomePage
            objhp.MdiParent = Me
            objhp.Show()

            cmbselectcmp.Text = CmpName
            Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")"
            SETENABILITY()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub opencmp(ByVal CMP As String)
        Try

            Dim objcmn As New ClsCommon
            Dim DT As DataTable

            DT = objcmn.search("CMPMASTER.CMP_NAME, YEARMASTER.YEAR_DBNAME, CMPMASTER.CMP_ID, YEARMASTER.YEAR_STARTDATE, YEARMASTER.YEAR_ENDDATE, YEARMASTER.YEAR_ID", "", " CMPMASTER INNER JOIN YEARMASTER ON YEARMASTER.YEAR_CMPID = CMPMASTER.CMP_ID", " AND CMPMASTER.CMP_NAME = '" & CMP & "'")


            CmpName = DT.Rows(0).Item(0).ToString
            DBName = DT.Rows(0).Item(1).ToString
            CmpId = DT.Rows(0).Item(2).ToString
            AccFrom = DT.Rows(0).Item(3)
            AccTo = DT.Rows(0).Item(4)
            YearId = DT.Rows(0).Item(5).ToString

            'GETTING RIGHTS IN DATATABLE
            DT.Clear()
            DT = objcmn.search("User_id", "", "UserMaster", " and user_name = '" & UserName & "' AND USER_CMPID = " & CmpId)
            Userid = DT.Rows(0).Item(0)
            USERRIGHTS = objcmn.search("User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete]", "", "USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID", " and USERMASTER.USER_NAME = '" & UserName & "' and usermaster.user_CMPID = " & CmpId)


            'MDIMain.Show()
            'MDIMain.Refresh()
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITADD.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "UNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITEDIT.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "UNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesSettlementToolStripMenuItem.Click

        Try
            Dim objadv_rec_settlement As New Adv_Receivable_settlement
            objadv_rec_settlement.MdiParent = Me
            objadv_rec_settlement.flag_adv_settlement = True
            objadv_rec_settlement.flag_Rec_settlement = False
            objadv_rec_settlement.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReceivableSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSettlementToolStripMenuItem.Click
        Try
            Dim objadv_rec_settlement As New Adv_Receivable_settlement
            objadv_rec_settlement.MdiParent = Me
            objadv_rec_settlement.flag_adv_settlement = False
            objadv_rec_settlement.flag_Rec_settlement = True
            objadv_rec_settlement.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PaymentDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentDetailsToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter 'PayamentDetails
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "PaymentDetails"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesPaidReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesPaidReportToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "AdvancesPaidReport"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AdvancesReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesReToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "AdvancesReceiveReport"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReceiptDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptDetailsToolStripMenuItem.Click

        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "ReceiptDetails"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYEDIT.Click
        Try
            Dim objpAYdtls As New PaymentDetails
            objpAYdtls.MdiParent = Me
            objpAYdtls.Show()
            objpAYdtls.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRA_TOOL.Click
        Try
            Dim OBJCONTRA As New ContraEntry
            OBJCONTRA.MdiParent = Me
            OBJCONTRA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        Try
            Dim OBJTB As New TB
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossToolStripMenuItem.Click
        Try
            Dim objpl As New ProfitLoss
            objpl.MdiParent = Me
            objpl.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        Try
            Dim OBJBALANCESHEET As New BS
            OBJBALANCESHEET.MdiParent = Me
            OBJBALANCESHEET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ROOMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROOMADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "ROOMTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELTYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELTYPEADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "HOTELTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELGROUPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELGROUPADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "GROUPOFHOTELS"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELGROUPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELGROUPEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "GROUPOFHOTELS"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELTYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELTYPEEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "HOTELTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ROOMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROOMEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "ROOMTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AMENITIESADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AMENITIESADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "AMENITIES"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AMENITIESEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AMENITIESEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "AMENITIES"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXPENSEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHERADD.Click
        Try
            Dim OBJNP As New ExpenseVoucher
            OBJNP.FRMSTRING = "NONPURCHASE"
            OBJNP.MdiParent = Me
            OBJNP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXPENSEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHEREDIT.Click
        Try
            Dim OBJNPDETAILS As New ExpenseVoucherDetails
            OBJNPDETAILS.FRMSTRING = "NONPURCHASE"
            OBJNPDETAILS.MdiParent = Me
            OBJNPDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem1.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EXPENSE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LedgerBookToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBookToolStripMenuItem1.Click
        Try
            Dim objledgerbook As New RegisterDetails
            objledgerbook.MdiParent = Me
            objledgerbook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerOnScreenToolStripMenuItem.Click
        Try
            Dim objledger As New LedgerSummary
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupWiseTransactionsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupWiseTransactionsToolStripMenuItem1.Click
        Try
            Dim OBJGROUP As New GroupFilter
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupSummaryToolStripMenuItem.Click
        Try
            Dim OBJGROUP As New GroupRegister
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailToolStripMenuItem.Click
        Try
            Dim OBJMAIL As New E_Mail
            OBJMAIL.MdiParent = Me
            OBJMAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendSMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendSMSToolStripMenuItem.Click
        Try
            Dim OBJSMS As New SendSMS
            OBJSMS.MdiParent = Me
            OBJSMS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click
        Try
            Cmpmaster.edit = True
            Cmpmaster.TEMPCMPNAME = CmpName
            Cmpmaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BACKUPCMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BACKUPCMP.Click
        Try
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGELEDGER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGELEDGER.Click
        Try
            Dim objledger As New MergeLedger
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBILL_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBILL_MASTER.Click
        Try
            Dim OBJOPENING As New OpeningBills
            OBJOPENING.MdiParent = Me
            OBJOPENING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'LBLCHECKIN.Left = LBLCHECKIN.Left - 1
        'LBLCHECKIN.Top = StatusStrip2.Top + 2
        'CHECKIN_CMD.Top = StatusStrip2.Top - 4
        'If LBLCHECKIN.Left < 0 - LBLCHECKIN.Width Then
        '    'SCROLLERS()
        '    LBLCHECKIN.Left = Me.Width
        'End If
    End Sub

    Private Sub LedgerBillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBillWiseToolStripMenuItem.Click
        Try
            Dim OBJBILL As New LedgerBillwise
            OBJBILL.MdiParent = Me
            OBJBILL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalesTaxRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTaxRegisterToolStripMenuItem1.Click
        Try
            Dim OBJST As New SalesTaxRegisterDetails
            OBJST.MdiParent = Me
            OBJST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFER_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDREQ_TOOL.Click
        Try
            Dim OBJMEDREQ As New MedClaimReq
            OBJMEDREQ.MdiParent = Me
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAY_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUREQ_TOOL.Click
        Try
            Dim OBJEDUREQ As New EduClaimRequest
            OBJEDUREQ.MdiParent = Me
            OBJEDUREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INTERNATIONAL_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKING_TOOL.Click
        Try
            Dim OBJBOOK As New Booking
            OBJBOOK.MdiParent = Me
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewBookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKINGADD.Click
        Try
            Dim OBJBOOK As New Booking
            OBJBOOK.MdiParent = Me
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFICERADD.Click
        Try
            Dim OBJOFFICER As New OfficerMaster
            OBJOFFICER.MdiParent = Me
            OBJOFFICER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUEST_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFICER_TOOL.Click
        Try
            Dim OBJOFFICER As New OfficerDetails
            OBJOFFICER.MdiParent = Me
            OBJOFFICER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFICEREDIT.Click
        Try
            Dim OBJOFFICER As New OfficerDetails
            OBJOFFICER.MdiParent = Me
            OBJOFFICER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "CATEGORY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDitExistingCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "CATEGORY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CategoryConfiguratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYCONFIGURATOR.Click
        Try
            Dim OBJCAT As New CategoryConfig
            OBJCAT.MdiParent = Me
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewInwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCINADD.Click
        Try
            Dim OBJDOC As New DocumentInward
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RANKADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "RANK"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OFFCOMPANYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFCOMPANYADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "COMPANY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RANKEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "RANK"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OFFCOMPANYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFCOMPANYEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "COMPANY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCTYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCTYPEADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "DOCTYPE"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SENTBYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SENTBYADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "SENTBY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCTYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCTYPEEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "DOCTYPE"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SENTBYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SENTBYEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "SENTBY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingInwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCINEDIT.Click
        Try
            Dim OBJDOC As New DocumentInwardDetails
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCIN_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCIN_TOOL.Click
        Try
            Dim OBJDOC As New DocumentInward
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDCLAIMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDCLAIMADD.Click
        Try
            Dim OBJMEDSET As New MedClaimSettlement
            OBJMEDSET.MdiParent = Me
            OBJMEDSET.FRMSTRING = "MEDICAL"
            OBJMEDSET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUCLAIMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUCLAIMADD.Click
        Try
            Dim OBJEDUSET As New EduClaimSettlement
            OBJEDUSET.MdiParent = Me
            OBJEDUSET.FRMSTRING = "EDUCATION"
            OBJEDUSET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedicalRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedicalRequestToolStripMenuItem.Click
        Try
            Dim OBJREQDTLS As New MedReimbursementReport
            OBJREQDTLS.MdiParent = Me
            OBJREQDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CORRESADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORRESADD.Click
        Try
            Dim OBJCOR As New Correspondence
            OBJCOR.MdiParent = Me
            OBJCOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COURSEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COURSEADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "COURSE"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COURSEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COURSEEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "COURSE"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COURSEYEARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COURSEYEARADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "COURSEYEAR"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COURSEYEAREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COURSEYEAREDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "COURSEYEAR"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CORRESEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORRESEDIT.Click
        Try
            Dim OBJCOR As New CorrespondenceDetails
            OBJCOR.MdiParent = Me
            OBJCOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NARRATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONADD.Click
        Try
            Dim OBJCAT As New NarrationMaster
            OBJCAT.MdiParent = Me
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NARRATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "NARRATION"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDCLAIM_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDCLAIM_TOOL.Click
        Try
            Dim OBJMEDREQ As New MedClaimSettlement
            OBJMEDREQ.MdiParent = Me
            OBJMEDREQ.FRMSTRING = "MEDICAL"
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUCLAIM_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUCLAIM_TOOL.Click
        Try
            Dim OBJeduREQ As New EduClaimSettlement
            OBJeduREQ.MdiParent = Me
            OBJeduREQ.FRMSTRING = "EDUCATION"
            OBJeduREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RoomInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomInventoryToolStripMenuItem.Click
        Try
            Dim OBJINV As New Inventory
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckInListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInListToolStripMenuItem.Click
        Try
            Dim OBJCHECKIN As New CheckInList
            OBJCHECKIN.MdiParent = Me
            OBJCHECKIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem2.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "MEDICAL"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem3.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EDUCATION"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem4.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "BOOKING"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDREQADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDREQADD.Click
        Try
            Dim OBJMEDREQ As New MedClaimReq
            OBJMEDREQ.MdiParent = Me
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDREQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDREQEDIT.Click
        Try
            Dim OBJMEDREQ As New MedClaimReqDetails
            OBJMEDREQ.MdiParent = Me
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUREQADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUREQADD.Click
        Try
            Dim OBJEDUREQ As New EduClaimRequest
            OBJEDUREQ.MdiParent = Me
            OBJEDUREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUREQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUREQEDIT.Click
        Try
            Dim OBJEDUREQ As New EduClaimReqDetails
            OBJEDUREQ.MdiParent = Me
            OBJEDUREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDCLAIMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDCLAIMEDIT.Click
        Try
            Dim OBJMEDREQ As New MedClaimSettlementDetails
            OBJMEDREQ.MdiParent = Me
            OBJMEDREQ.FRMSTRING = "MEDICAL"
            OBJMEDREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUCLAIMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUCLAIMEDIT.Click
        Try
            Dim OBJEDUREQ As New EduClaimSettlementDetails
            OBJEDUREQ.MdiParent = Me
            OBJEDUREQ.FRMSTRING = "EDUCATION"
            OBJEDUREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REFUNDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REFUNDADD.Click
        Try
            Dim OBJREFUND As New Refund
            OBJREFUND.MdiParent = Me
            OBJREFUND.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REFUNDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REFUNDEDIT.Click
        Try
            Dim OBJREF As New RefundDetails
            OBJREF.MdiParent = Me
            OBJREF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClaimPaymentRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaimPaymentRegisterToolStripMenuItem.Click
        Try
            Dim OBJCLAIM As New ClaimPaymentRegister
            OBJCLAIM.MdiParent = Me
            OBJCLAIM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EduClaimRequestDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EduClaimRequestDetailsToolStripMenuItem.Click
        Try
            Dim OBJREQDTLS As New EduReimbursementReport
            OBJREQDTLS.MdiParent = Me
            OBJREQDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EduPendingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EduPendingRequestToolStripMenuItem.Click
        Try
            Dim OBJEDU As New EduReqReport
            OBJEDU.MdiParent = Me
            OBJEDU.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedPendingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedPendingRequestToolStripMenuItem.Click
        Try
            Dim OBJMED As New MedReqReport
            OBJMED.MdiParent = Me
            OBJMED.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MonthlyReimbursementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyReimbursementReportToolStripMenuItem.Click
        Try
            Dim OBJMON As New CompanyMonthlyReport
            OBJMON.MdiParent = Me
            OBJMON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClaimReimbursementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaimReimbursementReportToolStripMenuItem.Click
        Try
            Dim OBJRE As New CompanyReimbursementReport
            OBJRE.MdiParent = Me
            OBJRE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContributionRecdReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContributionRecdReportToolStripMenuItem.Click
        Try
            Dim OBJCONT As New ContributionReport
            OBJCONT.MdiParent = Me
            OBJCONT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMPADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EMPADD.Click
        Try
            Dim OBJEMP As New EmployeeMaster
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
            OBJEMP.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMPEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EMPEDIT.Click
        Try
            Dim OBJEMP As New EmployeeDetails
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
            OBJEMP.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReimbursementComparisonReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReimbursementComparisonReportToolStripMenuItem.Click
        Try
            Dim OBJEMP As New ReimbursementComparisonReport
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
            OBJEMP.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelBookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelBookingToolStripMenuItem.Click
        Try
            Dim OBJOCC As New OccupancyReport
            OBJOCC.MdiParent = Me
            OBJOCC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefundDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefundDetailsToolStripMenuItem.Click
        Try
            Dim OBJREFUND As New RefundReport
            OBJREFUND.MdiParent = Me
            OBJREFUND.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKINGEDIT.Click
        Try
            Dim OBJBOOK As New BookingDetails
            OBJBOOK.MdiParent = Me
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ATTENDENCE_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATTENDENCE_MASTER.Click
        Try
            Dim OBJATT As New Attendence
            OBJATT.MdiParent = Me
            OBJATT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMADD.Click
        Try
            Dim OBJITEM As New ItemMaster
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMEDIT.Click
        Try
            Dim OBJITEM As New ItemDetails
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMCATEGORYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMCATEGORYADD.Click
        Try
            Dim OBJCAT As New CategoryMaster
            OBJCAT.MdiParent = Me
            OBJCAT.frmString = "ITEMCATEGORY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMCATEGORYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMCATEGORYEDIT.Click
        Try
            Dim OBJCAT As New CategoryDetails
            OBJCAT.MdiParent = Me
            OBJCAT.frmstring = "ITEMCATEGORY"
            OBJCAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMINVENTORYEDIT.Click
        Try
            Dim OBJINV As New ItemInventoryDetails
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMINVENTORYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMINVENTORYADD.Click
        Try
            Dim OBJINV As New ItemInventory
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedicalPendingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedicalPendingRequestToolStripMenuItem.Click
        Try
            Dim OBJMED As New MedReqOutstanding
            OBJMED.MdiParent = Me
            OBJMED.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MedOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedOutstandingToolStripMenuItem.Click
        Try
            Dim OBJMED As New MedSettlementOutstanding
            OBJMED.MdiParent = Me
            OBJMED.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EduOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EduOutstandingToolStripMenuItem.Click
        Try
            Dim OBJEDU As New EduSettlementOutstanding
            OBJEDU.MdiParent = Me
            OBJEDU.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EducationPendingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EducationPendingRequestToolStripMenuItem.Click
        Try
            Dim OBJEDU As New EduReqOutstanding
            OBJEDU.MdiParent = Me
            OBJEDU.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BookingOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookingOutstandingToolStripMenuItem.Click
        Try
            Dim OBJBOOK As New BookingOutstanding
            OBJBOOK.MdiParent = Me
            OBJBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefundOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefundOutstandingToolStripMenuItem.Click
        Try
            Dim OBJREF As New RefundOutstanding
            OBJREF.MdiParent = Me
            OBJREF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYADD.Click
        Try
            Dim OBJSAL As New SalaryMaster
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYEDIT.Click
        Try
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCHALLAN_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSCHALLAN_MASTER.Click
        Try
            Dim OBJTDS As New TDSChallan
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCERT_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSCERT_MASTER.Click
        Try
            Dim OBJTDS As New TDSCertificate
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCOUTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCOUTADD.Click
        Try
            Dim OBJDOC As New DocumentDispatch
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCOUTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCOUTEDIT.Click
        Try
            Dim OBJDOC As New DocumentDispatchDetails
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDSUPPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDSUPPADD.Click
        Try
            Dim OBJSUPP As New MedClaimSettlement
            OBJSUPP.MdiParent = Me
            OBJSUPP.FRMSTRING = "MEDSUPP"
            OBJSUPP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEDSUPPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDSUPPEDIT.Click
        Try
            Dim OBJSUPP As New MedClaimSettlementDetails
            OBJSUPP.MdiParent = Me
            OBJSUPP.FRMSTRING = "MEDSUPP"
            OBJSUPP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUSUPPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUSUPPADD.Click
        Try
            Dim OBJSUPP As New EduClaimSettlement
            OBJSUPP.MdiParent = Me
            OBJSUPP.FRMSTRING = "EDUSUPP"
            OBJSUPP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDUSUPPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDUSUPPEDIT.Click
        Try
            Dim OBJSUPP As New MedClaimSettlementDetails
            OBJSUPP.MdiParent = Me
            OBJSUPP.FRMSTRING = "EDUSUPP"
            OBJSUPP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    
    Private Sub HOLIDAY_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAY_MASTER.Click
        Try
            Dim OBJHOLIDAY As New HolidayMaster
            OBJHOLIDAY.MdiParent = Me
            OBJHOLIDAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARTRANSFER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARTRANSFER_MASTER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARADD.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Create New Accounting Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim obj As New YearMaster
                If CheckFormStatus(YearMaster) Then

                    Exit Sub
                End If
                obj.cmdback.Visible = False
                obj.EDIT = False
                obj.FRMSTRING = "ADDYEAR"
                obj.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckFormStatus(ByVal Myform As Form) As Boolean

        Dim objForm As Form
        Dim FlgLoaded As Boolean
        Dim FlgShown As Boolean
        FlgLoaded = False
        FlgShown = False
        For Each objForm In MdiChildren
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                FlgLoaded = True
                If objForm.Visible Then
                    FlgShown = True

                End If
                Exit For
            End If
        Next
        Return FlgShown
    End Function

    Private Sub DOCOUT_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCOUT_TOOL.Click
        Try
            Dim OBJDOC As New DocumentDispatch
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INVESTMENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INVESTMENTADD.Click
        Try
            Dim OBJDOC As New Investment
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INVESTMENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INVESTMENTEDIT.Click
        Try
            Dim OBJDOC As New InvestmentDetails
            OBJDOC.MdiParent = Me
            OBJDOC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerReportToolStripMenuItem.Click
        Try
            Dim OBJLEDGER As New LedgerFilter
            OBJLEDGER.MdiParent = Me
            OBJLEDGER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INVESTMENT_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INVESTMENT_MASTER.Click
        Try
            Dim OBJ As New InvestmentFilter
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBALANCE.Click
        Try
            Dim OBJOP As New OpeningBalance
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGEPARAMETER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGEPARAMETER.Click
        Try
            Dim objPARAM As New MergeParameter
            objPARAM.MdiParent = Me
            objPARAM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VESSELADD_Click(sender As Object, e As EventArgs) Handles VESSELADD.Click
        Try
            Dim OBJVESSEL As New VesselMaster
            OBJVESSEL.MdiParent = Me
            OBJVESSEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VESSELEDIT_Click(sender As Object, e As EventArgs) Handles VESSELEDIT.Click
        Try
            Dim OBJVESSEL As New VesselDetails
            OBJVESSEL.MdiParent = Me
            OBJVESSEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaryReportToolStripMenuItem.Click
        Try
            Dim OBJSAL As New SalaryFilter
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReimbursementComparisonReportPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimbursementComparisonReportPaymentToolStripMenuItem.Click
        Try
            Dim OBJEMP As New ReimbursementComparisonPayReport
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
            OBJEMP.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub WhatsappRegisterationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WhatsappRegisterationToolStripMenuItem1.Click
        Try
            Dim OBJEMP As New WhatsappRegisteration
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WhatsappRegisterationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhatsappRegisterationToolStripMenuItem.Click
        Try
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.MdiParent = Me
            OBJWHATSAPP.FRMSTRING = "DIRECTWHATSAPP"
            OBJWHATSAPP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
