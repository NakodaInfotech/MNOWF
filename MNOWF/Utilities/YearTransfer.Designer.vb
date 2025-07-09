<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearTransfer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GRIDYEAR = New System.Windows.Forms.DataGridView()
        Me.GYEAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GYEARID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl = New System.Windows.Forms.Label()
        Me.CHKMASTER = New System.Windows.Forms.CheckBox()
        Me.CHKDATA = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKDATA)
        Me.BlendPanel1.Controls.Add(Me.CHKMASTER)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDYEAR)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(534, 354)
        Me.BlendPanel1.TabIndex = 17
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(90, 316)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(71, 26)
        Me.CMDOK.TabIndex = 184
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(167, 316)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(71, 26)
        Me.CMDEXIT.TabIndex = 183
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'GRIDYEAR
        '
        Me.GRIDYEAR.AllowUserToAddRows = False
        Me.GRIDYEAR.AllowUserToDeleteRows = False
        Me.GRIDYEAR.AllowUserToResizeColumns = False
        Me.GRIDYEAR.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDYEAR.BackgroundColor = System.Drawing.Color.White
        Me.GRIDYEAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDYEAR.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GRIDYEAR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDYEAR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDYEAR.ColumnHeadersHeight = 22
        Me.GRIDYEAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDYEAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GYEAR, Me.GYEARID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDYEAR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDYEAR.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDYEAR.Location = New System.Drawing.Point(23, 38)
        Me.GRIDYEAR.MultiSelect = False
        Me.GRIDYEAR.Name = "GRIDYEAR"
        Me.GRIDYEAR.RowHeadersVisible = False
        Me.GRIDYEAR.RowHeadersWidth = 30
        Me.GRIDYEAR.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDYEAR.RowTemplate.Height = 20
        Me.GRIDYEAR.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDYEAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDYEAR.Size = New System.Drawing.Size(283, 271)
        Me.GRIDYEAR.TabIndex = 18
        '
        'GYEAR
        '
        Me.GYEAR.HeaderText = "Year "
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.Width = 250
        '
        'GYEARID
        '
        Me.GYEARID.HeaderText = "YEARID"
        Me.GYEARID.Name = "GYEARID"
        Me.GYEARID.Visible = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(20, 11)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(248, 14)
        Me.lbl.TabIndex = 182
        Me.lbl.Text = "Select Accounting Year To Transfer Data From"
        '
        'CHKMASTER
        '
        Me.CHKMASTER.AutoSize = True
        Me.CHKMASTER.BackColor = System.Drawing.Color.Transparent
        Me.CHKMASTER.Checked = True
        Me.CHKMASTER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKMASTER.Location = New System.Drawing.Point(312, 38)
        Me.CHKMASTER.Name = "CHKMASTER"
        Me.CHKMASTER.Size = New System.Drawing.Size(113, 19)
        Me.CHKMASTER.TabIndex = 185
        Me.CHKMASTER.Text = "Transfer Master"
        Me.CHKMASTER.UseVisualStyleBackColor = False
        '
        'CHKDATA
        '
        Me.CHKDATA.AutoSize = True
        Me.CHKDATA.BackColor = System.Drawing.Color.Transparent
        Me.CHKDATA.Checked = True
        Me.CHKDATA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKDATA.Location = New System.Drawing.Point(312, 63)
        Me.CHKDATA.Name = "CHKDATA"
        Me.CHKDATA.Size = New System.Drawing.Size(100, 19)
        Me.CHKDATA.TabIndex = 186
        Me.CHKDATA.Text = "Transfer Data"
        Me.CHKDATA.UseVisualStyleBackColor = False
        '
        'YearTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(534, 354)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YearTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "YearTransfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GRIDYEAR As System.Windows.Forms.DataGridView
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GYEAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GYEARID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHKDATA As CheckBox
    Friend WithEvents CHKMASTER As CheckBox
End Class
