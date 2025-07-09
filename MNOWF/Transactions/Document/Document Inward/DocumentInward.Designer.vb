<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentInward
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentInward))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CMBINMODE = New System.Windows.Forms.ComboBox
        Me.TXTNO = New System.Windows.Forms.TextBox
        Me.CMBUSER = New System.Windows.Forms.ComboBox
        Me.DOCDATE = New System.Windows.Forms.DateTimePicker
        Me.RECDATE = New System.Windows.Forms.DateTimePicker
        Me.GRIDINWARD = New System.Windows.Forms.DataGridView
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRECDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDOCTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GINMODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSENTBY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDOCDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRECDBY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDOCSUSED = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDONE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.TXTINWARD = New System.Windows.Forms.TextBox
        Me.CMBSENTBY = New System.Windows.Forms.ComboBox
        Me.CMBDOCTYPE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GRIDINWARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1022, 546)
        Me.BlendPanel1.TabIndex = 0
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(86, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 2
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1022, 25)
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
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.CMDEXIT.Location = New System.Drawing.Point(463, 519)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(69, 25)
        Me.CMDEXIT.TabIndex = 1
        Me.CMDEXIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CMBINMODE)
        Me.GroupBox3.Controls.Add(Me.TXTNO)
        Me.GroupBox3.Controls.Add(Me.CMBUSER)
        Me.GroupBox3.Controls.Add(Me.DOCDATE)
        Me.GroupBox3.Controls.Add(Me.RECDATE)
        Me.GroupBox3.Controls.Add(Me.GRIDINWARD)
        Me.GroupBox3.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox3.Controls.Add(Me.TXTINWARD)
        Me.GroupBox3.Controls.Add(Me.CMBSENTBY)
        Me.GroupBox3.Controls.Add(Me.CMBDOCTYPE)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1006, 448)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'CMBINMODE
        '
        Me.CMBINMODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBINMODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBINMODE.FormattingEnabled = True
        Me.CMBINMODE.Location = New System.Drawing.Point(244, 14)
        Me.CMBINMODE.Name = "CMBINMODE"
        Me.CMBINMODE.Size = New System.Drawing.Size(100, 22)
        Me.CMBINMODE.TabIndex = 3
        '
        'TXTNO
        '
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.Location = New System.Drawing.Point(544, 14)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTNO.TabIndex = 6
        Me.TXTNO.Text = "1"
        Me.TXTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Location = New System.Drawing.Point(854, 14)
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(90, 22)
        Me.CMBUSER.TabIndex = 8
        '
        'DOCDATE
        '
        Me.DOCDATE.CustomFormat = "dd/MM/yyyy"
        Me.DOCDATE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.DOCDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOCDATE.Location = New System.Drawing.Point(464, 14)
        Me.DOCDATE.Name = "DOCDATE"
        Me.DOCDATE.Size = New System.Drawing.Size(80, 22)
        Me.DOCDATE.TabIndex = 5
        '
        'RECDATE
        '
        Me.RECDATE.CustomFormat = "dd/MM/yyyy"
        Me.RECDATE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.RECDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RECDATE.Location = New System.Drawing.Point(44, 14)
        Me.RECDATE.Name = "RECDATE"
        Me.RECDATE.Size = New System.Drawing.Size(80, 22)
        Me.RECDATE.TabIndex = 1
        '
        'GRIDINWARD
        '
        Me.GRIDINWARD.AllowUserToAddRows = False
        Me.GRIDINWARD.AllowUserToDeleteRows = False
        Me.GRIDINWARD.AllowUserToResizeColumns = False
        Me.GRIDINWARD.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDINWARD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDINWARD.BackgroundColor = System.Drawing.Color.White
        Me.GRIDINWARD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDINWARD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDINWARD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDINWARD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDINWARD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GRECDATE, Me.GDOCTYPE, Me.GINMODE, Me.GSENTBY, Me.GDOCDATE, Me.GNO, Me.GREMARKS, Me.GRECDBY, Me.GDOCSUSED, Me.GDONE})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDINWARD.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDINWARD.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDINWARD.Location = New System.Drawing.Point(4, 37)
        Me.GRIDINWARD.MultiSelect = False
        Me.GRIDINWARD.Name = "GRIDINWARD"
        Me.GRIDINWARD.ReadOnly = True
        Me.GRIDINWARD.RowHeadersVisible = False
        Me.GRIDINWARD.RowHeadersWidth = 30
        Me.GRIDINWARD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDINWARD.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDINWARD.RowTemplate.Height = 20
        Me.GRIDINWARD.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDINWARD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDINWARD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDINWARD.Size = New System.Drawing.Size(997, 408)
        Me.GRIDINWARD.TabIndex = 9
        Me.GRIDINWARD.TabStop = False
        '
        'gsrno
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gsrno.DefaultCellStyle = DataGridViewCellStyle3
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 40
        '
        'GRECDATE
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GRECDATE.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRECDATE.HeaderText = "Rec Date"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.ReadOnly = True
        Me.GRECDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRECDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRECDATE.Width = 80
        '
        'GDOCTYPE
        '
        Me.GDOCTYPE.HeaderText = "Doc Type"
        Me.GDOCTYPE.Name = "GDOCTYPE"
        Me.GDOCTYPE.ReadOnly = True
        Me.GDOCTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDOCTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDOCTYPE.Width = 120
        '
        'GINMODE
        '
        Me.GINMODE.HeaderText = "In-Mode"
        Me.GINMODE.Name = "GINMODE"
        Me.GINMODE.ReadOnly = True
        '
        'GSENTBY
        '
        Me.GSENTBY.HeaderText = "Doc Sent By"
        Me.GSENTBY.Name = "GSENTBY"
        Me.GSENTBY.ReadOnly = True
        Me.GSENTBY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSENTBY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSENTBY.Width = 120
        '
        'GDOCDATE
        '
        Me.GDOCDATE.HeaderText = "Doc Date"
        Me.GDOCDATE.Name = "GDOCDATE"
        Me.GDOCDATE.ReadOnly = True
        Me.GDOCDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDOCDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDOCDATE.Width = 80
        '
        'GNO
        '
        Me.GNO.HeaderText = "No"
        Me.GNO.Name = "GNO"
        Me.GNO.ReadOnly = True
        Me.GNO.Width = 40
        '
        'GREMARKS
        '
        Me.GREMARKS.HeaderText = "Remarks"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.ReadOnly = True
        Me.GREMARKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREMARKS.Width = 270
        '
        'GRECDBY
        '
        Me.GRECDBY.HeaderText = "Recd By"
        Me.GRECDBY.Name = "GRECDBY"
        Me.GRECDBY.ReadOnly = True
        Me.GRECDBY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRECDBY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRECDBY.Width = 90
        '
        'GDOCSUSED
        '
        Me.GDOCSUSED.HeaderText = "Used"
        Me.GDOCSUSED.Name = "GDOCSUSED"
        Me.GDOCSUSED.ReadOnly = True
        Me.GDOCSUSED.Width = 30
        '
        'GDONE
        '
        Me.GDONE.HeaderText = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.ReadOnly = True
        Me.GDONE.Visible = False
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREMARKS.Location = New System.Drawing.Point(584, 14)
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(270, 22)
        Me.TXTREMARKS.TabIndex = 7
        '
        'TXTINWARD
        '
        Me.TXTINWARD.BackColor = System.Drawing.Color.Linen
        Me.TXTINWARD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINWARD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTINWARD.Location = New System.Drawing.Point(4, 14)
        Me.TXTINWARD.Name = "TXTINWARD"
        Me.TXTINWARD.ReadOnly = True
        Me.TXTINWARD.Size = New System.Drawing.Size(40, 22)
        Me.TXTINWARD.TabIndex = 0
        Me.TXTINWARD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBSENTBY
        '
        Me.CMBSENTBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSENTBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSENTBY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSENTBY.FormattingEnabled = True
        Me.CMBSENTBY.Location = New System.Drawing.Point(344, 14)
        Me.CMBSENTBY.Name = "CMBSENTBY"
        Me.CMBSENTBY.Size = New System.Drawing.Size(120, 22)
        Me.CMBSENTBY.TabIndex = 4
        '
        'CMBDOCTYPE
        '
        Me.CMBDOCTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDOCTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDOCTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDOCTYPE.DropDownWidth = 400
        Me.CMBDOCTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDOCTYPE.FormattingEnabled = True
        Me.CMBDOCTYPE.Location = New System.Drawing.Point(124, 14)
        Me.CMBDOCTYPE.Name = "CMBDOCTYPE"
        Me.CMBDOCTYPE.Size = New System.Drawing.Size(120, 22)
        Me.CMBDOCTYPE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 26)
        Me.Label2.TabIndex = 210
        Me.Label2.Text = "Document Inward"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'DocumentInward
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1022, 546)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DocumentInward"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Document Inward"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GRIDINWARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GRIDINWARD As System.Windows.Forms.DataGridView
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents CMBSENTBY As System.Windows.Forms.ComboBox
    Friend WithEvents CMBDOCTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTINWARD As System.Windows.Forms.TextBox
    Friend WithEvents RECDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DOCDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMBUSER As System.Windows.Forms.ComboBox
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBINMODE As System.Windows.Forms.ComboBox
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRECDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDOCTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GINMODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSENTBY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDOCDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRECDBY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDOCSUSED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDONE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
