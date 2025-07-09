<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MedClaimSettlementDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greqno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greqdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOFFICER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMUINO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grelation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcourse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ginstitute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.guniversity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gclaimedamt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsettleamt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVESSEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGISTER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 5
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
        Me.CMDOK.Location = New System.Drawing.Point(542, 543)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 317
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
        Me.cmdcancel.Location = New System.Drawing.Point(620, 544)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 61)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1211, 470)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.greqno, Me.greqdate, Me.GOFFICER, Me.GCMPNAME, Me.GRANK, Me.GMUINO, Me.grelation, Me.gcourse, Me.ginstitute, Me.guniversity, Me.gclaimedamt, Me.gsettleamt, Me.GVESSEL, Me.GREGISTER})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "srno"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "date"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 80
        '
        'greqno
        '
        Me.greqno.Caption = "Req. No."
        Me.greqno.FieldName = "reqno"
        Me.greqno.Name = "greqno"
        Me.greqno.Visible = True
        Me.greqno.VisibleIndex = 2
        Me.greqno.Width = 55
        '
        'greqdate
        '
        Me.greqdate.Caption = "Req Date"
        Me.greqdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.greqdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.greqdate.FieldName = "reqdate"
        Me.greqdate.Name = "greqdate"
        Me.greqdate.Visible = True
        Me.greqdate.VisibleIndex = 3
        Me.greqdate.Width = 80
        '
        'GOFFICER
        '
        Me.GOFFICER.Caption = "Officer"
        Me.GOFFICER.FieldName = "officer"
        Me.GOFFICER.Name = "GOFFICER"
        Me.GOFFICER.Visible = True
        Me.GOFFICER.VisibleIndex = 4
        Me.GOFFICER.Width = 180
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Company Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 5
        Me.GCMPNAME.Width = 200
        '
        'GRANK
        '
        Me.GRANK.Caption = "Rank"
        Me.GRANK.FieldName = "RANKNAME"
        Me.GRANK.Name = "GRANK"
        Me.GRANK.Visible = True
        Me.GRANK.VisibleIndex = 6
        Me.GRANK.Width = 100
        '
        'GMUINO
        '
        Me.GMUINO.Caption = "MUI No."
        Me.GMUINO.FieldName = "MUI"
        Me.GMUINO.Name = "GMUINO"
        Me.GMUINO.Visible = True
        Me.GMUINO.VisibleIndex = 7
        Me.GMUINO.Width = 100
        '
        'grelation
        '
        Me.grelation.Caption = "Relative"
        Me.grelation.FieldName = "relative"
        Me.grelation.Name = "grelation"
        Me.grelation.Visible = True
        Me.grelation.VisibleIndex = 8
        Me.grelation.Width = 130
        '
        'gcourse
        '
        Me.gcourse.Caption = "Diagnosis"
        Me.gcourse.FieldName = "diagnosis"
        Me.gcourse.Name = "gcourse"
        Me.gcourse.Visible = True
        Me.gcourse.VisibleIndex = 9
        Me.gcourse.Width = 180
        '
        'ginstitute
        '
        Me.ginstitute.Caption = "Dr. Name"
        Me.ginstitute.FieldName = "drname"
        Me.ginstitute.Name = "ginstitute"
        Me.ginstitute.Visible = True
        Me.ginstitute.VisibleIndex = 10
        Me.ginstitute.Width = 180
        '
        'guniversity
        '
        Me.guniversity.Caption = "Hospital"
        Me.guniversity.FieldName = "hospname"
        Me.guniversity.Name = "guniversity"
        Me.guniversity.Visible = True
        Me.guniversity.VisibleIndex = 11
        Me.guniversity.Width = 180
        '
        'gclaimedamt
        '
        Me.gclaimedamt.Caption = "Claimed Amt."
        Me.gclaimedamt.DisplayFormat.FormatString = "0.00"
        Me.gclaimedamt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gclaimedamt.FieldName = "claimedamt"
        Me.gclaimedamt.Name = "gclaimedamt"
        Me.gclaimedamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gclaimedamt.Visible = True
        Me.gclaimedamt.VisibleIndex = 12
        Me.gclaimedamt.Width = 80
        '
        'gsettleamt
        '
        Me.gsettleamt.Caption = "Settle Amt"
        Me.gsettleamt.DisplayFormat.FormatString = "0.00"
        Me.gsettleamt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gsettleamt.FieldName = "settleamt"
        Me.gsettleamt.Name = "gsettleamt"
        Me.gsettleamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gsettleamt.Visible = True
        Me.gsettleamt.VisibleIndex = 13
        Me.gsettleamt.Width = 80
        '
        'GVESSEL
        '
        Me.GVESSEL.Caption = "Vessel"
        Me.GVESSEL.FieldName = "VESSEL"
        Me.GVESSEL.Name = "GVESSEL"
        Me.GVESSEL.Visible = True
        Me.GVESSEL.VisibleIndex = 14
        Me.GVESSEL.Width = 200
        '
        'GREGISTER
        '
        Me.GREGISTER.Caption = "Register"
        Me.GREGISTER.FieldName = "REGISTER"
        Me.GREGISTER.Name = "GREGISTER"
        Me.GREGISTER.Visible = True
        Me.GREGISTER.VisibleIndex = 15
        Me.GREGISTER.Width = 200
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(757, 35)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(218, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(703, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Register"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.MNOWF.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 44)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(177, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select an Settlement to Change"
        '
        'MedClaimSettlementDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MedClaimSettlementDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Claim Settlement Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents greqno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents greqdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOFFICER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grelation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcourse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ginstitute As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents guniversity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gclaimedamt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gsettleamt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GVESSEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMUINO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGISTER As DevExpress.XtraGrid.Columns.GridColumn
End Class
