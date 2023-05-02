<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbItemname = New System.Windows.Forms.ComboBox()
        Me.dpdatefrom = New System.Windows.Forms.DateTimePicker()
        Me.dpdateto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbShopname = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(896, 40)
        Me.Panel1.TabIndex = 247
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(50, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Meal Reports"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(103, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 246
        Me.Label5.Text = "Pick a Meal"
        Me.Label5.Visible = False
        '
        'cbItemname
        '
        Me.cbItemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbItemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbItemname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbItemname.FormattingEnabled = True
        Me.cbItemname.Location = New System.Drawing.Point(276, 165)
        Me.cbItemname.Name = "cbItemname"
        Me.cbItemname.Size = New System.Drawing.Size(401, 29)
        Me.cbItemname.TabIndex = 245
        Me.cbItemname.Visible = False
        '
        'dpdatefrom
        '
        Me.dpdatefrom.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpdatefrom.Location = New System.Drawing.Point(276, 79)
        Me.dpdatefrom.Name = "dpdatefrom"
        Me.dpdatefrom.Size = New System.Drawing.Size(180, 27)
        Me.dpdatefrom.TabIndex = 244
        Me.dpdatefrom.Value = New Date(2022, 1, 12, 0, 0, 0, 0)
        '
        'dpdateto
        '
        Me.dpdateto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpdateto.Location = New System.Drawing.Point(497, 79)
        Me.dpdateto.Name = "dpdateto"
        Me.dpdateto.Size = New System.Drawing.Size(180, 27)
        Me.dpdateto.TabIndex = 243
        Me.dpdateto.Value = New Date(2022, 1, 12, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(103, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Pick a Company"
        '
        'cbShopname
        '
        Me.cbShopname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbShopname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbShopname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShopname.FormattingEnabled = True
        Me.cbShopname.Location = New System.Drawing.Point(276, 121)
        Me.cbShopname.Name = "cbShopname"
        Me.cbShopname.Size = New System.Drawing.Size(401, 29)
        Me.cbShopname.TabIndex = 250
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(466, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 20)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "From"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(322, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(259, 36)
        Me.Button1.TabIndex = 252
        Me.Button1.Text = "Meal per Company"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(41, 267)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(259, 37)
        Me.Button2.TabIndex = 253
        Me.Button2.Text = "Meal per Location"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(41, 383)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(259, 34)
        Me.Button3.TabIndex = 254
        Me.Button3.Text = "Meal per Type Roll"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(615, 385)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(259, 34)
        Me.Button4.TabIndex = 255
        Me.Button4.Text = "Meal per Date"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(41, 319)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(259, 37)
        Me.Button5.TabIndex = 256
        Me.Button5.Text = "Meal per Location Summary"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(322, 319)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(259, 37)
        Me.Button6.TabIndex = 258
        Me.Button6.Text = "Meal per Date Summary"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(322, 267)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(259, 37)
        Me.Button7.TabIndex = 257
        Me.Button7.Text = "Meal per Date"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(615, 319)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(259, 37)
        Me.Button8.TabIndex = 260
        Me.Button8.Text = "Meal per Staff Summary"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(615, 267)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(259, 37)
        Me.Button9.TabIndex = 259
        Me.Button9.Text = "Meal per Staff"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 550)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbItemname)
        Me.Controls.Add(Me.dpdatefrom)
        Me.Controls.Add(Me.dpdateto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbShopname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmReports"
        Me.Text = "frmReports"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbItemname As ComboBox
    Friend WithEvents dpdatefrom As DateTimePicker
    Friend WithEvents dpdateto As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents cbShopname As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
End Class
