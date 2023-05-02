Imports System.Data.SqlClient
Public Class frmlogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If

        cmd = New SqlCommand("select * from userprofiles where password = '" + TextBox1.Text + "'", Poscon)
        da = New SqlDataAdapter(cmd)
        tbl = New DataTable()
        tbl.Rows.Clear()
        da.Fill(tbl)
        If tbl.Rows.Count() = 1 Then
            Form1.MenuStrip1.Enabled = True
            Me.Hide()
        Else
            MsgBox("Wrong Password")
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If

    End Sub
End Class