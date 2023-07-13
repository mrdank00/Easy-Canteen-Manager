<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportExportDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MealEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem, Me.RegisterUserToolStripMenuItem, Me.MealEntriesToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ImportExportDataToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(927, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.LoginToolStripMenuItem.Text = "Exit"
        '
        'RegisterUserToolStripMenuItem
        '
        Me.RegisterUserToolStripMenuItem.Name = "RegisterUserToolStripMenuItem"
        Me.RegisterUserToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.RegisterUserToolStripMenuItem.Text = "Register User"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ImportExportDataToolStripMenuItem
        '
        Me.ImportExportDataToolStripMenuItem.Name = "ImportExportDataToolStripMenuItem"
        Me.ImportExportDataToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ImportExportDataToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'MealEntriesToolStripMenuItem
        '
        Me.MealEntriesToolStripMenuItem.Name = "MealEntriesToolStripMenuItem"
        Me.MealEntriesToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.MealEntriesToolStripMenuItem.Text = "Meal Entries"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 496)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Canteen Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RegisterUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportExportDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MealEntriesToolStripMenuItem As ToolStripMenuItem
End Class
