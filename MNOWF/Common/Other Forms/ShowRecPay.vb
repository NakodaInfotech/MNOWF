
Imports BL

Public Class ShowRecPay

    Public PURBILLINITIALS As String
    Public SALEBILLINITIALS As String

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ShowRecPay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ShowRecPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" T.[Bill No] , T.Amt , T.BILLINITIALS, T.REGTYPE , T.TYPE ", "", " ( SELECT JOURNALMASTER.JOURNAL_initials AS [Bill No], CASE WHEN SUM(JOURNALMASTER.JOURNAL_debit) > 0 THEN SUM(JOURNALMASTER.JOURNAL_debit) ELSE SUM(JOURNALMASTER.journal_credit) END AS Amt, JOURNALMASTER.JOURNAL_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'JOURNAL' AS TYPE FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.JOURNAL_registerid = REGISTERMASTER.register_id AND JOURNALMASTER.JOURNAL_cmpid = REGISTERMASTER.register_cmpid AND JOURNALMASTER.JOURNAL_locationid = REGISTERMASTER.register_locationid AND JOURNALMASTER.JOURNAL_yearid = RegisterMaster.register_yearid  WHERE JOURNALMASTER.journal_CMPID = " & CmpId & " AND JOURNALMASTER.journal_LOCATIONID = " & Locationid & " AND JOURNALMASTER.journal_YEARID = " & YearId & " AND (JOURNALMASTER.journal_refno = '" & PURBILLINITIALS & "' OR JOURNALMASTER.journal_refno = '" & SALEBILLINITIALS & "') GROUP BY JOURNALMASTER.JOURNAL_no, JOURNALMASTER.JOURNAL_initials, REGISTERMASTER.register_name   UNION ALL SELECT PAYMENTMASTER_DESC.PAYMENT_initials AS [Bill No], SUM(PAYMENTMASTER_DESC.PAYMENT_amt) AS Amt, PAYMENTMASTER_DESC.PAYMENT_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'PAYMENT' AS TYPE FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON PAYMENTMASTER_DESC.PAYMENT_registerid = REGISTERMASTER.register_id AND PAYMENTMASTER_DESC.PAYMENT_cmpid = REGISTERMASTER.register_cmpid AND PAYMENTMASTER_DESC.PAYMENT_locationid = REGISTERMASTER.register_locationid AND PAYMENTMASTER_DESC.PAYMENT_yearid = RegisterMaster.register_yearid WHERE PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId & " AND PAYMENT_BILLINITIALS = '" & PURBILLINITIALS & "' GROUP BY PAYMENTMASTER_DESC.PAYMENT_no, PAYMENTMASTER_DESC.PAYMENT_initials, REGISTERMASTER.register_name  UNION  ALL SELECT RECEIPTMASTER_DESC.RECEIPT_initials AS [Bill No], SUM(RECEIPTMASTER_DESC.RECEIPT_amt) AS Amt, RECEIPTMASTER_DESC.RECEIPT_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'RECEIPT' AS TYPE FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON RECEIPTMASTER_DESC.RECEIPT_registerid = REGISTERMASTER.register_id AND RECEIPTMASTER_DESC.RECEIPT_cmpid = REGISTERMASTER.register_cmpid AND RECEIPTMASTER_DESC.RECEIPT_locationid = REGISTERMASTER.register_locationid AND RECEIPTMASTER_DESC.RECEIPT_yearid = REGISTERMASTER.register_yearid WHERE RECEIPT_CMPID = " & CmpId & " AND RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPT_YEARID = " & YearId & " AND RECEIPT_BILLINITIALS = '" & SALEBILLINITIALS & "' GROUP BY RECEIPTMASTER_DESC.RECEIPT_no, RECEIPTMASTER_DESC.RECEIPT_initials, REGISTERMASTER.register_name UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS [Bill No], CREDITNOTEMASTER.CN_GTOTAL AS Amt, CN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'CREDITNOTE' AS TYPE FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id AND CREDITNOTEMASTER.CN_cmpid = REGISTERMASTER.register_cmpid AND CREDITNOTEMASTER.CN_locationid = REGISTERMASTER.register_locationid AND CREDITNOTEMASTER.CN_yearid = REGISTERMASTER.register_yearid WHERE CN_CMPID = " & CmpId & " AND CN_LOCATIONID = " & Locationid & " AND CN_YEARID = " & YearId & " AND CN_BILLNO = '" & SALEBILLINITIALS & "' UNION ALL SELECT DEBITNOTEMASTER.DN_initials AS [Bill No], DEBITNOTEMASTER.DN_GTOTAL AS Amt, DN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'DEBITNOTE' AS TYPE FROM DEBITNOTEMASTER INNER JOIN REGISTERMASTER ON DEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id AND DEBITNOTEMASTER.DN_cmpid = REGISTERMASTER.register_cmpid AND DEBITNOTEMASTER.DN_locationid = REGISTERMASTER.register_locationid AND DEBITNOTEMASTER.DN_yearid = REGISTERMASTER.register_yearid WHERE DN_CMPID = " & CmpId & " AND DN_LOCATIONID = " & Locationid & " AND DN_YEARID = " & YearId & " AND DN_BILLNO = '" & PURBILLINITIALS & "') AS T ", "")
            If DT.Rows.Count > 0 Then
                GRIDRECPAY.DataSource = DT
                GRIDRECPAY.Columns(0).Width = 150
                GRIDRECPAY.Columns(1).Width = 150
                GRIDRECPAY.Columns(2).Visible = False
                GRIDRECPAY.Columns(3).Visible = False
                GRIDRECPAY.Columns(4).Visible = False

                GRIDRECPAY.Columns(1).DefaultCellStyle.Format = "N2"
                GRIDRECPAY.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            For Each ROW As DataGridViewRow In GRIDRECPAY.SelectedRows

                If ROW.Cells(4).Value.ToString = "PAYMENT" Then

                    Dim OBJPAYMENT As New PaymentMaster
                    OBJPAYMENT.MdiParent = MDIMain
                    OBJPAYMENT.edit = True
                    OBJPAYMENT.TEMPPAYMENTNO = ROW.Cells(2).Value.ToString
                    OBJPAYMENT.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJPAYMENT.Show()

                ElseIf ROW.Cells(4).Value.ToString = "RECEIPT" Then

                    Dim OBJREC As New Receipt
                    OBJREC.MdiParent = MDIMain
                    OBJREC.edit = True
                    OBJREC.TEMPRECEIPTNO = ROW.Cells(2).Value.ToString
                    OBJREC.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJREC.Show()

                ElseIf ROW.Cells(4).Value.ToString = "JOURNAL" Then

                    Dim OBJJV As New journal
                    OBJJV.MdiParent = MDIMain
                    OBJJV.edit = True
                    OBJJV.tempjvno = ROW.Cells(2).Value.ToString
                    OBJJV.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJJV.Show()

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECPAY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRECPAY.CellDoubleClick
        Try
            SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class