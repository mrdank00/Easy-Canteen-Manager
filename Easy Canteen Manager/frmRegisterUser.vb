
Imports System.Data.OleDb
    Imports System.Data.SqlClient
Public Class frmRegisterUser
    Public path = "C:\Program Files (x86)\ZKTeco\att2000.mdb"
    'Public path = "C:\Program Files\ZKTeco\att2000.mdb"
    ' Public path = "C:\Program Files (x86)\Hardsoft\ZKTeco\att2000.mdb"
    Dim found As Boolean
    Private Sub frmRegUserMeal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Display("SELECT * from userinfo", DataGridView1)
        ComboFeed("select distinct company from mealmast order by company asc", cbCompany, 0)
        ComboFeed("select distinct department from mealmast order by department asc", cbDept, 0)
    End Sub
    Public Sub Display(ByVal sql As String, dgv As DataGridView)
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "' ;"
        Dim con As New OleDbConnection(connectionString)
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



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        clear()

        Try
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtusername.Text = row.Cells(3).Value.ToString()
            txtuserid.Text = row.Cells(1).Value.ToString()
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            cmd = New SqlCommand("select * from mealmast where userid = '" + row.Cells(1).Value.ToString() + "'", Poscon)
            da = New SqlDataAdapter(cmd)
            tbl = New DataTable()
            tbl.Rows.Clear()
            da.Fill(tbl)
            If tbl.Rows.Count() = 0 Then
                'MsgBox("Not found")
                found = 0
            Else
                found = 1

                txtuserid.Text = tbl.Rows(0)(1).ToString
                cbCompany.Text = tbl.Rows(0)(8).ToString
                cbDept.Text = tbl.Rows(0)(9).ToString
                txtunits.Text = tbl.Rows(0)(7).ToString
                txtStaffid.Text = tbl.Rows(0)(10).ToString
                ckbreakfast.Checked = tbl.Rows(0)(3).ToString
                cklunch.Checked = tbl.Rows(0)(4).ToString
                ckdinner.Checked = tbl.Rows(0)(5).ToString
                'DataGridView1.DataSource = tbl
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Sub write()
        'If Poscon.State = ConnectionState.Closed Then
        '    Poscon.Open()
        'End If
        'Dim query = "Select  * from FoodSetup "
        'cmd = New SqlCommand(query, Poscon)
        'dr = cmd.ExecuteReader
        'While dr.Read
        '    Select Case dr.Item("Meal")
        '        Case "breakfast"
        '            cmd = New SqlCommand("insert into foodtranx(userid,date) values()", con)
        '            cmd.ExecuteNonQuery()
        '        Case "Lunch"
        '            cmd = New SqlCommand("insert into foodtranx() values()", con)
        '            cmd.ExecuteNonQuery()
        '        Case "Dinner"
        '            cmd = New SqlCommand("insert into foodtranx() values()", con)
        '            cmd.ExecuteNonQuery()
        '    End Select


        'End While
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Display("SELECT * from userinfo where name like '%" + txtSearch.Text + "%' or badgenumber like '" & txtSearch.Text & "%'", DataGridView1)

        'Dim searchTerm As String = txtSearch.Text
        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If row.Cells("Name").Value.ToString().Contains(searchTerm) Then
        '        DataGridView1.CurrentCell = row.Cells("Name")
        '        Exit For
        '    End If
        'Next
        'Dim searchTerm As String = txtSearch.Text.Trim()
        'Dim rows = DataGridView1.Rows.Cast(Of DataGridViewRow)().Where(Function(row) If(row.Cells("Name").Value IsNot Nothing, row.Cells("Name").Value.ToString().Contains(searchTerm), False)).ToArray()


        'If rows.Length > 0 Then
        '    Dim firstRow = rows(0)
        '    DataGridView1.CurrentCell = firstRow.Cells("Name")
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' If found = 0 Then
        If cbCompany.Text = "" Then
            MsgBox("Select a company")
            Exit Sub
        End If
        If cbDept.Text = "" Then
            MsgBox("Select a Department")
            Exit Sub
        End If

        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If
        cmd = New SqlCommand("If EXISTS (Select * FROM mealmast WHERE userid = @userid) " &
                     "UPDATE mealmast Set username='" + txtusername.Text + "',breakfast='" & ckbreakfast.Checked & "',lunch='" & cklunch.Checked & "',dinner='" & ckdinner.Checked & "',qty='" & txtunits.Text & "',company='" & cbCompany.Text & "',department='" & cbDept.Text & "',Staffid='" & txtStaffid.Text & "' WHERE userid = @userid " &
                     "Else insert into mealmast(userid,username,breakfast,lunch,dinner,qty,company,department,Staffid) values('" & txtuserid.Text & "','" & txtusername.Text & "','" & ckbreakfast.Checked & "','" & cklunch.Checked & "','" & ckdinner.Checked & "','" & txtunits.Text & "','" + cbCompany.Text + "','" + cbDept.Text + "','" + txtStaffid.Text + "')", Poscon)

        cmd.Parameters.AddWithValue("@userid", txtuserid.Text)
        cmd.ExecuteNonQuery()

        '    'insertd("insert into mealmast(userid,username,breakfast,lunch,dinner,qty,company,department,Staffid) values('" & TextBox1.Text & "','" & txtAmtPaid.Text & "','" & BunifuCheckBox1.Checked & "','" & BunifuCheckBox2.Checked & "','" & BunifuCheckBox3.Checked & "','" & TextBox2.Text & "','" + cbPaymentAC.Text + "','" + cbDept.Text + "','" + txtStaffid.Text + "')")
        '    found = 1
        'End If
        'If found = 1 Then
        '    'insertd("insert into foodmast(userid,username,breakfast,lunch,dinner,units) values('" & TextBox1.Text & "','" & txtAmtPaid.Text & "','" & BunifuCheckBox1.Checked & "','" & BunifuCheckBox2.Checked & "','" & BunifuCheckBox3.Checked & "','" & TextBox2.Text & "')")
        'End If
        MsgBox("Success")
        clear()
    End Sub
    Sub clear()
        ckbreakfast.Checked = False
        cklunch.Checked = False
        ckdinner.Checked = False
        txtusername.Text = ""
        txtuserid.Text = ""
        cbDept.SelectedIndex = -1
        cbCompany.SelectedIndex = -1
        txtunits.Text = ""
        txtStaffid.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class