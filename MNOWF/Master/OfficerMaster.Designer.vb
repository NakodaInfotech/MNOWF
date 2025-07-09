<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OfficerMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDQRCODE = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTSERVICE = New System.Windows.Forms.TextBox()
        Me.CHKCONTRACT = New System.Windows.Forms.CheckBox()
        Me.CHKDONATION = New System.Windows.Forms.CheckBox()
        Me.CHKCONTRIBUTION = New System.Windows.Forms.CheckBox()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTOFFICERNO = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TXTCALCDOB = New System.Windows.Forms.TextBox()
        Me.CMBFAMILY = New System.Windows.Forms.ComboBox()
        Me.CMBRELATION = New System.Windows.Forms.ComboBox()
        Me.GRIDDETAILS = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFAMILY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRELATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTAGE = New System.Windows.Forms.TextBox()
        Me.DOB = New System.Windows.Forms.DateTimePicker()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTMUINO = New System.Windows.Forms.TextBox()
        Me.txtmobile = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbemail = New System.Windows.Forms.ComboBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.DOJ = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DECDATE = New System.Windows.Forms.DateTimePicker()
        Me.txtstd = New System.Windows.Forms.TextBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.CHKINDIAN = New System.Windows.Forms.CheckBox()
        Me.CMBCMPNAME = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.CMBRANK = New System.Windows.Forms.ComboBox()
        Me.LBLRANK = New System.Windows.Forms.Label()
        Me.TXTEMPCODE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtresino = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDQRCODE)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTSERVICE)
        Me.BlendPanel1.Controls.Add(Me.CHKCONTRACT)
        Me.BlendPanel1.Controls.Add(Me.CHKDONATION)
        Me.BlendPanel1.Controls.Add(Me.CHKCONTRIBUTION)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO)
        Me.BlendPanel1.Controls.Add(Me.GroupBox4)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTMUINO)
        Me.BlendPanel1.Controls.Add(Me.txtmobile)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.cmbemail)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.Label31)
        Me.BlendPanel1.Controls.Add(Me.txtfax)
        Me.BlendPanel1.Controls.Add(Me.DOJ)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label25)
        Me.BlendPanel1.Controls.Add(Me.DECDATE)
        Me.BlendPanel1.Controls.Add(Me.txtstd)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.CHKINDIAN)
        Me.BlendPanel1.Controls.Add(Me.CMBCMPNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label30)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.CMBRANK)
        Me.BlendPanel1.Controls.Add(Me.LBLRANK)
        Me.BlendPanel1.Controls.Add(Me.TXTEMPCODE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtresino)
        Me.BlendPanel1.Controls.Add(Me.Label26)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(616, 567)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDQRCODE
        '
        Me.CMDQRCODE.Location = New System.Drawing.Point(465, 532)
        Me.CMDQRCODE.Name = "CMDQRCODE"
        Me.CMDQRCODE.Size = New System.Drawing.Size(75, 23)
        Me.CMDQRCODE.TabIndex = 473
        Me.CMDQRCODE.Text = "QR CODE"
        Me.CMDQRCODE.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(80, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 14)
        Me.Label8.TabIndex = 472
        Me.Label8.Text = "Address"
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.SystemColors.Window
        Me.txtadd.ForeColor = System.Drawing.Color.Black
        Me.txtadd.Location = New System.Drawing.Point(133, 196)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(455, 46)
        Me.txtadd.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 14)
        Me.Label5.TabIndex = 471
        Me.Label5.Text = "Details Of Service"
        '
        'TXTSERVICE
        '
        Me.TXTSERVICE.BackColor = System.Drawing.SystemColors.Window
        Me.TXTSERVICE.ForeColor = System.Drawing.Color.Black
        Me.TXTSERVICE.Location = New System.Drawing.Point(133, 147)
        Me.TXTSERVICE.Multiline = True
        Me.TXTSERVICE.Name = "TXTSERVICE"
        Me.TXTSERVICE.Size = New System.Drawing.Size(455, 46)
        Me.TXTSERVICE.TabIndex = 11
        '
        'CHKCONTRACT
        '
        Me.CHKCONTRACT.AutoSize = True
        Me.CHKCONTRACT.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRACT.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRACT.Location = New System.Drawing.Point(205, 124)
        Me.CHKCONTRACT.Name = "CHKCONTRACT"
        Me.CHKCONTRACT.Size = New System.Drawing.Size(70, 18)
        Me.CHKCONTRACT.TabIndex = 8
        Me.CHKCONTRACT.Text = "Contract"
        Me.CHKCONTRACT.UseVisualStyleBackColor = False
        '
        'CHKDONATION
        '
        Me.CHKDONATION.AutoSize = True
        Me.CHKDONATION.BackColor = System.Drawing.Color.Transparent
        Me.CHKDONATION.ForeColor = System.Drawing.Color.Black
        Me.CHKDONATION.Location = New System.Drawing.Point(482, 124)
        Me.CHKDONATION.Name = "CHKDONATION"
        Me.CHKDONATION.Size = New System.Drawing.Size(105, 18)
        Me.CHKDONATION.TabIndex = 10
        Me.CHKDONATION.Text = "Donation Recd"
        Me.CHKDONATION.UseVisualStyleBackColor = False
        '
        'CHKCONTRIBUTION
        '
        Me.CHKCONTRIBUTION.AutoSize = True
        Me.CHKCONTRIBUTION.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRIBUTION.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRIBUTION.Location = New System.Drawing.Point(282, 124)
        Me.CHKCONTRIBUTION.Name = "CHKCONTRIBUTION"
        Me.CHKCONTRIBUTION.Size = New System.Drawing.Size(122, 18)
        Me.CHKCONTRIBUTION.TabIndex = 9
        Me.CHKCONTRIBUTION.Text = "Contribution Recd"
        Me.CHKCONTRIBUTION.UseVisualStyleBackColor = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDCLEAR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Image = Global.MNOWF.My.Resources.Resources.clear
        Me.CMDCLEAR.Location = New System.Drawing.Point(233, 530)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(72, 26)
        Me.CMDCLEAR.TabIndex = 21
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(63, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 14)
        Me.Label4.TabIndex = 469
        Me.Label4.Text = "MNOWF No"
        '
        'TXTOFFICERNO
        '
        Me.TXTOFFICERNO.BackColor = System.Drawing.Color.Pink
        Me.TXTOFFICERNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO.Location = New System.Drawing.Point(133, 16)
        Me.TXTOFFICERNO.Name = "TXTOFFICERNO"
        Me.TXTOFFICERNO.ReadOnly = True
        Me.TXTOFFICERNO.Size = New System.Drawing.Size(81, 22)
        Me.TXTOFFICERNO.TabIndex = 468
        Me.TXTOFFICERNO.TabStop = False
        Me.TXTOFFICERNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.TXTCALCDOB)
        Me.GroupBox4.Controls.Add(Me.CMBFAMILY)
        Me.GroupBox4.Controls.Add(Me.CMBRELATION)
        Me.GroupBox4.Controls.Add(Me.GRIDDETAILS)
        Me.GroupBox4.Controls.Add(Me.TXTAGE)
        Me.GroupBox4.Controls.Add(Me.DOB)
        Me.GroupBox4.Controls.Add(Me.TXTSRNO)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(76, 303)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(512, 170)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Family Details / Dependents"
        '
        'TXTCALCDOB
        '
        Me.TXTCALCDOB.BackColor = System.Drawing.Color.White
        Me.TXTCALCDOB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCALCDOB.Location = New System.Drawing.Point(247, 0)
        Me.TXTCALCDOB.Name = "TXTCALCDOB"
        Me.TXTCALCDOB.Size = New System.Drawing.Size(50, 22)
        Me.TXTCALCDOB.TabIndex = 2
        Me.TXTCALCDOB.TabStop = False
        Me.TXTCALCDOB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBFAMILY
        '
        Me.CMBFAMILY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFAMILY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFAMILY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFAMILY.FormattingEnabled = True
        Me.CMBFAMILY.Location = New System.Drawing.Point(47, 23)
        Me.CMBFAMILY.MaxDropDownItems = 14
        Me.CMBFAMILY.Name = "CMBFAMILY"
        Me.CMBFAMILY.Size = New System.Drawing.Size(200, 22)
        Me.CMBFAMILY.TabIndex = 1
        '
        'CMBRELATION
        '
        Me.CMBRELATION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBRELATION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBRELATION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRELATION.FormattingEnabled = True
        Me.CMBRELATION.Location = New System.Drawing.Point(380, 23)
        Me.CMBRELATION.MaxDropDownItems = 14
        Me.CMBRELATION.Name = "CMBRELATION"
        Me.CMBRELATION.Size = New System.Drawing.Size(100, 22)
        Me.CMBRELATION.TabIndex = 5
        '
        'GRIDDETAILS
        '
        Me.GRIDDETAILS.AllowUserToAddRows = False
        Me.GRIDDETAILS.AllowUserToDeleteRows = False
        Me.GRIDDETAILS.AllowUserToResizeColumns = False
        Me.GRIDDETAILS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDDETAILS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDDETAILS.BackgroundColor = System.Drawing.Color.White
        Me.GRIDDETAILS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDDETAILS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDDETAILS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDDETAILS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDDETAILS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GFAMILY, Me.GDOB, Me.GAGE, Me.GRELATION})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDDETAILS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDDETAILS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDDETAILS.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDDETAILS.Location = New System.Drawing.Point(7, 45)
        Me.GRIDDETAILS.MultiSelect = False
        Me.GRIDDETAILS.Name = "GRIDDETAILS"
        Me.GRIDDETAILS.ReadOnly = True
        Me.GRIDDETAILS.RowHeadersVisible = False
        Me.GRIDDETAILS.RowHeadersWidth = 30
        Me.GRIDDETAILS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDDETAILS.RowTemplate.Height = 20
        Me.GRIDDETAILS.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDDETAILS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDDETAILS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDDETAILS.Size = New System.Drawing.Size(501, 119)
        Me.GRIDDETAILS.TabIndex = 6
        Me.GRIDDETAILS.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GFAMILY
        '
        Me.GFAMILY.HeaderText = "Name"
        Me.GFAMILY.Name = "GFAMILY"
        Me.GFAMILY.ReadOnly = True
        Me.GFAMILY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GFAMILY.Width = 200
        '
        'GDOB
        '
        Me.GDOB.HeaderText = "DOB"
        Me.GDOB.Name = "GDOB"
        Me.GDOB.ReadOnly = True
        Me.GDOB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDOB.Width = 83
        '
        'GAGE
        '
        Me.GAGE.HeaderText = "Age"
        Me.GAGE.Name = "GAGE"
        Me.GAGE.ReadOnly = True
        Me.GAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAGE.Width = 50
        '
        'GRELATION
        '
        Me.GRELATION.HeaderText = "Relation"
        Me.GRELATION.Name = "GRELATION"
        Me.GRELATION.ReadOnly = True
        Me.GRELATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TXTAGE
        '
        Me.TXTAGE.BackColor = System.Drawing.Color.Linen
        Me.TXTAGE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAGE.Location = New System.Drawing.Point(330, 23)
        Me.TXTAGE.Name = "TXTAGE"
        Me.TXTAGE.ReadOnly = True
        Me.TXTAGE.Size = New System.Drawing.Size(50, 22)
        Me.TXTAGE.TabIndex = 4
        Me.TXTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DOB
        '
        Me.DOB.CustomFormat = "dd/MM/yyyy"
        Me.DOB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOB.Location = New System.Drawing.Point(247, 23)
        Me.DOB.Name = "DOB"
        Me.DOB.Size = New System.Drawing.Size(83, 22)
        Me.DOB.TabIndex = 3
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.White
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(7, 23)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTSRNO.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(76, 470)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(508, 60)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.BackColor = System.Drawing.SystemColors.Window
        Me.TXTREMARKS.ForeColor = System.Drawing.Color.Black
        Me.TXTREMARKS.Location = New System.Drawing.Point(8, 25)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(494, 29)
        Me.TXTREMARKS.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(233, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 467
        Me.Label2.Text = "MUI No"
        '
        'TXTMUINO
        '
        Me.TXTMUINO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMUINO.Location = New System.Drawing.Point(282, 97)
        Me.TXTMUINO.Name = "TXTMUINO"
        Me.TXTMUINO.Size = New System.Drawing.Size(99, 22)
        Me.TXTMUINO.TabIndex = 5
        Me.TXTMUINO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmobile
        '
        Me.txtmobile.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.Location = New System.Drawing.Point(369, 247)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(86, 22)
        Me.txtmobile.TabIndex = 15
        Me.txtmobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(474, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 14)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Fax"
        '
        'cmbemail
        '
        Me.cmbemail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbemail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbemail.FormattingEnabled = True
        Me.cmbemail.Location = New System.Drawing.Point(133, 275)
        Me.cmbemail.MaxDropDownItems = 14
        Me.cmbemail.Name = "cmbemail"
        Me.cmbemail.Size = New System.Drawing.Size(184, 22)
        Me.cmbemail.TabIndex = 17
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Image = Global.MNOWF.My.Resources.Resources.Delete
        Me.cmddelete.Location = New System.Drawing.Point(311, 531)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 26)
        Me.cmddelete.TabIndex = 22
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(56, 101)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(75, 14)
        Me.Label31.TabIndex = 465
        Me.Label31.Text = "Joining Date"
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Location = New System.Drawing.Point(501, 247)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(86, 22)
        Me.txtfax.TabIndex = 16
        Me.txtfax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DOJ
        '
        Me.DOJ.CustomFormat = "dd/MM/yyyy"
        Me.DOJ.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOJ.Location = New System.Drawing.Point(133, 97)
        Me.DOJ.Name = "DOJ"
        Me.DOJ.Size = New System.Drawing.Size(87, 22)
        Me.DOJ.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(321, 251)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 14)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Mobile"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(400, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 14)
        Me.Label14.TabIndex = 463
        Me.Label14.Text = "Declaration Date"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(387, 530)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 23
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(65, 251)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 14)
        Me.Label25.TabIndex = 130
        Me.Label25.Text = "S.T.D. Code"
        '
        'DECDATE
        '
        Me.DECDATE.CustomFormat = "dd/MM/yyyy"
        Me.DECDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DECDATE.Location = New System.Drawing.Point(501, 97)
        Me.DECDATE.Name = "DECDATE"
        Me.DECDATE.Size = New System.Drawing.Size(87, 22)
        Me.DECDATE.TabIndex = 6
        '
        'txtstd
        '
        Me.txtstd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstd.Location = New System.Drawing.Point(133, 247)
        Me.txtstd.Name = "txtstd"
        Me.txtstd.Size = New System.Drawing.Size(48, 22)
        Me.txtstd.TabIndex = 13
        Me.txtstd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.MNOWF.My.Resources.Resources.Save
        Me.cmdok.Location = New System.Drawing.Point(157, 532)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 26)
        Me.cmdok.TabIndex = 20
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'CHKINDIAN
        '
        Me.CHKINDIAN.AutoSize = True
        Me.CHKINDIAN.BackColor = System.Drawing.Color.Transparent
        Me.CHKINDIAN.Checked = True
        Me.CHKINDIAN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKINDIAN.ForeColor = System.Drawing.Color.Black
        Me.CHKINDIAN.Location = New System.Drawing.Point(133, 124)
        Me.CHKINDIAN.Name = "CHKINDIAN"
        Me.CHKINDIAN.Size = New System.Drawing.Size(62, 18)
        Me.CHKINDIAN.TabIndex = 7
        Me.CHKINDIAN.Text = "Indian"
        Me.CHKINDIAN.UseVisualStyleBackColor = False
        '
        'CMBCMPNAME
        '
        Me.CMBCMPNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCMPNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCMPNAME.FormattingEnabled = True
        Me.CMBCMPNAME.Items.AddRange(New Object() {""})
        Me.CMBCMPNAME.Location = New System.Drawing.Point(133, 70)
        Me.CMBCMPNAME.Name = "CMBCMPNAME"
        Me.CMBCMPNAME.Size = New System.Drawing.Size(248, 22)
        Me.CMBCMPNAME.TabIndex = 2
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(133, 43)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(248, 22)
        Me.CMBNAME.TabIndex = 0
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(40, 74)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 14)
        Me.Label30.TabIndex = 298
        Me.Label30.Text = "Company Name"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(12, 7)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 297
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'CMBRANK
        '
        Me.CMBRANK.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBRANK.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRANK.FormattingEnabled = True
        Me.CMBRANK.Location = New System.Drawing.Point(455, 43)
        Me.CMBRANK.MaxDropDownItems = 14
        Me.CMBRANK.Name = "CMBRANK"
        Me.CMBRANK.Size = New System.Drawing.Size(133, 22)
        Me.CMBRANK.TabIndex = 1
        '
        'LBLRANK
        '
        Me.LBLRANK.AutoSize = True
        Me.LBLRANK.BackColor = System.Drawing.Color.Transparent
        Me.LBLRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRANK.Location = New System.Drawing.Point(419, 47)
        Me.LBLRANK.Name = "LBLRANK"
        Me.LBLRANK.Size = New System.Drawing.Size(34, 14)
        Me.LBLRANK.TabIndex = 294
        Me.LBLRANK.Text = "Rank"
        '
        'TXTEMPCODE
        '
        Me.TXTEMPCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMPCODE.Location = New System.Drawing.Point(455, 70)
        Me.TXTEMPCODE.Name = "TXTEMPCODE"
        Me.TXTEMPCODE.Size = New System.Drawing.Size(133, 22)
        Me.TXTEMPCODE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 292
        Me.Label1.Text = "Officer's Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(393, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 14)
        Me.Label3.TabIndex = 293
        Me.Label3.Text = "Emp Code"
        '
        'txtresino
        '
        Me.txtresino.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresino.Location = New System.Drawing.Point(231, 247)
        Me.txtresino.Name = "txtresino"
        Me.txtresino.Size = New System.Drawing.Size(86, 22)
        Me.txtresino.TabIndex = 14
        Me.txtresino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(184, 251)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 14)
        Me.Label26.TabIndex = 132
        Me.Label26.Text = "Tel No."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(93, 279)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 14)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Email"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OfficerMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(616, 567)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OfficerMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Officer Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBCMPNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents CMBRANK As System.Windows.Forms.ComboBox
    Friend WithEvents LBLRANK As System.Windows.Forms.Label
    Friend WithEvents TXTEMPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmbemail As System.Windows.Forms.ComboBox
    Friend WithEvents txtresino As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtstd As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CHKINDIAN As System.Windows.Forms.CheckBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DOJ As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DECDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTSERVICE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTMUINO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GRIDDETAILS As System.Windows.Forms.DataGridView
    Friend WithEvents TXTAGE As System.Windows.Forms.TextBox
    Friend WithEvents DOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBRELATION As System.Windows.Forms.ComboBox
    Friend WithEvents CMBFAMILY As System.Windows.Forms.ComboBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTOFFICERNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CHKDONATION As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCONTRIBUTION As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCONTRACT As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GFAMILY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GAGE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRELATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTCALCDOB As System.Windows.Forms.TextBox
    Friend WithEvents CMDQRCODE As Button
End Class
