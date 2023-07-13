Imports System.Data.SqlClient
Public Class frmMealEntry
    Private Sub frmMealEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load("select username from mealmast")
        loc()
    End Sub

    Public Sub FillGoods(valueTosearch As String, e As KeyEventArgs)
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("kindly select a meal")
            Exit Sub
        End If
        Try

            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As String = "SELECT * FROM mealmast WHERE username = @StaffName or userid like @staffname"
            Dim cmd As New SqlCommand(query, Poscon)
            cmd.Parameters.AddWithValue("@StaffName", valueTosearch)

            Dim table As New DataTable()
            Using adapter As New SqlDataAdapter(cmd)
                adapter.Fill(table)
            End Using

            If table.Rows.Count = 1 Then
                Dim row As DataRow = table.Rows(0)
                lblStaffid.Text = row(1).ToString()
                lblStaffName.Text = row(2).ToString()
                lbldept.Text = row(9).ToString()
                lblComp.Text = row(8).ToString()
                DataGridView1.Rows.Insert(0, lblComp.Text, lblStaffid.Text, lblStaffName.Text, lbldept.Text, ComboBox1.Text, 1)
            ElseIf table.Rows.Count > 1 Then
                MsgBox("Staff Name more than 1. Kindly use staffid.")
            Else
                MsgBox("Not Found")
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillGoods(ComboBox2.Text, e)
            'ComboBox2.Focus()
        End If
    End Sub
    Sub load(ByVal txt As String)
        Try


            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            cmd = New SqlCommand

            With cmd
                .Connection = Poscon
                .CommandText = txt
                dr = cmd.ExecuteReader
                ComboBox2.Items.Clear()
                While dr.Read
                    ComboBox2.Items.Add(dr(0))
                    ComboBox2.Tag = Tag
                End While

            End With

            dr.Close()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillGoods(ComboBox2.Text, e)
        ComboBox2.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Select Items")
            Exit Sub
        End If
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim cmd1 As New SqlCommand("INSERT INTO mealtranx (userid, username, eatdate, mealname, qty, company, department, terminal, staffid) VALUES (@userid, @username, @eatdate, @mealname, @qty, @company, @department, @terminal, @staffid)", Poscon)

                With cmd1.Parameters
                    .AddWithValue("@userid", row.Cells(1).Value)
                    .AddWithValue("@username", row.Cells(2).Value)
                    .AddWithValue("@eatdate", Date.Now)
                    .AddWithValue("@mealname", row.Cells(4).Value)
                    .AddWithValue("@qty", "1")
                    .AddWithValue("@company", row.Cells(0).Value)
                    .AddWithValue("@department", row.Cells(3).Value)
                    .AddWithValue("@terminal", row.Cells(1).Value)
                    .AddWithValue("@staffid", row.Cells(1).Value)
                End With

                cmd1.ExecuteNonQuery()
            Next
            MsgBox("Success")
            DataGridView1.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub loc()
        Dim cmd As SqlCommand = New SqlCommand("SELECT location FROM mealtimes", Poscon)
        Dim tbl As DataTable = New DataTable()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd) ' Assign the SqlCommand to the SqlDataAdapter

        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If ' Assuming Poscon is a valid SqlConnection object
        da.Fill(tbl)
        Poscon.Close()

        If tbl.Rows.Count > 0 Then
            lblloc.Text = tbl.Rows(0)("location").ToString()
        End If


    End Sub
End Class