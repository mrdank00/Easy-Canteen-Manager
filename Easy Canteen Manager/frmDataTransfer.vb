
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Public Class frmDataTransfer
    Dim paths As String
    ' Dim asconnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "' ;"
    Dim asconnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                          "Data Source='" + paths + "';" +
                          "Integrated Security=True;"

    'Dim asconnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;" +
    '                      "Data Source='" + path + "';" +
    '                      "User Id=;" +
    '                      "Password=10062642;"
    Dim cmds As New OleDbCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        daccessdb(TextBox1)
        paths = TextBox1.Text
        asconnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + paths + "';Mode=Share Deny None"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Select an Access File")
            Exit Sub
        End If
        Display("SELECT * FROM mealtranxsync WHERE MONTH(eatdate) = Month(CDate('" + DateTimePicker1.Value.ToString("dd/MM/yyyy") + "')) ", DataGridView2)
    End Sub

    Public Sub Display(ByVal sql As String, dgv As DataGridView)
        '  MsgBox(asconnectionString)
        Dim con As New OleDbConnection(asconnectionString)
        'Try
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        'HOLDS THE DATA TO BE EXECUTED
        Dim cmds As New OleDbCommand
        Dim das As New OleDbDataAdapter
        With cmds
            .Connection = con
            .CommandText = sql
            'EXECUTE THE DATA
            result = cmds.ExecuteNonQuery
            Dim tbls As New DataTable
            das = New OleDbDataAdapter(cmds)
            das.Fill(tbls)
            dgv.DataSource = tbls

        End With

        con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
    End Sub
    Public Sub Insert(ByVal sql As String)
        Dim con As New OleDbConnection(asconnectionString)
        'Try
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        'HOLDS THE DATA TO BE EXECUTED
        Dim cmds As New OleDbCommand
        Dim das As New OleDbDataAdapter
        cmds = New OleDbCommand(sql, con)
        cmds.ExecuteNonQuery()
        con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
    End Sub

    Private Sub frmDataTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As SqlCommand = New SqlCommand("SELECT location FROM mealtimes", Poscon)
        Dim tbl As DataTable = New DataTable()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd) ' Assign the SqlCommand to the SqlDataAdapter

        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If ' Assuming Poscon is a valid SqlConnection object
        da.Fill(tbl)
        Poscon.Close()

        If tbl.Rows.Count > 0 Then
            Label3.Text = tbl.Rows(0)("location").ToString()
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        reload("Select * from mealtranx where MONTH(eatdate)=month(convert(datetime,'" + DateTimePicker1.Value + "',105))", DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim con As New OleDbConnection(asconnectionString)
        'Try
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows


            Dim myDate As DateTime = row.Cells(3).Value
            Dim myDateString As String = myDate.ToString("yyyy-MM-dd HH:mm:ss")


            cmds = New OleDbCommand("SELECT COUNT(*) FROM MealTranxsync WHERE syncid = @terminal+@id", con)
            cmds.Parameters.AddWithValue("@terminal", row.Cells(9).Value.ToString)
            cmds.Parameters.AddWithValue("@id", row.Cells(0).Value.ToString)

            Dim count As Integer = CInt(cmds.ExecuteScalar())

            If count > 0 Then
                ' MsgBox("Update")
                cmds = New OleDbCommand("UPDATE MealTranxsync 
                             SET UserName = @username,
                                 Price = @price,
                                 MealName = @mealName,
                                 Qty = @qty,
                                 Company = @company,
                                 Department = @department
                             WHERE  syncid = @terminal+@id", con)
            Else
                '  MsgBox("insert")
                cmds = New OleDbCommand("INSERT INTO MealTranxsync (UserId, UserName, MealName, Qty, Company, Department,eatdate,terminal,staffid,syncid) 
                             VALUES ('" & row.Cells(1).Value & "', '" + row.Cells(2).Value + "','" + row.Cells(5).Value + "', '" & row.Cells(6).Value & "', '" + row.Cells(7).Value + "', '" + row.Cells(8).Value + "',#" + myDateString + "#,'" & row.Cells(9).Value & "','" & row.Cells(10).Value & "','" & row.Cells(9).Value & row.Cells(0).Value & "')", con)
            End If
            '.ToString("yyyy-MM-dd HH:mm:ss")
            cmds.Parameters.AddWithValue("@id", row.Cells(0).Value)
            cmds.Parameters.AddWithValue("@userid", row.Cells(1).Value)
            cmds.Parameters.AddWithValue("@username", row.Cells(2).Value)
            ' cmds.Parameters.AddWithValue("@eatdate", row.Cells(3).Value)
            cmds.Parameters.AddWithValue("@price", row.Cells(4).Value)
            cmds.Parameters.AddWithValue("@mealname", row.Cells(5).Value)
            cmds.Parameters.AddWithValue("@qty", row.Cells(6).Value)
            cmds.Parameters.AddWithValue("@company", row.Cells(7).Value)
            cmds.Parameters.AddWithValue("@department", row.Cells(8).Value)
            cmds.Parameters.AddWithValue("@terminal", row.Cells(9).Value)
            cmds.Parameters.AddWithValue("@staffid", (row.Cells(10).Value))

            cmds.ExecuteNonQuery()


        Next
        Display("SELECT * FROM mealtranxsync WHERE MONTH(eatdate) = Month(CDate('" + DateTimePicker1.Value.ToString("dd/MM/yyyy") + "')) ", DataGridView2)
        MsgBox("Sucess")

    End Sub

    Private Sub DataGridView1_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValidated

    End Sub

    Private Sub DataGridView2_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValidated

    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Label1.Text = DataGridView1.Rows.Count()
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        Label1.Text = DataGridView1.Rows.Count()
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        Label2.Text = DataGridView2.Rows.Count()
    End Sub

    Private Sub DataGridView2_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView2.RowsRemoved
        Label2.Text = DataGridView2.Rows.Count()
    End Sub
End Class