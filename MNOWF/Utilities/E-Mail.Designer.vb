<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_Mail
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmdbrowse = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtsubject = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtattachment = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtmailbody = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbfirstadd = New System.Windows.Forms.ComboBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CHKDEC = New System.Windows.Forms.CheckBox
        Me.CHKDOM = New System.Windows.Forms.CheckBox
        Me.CHKHOSP = New System.Windows.Forms.CheckBox
        Me.CHKEDU = New System.Windows.Forms.CheckBox
        Me.CHKBOOKING = New System.Windows.Forms.CheckBox
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKBOOKING)
        Me.BlendPanel1.Controls.Add(Me.CHKEDU)
        Me.BlendPanel1.Controls.Add(Me.CHKHOSP)
        Me.BlendPanel1.Controls.Add(Me.CHKDOM)
        Me.BlendPanel1.Controls.Add(Me.CHKDEC)
        Me.BlendPanel1.Controls.Add(Me.cmdbrowse)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtsubject)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.txtattachment)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmbfirstadd)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(481, 454)
        Me.BlendPanel1.TabIndex = 0
        '
        'cmdbrowse
        '
        Me.cmdbrowse.Location = New System.Drawing.Point(429, 145)
        Me.cmdbrowse.Name = "cmdbrowse"
        Me.cmdbrowse.Size = New System.Drawing.Size(24, 22)
        Me.cmdbrowse.TabIndex = 3
        Me.cmdbrowse.Text = "..."
        Me.cmdbrowse.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "Attachement"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsubject
        '
        Me.txtsubject.BackColor = System.Drawing.Color.White
        Me.txtsubject.ForeColor = System.Drawing.Color.DimGray
        Me.txtsubject.Location = New System.Drawing.Point(92, 117)
        Me.txtsubject.Name = "txtsubject"
        Me.txtsubject.Size = New System.Drawing.Size(331, 22)
        Me.txtsubject.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Subject"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtattachment
        '
        Me.txtattachment.BackColor = System.Drawing.Color.White
        Me.txtattachment.ForeColor = System.Drawing.Color.DimGray
        Me.txtattachment.Location = New System.Drawing.Point(92, 145)
        Me.txtattachment.Name = "txtattachment"
        Me.txtattachment.Size = New System.Drawing.Size(331, 22)
        Me.txtattachment.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtmailbody)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 248)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(439, 154)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Email - Message (Pls. Type the Message in the Box below)"
        '
        'txtmailbody
        '
        Me.txtmailbody.ForeColor = System.Drawing.Color.DimGray
        Me.txtmailbody.Location = New System.Drawing.Point(8, 18)
        Me.txtmailbody.Multiline = True
        Me.txtmailbody.Name = "txtmailbody"
        Me.txtmailbody.Size = New System.Drawing.Size(425, 128)
        Me.txtmailbody.TabIndex = 0
        Me.txtmailbody.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "From, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MNOWF" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 409)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 1)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmbfirstadd
        '
        Me.cmbfirstadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfirstadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfirstadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfirstadd.FormattingEnabled = True
        Me.cmbfirstadd.Location = New System.Drawing.Point(158, 68)
        Me.cmbfirstadd.MaxDropDownItems = 14
        Me.cmbfirstadd.Name = "cmbfirstadd"
        Me.cmbfirstadd.Size = New System.Drawing.Size(265, 22)
        Me.cmbfirstadd.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Image = Global.MNOWF.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(243, 415)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(69, 27)
        Me.cmdcancel.TabIndex = 6
        Me.cmdcancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 23)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "E-Mail"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.MNOWF.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(168, 412)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(69, 30)
        Me.cmdok.TabIndex = 5
        Me.cmdok.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Email Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Black
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(454, 1)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(82, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "For Example"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "gulkit@bombayitsolutions.com"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CHKDEC
        '
        Me.CHKDEC.AutoSize = True
        Me.CHKDEC.BackColor = System.Drawing.Color.Transparent
        Me.CHKDEC.Location = New System.Drawing.Point(92, 173)
        Me.CHKDEC.Name = "CHKDEC"
        Me.CHKDEC.Size = New System.Drawing.Size(89, 18)
        Me.CHKDEC.TabIndex = 216
        Me.CHKDEC.Text = "Declaration"
        Me.CHKDEC.UseVisualStyleBackColor = False
        '
        'CHKDOM
        '
        Me.CHKDOM.AutoSize = True
        Me.CHKDOM.BackColor = System.Drawing.Color.Transparent
        Me.CHKDOM.Location = New System.Drawing.Point(92, 197)
        Me.CHKDOM.Name = "CHKDOM"
        Me.CHKDOM.Size = New System.Drawing.Size(88, 18)
        Me.CHKDOM.TabIndex = 217
        Me.CHKDOM.Text = "Domiciliary"
        Me.CHKDOM.UseVisualStyleBackColor = False
        '
        'CHKHOSP
        '
        Me.CHKHOSP.AutoSize = True
        Me.CHKHOSP.BackColor = System.Drawing.Color.Transparent
        Me.CHKHOSP.Location = New System.Drawing.Point(92, 221)
        Me.CHKHOSP.Name = "CHKHOSP"
        Me.CHKHOSP.Size = New System.Drawing.Size(111, 18)
        Me.CHKHOSP.TabIndex = 218
        Me.CHKHOSP.Text = "Hospitalisation"
        Me.CHKHOSP.UseVisualStyleBackColor = False
        '
        'CHKEDU
        '
        Me.CHKEDU.AutoSize = True
        Me.CHKEDU.BackColor = System.Drawing.Color.Transparent
        Me.CHKEDU.Location = New System.Drawing.Point(223, 173)
        Me.CHKEDU.Name = "CHKEDU"
        Me.CHKEDU.Size = New System.Drawing.Size(79, 18)
        Me.CHKEDU.TabIndex = 219
        Me.CHKEDU.Text = "Education"
        Me.CHKEDU.UseVisualStyleBackColor = False
        '
        'CHKBOOKING
        '
        Me.CHKBOOKING.AutoSize = True
        Me.CHKBOOKING.BackColor = System.Drawing.Color.Transparent
        Me.CHKBOOKING.Location = New System.Drawing.Point(223, 197)
        Me.CHKBOOKING.Name = "CHKBOOKING"
        Me.CHKBOOKING.Size = New System.Drawing.Size(109, 18)
        Me.CHKBOOKING.TabIndex = 220
        Me.CHKBOOKING.Text = "Holiday Homes"
        Me.CHKBOOKING.UseVisualStyleBackColor = False
        '
        'E_Mail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(481, 454)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "E_Mail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "EMail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmailbody As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbfirstadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtattachment As System.Windows.Forms.TextBox
    Friend WithEvents txtsubject As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdbrowse As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CHKBOOKING As System.Windows.Forms.CheckBox
    Friend WithEvents CHKEDU As System.Windows.Forms.CheckBox
    Friend WithEvents CHKHOSP As System.Windows.Forms.CheckBox
    Friend WithEvents CHKDOM As System.Windows.Forms.CheckBox
    Friend WithEvents CHKDEC As System.Windows.Forms.CheckBox
End Class
