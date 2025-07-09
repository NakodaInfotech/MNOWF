<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SendWhatsapp
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOFFICERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOMPANYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMOBNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTAUTOCC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTERRORMSG = New System.Windows.Forms.TextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTOFFICERNO4 = New System.Windows.Forms.TextBox()
        Me.TXTOFFICERNO3 = New System.Windows.Forms.TextBox()
        Me.TXTOFFICERNO2 = New System.Windows.Forms.TextBox()
        Me.TXTOFFICERNO1 = New System.Windows.Forms.TextBox()
        Me.TXTOFFICERNO = New System.Windows.Forms.TextBox()
        Me.TXTMESSAGE = New System.Windows.Forms.TextBox()
        Me.CMBOFFICERNAME4 = New System.Windows.Forms.ComboBox()
        Me.CMBOFFICERNAME3 = New System.Windows.Forms.ComboBox()
        Me.CMBOFFICERNAME2 = New System.Windows.Forms.ComboBox()
        Me.CMBOFFICERNAME1 = New System.Windows.Forms.ComboBox()
        Me.CMBOFFICERNAME = New System.Windows.Forms.ComboBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.CMDSEND = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BlendPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTAUTOCC)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTERRORMSG)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO4)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO3)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO2)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO1)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNO)
        Me.BlendPanel1.Controls.Add(Me.TXTMESSAGE)
        Me.BlendPanel1.Controls.Add(Me.CMBOFFICERNAME4)
        Me.BlendPanel1.Controls.Add(Me.CMBOFFICERNAME3)
        Me.BlendPanel1.Controls.Add(Me.CMBOFFICERNAME2)
        Me.BlendPanel1.Controls.Add(Me.CMBOFFICERNAME1)
        Me.BlendPanel1.Controls.Add(Me.CMBOFFICERNAME)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.CMDSEND)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(558, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(654, 557)
        Me.TabControl1.TabIndex = 660
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.CHKSELECTALL)
        Me.TabPage1.Controls.Add(Me.gridbilldetails)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(646, 529)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Officer Selection"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(6, 6)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 2
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(3, 27)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(637, 496)
        Me.gridbilldetails.TabIndex = 3
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill, Me.GridView2})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GOFFICERNAME, Me.GRANK, Me.GCOMPANYNAME, Me.GMOBNO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCHK
        '
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'GOFFICERNAME
        '
        Me.GOFFICERNAME.Caption = "Officer Name"
        Me.GOFFICERNAME.FieldName = "OFFICERNAME"
        Me.GOFFICERNAME.ImageIndex = 0
        Me.GOFFICERNAME.Name = "GOFFICERNAME"
        Me.GOFFICERNAME.OptionsColumn.AllowEdit = False
        Me.GOFFICERNAME.Visible = True
        Me.GOFFICERNAME.VisibleIndex = 1
        Me.GOFFICERNAME.Width = 250
        '
        'GRANK
        '
        Me.GRANK.Caption = "Rank"
        Me.GRANK.FieldName = "RANK"
        Me.GRANK.Name = "GRANK"
        Me.GRANK.Visible = True
        Me.GRANK.VisibleIndex = 2
        Me.GRANK.Width = 100
        '
        'GCOMPANYNAME
        '
        Me.GCOMPANYNAME.Caption = "Company Name"
        Me.GCOMPANYNAME.FieldName = "COMPANYNAME"
        Me.GCOMPANYNAME.Name = "GCOMPANYNAME"
        Me.GCOMPANYNAME.Visible = True
        Me.GCOMPANYNAME.VisibleIndex = 3
        Me.GCOMPANYNAME.Width = 100
        '
        'GMOBNO
        '
        Me.GMOBNO.Caption = "Whatsapp No"
        Me.GMOBNO.FieldName = "MOBNO"
        Me.GMOBNO.Name = "GMOBNO"
        Me.GMOBNO.OptionsColumn.AllowEdit = False
        Me.GMOBNO.Visible = True
        Me.GMOBNO.VisibleIndex = 4
        Me.GMOBNO.Width = 100
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridbilldetails
        Me.GridView2.Name = "GridView2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(45, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Auto CC"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTAUTOCC
        '
        Me.TXTAUTOCC.Location = New System.Drawing.Point(98, 265)
        Me.TXTAUTOCC.MaxLength = 10
        Me.TXTAUTOCC.Name = "TXTAUTOCC"
        Me.TXTAUTOCC.Size = New System.Drawing.Size(176, 23)
        Me.TXTAUTOCC.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Error Message"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTERRORMSG
        '
        Me.TXTERRORMSG.BackColor = System.Drawing.Color.Linen
        Me.TXTERRORMSG.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTERRORMSG.ForeColor = System.Drawing.Color.DimGray
        Me.TXTERRORMSG.Location = New System.Drawing.Point(100, 325)
        Me.TXTERRORMSG.Multiline = True
        Me.TXTERRORMSG.Name = "TXTERRORMSG"
        Me.TXTERRORMSG.ReadOnly = True
        Me.TXTERRORMSG.Size = New System.Drawing.Size(423, 112)
        Me.TXTERRORMSG.TabIndex = 15
        Me.TXTERRORMSG.TabStop = False
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(527, 97)
        Me.TXTADD.MaxLength = 10
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(25, 23)
        Me.TXTADD.TabIndex = 14
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(527, 68)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(25, 23)
        Me.CMBCODE.TabIndex = 13
        Me.CMBCODE.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Message"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTOFFICERNO4
        '
        Me.TXTOFFICERNO4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO4.Location = New System.Drawing.Point(345, 132)
        Me.TXTOFFICERNO4.MaxLength = 10
        Me.TXTOFFICERNO4.Name = "TXTOFFICERNO4"
        Me.TXTOFFICERNO4.Size = New System.Drawing.Size(176, 23)
        Me.TXTOFFICERNO4.TabIndex = 9
        '
        'TXTOFFICERNO3
        '
        Me.TXTOFFICERNO3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO3.Location = New System.Drawing.Point(345, 102)
        Me.TXTOFFICERNO3.MaxLength = 10
        Me.TXTOFFICERNO3.Name = "TXTOFFICERNO3"
        Me.TXTOFFICERNO3.Size = New System.Drawing.Size(176, 23)
        Me.TXTOFFICERNO3.TabIndex = 7
        '
        'TXTOFFICERNO2
        '
        Me.TXTOFFICERNO2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO2.Location = New System.Drawing.Point(345, 72)
        Me.TXTOFFICERNO2.MaxLength = 10
        Me.TXTOFFICERNO2.Name = "TXTOFFICERNO2"
        Me.TXTOFFICERNO2.Size = New System.Drawing.Size(176, 23)
        Me.TXTOFFICERNO2.TabIndex = 5
        '
        'TXTOFFICERNO1
        '
        Me.TXTOFFICERNO1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO1.Location = New System.Drawing.Point(345, 42)
        Me.TXTOFFICERNO1.MaxLength = 10
        Me.TXTOFFICERNO1.Name = "TXTOFFICERNO1"
        Me.TXTOFFICERNO1.Size = New System.Drawing.Size(176, 23)
        Me.TXTOFFICERNO1.TabIndex = 3
        '
        'TXTOFFICERNO
        '
        Me.TXTOFFICERNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNO.Location = New System.Drawing.Point(345, 12)
        Me.TXTOFFICERNO.MaxLength = 10
        Me.TXTOFFICERNO.Name = "TXTOFFICERNO"
        Me.TXTOFFICERNO.Size = New System.Drawing.Size(176, 23)
        Me.TXTOFFICERNO.TabIndex = 1
        '
        'TXTMESSAGE
        '
        Me.TXTMESSAGE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMESSAGE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTMESSAGE.Location = New System.Drawing.Point(98, 161)
        Me.TXTMESSAGE.Multiline = True
        Me.TXTMESSAGE.Name = "TXTMESSAGE"
        Me.TXTMESSAGE.Size = New System.Drawing.Size(423, 98)
        Me.TXTMESSAGE.TabIndex = 10
        '
        'CMBOFFICERNAME4
        '
        Me.CMBOFFICERNAME4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICERNAME4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICERNAME4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICERNAME4.FormattingEnabled = True
        Me.CMBOFFICERNAME4.Location = New System.Drawing.Point(98, 132)
        Me.CMBOFFICERNAME4.MaxDropDownItems = 14
        Me.CMBOFFICERNAME4.Name = "CMBOFFICERNAME4"
        Me.CMBOFFICERNAME4.Size = New System.Drawing.Size(241, 23)
        Me.CMBOFFICERNAME4.TabIndex = 8
        '
        'CMBOFFICERNAME3
        '
        Me.CMBOFFICERNAME3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICERNAME3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICERNAME3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICERNAME3.FormattingEnabled = True
        Me.CMBOFFICERNAME3.Location = New System.Drawing.Point(98, 102)
        Me.CMBOFFICERNAME3.MaxDropDownItems = 14
        Me.CMBOFFICERNAME3.Name = "CMBOFFICERNAME3"
        Me.CMBOFFICERNAME3.Size = New System.Drawing.Size(241, 23)
        Me.CMBOFFICERNAME3.TabIndex = 6
        '
        'CMBOFFICERNAME2
        '
        Me.CMBOFFICERNAME2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICERNAME2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICERNAME2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICERNAME2.FormattingEnabled = True
        Me.CMBOFFICERNAME2.Location = New System.Drawing.Point(98, 72)
        Me.CMBOFFICERNAME2.MaxDropDownItems = 14
        Me.CMBOFFICERNAME2.Name = "CMBOFFICERNAME2"
        Me.CMBOFFICERNAME2.Size = New System.Drawing.Size(241, 23)
        Me.CMBOFFICERNAME2.TabIndex = 4
        '
        'CMBOFFICERNAME1
        '
        Me.CMBOFFICERNAME1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICERNAME1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICERNAME1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICERNAME1.FormattingEnabled = True
        Me.CMBOFFICERNAME1.Location = New System.Drawing.Point(98, 42)
        Me.CMBOFFICERNAME1.MaxDropDownItems = 14
        Me.CMBOFFICERNAME1.Name = "CMBOFFICERNAME1"
        Me.CMBOFFICERNAME1.Size = New System.Drawing.Size(241, 23)
        Me.CMBOFFICERNAME1.TabIndex = 2
        '
        'CMBOFFICERNAME
        '
        Me.CMBOFFICERNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOFFICERNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOFFICERNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOFFICERNAME.FormattingEnabled = True
        Me.CMBOFFICERNAME.Location = New System.Drawing.Point(98, 12)
        Me.CMBOFFICERNAME.MaxDropDownItems = 14
        Me.CMBOFFICERNAME.Name = "CMBOFFICERNAME"
        Me.CMBOFFICERNAME.Size = New System.Drawing.Size(241, 23)
        Me.CMBOFFICERNAME.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(294, 291)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 12
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'CMDSEND
        '
        Me.CMDSEND.BackColor = System.Drawing.Color.Transparent
        Me.CMDSEND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMDSEND.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSEND.FlatAppearance.BorderSize = 0
        Me.CMDSEND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSEND.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSEND.Location = New System.Drawing.Point(208, 291)
        Me.CMDSEND.Name = "CMDSEND"
        Me.CMDSEND.Size = New System.Drawing.Size(80, 28)
        Me.CMDSEND.TabIndex = 11
        Me.CMDSEND.Text = "&Send"
        Me.CMDSEND.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CMDSEND.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Officer Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Officer Name 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Officer Name 2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Officer Name 3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Officer Name 4"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'SendWhatsapp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SendWhatsapp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Send Whatsapp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GOFFICERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMPANYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTAUTOCC As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTERRORMSG As TextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTOFFICERNO4 As TextBox
    Friend WithEvents TXTOFFICERNO3 As TextBox
    Friend WithEvents TXTOFFICERNO2 As TextBox
    Friend WithEvents TXTOFFICERNO1 As TextBox
    Friend WithEvents TXTOFFICERNO As TextBox
    Friend WithEvents TXTMESSAGE As TextBox
    Friend WithEvents CMBOFFICERNAME4 As ComboBox
    Friend WithEvents CMBOFFICERNAME3 As ComboBox
    Friend WithEvents CMBOFFICERNAME2 As ComboBox
    Friend WithEvents CMBOFFICERNAME1 As ComboBox
    Friend WithEvents CMBOFFICERNAME As ComboBox
    Friend WithEvents cmdcancel As Button
    Friend WithEvents CMDSEND As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
