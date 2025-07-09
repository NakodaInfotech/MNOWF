
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports BL
Imports System.IO

Public Class SendWhatsapp

    Public OFFICERNAME As String = ""
    Public OFFICERNAME1 As String = ""
    Public OFFICERNAME2 As String = ""
    Public OFFICERNAME3 As String = ""
    Public OFFICERNAME4 As String = ""
    Public PATH As New ArrayList
    Public FILENAME As New ArrayList
    Dim RESPONSE As String = ""
    Public FRMSTRING As String = ""
    Public MSG As String = ""
    Public NARRATION As String = ""
    Public AUTOCCNO As String = ""

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Public Sub SendWhatsapp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If FRMSTRING = "DIRECTWHATSAPP" Then FILLGRID()


            'IF AUTOCC IS TRUE THEN GET THE MOBILE NO FROM CMPMASTER AND SHOW IN AUTOCC
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If WHATSAPPAUTOCC = True Then
                DT = OBJCMN.search("ISNULL(CMP_TEL,'') AS MOBILENO", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
                If DT.Rows.Count > 0 Then TXTAUTOCC.Text = DT.Rows(0).Item("MOBILENO")
            Else
                TXTAUTOCC.Text = AUTOCCNO
            End If

            TXTMESSAGE.Text = MSG


            CMBOFFICERNAME.Text = OFFICERNAME
            CMBOFFICERNAME1.Text = OFFICERNAME1
            CMBOFFICERNAME2.Text = OFFICERNAME2
            CMBOFFICERNAME3.Text = OFFICERNAME3
            CMBOFFICERNAME4.Text = OFFICERNAME4

            Dim EN As New CancelEventArgs
            If OFFICERNAME <> "" Then CMBOFFICERNAME_Validating(CMBOFFICERNAME, EN)
            If OFFICERNAME1 <> "" Then CMBOFFICERNAME1_Validating(CMBOFFICERNAME1, EN)
            If OFFICERNAME2 <> "" Then CMBOFFICERNAME2_Validating(CMBOFFICERNAME2, EN)
            If OFFICERNAME3 <> "" Then CMBOFFICERNAME3_Validating(CMBOFFICERNAME3, EN)
            If OFFICERNAME4 <> "" Then CMBOFFICERNAME4_Validating(CMBOFFICERNAME4, EN)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST(0 AS BIT) AS CHK, ISNULL(OFFICERMASTER.OFFICER_cmpid, 0) AS COMPANYNAME, ISNULL(OFFICERMASTER.OFFICER_name, '') AS OFFICERNAME, ISNULL(OFFICERMASTER.OFFICER_RANKID, '') AS RANKID, ISNULL(OFFICERMASTER.OFFICER_mobile, '0') AS MOBNO, RANKMASTER.RANK_NAME AS RANK, COMPANYMASTER.COMPANY_NAME AS COMPANYNAME", "", "  OFFICERMASTER LEFT OUTER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_ID LEFT OUTER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID", "  AND OFFICER_mobile<> '' and OFFICER_yearid = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICERNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBOFFICERNAME.Validating
        Try
            If CMBOFFICERNAME.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICERNAME, e, Me, " AND OFFICERMASTER.OFFICER_yearID=" & YearId, TXTOFFICERNO.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICERNAME1_Validating(sender As Object, e As CancelEventArgs) Handles CMBOFFICERNAME1.Validating
        Try
            If CMBOFFICERNAME1.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICERNAME1, e, Me, " AND OFFICERMASTER.OFFICER_yearID=" & YearId, TXTOFFICERNO1.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICERNAME2_Validating(sender As Object, e As CancelEventArgs) Handles CMBOFFICERNAME2.Validating
        Try
            If CMBOFFICERNAME2.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICERNAME2, e, Me, " AND OFFICERMASTER.OFFICER_yearID=" & YearId, TXTOFFICERNO2.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICERNAME3_Validating(sender As Object, e As CancelEventArgs) Handles CMBOFFICERNAME3.Validating
        Try
            If CMBOFFICERNAME3.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICERNAME3, e, Me, " AND OFFICERMASTER.OFFICER_yearID=" & YearId, TXTOFFICERNO3.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOFFICERNAME4_Validating(sender As Object, e As CancelEventArgs) Handles CMBOFFICERNAME4.Validating
        Try
            If CMBOFFICERNAME4.Text.Trim <> "" Then OFFICERVALIDATE(CMBOFFICERNAME4, e, Me, " AND OFFICERMASTER.OFFICER_yearID=" & YearId, TXTOFFICERNO4.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Async Sub CMDSEND_Click(sender As Object, e As EventArgs) Handles CMDSEND.Click
        Try

            'FIRST CHECK STATUS OF MOBILE CONNECTION
            Dim CONNECTSTATUS As String = JObject.Parse(Await CHECKMOBILECONNECTSTATUS())("success")
            If CONNECTSTATUS = "False" Then
                MsgBox("Mobile Not connected, Please Check Connection", MsgBoxStyle.Critical)
                Exit Sub
            End If



            'For SENDING IMAGES
            'If FRMSTRING = "DIRECTWHATSAPP" Then
            '    ' For i As Integer = 0 To GRIDDESIGN.RowCount - 1
            '    'Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
            '    If Convert.ToBoolean(dtrow("CHK")) = True Then
            '                Dim OBJCMN As New ClsCommon
            '                Dim DTIMG As DataTable = OBJCMN.search("CATALOG_PHOTO AS PHOTO", "", " CATALOGMASTER ", " AND CATALOG_NO = " & dtrow("CATALOGNO") & " AND CATALOG_YEARID = " & YearId)
            '                For Each DR As DataRow In DTIMG.Rows
            '                    Dim _MemoryStream As New System.IO.MemoryStream()
            '                    Dim _BinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            '                    _BinaryFormatter.Serialize(_MemoryStream, DR("PHOTO"))
            '                    _MemoryStream.ToArray()
            '            ' File.WriteAllBytes(Application.StartupPath & “\" & dtrow("ITEMNAME") & dtrow("CATALOGNO") & YearId & ".jpeg”, DirectCast(DR("PHOTO"), Byte()))
            '            'PATH.Add(Application.StartupPath & “\" & dtrow("ITEMNAME") & dtrow("CATALOGNO") & YearId & ".jpeg”)
            '            'FILENAME.Add(dtrow("ITEMNAME") & dtrow("CATALOGNO") & YearId & ".jpeg”)
            '        Next
            '            End If
            '        Next
            '    End If


            ' If PATH.Count = 0 Then Exit Sub


            For I As Integer = 0 To PATH.Count - 1
                If TXTOFFICERNO.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOFFICERNO.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOFFICERNO.Text)
                End If
                If TXTOFFICERNO1.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOFFICERNO1.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOFFICERNO1.Text)
                End If
                If TXTOFFICERNO2.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOFFICERNO2.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOFFICERNO2.Text)
                End If
                If TXTOFFICERNO3.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOFFICERNO3.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOFFICERNO3.Text)
                End If
                If TXTOFFICERNO4.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOFFICERNO4.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTOFFICERNO4.Text)
                End If
                If TXTAUTOCC.Text.Trim <> "" Then
                    RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTAUTOCC.Text.Trim, PATH(I), FILENAME(I))
                    ERRORMESSAGE(TXTAUTOCC.Text)
                End If


                'SENDING WHATSAPP TO MULTIPLE LEDGERS SELECTED
                If FRMSTRING = "DIRECTWHATSAPP" Then
                    For J As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(J)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & dtrow("MOBNO"), PATH(I), FILENAME(I))
                            ERRORMESSAGE(dtrow("MOBNO"))
                        End If
                    Next
                End If
            Next


            'DELETE ALL THE FILES IN PATH ARRAY
            If FRMSTRING = "DIRECTWHATSAPP" Then
                For I As Integer = 0 To PATH.Count - 1
                    If File.Exists(PATH(I)) Then File.Delete(PATH(I))
                Next
            End If


            'TEXT MESSAGE SHOULD BE SEND ONLY ONCE
            If TXTMESSAGE.Text.Trim <> "" Then
                If TXTOFFICERNO.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOFFICERNO.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOFFICERNO1.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOFFICERNO1.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOFFICERNO2.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOFFICERNO2.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOFFICERNO3.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOFFICERNO3.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTOFFICERNO4.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOFFICERNO4.Text.Trim, TXTMESSAGE.Text.Trim)
                If TXTAUTOCC.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTAUTOCC.Text.Trim, TXTMESSAGE.Text.Trim)

                'SENDING WHATSAPP TO MULTIPLE LEDGERS SELECTED
                If FRMSTRING = "DIRECTWHATSAPP" Then
                    For J As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(J)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            RESPONSE = Await SENDWHATSAPPMESSAGE("91" & dtrow("MOBNO"), TXTMESSAGE.Text.Trim)
                        End If
                    Next
                End If
            End If


            MsgBox("Message Sent", MsgBoxStyle.Information)
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ERRORMESSAGE(NO As String)
        Try
            If RESPONSE <> "" Then
                Dim STATUS As String = JObject.Parse(RESPONSE)("success")
                Dim ERRORMSG As String = JObject.Parse(RESPONSE)("message")
                If STATUS = "False" Then MsgBox("Error While Sending Msg to " & NO & ", Error - " & ERRORMSG & ", Response - " & RESPONSE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendWhatsapp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If FRMSTRING = "DIRECTWHATSAPP" Then TabControl1.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class