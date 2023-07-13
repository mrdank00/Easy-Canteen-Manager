Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class frmUploadData
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
        Display("SELECT * FROM mealtranxsync WHERE MONTH(eatdate) = Month(CDate('" + DateTimePicker1.Value.ToString("dd/MM/yyyy") + "'))", DataGridView2)
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
        reload("Select * from mealtranx where MONTH(eatdate)=month(convert(datetime,'" + DateTimePicker1.Value + "',105)) ", DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        For Each row As DataGridViewRow In DataGridView2.Rows
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            Dim myDateString As String = Convert.ToDateTime(row.Cells(3).Value).ToString("yyyy-MM-dd HH:mm:ss")
            Dim cmdText As String = "IF EXISTS (SELECT * FROM MealTranx WHERE syncid = @syncid) " &
                                    "UPDATE MealTranx " &
                                    "SET UserName = @username, " &
                                    "    Price = @price, " &
                                    "    MealName = @mealName, " &
                                    "    Qty = @qty, " &
                                    "    Company = @company, " &
                                    "    Department = @department " &
                                    "WHERE syncid = @syncid " &
                                    "ELSE " &
                                    "INSERT INTO MealTranx (UserId, UserName, Price, MealName, Qty, Company, Department,eatdate,terminal,Staffid,syncid) " &
                                    "VALUES (@userid, @username, @price, @mealName, @qty, @company, @department,@eatdate,@terminal,@staffid,@syncid)"

            cmd = New SqlCommand(cmdText, Poscon)
            cmd.Parameters.AddWithValue("@userid", row.Cells(1).Value)
            cmd.Parameters.AddWithValue("@username", row.Cells(2).Value)
            cmd.Parameters.AddWithValue("@eatdate", myDateString)
            cmd.Parameters.AddWithValue("@price", row.Cells(4).Value)
            cmd.Parameters.AddWithValue("@mealname", row.Cells(5).Value)
            cmd.Parameters.AddWithValue("@qty", row.Cells(6).Value)
            cmd.Parameters.AddWithValue("@company", row.Cells(7).Value)
            cmd.Parameters.AddWithValue("@department", row.Cells(8).Value)
            cmd.Parameters.AddWithValue("@terminal", row.Cells(9).Value)
            cmd.Parameters.AddWithValue("@staffid", row.Cells(10).Value)
            cmd.Parameters.AddWithValue("@syncid", row.Cells(11).Value)

            cmd.ExecuteNonQuery()
        Next
        MsgBox("Success")

    End Sub
End Class