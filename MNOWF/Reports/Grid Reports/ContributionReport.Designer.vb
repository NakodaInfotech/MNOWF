﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContributionReport
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
        Me.gcmpname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOFFICERS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GYEAR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPERCENT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDOK = New System.Windows.Forms.Button
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
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(736, 741)
        Me.BlendPanel1.TabIndex = 6
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(17, 39)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(703, 658)
        Me.gridbilldetails.TabIndex = 444
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcmpname, Me.GOFFICERS, Me.GYEAR, Me.GAMT, Me.GCHQNO, Me.GCHQDATE, Me.GPERCENT})
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
        'gcmpname
        '
        Me.gcmpname.Caption = "Company Name"
        Me.gcmpname.FieldName = "CMPNAME"
        Me.gcmpname.Name = "gcmpname"
        Me.gcmpname.Visible = True
        Me.gcmpname.VisibleIndex = 0
        Me.gcmpname.Width = 200
        '
        'GOFFICERS
        '
        Me.GOFFICERS.Caption = "No Of Officers"
        Me.GOFFICERS.FieldName = "TOTALOFFICERS"
        Me.GOFFICERS.Name = "GOFFICERS"
        Me.GOFFICERS.Visible = True
        Me.GOFFICERS.VisibleIndex = 1
        Me.GOFFICERS.Width = 80
        '
        'GYEAR
        '
        Me.GYEAR.Caption = "Year"
        Me.GYEAR.FieldName = "CONTRIYEAR"
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.Visible = True
        Me.GYEAR.VisibleIndex = 2
        Me.GYEAR.Width = 100
        '
        'GAMT
        '
        Me.GAMT.Caption = "Contribution"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "CONTRIBUTION"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 3
        Me.GAMT.Width = 80
        '
        'GCHQNO
        '
        Me.GCHQNO.Caption = "Chq No"
        Me.GCHQNO.FieldName = "CHQNO"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.Visible = True
        Me.GCHQNO.VisibleIndex = 4
        Me.GCHQNO.Width = 80
        '
        'GCHQDATE
        '
        Me.GCHQDATE.Caption = "Chq Date"
        Me.GCHQDATE.FieldName = "DATE"
        Me.GCHQDATE.Name = "GCHQDATE"
        Me.GCHQDATE.Visible = True
        Me.GCHQDATE.VisibleIndex = 5
        Me.GCHQDATE.Width = 80
        '
        'GPERCENT
        '
        Me.GPERCENT.Caption = "%"
        Me.GPERCENT.DisplayFormat.FormatString = "0.00"
        Me.GPERCENT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPERCENT.FieldName = "PERCENT"
        Me.GPERCENT.Name = "GPERCENT"
        Me.GPERCENT.Visible = True
        Me.GPERCENT.VisibleIndex = 6
        Me.GPERCENT.Width = 35
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
        Me.CMDOK.Location = New System.Drawing.Point(286, 703)
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
        Me.cmdcancel.Location = New System.Drawing.Point(364, 705)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(736, 25)
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
        'ContributionReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(736, 741)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.Name = "ContributionReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contribution Report"
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
    Friend WithEvents gcmpname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOFFICERS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYEAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GPERCENT As DevExpress.XtraGrid.Columns.GridColumn
End Class
