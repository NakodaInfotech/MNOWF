<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Refund
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Refund))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TXTACNAME = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TXTBANK = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TXTBRANCH = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TXTACNO = New System.Windows.Forms.TextBox
        Me.TXTBANKADD = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.PBPAID = New System.Windows.Forms.PictureBox
        Me.PBlock = New System.Windows.Forms.PictureBox
        Me.lbllocked = New System.Windows.Forms.Label
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button
        Me.TXTEXTRAAMT = New System.Windows.Forms.TextBox
        Me.TXTBALANCE = New System.Windows.Forms.TextBox
        Me.TXTRETURN = New System.Windows.Forms.TextBox
        Me.TXTAMTREC = New System.Windows.Forms.TextBox
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.TXTREFUND = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTOFFICERNAME = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTMUINO = New System.Windows.Forms.TextBox
        Me.TXTCMPNAME = New System.Windows.Forms.TextBox
        Me.TXTRANK = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.LBLRANK = New System.Windows.Forms.Label
        Me.TXTEMPCODE = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTDEPOSIT = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TXTAMT = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TXTREFUNDNO = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.REFUNDDATE = New System.Windows.Forms.DateTimePicker
        Me.cmdselectdoc = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PBPAID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.PBPAID)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRAAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTBALANCE)
        Me.BlendPanel1.Controls.Add(Me.TXTRETURN)
        Me.BlendPanel1.Controls.Add(Me.TXTAMTREC)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.TXTREFUND)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTOFFICERNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTMUINO)
        Me.BlendPanel1.Controls.Add(Me.TXTCMPNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTRANK)
        Me.BlendPanel1.Controls.Add(Me.Label30)
        Me.BlendPanel1.Controls.Add(Me.LBLRANK)
        Me.BlendPanel1.Controls.Add(Me.TXTEMPCODE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTDEPOSIT)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.TXTAMT)
        Me.BlendPanel1.Controls.Add(Me.Label19)
        Me.BlendPanel1.Controls.Add(Me.TXTREFUNDNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTBOOKINGNO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.REFUNDDATE)
        Me.BlendPanel1.Controls.Add(Me.cmdselectdoc)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(527, 437)
        Me.BlendPanel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TXTACNAME)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.TXTBANK)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TXTBRANCH)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.TXTACNO)
        Me.GroupBox2.Controls.Add(Me.TXTBANKADD)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(22, 255)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 123)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Officers' Bank Details"
        '
        'TXTACNAME
        '
        Me.TXTACNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTACNAME.Location = New System.Drawing.Point(109, 21)
        Me.TXTACNAME.Name = "TXTACNAME"
        Me.TXTACNAME.Size = New System.Drawing.Size(206, 22)
        Me.TXTACNAME.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(3, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(106, 14)
        Me.Label27.TabIndex = 502
        Me.Label27.Text = "A/C Holders Name"
        '
        'TXTBANK
        '
        Me.TXTBANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBANK.ForeColor = System.Drawing.Color.Black
        Me.TXTBANK.Location = New System.Drawing.Point(109, 46)
        Me.TXTBANK.Name = "TXTBANK"
        Me.TXTBANK.Size = New System.Drawing.Size(206, 22)
        Me.TXTBANK.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(40, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 14)
        Me.Label17.TabIndex = 493
        Me.Label17.Text = "Bank Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(323, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 495
        Me.Label18.Text = "Branch"
        '
        'TXTBRANCH
        '
        Me.TXTBRANCH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBRANCH.ForeColor = System.Drawing.Color.Black
        Me.TXTBRANCH.Location = New System.Drawing.Point(369, 46)
        Me.TXTBRANCH.Name = "TXTBRANCH"
        Me.TXTBRANCH.Size = New System.Drawing.Size(107, 22)
        Me.TXTBRANCH.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(322, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 14)
        Me.Label20.TabIndex = 498
        Me.Label20.Text = "A/C No."
        '
        'TXTACNO
        '
        Me.TXTACNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACNO.ForeColor = System.Drawing.Color.Black
        Me.TXTACNO.Location = New System.Drawing.Point(369, 21)
        Me.TXTACNO.Name = "TXTACNO"
        Me.TXTACNO.Size = New System.Drawing.Size(107, 22)
        Me.TXTACNO.TabIndex = 1
        Me.TXTACNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTBANKADD
        '
        Me.TXTBANKADD.BackColor = System.Drawing.SystemColors.Window
        Me.TXTBANKADD.ForeColor = System.Drawing.Color.Black
        Me.TXTBANKADD.Location = New System.Drawing.Point(109, 72)
        Me.TXTBANKADD.Multiline = True
        Me.TXTBANKADD.Name = "TXTBANKADD"
        Me.TXTBANKADD.Size = New System.Drawing.Size(367, 46)
        Me.TXTBANKADD.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(28, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 14)
        Me.Label21.TabIndex = 500
        Me.Label21.Text = "Bank Address"
        '
        'PBPAID
        '
        Me.PBPAID.BackColor = System.Drawing.Color.Transparent
        Me.PBPAID.Image = Global.MNOWF.My.Resources.Resources.paid
        Me.PBPAID.Location = New System.Drawing.Point(305, 169)
        Me.PBPAID.Name = "PBPAID"
        Me.PBPAID.Size = New System.Drawing.Size(60, 50)
        Me.PBPAID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPAID.TabIndex = 704
        Me.PBPAID.TabStop = False
        Me.PBPAID.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.MNOWF.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(366, 169)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(50, 50)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 703
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(417, 197)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 702
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(94, 396)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(80, 28)
        Me.CMDSHOWDETAILS.TabIndex = 8
        Me.CMDSHOWDETAILS.Text = "S&how Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'TXTEXTRAAMT
        '
        Me.TXTEXTRAAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEXTRAAMT.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRAAMT.Location = New System.Drawing.Point(398, 20)
        Me.TXTEXTRAAMT.Name = "TXTEXTRAAMT"
        Me.TXTEXTRAAMT.Size = New System.Drawing.Size(29, 21)
        Me.TXTEXTRAAMT.TabIndex = 700
        Me.TXTEXTRAAMT.TabStop = False
        Me.TXTEXTRAAMT.Visible = False
        '
        'TXTBALANCE
        '
        Me.TXTBALANCE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBALANCE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALANCE.Location = New System.Drawing.Point(368, 20)
        Me.TXTBALANCE.Name = "TXTBALANCE"
        Me.TXTBALANCE.Size = New System.Drawing.Size(29, 21)
        Me.TXTBALANCE.TabIndex = 699
        Me.TXTBALANCE.TabStop = False
        Me.TXTBALANCE.Visible = False
        '
        'TXTRETURN
        '
        Me.TXTRETURN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRETURN.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRETURN.Location = New System.Drawing.Point(338, 20)
        Me.TXTRETURN.Name = "TXTRETURN"
        Me.TXTRETURN.Size = New System.Drawing.Size(29, 21)
        Me.TXTRETURN.TabIndex = 698
        Me.TXTRETURN.TabStop = False
        Me.TXTRETURN.Visible = False
        '
        'TXTAMTREC
        '
        Me.TXTAMTREC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAMTREC.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMTREC.Location = New System.Drawing.Point(307, 20)
        Me.TXTAMTREC.Name = "TXTAMTREC"
        Me.TXTAMTREC.Size = New System.Drawing.Size(29, 21)
        Me.TXTAMTREC.TabIndex = 697
        Me.TXTAMTREC.TabStop = False
        Me.TXTAMTREC.Visible = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(123, 18)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 696
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'TXTREFUND
        '
        Me.TXTREFUND.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREFUND.Location = New System.Drawing.Point(305, 222)
        Me.TXTREFUND.Name = "TXTREFUND"
        Me.TXTREFUND.Size = New System.Drawing.Size(116, 22)
        Me.TXTREFUND.TabIndex = 2
        Me.TXTREFUND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(258, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 14)
        Me.Label6.TabIndex = 695
        Me.Label6.Text = "Refund"
        '
        'TXTOFFICERNAME
        '
        Me.TXTOFFICERNAME.BackColor = System.Drawing.Color.Pink
        Me.TXTOFFICERNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOFFICERNAME.Location = New System.Drawing.Point(126, 97)
        Me.TXTOFFICERNAME.Name = "TXTOFFICERNAME"
        Me.TXTOFFICERNAME.ReadOnly = True
        Me.TXTOFFICERNAME.Size = New System.Drawing.Size(295, 22)
        Me.TXTOFFICERNAME.TabIndex = 693
        Me.TXTOFFICERNAME.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(78, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 692
        Me.Label2.Text = "MUI No"
        '
        'TXTMUINO
        '
        Me.TXTMUINO.BackColor = System.Drawing.Color.Pink
        Me.TXTMUINO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMUINO.Location = New System.Drawing.Point(126, 172)
        Me.TXTMUINO.Name = "TXTMUINO"
        Me.TXTMUINO.ReadOnly = True
        Me.TXTMUINO.Size = New System.Drawing.Size(112, 22)
        Me.TXTMUINO.TabIndex = 687
        Me.TXTMUINO.TabStop = False
        Me.TXTMUINO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCMPNAME
        '
        Me.TXTCMPNAME.BackColor = System.Drawing.Color.Pink
        Me.TXTCMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCMPNAME.Location = New System.Drawing.Point(126, 122)
        Me.TXTCMPNAME.Name = "TXTCMPNAME"
        Me.TXTCMPNAME.ReadOnly = True
        Me.TXTCMPNAME.Size = New System.Drawing.Size(295, 22)
        Me.TXTCMPNAME.TabIndex = 684
        Me.TXTCMPNAME.TabStop = False
        '
        'TXTRANK
        '
        Me.TXTRANK.BackColor = System.Drawing.Color.Pink
        Me.TXTRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRANK.Location = New System.Drawing.Point(126, 147)
        Me.TXTRANK.Name = "TXTRANK"
        Me.TXTRANK.ReadOnly = True
        Me.TXTRANK.Size = New System.Drawing.Size(112, 22)
        Me.TXTRANK.TabIndex = 685
        Me.TXTRANK.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(34, 126)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 14)
        Me.Label30.TabIndex = 691
        Me.Label30.Text = "Company Name"
        '
        'LBLRANK
        '
        Me.LBLRANK.AutoSize = True
        Me.LBLRANK.BackColor = System.Drawing.Color.Transparent
        Me.LBLRANK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRANK.Location = New System.Drawing.Point(91, 151)
        Me.LBLRANK.Name = "LBLRANK"
        Me.LBLRANK.Size = New System.Drawing.Size(34, 14)
        Me.LBLRANK.TabIndex = 690
        Me.LBLRANK.Text = "Rank"
        '
        'TXTEMPCODE
        '
        Me.TXTEMPCODE.BackColor = System.Drawing.Color.Pink
        Me.TXTEMPCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMPCODE.Location = New System.Drawing.Point(305, 147)
        Me.TXTEMPCODE.Name = "TXTEMPCODE"
        Me.TXTEMPCODE.ReadOnly = True
        Me.TXTEMPCODE.Size = New System.Drawing.Size(116, 22)
        Me.TXTEMPCODE.TabIndex = 686
        Me.TXTEMPCODE.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 14)
        Me.Label3.TabIndex = 688
        Me.Label3.Text = "Officers' Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(244, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 689
        Me.Label5.Text = "Emp Code"
        '
        'TXTDEPOSIT
        '
        Me.TXTDEPOSIT.BackColor = System.Drawing.Color.Pink
        Me.TXTDEPOSIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEPOSIT.Location = New System.Drawing.Point(126, 222)
        Me.TXTDEPOSIT.Name = "TXTDEPOSIT"
        Me.TXTDEPOSIT.ReadOnly = True
        Me.TXTDEPOSIT.Size = New System.Drawing.Size(112, 22)
        Me.TXTDEPOSIT.TabIndex = 681
        Me.TXTDEPOSIT.TabStop = False
        Me.TXTDEPOSIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(51, 226)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 14)
        Me.Label23.TabIndex = 683
        Me.Label23.Text = "Deposit Amt"
        '
        'TXTAMT
        '
        Me.TXTAMT.BackColor = System.Drawing.Color.Pink
        Me.TXTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMT.Location = New System.Drawing.Point(126, 197)
        Me.TXTAMT.Name = "TXTAMT"
        Me.TXTAMT.ReadOnly = True
        Me.TXTAMT.Size = New System.Drawing.Size(112, 22)
        Me.TXTAMT.TabIndex = 680
        Me.TXTAMT.TabStop = False
        Me.TXTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(66, 201)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 14)
        Me.Label19.TabIndex = 682
        Me.Label19.Text = "TotaL Amt"
        '
        'TXTREFUNDNO
        '
        Me.TXTREFUNDNO.BackColor = System.Drawing.Color.Pink
        Me.TXTREFUNDNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREFUNDNO.Location = New System.Drawing.Point(126, 47)
        Me.TXTREFUNDNO.Name = "TXTREFUNDNO"
        Me.TXTREFUNDNO.ReadOnly = True
        Me.TXTREFUNDNO.Size = New System.Drawing.Size(112, 22)
        Me.TXTREFUNDNO.TabIndex = 646
        Me.TXTREFUNDNO.TabStop = False
        Me.TXTREFUNDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(87, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 647
        Me.Label1.Text = "Sr No."
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Pink
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(126, 72)
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.ReadOnly = True
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(112, 22)
        Me.TXTBOOKINGNO.TabIndex = 643
        Me.TXTBOOKINGNO.TabStop = False
        Me.TXTBOOKINGNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(53, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 14)
        Me.Label4.TabIndex = 645
        Me.Label4.Text = "Booking No."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(257, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 14)
        Me.Label14.TabIndex = 644
        Me.Label14.Text = "Refund Date"
        '
        'REFUNDDATE
        '
        Me.REFUNDDATE.CustomFormat = "dd/MM/yyyy"
        Me.REFUNDDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.REFUNDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.REFUNDDATE.Location = New System.Drawing.Point(334, 47)
        Me.REFUNDDATE.Name = "REFUNDDATE"
        Me.REFUNDDATE.Size = New System.Drawing.Size(87, 22)
        Me.REFUNDDATE.TabIndex = 0
        '
        'cmdselectdoc
        '
        Me.cmdselectdoc.BackColor = System.Drawing.Color.Transparent
        Me.cmdselectdoc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdselectdoc.FlatAppearance.BorderSize = 0
        Me.cmdselectdoc.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdselectdoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdselectdoc.Location = New System.Drawing.Point(8, 396)
        Me.cmdselectdoc.Name = "cmdselectdoc"
        Me.cmdselectdoc.Size = New System.Drawing.Size(80, 28)
        Me.cmdselectdoc.TabIndex = 1
        Me.cmdselectdoc.Text = "S&elect Book"
        Me.cmdselectdoc.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(266, 397)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 5
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(352, 397)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 6
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(438, 396)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(180, 396)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(80, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Refund"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 285
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
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
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
        Me.ToolStripdelete.Text = "&Delete Journal"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.MNOWF.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.MNOWF.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 0
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'Refund
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(527, 462)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "Refund"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Refund"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PBPAID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents cmdselectdoc As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents TXTREFUNDNO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents REFUNDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTDEPOSIT As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TXTOFFICERNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTMUINO As System.Windows.Forms.TextBox
    Friend WithEvents TXTCMPNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTRANK As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents LBLRANK As System.Windows.Forms.Label
    Friend WithEvents TXTEMPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTREFUND As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents TXTEXTRAAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTBALANCE As System.Windows.Forms.TextBox
    Friend WithEvents TXTRETURN As System.Windows.Forms.TextBox
    Friend WithEvents TXTAMTREC As System.Windows.Forms.TextBox
    Friend WithEvents PBPAID As System.Windows.Forms.PictureBox
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTACNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TXTBANK As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXTBRANCH As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TXTACNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTBANKADD As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
