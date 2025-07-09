<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyMonthlyReport
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAPRIL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMAY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GJUNE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GJULY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAUGUST = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSEPT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOCT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNOV = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDEC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GJAN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFEB = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMAR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 741)
        Me.BlendPanel1.TabIndex = 5
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"", "EDUCATION", "MEDICAL"})
        Me.CMBTYPE.Location = New System.Drawing.Point(100, 33)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(123, 22)
        Me.CMBTYPE.TabIndex = 622
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 623
        Me.Label6.Text = "Type"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 56)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1206, 643)
        Me.gridbilldetails.TabIndex = 324
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCMPNAME, Me.GAPRIL, Me.GMAY, Me.GJUNE, Me.GJULY, Me.GAUGUST, Me.GSEPT, Me.GOCT, Me.GNOV, Me.GDEC, Me.GJAN, Me.GFEB, Me.GMAR})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Compnay Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 0
        Me.GCMPNAME.Width = 200
        '
        'GAPRIL
        '
        Me.GAPRIL.Caption = "April"
        Me.GAPRIL.DisplayFormat.FormatString = "0.00"
        Me.GAPRIL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAPRIL.FieldName = "APRIL"
        Me.GAPRIL.Name = "GAPRIL"
        Me.GAPRIL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAPRIL.Visible = True
        Me.GAPRIL.VisibleIndex = 1
        '
        'GMAY
        '
        Me.GMAY.Caption = "May"
        Me.GMAY.DisplayFormat.FormatString = "0.00"
        Me.GMAY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMAY.FieldName = "MAY"
        Me.GMAY.Name = "GMAY"
        Me.GMAY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMAY.Visible = True
        Me.GMAY.VisibleIndex = 2
        '
        'GJUNE
        '
        Me.GJUNE.Caption = "June"
        Me.GJUNE.DisplayFormat.FormatString = "0.00"
        Me.GJUNE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJUNE.FieldName = "JUNE"
        Me.GJUNE.Name = "GJUNE"
        Me.GJUNE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GJUNE.Visible = True
        Me.GJUNE.VisibleIndex = 3
        '
        'GJULY
        '
        Me.GJULY.Caption = "July"
        Me.GJULY.DisplayFormat.FormatString = "0.00"
        Me.GJULY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJULY.FieldName = "JULY"
        Me.GJULY.Name = "GJULY"
        Me.GJULY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GJULY.Visible = True
        Me.GJULY.VisibleIndex = 4
        '
        'GAUGUST
        '
        Me.GAUGUST.Caption = "August"
        Me.GAUGUST.DisplayFormat.FormatString = "0.00"
        Me.GAUGUST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAUGUST.FieldName = "AUGUST"
        Me.GAUGUST.Name = "GAUGUST"
        Me.GAUGUST.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAUGUST.Visible = True
        Me.GAUGUST.VisibleIndex = 5
        '
        'GSEPT
        '
        Me.GSEPT.Caption = "September"
        Me.GSEPT.DisplayFormat.FormatString = "0.00"
        Me.GSEPT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSEPT.FieldName = "SEPTEMBER"
        Me.GSEPT.Name = "GSEPT"
        Me.GSEPT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSEPT.Visible = True
        Me.GSEPT.VisibleIndex = 6
        '
        'GOCT
        '
        Me.GOCT.Caption = "October"
        Me.GOCT.DisplayFormat.FormatString = "0.00"
        Me.GOCT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOCT.FieldName = "OCTOBER"
        Me.GOCT.Name = "GOCT"
        Me.GOCT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GOCT.Visible = True
        Me.GOCT.VisibleIndex = 7
        '
        'GNOV
        '
        Me.GNOV.Caption = "November"
        Me.GNOV.DisplayFormat.FormatString = "0.00"
        Me.GNOV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNOV.FieldName = "NOVEMBER"
        Me.GNOV.Name = "GNOV"
        Me.GNOV.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GNOV.Visible = True
        Me.GNOV.VisibleIndex = 8
        '
        'GDEC
        '
        Me.GDEC.Caption = "December"
        Me.GDEC.DisplayFormat.FormatString = "0.00"
        Me.GDEC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDEC.FieldName = "DECEMBER"
        Me.GDEC.Name = "GDEC"
        Me.GDEC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GDEC.Visible = True
        Me.GDEC.VisibleIndex = 9
        '
        'GJAN
        '
        Me.GJAN.Caption = "January"
        Me.GJAN.DisplayFormat.FormatString = "0.00"
        Me.GJAN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAN.FieldName = "JANUARY"
        Me.GJAN.Name = "GJAN"
        Me.GJAN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GJAN.Visible = True
        Me.GJAN.VisibleIndex = 10
        '
        'GFEB
        '
        Me.GFEB.Caption = "February"
        Me.GFEB.DisplayFormat.FormatString = "0.00"
        Me.GFEB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFEB.FieldName = "FEBRUARY"
        Me.GFEB.Name = "GFEB"
        Me.GFEB.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GFEB.Visible = True
        Me.GFEB.VisibleIndex = 11
        '
        'GMAR
        '
        Me.GMAR.Caption = "March"
        Me.GMAR.DisplayFormat.FormatString = "0.00"
        Me.GMAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMAR.FieldName = "MARCH"
        Me.GMAR.Name = "GMAR"
        Me.GMAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMAR.Visible = True
        Me.GMAR.VisibleIndex = 12
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
        Me.cmdcancel.Location = New System.Drawing.Point(468, 705)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2})
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
        'CompanyMonthlyReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 741)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CompanyMonthlyReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Company Monthly Report"
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
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAPRIL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJUNE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJULY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAUGUST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSEPT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOCT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFEB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
