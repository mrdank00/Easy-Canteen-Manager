<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegisterUser
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.txtunits = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ckbreakfast = New System.Windows.Forms.CheckBox()
        Me.cklunch = New System.Windows.Forms.CheckBox()
        Me.ckdinner = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbDept = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStaffid = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 17)
        Me.Label9.TabIndex = 254
        Me.Label9.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(79, 191)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(333, 27)
        Me.txtSearch.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(307, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 17)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Company"
        '
        'cbCompany
        '
        Me.cbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCompany.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Location = New System.Drawing.Point(310, 77)
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(191, 28)
        Me.cbCompany.TabIndex = 251
        '
        'txtunits
        '
        Me.txtunits.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunits.Location = New System.Drawing.Point(174, 140)
        Me.txtunits.Name = "txtunits"
        Me.txtunits.Size = New System.Drawing.Size(114, 27)
        Me.txtunits.TabIndex = 250
        Me.txtunits.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(182, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 17)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Units"
        '
        'txtuserid
        '
        Me.txtuserid.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserid.Location = New System.Drawing.Point(28, 140)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.ReadOnly = True
        Me.txtuserid.Size = New System.Drawing.Size(102, 27)
        Me.txtuserid.TabIndex = 248
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "User ID"
        '
        'txtusername
        '
        Me.txtusername.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(28, 77)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(260, 27)
        Me.txtusername.TabIndex = 243
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 242
        Me.Label1.Text = "User Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "REGISTER USER"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 40)
        Me.Panel1.TabIndex = 241
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 224)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(768, 258)
        Me.DataGridView1.TabIndex = 240
        '
        'ckbreakfast
        '
        Me.ckbreakfast.AutoSize = True
        Me.ckbreakfast.Location = New System.Drawing.Point(513, 147)
        Me.ckbreakfast.Name = "ckbreakfast"
        Me.ckbreakfast.Size = New System.Drawing.Size(71, 17)
        Me.ckbreakfast.TabIndex = 255
        Me.ckbreakfast.Text = "Breakfast"
        Me.ckbreakfast.UseVisualStyleBackColor = True
        '
        'cklunch
        '
        Me.cklunch.AutoSize = True
        Me.cklunch.Checked = True
        Me.cklunch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cklunch.Location = New System.Drawing.Point(634, 147)
        Me.cklunch.Name = "cklunch"
        Me.cklunch.Size = New System.Drawing.Size(56, 17)
        Me.cklunch.TabIndex = 256
        Me.cklunch.Text = "Lunch"
        Me.cklunch.UseVisualStyleBackColor = True
        '
        'ckdinner
        '
        Me.ckdinner.AutoSize = True
        Me.ckdinner.Location = New System.Drawing.Point(749, 147)
        Me.ckdinner.Name = "ckdinner"
        Me.ckdinner.Size = New System.Drawing.Size(57, 17)
        Me.ckdinner.TabIndex = 257
        Me.ckdinner.Text = "Dinner"
        Me.ckdinner.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(510, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 45)
        Me.Button1.TabIndex = 258
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(548, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Department"
        '
        'cbDept
        '
        Me.cbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDept.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDept.FormattingEnabled = True
        Me.cbDept.Location = New System.Drawing.Point(551, 77)
        Me.cbDept.Name = "cbDept"
        Me.cbDept.Size = New System.Drawing.Size(191, 28)
        Me.cbDept.TabIndex = 260
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(307, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "StaffId"
        '
        'txtStaffid
        '
        Me.txtStaffid.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStaffid.Location = New System.Drawing.Point(310, 140)
        Me.txtStaffid.Name = "txtStaffid"
        Me.txtStaffid.Size = New System.Drawing.Size(191, 27)
        Me.txtStaffid.TabIndex = 262
        '
        'frmRegisterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 494)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStaffid)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbDept)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ckdinner)
        Me.Controls.Add(Me.cklunch)
        Me.Controls.Add(Me.ckbreakfast)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbCompany)
        Me.Controls.Add(Me.txtunits)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtuserid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmRegisterUser"
        Me.Text = "frmRegisterUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbCompany As ComboBox
    Friend WithEvents txtunits As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtuserid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtusername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ckbreakfast As CheckBox
    Friend WithEvents cklunch As CheckBox
    Friend WithEvents ckdinner As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cbDept As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtStaffid As TextBox
End Class
