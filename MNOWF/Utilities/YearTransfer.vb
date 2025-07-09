
Imports BL

Public Class YearTransfer

    Dim INTRES As Integer
    Dim OBJTRF As New ClsYearTransfer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'transfering data from selected cmp
            If GRIDYEAR.SelectedRows.Count = 0 Then
                MsgBox("Select Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim SELECTEDYEARID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox("Transfer Data from Selected Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    SELECTEDYEARID = GRIDYEAR.Item(GYEARID.Index, GRIDYEAR.CurrentRow.Index).Value

                    If CHKMASTER.Checked = True Then
                        TRANSFERDOCTYPE(SELECTEDYEARID)
                        TRANSFERINMODE(SELECTEDYEARID)
                        TRANSFERSENTBY(SELECTEDYEARID)
                        'TRANSFERRECDBY(SELECTEDYEARID)

                        TRANSFERRANK(SELECTEDYEARID)
                        TRANSFERCOMPANY(SELECTEDYEARID)
                        TRANSFERFAMILY(SELECTEDYEARID)
                        TRANSFERRELATION(SELECTEDYEARID)
                        TRANSFEROFFICER(SELECTEDYEARID)
                        TRANSFERVESSEL(SELECTEDYEARID)

                        TRANSFERDESIGNATION(SELECTEDYEARID)
                        TRANSFERDEPARTMENT(SELECTEDYEARID)
                        TRANSFERGROUP(SELECTEDYEARID)
                        TRANSFERLOCATION(SELECTEDYEARID)
                        TRANSFERACCOUNTS(SELECTEDYEARID)
                        TRANSFEREMPLOYEES(SELECTEDYEARID)

                        TRANSFERAMENITIES(SELECTEDYEARID)
                        TRANSFERHOTELTYPE(SELECTEDYEARID)
                        TRANSFERHOTELGROUP(SELECTEDYEARID)
                        TRANSFERROOMTYPE(SELECTEDYEARID)
                        TRANSFERHOTEL(SELECTEDYEARID)

                        TRANSFERCATEGORY(SELECTEDYEARID)
                        TRANSFERCHARGES(SELECTEDYEARID)
                        TRANSFERCONFIG(SELECTEDYEARID)

                        TRANSFERCOURSE(SELECTEDYEARID)
                        TRANSFERCOURSEYEAR(SELECTEDYEARID)

                        TRANSFERITEMCATEGORY(SELECTEDYEARID)
                        TRANSFERITEM(SELECTEDYEARID)
                        TRANSFERNARRATION(SELECTEDYEARID)
                    End If

                    If CHKDATA.Checked = True Then
                        TRANSFERDOCUMENTINWARD(SELECTEDYEARID)
                        TRANSFERMEDCLAIMS(SELECTEDYEARID)
                        TRANSFEREDUCLAIMS(SELECTEDYEARID)
                        TRANSFERBOOKING(SELECTEDYEARID)
                        TRANSFERCORRESPONDENCE(SELECTEDYEARID)
                        TRANSFERINVESTMENT(SELECTEDYEARID)
                        TRANSFERBILLS(SELECTEDYEARID)
                        TRANSFERBALANCE(SELECTEDYEARID)

                        TRANSFERPROFITLOSS(SELECTEDYEARID)
                    End If

                    MsgBox("Transfer Completed Successfully")

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CONVERT(char(11), year_startdate , 6) + ' - ' + CONVERT(char(11), year_enddate , 6) AS YEARNAME, YEAR_ID AS YEARID   ", "", " YEARMASTER", " AND YEAR_ID <> " & YearId & " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_ID DESC ")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDYEAR.Rows.Add(DTROW("YEARNAME"), DTROW("YEARID"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDOCTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDOCTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERINMODE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERINMODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSENTBY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSENTBY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRANK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERRANK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOMPANY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOMPANY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERFAMILY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERFAMILY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRELATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERRELATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFEROFFICER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFEROFFICER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERVESSEL(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERVESSEL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDEPARTMENT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDEPARTMENT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOCATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOCATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERACCOUNTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERACCOUNTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFEREMPLOYEES(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFEREMPLOYEES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERAMENITIES(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERAMENITIES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTELTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTELTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTELGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTELGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDESIGNATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDESIGNATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERROOMTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTEL(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTEL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCATEGORY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCATEGORY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCHARGES(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCHARGES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCONFIG(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCONFIG()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOURSE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOURSE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOURSEYEAR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOURSEYEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITEMCATEGORY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITEMCATEGORY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITEM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITEM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERNARRATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERNARRATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDOCUMENTINWARD(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDOCUMENTINWARD()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMEDCLAIMS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMEDCLAIMS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFEREDUCLAIMS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFEREDUCLAIMS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub TRANSFERBOOKING(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBOOKING()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCORRESPONDENCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCORRESPONDENCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERINVESTMENT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERINVESTMENT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBILLS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBILLS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBALANCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROFITLOSS(ByVal SELECTEDYEARID As Integer)
        Try


            Dim ALPARAVAL As New ArrayList
            Dim OBJPL As New ClsProfitLoss

            Dim OBJCMN As New ClsCommon
            Dim DTF As DataTable = OBJCMN.search(" YEAR_STARTDATE AS FROMDATE, YEAR_ENDDATE AS TODATE", "", " YEARMASTER ", " AND YEAR_ID = " & SELECTEDYEARID)
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("FROMDATE"), "MM/dd/yyyy"))
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("TODATE"), "MM/dd/yyyy"))

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(SELECTEDYEARID)

            OBJPL.alParaval = ALPARAVAL
            Dim DT = OBJPL.GETLEDGER()


            'CODE BY GULKIT
            'GET OPSTOCK
            Dim OPSTOCK, CLOSTOCK As Double
            Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS, TOTALNETTPROFIT, TOTALNETTLOSS As Double
            OPSTOCK = 0
            CLOSTOCK = 0
            Dim OPSTOCKDT As DataTable = OBJCMN.search(" ISNULL(OPENINGSTOCK,0) AS OPENINGSTOCK, ISNULL(CLOSINGSTOCK,0) AS CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & SELECTEDYEARID)
            If OPSTOCKDT.Rows.Count > 0 Then
                OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OPENINGSTOCK"))
                CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("CLOSINGSTOCK"))
            End If


            TOTALDREXP += OPSTOCK

            Dim i As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDREXP += Val(DTROW("CLOBALDR"))
                        TOTALCREXP += Val(DTROW("CLOBALCR"))
                    End If
                End If
                '*****************************************************************
                '*****************************************************************

                If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDRINC += Val(DTROW("CLOBALDR"))
                        TOTALCRINC += Val(DTROW("CLOBALCR"))
                    End If
                End If
            Next
            TOTALCRINC += CLOSTOCK

            If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
            Else
                TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
            End If
            ''**************************************************************************************



            TOTALDREXP = 0
            TOTALCREXP = 0
            TOTALDRINC = 0
            TOTALCRINC = 0


            'FORMATTING GRID
            For Each DTROW As DataRow In DT.Rows
                If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDREXP += Val(DTROW("CLOBALDR"))
                        TOTALCREXP += Val(DTROW("CLOBALCR"))
                    End If
                End If
                '*****************************************************************
                '*****************************************************************

                If DTROW("PRIMARYGP") = "Indirect Income" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDRINC += Val(DTROW("CLOBALDR"))
                        TOTALCRINC += Val(DTROW("CLOBALCR"))
                    End If
                End If
            Next

            If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
            Else
                TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
            End If
            ''***************************************************************************************
            ALPARAVAL.Clear()


            'IF WE HAVE ENTERED JOURNAL ENTRY IN CURRENT YEAR THEN FETCH THAT VALUE AND ADD IN BELOW ENTRY
            Dim PLTBDR As Double = 0
            Dim PLTBCR As Double = 0
            Dim DTPLTB As DataTable = OBJCMN.search("(CASE WHEN (SUM(DR) - SUM(CR)) > 0 THEN (SUM(DR) - SUM(CR)) ELSE 0 END) AS DR, (CASE WHEN (SUM(CR) - SUM(DR)) > 0 THEN (SUM(CR) - SUM(DR)) ELSE 0 END) AS CR", "", "TRIALBALANCE", " AND PRIMARYGROUP = 'Profit & Loss' AND YEARID = " & SELECTEDYEARID)
            If DTPLTB.Rows.Count > 0 Then
                PLTBDR = Val(DTPLTB.Rows(0).Item("DR"))
                PLTBCR = Val(DTPLTB.Rows(0).Item("CR"))
            End If


            'IF PROFITLOSS LEDGER IS DEBIT THEN DEDUCT FROM TOTALNETTPROFIT OR ELSE DEDUCT FROM TOTALNETTLOSS
            If PLTBDR > 0 Then TOTALNETTPROFIT = Format(Val(TOTALNETTPROFIT) - Val(PLTBDR), "0.00")
            If PLTBCR > 0 Then TOTALNETTLOSS = Format(Val(TOTALNETTLOSS) - Val(PLTBCR), "0.00")


            If TOTALNETTPROFIT > 0 Then ALPARAVAL.Add(Val(TOTALNETTPROFIT)) Else ALPARAVAL.Add(Val(TOTALNETTLOSS))


            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROFITLOSS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class