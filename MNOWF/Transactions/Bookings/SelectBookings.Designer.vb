<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBookings
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
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKCOL = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcmpname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grank = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gempcode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gmuino = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GARRIVAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDEPARTURE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDEPOSIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKCOL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1008, 546)
        Me.BlendPanel1.TabIndex = 4
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 38)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKCOL})
        Me.gridbilldetails.Size = New System.Drawing.Size(981, 475)
        Me.gridbilldetails.TabIndex = 442
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GDATE, Me.gname, Me.gcmpname, Me.grank, Me.gempcode, Me.gmuino, Me.GARRIVAL, Me.GDEPARTURE, Me.GAMT, Me.GDEPOSIT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CLAIMAMT", Me.GARRIVAL, "")})
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKCOL
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 40
        '
        'CHKCOL
        '
        Me.CHKCOL.AutoHeight = False
        Me.CHKCOL.Caption = ""
        Me.CHKCOL.Name = "CHKCOL"
        Me.CHKCOL.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Booking No."
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 80
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 3
        Me.gname.Width = 200
        '
        'gcmpname
        '
        Me.gcmpname.Caption = "Cmp Name"
        Me.gcmpname.FieldName = "CMPNAME"
        Me.gcmpname.Name = "gcmpname"
        Me.gcmpname.OptionsColumn.AllowEdit = False
        Me.gcmpname.Visible = True
        Me.gcmpname.VisibleIndex = 4
        Me.gcmpname.Width = 200
        '
        'grank
        '
        Me.grank.Caption = "Rank"
        Me.grank.FieldName = "RANK"
        Me.grank.Name = "grank"
        Me.grank.OptionsColumn.AllowEdit = False
        Me.grank.Width = 100
        '
        'gempcode
        '
        Me.gempcode.Caption = "Emp Code"
        Me.gempcode.FieldName = "EMPCODE"
        Me.gempcode.Name = "gempcode"
        Me.gempcode.OptionsColumn.AllowEdit = False
        Me.gempcode.Width = 100
        '
        'gmuino
        '
        Me.gmuino.Caption = "MUI No."
        Me.gmuino.FieldName = "MUINO"
        Me.gmuino.Name = "gmuino"
        Me.gmuino.OptionsColumn.AllowEdit = False
        Me.gmuino.Width = 80
        '
        'GARRIVAL
        '
        Me.GARRIVAL.Caption = "Check In"
        Me.GARRIVAL.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GARRIVAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GARRIVAL.FieldName = "ARRIVAL"
        Me.GARRIVAL.Name = "GARRIVAL"
        Me.GARRIVAL.OptionsColumn.AllowEdit = False
        Me.GARRIVAL.SummaryItem.FieldName = "CLAIMAMT"
        Me.GARRIVAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GARRIVAL.Visible = True
        Me.GARRIVAL.VisibleIndex = 5
        Me.GARRIVAL.Width = 80
        '
        'GDEPARTURE
        '
        Me.GDEPARTURE.Caption = "Check Out"
        Me.GDEPARTURE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDEPARTURE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDEPARTURE.FieldName = "DEPARTURE"
        Me.GDEPARTURE.Name = "GDEPARTURE"
        Me.GDEPARTURE.Visible = True
        Me.GDEPARTURE.VisibleIndex = 6
        Me.GDEPARTURE.Width = 80
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 7
        Me.GAMT.Width = 80
        '
        'GDEPOSIT
        '
        Me.GDEPOSIT.Caption = "Deposit"
        Me.GDEPOSIT.DisplayFormat.FormatString = "0.00"
        Me.GDEPOSIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDEPOSIT.FieldName = "DEPOSIT"
        Me.GDEPOSIT.Name = "GDEPOSIT"
        Me.GDEPOSIT.Visible = True
        Me.GDEPOSIT.VisibleIndex = 8
        Me.GDEPOSIT.Width = 80
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(421, 516)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(507, 516)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(15, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(97, 14)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select a Booking"
        '
        'SelectBookings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1008, 546)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectBookings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Bookings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKCOL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKCOL As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcmpname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gempcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gmuino As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARRIVAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GDEPARTURE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPOSIT As DevExpress.XtraGrid.Columns.GridColumn
End Class
