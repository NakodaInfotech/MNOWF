
Imports System.Windows.Forms
Imports System.Net.Mail
Imports BL
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Web
Imports System.Security
Imports WAProAPI
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Module Functions

    Function ErrHandle(ByVal Errcode As Integer) As Boolean
        Dim bln As Boolean = False
        If Errcode = -675406840 Then
            MsgBox("Check Internet Connection")
            bln = True
        End If
        Return bln
    End Function

    Public Sub pcase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.ProperCase)
    End Sub

    Public Sub uppercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Uppercase)
    End Sub

    Public Sub lowercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Lowercase)
    End Sub

    Function getfirstdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "DEFAULT HEADER"


    Public Sub AddExcelHeaderWithLogo(filePath As String, reportType As String, dtfrom As Date, dtto As Date)
        Dim excelApp As New Excel.Application
        Dim workbook As Excel.Workbook = excelApp.Workbooks.Open(filePath)
        Dim worksheet As Excel.Worksheet = CType(workbook.Sheets(1), Excel.Worksheet)

        excelApp.Visible = False

        ' Insert 5 rows at the top
        worksheet.Rows("1:5").Insert()

        ' Set default font
        worksheet.Cells.Font.Name = "Calibri"
        worksheet.Cells.Font.Size = 10

        ' Main Title
        With worksheet.Range("A1:H1")
            .Merge()
            .Value = "THE MERCHANT NAVY OFFICERS' WELFARE FUND"
            .Font.Size = 14
            .Font.Bold = True
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With

        ' Subtitle
        With worksheet.Range("A2:H2")
            .Merge()
            .Value = reportType.ToUpper() & " REIMBURSEMENT PAYMENT (BANK COPY)"
            .Font.Size = 11
            .Font.Bold = True
            .Font.Underline = True
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With

        ' Date Range
        With worksheet.Range("A3:H3")
            .Merge()
            .Value = "From " & dtfrom.ToString("dd/MM/yyyy") & " To " & dtto.ToString("dd/MM/yyyy")
            .Font.Size = 10
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With

        ' Insert Logo if it exists
        Dim logoPath As String = Application.StartupPath & "\logo.png"
        If System.IO.File.Exists(logoPath) Then
            worksheet.Shapes.AddPicture(logoPath, 0, -1, 10, 5, 60, 60)
        Else
            MsgBox("Logo not found at: " & logoPath)
        End If

        ' Determine the last used row
        Dim lastRow As Integer = worksheet.Cells(worksheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row

        ' Auto-fit all columns
        worksheet.Columns("A:H").AutoFit()

        ' Freeze header row (row 6 becomes header after inserting 5 rows)
        worksheet.Rows("7:7").Select()
        excelApp.ActiveWindow.FreezePanes = True

        ' Align Amount column (G) to the right
        worksheet.Range("G7:G" & lastRow).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

        ' Save and clean up
        workbook.Save()
        workbook.Close(False)
        excelApp.Quit()

        ' Release COM objects
        ReleaseObject(worksheet)
        ReleaseObject(workbook)
        ReleaseObject(excelApp)
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


#End Region

#Region "WHATSAPP"

    Function CHECKWHASTAPPEXP() As Boolean
        Dim BLN As Boolean = True
        If Now.Date > WHATSAPPEXPDATE Then
            BLN = False
        End If
        Return BLN
    End Function

    Function GETWHATSAPPBASEURL() As String
        Dim WHATSAPPBASEURL As String = ""

        'READ BASEURL FROM C DRIVE
        If File.Exists("C:\WHATSAPPBASEURL.txt") Then
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\WHATSAPPBASEURL.txt")
            WHATSAPPBASEURL = oRead.ReadToEnd
        End If
        Return WHATSAPPBASEURL
    End Function

    Async Function SENDWHATSAPPATTACHMENT(WHATSAPPNO As String, PATH As String, FILENAME As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim waMediaMsgBody As SendMediaMsgJson = New SendMediaMsgJson()
        Dim Attachment As String = Convert.ToBase64String(File.ReadAllBytes(PATH))
        Dim AttachmentFileName As String = FILENAME
        waMediaMsgBody.base64data = Attachment
        waMediaMsgBody.mimeType = MimeMapping.GetMimeMapping(AttachmentFileName)
        'waMediaMsgBody.caption = "APIMethod SendMediaMessage from CISPLWhatsAppAPI.dll"
        waMediaMsgBody.filename = AttachmentFileName
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendMediaMessageAsync(WHATSAPPNO, waMediaMsgBody)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)

        Return RESPONSE
    End Function

    Async Function SENDWHATSAPPMESSAGE(WHATSAPPNO As String, TEXTMESSAGE As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim Body As SendTextMsgJson = New SendTextMsgJson()
        Body.text = TEXTMESSAGE
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendTextMessageAsync(WHATSAPPNO, Body)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function

    Async Function CHECKMOBILECONNECTSTATUS() As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim txnResp As TxnRespWithConnectionState = Await APIMethods.GetConnectionStateAsync()
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function

#End Region

    Function getlastdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub datefunction()

        'SQL Queries
        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)),@mydate),101) ,
        '        'Last Day of Previous Month'
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101) AS Date_Value,
        '            'First Day of Current Month' AS Date_Type
        'UNION
        'SELECT CONVERT(VARCHAR(25),@mydate,101) AS Date_Value, 'Today' AS Date_Type
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))),DATEADD(mm,1,@mydate)),101) ,
        '                    'Last Day of Current Month'
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))-1),DATEADD(mm,1,@mydate)),101) ,
        '                        'First Day of Next Month'


    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As System.Windows.Forms.TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If
        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Function getmax(ByVal fldname As String, ByVal tbname As String, Optional ByVal whereclause As String = "") As DataTable
        Try
            Dim DTTABLE As DataTable

            Dim objclscommon As New ClsCommon()
            DTTABLE = objclscommon.GETMAXNO(fldname, tbname, whereclause)

            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function datecheck(ByVal dateval As Date) As Boolean
        Dim bln As Boolean = True
        If dateval.Date > AccTo Or dateval.Date < AccFrom Then
            bln = False
        End If
        Return bln
    End Function

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub

    Sub fillregister(ByRef cmbregister As ComboBox, ByVal condition As String)
        Try
            If cmbregister.Text.Trim = "" Then

                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search(" Register_name ", "", "RegisterMaster ", condition & " and Register_cmpid=" & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Register_name"
                    cmbregister.DataSource = dt
                    cmbregister.DisplayMember = "Register_name"
                    cmbregister.Text = ""
                End If
                cmbregister.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLOFFICER(ByRef CMBOFFICER As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBOFFICER.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" OFFICER_name ", "", " OFFICERMaster", CONDITION & " and OFFICER_cmpid=" & CmpId & " AND OFFICER_LOCATIONID = " & Locationid & " AND OFFICER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "OFFICER_name"
                    CMBOFFICER.DataSource = dt
                    CMBOFFICER.DisplayMember = "OFFICER_name"
                    If edit = False Then CMBOFFICER.Text = ""
                End If
                CMBOFFICER.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub OFFICERVALIDATE(ByRef CMBOFFICER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal whereclause As String = "", Optional ByRef WHATSAPPNO As String = "")

        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBOFFICER.Text.Trim <> "" Then
                pcase(CMBOFFICER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" ISNULL(OFFICER_mobile, '') AS WHATSAPPNO, ISNULL(OFFICER_name, '') AS NAME", "", " OFFICERMASTER ", " and OFFICER_NAME = '" & CMBOFFICER.Text.Trim & "' AND OFFICER_CMPID = " & CmpId & " AND OFFICER_LOCATIONID = " & Locationid & " AND OFFICER_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBOFFICER.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Officer not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMBOFFICER.Text = a
                        Dim OBJOFFICER As New OfficerMaster
                        OBJOFFICER.frmstring = "OFFICER MASTER"
                        OBJOFFICER.TEMPOFFICERNAME = CMBOFFICER.Text.Trim()
                        OBJOFFICER.ShowDialog()
                        dt = objclscommon.search("ISNULL(OFFICERMASTER.OFFICER_mobile, '') AS WHATSAPPNO, ISNULL(OFFICERMASTER.OFFICER_name, '') AS NAME, LEDGERS.Acc_id as ACCID", "", " OFFICERMASTER INNER JOIN LEDGERS ON OFFICERMASTER.OFFICER_id = LEDGERS.Acc_id ", " and OFFICER_NAME = '" & CMBOFFICER.Text.Trim & "' AND OFFICER_CMPID = " & CmpId & " AND OFFICER_LOCATIONID = " & Locationid & " AND OFFICER_YEARID = " & YearId & whereclause)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBOFFICER.DataSource
                            If CMBOFFICER.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ACCID"), CMBOFFICER.Text.Trim)
                                    CMBOFFICER.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    If WHATSAPPNO = "" Then WHATSAPPNO = dt.Rows(0).Item("WHATSAPPNO")
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLRANK(ByRef CMBRANK As ComboBox, ByRef edit As Boolean)
        Try
            If CMBRANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" RANK_name ", "", " RANKMaster", " and RANK_cmpid=" & CmpId & " AND RANK_LOCATIONID = " & Locationid & " AND RANK_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "RANK_name"
                    CMBRANK.DataSource = dt
                    CMBRANK.DisplayMember = "RANK_name"
                    If edit = False Then CMBRANK.Text = ""
                End If
                CMBRANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub RANKVALIDATE(ByRef CMBRANK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBRANK.Text.Trim <> "" Then
                pcase(CMBRANK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("RANK_id", "", "RANKMaster", " and RANK_NAME = '" & CMBRANK.Text.Trim & "' and RANK_cmpid = " & CmpId & " and RANK_LOCATIONid = " & Locationid & " and RANK_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("RANK not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBRANK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsRANK As New ClsRankMaster
                        objclsRANK.alParaval = alParaval
                        Dim IntResult As Integer = objclsRANK.SAVE()
                    Else
                        CMBRANK.Focus()
                        CMBRANK.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCOURSEYEAR(ByRef CMBCOURSEYEAR As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCOURSEYEAR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COURSEYEAR_name ", "", " COURSEYEARMaster", " and COURSEYEAR_cmpid=" & CmpId & " AND COURSEYEAR_LOCATIONID = " & Locationid & " AND COURSEYEAR_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COURSEYEAR_name"
                    CMBCOURSEYEAR.DataSource = dt
                    CMBCOURSEYEAR.DisplayMember = "COURSEYEAR_name"
                    If edit = False Then CMBCOURSEYEAR.Text = ""
                End If
                CMBCOURSEYEAR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COURSEYEARVALIDATE(ByRef CMBCOURSEYEAR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOURSEYEAR.Text.Trim <> "" Then
                pcase(CMBCOURSEYEAR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COURSEYEAR_id", "", "COURSEYEARMaster", " and COURSEYEAR_NAME = '" & CMBCOURSEYEAR.Text.Trim & "' and COURSEYEAR_cmpid = " & CmpId & " and COURSEYEAR_LOCATIONid = " & Locationid & " and COURSEYEAR_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COURSEYEAR not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCOURSEYEAR.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCOURSEYEAR As New ClsCourseYearMaster
                        objclsCOURSEYEAR.alParaval = alParaval
                        Dim IntResult As Integer = objclsCOURSEYEAR.save()
                    Else
                        CMBCOURSEYEAR.Focus()
                        CMBCOURSEYEAR.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCOURSE(ByRef CMBCOURSE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCOURSE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COURSE_name ", "", " COURSEMaster", " and COURSE_cmpid=" & CmpId & " AND COURSE_LOCATIONID = " & Locationid & " AND COURSE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COURSE_name"
                    CMBCOURSE.DataSource = dt
                    CMBCOURSE.DisplayMember = "COURSE_name"
                    If edit = False Then CMBCOURSE.Text = ""
                End If
                CMBCOURSE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COURSEVALIDATE(ByRef CMBCOURSE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOURSE.Text.Trim <> "" Then
                pcase(CMBCOURSE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COURSE_id", "", "COURSEMaster", " and COURSE_NAME = '" & CMBCOURSE.Text.Trim & "' and COURSE_cmpid = " & CmpId & " and COURSE_LOCATIONid = " & Locationid & " and COURSE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COURSE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCOURSE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCOURSE As New ClsCourseMaster
                        objclsCOURSE.alParaval = alParaval
                        Dim IntResult As Integer = objclsCOURSE.save()
                    Else
                        CMBCOURSE.Focus()
                        CMBCOURSE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCOMPANY(ByRef CMBCOMPANY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COMPANY_name ", "", " COMPANYMaster", " and COMPANY_cmpid=" & CmpId & " AND COMPANY_LOCATIONID = " & Locationid & " AND COMPANY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COMPANY_name"
                    CMBCOMPANY.DataSource = dt
                    CMBCOMPANY.DisplayMember = "COMPANY_name"
                    If edit = False Then CMBCOMPANY.Text = ""
                End If
                CMBCOMPANY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COMPANYVALIDATE(ByRef CMBCOMPANY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOMPANY.Text.Trim <> "" Then
                pcase(CMBCOMPANY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COMPANY_id", "", "COMPANYMaster", " and COMPANY_NAME = '" & CMBCOMPANY.Text.Trim & "' and COMPANY_cmpid = " & CmpId & " and COMPANY_LOCATIONid = " & Locationid & " and COMPANY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COMPANY not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCOMPANY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCOMPANY As New ClsCompanyMaster
                        objclsCOMPANY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCOMPANY.SAVE()
                    Else
                        CMBCOMPANY.Focus()
                        CMBCOMPANY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLRELATION(ByRef CMBRELATION As ComboBox, ByRef edit As Boolean)
        Try
            If CMBRELATION.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" RELATION_name ", "", " RELATIONMaster", " and RELATION_cmpid=" & CmpId & " AND RELATION_LOCATIONID = " & Locationid & " AND RELATION_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "RELATION_name"
                    CMBRELATION.DataSource = dt
                    CMBRELATION.DisplayMember = "RELATION_name"
                    If edit = False Then CMBRELATION.Text = ""
                End If
                CMBRELATION.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub RELATIONVALIDATE(ByRef CMBRELATION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBRELATION.Text.Trim <> "" Then
                pcase(CMBRELATION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("RELATION_id", "", "RELATIONMaster", " and RELATION_NAME = '" & CMBRELATION.Text.Trim & "' and RELATION_cmpid = " & CmpId & " and RELATION_LOCATIONid = " & Locationid & " and RELATION_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("RELATION not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBRELATION.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsRELATION As New ClsRelationMaster
                        objclsRELATION.alParaval = alParaval
                        Dim IntResult As Integer = objclsRELATION.SAVE()
                    Else
                        CMBRELATION.Focus()
                        CMBRELATION.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLEMP(ByRef CMPEMP As ComboBox, ByRef edit As Boolean)
        Try
            If CMPEMP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" EMP_name ", "", " EMPLOYEEMaster", " and EMP_cmpid=" & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_name"
                    CMPEMP.DataSource = dt
                    CMPEMP.DisplayMember = "EMP_name"
                    If edit = False Then CMPEMP.Text = ""
                End If
                CMPEMP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EMPVALIDATE(ByRef CMPEMP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMPEMP.Text.Trim <> "" Then
                pcase(CMPEMP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMP_ID", "", " EMPLOYEEMASTER", " and EMP_NAME = '" & CMPEMP.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMPEMP.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Employee not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMPEMP.Text = a
                        Dim OBJEMP As New EmployeeMaster
                        OBJEMP.TEMPEMPNAME = CMPEMP.Text.Trim()
                        OBJEMP.ShowDialog()
                        dt = objclscommon.search("EMP_ID", "", " EMPLOYEEMASTER ", " and EMP_name = '" & CMPEMP.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMPEMP.DataSource
                            If CMPEMP.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMPEMP.Text.Trim)
                                    CMPEMP.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLFAMILY(ByRef CMBFAMILY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBFAMILY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" FAMILY_name ", "", " FAMILYMaster", " and FAMILY_cmpid=" & CmpId & " AND FAMILY_LOCATIONID = " & Locationid & " AND FAMILY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FAMILY_name"
                    CMBFAMILY.DataSource = dt
                    CMBFAMILY.DisplayMember = "FAMILY_name"
                    If edit = False Then CMBFAMILY.Text = ""
                End If
                CMBFAMILY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FAMILYVALIDATE(ByRef CMBFAMILY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBFAMILY.Text.Trim <> "" Then
                pcase(CMBFAMILY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FAMILY_id", "", "FAMILYMaster", " and FAMILY_NAME = '" & CMBFAMILY.Text.Trim & "' and FAMILY_cmpid = " & CmpId & " and FAMILY_LOCATIONid = " & Locationid & " and FAMILY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("FAMILY not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBFAMILY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsFAMILY As New ClsFamilyMaster
                        objclsFAMILY.alParaval = alParaval
                        Dim IntResult As Integer = objclsFAMILY.SAVE()
                    Else
                        CMBFAMILY.Focus()
                        CMBFAMILY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLUSER(ByRef CMBUSER As ComboBox, ByRef edit As Boolean)
        Try
            If CMBUSER.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DISTINCT USER_name ", "", " USERMaster", " and USER_cmpid=" & CmpId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "USER_name"
                    CMBUSER.DataSource = dt
                    CMBUSER.DisplayMember = "USER_name"
                    If edit = False Then CMBUSER.Text = ""
                End If
                CMBUSER.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub USERVALIDATE(ByRef CMBUSER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBUSER.Text.Trim <> "" Then
                pcase(CMBUSER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("USER_ID", "", " USERMASTER ", " and USER_NAME = '" & CMBUSER.Text.Trim & "' AND USER_CMPID = " & CmpId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBUSER.Text.Trim
                    Dim tempmsg As Integer = MsgBox("USER not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMBUSER.Text = a
                        Dim OBJUSER As New UserMaster
                        OBJUSER.txtusername.Text = CMBUSER.Text.Trim()
                        OBJUSER.ShowDialog()
                        dt = objclscommon.search("USER_add", "", " OFFCIERMASTER ", " and USER_cmpname = '" & CMBUSER.Text.Trim & "' AND USER_CMPID = " & CmpId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBUSER.DataSource
                            If CMBUSER.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBUSER.Text.Trim)
                                    CMBUSER.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If

                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSENTBY(ByRef CMBSENTBY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSENTBY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SENTBY_name ", "", " SENTBYMaster", " and SENTBY_cmpid=" & CmpId & " AND SENTBY_LOCATIONID = " & Locationid & " AND SENTBY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SENTBY_name"
                    CMBSENTBY.DataSource = dt
                    CMBSENTBY.DisplayMember = "SENTBY_name"
                    If edit = False Then CMBSENTBY.Text = ""
                End If
                CMBSENTBY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENTBYVALIDATE(ByRef CMBSENTBY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSENTBY.Text.Trim <> "" Then
                pcase(CMBSENTBY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SENTBY_id", "", "SENTBYMaster", " and SENTBY_NAME = '" & CMBSENTBY.Text.Trim & "' and SENTBY_cmpid = " & CmpId & " and SENTBY_LOCATIONid = " & Locationid & " and SENTBY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SENTBY not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSENTBY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSENTBY As New ClsSentByMaster
                        objclsSENTBY.alParaval = alParaval
                        Dim IntResult As Integer = objclsSENTBY.save()
                    Else
                        CMBSENTBY.Focus()
                        CMBSENTBY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLINMODE(ByRef CMBINMODE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBINMODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" INMODE_name ", "", " INMODEMaster", " and INMODE_cmpid=" & CmpId & " AND INMODE_LOCATIONID = " & Locationid & " AND INMODE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "INMODE_name"
                    CMBINMODE.DataSource = dt
                    CMBINMODE.DisplayMember = "INMODE_name"
                    If edit = False Then CMBINMODE.Text = ""
                End If
                CMBINMODE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub INMODEVALIDATE(ByRef CMBINMODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBINMODE.Text.Trim <> "" Then
                pcase(CMBINMODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("INMODE_id", "", "INMODEMaster", " and INMODE_NAME = '" & CMBINMODE.Text.Trim & "' and INMODE_cmpid = " & CmpId & " and INMODE_LOCATIONid = " & Locationid & " and INMODE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("INMODE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBINMODE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsINMODE As New ClsInModeMaster
                        objclsINMODE.alParaval = alParaval
                        Dim IntResult As Integer = objclsINMODE.save()
                    Else
                        CMBINMODE.Focus()
                        CMBINMODE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLDOCTYPE(ByRef CMBDOCTYPE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDOCTYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DOCTYPE_name ", "", " DOCTYPEMaster", " and DOCTYPE_cmpid=" & CmpId & " AND DOCTYPE_LOCATIONID = " & Locationid & " AND DOCTYPE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DOCTYPE_name"
                    CMBDOCTYPE.DataSource = dt
                    CMBDOCTYPE.DisplayMember = "DOCTYPE_name"
                    If edit = False Then CMBDOCTYPE.Text = ""
                End If
                CMBDOCTYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DOCTYPEVALIDATE(ByRef CMBDOCTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDOCTYPE.Text.Trim <> "" Then
                pcase(CMBDOCTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DOCTYPE_id", "", "DOCTYPEMaster", " and DOCTYPE_NAME = '" & CMBDOCTYPE.Text.Trim & "' and DOCTYPE_cmpid = " & CmpId & " and DOCTYPE_LOCATIONid = " & Locationid & " and DOCTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DOCTYPE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDOCTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDOCTYPE As New ClsDocTypeMaster
                        objclsDOCTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsDOCTYPE.save()
                    Else
                        CMBDOCTYPE.Focus()
                        CMBDOCTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLITEMCATEGORY(ByRef CMBITEMCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBITEMCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" ITEMCATEGORY_name ", "", " ITEMCATEGORYMaster", " and ITEMCATEGORY_cmpid=" & CmpId & " AND ITEMCATEGORY_LOCATIONID = " & Locationid & " AND ITEMCATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEMCATEGORY_name"
                    CMBITEMCATEGORY.DataSource = dt
                    CMBITEMCATEGORY.DisplayMember = "ITEMCATEGORY_name"
                    If edit = False Then CMBITEMCATEGORY.Text = ""
                End If
                CMBITEMCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ITEMCATEGORYVALIDATE(ByRef CMBITEMCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBITEMCATEGORY.Text.Trim <> "" Then
                pcase(CMBITEMCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEMCATEGORY_id", "", "ITEMCATEGORYMaster", " and ITEMCATEGORY_NAME = '" & CMBITEMCATEGORY.Text.Trim & "' and ITEMCATEGORY_cmpid = " & CmpId & " and ITEMCATEGORY_LOCATIONid = " & Locationid & " and ITEMCATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("ITEMCATEGORY not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBITEMCATEGORY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsITEMCATEGORY As New ClsItemCategory
                        objclsITEMCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsITEMCATEGORY.save()
                    Else
                        CMBITEMCATEGORY.Focus()
                        CMBITEMCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLITEM(ByRef CMBITEM As ComboBox, ByRef edit As Boolean)
        Try
            If CMBITEM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" ITEM_name ", "", " ITEMMaster", " and ITEM_cmpid=" & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM_name"
                    CMBITEM.DataSource = dt
                    CMBITEM.DisplayMember = "ITEM_name"
                    If edit = False Then CMBITEM.Text = ""
                End If
                CMBITEM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ITEMVALIDATE(ByRef CMBITEM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBITEM.Text.Trim <> "" Then
                pcase(CMBITEM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEM_ID", "", "ITEMMASTER", " and ITEM_name = '" & CMBITEM.Text.Trim & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBITEM.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMBITEM.Text = a
                        Dim OBJITEM As New ItemMaster
                        OBJITEM.TEMPITEMNAME = CMBITEM.Text.Trim()
                        OBJITEM.ShowDialog()
                        dt = objclscommon.search("ITEM_ID", "", "ITEMMASTER", " and ITEM_name = '" & CMBITEM.Text.Trim & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBITEM.DataSource
                            If CMBITEM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBITEM.Text.Trim)
                                    CMBITEM.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLVESSEL(ByRef CMBVESSEL As ComboBox, ByRef edit As Boolean)
        Try
            If CMBVESSEL.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" VESSEL_name ", "", " VESSELMaster", " AND VESSEL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "VESSEL_name"
                    CMBVESSEL.DataSource = dt
                    CMBVESSEL.DisplayMember = "VESSEL_name"
                    If edit = False Then CMBVESSEL.Text = ""
                End If
                CMBVESSEL.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub VESSELVALIDATE(ByRef CMBVESSEL As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBVESSEL.Text.Trim <> "" Then
                pcase(CMBVESSEL)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("VESSEL_id", "", "VESSELMaster", " and VESSEL_NAME = '" & CMBVESSEL.Text.Trim & "' and VESSEL_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("VESSEL not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBVESSEL.Text.Trim)
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim objclsVESSEL As New ClsVesselMaster
                        objclsVESSEL.alParaval = alParaval
                        Dim IntResult As Integer = objclsVESSEL.SAVE()
                    Else
                        CMBVESSEL.Focus()
                        CMBVESSEL.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCATEGORY(ByRef CMBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CATEGORY_name ", "", " CATEGORYMaster", " and CATEGORY_cmpid=" & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CATEGORY_name"
                    CMBCATEGORY.DataSource = dt
                    CMBCATEGORY.DisplayMember = "CATEGORY_name"
                    If edit = False Then CMBCATEGORY.Text = ""
                End If
                CMBCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CATEGORYVALIDATE(ByRef CMBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCATEGORY.Text.Trim <> "" Then
                pcase(CMBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CATEGORY_id", "", "CATEGORYMaster", " and CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_LOCATIONid = " & Locationid & " and CATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CATEGORY not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCATEGORY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCATEGORY As New ClsCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.save()
                    Else
                        CMBCATEGORY.Focus()
                        CMBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLDEPARTMENT(ByRef CMBDEPARTMENT As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEPARTMENT_NAME ", "", " DEPARTMENTMASTER", " and DEPARTMENT_cmpid=" & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEPARTMENT_NAME"
                CMBDEPARTMENT.DataSource = dt
                CMBDEPARTMENT.DisplayMember = "DEPARTMENT_NAME"
                CMBDEPARTMENT.Text = ""
            End If
            CMBDEPARTMENT.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                uppercase(CMBDEPARTMENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEPARTMENT_id", "", "DEPARTMENTMaster", " and DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_LOCATIONid = " & Locationid & " and DEPARTMENT_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEPARTMENT not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEPARTMENT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEPARTMENT As New ClsDepartmentMaster
                        objclsDEPARTMENT.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEPARTMENT.SAVE()
                    Else
                        CMBDEPARTMENT.Focus()
                        CMBDEPARTMENT.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDESIGNATION(ByRef CMBDESIGNATION As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DESIGNATION_NAME ", "", " DESIGNATIONMASTER", " and DESIGNATION_cmpid=" & CmpId & " AND DESIGNATION_LOCATIONID = " & Locationid & " AND DESIGNATION_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DESIGNATION_NAME"
                CMBDESIGNATION.DataSource = dt
                CMBDESIGNATION.DisplayMember = "DESIGNATION_NAME"
                CMBDESIGNATION.Text = ""
            End If
            CMBDESIGNATION.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DESIGNATIONVALIDATE(ByRef CMBDESIGNATION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDESIGNATION.Text.Trim <> "" Then
                uppercase(CMBDESIGNATION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DESIGNATION_id", "", "DESIGNATIONMaster", " and DESIGNATION_NAME = '" & CMBDESIGNATION.Text.Trim & "' and DESIGNATION_cmpid = " & CmpId & " and DESIGNATION_LOCATIONid = " & Locationid & " and DESIGNATION_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DESIGNATION not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDESIGNATION.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDESIGNATION As New ClsDesignationMaster
                        objclsDESIGNATION.alParaval = alParaval
                        Dim IntResult As Integer = objclsDESIGNATION.SAVE()
                    Else
                        CMBDESIGNATION.Focus()
                        CMBDESIGNATION.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCHARGES(ByRef CMBCHARGES As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCHARGES.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CHARGES_name ", "", " CHARGESMaster", " and CHARGES_cmpid=" & CmpId & " AND CHARGES_LOCATIONID = " & Locationid & " AND CHARGES_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CHARGES_name"
                    CMBCHARGES.DataSource = dt
                    CMBCHARGES.DisplayMember = "CHARGES_name"
                    If edit = False Then CMBCHARGES.Text = ""
                End If
                CMBCHARGES.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CHARGESVALIDATE(ByRef CMBCHARGES As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCHARGES.Text.Trim <> "" Then
                pcase(CMBCHARGES)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CHARGES_id", "", "CHARGESMaster", " and CHARGES_NAME = '" & CMBCHARGES.Text.Trim & "' and CHARGES_cmpid = " & CmpId & " and CHARGES_LOCATIONid = " & Locationid & " and CHARGES_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CHARGES not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCHARGES.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCHARGES As New ClsChargesMaster
                        objclsCHARGES.alParaval = alParaval
                        Dim IntResult As Integer = objclsCHARGES.save()
                    Else
                        CMBCHARGES.Focus()
                        CMBCHARGES.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillACCCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ACC_CODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and ACC_cmpid=" & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ACC_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "ACC_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillAGENT(ByRef CMBAGENT As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAGENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    CMBAGENT.DataSource = dt
                    CMBAGENT.DisplayMember = "ACC_cmpname"
                    If edit = False Then CMBAGENT.Text = ""
                End If
                CMBAGENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub AGENTVALIDATE(ByRef CMBAGENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAGENT.Text.Trim <> "" Then
                pcase(CMBAGENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,'')", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & CMBAGENT.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBAGENT.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMBAGENT.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = CMBAGENT.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & CMBAGENT.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBAGENT.DataSource
                            If CMBAGENT.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBAGENT.Text.Trim)
                                    CMBAGENT.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLEMAIL(ByRef CMBEMAIL As ComboBox)
        Try
            If CMBEMAIL.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" EMAIL_name ", "", " EMAILMaster", " and EMAIL_cmpid=" & CmpId & " AND EMAIL_LOCATIONID = " & Locationid & " AND EMAIL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMAIL_name"
                    CMBEMAIL.DataSource = dt
                    CMBEMAIL.DisplayMember = "EMAIL_name"
                    CMBEMAIL.Text = ""
                End If
                CMBEMAIL.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EMAILVALIDATE(ByRef CMBEMAIL As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMAIL.Text.Trim <> "" Then
                lowercase(CMBEMAIL)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMAIL_id", "", "EMAILMaster", " and EMAIL_id = '" & CMBEMAIL.Text.Trim & "' and EMAIL_cmpid = " & CmpId & " and EMAIL_LOCATIONid = " & Locationid & " and EMAIL_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("EMAIL ID not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBEMAIL.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsEMAIL As New ClsEmailMaster
                        objclsEMAIL.alParaval = alParaval
                        Dim IntResult As Integer = objclsEMAIL.save()
                    Else
                        CMBEMAIL.Focus()
                        CMBEMAIL.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcity(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" city_name ", "", " CityMaster", " and city_cmpid=" & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "city_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "city_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CITYVALIDATE(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                uppercase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CITY_id", "", "CITYMaster", " and CITY_NAME = '" & CMBCITY.Text.Trim & "' and CITY_cmpid = " & CmpId & " and CITY_LOCATIONid = " & Locationid & " and CITY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CITY not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCITY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCITY As New ClsCityMaster
                        objclsCITY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCITY.save()
                    Else
                        CMBCITY.Focus()
                        CMBCITY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSTATE(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATE_name ", "", " STATEMaster", " and STATE_cmpid=" & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATE_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "STATE_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATEVALIDATE(ByRef CMBSTATE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATE.Text.Trim <> "" Then
                uppercase(CMBSTATE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATE_id", "", "STATEMaster", " and STATE_NAME = '" & CMBSTATE.Text.Trim & "' and STATE_cmpid = " & CmpId & " and STATE_LOCATIONid = " & Locationid & " and STATE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("STATE not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSTATE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSTATE As New ClsStateMaster
                        objclsSTATE.alParaval = alParaval
                        Dim IntResult As Integer = objclsSTATE.save()
                    Else
                        CMBSTATE.Focus()
                        CMBSTATE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCOUNTRY(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COUNTRY_name ", "", " COUNTRYMaster", " and COUNTRY_cmpid=" & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COUNTRY_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "COUNTRY_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COUNTRYVALIDATE(ByRef CMBCOUNTRY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRY.Text.Trim <> "" Then
                uppercase(CMBCOUNTRY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COUNTRY_id", "", "COUNTRYMaster", " and COUNTRY_NAME = '" & CMBCOUNTRY.Text.Trim & "' and COUNTRY_cmpid = " & CmpId & " and COUNTRY_LOCATIONid = " & Locationid & " and COUNTRY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COUNTRY not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCOUNTRY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCOUNTRY As New ClsCountryMaster
                        objclsCOUNTRY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCOUNTRY.save()
                    Else
                        CMBCOUNTRY.Focus()
                        CMBCOUNTRY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLAREA(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" AREA_name ", "", " AREAMaster", " and AREA_cmpid=" & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "AREA_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "AREA_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AREAVALIDATE(ByRef CMBAREA As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAREA.Text.Trim <> "" Then
                uppercase(CMBAREA)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("AREA_id", "", "AREAMaster", " and AREA_NAME = '" & CMBAREA.Text.Trim & "' and AREA_cmpid = " & CmpId & " and AREA_LOCATIONid = " & Locationid & " and AREA_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("AREA not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBAREA.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsAREA As New ClsAreaMaster
                        objclsAREA.alParaval = alParaval
                        Dim IntResult As Integer = objclsAREA.save()
                    Else
                        CMBAREA.Focus()
                        CMBAREA.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub filltax(ByRef cmbname As ComboBox, ByRef edit As Boolean)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" tax_name ", "", " TaxMaster", " and Tax_cmpid=" & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "tax_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "tax_name"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TAXvalidate(ByRef CMBTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAX.Text.Trim <> "" Then
                pcase(CMBTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTAX.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TAX not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        CMBTAX.Text = a
                        Dim OBJTAX As New Taxmaster
                        OBJTAX.txtname.Text = CMBTAX.Text.Trim()
                        OBJTAX.ShowDialog()
                        dt = objclscommon.search("TAX_name", "", "TAXMaster", " and TAX_name = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBTAX.DataSource
                            If CMBTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTAX.Text.Trim)
                                    CMBTAX.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSOURCE(ByRef CMBSOURCE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSOURCE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SOURCE_name ", "", " SOURCEMaster", " and SOURCE_cmpid=" & CmpId & " AND SOURCE_LOCATIONID = " & Locationid & " AND SOURCE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SOURCE_name"
                    CMBSOURCE.DataSource = dt
                    CMBSOURCE.DisplayMember = "SOURCE_name"
                    If edit = False Then CMBSOURCE.Text = ""
                End If
                CMBSOURCE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SOURCEvalidate(ByRef CMBSOURCE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSOURCE.Text.Trim <> "" Then
                pcase(CMBSOURCE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SOURCE_id", "", "SOURCEMaster", " and SOURCE_NAME = '" & CMBSOURCE.Text.Trim & "' and SOURCE_cmpid = " & CmpId & " and SOURCE_LOCATIONid = " & Locationid & " and SOURCE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SOURCE ID not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSOURCE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSOURCE As New ClsSourceMaster
                        objclsSOURCE.alParaval = alParaval
                        Dim IntResult As Integer = objclsSOURCE.SAVE()
                    Else
                        CMBSOURCE.Focus()
                        CMBSOURCE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLBOOKEDBY(ByRef CMBBOOKEDBY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" BOOKEDBY_name ", "", " BOOKEDBYMaster", " and BOOKEDBY_cmpid=" & CmpId & " AND BOOKEDBY_LOCATIONID = " & Locationid & " AND BOOKEDBY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "BOOKEDBY_name"
                    CMBBOOKEDBY.DataSource = dt
                    CMBBOOKEDBY.DisplayMember = "BOOKEDBY_name"
                    If edit = False Then CMBBOOKEDBY.Text = ""
                End If
                CMBBOOKEDBY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BOOKEDBYvalidate(ByRef CMBBOOKEDBY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBBOOKEDBY.Text.Trim <> "" Then
                pcase(CMBBOOKEDBY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("BOOKEDBY_id", "", "BOOKEDBYMaster", " and BOOKEDBY_NAME = '" & CMBBOOKEDBY.Text.Trim & "' and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_LOCATIONid = " & Locationid & " and BOOKEDBY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("BOOKEDBY ID not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBBOOKEDBY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsBOOKEDBY As New ClsBookedByMaster
                        objclsBOOKEDBY.alParaval = alParaval
                        Dim IntResult As Integer = objclsBOOKEDBY.SAVE()
                    Else
                        CMBBOOKEDBY.Focus()
                        CMBBOOKEDBY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUPOFHOTELS(ByRef CMBGROUPOFHOTELS As ComboBox)
        Try
            If CMBGROUPOFHOTELS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GROUPOFHOTELS_name ", "", " GROUPOFHOTELSMaster", " and GROUPOFHOTELS_cmpid=" & CmpId & " AND GROUPOFHOTELS_LOCATIONID = " & Locationid & " AND GROUPOFHOTELS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GROUPOFHOTELS_name"
                    CMBGROUPOFHOTELS.DataSource = dt
                    CMBGROUPOFHOTELS.DisplayMember = "GROUPOFHOTELS_name"
                    CMBGROUPOFHOTELS.Text = ""
                End If
                CMBGROUPOFHOTELS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GROUPOFHOTELSVALIDATE(ByRef CMBGROUPOFHOTELS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGROUPOFHOTELS.Text.Trim <> "" Then
                uppercase(CMBGROUPOFHOTELS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GROUPOFHOTELS_id", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_NAME = '" & CMBGROUPOFHOTELS.Text.Trim & "' and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_LOCATIONid = " & Locationid & " and GROUPOFHOTELS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Group Of Hotels not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGROUPOFHOTELS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJGROUP As New ClsGroupOfHotelsMaster
                        OBJGROUP.alParaval = alParaval
                        Dim IntResult As Integer = OBJGROUP.SAVE()
                    Else
                        CMBGROUPOFHOTELS.Focus()
                        CMBGROUPOFHOTELS.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ACCCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBACCNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_CMPNAME, ACC_ADD", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsCode = CMBCODE.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_CODE", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBACCNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ledgervalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                'pcase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,'')", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    CMBACCCODE.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillROOMTYPE(ByRef CMBROOMTYPE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ROOMTYPE_NAME ", "", " ROOMTYPEMASTER", " and ROOMTYPE_cmpid=" & CmpId & " AND ROOMTYPE_LOCATIONID = " & Locationid & " AND ROOMTYPE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ROOMTYPE_NAME"
                CMBROOMTYPE.DataSource = dt
                CMBROOMTYPE.DisplayMember = "ROOMTYPE_NAME"
                CMBROOMTYPE.Text = ""
            End If
            CMBROOMTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ROOMTYPEVALIDATE(ByRef CMBROOMTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBROOMTYPE.Text.Trim <> "" Then
                uppercase(CMBROOMTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ROOMTYPE_id", "", "ROOMTYPEMaster", " and ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' and ROOMTYPE_cmpid = " & CmpId & " and ROOMTYPE_LOCATIONid = " & Locationid & " and ROOMTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("ROOMTYPE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBROOMTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsROOMTYPE As New ClsRoomTypeMaster
                        objclsROOMTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsROOMTYPE.SAVE()
                    Else
                        CMBROOMTYPE.Focus()
                        CMBROOMTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillHOTELTYPE(ByRef CMBHOTELTYPE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTELTYPE_NAME ", "", " HOTELTYPEMASTER", " and HOTELTYPE_cmpid=" & CmpId & " AND HOTELTYPE_LOCATIONID = " & Locationid & " AND HOTELTYPE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTELTYPE_NAME"
                CMBHOTELTYPE.DataSource = dt
                CMBHOTELTYPE.DisplayMember = "HOTELTYPE_NAME"
                CMBHOTELTYPE.Text = ""
            End If
            CMBHOTELTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELTYPEVALIDATE(ByRef CMBHOTELTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHOTELTYPE.Text.Trim <> "" Then
                uppercase(CMBHOTELTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("HOTELTYPE_id", "", "HOTELTYPEMaster", " and HOTELTYPE_NAME = '" & CMBHOTELTYPE.Text.Trim & "' and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_LOCATIONid = " & Locationid & " and HOTELTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("HOTELTYPE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBHOTELTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsHOTELTYPE As New ClsHotelTypeMaster
                        objclsHOTELTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsHOTELTYPE.SAVE()
                    Else
                        CMBHOTELTYPE.Focus()
                        CMBHOTELTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillHOTELCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTEL_CODE ", "", " HOTELMASTER", " and HOTEL_cmpid=" & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTEL_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "HOTEL_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBHOTELNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox)
        Try

            If CMBCODE.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" HOTEL_NAME, HOTEL_ADD ", "", "HOTELMASTER", " and HOTEL_CODE = '" & CMBCODE.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJHOTEL As New HotelMaster
                        OBJHOTEL.cmbcode.Text = CMBCODE.Text.Trim()
                        OBJHOTEL.ShowDialog()
                        dt = objclscommon.search(" HOTEL_CODE ", "", "HOTELMASTER", " and HOTEL_CODE = '" & CMBCODE.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBHOTELNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillHOTEL(ByRef CMBHOTELNAME As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTEL_NAME ", "", " HOTELMASTER", " and HOTEL_cmpid=" & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTEL_NAME"
                CMBHOTELNAME.DataSource = dt
                CMBHOTELNAME.DisplayMember = "HOTEL_NAME"
                CMBHOTELNAME.Text = ""
            End If
            CMBHOTELNAME.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELvalidate(ByRef CMBHOTEL As ComboBox, ByVal CMBCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox)
        Try

            If CMBHOTEL.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" HOTEL_CODE, HOTEL_ADD ", "", "HOTELMASTER", " and HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Hotel not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJHOTEL As New HotelMaster
                        OBJHOTEL.CMBHOTELNAME.Text = CMBHOTEL.Text.Trim()
                        OBJHOTEL.ShowDialog()
                        dt = objclscommon.search(" HOTEL_NAME ", "", "HOTELMASTER", " and HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBHOTEL.Text.Trim
                            dt1 = CMBHOTEL.DataSource
                            If CMBHOTEL.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHOTEL.Text.Trim)
                                    CMBHOTEL.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBCODE.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLNATURE(ByRef CMBNATURE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" PAY_name ", "", " NATUREOFPAYMENTMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PAY_name"
                CMBNATURE.DataSource = dt
                CMBNATURE.DisplayMember = "PAY_name"
                CMBNATURE.Text = ""
            End If
            CMBNATURE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATUREVALIDATE(ByRef CMBNATURE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATURE.Text.Trim <> "" Then
                uppercase(CMBNATURE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAY_id", "", "NATUREOFPAYMENTMASTER", " and PAY_NAME = '" & CMBNATURE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("NATURE OF PAYMENT not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBNATURE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJNATUREOFPAYMENT As New ClsNatureOfPayment
                        OBJNATUREOFPAYMENT.alParaval = alParaval
                        Dim IntResult As Integer = OBJNATUREOFPAYMENT.SAVE()
                    Else
                        CMBNATURE.Focus()
                        CMBNATURE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDEDUCTEETYPE(ByRef cmbDEDUCTEE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEDUCTEETYPE_name ", "", " DEDUCTEETYPEMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.DataSource = dt
                cmbDEDUCTEE.DisplayMember = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.Text = ""
            End If
            cmbDEDUCTEE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEDUCTEETYPEVALIDATE(ByRef CMBDEDUCTEETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                uppercase(CMBDEDUCTEETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEDUCTEETYPE_id", "", "DEDUCTEETYPEMASTER", " and DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEDUCTEETYPE not present, Add New?", MsgBoxStyle.YesNo, "MNOWF")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEDUCTEETYPE As New ClsDeducteetypeMaster
                        objclsDEDUCTEETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEDUCTEETYPE.SAVE()
                    Else
                        CMBDEDUCTEETYPE.Focus()
                        CMBDEDUCTEETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillunit(ByRef cmbunit As ComboBox)
        Try
            If cmbunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", " UnitMaster ", " and unit_cmpid=" & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "unit_abbr"
                    cmbunit.DataSource = dt
                    cmbunit.DisplayMember = "unit_abbr"
                    cmbunit.Text = ""
                End If
                cmbunit.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub unitvalidate(ByRef cmbunit As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbunit.Text.Trim <> "" Then
                lowercase(cmbunit)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Unit not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objunitmaster As New UnitMaster
                        objunitmaster.frmString = "UNIT"
                        objunitmaster.txtabbr.Text = cmbunit.Text.Trim()
                        objunitmaster.ShowDialog()
                        dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = cmbunit.Text.Trim
                            dt1 = cmbunit.DataSource
                            If cmbunit.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbunit.Text.Trim)
                                    cmbunit.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

#Region "FUNCTION FOR EMAIL"
    'Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0, Optional ByVal TEMPATTACHMENT1 As String = "", Optional ByVal TEMPATTACHMENT2 As String = "", Optional ByVal TEMPATTACHMENT3 As String = "", Optional ByVal TEMPATTACHMENT4 As String = "", Optional ByVal TEMPATTACHMENT5 As String = "", Optional ByVal TEMPATTACHMENT6 As String = "")

    'Dim mailBody As String
    'Try
    '        Cursor.Current = Cursors.WaitCursor

    '        'create the mail message
    '        Dim mail As New MailMessage
    '        Dim MAILATTACHMENT As Attachment

    '        'set the addresses
    '        'mail.From = New MailAddress("siddhivinayaksynthetics@gmail.com", CmpName)
    '        'mail.From = New MailAddress("gulkitjain@gmail.com", "TexPro V1.0")

    '        mail.To.Add(toMail)

    '        '''' GIVING ISSUE IN DIRECT MULTIPLE PRINT IN INVOICE.
    '        ''set the content
    '        'mail.Subject = subject
    '        'mail.Body = mailbody
    '        'mail.IsBodyHtml = True
    '        'MAILATTACHMENT = New Attachment(tempattachment)
    '        'mail.Attachments.Add(MAILATTACHMENT)

    '        'If TEMPATTACHMENT1 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT1)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If

    '        'If TEMPATTACHMENT2 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT2)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If

    '        'If TEMPATTACHMENT3 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT3)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If

    '        'If TEMPATTACHMENT4 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT4)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If


    '        'If TEMPATTACHMENT5 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT5)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If

    '        'If TEMPATTACHMENT6 <> "" Then
    '        '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT6)
    '        '    mail.Attachments.Add(MAILATTACHMENT)
    '        'End If

    '        'set the content
    '        mail.Subject = subject
    '        mail.Body = mailbody
    '        mail.IsBodyHtml = True
    '        If NOOFATTACHMENTS <= 1 Then
    '            If ALATTACHMENT.Count > 0 Then MAILATTACHMENT = New Attachment(ALATTACHMENT(0)) Else MAILATTACHMENT = New Attachment(tempattachment)
    '            mail.Attachments.Add(MAILATTACHMENT)
    '        Else
    '            For I As Integer = 0 To NOOFATTACHMENTS - 1
    '                MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
    '                mail.Attachments.Add(MAILATTACHMENT)
    '            Next
    '        End If


    '        'send the message
    '        Dim smtp As New SmtpClient

    '        'set username and password
    '        Dim nc As New System.Net.NetworkCredential


    '        'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
    '        Dim OBJCMN As New ClsCommon
    '        Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
    '        If DT.Rows.Count > 0 Then
    '            If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")
    '            'smtp.Port = (25)
    '            smtp.Port = (587)


    '            smtp.EnableSsl = True
    '            mail.From = New MailAddress(DT.Rows(0).Item("EMAIL"), CmpName)
    '            nc.UserName = DT.Rows(0).Item("EMAIL")
    '            nc.Password = DT.Rows(0).Item("PASS") '"qhokuzymfmcxtoge"

    '        Else

    '            smtp.Host = "smtp.gmail.com"
    '            'smtp.Port = (25)
    '            smtp.Port = (587)
    '            smtp.EnableSsl = True

    '            mail.From = New MailAddress("noreply.mnowf@gmail.com", CmpName)
    '            nc.UserName = "noreply.mnowf@gmail.com"
    '            nc.Password = "tlaztqqpfbelzglr"

    '        End If


    '        'smtp.Timeout = 20000
    '        smtp.Timeout = 50000

    '        smtp.Credentials = nc

    '        smtp.Send(mail)
    '        mail.Dispose()

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0, Optional ByVal TEMPATTACHMENT1 As String = "", Optional ByVal TEMPATTACHMENT2 As String = "", Optional ByVal TEMPATTACHMENT3 As String = "", Optional ByVal TEMPATTACHMENT4 As String = "", Optional ByVal TEMPATTACHMENT5 As String = "", Optional ByVal TEMPATTACHMENT6 As String = "")

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment

            'set the addresses
            'mail.From = New MailAddress("siddhivinayaksynthetics@gmail.com", CmpName)
            'mail.From = New MailAddress("gulkitjain@gmail.com", "TexPro V1.0")

            mail.To.Add(toMail)

            '''' GIVING ISSUE IN DIRECT MULTIPLE PRINT IN INVOICE.
            ''set the content
            'mail.Subject = subject
            'mail.Body = mailbody
            'mail.IsBodyHtml = True
            'MAILATTACHMENT = New Attachment(tempattachment)
            'mail.Attachments.Add(MAILATTACHMENT)

            'If TEMPATTACHMENT1 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT1)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT2 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT2)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT3 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT3)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT4 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT4)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If


            'If TEMPATTACHMENT5 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT5)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT6 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT6)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'set the content
            mail.Subject = subject
            mail.Body = mailbody
            mail.IsBodyHtml = True
            If NOOFATTACHMENTS <= 1 Then
                If ALATTACHMENT.Count > 0 Then MAILATTACHMENT = New Attachment(ALATTACHMENT(0)) Else MAILATTACHMENT = New Attachment(tempattachment)
                mail.Attachments.Add(MAILATTACHMENT)
            Else
                For I As Integer = 0 To NOOFATTACHMENTS - 1
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
                    mail.Attachments.Add(MAILATTACHMENT)
                Next
            End If


            'send the message
            Dim smtp As New SmtpClient

            'set username and password
            Dim nc As New System.Net.NetworkCredential


            'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")
                'smtp.Port = (25)
                smtp.Port = (587)


                smtp.EnableSsl = True
                mail.From = New MailAddress(DT.Rows(0).Item("EMAIL"), CmpName)
                nc.UserName = DT.Rows(0).Item("EMAIL")
                nc.Password = DT.Rows(0).Item("PASS") '"qhokuzymfmcxtoge"

            Else

                smtp.Host = "smtp.gmail.com"
                'smtp.Port = (25)
                smtp.Port = (587)
                smtp.EnableSsl = True

                mail.From = New MailAddress("noreply.textrade@gmail.com", CmpName)
                nc.UserName = "noreply.textrade@gmail.com"
                nc.Password = "tlaztqqpfbelzglr"

            End If


            'smtp.Timeout = 20000
            smtp.Timeout = 50000

            smtp.Credentials = nc

            smtp.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub



    Sub namevalidate(ByRef cmbname As ComboBox, ByRef CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "", Optional ByVal TYPE As String = "ACCOUNTS", Optional ByRef TRANSNAME As String = "", Optional ByRef AGENTNAME As String = "", Optional ByRef WHATSAPPNO As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("isnull(LEDGERS.acc_add,'') as [ADDRESS], isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME, ISNULL(LEDGERS.ACC_WHATSAPPNO,'') AS WHATSAPPNO ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.tempTYPE = TYPE

                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("isnull(LEDGERS.acc_add,'') as [ADDRESS], isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME, ISNULL(LEDGERS.ACC_WHATSAPPNO,'') AS WHATSAPPNO, LEDGERS.ACC_ID AS ACCID ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ACCID"), cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item("ADDRESS")
                    If ClientName = "MVIKASKUMAR" Or ClientName = "SUPRIYA" Then
                        TRANSNAME = dt.Rows(0).Item(2).ToString
                        AGENTNAME = dt.Rows(0).Item(3).ToString
                    Else
                        If TRANSNAME = "" Then TRANSNAME = dt.Rows(0).Item(2).ToString
                        If AGENTNAME = "" Then AGENTNAME = dt.Rows(0).Item(3).ToString
                    End If
                    If WHATSAPPNO = "" Then WHATSAPPNO = dt.Rows(0).Item("WHATSAPPNO")
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub
    'Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal DEC As Boolean = False, Optional ByVal DOM As Boolean = False, Optional ByVal HOSP As Boolean = False, Optional ByVal EDU As Boolean = False, Optional ByVal BOOKING As Boolean = False)

    '    'Dim mailBody As String
    '    Try
    '        Cursor.Current = Cursors.WaitCursor

    '        'create the mail message
    '        Dim mail As New MailMessage
    '        Dim MAILATTACHMENT As Attachment
    '        Dim DECLARATION As Attachment
    '        Dim DOMICILIARY As Attachment
    '        Dim HOSPITALISATION As Attachment
    '        Dim EDUCATION As Attachment
    '        Dim HOLIDAYBOOKING As Attachment

    '        'set the addresses
    '        mail.From = New MailAddress("mnowf@hathway.com", "MNOWF")
    '        mail.To.Add(toMail)


    '        'set the content
    '        mail.Subject = subject
    '        mail.Body = mailbody
    '        mail.IsBodyHtml = True
    '        If tempattachment <> "" Then
    '            MAILATTACHMENT = New Attachment(tempattachment)
    '            mail.Attachments.Add(MAILATTACHMENT)
    '        End If


    '        If DEC = True Then
    '            DECLARATION = New Attachment(Application.StartupPath & "\DOCS\Declaration.Pdf")
    '            mail.Attachments.Add(DECLARATION)
    '        End If

    '        If DOM = True Then
    '            DOMICILIARY = New Attachment(Application.StartupPath & "\DOCS\Domiciliary.Pdf")
    '            mail.Attachments.Add(DOMICILIARY)
    '        End If

    '        If HOSP = True Then
    '            HOSPITALISATION = New Attachment(Application.StartupPath & "\DOCS\Hospitalisation.Pdf")
    '            mail.Attachments.Add(HOSPITALISATION)
    '        End If

    '        If EDU = True Then
    '            EDUCATION = New Attachment(Application.StartupPath & "\DOCS\Education.Pdf")
    '            mail.Attachments.Add(EDUCATION)
    '        End If

    '        If BOOKING = True Then
    '            HOLIDAYBOOKING = New Attachment(Application.StartupPath & "\DOCS\Bookings.Pdf")
    '            mail.Attachments.Add(HOLIDAYBOOKING)
    '        End If


    '        'send the message
    '        Dim smtp As New SmtpClient

    '        'set username and password
    '        Dim nc As New System.Net.NetworkCredential


    '        'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
    '        Dim OBJCMN As New ClsCommon
    '        Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
    '        If DT.Rows.Count > 0 Then
    '            If DT.Rows(0).Item("SMTP") = "" Then
    '                smtp.Host = "smtp.gmail.com"
    '            Else
    '                smtp.Host = DT.Rows(0).Item("SMTP")
    '            End If
    '            smtp.Port = (25)
    '            smtp.EnableSsl = False

    '            nc.UserName = DT.Rows(0).Item("EMAIL")
    '            nc.Password = DT.Rows(0).Item("PASS")

    '        Else

    '            smtp.Host = "smtp.gmail.com"
    '            smtp.Port = (25)
    '            smtp.EnableSsl = True

    '            nc.UserName = "gulkitjain@gmail.com"
    '            nc.Password = "gulkit3042"

    '        End If

    '        'System.Net.NetworkCredential(nc = New System.Net.NetworkCredential("customerservice@thecareerspectrum.com", "12345678"))
    '        smtp.Credentials = nc
    '        smtp.Send(mail)
    '        mail.Dispose()

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

#End Region

    Function checkrowlinedel(ByVal gridsrno As Integer, ByVal txtno As System.Windows.Forms.TextBox) As Boolean
        Dim bln As Boolean = True
        If gridsrno = txtno.Text.Trim Then
            bln = False
        End If
        Return bln
    End Function

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord
    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        Dim i As Integer
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

End Module
