<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectInward
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
        Me.gridBilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gadd = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GINWARDNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRECDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDOCTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSENTBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmbformname = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridBilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridBilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(854, 546)
        Me.BlendPanel1.TabIndex = 7
        '
        'gridBilldetails
        '
        Me.gridBilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBilldetails.Location = New System.Drawing.Point(22, 33)
        Me.gridBilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridBilldetails.MainView = Me.gridbill
        Me.gridBilldetails.Name = "gridBilldetails"
        Me.gridBilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbformname, Me.RepositoryItemCheckEdit1})
        Me.gridBilldetails.Size = New System.Drawing.Size(811, 472)
        Me.gridBilldetails.TabIndex = 252
        Me.gridBilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gadd, Me.GINWARDNO, Me.GRECDATE, Me.GDOCTYPE, Me.GSENTBY, Me.GREMARKS})
        Me.gridbill.GridControl = Me.gridBilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gadd
        '
        Me.gadd.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gadd.FieldName = "DONE"
        Me.gadd.Name = "gadd"
        Me.gadd.OptionsColumn.ShowCaption = False
        Me.gadd.Visible = True
        Me.gadd.VisibleIndex = 0
        Me.gadd.Width = 40
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GINWARDNO
        '
        Me.GINWARDNO.Caption = "Inward No"
        Me.GINWARDNO.FieldName = "INWARDNO"
        Me.GINWARDNO.Name = "GINWARDNO"
        Me.GINWARDNO.OptionsColumn.AllowEdit = False
        Me.GINWARDNO.OptionsColumn.ReadOnly = True
        Me.GINWARDNO.Visible = True
        Me.GINWARDNO.VisibleIndex = 1
        '
        'GRECDATE
        '
        Me.GRECDATE.Caption = "Rec Date"
        Me.GRECDATE.FieldName = "RECDATE"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.OptionsColumn.AllowEdit = False
        Me.GRECDATE.Visible = True
        Me.GRECDATE.VisibleIndex = 2
        Me.GRECDATE.Width = 80
        '
        'GDOCTYPE
        '
        Me.GDOCTYPE.Caption = "Doc Type"
        Me.GDOCTYPE.FieldName = "DOCTYPE"
        Me.GDOCTYPE.Name = "GDOCTYPE"
        Me.GDOCTYPE.OptionsColumn.AllowEdit = False
        Me.GDOCTYPE.Visible = True
        Me.GDOCTYPE.VisibleIndex = 3
        Me.GDOCTYPE.Width = 120
        '
        'GSENTBY
        '
        Me.GSENTBY.Caption = "Sent By"
        Me.GSENTBY.FieldName = "SENTBY"
        Me.GSENTBY.Name = "GSENTBY"
        Me.GSENTBY.OptionsColumn.AllowEdit = False
        Me.GSENTBY.Visible = True
        Me.GSENTBY.VisibleIndex = 4
        Me.GSENTBY.Width = 120
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 5
        Me.GREMARKS.Width = 320
        '
        'cmbformname
        '
        Me.cmbformname.AutoHeight = False
        Me.cmbformname.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbformname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbformname.DropDownRows = 10
        Me.cmbformname.Name = "cmbformname"
        Me.cmbformname.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbformname.ValidateOnEnterKey = True
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(430, 518)
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
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 11)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(108, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Document"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(344, 518)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'SelectInward
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(854, 546)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectInward"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Inward"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridBilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents gridBilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gadd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GINWARDNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbformname As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSENTBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
End Class
