
Imports Microsoft.Win32 ' for registry access
Imports System.IO


Module Module1

    '******** COMMON VARIABLES **************
    Public Mydate As DateTime                           'Used for SQL Date throughout the Software at the time of login

    ' '' -------NOTEPAD CODE --------
    'Public oFile As System.IO.File
    'Public oRead As System.IO.StreamReader = File.OpenText("C:\SERVERNAME.txt")
    'Public SERVERNAME As String = oRead.ReadToEnd
    ' '' ----------------- NOTEPAD CODE---------



    ''Public Servername As String = "THE-922954AD1EE"          'Used for Servername for reports
    'Public DatabaseName As String = "MNOWF"
    'Public DBUSERNAME As String = "sa"          'Used for Servername username for reports
    'Public Dbpassword As String = "infosys123"         ''Used for Servername password for reports
    'Public Dbsecurity As Boolean = False

    'Public Servername As String = "LAPTOP"          'Used for Servername for reports'
    'Public DatabaseName As String = "MNOWF"          'Used for Servername for reports'
    'Public DBUSERNAME As String = ""
    'Public Dbpassword As String = ""
    'Public Dbsecurity As Boolean = True


    Public SERVERNAME As String
    Public DatabaseName As String
    Public DBUSERNAME As String             'Used for Servername username for reports
    Public Dbpassword As String         ''Used for Servername password for reports
    Public Dbsecurity As Boolean


    '******** FORM WISE VARIABLES ************
    '---CMPDETAILS---
    Public CmpName As String            'Used for CmpName throughout the software 
    Public DBName As String             'Used for DBName throughout the software 
    Public CmpId As Integer             'Used for CmpId throughout the software
    Public YearId As Integer            'Used for YearId throughout the software
    Public AccFrom, AccTo As DateTime   'Used for A/C year start and end throughout the software
    Public Locationid As Integer        'Used for Locationid while login

    '---LOGIN---
    Public Userid As Integer                'Used for Userid while login
    Public UserName As String               'User for UserName while Login
    Public LastTransferDate As Date         'Used for getting LastTransferDate from getting data from eagle's database

    '---VARIABLE---
    Public USERRIGHTS As DataTable          'USED FOR USER RIGHTS THROUGHOUT THE APPLICATION 
    Public ADDPROFITINCAPITAL As Boolean = False
    Public WHATSAPPEXPDATE As Date          'Used for COMPANY'S WHATSAPP EXPIRY DATE
    Public ALLOWWHATSAPP As Boolean
    Public WHATSAPPAUTOCC As Boolean
    'CODE TO PROGRAMMATICALLY CREATE D. S. N.
    'Module CreateDSN

    Public CMPBANK As String       'Used for COMPANY'S BANKNAME 
    Public CMPACCNO As String       'Used for COMPANY'S ACCOUNT NO
    Public CMPIFSC As String       'Used for COMPANY'S IFSC CODE
    Public CMPUPI As String       'Used for COMPANY'S UPIID
    Public CMPTEL As String       'Used for COMPANY'S TELNO
    Public CMPADDRESS As String         'Used for COMPANY'S ADDRESS
    Public ClientName As String = ""

    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal ByValfRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
    Private Const vbAPINull As Integer = 0 ' NULL Pointer
    Private Const ODBC_ADD_SYS_DSN As Short = 1 ' Add data source

    Public Sub GETCONN()
        Try
            '-------NOTEPAD CODE --------

            Dim STARTPOS, ENDPOS As Integer
            Dim CONNSTR As String
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\CONNECTIONSTRING.txt")
            CONNSTR = oRead.ReadToEnd


            STARTPOS = CONNSTR.IndexOf("=", 0)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            SERVERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            DatabaseName = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            If CONNSTR.IndexOf("User ID", ENDPOS) > 0 Then
                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                DBUSERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                Dbpassword = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                Dbsecurity = False

            Else
                DBUSERNAME = ""
                Dbpassword = ""
                Dbsecurity = True
            End If

            '----------------- NOTEPAD CODE---------
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CreateUserDSN()
        Dim intRet As Integer
        Dim Driver As String
        Dim Attributes As New System.Text.StringBuilder
        Dim strConnect As String

        'Set the driver to SQL Server because it is most common.
        Driver = "SQL Server"
        'Set the attributes delimited by null.
        'See driver documentation for a complete
        'list of supported attributes.
        Attributes.Append("SERVER=" & SERVERNAME & Chr(0))
        Attributes.Append("DSN=EAGLE" & Chr(0))
        Attributes.Append("DESCRIPTION=New DSN" & Chr(0))
        Attributes.Append("DATABASE=" & DatabaseName & Chr(0))
        '        Attributes.Append("Password=infosys123" & Chr(0))
        Attributes.Append("Trusted_Connection=No" & Chr(0))
        strConnect = Attributes.ToString

        'strConnect = "driver={SQL Server};server=tcp:sql2k801.discountasp.net;" & _
        '  "DSN=EAGLE;database=" & DatabaseName & ";Username=UID=SQL2008_655591_eagletravels_user;PWD=infosys123;"

        'To show dialog, use Form1.Hwnd instead of vbAPINull.
        ' intRet = SQLConfigDataSource(vbAPINull, ODBC_ADD_SYS_DSN, Driver, Attributes)
        intRet = SQLConfigDataSource(vbAPINull, ODBC_ADD_SYS_DSN, Driver, Attributes.ToString)
        If intRet = 1 Then
            Dim regKey As RegistryKey, regSubKeySW As RegistryKey
            Dim regSubKeyODBC As RegistryKey, regSubKeyODBCINI As RegistryKey
            Dim regSales As RegistryKey
            Dim regPass As RegistryKey

            regKey = Registry.CurrentUser
            regSubKeySW = regKey.OpenSubKey("SOFTWARE")
            regSubKeyODBC = regSubKeySW.OpenSubKey("ODBC")
            regSubKeyODBCINI = regSubKeyODBC.OpenSubKey("ODBC.INI")
            regSales = regSubKeyODBCINI.OpenSubKey("EAGLE", True)
            regPass = regSubKeyODBCINI.OpenSubKey("EAGLE", True)
            ' CHANGE THE FOLLOWING LINE'S VALUE TO THE USER ID NEEDED TO CONNECT TO THE SQL DATA SOURCE
            regSales.SetValue("LastUser", "SQL2008_655591_eagletravels_user")
            regPass.SetValue("Password", "infosys123")
            'regPass.SetValue("PWD", "infosys123")

        End If

    End Sub
    Public Sub CreateUserDSN1()
        Dim sAttributes As New System.Text.StringBuilder
        Dim intRet As Integer
        Dim Driver As String
        'Dim Attributes As String

        ''Set the driver to SQL Server because it is most common.
        'Driver = "SQL Server"
        'Const ODBC_ADD_SYS_DSN = 4
        'Dim intResult As Long

        'sAttributes.Append("SERVER=" & Servername & Chr(0))
        'sAttributes.Append("DESCRIPTION=New DSN" & Chr(0))
        'sAttributes.Append("DSN=EAGLE" & Chr(0))
        'sAttributes.Append("DATABASE=" & DatabaseName & Chr(0))
        'sAttributes.Append("UID=SQL2008_655591_eagletravels_user" & Chr(0))
        'sAttributes.Append("PWD=infosys123" & Chr(0))
        'sAttributes.Append("Trusted_Connection=No" & Chr(0))
        'MsgBox(sAttributes.ToString)
        'intResult = SQLConfigDataSource(0&, ODBC_ADD_SYS_DSN, Driver, sAttributes.ToString)
        'sAttributes = Nothing
    End Sub
    'Sub CreateSQLServerDSN(ByVal DSNFile As String, ByVal DatabaseName As String,ByVal UserName As String, ByVal Password As String, Optional ByVal ServerName As String, Optional ByVal Description As String)

    '        Dim fnum As Integer
    '        Dim isOpen As Boolean

    '        On Error GoTo ErrorHandler

    '        fnum = FreeFile()

    '        isOpen = True

    '    Print #fnum, "[ODBC]"
    '    Print #fnum, "DRIVER=SQL Server"
    '    Print #fnum, "UID=" & UserName
    '    Print #fnum, "DATABASE=" & DatabaseName
    '    Print #fnum, "SERVER=" & IIf(ServerName = "", "(local)", ServerName)
    '        If Not IsMissing(Description) Then
    '        Print #fnum, "DESCRIPTION=" & Description
    '        End If

    '    Close #fnum
    '        Exit Sub

    'ErrorHandler:
    '    If isOpen Then Close #fnum
    '        Err.Raise(Err.Number, , Err.Description)

    'End Sub

End Module
