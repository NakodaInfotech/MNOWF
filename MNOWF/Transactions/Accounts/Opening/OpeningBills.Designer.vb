<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningBills
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningBills))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TXTIFSCCODE = New System.Windows.Forms.TextBox()
        Me.CMBCOURSEYEAR = New System.Windows.Forms.ComboBox()
        Me.CMBCOURSE = New System.Windows.Forms.ComboBox()
        Me.TXTUNINAME = New System.Windows.Forms.TextBox()
        Me.TXTINSTNAME = New System.Windows.Forms.TextBox()
        Me.TXTHOSPADD = New System.Windows.Forms.TextBox()
        Me.TXTHOSPNAME = New System.Windows.Forms.TextBox()
        Me.TXTDIAGNOSIS = New System.Windows.Forms.TextBox()
        Me.TXTACNAME = New System.Windows.Forms.TextBox()
        Me.TXTBANK = New System.Windows.Forms.TextBox()
        Me.TXTBRANCH = New System.Windows.Forms.TextBox()
        Me.TXTACNO = New System.Windows.Forms.TextBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.CMBCLAIMTYPE = New System.Windows.Forms.ComboBox()
        Me.TXTAMT = New System.Windows.Forms.TextBox()
        Me.TXTCLAIMAMT = New System.Windows.Forms.TextBox()
        Me.GRIDOPENING = New System.Windows.Forms.DataGridView()
        Me.CMBPATIENT = New System.Windows.Forms.ComboBox()
        Me.BILLDATE = New System.Windows.Forms.DateTimePicker()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.CMBOFFICER = New System.Windows.Forms.ComboBox()
        Me.TXTYEAR = New System.Windows.Forms.TextBox()
        Me.TXTREQNO = New System.Windows.Forms.TextBox()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.lbldrcropening = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtopening = New System.Windows.Forms.TextBox()
        Me.lblopbal = New System.Windows.Forms.Label()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.LBLTOTAL = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBILLTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBILLNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREQNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOFFNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCATEGORY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPATIENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCLAIMEDAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCLAIMTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBANK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBRANCH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GACNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GACNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GIFSCCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDIAGNOSIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GHOSPNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GHOSPADD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOURSENAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOURSEYEAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GINSTNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNINAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GVESSEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GYEAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBILLDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMTPAIDREC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXTRAAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRETURN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALANCE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBVESSEL = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GRIDOPENING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Panel1)
        Me.BlendPanel1.Controls.Add(Me.lbldrcropening)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.txtopening)
        Me.BlendPanel1.Controls.Add(Me.lblopbal)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTAL)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.Label31)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 561)
        Me.BlendPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CMBVESSEL)
        Me.Panel1.Controls.Add(Me.TXTIFSCCODE)
        Me.Panel1.Controls.Add(Me.CMBCOURSEYEAR)
        Me.Panel1.Controls.Add(Me.CMBCOURSE)
        Me.Panel1.Controls.Add(Me.TXTUNINAME)
        Me.Panel1.Controls.Add(Me.TXTINSTNAME)
        Me.Panel1.Controls.Add(Me.TXTHOSPADD)
        Me.Panel1.Controls.Add(Me.TXTHOSPNAME)
        Me.Panel1.Controls.Add(Me.TXTDIAGNOSIS)
        Me.Panel1.Controls.Add(Me.TXTACNAME)
        Me.Panel1.Controls.Add(Me.TXTBANK)
        Me.Panel1.Controls.Add(Me.TXTBRANCH)
        Me.Panel1.Controls.Add(Me.TXTACNO)
        Me.Panel1.Controls.Add(Me.TXTSRNO)
        Me.Panel1.Controls.Add(Me.CMBCLAIMTYPE)
        Me.Panel1.Controls.Add(Me.TXTAMT)
        Me.Panel1.Controls.Add(Me.TXTCLAIMAMT)
        Me.Panel1.Controls.Add(Me.GRIDOPENING)
        Me.Panel1.Controls.Add(Me.CMBPATIENT)
        Me.Panel1.Controls.Add(Me.BILLDATE)
        Me.Panel1.Controls.Add(Me.CMBCATEGORY)
        Me.Panel1.Controls.Add(Me.TXTBILLNO)
        Me.Panel1.Controls.Add(Me.CMBOFFICER)
        Me.Panel1.Controls.Add(Me.TXTYEAR)
        Me.Panel1.Controls.Add(Me.TXTREQNO)
        Me.Panel1.Controls.Add(Me.CMBTYPE)
        Me.Panel1.Location = New System.Drawing.Point(23, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1189, 424)
        Me.Panel1.TabIndex = 1
        '
        'TXTIFSCCODE
        '
        Me.TXTIFSCCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIFSCCODE.ForeColor = System.Drawing.Color.Black
        Me.TXTIFSCCODE.Location = New System.Drawing.Point(1503, 3)
        Me.TXTIFSCCODE.Name = "TXTIFSCCODE"
        Me.TXTIFSCCODE.Size = New System.Drawing.Size(100, 23)
        Me.TXTIFSCCODE.TabIndex = 12
        Me.TXTIFSCCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBCOURSEYEAR
        '
        Me.CMBCOURSEYEAR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOURSEYEAR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOURSEYEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOURSEYEAR.FormattingEnabled = True
        Me.CMBCOURSEYEAR.Location = New System.Drawing.Point(2403, 3)
        Me.CMBCOURSEYEAR.MaxDropDownItems = 14
        Me.CMBCOURSEYEAR.Name = "CMBCOURSEYEAR"
        Me.CMBCOURSEYEAR.Size = New System.Drawing.Size(100, 23)
        Me.CMBCOURSEYEAR.TabIndex = 17
        '
        'CMBCOURSE
        '
        Me.CMBCOURSE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOURSE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOURSE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOURSE.FormattingEnabled = True
        Me.CMBCOURSE.Location = New System.Drawing.Point(2203, 3)
        Me.CMBCOURSE.MaxDropDownItems = 14
        Me.CMBCOURSE.Name = "CMBCOURSE"
        Me.CMBCOURSE.Size = New System.Drawing.Size(200, 23)
        Me.CMBCOURSE.TabIndex = 16
        '
        'TXTUNINAME
        '
        Me.TXTUNINAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUNINAME.Location = New System.Drawing.Point(2703, 3)
        Me.TXTUNINAME.Name = "TXTUNINAME"
        Me.TXTUNINAME.Size = New System.Drawing.Size(200, 23)
        Me.TXTUNINAME.TabIndex = 19
        '
        'TXTINSTNAME
        '
        Me.TXTINSTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINSTNAME.Location = New System.Drawing.Point(2503, 3)
        Me.TXTINSTNAME.Name = "TXTINSTNAME"
        Me.TXTINSTNAME.Size = New System.Drawing.Size(200, 23)
        Me.TXTINSTNAME.TabIndex = 18
        '
        'TXTHOSPADD
        '
        Me.TXTHOSPADD.BackColor = System.Drawing.SystemColors.Window
        Me.TXTHOSPADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOSPADD.ForeColor = System.Drawing.Color.Black
        Me.TXTHOSPADD.Location = New System.Drawing.Point(2003, 3)
        Me.TXTHOSPADD.Name = "TXTHOSPADD"
        Me.TXTHOSPADD.Size = New System.Drawing.Size(200, 23)
        Me.TXTHOSPADD.TabIndex = 15
        '
        'TXTHOSPNAME
        '
        Me.TXTHOSPNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOSPNAME.Location = New System.Drawing.Point(1803, 3)
        Me.TXTHOSPNAME.Name = "TXTHOSPNAME"
        Me.TXTHOSPNAME.Size = New System.Drawing.Size(200, 23)
        Me.TXTHOSPNAME.TabIndex = 14
        '
        'TXTDIAGNOSIS
        '
        Me.TXTDIAGNOSIS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDIAGNOSIS.Location = New System.Drawing.Point(1603, 3)
        Me.TXTDIAGNOSIS.Name = "TXTDIAGNOSIS"
        Me.TXTDIAGNOSIS.Size = New System.Drawing.Size(200, 23)
        Me.TXTDIAGNOSIS.TabIndex = 13
        '
        'TXTACNAME
        '
        Me.TXTACNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTACNAME.Location = New System.Drawing.Point(1213, 3)
        Me.TXTACNAME.Name = "TXTACNAME"
        Me.TXTACNAME.Size = New System.Drawing.Size(190, 23)
        Me.TXTACNAME.TabIndex = 10
        '
        'TXTBANK
        '
        Me.TXTBANK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBANK.ForeColor = System.Drawing.Color.Black
        Me.TXTBANK.Location = New System.Drawing.Point(913, 3)
        Me.TXTBANK.Name = "TXTBANK"
        Me.TXTBANK.Size = New System.Drawing.Size(200, 23)
        Me.TXTBANK.TabIndex = 8
        '
        'TXTBRANCH
        '
        Me.TXTBRANCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBRANCH.ForeColor = System.Drawing.Color.Black
        Me.TXTBRANCH.Location = New System.Drawing.Point(1113, 3)
        Me.TXTBRANCH.Name = "TXTBRANCH"
        Me.TXTBRANCH.Size = New System.Drawing.Size(100, 23)
        Me.TXTBRANCH.TabIndex = 9
        '
        'TXTACNO
        '
        Me.TXTACNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACNO.ForeColor = System.Drawing.Color.Black
        Me.TXTACNO.Location = New System.Drawing.Point(1403, 3)
        Me.TXTACNO.Name = "TXTACNO"
        Me.TXTACNO.Size = New System.Drawing.Size(100, 23)
        Me.TXTACNO.TabIndex = 11
        Me.TXTACNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(3, 3)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 1
        Me.TXTSRNO.TabStop = False
        '
        'CMBCLAIMTYPE
        '
        Me.CMBCLAIMTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCLAIMTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCLAIMTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBCLAIMTYPE.Enabled = False
        Me.CMBCLAIMTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCLAIMTYPE.FormattingEnabled = True
        Me.CMBCLAIMTYPE.Items.AddRange(New Object() {"MEDICAL", "EDUCATION", "BOOKING", "REFUND"})
        Me.CMBCLAIMTYPE.Location = New System.Drawing.Point(833, 3)
        Me.CMBCLAIMTYPE.Name = "CMBCLAIMTYPE"
        Me.CMBCLAIMTYPE.Size = New System.Drawing.Size(80, 23)
        Me.CMBCLAIMTYPE.TabIndex = 7
        '
        'TXTAMT
        '
        Me.TXTAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMT.Location = New System.Drawing.Point(3313, 3)
        Me.TXTAMT.Name = "TXTAMT"
        Me.TXTAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTAMT.TabIndex = 23
        Me.TXTAMT.Text = "0.00"
        Me.TXTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCLAIMAMT
        '
        Me.TXTCLAIMAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCLAIMAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCLAIMAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLAIMAMT.Location = New System.Drawing.Point(753, 3)
        Me.TXTCLAIMAMT.MaxLength = 10
        Me.TXTCLAIMAMT.Name = "TXTCLAIMAMT"
        Me.TXTCLAIMAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTCLAIMAMT.TabIndex = 6
        Me.TXTCLAIMAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDOPENING
        '
        Me.GRIDOPENING.AllowUserToAddRows = False
        Me.GRIDOPENING.AllowUserToDeleteRows = False
        Me.GRIDOPENING.AllowUserToResizeColumns = False
        Me.GRIDOPENING.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDOPENING.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDOPENING.BackgroundColor = System.Drawing.Color.White
        Me.GRIDOPENING.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDOPENING.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDOPENING.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDOPENING.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDOPENING.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GBILLTYPE, Me.GBILLNO, Me.GREQNO, Me.GOFFNAME, Me.GCATEGORY, Me.GPATIENT, Me.GCLAIMEDAMT, Me.GCLAIMTYPE, Me.GBANK, Me.GBRANCH, Me.GACNAME, Me.GACNO, Me.GIFSCCODE, Me.GDIAGNOSIS, Me.GHOSPNAME, Me.GHOSPADD, Me.GCOURSENAME, Me.GCOURSEYEAR, Me.GINSTNAME, Me.GUNINAME, Me.GVESSEL, Me.GYEAR, Me.GBILLDATE, Me.GAMT, Me.GAMTPAIDREC, Me.GEXTRAAMT, Me.GRETURN, Me.GBALANCE})
        Me.GRIDOPENING.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDOPENING.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDOPENING.Location = New System.Drawing.Point(3, 26)
        Me.GRIDOPENING.MultiSelect = False
        Me.GRIDOPENING.Name = "GRIDOPENING"
        Me.GRIDOPENING.ReadOnly = True
        Me.GRIDOPENING.RowHeadersVisible = False
        Me.GRIDOPENING.RowHeadersWidth = 30
        Me.GRIDOPENING.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDOPENING.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDOPENING.RowTemplate.Height = 20
        Me.GRIDOPENING.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDOPENING.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDOPENING.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDOPENING.Size = New System.Drawing.Size(3426, 381)
        Me.GRIDOPENING.TabIndex = 7
        Me.GRIDOPENING.TabStop = False
        '
        'CMBPATIENT
        '
        Me.CMBPATIENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPATIENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPATIENT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPATIENT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPATIENT.FormattingEnabled = True
        Me.CMBPATIENT.Items.AddRange(New Object() {""})
        Me.CMBPATIENT.Location = New System.Drawing.Point(603, 3)
        Me.CMBPATIENT.Name = "CMBPATIENT"
        Me.CMBPATIENT.Size = New System.Drawing.Size(150, 23)
        Me.CMBPATIENT.TabIndex = 5
        '
        'BILLDATE
        '
        Me.BILLDATE.CustomFormat = "dd/MM/yyyy"
        Me.BILLDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BILLDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BILLDATE.Location = New System.Drawing.Point(3223, 3)
        Me.BILLDATE.Name = "BILLDATE"
        Me.BILLDATE.Size = New System.Drawing.Size(90, 23)
        Me.BILLDATE.TabIndex = 22
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Items.AddRange(New Object() {""})
        Me.CMBCATEGORY.Location = New System.Drawing.Point(453, 3)
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(150, 23)
        Me.CMBCATEGORY.TabIndex = 4
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.Location = New System.Drawing.Point(123, 3)
        Me.TXTBILLNO.MaxLength = 10
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(70, 23)
        Me.TXTBILLNO.TabIndex = 1
        Me.TXTBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBOFFICER
        '
        Me.CMBOFFICER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICER.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBOFFICER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICER.FormattingEnabled = True
        Me.CMBOFFICER.Items.AddRange(New Object() {""})
        Me.CMBOFFICER.Location = New System.Drawing.Point(263, 3)
        Me.CMBOFFICER.Name = "CMBOFFICER"
        Me.CMBOFFICER.Size = New System.Drawing.Size(190, 23)
        Me.CMBOFFICER.TabIndex = 3
        '
        'TXTYEAR
        '
        Me.TXTYEAR.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTYEAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTYEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTYEAR.Location = New System.Drawing.Point(3153, 3)
        Me.TXTYEAR.MaxLength = 10
        Me.TXTYEAR.Name = "TXTYEAR"
        Me.TXTYEAR.Size = New System.Drawing.Size(70, 23)
        Me.TXTYEAR.TabIndex = 21
        Me.TXTYEAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTREQNO
        '
        Me.TXTREQNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTREQNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTREQNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREQNO.Location = New System.Drawing.Point(193, 3)
        Me.TXTREQNO.MaxLength = 10
        Me.TXTREQNO.Name = "TXTREQNO"
        Me.TXTREQNO.Size = New System.Drawing.Size(70, 23)
        Me.TXTREQNO.TabIndex = 2
        Me.TXTREQNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Enabled = False
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"PURCHASE", "SALE"})
        Me.CMBTYPE.Location = New System.Drawing.Point(43, 3)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(80, 23)
        Me.CMBTYPE.TabIndex = 0
        '
        'lbldrcropening
        '
        Me.lbldrcropening.AutoSize = True
        Me.lbldrcropening.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcropening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcropening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcropening.Location = New System.Drawing.Point(618, 45)
        Me.lbldrcropening.Name = "lbldrcropening"
        Me.lbldrcropening.Size = New System.Drawing.Size(0, 15)
        Me.lbldrcropening.TabIndex = 490
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.ToolStripdelete, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 652
        Me.ToolStrip1.Text = "v"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "&Delete All"
        Me.ToolStripdelete.ToolTipText = "Delete Contra"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.Linen
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(516, 42)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(100, 23)
        Me.txtopening.TabIndex = 489
        Me.txtopening.TabStop = False
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(466, 45)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(49, 15)
        Me.lblopbal.TabIndex = 488
        Me.lblopbal.Text = "O/P Bal"
        '
        'TXTADD
        '
        Me.TXTADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(941, 41)
        Me.TXTADD.MaxLength = 10
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(30, 23)
        Me.TXTADD.TabIndex = 649
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'LBLTOTAL
        '
        Me.LBLTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTAL.Location = New System.Drawing.Point(1041, 501)
        Me.LBLTOTAL.Name = "LBLTOTAL"
        Me.LBLTOTAL.Size = New System.Drawing.Size(102, 14)
        Me.LBLTOTAL.TabIndex = 648
        Me.LBLTOTAL.Text = "0.00"
        Me.LBLTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1012, 501)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 14)
        Me.Label23.TabIndex = 647
        Me.Label23.Text = "Total"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(873, 42)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(82, 15)
        Me.Label31.TabIndex = 643
        Me.Label31.Text = "Sale A/C Code"
        Me.Label31.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(142, 45)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(86, 15)
        Me.Label33.TabIndex = 642
        Me.Label33.Text = "Sale A/C Name"
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(957, 38)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(74, 23)
        Me.CMBACCCODE.TabIndex = 640
        Me.CMBACCCODE.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(231, 41)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(219, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(552, 501)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 3
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(466, 501)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(638, 501)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(105, 20)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Opening Bill"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GBILLTYPE
        '
        Me.GBILLTYPE.HeaderText = "Bill Type"
        Me.GBILLTYPE.Name = "GBILLTYPE"
        Me.GBILLTYPE.ReadOnly = True
        Me.GBILLTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBILLTYPE.Width = 80
        '
        'GBILLNO
        '
        Me.GBILLNO.HeaderText = "Claim No"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.ReadOnly = True
        Me.GBILLNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBILLNO.Width = 70
        '
        'GREQNO
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GREQNO.DefaultCellStyle = DataGridViewCellStyle3
        Me.GREQNO.HeaderText = "Req No"
        Me.GREQNO.Name = "GREQNO"
        Me.GREQNO.ReadOnly = True
        Me.GREQNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREQNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREQNO.Width = 70
        '
        'GOFFNAME
        '
        Me.GOFFNAME.HeaderText = "Officer Name"
        Me.GOFFNAME.Name = "GOFFNAME"
        Me.GOFFNAME.ReadOnly = True
        Me.GOFFNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOFFNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOFFNAME.Width = 190
        '
        'GCATEGORY
        '
        Me.GCATEGORY.HeaderText = "Category"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.ReadOnly = True
        Me.GCATEGORY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCATEGORY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCATEGORY.Width = 150
        '
        'GPATIENT
        '
        Me.GPATIENT.HeaderText = "Patient"
        Me.GPATIENT.Name = "GPATIENT"
        Me.GPATIENT.ReadOnly = True
        Me.GPATIENT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPATIENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPATIENT.Width = 150
        '
        'GCLAIMEDAMT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCLAIMEDAMT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GCLAIMEDAMT.HeaderText = "Claim Amt"
        Me.GCLAIMEDAMT.Name = "GCLAIMEDAMT"
        Me.GCLAIMEDAMT.ReadOnly = True
        Me.GCLAIMEDAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCLAIMEDAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCLAIMEDAMT.Width = 80
        '
        'GCLAIMTYPE
        '
        Me.GCLAIMTYPE.HeaderText = "Claim Type"
        Me.GCLAIMTYPE.Name = "GCLAIMTYPE"
        Me.GCLAIMTYPE.ReadOnly = True
        Me.GCLAIMTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCLAIMTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCLAIMTYPE.Width = 80
        '
        'GBANK
        '
        Me.GBANK.HeaderText = "Bank Name"
        Me.GBANK.Name = "GBANK"
        Me.GBANK.ReadOnly = True
        Me.GBANK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBANK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBANK.Width = 200
        '
        'GBRANCH
        '
        Me.GBRANCH.HeaderText = "Branch"
        Me.GBRANCH.Name = "GBRANCH"
        Me.GBRANCH.ReadOnly = True
        Me.GBRANCH.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBRANCH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GACNAME
        '
        Me.GACNAME.HeaderText = "A/C Holders Name"
        Me.GACNAME.Name = "GACNAME"
        Me.GACNAME.ReadOnly = True
        Me.GACNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GACNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GACNAME.Width = 190
        '
        'GACNO
        '
        Me.GACNO.HeaderText = "A/C No"
        Me.GACNO.Name = "GACNO"
        Me.GACNO.ReadOnly = True
        Me.GACNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GACNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GIFSCCODE
        '
        Me.GIFSCCODE.HeaderText = "IFSC Code"
        Me.GIFSCCODE.Name = "GIFSCCODE"
        Me.GIFSCCODE.ReadOnly = True
        Me.GIFSCCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GIFSCCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GDIAGNOSIS
        '
        Me.GDIAGNOSIS.HeaderText = "Diagnosis"
        Me.GDIAGNOSIS.Name = "GDIAGNOSIS"
        Me.GDIAGNOSIS.ReadOnly = True
        Me.GDIAGNOSIS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDIAGNOSIS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDIAGNOSIS.Width = 200
        '
        'GHOSPNAME
        '
        Me.GHOSPNAME.HeaderText = "Hospital Name"
        Me.GHOSPNAME.Name = "GHOSPNAME"
        Me.GHOSPNAME.ReadOnly = True
        Me.GHOSPNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GHOSPNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GHOSPNAME.Width = 200
        '
        'GHOSPADD
        '
        Me.GHOSPADD.HeaderText = "Hosiptal Address"
        Me.GHOSPADD.Name = "GHOSPADD"
        Me.GHOSPADD.ReadOnly = True
        Me.GHOSPADD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GHOSPADD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GHOSPADD.Width = 200
        '
        'GCOURSENAME
        '
        Me.GCOURSENAME.HeaderText = "Course Name"
        Me.GCOURSENAME.Name = "GCOURSENAME"
        Me.GCOURSENAME.ReadOnly = True
        Me.GCOURSENAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOURSENAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCOURSENAME.Width = 200
        '
        'GCOURSEYEAR
        '
        Me.GCOURSEYEAR.HeaderText = "Course Year"
        Me.GCOURSEYEAR.Name = "GCOURSEYEAR"
        Me.GCOURSEYEAR.ReadOnly = True
        Me.GCOURSEYEAR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOURSEYEAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GINSTNAME
        '
        Me.GINSTNAME.HeaderText = "Institute Name"
        Me.GINSTNAME.Name = "GINSTNAME"
        Me.GINSTNAME.ReadOnly = True
        Me.GINSTNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GINSTNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GINSTNAME.Width = 200
        '
        'GUNINAME
        '
        Me.GUNINAME.HeaderText = "University"
        Me.GUNINAME.Name = "GUNINAME"
        Me.GUNINAME.ReadOnly = True
        Me.GUNINAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNINAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUNINAME.Width = 200
        '
        'GVESSEL
        '
        Me.GVESSEL.HeaderText = "Vessel"
        Me.GVESSEL.Name = "GVESSEL"
        Me.GVESSEL.ReadOnly = True
        Me.GVESSEL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GVESSEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GVESSEL.Width = 250
        '
        'GYEAR
        '
        Me.GYEAR.HeaderText = "Year"
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.ReadOnly = True
        Me.GYEAR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GYEAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GYEAR.Width = 70
        '
        'GBILLDATE
        '
        Me.GBILLDATE.HeaderText = "Date"
        Me.GBILLDATE.Name = "GBILLDATE"
        Me.GBILLDATE.ReadOnly = True
        Me.GBILLDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBILLDATE.Width = 90
        '
        'GAMT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GAMT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GAMT.HeaderText = "Amt"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.ReadOnly = True
        Me.GAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMT.Width = 80
        '
        'GAMTPAIDREC
        '
        Me.GAMTPAIDREC.HeaderText = "AMT PAID"
        Me.GAMTPAIDREC.Name = "GAMTPAIDREC"
        Me.GAMTPAIDREC.ReadOnly = True
        Me.GAMTPAIDREC.Visible = False
        '
        'GEXTRAAMT
        '
        Me.GEXTRAAMT.HeaderText = "EXTRA AMT"
        Me.GEXTRAAMT.Name = "GEXTRAAMT"
        Me.GEXTRAAMT.ReadOnly = True
        Me.GEXTRAAMT.Visible = False
        '
        'GRETURN
        '
        Me.GRETURN.HeaderText = "RETURN"
        Me.GRETURN.Name = "GRETURN"
        Me.GRETURN.ReadOnly = True
        Me.GRETURN.Visible = False
        '
        'GBALANCE
        '
        Me.GBALANCE.HeaderText = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.ReadOnly = True
        Me.GBALANCE.Visible = False
        '
        'CMBVESSEL
        '
        Me.CMBVESSEL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBVESSEL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBVESSEL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBVESSEL.FormattingEnabled = True
        Me.CMBVESSEL.Location = New System.Drawing.Point(2903, 3)
        Me.CMBVESSEL.MaxDropDownItems = 14
        Me.CMBVESSEL.Name = "CMBVESSEL"
        Me.CMBVESSEL.Size = New System.Drawing.Size(250, 23)
        Me.CMBVESSEL.TabIndex = 20
        '
        'OpeningBills
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningBills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Bills"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRIDOPENING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents BILLDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDOPENING As System.Windows.Forms.DataGridView
    Friend WithEvents TXTYEAR As System.Windows.Forms.TextBox
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents GPURSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents LBLTOTAL As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbldrcropening As System.Windows.Forms.Label
    Friend WithEvents txtopening As System.Windows.Forms.TextBox
    Friend WithEvents lblopbal As System.Windows.Forms.Label
    Friend WithEvents TXTCLAIMAMT As System.Windows.Forms.TextBox
    Friend WithEvents CMBPATIENT As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents CMBOFFICER As System.Windows.Forms.ComboBox
    Friend WithEvents TXTREQNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBCLAIMTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TXTACNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTBANK As System.Windows.Forms.TextBox
    Friend WithEvents TXTBRANCH As System.Windows.Forms.TextBox
    Friend WithEvents TXTACNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTHOSPADD As System.Windows.Forms.TextBox
    Friend WithEvents TXTHOSPNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTDIAGNOSIS As System.Windows.Forms.TextBox
    Friend WithEvents CMBCOURSEYEAR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCOURSE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTUNINAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTINSTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTIFSCCODE As TextBox
    Friend WithEvents CMBVESSEL As ComboBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GBILLTYPE As DataGridViewTextBoxColumn
    Friend WithEvents GBILLNO As DataGridViewTextBoxColumn
    Friend WithEvents GREQNO As DataGridViewTextBoxColumn
    Friend WithEvents GOFFNAME As DataGridViewTextBoxColumn
    Friend WithEvents GCATEGORY As DataGridViewTextBoxColumn
    Friend WithEvents GPATIENT As DataGridViewTextBoxColumn
    Friend WithEvents GCLAIMEDAMT As DataGridViewTextBoxColumn
    Friend WithEvents GCLAIMTYPE As DataGridViewTextBoxColumn
    Friend WithEvents GBANK As DataGridViewTextBoxColumn
    Friend WithEvents GBRANCH As DataGridViewTextBoxColumn
    Friend WithEvents GACNAME As DataGridViewTextBoxColumn
    Friend WithEvents GACNO As DataGridViewTextBoxColumn
    Friend WithEvents GIFSCCODE As DataGridViewTextBoxColumn
    Friend WithEvents GDIAGNOSIS As DataGridViewTextBoxColumn
    Friend WithEvents GHOSPNAME As DataGridViewTextBoxColumn
    Friend WithEvents GHOSPADD As DataGridViewTextBoxColumn
    Friend WithEvents GCOURSENAME As DataGridViewTextBoxColumn
    Friend WithEvents GCOURSEYEAR As DataGridViewTextBoxColumn
    Friend WithEvents GINSTNAME As DataGridViewTextBoxColumn
    Friend WithEvents GUNINAME As DataGridViewTextBoxColumn
    Friend WithEvents GVESSEL As DataGridViewTextBoxColumn
    Friend WithEvents GYEAR As DataGridViewTextBoxColumn
    Friend WithEvents GBILLDATE As DataGridViewTextBoxColumn
    Friend WithEvents GAMT As DataGridViewTextBoxColumn
    Friend WithEvents GAMTPAIDREC As DataGridViewTextBoxColumn
    Friend WithEvents GEXTRAAMT As DataGridViewTextBoxColumn
    Friend WithEvents GRETURN As DataGridViewTextBoxColumn
    Friend WithEvents GBALANCE As DataGridViewTextBoxColumn
End Class
