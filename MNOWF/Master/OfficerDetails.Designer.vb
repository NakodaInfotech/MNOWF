<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OfficerDetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDPRINTHISTORY = New System.Windows.Forms.Button
        Me.CMDEXCEL = New System.Windows.Forms.PictureBox
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gtype = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSETTLENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCLAIMED = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPAID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GYEAR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Details = New System.Windows.Forms.TabPage
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.CHKCONTRACT = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTOFFICERNO = New System.Windows.Forms.TextBox
        Me.CHKDONATION = New System.Windows.Forms.CheckBox
        Me.CHKCONTRIBUTION = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DOJ = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.DECDATE = New System.Windows.Forms.DateTimePicker
        Me.CHKINDIAN = New System.Windows.Forms.CheckBox
        Me.TXTEMPCODE = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTCMPNAME = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.TXTMUINO = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtstd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtmobile = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.TXTRESINO = New System.Windows.Forms.TextBox
        Me.TXTRANK = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TXTSERVICE = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.Roomdetails = New System.Windows.Forms.TabPage
        Me.BlendPanel3 = New VbPowerPack.BlendPanel
        Me.GRIDFAMILY = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDOB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GAGE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRELATION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dttodate = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtfromdate = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.CMDEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Roomdetails.SuspendLayout()
        Me.BlendPanel3.SuspendLayout()
        CType(Me.GRIDFAMILY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINTHISTORY)
        Me.BlendPanel1.Controls.Add(Me.CMDEXCEL)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.dttodate)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.dtfromdate)
        Me.BlendPanel1.Controls.Add(Me.Label25)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 741)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMDPRINTHISTORY
        '
        Me.CMDPRINTHISTORY.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINTHISTORY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINTHISTORY.FlatAppearance.BorderSize = 0
        Me.CMDPRINTHISTORY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINTHISTORY.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINTHISTORY.Location = New System.Drawing.Point(998, 298)
        Me.CMDPRINTHISTORY.Name = "CMDPRINTHISTORY"
        Me.CMDPRINTHISTORY.Size = New System.Drawing.Size(90, 28)
        Me.CMDPRINTHISTORY.TabIndex = 451
        Me.CMDPRINTHISTORY.Text = "&Print History"
        Me.CMDPRINTHISTORY.UseVisualStyleBackColor = False
        '
        'CMDEXCEL
        '
        Me.CMDEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXCEL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXCEL.Image = Global.MNOWF.My.Resources.Resources.Excel_icon
        Me.CMDEXCEL.Location = New System.Drawing.Point(899, 19)
        Me.CMDEXCEL.Name = "CMDEXCEL"
        Me.CMDEXCEL.Size = New System.Drawing.Size(32, 26)
        Me.CMDEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CMDEXCEL.TabIndex = 450
        Me.CMDEXCEL.TabStop = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(742, 18)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 449
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Location = New System.Drawing.Point(373, 327)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(849, 374)
        Me.gridbilldetails.TabIndex = 448
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gtype, Me.GREQNO, Me.GSETTLENO, Me.gname, Me.gdate, Me.GCLAIMED, Me.GPAID, Me.GCHQNO, Me.GCHQDATE, Me.GYEAR})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gtype
        '
        Me.gtype.Caption = "Type"
        Me.gtype.FieldName = "TYPE"
        Me.gtype.Name = "gtype"
        Me.gtype.Visible = True
        Me.gtype.VisibleIndex = 0
        Me.gtype.Width = 65
        '
        'GREQNO
        '
        Me.GREQNO.Caption = "Req No"
        Me.GREQNO.FieldName = "REQNO"
        Me.GREQNO.Name = "GREQNO"
        Me.GREQNO.Visible = True
        Me.GREQNO.VisibleIndex = 1
        '
        'GSETTLENO
        '
        Me.GSETTLENO.Caption = "Claim No"
        Me.GSETTLENO.FieldName = "CLAIMNO"
        Me.GSETTLENO.Name = "GSETTLENO"
        Me.GSETTLENO.Visible = True
        Me.GSETTLENO.VisibleIndex = 2
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "PATIENTNAME"
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 3
        Me.gname.Width = 150
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 4
        '
        'GCLAIMED
        '
        Me.GCLAIMED.Caption = "Claimed Amt"
        Me.GCLAIMED.DisplayFormat.FormatString = "0.00"
        Me.GCLAIMED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLAIMED.FieldName = "CLAIMEDAMT"
        Me.GCLAIMED.Name = "GCLAIMED"
        Me.GCLAIMED.Visible = True
        Me.GCLAIMED.VisibleIndex = 5
        Me.GCLAIMED.Width = 70
        '
        'GPAID
        '
        Me.GPAID.Caption = "Paid Amt"
        Me.GPAID.DisplayFormat.FormatString = "0.00"
        Me.GPAID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPAID.FieldName = "PAIDAMT"
        Me.GPAID.Name = "GPAID"
        Me.GPAID.Visible = True
        Me.GPAID.VisibleIndex = 6
        Me.GPAID.Width = 70
        '
        'GCHQNO
        '
        Me.GCHQNO.Caption = "Chq No"
        Me.GCHQNO.FieldName = "CHQNO"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.Visible = True
        Me.GCHQNO.VisibleIndex = 7
        Me.GCHQNO.Width = 65
        '
        'GCHQDATE
        '
        Me.GCHQDATE.Caption = "Chq Date"
        Me.GCHQDATE.FieldName = "CHQDATE"
        Me.GCHQDATE.Name = "GCHQDATE"
        Me.GCHQDATE.Visible = True
        Me.GCHQDATE.VisibleIndex = 8
        '
        'GYEAR
        '
        Me.GYEAR.Caption = "Year"
        Me.GYEAR.FieldName = "YEARNAME"
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.Visible = True
        Me.GYEAR.VisibleIndex = 9
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(18, 27)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(349, 674)
        Me.gridname.TabIndex = 315
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Black
        Me.cmdadd.Location = New System.Drawing.Point(508, 705)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 2
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(825, 18)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(80, 28)
        Me.cmdedit.TabIndex = 4
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(594, 705)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Roomdetails)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(370, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(622, 268)
        Me.TabControl1.TabIndex = 239
        '
        'Details
        '
        Me.Details.Controls.Add(Me.BlendPanel2)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 23)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(614, 241)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Officer Details"
        Me.Details.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CHKCONTRACT)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTOFFICERNO)
        Me.BlendPanel2.Controls.Add(Me.CHKDONATION)
        Me.BlendPanel2.Controls.Add(Me.CHKCONTRIBUTION)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.DOJ)
        Me.BlendPanel2.Controls.Add(Me.Label14)
        Me.BlendPanel2.Controls.Add(Me.DECDATE)
        Me.BlendPanel2.Controls.Add(Me.CHKINDIAN)
        Me.BlendPanel2.Controls.Add(Me.TXTEMPCODE)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.TXTCMPNAME)
        Me.BlendPanel2.Controls.Add(Me.Label29)
        Me.BlendPanel2.Controls.Add(Me.TXTNAME)
        Me.BlendPanel2.Controls.Add(Me.TXTMUINO)
        Me.BlendPanel2.Controls.Add(Me.Label31)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.txtstd)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.Label53)
        Me.BlendPanel2.Controls.Add(Me.Label52)
        Me.BlendPanel2.Controls.Add(Me.Label49)
        Me.BlendPanel2.Controls.Add(Me.txtfax)
        Me.BlendPanel2.Controls.Add(Me.txtmobile)
        Me.BlendPanel2.Controls.Add(Me.txtemail)
        Me.BlendPanel2.Controls.Add(Me.Label50)
        Me.BlendPanel2.Controls.Add(Me.TXTRESINO)
        Me.BlendPanel2.Controls.Add(Me.TXTRANK)
        Me.BlendPanel2.Controls.Add(Me.Label30)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel2.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(608, 235)
        Me.BlendPanel2.TabIndex = 0
        '
        'CHKCONTRACT
        '
        Me.CHKCONTRACT.AutoSize = True
        Me.CHKCONTRACT.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRACT.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRACT.Location = New System.Drawing.Point(298, 116)
        Me.CHKCONTRACT.Name = "CHKCONTRACT"
        Me.CHKCONTRACT.Size = New System.Drawing.Size(70, 18)
        Me.CHKCONTRACT.TabIndex = 478
        Me.CHKCONTRACT.Text = "Contract"
        Me.CHKCONTRACT.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(34, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 475
        Me.Label3.Text = "MNOWF No"
        '
        'TXTOFFICERNO
        '
        Me.TXTOFFICERNO.BackColor = System.Drawing.Color.Linen
        Me.TXTOFFICERNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO.Location = New System.Drawing.Point(104, 8)
        Me.TXTOFFICERNO.Name = "TXTOFFICERNO"
        Me.TXTOFFICERNO.ReadOnly = True
        Me.TXTOFFICERNO.Size = New System.Drawing.Size(81, 22)
        Me.TXTOFFICERNO.TabIndex = 474
        Me.TXTOFFICERNO.TabStop = False
        Me.TXTOFFICERNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKDONATION
        '
        Me.CHKDONATION.AutoSize = True
        Me.CHKDONATION.BackColor = System.Drawing.Color.Transparent
        Me.CHKDONATION.ForeColor = System.Drawing.Color.Black
        Me.CHKDONATION.Location = New System.Drawing.Point(374, 116)
        Me.CHKDONATION.Name = "CHKDONATION"
        Me.CHKDONATION.Size = New System.Drawing.Size(105, 18)
        Me.CHKDONATION.TabIndex = 473
        Me.CHKDONATION.Text = "Donation Recd"
        Me.CHKDONATION.UseVisualStyleBackColor = False
        '
        'CHKCONTRIBUTION
        '
        Me.CHKCONTRIBUTION.AutoSize = True
        Me.CHKCONTRIBUTION.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRIBUTION.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRIBUTION.Location = New System.Drawing.Point(169, 116)
        Me.CHKCONTRIBUTION.Name = "CHKCONTRIBUTION"
        Me.CHKCONTRIBUTION.Size = New System.Drawing.Size(122, 18)
        Me.CHKCONTRIBUTION.TabIndex = 472
        Me.CHKCONTRIBUTION.Text = "Contribution Recd"
        Me.CHKCONTRIBUTION.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 470
        Me.Label1.Text = "Joining Date"
        '
        'DOJ
        '
        Me.DOJ.CustomFormat = "dd/MM/yyyy"
        Me.DOJ.Enabled = False
        Me.DOJ.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOJ.Location = New System.Drawing.Point(104, 88)
        Me.DOJ.Name = "DOJ"
        Me.DOJ.Size = New System.Drawing.Size(87, 22)
        Me.DOJ.TabIndex = 469
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(273, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 14)
        Me.Label14.TabIndex = 468
        Me.Label14.Text = "Declaration Date"
        '
        'DECDATE
        '
        Me.DECDATE.CustomFormat = "dd/MM/yyyy"
        Me.DECDATE.Enabled = False
        Me.DECDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DECDATE.Location = New System.Drawing.Point(374, 88)
        Me.DECDATE.Name = "DECDATE"
        Me.DECDATE.Size = New System.Drawing.Size(87, 22)
        Me.DECDATE.TabIndex = 467
        '
        'CHKINDIAN
        '
        Me.CHKINDIAN.AutoSize = True
        Me.CHKINDIAN.BackColor = System.Drawing.Color.Transparent
        Me.CHKINDIAN.Checked = True
        Me.CHKINDIAN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKINDIAN.ForeColor = System.Drawing.Color.Black
        Me.CHKINDIAN.Location = New System.Drawing.Point(104, 116)
        Me.CHKINDIAN.Name = "CHKINDIAN"
        Me.CHKINDIAN.Size = New System.Drawing.Size(62, 18)
        Me.CHKINDIAN.TabIndex = 466
        Me.CHKINDIAN.Text = "Indian"
        Me.CHKINDIAN.UseVisualStyleBackColor = False
        '
        'TXTEMPCODE
        '
        Me.TXTEMPCODE.BackColor = System.Drawing.Color.White
        Me.TXTEMPCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMPCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTEMPCODE.Location = New System.Drawing.Point(374, 60)
        Me.TXTEMPCODE.Name = "TXTEMPCODE"
        Me.TXTEMPCODE.ReadOnly = True
        Me.TXTEMPCODE.Size = New System.Drawing.Size(125, 22)
        Me.TXTEMPCODE.TabIndex = 258
        Me.TXTEMPCODE.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(312, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Emp Code"
        '
        'TXTCMPNAME
        '
        Me.TXTCMPNAME.BackColor = System.Drawing.Color.White
        Me.TXTCMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCMPNAME.ForeColor = System.Drawing.Color.DimGray
        Me.TXTCMPNAME.Location = New System.Drawing.Point(104, 60)
        Me.TXTCMPNAME.Name = "TXTCMPNAME"
        Me.TXTCMPNAME.ReadOnly = True
        Me.TXTCMPNAME.Size = New System.Drawing.Size(186, 22)
        Me.TXTCMPNAME.TabIndex = 218
        Me.TXTCMPNAME.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(17, 37)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Officer's Name"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.White
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.ForeColor = System.Drawing.Color.DimGray
        Me.TXTNAME.Location = New System.Drawing.Point(104, 33)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(186, 22)
        Me.TXTNAME.TabIndex = 219
        Me.TXTNAME.TabStop = False
        '
        'TXTMUINO
        '
        Me.TXTMUINO.BackColor = System.Drawing.Color.White
        Me.TXTMUINO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMUINO.ForeColor = System.Drawing.Color.DimGray
        Me.TXTMUINO.Location = New System.Drawing.Point(313, 187)
        Me.TXTMUINO.Name = "TXTMUINO"
        Me.TXTMUINO.ReadOnly = True
        Me.TXTMUINO.Size = New System.Drawing.Size(125, 22)
        Me.TXTMUINO.TabIndex = 251
        Me.TXTMUINO.TabStop = False
        Me.TXTMUINO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(11, 64)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(91, 14)
        Me.Label31.TabIndex = 217
        Me.Label31.Text = "Company Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(261, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "MUI No."
        '
        'txtstd
        '
        Me.txtstd.BackColor = System.Drawing.Color.White
        Me.txtstd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstd.ForeColor = System.Drawing.Color.DimGray
        Me.txtstd.Location = New System.Drawing.Point(104, 138)
        Me.txtstd.Name = "txtstd"
        Me.txtstd.ReadOnly = True
        Me.txtstd.Size = New System.Drawing.Size(87, 22)
        Me.txtstd.TabIndex = 249
        Me.txtstd.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(68, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "S.T.D."
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(77, 191)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(25, 14)
        Me.Label53.TabIndex = 227
        Me.Label53.Text = "Fax"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(56, 167)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 14)
        Me.Label52.TabIndex = 226
        Me.Label52.Text = "Mobile"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(273, 142)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(38, 14)
        Me.Label49.TabIndex = 228
        Me.Label49.Text = "Email"
        '
        'txtfax
        '
        Me.txtfax.BackColor = System.Drawing.Color.White
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.ForeColor = System.Drawing.Color.DimGray
        Me.txtfax.Location = New System.Drawing.Point(104, 187)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.ReadOnly = True
        Me.txtfax.Size = New System.Drawing.Size(125, 22)
        Me.txtfax.TabIndex = 233
        Me.txtfax.TabStop = False
        Me.txtfax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmobile
        '
        Me.txtmobile.BackColor = System.Drawing.Color.White
        Me.txtmobile.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.ForeColor = System.Drawing.Color.DimGray
        Me.txtmobile.Location = New System.Drawing.Point(104, 163)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.ReadOnly = True
        Me.txtmobile.Size = New System.Drawing.Size(125, 22)
        Me.txtmobile.TabIndex = 232
        Me.txtmobile.TabStop = False
        Me.txtmobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtemail
        '
        Me.txtemail.BackColor = System.Drawing.Color.White
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.ForeColor = System.Drawing.Color.DimGray
        Me.txtemail.Location = New System.Drawing.Point(313, 138)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(186, 22)
        Me.txtemail.TabIndex = 234
        Me.txtemail.TabStop = False
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(270, 167)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(41, 14)
        Me.Label50.TabIndex = 224
        Me.Label50.Text = "Tel No"
        '
        'TXTRESINO
        '
        Me.TXTRESINO.BackColor = System.Drawing.Color.White
        Me.TXTRESINO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESINO.ForeColor = System.Drawing.Color.DimGray
        Me.TXTRESINO.Location = New System.Drawing.Point(313, 163)
        Me.TXTRESINO.Name = "TXTRESINO"
        Me.TXTRESINO.ReadOnly = True
        Me.TXTRESINO.Size = New System.Drawing.Size(125, 22)
        Me.TXTRESINO.TabIndex = 230
        Me.TXTRESINO.TabStop = False
        Me.TXTRESINO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRANK
        '
        Me.TXTRANK.BackColor = System.Drawing.Color.White
        Me.TXTRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRANK.ForeColor = System.Drawing.Color.DimGray
        Me.TXTRANK.Location = New System.Drawing.Point(374, 33)
        Me.TXTRANK.Name = "TXTRANK"
        Me.TXTRANK.ReadOnly = True
        Me.TXTRANK.Size = New System.Drawing.Size(125, 22)
        Me.TXTRANK.TabIndex = 221
        Me.TXTRANK.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(338, 37)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(34, 14)
        Me.Label30.TabIndex = 220
        Me.Label30.Text = "Rank"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(614, 241)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Address"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TXTSERVICE)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(280, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(277, 102)
        Me.GroupBox3.TabIndex = 480
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Details Of Services"
        '
        'TXTSERVICE
        '
        Me.TXTSERVICE.BackColor = System.Drawing.SystemColors.Window
        Me.TXTSERVICE.ForeColor = System.Drawing.Color.Black
        Me.TXTSERVICE.Location = New System.Drawing.Point(8, 19)
        Me.TXTSERVICE.Multiline = True
        Me.TXTSERVICE.Name = "TXTSERVICE"
        Me.TXTSERVICE.ReadOnly = True
        Me.TXTSERVICE.Size = New System.Drawing.Size(263, 74)
        Me.TXTSERVICE.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(4, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 108)
        Me.GroupBox1.TabIndex = 479
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
        Me.TXTREMARKS.ReadOnly = True
        Me.TXTREMARKS.Size = New System.Drawing.Size(252, 74)
        Me.TXTREMARKS.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtadd)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 108)
        Me.GroupBox2.TabIndex = 478
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Permanent Address / Correspondance"
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.SystemColors.Window
        Me.txtadd.ForeColor = System.Drawing.Color.Black
        Me.txtadd.Location = New System.Drawing.Point(8, 25)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(252, 74)
        Me.txtadd.TabIndex = 0
        '
        'Roomdetails
        '
        Me.Roomdetails.Controls.Add(Me.BlendPanel3)
        Me.Roomdetails.Location = New System.Drawing.Point(4, 23)
        Me.Roomdetails.Name = "Roomdetails"
        Me.Roomdetails.Padding = New System.Windows.Forms.Padding(3)
        Me.Roomdetails.Size = New System.Drawing.Size(614, 241)
        Me.Roomdetails.TabIndex = 3
        Me.Roomdetails.Text = "Family Details / Dependents"
        Me.Roomdetails.UseVisualStyleBackColor = True
        '
        'BlendPanel3
        '
        Me.BlendPanel3.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel3.Controls.Add(Me.GRIDFAMILY)
        Me.BlendPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel3.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel3.Name = "BlendPanel3"
        Me.BlendPanel3.Size = New System.Drawing.Size(608, 235)
        Me.BlendPanel3.TabIndex = 1
        '
        'GRIDFAMILY
        '
        Me.GRIDFAMILY.AllowUserToAddRows = False
        Me.GRIDFAMILY.AllowUserToDeleteRows = False
        Me.GRIDFAMILY.AllowUserToResizeColumns = False
        Me.GRIDFAMILY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDFAMILY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDFAMILY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDFAMILY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDFAMILY.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDFAMILY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDFAMILY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDFAMILY.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.DataGridViewTextBoxColumn1, Me.GDOB, Me.GAGE, Me.GRELATION})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDFAMILY.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDFAMILY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GRIDFAMILY.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDFAMILY.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDFAMILY.Location = New System.Drawing.Point(0, 0)
        Me.GRIDFAMILY.MultiSelect = False
        Me.GRIDFAMILY.Name = "GRIDFAMILY"
        Me.GRIDFAMILY.ReadOnly = True
        Me.GRIDFAMILY.RowHeadersVisible = False
        Me.GRIDFAMILY.RowHeadersWidth = 30
        Me.GRIDFAMILY.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDFAMILY.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDFAMILY.RowTemplate.Height = 20
        Me.GRIDFAMILY.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDFAMILY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDFAMILY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDFAMILY.Size = New System.Drawing.Size(608, 235)
        Me.GRIDFAMILY.TabIndex = 475
        Me.GRIDFAMILY.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'GDOB
        '
        Me.GDOB.HeaderText = "DOB"
        Me.GDOB.Name = "GDOB"
        Me.GDOB.ReadOnly = True
        Me.GDOB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDOB.Width = 80
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
        Me.GRELATION.HeaderText = "Relarionship"
        Me.GRELATION.Name = "GRELATION"
        Me.GRELATION.ReadOnly = True
        Me.GRELATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(669, 303)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 228
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(861, 305)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 14)
        Me.Label8.TabIndex = 235
        Me.Label8.Text = "To"
        '
        'dttodate
        '
        Me.dttodate.CustomFormat = "dd/MM/yyyy"
        Me.dttodate.Enabled = False
        Me.dttodate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttodate.Location = New System.Drawing.Point(884, 301)
        Me.dttodate.Name = "dttodate"
        Me.dttodate.Size = New System.Drawing.Size(82, 22)
        Me.dttodate.TabIndex = 230
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(726, 305)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 14)
        Me.Label11.TabIndex = 234
        Me.Label11.Text = "From"
        '
        'dtfromdate
        '
        Me.dtfromdate.CustomFormat = "dd/MM/yyyy"
        Me.dtfromdate.Enabled = False
        Me.dtfromdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfromdate.Location = New System.Drawing.Point(762, 301)
        Me.dtfromdate.Name = "dtfromdate"
        Me.dtfromdate.Size = New System.Drawing.Size(82, 22)
        Me.dtfromdate.TabIndex = 229
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(372, 305)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(75, 14)
        Me.Label25.TabIndex = 233
        Me.Label25.Text = "Transactions"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(15, 9)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(184, 14)
        Me.Label21.TabIndex = 232
        Me.Label21.Text = "Double Click on an Officer to Edit"
        '
        'OfficerDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 741)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OfficerDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Officer Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.CMDEXCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Details.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Roomdetails.ResumeLayout(False)
        Me.BlendPanel3.ResumeLayout(False)
        CType(Me.GRIDFAMILY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gtype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GSETTLENO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCLAIMED As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents TXTEMPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCMPNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTMUINO As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtstd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents TXTRESINO As System.Windows.Forms.TextBox
    Friend WithEvents TXTRANK As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Roomdetails As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel3 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dttodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DOJ As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DECDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CHKINDIAN As System.Windows.Forms.CheckBox
    Friend WithEvents GRIDFAMILY As System.Windows.Forms.DataGridView
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GAGE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRELATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHKDONATION As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCONTRIBUTION As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTOFFICERNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDEXCEL As System.Windows.Forms.PictureBox
    Friend WithEvents CHKCONTRACT As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTSERVICE As System.Windows.Forms.TextBox
    Friend WithEvents GPAID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYEAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDPRINTHISTORY As System.Windows.Forms.Button
End Class
