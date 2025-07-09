<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EduSettlementOutstanding
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCLAIMNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcmpname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grank = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gempcode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gmuino = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOURSE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOURSEYEAR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINSTITUTE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNIVERSITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRELATION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRELATIONSHIP = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCLAIMEDAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSETTLEAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSETTLENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKSETTLED = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.CHKCLOSED = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
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
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 741)
        Me.BlendPanel1.TabIndex = 6
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 38)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKSETTLED, Me.CHKCLOSED})
        Me.gridbilldetails.Size = New System.Drawing.Size(981, 660)
        Me.gridbilldetails.TabIndex = 444
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCLAIMNO, Me.GDATE, Me.GREQNO, Me.gname, Me.gcmpname, Me.grank, Me.gempcode, Me.gmuino, Me.GCATEGORY, Me.GCOURSE, Me.GCOURSEYEAR, Me.GINSTITUTE, Me.GUNIVERSITY, Me.GRELATION, Me.GRELATIONSHIP, Me.GCLAIMEDAMT, Me.GSETTLEAMT, Me.GSETTLENO})
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
        'GCLAIMNO
        '
        Me.GCLAIMNO.Caption = "Claim No"
        Me.GCLAIMNO.FieldName = "CLAIMNO"
        Me.GCLAIMNO.Name = "GCLAIMNO"
        Me.GCLAIMNO.Visible = True
        Me.GCLAIMNO.VisibleIndex = 0
        Me.GCLAIMNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "CLAIMDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GREQNO
        '
        Me.GREQNO.Caption = "Req No"
        Me.GREQNO.FieldName = "REQNO"
        Me.GREQNO.Name = "GREQNO"
        Me.GREQNO.Visible = True
        Me.GREQNO.VisibleIndex = 2
        Me.GREQNO.Width = 50
        '
        'gname
        '
        Me.gname.Caption = "Officer Name"
        Me.gname.FieldName = "NAME"
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 3
        Me.gname.Width = 200
        '
        'gcmpname
        '
        Me.gcmpname.Caption = "Company Name"
        Me.gcmpname.FieldName = "CMPNAME"
        Me.gcmpname.Name = "gcmpname"
        Me.gcmpname.Visible = True
        Me.gcmpname.VisibleIndex = 4
        Me.gcmpname.Width = 200
        '
        'grank
        '
        Me.grank.Caption = "Rank"
        Me.grank.FieldName = "RANK"
        Me.grank.Name = "grank"
        Me.grank.Visible = True
        Me.grank.VisibleIndex = 5
        Me.grank.Width = 150
        '
        'gempcode
        '
        Me.gempcode.Caption = "Emp Code"
        Me.gempcode.FieldName = "EMPCODE"
        Me.gempcode.Name = "gempcode"
        Me.gempcode.Visible = True
        Me.gempcode.VisibleIndex = 6
        Me.gempcode.Width = 100
        '
        'gmuino
        '
        Me.gmuino.Caption = "MUI No."
        Me.gmuino.FieldName = "MUINO"
        Me.gmuino.Name = "gmuino"
        Me.gmuino.Visible = True
        Me.gmuino.VisibleIndex = 7
        Me.gmuino.Width = 100
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 8
        Me.GCATEGORY.Width = 100
        '
        'GCOURSE
        '
        Me.GCOURSE.Caption = "Course Name"
        Me.GCOURSE.FieldName = "COURSENAME"
        Me.GCOURSE.Name = "GCOURSE"
        Me.GCOURSE.Visible = True
        Me.GCOURSE.VisibleIndex = 9
        Me.GCOURSE.Width = 200
        '
        'GCOURSEYEAR
        '
        Me.GCOURSEYEAR.Caption = "Course Year"
        Me.GCOURSEYEAR.FieldName = "COURSEYEAR"
        Me.GCOURSEYEAR.Name = "GCOURSEYEAR"
        Me.GCOURSEYEAR.Visible = True
        Me.GCOURSEYEAR.VisibleIndex = 10
        '
        'GINSTITUTE
        '
        Me.GINSTITUTE.Caption = "Institute Name"
        Me.GINSTITUTE.FieldName = "INSTITUTE"
        Me.GINSTITUTE.Name = "GINSTITUTE"
        Me.GINSTITUTE.Visible = True
        Me.GINSTITUTE.VisibleIndex = 11
        Me.GINSTITUTE.Width = 200
        '
        'GUNIVERSITY
        '
        Me.GUNIVERSITY.Caption = "University"
        Me.GUNIVERSITY.FieldName = "UNIVERSITY"
        Me.GUNIVERSITY.Name = "GUNIVERSITY"
        Me.GUNIVERSITY.Visible = True
        Me.GUNIVERSITY.VisibleIndex = 12
        Me.GUNIVERSITY.Width = 150
        '
        'GRELATION
        '
        Me.GRELATION.Caption = "Dependant"
        Me.GRELATION.FieldName = "RELATION"
        Me.GRELATION.Name = "GRELATION"
        Me.GRELATION.Visible = True
        Me.GRELATION.VisibleIndex = 13
        '
        'GRELATIONSHIP
        '
        Me.GRELATIONSHIP.Caption = "Relationship"
        Me.GRELATIONSHIP.FieldName = "RELATIONSHIP"
        Me.GRELATIONSHIP.Name = "GRELATIONSHIP"
        Me.GRELATIONSHIP.Visible = True
        Me.GRELATIONSHIP.VisibleIndex = 14
        '
        'GCLAIMEDAMT
        '
        Me.GCLAIMEDAMT.Caption = "Claimed Amt"
        Me.GCLAIMEDAMT.DisplayFormat.FormatString = "0.00"
        Me.GCLAIMEDAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLAIMEDAMT.FieldName = "CLAIMEDAMT"
        Me.GCLAIMEDAMT.Name = "GCLAIMEDAMT"
        Me.GCLAIMEDAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCLAIMEDAMT.Visible = True
        Me.GCLAIMEDAMT.VisibleIndex = 15
        Me.GCLAIMEDAMT.Width = 80
        '
        'GSETTLEAMT
        '
        Me.GSETTLEAMT.Caption = "Settled Amt"
        Me.GSETTLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GSETTLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSETTLEAMT.FieldName = "AMT"
        Me.GSETTLEAMT.Name = "GSETTLEAMT"
        Me.GSETTLEAMT.SummaryItem.FieldName = "SETTLEDAMT"
        Me.GSETTLEAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSETTLEAMT.Visible = True
        Me.GSETTLEAMT.VisibleIndex = 16
        '
        'GSETTLENO
        '
        Me.GSETTLENO.Caption = "SETTLENO"
        Me.GSETTLENO.FieldName = "SETTLENO"
        Me.GSETTLENO.Name = "GSETTLENO"
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
        Me.CMDOK.Location = New System.Drawing.Point(429, 704)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 25)
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
        Me.cmdcancel.Location = New System.Drawing.Point(507, 706)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 23)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
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
        'EduSettlementOutstanding
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 741)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EduSettlementOutstanding"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Education Settlement Outstanding"
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
    Friend WithEvents GCLAIMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcmpname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gempcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gmuino As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOURSE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOURSEYEAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINSTITUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIVERSITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRELATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRELATIONSHIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLAIMEDAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSETTLENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKSETTLED As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CHKCLOSED As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GSETTLEAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
