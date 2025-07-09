<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClaimPaymentRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClaimPaymentRegister))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcmpname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gempcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gmuino = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOFFBANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBRANCH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLAIMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREQNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRELATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLAIMEDAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANKNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHQNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHQDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAYAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSETTLENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVESSEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKSETTLED = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CHKCLOSED = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CLAIMREPORT = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKSETTLED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKCLOSED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 741)
        Me.BlendPanel1.TabIndex = 4
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"", "EDUCATION", "MEDICAL"})
        Me.CMBTYPE.Location = New System.Drawing.Point(54, 35)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(123, 22)
        Me.CMBTYPE.TabIndex = 638
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 639
        Me.Label6.Text = "Type"
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowdetails.Image = Global.MNOWF.My.Resources.Resources.showdetails2
        Me.cmdshowdetails.Location = New System.Drawing.Point(467, 34)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(83, 25)
        Me.cmdshowdetails.TabIndex = 636
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(183, 37)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 632
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(382, 35)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(79, 22)
        Me.dtto.TabIndex = 635
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(358, 39)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 637
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(273, 35)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(80, 22)
        Me.dtfrom.TabIndex = 634
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(235, 39)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 633
        Me.lblfrom.Text = "From"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 66)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKSETTLED, Me.CHKCLOSED})
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 631)
        Me.gridbilldetails.TabIndex = 442
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTYPE, Me.gname, Me.gcmpname, Me.grank, Me.gempcode, Me.gmuino, Me.GOFFBANK, Me.GBRANCH, Me.GACNAME, Me.GACNO, Me.GCLAIMNO, Me.GREQNO, Me.GCATEGORY, Me.GRELATION, Me.GCLAIMEDAMT, Me.GAMT, Me.GBANKNAME, Me.GCHQNO, Me.GCHQDATE, Me.GPAYAMT, Me.GSETTLENO, Me.GVESSEL})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.AllowCellMerge = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 0
        '
        'gname
        '
        Me.gname.Caption = "Officer Name"
        Me.gname.FieldName = "NAME"
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 200
        '
        'gcmpname
        '
        Me.gcmpname.Caption = "Company Name"
        Me.gcmpname.FieldName = "CMPNAME"
        Me.gcmpname.Name = "gcmpname"
        Me.gcmpname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcmpname.Visible = True
        Me.gcmpname.VisibleIndex = 2
        Me.gcmpname.Width = 200
        '
        'grank
        '
        Me.grank.Caption = "Rank"
        Me.grank.FieldName = "RANK"
        Me.grank.Name = "grank"
        Me.grank.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.grank.Visible = True
        Me.grank.VisibleIndex = 3
        Me.grank.Width = 150
        '
        'gempcode
        '
        Me.gempcode.Caption = "Emp Code"
        Me.gempcode.FieldName = "EMPCODE"
        Me.gempcode.Name = "gempcode"
        Me.gempcode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gempcode.Visible = True
        Me.gempcode.VisibleIndex = 4
        Me.gempcode.Width = 100
        '
        'gmuino
        '
        Me.gmuino.Caption = "MUI No."
        Me.gmuino.FieldName = "MUINO"
        Me.gmuino.Name = "gmuino"
        Me.gmuino.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gmuino.Visible = True
        Me.gmuino.VisibleIndex = 5
        Me.gmuino.Width = 100
        '
        'GOFFBANK
        '
        Me.GOFFBANK.Caption = "Off. Bank Name"
        Me.GOFFBANK.FieldName = "OFFBANK"
        Me.GOFFBANK.Name = "GOFFBANK"
        Me.GOFFBANK.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GOFFBANK.Visible = True
        Me.GOFFBANK.VisibleIndex = 6
        Me.GOFFBANK.Width = 120
        '
        'GBRANCH
        '
        Me.GBRANCH.Caption = "Branch"
        Me.GBRANCH.FieldName = "BRANCH"
        Me.GBRANCH.Name = "GBRANCH"
        Me.GBRANCH.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GBRANCH.Visible = True
        Me.GBRANCH.VisibleIndex = 7
        Me.GBRANCH.Width = 100
        '
        'GACNAME
        '
        Me.GACNAME.Caption = "A/C Name"
        Me.GACNAME.FieldName = "ACNAME"
        Me.GACNAME.Name = "GACNAME"
        Me.GACNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GACNAME.Visible = True
        Me.GACNAME.VisibleIndex = 8
        Me.GACNAME.Width = 120
        '
        'GACNO
        '
        Me.GACNO.Caption = "A/C No"
        Me.GACNO.FieldName = "ACNO"
        Me.GACNO.Name = "GACNO"
        Me.GACNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GACNO.Visible = True
        Me.GACNO.VisibleIndex = 9
        Me.GACNO.Width = 100
        '
        'GCLAIMNO
        '
        Me.GCLAIMNO.Caption = "Claim No"
        Me.GCLAIMNO.FieldName = "CLAIMNO"
        Me.GCLAIMNO.Name = "GCLAIMNO"
        Me.GCLAIMNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCLAIMNO.Visible = True
        Me.GCLAIMNO.VisibleIndex = 10
        Me.GCLAIMNO.Width = 50
        '
        'GREQNO
        '
        Me.GREQNO.Caption = "Req No"
        Me.GREQNO.FieldName = "REQNO"
        Me.GREQNO.Name = "GREQNO"
        Me.GREQNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GREQNO.Visible = True
        Me.GREQNO.VisibleIndex = 11
        Me.GREQNO.Width = 50
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 12
        Me.GCATEGORY.Width = 100
        '
        'GRELATION
        '
        Me.GRELATION.Caption = "Relation"
        Me.GRELATION.FieldName = "RELATION"
        Me.GRELATION.Name = "GRELATION"
        Me.GRELATION.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GRELATION.Visible = True
        Me.GRELATION.VisibleIndex = 13
        '
        'GCLAIMEDAMT
        '
        Me.GCLAIMEDAMT.Caption = "Claimed Amt"
        Me.GCLAIMEDAMT.DisplayFormat.FormatString = "0.00"
        Me.GCLAIMEDAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLAIMEDAMT.FieldName = "CLAIMEDAMT"
        Me.GCLAIMEDAMT.Name = "GCLAIMEDAMT"
        Me.GCLAIMEDAMT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCLAIMEDAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCLAIMEDAMT.Visible = True
        Me.GCLAIMEDAMT.VisibleIndex = 14
        Me.GCLAIMEDAMT.Width = 80
        '
        'GAMT
        '
        Me.GAMT.Caption = "Settled Amt"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 15
        Me.GAMT.Width = 80
        '
        'GBANKNAME
        '
        Me.GBANKNAME.Caption = "Bank Name"
        Me.GBANKNAME.FieldName = "BANKNAME"
        Me.GBANKNAME.Name = "GBANKNAME"
        Me.GBANKNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GBANKNAME.Visible = True
        Me.GBANKNAME.VisibleIndex = 16
        '
        'GCHQNO
        '
        Me.GCHQNO.Caption = "Chq No"
        Me.GCHQNO.FieldName = "CHQNO"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHQNO.Visible = True
        Me.GCHQNO.VisibleIndex = 17
        '
        'GCHQDATE
        '
        Me.GCHQDATE.Caption = "Chq Date"
        Me.GCHQDATE.FieldName = "PAYDATE"
        Me.GCHQDATE.Name = "GCHQDATE"
        Me.GCHQDATE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHQDATE.Visible = True
        Me.GCHQDATE.VisibleIndex = 18
        '
        'GPAYAMT
        '
        Me.GPAYAMT.Caption = "Payment Amt"
        Me.GPAYAMT.DisplayFormat.FormatString = "0.00"
        Me.GPAYAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPAYAMT.FieldName = "CHQAMT"
        Me.GPAYAMT.Name = "GPAYAMT"
        Me.GPAYAMT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GPAYAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPAYAMT.Visible = True
        Me.GPAYAMT.VisibleIndex = 19
        '
        'GSETTLENO
        '
        Me.GSETTLENO.Caption = "SETTLENO"
        Me.GSETTLENO.FieldName = "SETTLENO"
        Me.GSETTLENO.Name = "GSETTLENO"
        Me.GSETTLENO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GVESSEL
        '
        Me.GVESSEL.Caption = "Vessel"
        Me.GVESSEL.FieldName = "VESSEL"
        Me.GVESSEL.Name = "GVESSEL"
        Me.GVESSEL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVESSEL.Visible = True
        Me.GVESSEL.VisibleIndex = 20
        Me.GVESSEL.Width = 200
        '
        'CHKSETTLED
        '
        Me.CHKSETTLED.AutoHeight = False
        Me.CHKSETTLED.Name = "CHKSETTLED"
        '
        'CHKCLOSED
        '
        Me.CHKCLOSED.AutoHeight = False
        Me.CHKCLOSED.Name = "CHKCLOSED"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.MNOWF.My.Resources.Resources.ok
        Me.CMDOK.Location = New System.Drawing.Point(429, 703)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(507, 705)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2, Me.CLAIMREPORT, Me.PrintToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.MNOWF.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CLAIMREPORT
        '
        Me.CLAIMREPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CLAIMREPORT.Image = Global.MNOWF.My.Resources.Resources.Bookings
        Me.CLAIMREPORT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CLAIMREPORT.Name = "CLAIMREPORT"
        Me.CLAIMREPORT.Size = New System.Drawing.Size(23, 22)
        Me.CLAIMREPORT.Text = "ToolStripButton1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print Bank Format"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ClaimPaymentRegister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 741)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ClaimPaymentRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Claim Payment Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKSETTLED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKCLOSED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcmpname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gempcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gmuino As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKSETTLED As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CHKCLOSED As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOFFBANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBRANCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLAIMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLAIMEDAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRELATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANKNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAYAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSETTLENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents GACNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CLAIMREPORT As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents GVESSEL As DevExpress.XtraGrid.Columns.GridColumn
End Class
