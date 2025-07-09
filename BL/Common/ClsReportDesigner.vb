
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data
Imports Microsoft.Office.Interop

Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try
                For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                    proc.Kill()
                Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Sample"

    Public Function RPT_SampleGeneral_Loading(ByVal intPDIID As Integer, ByVal strPUser As String) As Object
        Try
            Dim id As Integer = 0
            Dim intJ As Integer = 0
            Dim intTotal As Integer = 0
            Dim intSrNo As Integer = 0
            Dim intRowStart, intRowEnd As Integer
            Dim drRow As DataRow
            Dim drNew As System.Data.DataRow = Nothing
            Dim dtTable As New System.Data.DataTable
            Dim dtSetItem As New System.Data.DataTable
            Dim dtChild As New System.Data.DataTable
            Dim objDispatch As New Object()

            'BrandPromotion.clsSampleDispatch()
            'Dim Tot1, Tot2, tot3, Tot4 As Double
            'Dim Gt1, Gt2, Gt3 As Double
            'Dim dvTemp As DataView
            'dtTable = objDispatch.DispatchChitReport(intPDIID)
            'If dtTable.Rows.Count = 0 Then Return Nothing
            'dtChild = objDispatch.DispatchChitReportCHILD(intPDIID)
            'dtSetItem = objDispatch.DispatchChitReportItem(intPDIID)




            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")
            'SetColumn("10", "J")
            'SetColumn("11", "K")
            'SetColumn("12", "L")
            'SetColumn("13", "M")
            'SetColumn("14", "N")
            'SetColumn("15", "O")
            SetColumnWidth("A1", 50)

            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write(_Report_Title, Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("2. Exports of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Gold Exports (non-monetary gold)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Repairs on goods", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Coffee and other Exports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("3. Income Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Interest received on External assets", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Dividends / profits received", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("4. Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(h) Royalties and license fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("5. Transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) NGO inflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("6. Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("7. Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Bank", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("8. Loans", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Loan Received", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Other (Please specify)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Private Sub FetchData(ByVal fromDate As Date, ByVal toDate As Date, ByVal sp_name As String)
        Try
            'Dim conn As New SqlClient.SqlConnection("Data Source=DELL-B0BA70D352\SQLDELL;Initial Catalog=Forex;Integrated Security=True;uid=sa;pwd=admin123;")
            'Dim conn As New SqlClient.SqlConnection("Data Source=.\SQLDELL;Initial Catalog=Project;Integrated Security=True;")
            Dim conn As New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString())


            Dim comm As New SqlClient.SqlCommand()
            conn.Open()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = sp_name
            comm.Parameters.Add(New SqlClient.SqlParameter("@FromDate", fromDate))
            comm.Parameters.Add(New SqlClient.SqlParameter("@ToDate", toDate))
            comm.CommandTimeout = 1000
            Dim adap As New SqlClient.SqlDataAdapter(comm)
            adap.Fill(dsResult)
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillAmount()
        Try

            If dv.Count > 0 Then
                For index As Integer = 1 To dv.Count
                    If dv.Item(index - 1)("CurrencyId") = 1 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 2 Then
                        Write(dv.Item(index - 1)("Amount"), Range("3"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 3 Then
                        Write(dv.Item(index - 1)("Amount"), Range("4"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 4 Then
                        Write(dv.Item(index - 1)("Amount"), Range("5"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 5 Then
                        Write(dv.Item(index - 1)("Amount"), Range("6"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 7 Then
                        Write(dv.Item(index - 1)("Amount"), Range("7"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 9 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RPT_Sales_Report(ByVal fromDate As Date, ByVal toDate As Date) As Object
        Try
            Me.FetchData(fromDate, toDate, "SP_SELECTSO_FOR_EDIT")

            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")

            SetColumnWidth("A1", 50)
            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write("FORM P(Sales)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, , True)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            dv = dsResult.Tables(0).DefaultView

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CurrencyHoldingDiposits'"
            Me.FillAmount()

            RowIndex += 1
            Write("2. Import of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Govt imports (Incl. Govt. Projects)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Private Imports (Incl. Parastatal & NGOs)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PrivateImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Oil Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OilImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Gold Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoldImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iii) Repairs", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='Repairs'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iv) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='GoodsProPortsByCarrier'"
            Me.FillAmount()

            RowIndex += 1
            Write("(v) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsForProcessig'"
            Me.FillAmount()

            RowIndex += 1
            Write("Income Payments", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Interest received on External liabilities", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InterestPaidOnExternalLib'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Dividends / profits paid", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='DividentProfitPaid'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='WagesSalaries'"
            Me.FillAmount()

            RowIndex += 1
            Write("Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransFreight'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransPassanger'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CommunicationService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='ConstructionService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InsuranceDeInsu'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='FinancialService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelBusinessOfficial'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelEducation'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelMedical'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelOtherPersonal'"
            Me.FillAmount()

            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CompAndInfoService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(h) Royalties and licence fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RoyaliAndLicenceFees'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OtherBusinessService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PersonalCultAndReceService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtServices'"
            Me.FillAmount()

            RowIndex += 1
            Write("Transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) NGO Outflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransNGOOutFlows'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransGovtGrants'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransWorkerRemitance'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransOtherTransfer'"
            Me.FillAmount()

            RowIndex += 1
            Write("Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='ForeignDirectEquityInvestment'"
            Me.FillAmount()

            RowIndex += 1
            Write("Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) By Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) By Bank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByBanks'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) By Other", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByOthers'"
            Me.FillAmount()

            RowIndex += 1
            Write("Loans", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) Loans Extended abroad", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanOtherGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanRepaymentPrincipal'"
            Me.FillAmount()

            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='BankBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("Inerbank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBank'"
            Me.FillAmount()

            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

    'Private Function RPT_Purchase_Report_Data() As DataSet

    '    Dim objDbOperation As DBLayer.DB_Operation = New DBLayer.DB_Operation()

    '    Dim strSql As String
    '    strSql = "SELECT * FROM TradingSales"
    '    Return objDbOperation.ExecuteQuery(strSql)

    'End Function

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String)
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            
            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "BANKRECO"

    Public Function BANKRECO(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DT As System.Data.DataTable = OBJRECO.GETDATA()
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Reconciliation Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Booking No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Reco Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Ledger Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                'AS PER JEETU
                'GET ALL DEBIT AMOUNT RECOED
                'I = 0
                'RowIndex += 1
                'Write("Chques Deposited and Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next

                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))



                'AS PER JEETU
                'GET ALL CREDIT AMOUNT
                'I = 0
                'RowIndex += 2
                'Write("Chques Issused and Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next


                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))




                'GET ALL DEBIT AMOUNT
                I = 0
                RowIndex += 1
                Write("Chques Deposited but not Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows

                    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))



                'GET ALL CREDIT AMOUNT
                I = 0
                RowIndex += 2
                Write("Chques Issused but not Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function BANKSTATEMENT(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0
            Dim BALANCE As Double = 0

            Dim DT As System.Data.DataTable = OBJCMN.search("DISTINCT RecoDate AS RECODATE, acc_initials AS BILLINITIALS, AGAINST AS NAME, ChqNo AS CHQNO, dr AS DR, cr AS CR", "", " BANKRECO", " AND BANKRECO.NAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " AND CAST(RECODATE AS DATE) >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(RECODATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "'  ORDER BY RECODATE")


            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Booking No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Bank Pass Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                BALANCE = Val(DTTOTAL.Rows(0).Item("BOOKBAL"))


                'GET ALL DEBIT AMOUNT
                I = 0
                Dim RDATE As Date = Now.Date
                Dim FROW As Boolean = True
                Dim FROMNO As Integer = 0
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    I += 1
                    RowIndex += 1
                    'GET REOCDATE ONLY ONCE
                    If RDATE <> DTROW("RECODATE") Then
                        If FROW = False Then
                            RowIndex += 1
                            Write(DTROW("RECODATE"), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & FROMNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & FROMNO & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)

                            'SET BALANCE
                            BALANCE = (BALANCE + Val(objSheet.Range(Range("7"), Range("7")).Text)) - Val(objSheet.Range(Range("6"), Range("6")).Text)

                            Write(Format(BALANCE, "0.00"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                            SetBorder(RowIndex, Range("1"), Range("8"))
                        End If

                        RowIndex += 2
                        Write(DTROW("RECODATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        RDATE = DTROW("RECODATE")
                        'GET TOTAL OF THE PARTICULAR DATE IF NOT FIRST ROW

                        FROMNO = RowIndex
                    End If
                    Write(DTROW("BILLINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    FROW = False
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))




                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "OFFICER DETAILS"

    Public Function OFFICERDETAILS(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            Dim DT As System.Data.DataTable = objCMN.search(" OFFICERMASTER.OFFICER_name AS NAME, RANKMASTER.RANK_NAME AS RANK, COMPANYMASTER.COMPANY_NAME AS COMPANY, ISNULL(OFFICERMASTER.OFFICER_EMPCODE,'') AS EMPCODE, OFFICERMASTER.OFFICER_DOJ AS DOJ, OFFICERMASTER.OFFICER_INDIAN AS INDIAN, OFFICERMASTER.OFFICER_CONTRACT AS CONTRACT, OFFICERMASTER.OFFICER_CONTRIBUTION AS CONTRIBUTION, OFFICERMASTER.OFFICER_DONATION AS DONATION, OFFICERMASTER.OFFICER_DECDATE AS DECDATE, ISNULL(OFFICERMASTER.OFFICER_std,'') AS STD, ISNULL(OFFICERMASTER.OFFICER_mobile,'') AS MOBILE, ISNULL(OFFICERMASTER.OFFICER_fax,'') AS FAX, ISNULL(OFFICERMASTER.OFFICER_resino,'') AS RESINO, ISNULL(OFFICERMASTER.OFFICER_MUINO,'') AS MUINO, ISNULL(OFFICERMASTER.OFFICER_email,'') AS EMAIL, ISNULL(OFFICERMASTER.OFFICER_SERVICE,'') AS SERVICE, ISNULL(OFFICERMASTER.OFFICER_add,'') AS [ADD], ISNULL(OFFICERMASTER.OFFICER_remarks,'') AS REMARKS, OFFICER_id AS MNOWFNO", "", " OFFICERMASTER INNER JOIN RANKMASTER ON OFFICERMASTER.OFFICER_RANKID = RANKMASTER.RANK_ID AND OFFICERMASTER.OFFICER_cmpid = RANKMASTER.RANK_CMPID AND OFFICERMASTER.OFFICER_locationid = RANKMASTER.RANK_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = RANKMASTER.RANK_YEARID INNER JOIN COMPANYMASTER ON OFFICERMASTER.OFFICER_COMPANYID = COMPANYMASTER.COMPANY_ID AND OFFICERMASTER.OFFICER_cmpid = COMPANYMASTER.COMPANY_CMPID AND OFFICERMASTER.OFFICER_locationid = COMPANYMASTER.COMPANY_LOCATIONID AND OFFICERMASTER.OFFICER_yearid = COMPANYMASTER.COMPANY_YEARID", CONDITION & " AND OFFICER_CMPID = " & CMPID & " AND OFFICER_LOCATIONID = " & LOCATIONID & " AND OFFICER_YEARID = " & YEARID)

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 16)
            Next

            'SetColumnWidth("H1", 15)
            'SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex += 1
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("11"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("11"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("11"))

            RowIndex += 1
            Write("OFFICERS' DETAILS", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("11"))

            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("11").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("11").ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex, Range("1"), Range("11"))

            RowIndex += 2
            Write("Officers' Name", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Company's Name", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            Write("Rank", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("MUI No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Address", Range("6"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            Write("Tel No", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Mobile No", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Email ID", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            
            SetBorder(RowIndex, Range("1"), Range("11"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("NAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(dr("COMPANY"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), False, 10, True)
                Write(dr("RANK"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(dr("MUINO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(dr("ADD"), Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10, True)
                Write(dr("MOBILE"), Range("9"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(dr("RESINO"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(dr("EMAIL"), Range("11"), XlHAlign.xlHAlignLeft, , False, 10, True)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("1"))
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - DT.Rows.Count, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("5"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - DT.Rows.Count, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("11"))
            
            'RowIndex += 1
            'Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            'Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            'Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            'SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            'SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            'objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            'objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("11").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "INVOICE SUMMARY REPORT"

    Public Function INVOICE_SUMMARY_EXCEL(ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_DATE AS DATE, CUSTOMERMASTER.Customer_cmpname AS NAME, INVOICEMASTER.INVOICE_ORDERNO AS PONO, INVOICEMASTER.INVOICE_ORDERDATE AS PODATE, SUM(INVOICEMASTER_DESC.INVOICE_QTY) AS TOTALSETS, INVOICEMASTER.INVOICE_GRANDTOTAL AS TOTALAMT, (CASE WHEN SUM(INVOICE_QTY) < SALEORDER.SO_TOTALQTY THEN 'PENDING' ELSE 'COMPLETED' END) AS STATUS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_INITIALS = INVOICEMASTER.INVOICE_INITIALS AND INVOICEMASTER_DESC.INVOICE_CMPID = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_DESC.INVOICE_LOCATIONID = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN CUSTOMERMASTER ON INVOICEMASTER.INVOICE_LEDGERID = CUSTOMERMASTER.Customer_id AND INVOICEMASTER.INVOICE_CMPID = CUSTOMERMASTER.Customer_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = CUSTOMERMASTER.Customer_locationid AND INVOICEMASTER.INVOICE_YEARID = CUSTOMERMASTER.Customer_yearid INNER JOIN CMPMASTER ON INVOICEMASTER.INVOICE_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN SALEORDER ON INVOICEMASTER.INVOICE_YEARID = SALEORDER.so_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = SALEORDER.so_locationid AND INVOICEMASTER.INVOICE_CMPID = SALEORDER.so_cmpid AND INVOICEMASTER.INVOICE_ORDERNO = SALEORDER.so_pono", CONDITION & " GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_DATE, CUSTOMERMASTER.Customer_cmpname, INVOICEMASTER.INVOICE_ORDERNO, INVOICEMASTER.INVOICE_ORDERDATE, INVOICEMASTER.INVOICE_GRANDTOTAL, SALEORDER.so_totalqty, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, CMPMASTER.cmp_invinitials")

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("H1", 15)
            SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD1
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD2
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            RowIndex += 1
            Write("INVOICE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("25"))


            RowIndex += 2
            Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Customer", Range("5"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            Write("PO No", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PO Date", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            Write("Total Sets", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            Write("Total Amt", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Transport Name", Range("17"), XlHAlign.xlHAlignCenter, Range("19"), True, 10)
            Write("LR No", Range("20"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            Write("LR Date", Range("22"), XlHAlign.xlHAlignCenter, Range("23"), True, 10)
            Write("Status", Range("24"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)

            SetBorder(RowIndex, Range("1"), Range("25"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("INVOICENO"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), False, 10)
                Write(dr("DATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("NAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                Write(dr("PONO"), Range("8"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PODATE"), Range("11"), XlHAlign.xlHAlignLeft, Range("12"), False, 10)
                Write(dr("TOTALSETS"), Range("13"), XlHAlign.xlHAlignRight, Range("14"), False, 10)
                Write(dr("TOTALAMT"), Range("15"), XlHAlign.xlHAlignRight, Range("16"), False, 10)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - DT.Rows.Count, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - DT.Rows.Count, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - DT.Rows.Count, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - DT.Rows.Count, Range("21"))
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex - DT.Rows.Count, Range("23"))
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex - DT.Rows.Count, Range("25"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            RowIndex += 1
            Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("25").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX DETAILS REPORT"

    Public Function SALES_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_TAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID  FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_BOOKTYPE = 'BOOKING' AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TOTALSALEAMT AS NETT, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILL, 'PACKAGE' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, INTERNATIONALBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER.BOOKING_TAX AS TAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILL, 'INTERNATIONAL' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE') AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_TAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_ADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("SALES-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GP SHEET"

    Public Function GP_SHEET(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DTGUEST As System.Data.DataTable = objCMN.search(" TOP 1 GUESTMASTER.GUEST_NAME AS GUESTNAME, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, isnull(GUESTMASTER.GUEST_MOBILENO,'') AS [MOBILENO], ISNULL(GUESTMASTER.GUEST_EMAIL,'') AS EMAILID, ISNULL(CAST(GUESTMASTER.GUEST_ADD AS VARCHAR(8000)),'') AS GUESTADD", "", " INTERNATIONALBOOKINGMASTER_GUESTDETAILS INNER JOIN GUESTMASTER ON INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND  INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID RIGHT OUTER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID", CONDITION & " ")
            Dim DTPUR As System.Data.DataTable = objCMN.search(" LEDGERS.Acc_cmpname AS PURCHASENAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURRATE, '1' AS PURQTY, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMTPAID + INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_EXTRAAMT AS PURPAIDAMT", "", " LEDGERS INNER JOIN INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS ON LEDGERS.Acc_id = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID AND LEDGERS.Acc_cmpid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID AND LEDGERS.Acc_locationid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID RIGHT OUTER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID", CONDITION & "")
            Dim DT As System.Data.DataTable = objCMN.search("HOTELMASTER.HOTEL_NAME AS HOTELNAME, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_ARRIVALDATE AS ARRIVAL, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_DEPARTUREDATE AS DEPARTURE, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_RATE AS SALERATE, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_NOOFROOMS AS SALEQTY, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_AMOUNT AS SALEAMT, INTERNATIONALBOOKINGMASTER.BOOKING_SALEAMTREC + INTERNATIONALBOOKINGMASTER.BOOKING_SALEEXTRAAMT AS SALERECDAMT, INTERNATIONALBOOKINGMASTER.BOOKING_SALEBALANCE AS SALEBALANCE, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS SALETOTAL, CITYMASTER.city_name AS CITYNAME", "", " HOTELMASTER INNER JOIN INTERNATIONALBOOKINGMASTER INNER JOIN INTERNATIONALBOOKINGMASTER_DESC ON INTERNATIONALBOOKINGMASTER.BOOKING_NO = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_NO AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID ON HOTELMASTER.HOTEL_ID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_HOTELID AND HOTELMASTER.HOTEL_CMPID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID LEFT OUTER JOIN CITYMASTER ON INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID = CITYMASTER.city_yearid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID = CITYMASTER.city_locationid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID = CITYMASTER.city_cmpid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_SECTORID = CITYMASTER.city_id", CONDITION & "")
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 30)
                SetColumnWidth("F1", 1.5)
                SetColumnWidth("C1", 5)
                SetColumnWidth("D1", 5)
                SetColumnWidth("E1", 13)
                SetColumnWidth("H1", 5)
                SetColumnWidth("I1", 5)
                SetColumnWidth("J1", 13)


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("10"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))

                RowIndex += 1
                Write("GP Sheet for " & DTGUEST.Rows(0).Item("GUESTNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
                SetBorder(RowIndex, Range("1"), Range("10"))

                SetBorder(RowIndex, Range("1"), Range("10"))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Select()
                objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 1
                Write("Passenger Details :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

                RowIndex += 1
                Write("Pax Name", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("GUESTNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("No. Of Guest", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("TOTALPAX"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Mobile No.", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("MOBILENO"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Email ID", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("EMAILID"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Address", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                'Write(DTGUEST.Rows(0).Item("GUESTADD"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)



                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - 5, objColumn.Item("10").ToString & RowIndex)



                RowIndex += 1
                Write("Booking Details :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                RowIndex += 1
                Write("Hotel", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

                For Each DTROW As DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("CITYNAME"), Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("HOTELNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)

                    RowIndex += 1
                    Write("CHECK IN", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("ARRIVAL"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)

                    RowIndex += 1
                    Write("CHECK OUT", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("DEPARTURE"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
                    RowIndex += 1
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - (RowIndex - 5), objColumn.Item("10").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("1").ToString & RowIndex)



                RowIndex += 1
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
                Write("PURCHASE", Range("2"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
                Write("SALE", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



                RowIndex += 1
                Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Rate", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("ROE", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Qty.", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Amount in INR", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)

                Write("Rate", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("ROE", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Qty.", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Amount in INR", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 1
                Write("Package :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)


                'USED TO SAVE ROWCOUNT NO FOR CALCULATING SUM AT THE BOTTOM
                'DONT DELETE TESTED PROPERLY
                Dim TEMPROWCOUNT As Integer = RowIndex

                For Each DTROW As DataRow In DTPUR.Rows
                    RowIndex += 1
                    Write(DTROW("PURCHASENAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURRATE"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)

                    'ROE (RATE OF EXCHANGE) BY DEFAULT 1
                    Write("1", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURQTY"), Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=(" & Range("2") & "*" & Range("3") & "*" & Range("4") & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Next

                Dim TEMPFINISHCOUNT As Integer = RowIndex
                RowIndex = TEMPROWCOUNT

                For Each DTROW As DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("SALERATE"), Range("7"), XlHAlign.xlHAlignLeft, , True, 10)

                    'ROE (RATE OF EXCHANGE) BY DEFAULT 1
                    Write("1", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("SALEQTY"), Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=(" & Range("7") & "*" & Range("8") & "*" & Range("9") & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                Next


                If RowIndex < TEMPFINISHCOUNT Then RowIndex = TEMPFINISHCOUNT

                RowIndex += 2
                FORMULA("=SUM(" & objColumn.Item("5").ToString & TEMPROWCOUNT & ":" & objColumn.Item("5").ToString & RowIndex - 2 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("10").ToString & TEMPROWCOUNT & ":" & objColumn.Item("10").ToString & RowIndex - 2 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 2
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " > 0,""GROSS PROFIT"",""GROSS LOSS""", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " < 0," & objColumn.Item("5").ToString & RowIndex - 2 & "-" & objColumn.Item("10").ToString & RowIndex - 2 & ",""""", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " > 0," & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & ",""""", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 2
                Write("Purchased From :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For Each DTROW As DataRow In DTPUR.Rows
                    RowIndex += 1
                    Write(DTROW("PURCHASENAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURAMT"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=IF(" & DTROW("PURAMT") & "-" & DTROW("PURPAIDAMT") & " = 0,""PAID"",""""", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Next



                RowIndex += 2
                Write("Invoice to be made as follows :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("SALERECDAMT")) > 0 Then
                        RowIndex += 1
                        Write(DTROW("Amount received"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9, False, True)
                        Write(DTROW("SALERECDAMT"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                        FORMULA("=IF(" & DTROW("SALEAMT") & "-" & DTROW("SALERECDAMT") & " = 0,""RECD"",""""", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                    End If
                Next
                RowIndex += 1
                Write("Balance:", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, False, True)
                Write(DT.Rows(0).Item("SALEBALANCE"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)

                RowIndex += 3
                Write("Total Invoice", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DT.Rows(0).Item("SALETOTAL"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("10").ToString & RowIndex + 1)


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX DETAILS REPORT"

    Public Function PURCHASE_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE HOTELBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND HOTELBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE' UNION ALL Select DISTINCT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'PACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL Select DISTINCT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE (INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE')) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim COLINDEX As Integer = 0
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        COLINDEX = DT.Columns.IndexOf(DRADDTAX("TAXNAME"))
                        If COLINDEX = 0 Then DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID") & " OR TAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            If IsDBNull(DR(DRADDTAX("TAXNAME"))) = False Then
                                DR(DRADDTAX("TAXNAME")) = Val(DR(DRADDTAX("TAXNAME"))) + DR("ADDTAXAMT")
                            Else
                                DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                            End If
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("Purchase-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX SUMMARY REPORT"

    Public Function SALES_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS NETTAMT", "", " HOTELBOOKINGMASTER", " AND BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(BOOKING_DATE) = " & Val(DR("MONTH")) & " AND BOOKING_CMPID = " & CMPID & " AND BOOKING_LOCATIONID = " & LOCATIONID & " AND BOOKING_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            'Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN INVOICEMASTER ON EXCISEMASTER.EXCISE_yearid = INVOICEMASTER.INVOICE_YEARID AND EXCISEMASTER.EXCISE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = INVOICEMASTER.INVOICE_CMPID AND EXCISEMASTER.EXCISE_id = INVOICEMASTER.INVOICE_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            'If DTEXCISE.Rows.Count > 0 Then
            '    For Each DREXCISE As DataRow In DTEXCISE.Rows
            '        DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales")
            '        DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Sales")
            '        DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Sales")
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_HSECESSAMT),0) AS HSECESSAMT", "", " INVOICEMASTER", " AND INVOICE_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
            '            Else
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = 0.0
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = 0.0
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = 0.0
            '            End If
            '        Next
            '    Next
            'End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER ON TAXMASTER.TAX_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.TAX_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.TAX_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.TAX_id = HOTELBOOKINGMASTER.BOOKING_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_TAX),0) AS TAXAMT ", "", " HOTELBOOKINGMASTER", " AND HOTELBOOKINGMASTER.BOOKING_TAXID = " & DRTAX("TAXID") & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(HOTELBOOKINGMASTER.BOOKING_DATE) = " & Val(DR("MONTH")) & " AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CMPID & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & LOCATIONID & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            ''FOR ADDTAXAMT
            'Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN INVOICEMASTER ON TAXMASTER.TAX_yearid = INVOICEMASTER.INVOICE_YEARID AND TAXMASTER.TAX_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND TAXMASTER.TAX_cmpid = INVOICEMASTER.INVOICE_CMPID AND TAXMASTER.TAX_id = INVOICEMASTER.INVOICE_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            'If DTADDTAX.Rows.Count > 0 Then
            '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
            '        DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search("ISNULL(SUM(INVOICEMASTER.INVOICE_ADDTAXAMT),0) AS ADDTAXAMT", "", " INVOICEMASTER", " AND INVOICE_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(INVOICE_DATE)= " & DR("MONTH") & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
            '            Else
            '                DR(DRADDTAX("TAXNAME")) = 0.0
            '            End If
            '        Next
            '    Next
            'End If


            'DTMONTH.Columns.Add("FREIGHT")
            'DTMONTH.Columns.Add("OCTROIAMT")
            'DTMONTH.Columns.Add("INSAMT")
            'DTMONTH.Columns.Add("ROUNDOFF")
            'For Each DR As DataRow In DTMONTH.Rows
            '    DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_FREIGHT),0) AS FREIGHT, ISNULL(SUM(INVOICEMASTER.INVOICE_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_INSAMT),0) AS INSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_ROUNDOFF),0) AS ROUNDOFF", "", " INVOICEMASTER", " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '    If DTVAL.Rows.Count > 0 Then
            '        DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
            '        DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
            '        DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
            '        DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
            '    Else
            '        DR("FREIGHT") = 0.0
            '        DR("OCTROIAMT") = 0.0
            '        DR("INSAMT") = 0.0
            '        DR("ROUNDOFF") = 0.0
            '    End If
            'Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            'Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                'Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("SALES-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX SUMMARY REPORT"

    Public Function PURCHASE_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_NETT),0) AS NETTAMT", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN PURCHASEMASTER ON EXCISEMASTER.EXCISE_yearid = PURCHASEMASTER.BILL_YEARID AND EXCISEMASTER.EXCISE_locationid = PURCHASEMASTER.BILL_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = PURCHASEMASTER.BILL_CMPID AND EXCISEMASTER.EXCISE_id = PURCHASEMASTER.BILL_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            If DTEXCISE.Rows.Count > 0 Then
                For Each DREXCISE As DataRow In DTEXCISE.Rows
                    DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase")
                    DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Purchase")
                    DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Purchase")
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(PURCHASEMASTER.BILL_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_HSECESSAMT),0) AS HSECESSAMT", "", " PURCHASEMASTER", " AND BILL_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
                        Else
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = 0.0
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = 0.0
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = 0.0
                        End If
                    Next
                Next
            End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_TAXAMT),0) AS TAXAMT ", "", " PURCHASEMASTER", " AND BILL_TAXID = " & DTTAX.Rows(0).Item("TAXID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


           'FOR ADDTAXAMT
            Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTADDTAX.Rows.Count > 0 Then
                For Each DRADDTAX As DataRow In DTADDTAX.Rows
                    DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search("ISNULL(SUM(PURCHASEMASTER.BILL_ADDTAXAMT),0) AS ADDTAXAMT", "", " PURCHASEMASTER", " AND BILL_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(BILL_DATE)= " & DR("MONTH") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
                        Else
                            DR(DRADDTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            DTMONTH.Columns.Add("FREIGHT")
            DTMONTH.Columns.Add("OCTROIAMT")
            DTMONTH.Columns.Add("INSAMT")
            DTMONTH.Columns.Add("ROUNDOFF")
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_FREIGHT),0) AS FREIGHT, ISNULL(SUM(PURCHASEMASTER.BILL_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(PURCHASEMASTER.BILL_INSAMT),0) AS INSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_ROUNDOFF),0) AS ROUNDOFF", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
                    DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
                    DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
                    DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
                Else
                    DR("FREIGHT") = 0.0
                    DR("OCTROIAMT") = 0.0
                    DR("INSAMT") = 0.0
                    DR("ROUNDOFF") = 0.0
                End If
            Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)
            


            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("PURCHASE-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GROUP WISE TRANS DETAILS REPORT"

    Public Function GROUP_TRANS_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("B1", 40)


            'CMPHEADER
            CMPHEADER(CMPID, "GROUP-WISE TRANSACTION REPORT")



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bll No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim ALCOL(1) As String
            ALCOL(0) = ("ACC_INITIALS")
            ALCOL(1) = ("ACC_BILLNO")

            Dim OBJGROUP As New ClsCommon
            Dim DTALL As System.Data.DataTable = OBJGROUP.search("ACC_BILLDATE AS [DATE], NAME, ACC_TYPE AS [TYPE], ACC_BILLNO, ACC_INITIALS , DR,CR, PRIMARYGROUP ", "", " REGISTER ", CONDITION & " AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " ORDER BY ACC_BILLDATE")
            Dim DTMAIN As System.Data.DataTable = DTALL.DefaultView.ToTable(True, ALCOL)
            Dim DR() As System.Data.DataRow = DTMAIN.Select("ACC_INITIALS <> '0'", "ACC_BILLNO ASC")
            Dim DR1() As System.Data.DataRow
            For I As Integer = 0 To DR.GetUpperBound(0)

                DR1 = DTALL.Select("ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")

                Dim DTINITIALPARTY As System.Data.DataTable = OBJGROUP.search(" TOP(1) NAME", "", " REGISTER", " and acc_cmpid = " & CMPID & " and YEARID = " & YEARID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND name NOT IN (SELECT name FROM REGISTER WHERE REGISTER.acc_cmpid = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND REGISTER.YEARID = " & YEARID & CONDITION & ")  and acc_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")
                If DTINITIALPARTY.Rows.Count > 0 Then
                    RowIndex += 2
                    Write(Format(Convert.ToDateTime(DR1(0)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTINITIALPARTY.Rows(0).Item("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTALL.Compute("SUM(CR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTALL.Compute("SUM(DR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                    For A As Integer = 0 To DR1.GetUpperBound(0)

                        RowIndex += 1
                        Write(Format(Convert.ToDateTime(DR1(A)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("     " & DR1(A)("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(DR1(A)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("DR"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DR1(A)("cr"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Next
                End If

            Next

            

            For I As Integer = 1 To 6
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))


            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("6").ToString & RowIndex + 1)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PROFIT AND LOSS REPORT"

    Public Function PROFIT_AND_LOSS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth("A1", 35)
            SetColumnWidth("D1", 35)


            CMPHEADER(CMPID, "PROFIT & LOSS")


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("Particulars", Range("4"), XlHAlign.xlHAlignLeft, Range("6"), True, 10)
            
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim DT As New System.Data.DataTable
            Dim OBJPL As New ClsProfitLoss
            OBJPL.alParaval = ALPARAVAL

            Dim RowIndexIncome As Integer = RowIndex
            Dim RowIndexexpense As Integer = RowIndex


            If CONDITION = "CONDENSED" Then
                DT = OBJPL.GETSUMMARY()

                'FORMATTING REPORT
                RowIndex += 1
                Write("Opening Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                RowIndexexpense = RowIndex

                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If

                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Gross Profit C/O" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        GoTo LINE1
                    End If


                    If DTROW(0) = "Gross Loss C/O" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        RowIndexIncome = RowIndex

                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''*************************************************************************


                    If DTROW(0) = "Indirect Expenses" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Indirect Income" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex


                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                        ''***************************************************************************************

LINE1:
                Next


            Else
                If CONDITION = "DETAILS" Then
                    DT = OBJPL.GETDETAILS()
                Else
                    DT = OBJPL.GETLEDGER()
                End If

                'FORMATTING REPORT
                RowIndex += 1
                Write("Opening Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                RowIndexexpense = RowIndex

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) = 1 Or DTROW(2) = 2 Then
                        If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                            RowIndex = RowIndexexpense
                            RowIndex += 2
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexexpense
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) = 3 Or DTROW(2) = 4 Then
                        If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                            RowIndex = RowIndexIncome
                            RowIndex += 2
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexIncome
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Gross Profit C/O" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 2
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Closing Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 2
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If


                    If DTROW(0) = "Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''*************************************************************************

                    If DTROW(2) = 11 Then
                        If DTROW(0) = "Indirect Expenses" Then
                            RowIndex = RowIndexexpense
                            RowIndex += 2
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexexpense
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    If DTROW(2) = 12 Then
                        If DTROW(0) = "Indirect Income" Then
                            RowIndex = RowIndexIncome
                            RowIndex += 2
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexIncome
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        End If
                    End If

                    ''***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex


                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************
LINE2:

                Next

            End If

            If RowIndexexpense > RowIndexIncome Then
                RowIndex = RowIndexexpense
            Else
                RowIndex = RowIndexIncome
            End If
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("3").ToString & RowIndex + 1)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 7, objColumn.Item("6").ToString & RowIndex + 1)

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"




            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "BALANCE SHEET REPORT"

    Public Function BALANCE_SHEET_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth("A1", 35)
            SetColumnWidth("D1", 35)


            CMPHEADER(CMPID, "BALANCE SHEET")


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("Particulars", Range("4"), XlHAlign.xlHAlignLeft, Range("6"), True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim DT As New System.Data.DataTable
            Dim OBJBAL As New ClsBalanceSheet

            Dim OBJPL As New ClsProfitLoss
            Dim DTPL As New System.Data.DataTable

            OBJBAL.alParaval = ALPARAVAL
            OBJPL.alParaval = ALPARAVAL

            DTPL = OBJPL.GETSUMMARY()
            Dim DRPL() As DataRow = DTPL.Select("NAME = 'Nett Profit' OR NAME = 'Nett Loss'")


            Dim RowIndexAssets As Integer = RowIndex
            Dim RowIndexLiability As Integer = RowIndex


            If CONDITION = "CONDENSED" Then
                DT = OBJBAL.GETSUMMARY()

                'FORMATTING REPORT
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Then
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If

                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Profit" Then
                        If DRPL(0)(0) = "Nett Loss" Then GoTo LINE1
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                        Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Loss" Then
                        If DRPL(0)(0) = "Nett Profit" Then GoTo LINE1
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                        Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total Liability" Then

                        If RowIndexLiability > RowIndexAssets Then
                            RowIndexAssets = RowIndexLiability
                        Else
                            RowIndexLiability = RowIndexAssets
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Total Assets" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************
LINE1:
                Next


            Else
                If CONDITION = "DETAILS" Then
                    DT = OBJBAL.GETDETAILS()
                Else
                    DT = OBJBAL.GETLEDGERDETAILS()
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) < 8 Then
                        If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Or (DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Profit" Then
                            If DTROW(0) <> "Profit" Then
                                RowIndex = RowIndexLiability
                                RowIndex += 2
                                Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                                Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                                objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                RowIndexLiability = RowIndex
                                GoTo LINE2
                            Else
                                If DTROW(0) = "Profit" Then
                                    If DRPL(0)(0) = "Nett Loss" Then GoTo LINE2
                                    RowIndex = RowIndexLiability
                                    RowIndex += 2
                                    Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                                    Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    RowIndexLiability = RowIndex
                                    GoTo LINE2
                                End If
                            End If
                            
                        Else
                            RowIndex = RowIndexLiability
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexLiability = RowIndex
                            GoTo LINE2
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) > 7 And DTROW(2) < 14 Then
                        If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Or (DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Loss" Then
                            If DTROW(0) <> "Loss" Then
                                RowIndex = RowIndexAssets
                                RowIndex += 2
                                Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                                Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                                objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                RowIndexAssets = RowIndex
                                GoTo LINE2
                            Else
                                If DTROW(0) = "Loss" Then
                                    If DRPL(0)(0) = "Nett Profit" Then GoTo LINE2
                                    RowIndex = RowIndexAssets
                                    RowIndex += 2
                                    Write("Profit & Loss", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, )
                                    Write(Val(DRPL(0)(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                                    objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    RowIndexAssets = RowIndex
                                    GoTo LINE2
                                End If
                            End If
                        Else
                            RowIndex = RowIndexAssets
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexAssets = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Total Liability" Then

                        If RowIndexLiability > RowIndexAssets Then
                            RowIndexAssets = RowIndexLiability
                        Else
                            RowIndexLiability = RowIndexAssets
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE2
                    End If


                    If DTROW(0) = "Total Assets" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************
LINE2:

                Next

            End If

            If RowIndexLiability > RowIndexAssets Then
                RowIndex = RowIndexLiability
            Else
                RowIndex = RowIndexAssets
            End If
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("3").ToString & RowIndex + 1)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 7, objColumn.Item("6").ToString & RowIndex + 1)

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"




            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TRIALBALANCE"

    Public Function TRIALBALANCE_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("TRIAL-BALANCE", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Name", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("O/P Dr", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("O/P Cr", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Dr", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Cr", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " TEMPTRIALBALANCEPRINT", " ORDER BY ROWNO")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                If DTROW("OPENINGDR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGDR")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("OPENINGCR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGCR")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

                If DTROW("CLOSINGDR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGDR")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("CLOSINGCR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGCR")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If Left(DTROW("NAME"), 1) = " " And Left(DTROW("NAME"), 6) <> "      " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                ElseIf Left(DTROW("NAME"), 1) <> " " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALARYREPORT"

    Public Function SALARYREPORT_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal NAMECLAUSE As String = "", Optional ByVal MONTHNAME As String = "", Optional ByVal MONTHYEAR As String = "") As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 8)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 18)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 14)

            RowIndex += 1
            Write("SALARY STATEMENT FOR THE MONTH OF " & MONTHYEAR, Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 12)



            'FETCH DATA FROM SALARYMASTER FOR COLUMNS THEN LOOP WITH RESPECT TO NAMECLAUSE
            Dim GRANDTOTAL(50) As Double
            Dim TEMPROWINDEX As Integer = 0
            Dim MONTHCLAUSE As String = ""
            If MONTHNAME <> "" Then MONTHCLAUSE = " AND SALARYMASTER.SAL_MONTH = '" & MONTHNAME & "' "
            Dim DTDEBITLEDGER As System.Data.DataTable = OBJCMN.search(" DISTINCT UPPER(LEDGERS.ACC_CMPNAME) AS DEBITLEDGER  ", "", " SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID ", " AND SALARYMASTER.SAL_YEARID = " & YEARID & MONTHCLAUSE & NAMECLAUSE & " ORDER BY DEBITLEDGER ")
            For Each DTROWDEBITLEDGER As DataRow In DTDEBITLEDGER.Rows
                RowIndex += 4
                Write(DTROWDEBITLEDGER("DEBITLEDGER"), Range("1"), XlHAlign.xlHAlignLeft, , True, 12)

                RowIndex += 1
                TEMPROWINDEX = RowIndex
                'ADDING COLS IN EACH DEBITLEDGER
                Dim J As Integer = 3
                Write("DESIGNATION", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim DTCOLUMN As System.Data.DataTable = OBJCMN.search(" * ", "", " (SELECT DISTINCT UPPER(EARLEDGERS.Acc_cmpname) AS NAME, LEDGERS.ACC_CMPNAME AS DEBITLEDGER, 'EARNING' AS TYPE FROM SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER_EARNINGS ON SALARYMASTER.SAL_NO = SALARYMASTER_EARNINGS.SAL_NO AND SALARYMASTER.SAL_YEARID = SALARYMASTER_EARNINGS.SAL_yearid INNER JOIN LEDGERS AS EARLEDGERS ON SALARYMASTER_EARNINGS.SAL_EARID = EARLEDGERS.ACC_ID WHERE SALARYMASTER.SAL_YEARID = " & YEARID & MONTHCLAUSE & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' UNION ALL SELECT 'GROSS SALARY' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'EARNING' AS TYPE UNION ALL SELECT DISTINCT UPPER(DEDLEDGERS.Acc_cmpname) AS NAME, LEDGERS.ACC_CMPNAME AS DEBITLEDGER, 'DEDUCTION' AS TYPE FROM SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER_DEDUCTION ON SALARYMASTER.SAL_NO = SALARYMASTER_DEDUCTION.SAL_NO AND SALARYMASTER.SAL_YEARID = SALARYMASTER_DEDUCTION.SAL_yearid INNER JOIN LEDGERS AS DEDLEDGERS ON SALARYMASTER_DEDUCTION.SAL_DEDID = DEDLEDGERS.ACC_ID WHERE SALARYMASTER.SAL_MONTH = '" & MONTHNAME & "' AND SALARYMASTER.SAL_YEARID = " & YEARID & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' UNION ALL SELECT 'TOTAL DEDUCTION' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'DEDUCTION' AS TYPE UNION ALL SELECT 'NETT SALARY' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'DEDUCTION' AS TYPE) AS T ", "")
                For Each DTROWCOL As DataRow In DTCOLUMN.Rows
                    Write(DTROWCOL("NAME"), Range(J.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    J += 1
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                objSheet.Range(objColumn.Item("1").ToString & RowIndex).RowHeight = 40

                'ADDING ALL ROWS WITH RESPECT TO EMPLOYEES 
                Dim TEMPCOLNAME As String = ""
                Dim DTEMP As System.Data.DataTable = OBJCMN.search(" UPPER(EMP_NAME) AS EMPLOYEE, ISNULL(DESIGNATION_NAME,'') AS DESIGNATION, SALARYMASTER.SAL_NO AS SALNO ", "", " SALARYMASTER INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID= EMP_id INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN DESIGNATIONMASTER ON EMP_DESIGNATIONID = DESIGNATION_ID", " AND SALARYMASTER.SAL_YEARID = " & YEARID & MONTHCLAUSE & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' ORDER BY SALARYMASTER.SAL_NO")
                For Each DTROW As DataRow In DTEMP.Rows
                    RowIndex += 1
                    Write(DTROW("EMPLOYEE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("DESIGNATION"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)

                    'GET THE SALARY DETAILS WITH RESPECT TO SALARYNO
                    Dim TEMPDEDCOLSTART As Integer = 3
                    Dim GROSSCOL As Integer = 3
                    For TEMPCOL As Integer = 3 To J - 1
                        Dim CHARACTER As String = Chr(64 + TEMPCOL)
                        If IsDBNull(objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text) = False Then TEMPCOLNAME = objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text
                        Dim DTSAL As System.Data.DataTable = OBJCMN.search("*", "", "(SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SAL_AMT,0) AS AMT FROM SALARYMASTER_EARNINGS INNER JOIN LEDGERS ON SAL_EARID = LEDGERS.ACC_ID WHERE SALARYMASTER_EARNINGS.SAL_YEARID = " & YEARID & " AND SALARYMASTER_EARNINGS.SAL_NO = " & Val(DTROW("SALNO")) & " UNION ALL SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SAL_AMT,0) AS AMT FROM SALARYMASTER_DEDUCTION INNER JOIN LEDGERS ON SAL_DEDID = LEDGERS.ACC_ID WHERE SALARYMASTER_DEDUCTION.SAL_YEARID = " & YEARID & " AND SALARYMASTER_DEDUCTION.SAL_NO = " & Val(DTROW("SALNO")) & ") AS T", " AND T.COLNAME = '" & TEMPCOLNAME & "'")
                        If DTSAL.Rows.Count > 0 Then Write(Val(DTSAL.Rows(0).Item("AMT")), Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9) Else Write("0", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9)

                        'IF COLNAME IS GROSS SALARY OR NETTSALARY THEN WRITE FORMULA THEN
                        If TEMPCOLNAME = "GROSS SALARY" Then
                            TEMPDEDCOLSTART = TEMPCOL + 1
                            FORMULA("=SUM(" & objColumn.Item("3").ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                            GROSSCOL = TEMPCOL
                        End If

                        If TEMPCOLNAME = "TOTAL DEDUCTION" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=SUM(" & objColumn.Item(TEMPDEDCOLSTART.ToString).ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If

                        If TEMPCOLNAME = "NETT SALARY" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=(" & objColumn.Item(GROSSCOL.ToString).ToString & RowIndex & ")-(" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If

                    Next

                    'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                Next


                'GIVE TOTAL
                RowIndex += 1
                Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For TEMPNO As Integer = 1 To J - 1
                    If TEMPNO > 2 Then
                        FORMULA("=SUM(" & objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX + 1 & ":" & objColumn.Item(TEMPNO.ToString).ToString & RowIndex - 1 & ")", Range(TEMPNO.ToString), XlHAlign.xlHAlignRight, , True, 10)
                        Dim CHARACTER As String = Chr(64 + TEMPNO)
                        GRANDTOTAL(TEMPNO) = Val(GRANDTOTAL(TEMPNO)) + objSheet.Range(CHARACTER & RowIndex).Text
                    End If
                    SetBorder(RowIndex, objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    objSheet.Range(objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex).NumberFormat = "##,##,###.00"
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                'objSheet.Range(Range("1"), Range((J - 1).ToString)).Interior.Color = RGB(255, 165, 0)


            Next



            'GIVE TOTAL
            RowIndex += 2
            Write("GRANDTOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            For TEMPNO As Integer = 3 To GRANDTOTAL.Length - 1
                If TEMPNO > 2 And GRANDTOTAL(TEMPNO) > 0 Then
                    Write(GRANDTOTAL(TEMPNO), Range(TEMPNO.ToString), XlHAlign.xlHAlignRight, , True, 9, True)
                    SetBorder(RowIndex, objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    objSheet.Range(objColumn.Item(TEMPNO.ToString).ToString & RowIndex, objColumn.Item(TEMPNO.ToString).ToString & RowIndex).NumberFormat = "##,##,###.00"
                End If
            Next





            'RowIndex += 2
            'Write("", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            'Write("TAXABLE AMT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("CGST", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("SGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("TAX C+S", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("IGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("TOTAL", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)



            ''FIRST GET OPENING WITH RESPECT TO FROM DATE
            ''FOR NOW OPENING WILL BE BLANK
            'RowIndex += 1
            'Write("OPENING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

            'Dim WHERECLAUSE As String = ""
            'If REGNAME <> "" Then WHERECLAUSE = " And REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            ''PURCHASE(REGISTERED)
            'RowIndex += 1
            'Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'FALSE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            '    objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            'End If


            ''NONPURCHASE (REGISTERED)
            'RowIndex += 1
            'Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search("  ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID INNER JOIN LEDGERS ON NP_LEDGERID = LEDGERS.ACC_ID", WHERECLAUSE & " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'FALSE'")
            'If DTNP.Rows.Count > 0 Then
            '    Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            '    objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            'End If


            ''CREDITNOTE(OF PURCHASE)
            'RowIndex += 1
            'Write("CREDIT NOTE (PUR)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT ISNULL(SUM(CN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(CN_CGSTAMT),0) AS CGST, ISNULL(SUM(CN_SGSTAMT),0) AS SGST, ISNULL(SUM(CN_IGSTAMT),0) AS IGST FROM CREDITNOTEMASTER WHERE CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_YEARID = " & YEARID & "  AND ISNULL(CN_NOGSTR1,0) = 'TRUE' AND ISNULL(CN_RCM,0) = 'FALSE') AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            '    objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            'End If




            ''CREDITNOTE (OF SALES)
            'RowIndex += 1
            'Write("CREDIT NOTE (SALE)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(SALERETURN.SALRET_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0)) AS IGST FROM SALERETURN WHERE SALRET_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND SALRET_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND SALRET_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(CN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(CN_CGSTAMT),0) AS CGST, ISNULL(SUM(CN_SGSTAMT),0) AS SGST, ISNULL(SUM(CN_IGSTAMT),0) AS IGST FROM CREDITNOTEMASTER WHERE CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_YEARID = " & YEARID & " AND ISNULL(CN_NOGSTR1,0) = 'FALSE' AND ISNULL(CN_RCM,0) = 'FALSE') AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            '    objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            'End If


            ''SALE(REGISTERED)
            'RowIndex += 1
            'Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("ISNULL(SUM(T.TAXABLEAMT ),0) AS TAXABLEAMT, ISNULL(SUM(T.CGST),0) AS CGST, ISNULL(SUM(T.SGST),0) AS SGST, ISNULL(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') <> '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''SALE URD (LOCAL)
            'RowIndex += 1
            'Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'FALSE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''SALE URD (EXPORT)
            'RowIndex += 1
            'Write("SALE (URD-EXPORT)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If




            ''DEBITNOTE (OF SALE)
            'RowIndex += 1
            'Write("DEBIT NOTE (SALE)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT ISNULL(SUM(DN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(DN_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(DN_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(DN_TOTALIGSTAMT),0) AS IGST FROM DEBITNOTEMASTER WHERE DN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND ISNULL(DN_GSTR1,0) = 'TRUE' AND DN_YEARID = " & YEARID & ") AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If


            ''DEBITNOTE (OF PURCHASE)
            'RowIndex += 1
            'Write("DEBIT NOTE (PUR)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0)) AS IGST FROM PURCHASERETURN WHERE PR_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PR_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PR_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(DN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(DN_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(DN_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(DN_TOTALIGSTAMT),0) AS IGST FROM DEBITNOTEMASTER WHERE DN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND ISNULL(DN_GSTR1,0) = 'FALSE' AND DN_YEARID = " & YEARID & ") AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If




            ''CLOSING
            'RowIndex += 1
            'Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & 12 & ") - SUM(" & objColumn.Item("3").ToString & 13 & ":" & objColumn.Item("3").ToString & 17 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & 12 & ") - SUM(" & objColumn.Item("4").ToString & 13 & ":" & objColumn.Item("4").ToString & 17 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & 12 & ") - SUM(" & objColumn.Item("5").ToString & 13 & ":" & objColumn.Item("5").ToString & 17 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & 12 & ") - SUM(" & objColumn.Item("6").ToString & 13 & ":" & objColumn.Item("6").ToString & 17 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & 12 & ") - SUM(" & objColumn.Item("7").ToString & 13 & ":" & objColumn.Item("7").ToString & 17 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 165, 0)


            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)





            ''PURCHASE (URD)
            'RowIndex += 3
            'Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'TRUE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            'End If


            ''NONPURCHASE (URD)
            'RowIndex += 1
            'Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'TRUE'")
            'If DTNP.Rows.Count > 0 Then
            '    Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            'End If

            ''RCM CLOSING
            'RowIndex += 1
            'Write("RCM CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'FORMULA("=SUM(" & objColumn.Item("3").ToString & RowIndex - 2 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex - 2 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("5").ToString & RowIndex - 2 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("6").ToString & RowIndex - 2 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - 2 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(0, 255, 0)

            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)



            ''PAYMENT
            'RowIndex += 1
            'Write("GST PAYMENT", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search(" ISNULL(SUM(PAYMENT_TOTAL),0) AS PAIDAMOUNT ", "", " PAYMENTMASTER INNER JOIN LEDGERS ON PAYMENT_ledgerid = Acc_id ", " AND LEDGERS.ACC_CMPNAME IN ('CGST', 'SGST','IGST', 'REVERSE CHARGE') AND PAYMENT_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_YEARID = " & YEARID)
            'Write(Val(DTNP.Rows(0).Item("PAIDAMOUNT")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 255, 0)



            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)




            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function ANNUALSALARYREPORT_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal NAMECLAUSE As String = "", Optional ByVal HEADER As String = "") As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 8)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 18)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 14)

            RowIndex += 1
            Write("SALARY STATEMENT FOR " & HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 12)



            'FETCH DATA FROM SALARYMASTER FOR COLUMNS THEN LOOP WITH RESPECT TO NAMECLAUSE
            Dim GRANDTOTAL(50) As Double
            Dim TEMPROWINDEX As Integer = 0
            Dim DTDEBITLEDGER As System.Data.DataTable = OBJCMN.search(" DISTINCT UPPER(LEDGERS.ACC_CMPNAME) AS DEBITLEDGER  ", "", " SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID ", " AND SALARYMASTER.SAL_YEARID = " & YEARID & NAMECLAUSE & " ORDER BY DEBITLEDGER ")
            For Each DTROWDEBITLEDGER As DataRow In DTDEBITLEDGER.Rows
                RowIndex += 4
                Write(DTROWDEBITLEDGER("DEBITLEDGER"), Range("1"), XlHAlign.xlHAlignLeft, , True, 12)

                RowIndex += 1
                TEMPROWINDEX = RowIndex
                'ADDING COLS IN EACH DEBITLEDGER
                Dim J As Integer = 4
                Write("EMPLOYEE NAME", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("DESIGNATION", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("MONTH", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim DTCOLUMN As System.Data.DataTable = OBJCMN.search(" * ", "", " (SELECT DISTINCT UPPER(EARLEDGERS.Acc_cmpname) AS NAME, LEDGERS.ACC_CMPNAME AS DEBITLEDGER, 'EARNING' AS TYPE FROM SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER_EARNINGS ON SALARYMASTER.SAL_NO = SALARYMASTER_EARNINGS.SAL_NO AND SALARYMASTER.SAL_YEARID = SALARYMASTER_EARNINGS.SAL_yearid INNER JOIN LEDGERS AS EARLEDGERS ON SALARYMASTER_EARNINGS.SAL_EARID = EARLEDGERS.ACC_ID WHERE SALARYMASTER.SAL_YEARID = " & YEARID & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' UNION ALL SELECT 'GROSS SALARY' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'EARNING' AS TYPE UNION ALL SELECT DISTINCT UPPER(DEDLEDGERS.Acc_cmpname) AS NAME, LEDGERS.ACC_CMPNAME AS DEBITLEDGER, 'DEDUCTION' AS TYPE FROM SALARYMASTER INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER_DEDUCTION ON SALARYMASTER.SAL_NO = SALARYMASTER_DEDUCTION.SAL_NO AND SALARYMASTER.SAL_YEARID = SALARYMASTER_DEDUCTION.SAL_yearid INNER JOIN LEDGERS AS DEDLEDGERS ON SALARYMASTER_DEDUCTION.SAL_DEDID = DEDLEDGERS.ACC_ID WHERE SALARYMASTER.SAL_YEARID = " & YEARID & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' UNION ALL SELECT 'TOTAL DEDUCTION' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'DEDUCTION' AS TYPE UNION ALL SELECT 'NETT SALARY' AS NAME, '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' AS DEBITLEDGER, 'DEDUCTION' AS TYPE) AS T ", "")
                For Each DTROWCOL As DataRow In DTCOLUMN.Rows
                    Write(DTROWCOL("NAME"), Range(J.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    J += 1
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                objSheet.Range(objColumn.Item("1").ToString & RowIndex).RowHeight = 40


                'ADDING ALL ROWS WITH RESPECT TO EMPLOYEES 
                Dim TEMPCOLNAME As String = ""
                Dim DTEMP As System.Data.DataTable = OBJCMN.search(" UPPER(EMP_NAME) AS EMPLOYEE, ISNULL(DESIGNATION_NAME,'') AS DESIGNATION, SALARYMASTER.SAL_NO AS SALNO, SALARYMASTER.SAL_MONTH AS SALMONTH ", "", " SALARYMASTER INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID= EMP_id INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN DESIGNATIONMASTER ON EMP_DESIGNATIONID = DESIGNATION_ID", " AND SALARYMASTER.SAL_YEARID = " & YEARID & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' ORDER BY (CASE WHEN SAL_MONTH = 'April'  THEN 0 WHEN SAL_MONTH = 'May'  THEN 1 WHEN SAL_MONTH = 'June'  THEN 2 WHEN SAL_MONTH = 'July'   THEN 3 WHEN SAL_MONTH = 'August'  THEN 4 WHEN SAL_MONTH = 'September'  THEN 5 WHEN SAL_MONTH = 'October'  THEN 6 WHEN SAL_MONTH = 'November'  THEN 7 WHEN SAL_MONTH = 'December'  THEN 8 WHEN SAL_MONTH = 'January'  THEN 9 WHEN SAL_MONTH = 'February'  THEN 10 WHEN SAL_MONTH = 'March'  THEN 11 END )")
                For Each DTROW As DataRow In DTEMP.Rows
                    RowIndex += 1
                    Write(DTROW("EMPLOYEE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("DESIGNATION"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("SALMONTH"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)

                    'GET THE SALARY DETAILS WITH RESPECT TO SALARYNO
                    Dim TEMPDEDCOLSTART As Integer = 4
                    Dim GROSSCOL As Integer = 4
                    For TEMPCOL As Integer = 4 To J - 1
                        Dim CHARACTER As String = Chr(64 + TEMPCOL)
                        If IsDBNull(objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text) = False Then TEMPCOLNAME = objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text
                        Dim DTSAL As System.Data.DataTable = OBJCMN.search("*", "", "(SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SAL_AMT,0) AS AMT FROM SALARYMASTER_EARNINGS INNER JOIN LEDGERS ON SAL_EARID = LEDGERS.ACC_ID WHERE SALARYMASTER_EARNINGS.SAL_YEARID = " & YEARID & " AND SALARYMASTER_EARNINGS.SAL_NO = " & Val(DTROW("SALNO")) & " UNION ALL SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SAL_AMT,0) AS AMT FROM SALARYMASTER_DEDUCTION INNER JOIN LEDGERS ON SAL_DEDID = LEDGERS.ACC_ID WHERE SALARYMASTER_DEDUCTION.SAL_YEARID = " & YEARID & " AND SALARYMASTER_DEDUCTION.SAL_NO = " & Val(DTROW("SALNO")) & ") AS T", " AND T.COLNAME = '" & TEMPCOLNAME & "'")
                        If DTSAL.Rows.Count > 0 Then Write(Val(DTSAL.Rows(0).Item("AMT")), Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9) Else Write("0", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9)

                        'IF COLNAME IS GROSS SALARY OR NETTSALARY THEN WRITE FORMULA THEN
                        If TEMPCOLNAME = "GROSS SALARY" Then
                            TEMPDEDCOLSTART = TEMPCOL + 1
                            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                            GROSSCOL = TEMPCOL
                        End If

                        If TEMPCOLNAME = "TOTAL DEDUCTION" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=SUM(" & objColumn.Item(TEMPDEDCOLSTART.ToString).ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If

                        If TEMPCOLNAME = "NETT SALARY" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=(" & objColumn.Item(GROSSCOL.ToString).ToString & RowIndex & ")-(" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If

                    Next
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                Next





                'HERE WE WANT EMPLOYEEWISE SUMMARY
                'ADDING ALL ROWS WITH RESPECT TO EMPLOYEES 
                RowIndex += 3
                Dim SUMMSTARTROWINDEX As Integer = RowIndex
                Dim DTEMPSUMM As System.Data.DataTable = OBJCMN.search(" UPPER(EMP_NAME) AS EMPLOYEE ", "", " SALARYMASTER INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID= EMP_id INNER JOIN LEDGERS ON SALARYMASTER.SAL_DEBITLEDGERID = LEDGERS.ACC_ID ", " AND SALARYMASTER.SAL_YEARID = " & YEARID & " AND LEDGERS.Acc_cmpname = '" & DTROWDEBITLEDGER("DEBITLEDGER") & "' GROUP BY EMPLOYEEMASTER.EMP_NAME ORDER BY EMPLOYEEMASTER.EMP_NAME ")
                For Each DTROW As DataRow In DTEMPSUMM.Rows
                    RowIndex += 1
                    Write(DTROW("EMPLOYEE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)

                    'GET THE SALARY DETAILS WITH RESPECT TO SALARYNO
                    Dim TEMPDEDCOLSTART As Integer = 4
                    Dim GROSSCOL As Integer = 4
                    For TEMPCOL As Integer = 4 To J - 1
                        Dim CHARACTER As String = Chr(64 + TEMPCOL)
                        If IsDBNull(objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text) = False Then TEMPCOLNAME = objSheet.Range(CHARACTER & TEMPROWINDEX.ToString).Text
                        Dim DTSAL As System.Data.DataTable = OBJCMN.search("*", "", "(SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SUM(SALARYMASTER_EARNINGS.SAL_AMT),0) AS AMT FROM SALARYMASTER_EARNINGS INNER JOIN LEDGERS ON SALARYMASTER_EARNINGS.SAL_EARID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER ON SALARYMASTER_EARNINGS.SAL_NO = SALARYMASTER.SAL_NO AND SALARYMASTER_EARNINGS.SAL_YEARID = SALARYMASTER.SAL_YEARID INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID = EMPLOYEEMASTER.EMP_ID WHERE SALARYMASTER_EARNINGS.SAL_YEARID = " & YEARID & " AND EMPLOYEEMASTER.EMP_NAME = '" & DTROW("EMPLOYEE") & "' GROUP BY ISNULL(LEDGERS.Acc_cmpname,'') UNION ALL SELECT ISNULL(LEDGERS.Acc_cmpname,'') AS COLNAME, ISNULL(SUM(SALARYMASTER_DEDUCTION.SAL_AMT),0) AS AMT FROM SALARYMASTER_DEDUCTION INNER JOIN LEDGERS ON SAL_DEDID = LEDGERS.ACC_ID INNER JOIN SALARYMASTER ON SALARYMASTER_DEDUCTION.SAL_NO = SALARYMASTER.SAL_NO AND SALARYMASTER_DEDUCTION.SAL_YEARID = SALARYMASTER.SAL_YEARID INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID = EMPLOYEEMASTER.EMP_ID WHERE SALARYMASTER_DEDUCTION.SAL_YEARID = " & YEARID & " AND EMPLOYEEMASTER.EMP_NAME = '" & DTROW("EMPLOYEE") & "' GROUP BY ISNULL(LEDGERS.Acc_cmpname,'')) AS T", " AND T.COLNAME = '" & TEMPCOLNAME & "'")
                        If DTSAL.Rows.Count > 0 Then Write(Val(DTSAL.Rows(0).Item("AMT")), Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9) Else Write("0", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , False, 9)

                        'IF COLNAME IS GROSS SALARY OR NETTSALARY THEN WRITE FORMULA THEN
                        If TEMPCOLNAME = "GROSS SALARY" Then
                            TEMPDEDCOLSTART = TEMPCOL + 1
                            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                            GROSSCOL = TEMPCOL
                        End If

                        If TEMPCOLNAME = "TOTAL DEDUCTION" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=SUM(" & objColumn.Item(TEMPDEDCOLSTART.ToString).ToString & RowIndex & ":" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If

                        If TEMPCOLNAME = "NETT SALARY" And TEMPDEDCOLSTART <> TEMPCOL Then
                            FORMULA("=(" & objColumn.Item(GROSSCOL.ToString).ToString & RowIndex & ")-(" & objColumn.Item((TEMPCOL - 1).ToString).ToString & RowIndex & ")", Range(TEMPCOL.ToString), XlHAlign.xlHAlignRight, , True, 9)
                        End If
                        SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                    Next
                Next




                'GIVE TOTAL
                RowIndex += 1
                Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For TEMPNO As Integer = 1 To J - 1
                    If TEMPNO > 3 Then
                        FORMULA("=SUM(" & objColumn.Item(TEMPNO.ToString).ToString & SUMMSTARTROWINDEX + 1 & ":" & objColumn.Item(TEMPNO.ToString).ToString & RowIndex - 1 & ")", Range(TEMPNO.ToString), XlHAlign.xlHAlignRight, , True, 10)
                        Dim CHARACTER As String = Chr(64 + TEMPNO)
                        GRANDTOTAL(TEMPNO) = Val(GRANDTOTAL(TEMPNO)) + objSheet.Range(CHARACTER & RowIndex).Text
                    End If
                    SetBorder(RowIndex, objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    objSheet.Range(objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex).NumberFormat = "##,##,###.00"
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((J - 1).ToString).ToString & RowIndex)
                'objSheet.Range(Range("1"), Range((J - 1).ToString)).Interior.Color = RGB(255, 165, 0)


            Next



            'GIVE TOTAL
            RowIndex += 2
            Write("GRANDTOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            For TEMPNO As Integer = 4 To GRANDTOTAL.Length - 1
                If TEMPNO > 3 And GRANDTOTAL(TEMPNO) > 0 Then
                    Write(GRANDTOTAL(TEMPNO), Range(TEMPNO.ToString), XlHAlign.xlHAlignRight, , True, 9, True)
                    SetBorder(RowIndex, objColumn.Item(TEMPNO.ToString).ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & TEMPROWINDEX, objColumn.Item(TEMPNO.ToString).ToString & RowIndex)
                    objSheet.Range(objColumn.Item(TEMPNO.ToString).ToString & RowIndex, objColumn.Item(TEMPNO.ToString).ToString & RowIndex).NumberFormat = "##,##,###.00"
                End If
            Next


            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

End Class
