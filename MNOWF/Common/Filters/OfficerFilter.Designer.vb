<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OfficerFilter
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
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CHKCONTRACT = New System.Windows.Forms.CheckBox
        Me.CHKDONATION = New System.Windows.Forms.CheckBox
        Me.CHKCONTRIBUTION = New System.Windows.Forms.CheckBox
        Me.CHKINDIAN = New System.Windows.Forms.CheckBox
        Me.CMBRANK = New System.Windows.Forms.ComboBox
        Me.LBLRANK = New System.Windows.Forms.Label
        Me.CMBCMPNAME = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CHKCONTRACT)
        Me.BlendPanel1.Controls.Add(Me.CHKDONATION)
        Me.BlendPanel1.Controls.Add(Me.CHKCONTRIBUTION)
        Me.BlendPanel1.Controls.Add(Me.CHKINDIAN)
        Me.BlendPanel1.Controls.Add(Me.CMBRANK)
        Me.BlendPanel1.Controls.Add(Me.LBLRANK)
        Me.BlendPanel1.Controls.Add(Me.CMBCMPNAME)
        Me.BlendPanel1.Controls.Add(Me.Label30)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(397, 222)
        Me.BlendPanel1.TabIndex = 9
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(115, 32)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(246, 22)
        Me.CMBNAME.TabIndex = 478
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 479
        Me.Label1.Text = "Officer's Name"
        '
        'CHKCONTRACT
        '
        Me.CHKCONTRACT.AutoSize = True
        Me.CHKCONTRACT.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRACT.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRACT.Location = New System.Drawing.Point(252, 116)
        Me.CHKCONTRACT.Name = "CHKCONTRACT"
        Me.CHKCONTRACT.Size = New System.Drawing.Size(70, 18)
        Me.CHKCONTRACT.TabIndex = 477
        Me.CHKCONTRACT.Text = "Contract"
        Me.CHKCONTRACT.UseVisualStyleBackColor = False
        '
        'CHKDONATION
        '
        Me.CHKDONATION.AutoSize = True
        Me.CHKDONATION.BackColor = System.Drawing.Color.Transparent
        Me.CHKDONATION.ForeColor = System.Drawing.Color.Black
        Me.CHKDONATION.Location = New System.Drawing.Point(252, 140)
        Me.CHKDONATION.Name = "CHKDONATION"
        Me.CHKDONATION.Size = New System.Drawing.Size(106, 18)
        Me.CHKDONATION.TabIndex = 476
        Me.CHKDONATION.Text = "Donation Recd"
        Me.CHKDONATION.UseVisualStyleBackColor = False
        '
        'CHKCONTRIBUTION
        '
        Me.CHKCONTRIBUTION.AutoSize = True
        Me.CHKCONTRIBUTION.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONTRIBUTION.ForeColor = System.Drawing.Color.Black
        Me.CHKCONTRIBUTION.Location = New System.Drawing.Point(111, 140)
        Me.CHKCONTRIBUTION.Name = "CHKCONTRIBUTION"
        Me.CHKCONTRIBUTION.Size = New System.Drawing.Size(123, 18)
        Me.CHKCONTRIBUTION.TabIndex = 475
        Me.CHKCONTRIBUTION.Text = "Contribution Recd"
        Me.CHKCONTRIBUTION.UseVisualStyleBackColor = False
        '
        'CHKINDIAN
        '
        Me.CHKINDIAN.AutoSize = True
        Me.CHKINDIAN.BackColor = System.Drawing.Color.Transparent
        Me.CHKINDIAN.Checked = True
        Me.CHKINDIAN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKINDIAN.ForeColor = System.Drawing.Color.Black
        Me.CHKINDIAN.Location = New System.Drawing.Point(111, 116)
        Me.CHKINDIAN.Name = "CHKINDIAN"
        Me.CHKINDIAN.Size = New System.Drawing.Size(62, 18)
        Me.CHKINDIAN.TabIndex = 474
        Me.CHKINDIAN.Text = "Indian"
        Me.CHKINDIAN.UseVisualStyleBackColor = False
        '
        'CMBRANK
        '
        Me.CMBRANK.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBRANK.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRANK.FormattingEnabled = True
        Me.CMBRANK.Location = New System.Drawing.Point(115, 60)
        Me.CMBRANK.MaxDropDownItems = 14
        Me.CMBRANK.Name = "CMBRANK"
        Me.CMBRANK.Size = New System.Drawing.Size(246, 22)
        Me.CMBRANK.TabIndex = 470
        '
        'LBLRANK
        '
        Me.LBLRANK.AutoSize = True
        Me.LBLRANK.BackColor = System.Drawing.Color.Transparent
        Me.LBLRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRANK.Location = New System.Drawing.Point(79, 64)
        Me.LBLRANK.Name = "LBLRANK"
        Me.LBLRANK.Size = New System.Drawing.Size(34, 14)
        Me.LBLRANK.TabIndex = 471
        Me.LBLRANK.Text = "Rank"
        '
        'CMBCMPNAME
        '
        Me.CMBCMPNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCMPNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCMPNAME.FormattingEnabled = True
        Me.CMBCMPNAME.Items.AddRange(New Object() {""})
        Me.CMBCMPNAME.Location = New System.Drawing.Point(115, 88)
        Me.CMBCMPNAME.Name = "CMBCMPNAME"
        Me.CMBCMPNAME.Size = New System.Drawing.Size(246, 22)
        Me.CMBCMPNAME.TabIndex = 299
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(22, 92)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 14)
        Me.Label30.TabIndex = 300
        Me.Label30.Text = "Company Name"
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Image = Global.MNOWF.My.Resources.Resources.show_report1
        Me.cmdShowReport.Location = New System.Drawing.Point(116, 174)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(86, 31)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(205, 177)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 27)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'OfficerFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(397, 222)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OfficerFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Officer Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents CMBCMPNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CMBRANK As System.Windows.Forms.ComboBox
    Friend WithEvents LBLRANK As System.Windows.Forms.Label
    Friend WithEvents CHKINDIAN As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCONTRACT As System.Windows.Forms.CheckBox
    Friend WithEvents CHKDONATION As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCONTRIBUTION As System.Windows.Forms.CheckBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
