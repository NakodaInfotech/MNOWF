<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemInventory
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemInventory))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.CMBHOTEL = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTNARR = New System.Windows.Forms.TextBox
        Me.TXTCLOSING = New System.Windows.Forms.TextBox
        Me.TXTDAMAGED = New System.Windows.Forms.TextBox
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.TXTPASSED = New System.Windows.Forms.TextBox
        Me.cmdok = New System.Windows.Forms.Button
        Me.TXTREQ = New System.Windows.Forms.TextBox
        Me.cmdclear = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmddelete = New System.Windows.Forms.Button
        Me.TXTOPSTOCK = New System.Windows.Forms.TextBox
        Me.TXTITEMNO = New System.Windows.Forms.TextBox
        Me.GRIDITEM = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCATEGORY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREQ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPASSED = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDAMAGED = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCLOSING = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ITEMDATE = New System.Windows.Forms.DateTimePicker
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBHOTEL)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTNARR)
        Me.BlendPanel1.Controls.Add(Me.TXTCLOSING)
        Me.BlendPanel1.Controls.Add(Me.TXTDAMAGED)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.TXTPASSED)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.TXTREQ)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.TXTOPSTOCK)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMNO)
        Me.BlendPanel1.Controls.Add(Me.GRIDITEM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.ITEMDATE)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1008, 546)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Enabled = False
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(753, 40)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(24, 22)
        Me.TXTADD.TabIndex = 668
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(719, 40)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(32, 22)
        Me.CMBCODE.TabIndex = 667
        Me.CMBCODE.Visible = False
        '
        'CMBHOTEL
        '
        Me.CMBHOTEL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHOTEL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHOTEL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHOTEL.FormattingEnabled = True
        Me.CMBHOTEL.Location = New System.Drawing.Point(418, 40)
        Me.CMBHOTEL.MaxDropDownItems = 14
        Me.CMBHOTEL.Name = "CMBHOTEL"
        Me.CMBHOTEL.Size = New System.Drawing.Size(295, 22)
        Me.CMBHOTEL.TabIndex = 615
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(302, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 14)
        Me.Label6.TabIndex = 616
        Me.Label6.Text = "Convalescent Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 474)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 628
        Me.Label1.Text = "Remarks"
        '
        'TXTNARR
        '
        Me.TXTNARR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNARR.ForeColor = System.Drawing.Color.DimGray
        Me.TXTNARR.Location = New System.Drawing.Point(14, 491)
        Me.TXTNARR.Multiline = True
        Me.TXTNARR.Name = "TXTNARR"
        Me.TXTNARR.Size = New System.Drawing.Size(337, 44)
        Me.TXTNARR.TabIndex = 627
        '
        'TXTCLOSING
        '
        Me.TXTCLOSING.BackColor = System.Drawing.Color.Pink
        Me.TXTCLOSING.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCLOSING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLOSING.Location = New System.Drawing.Point(645, 465)
        Me.TXTCLOSING.Name = "TXTCLOSING"
        Me.TXTCLOSING.ReadOnly = True
        Me.TXTCLOSING.Size = New System.Drawing.Size(80, 22)
        Me.TXTCLOSING.TabIndex = 482
        Me.TXTCLOSING.TabStop = False
        Me.TXTCLOSING.Text = "0.00"
        Me.TXTCLOSING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDAMAGED
        '
        Me.TXTDAMAGED.BackColor = System.Drawing.Color.Pink
        Me.TXTDAMAGED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDAMAGED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDAMAGED.Location = New System.Drawing.Point(566, 465)
        Me.TXTDAMAGED.Name = "TXTDAMAGED"
        Me.TXTDAMAGED.ReadOnly = True
        Me.TXTDAMAGED.Size = New System.Drawing.Size(80, 22)
        Me.TXTDAMAGED.TabIndex = 481
        Me.TXTDAMAGED.TabStop = False
        Me.TXTDAMAGED.Text = "0.00"
        Me.TXTDAMAGED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(308, 36)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 626
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'TXTPASSED
        '
        Me.TXTPASSED.BackColor = System.Drawing.Color.Pink
        Me.TXTPASSED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPASSED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPASSED.Location = New System.Drawing.Point(487, 465)
        Me.TXTPASSED.Name = "TXTPASSED"
        Me.TXTPASSED.ReadOnly = True
        Me.TXTPASSED.Size = New System.Drawing.Size(80, 22)
        Me.TXTPASSED.TabIndex = 480
        Me.TXTPASSED.TabStop = False
        Me.TXTPASSED.Text = "0.00"
        Me.TXTPASSED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.cmdok.Location = New System.Drawing.Point(357, 505)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 26)
        Me.cmdok.TabIndex = 2
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'TXTREQ
        '
        Me.TXTREQ.BackColor = System.Drawing.Color.Pink
        Me.TXTREQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTREQ.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREQ.Location = New System.Drawing.Point(408, 465)
        Me.TXTREQ.Name = "TXTREQ"
        Me.TXTREQ.ReadOnly = True
        Me.TXTREQ.Size = New System.Drawing.Size(80, 22)
        Me.TXTREQ.TabIndex = 479
        Me.TXTREQ.TabStop = False
        Me.TXTREQ.Text = "0.00"
        Me.TXTREQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdclear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Image = Global.MNOWF.My.Resources.Resources.clear
        Me.cmdclear.Location = New System.Drawing.Point(432, 503)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(72, 26)
        Me.cmdclear.TabIndex = 3
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(245, 469)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 14)
        Me.Label23.TabIndex = 478
        Me.Label23.Text = "Total Claimed"
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
        Me.cmddelete.Location = New System.Drawing.Point(508, 504)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 26)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'TXTOPSTOCK
        '
        Me.TXTOPSTOCK.BackColor = System.Drawing.Color.Pink
        Me.TXTOPSTOCK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTOPSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPSTOCK.Location = New System.Drawing.Point(329, 465)
        Me.TXTOPSTOCK.Name = "TXTOPSTOCK"
        Me.TXTOPSTOCK.ReadOnly = True
        Me.TXTOPSTOCK.Size = New System.Drawing.Size(80, 22)
        Me.TXTOPSTOCK.TabIndex = 477
        Me.TXTOPSTOCK.TabStop = False
        Me.TXTOPSTOCK.Text = "0.00"
        Me.TXTOPSTOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTITEMNO
        '
        Me.TXTITEMNO.BackColor = System.Drawing.Color.Pink
        Me.TXTITEMNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMNO.Location = New System.Drawing.Point(877, 44)
        Me.TXTITEMNO.Name = "TXTITEMNO"
        Me.TXTITEMNO.ReadOnly = True
        Me.TXTITEMNO.Size = New System.Drawing.Size(87, 22)
        Me.TXTITEMNO.TabIndex = 621
        Me.TXTITEMNO.TabStop = False
        Me.TXTITEMNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDITEM
        '
        Me.GRIDITEM.AllowUserToAddRows = False
        Me.GRIDITEM.AllowUserToDeleteRows = False
        Me.GRIDITEM.AllowUserToResizeColumns = False
        Me.GRIDITEM.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDITEM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDITEM.BackgroundColor = System.Drawing.Color.White
        Me.GRIDITEM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDITEM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDITEM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDITEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDITEM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GCATEGORY, Me.GITEMNAME, Me.GOP, Me.GREQ, Me.GPASSED, Me.GDAMAGED, Me.GCLOSING, Me.GREMARKS})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDITEM.DefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDITEM.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDITEM.Location = New System.Drawing.Point(14, 68)
        Me.GRIDITEM.MultiSelect = False
        Me.GRIDITEM.Name = "GRIDITEM"
        Me.GRIDITEM.RowHeadersVisible = False
        Me.GRIDITEM.RowHeadersWidth = 30
        Me.GRIDITEM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDITEM.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDITEM.RowTemplate.Height = 20
        Me.GRIDITEM.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDITEM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDITEM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDITEM.Size = New System.Drawing.Size(980, 394)
        Me.GRIDITEM.TabIndex = 0
        Me.GRIDITEM.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = False
        '
        'GCATEGORY
        '
        Me.GCATEGORY.HeaderText = "Category"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.ReadOnly = True
        Me.GCATEGORY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCATEGORY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 200
        '
        'GOP
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GOP.DefaultCellStyle = DataGridViewCellStyle3
        Me.GOP.HeaderText = "O/P Stock"
        Me.GOP.Name = "GOP"
        Me.GOP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOP.Width = 80
        '
        'GREQ
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GREQ.DefaultCellStyle = DataGridViewCellStyle4
        Me.GREQ.HeaderText = "Indent"
        Me.GREQ.Name = "GREQ"
        Me.GREQ.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREQ.Width = 80
        '
        'GPASSED
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPASSED.DefaultCellStyle = DataGridViewCellStyle5
        Me.GPASSED.HeaderText = "Sanctioned"
        Me.GPASSED.Name = "GPASSED"
        Me.GPASSED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPASSED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPASSED.Width = 80
        '
        'GDAMAGED
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GDAMAGED.DefaultCellStyle = DataGridViewCellStyle6
        Me.GDAMAGED.HeaderText = "Damaged"
        Me.GDAMAGED.Name = "GDAMAGED"
        Me.GDAMAGED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDAMAGED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDAMAGED.Width = 80
        '
        'GCLOSING
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCLOSING.DefaultCellStyle = DataGridViewCellStyle7
        Me.GCLOSING.HeaderText = "C/O Stock"
        Me.GCLOSING.Name = "GCLOSING"
        Me.GCLOSING.ReadOnly = True
        Me.GCLOSING.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCLOSING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCLOSING.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.HeaderText = "Remarks"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREMARKS.Width = 250
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(838, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 620
        Me.Label4.Text = "Sr No."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(167, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 14)
        Me.Label9.TabIndex = 625
        Me.Label9.Text = "Date"
        '
        'ITEMDATE
        '
        Me.ITEMDATE.CustomFormat = "dd/MM/yyyy"
        Me.ITEMDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ITEMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ITEMDATE.Location = New System.Drawing.Point(202, 40)
        Me.ITEMDATE.Name = "ITEMDATE"
        Me.ITEMDATE.Size = New System.Drawing.Size(80, 22)
        Me.ITEMDATE.TabIndex = 0
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(238, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(67, 22)
        Me.tstxtbillno.TabIndex = 2
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 286
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "&Delete"
        Me.ToolStripdelete.ToolTipText = "Delete Contra"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Image = Global.MNOWF.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(68, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Image = Global.MNOWF.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(50, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.CMDEXIT.Location = New System.Drawing.Point(586, 504)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(69, 25)
        Me.CMDEXIT.TabIndex = 5
        Me.CMDEXIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 26)
        Me.Label2.TabIndex = 210
        Me.Label2.Text = "Item Inventory"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ItemInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1008, 546)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDITEM As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ITEMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTITEMNO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents TXTDAMAGED As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASSED As System.Windows.Forms.TextBox
    Friend WithEvents TXTREQ As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTOPSTOCK As System.Windows.Forms.TextBox
    Friend WithEvents TXTCLOSING As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTNARR As System.Windows.Forms.TextBox
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCATEGORY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPASSED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDAMAGED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCLOSING As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBHOTEL As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
End Class
