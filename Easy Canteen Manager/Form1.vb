Public Class Form1
    Private Sub RegisterUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterUserToolStripMenuItem.Click
        OpenForm(GetType(frmRegisterUser))
    End Sub
    Private Sub OpenForm(ByVal formType As Type)
        Dim openForm As Form = Nothing
        For Each childForm As Form In MdiChildren
            If childForm.GetType() Is formType Then
                openForm = childForm
                Exit For
            End If
        Next

        If openForm Is Nothing Then
            openForm = Activator.CreateInstance(formType)
            openForm.MdiParent = Me
            openForm.WindowState = FormWindowState.Maximized
            openForm.StartPosition = FormStartPosition.CenterParent
            openForm.Show()

        Else
            openForm.Activate()
        End If
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        OpenForm(GetType(frmReports))
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Enabled = False
        OpenForm(GetType(frmlogin))
    End Sub

    Private Sub ImportExportDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportExportDataToolStripMenuItem.Click
        OpenForm(GetType(frmDataTransfer))
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        OpenForm(GetType(frmUploadData))
    End Sub
End Class
