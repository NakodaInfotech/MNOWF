﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupFilter
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTempName = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.gridbusrefno = New System.Windows.Forms.DataGridView
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkdetails = New System.Windows.Forms.CheckBox
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridbusrefno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(352, 498)
        Me.BlendPanel1.TabIndex = 10
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(25, 402)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 2
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Image = Global.MNOWF.My.Resources.Resources.show_report
        Me.cmdShowReport.Location = New System.Drawing.Point(99, 460)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(76, 29)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(178, 463)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 25)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkdetails)
        Me.GroupBox1.Controls.Add(Me.txtTempName)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.gridbusrefno)
        Me.GroupBox1.Controls.Add(Me.chkall)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(14, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 390)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group"
        '
        'txtTempName
        '
        Me.txtTempName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtTempName.Location = New System.Drawing.Point(275, 44)
        Me.txtTempName.Name = "txtTempName"
        Me.txtTempName.Size = New System.Drawing.Size(44, 22)
        Me.txtTempName.TabIndex = 112
        Me.txtTempName.Visible = False
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtName.Location = New System.Drawing.Point(9, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(310, 22)
        Me.txtName.TabIndex = 1
        '
        'gridbusrefno
        '
        Me.gridbusrefno.AllowUserToAddRows = False
        Me.gridbusrefno.AllowUserToDeleteRows = False
        Me.gridbusrefno.AllowUserToResizeColumns = False
        Me.gridbusrefno.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridbusrefno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridbusrefno.BackgroundColor = System.Drawing.Color.White
        Me.gridbusrefno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridbusrefno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridbusrefno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridbusrefno.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridbusrefno.GridColor = System.Drawing.SystemColors.Control
        Me.gridbusrefno.Location = New System.Drawing.Point(9, 69)
        Me.gridbusrefno.Margin = New System.Windows.Forms.Padding(2)
        Me.gridbusrefno.MultiSelect = False
        Me.gridbusrefno.Name = "gridbusrefno"
        Me.gridbusrefno.ReadOnly = True
        Me.gridbusrefno.RowHeadersVisible = False
        Me.gridbusrefno.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridbusrefno.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridbusrefno.RowTemplate.Height = 20
        Me.gridbusrefno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridbusrefno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridbusrefno.Size = New System.Drawing.Size(310, 316)
        Me.gridbusrefno.TabIndex = 0
        Me.gridbusrefno.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(11, 46)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(77, 18)
        Me.chkall.TabIndex = 1
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 406)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 48)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(208, 19)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(92, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(179, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(70, 19)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(92, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(26, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'chkdetails
        '
        Me.chkdetails.AutoSize = True
        Me.chkdetails.BackColor = System.Drawing.Color.Transparent
        Me.chkdetails.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdetails.Location = New System.Drawing.Point(139, 46)
        Me.chkdetails.Name = "chkdetails"
        Me.chkdetails.Size = New System.Drawing.Size(66, 18)
        Me.chkdetails.TabIndex = 113
        Me.chkdetails.Text = "Details"
        Me.chkdetails.UseVisualStyleBackColor = False
        '
        'GroupFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(352, 498)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "GroupFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Group"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridbusrefno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTempName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents gridbusrefno As System.Windows.Forms.DataGridView
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkdetails As System.Windows.Forms.CheckBox
End Class
