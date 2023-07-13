
Imports System.Data.SqlClient

    Imports System.Text
Public Class frmReports
    Dim dt As New dsPosTerminal


    Private Sub frmMealReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dpdatefrom.Value = Date.Now
        dpdateto.Value = Date.Now
        ComboFeed("select distinct mealname from mealtranx", cbItemname)
        ComboFeed("select distinct company from mealtranx", cbShopname)
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  * FROM MealTranx where convert(date,eatdate,103) between convert(date,@datefrom,103) and convert(date,@dateto,103)")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("mealtranx").Rows.Clear()
                adapter.Fill(dt, "mealtranx")

                If dt.Tables("mealtranx").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealPertype
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',terminal as location
FROM MealTranx where 1=1
")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptmealperloc
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  * FROM MealTranx where convert(date,eatdate,103) between convert(date,@datefrom,103) and convert(date,@dateto,103)")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If

            ' query.Append(" AND eatdate between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("mealtranx").Rows.Clear()
                adapter.Fill(dt, "mealtranx")

                If dt.Tables("mealtranx").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealTyperoll
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
                                                            SUM(CASE WHEN MealName = 'Breakfast' THEN Qty END) AS 'Breakfast',
                                                            SUM(CASE WHEN MealName = 'Lunch' THEN Qty END) AS 'Lunch',
                                                            SUM(CASE WHEN MealName = 'Dinner' THEN Qty END) AS 'Dinner'
                                                    FROM MealTranx where 1=1
                                                   ")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If

            query.Append(" AND eatdate between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")
            query.Append(" GROUP BY userid,UserName,convert(date,eatdate,103),Company,Department order by edate")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealsperDept
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',terminal as location
FROM MealTranx where 1=1
")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealPerLocSumm
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',terminal as location
        FROM MealTranx where 1=1
        ")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealsPerDate
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',terminal as location
FROM MealTranx where 1=1
")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealperDateSumm
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',
        CASE WHEN MealName = 'Supplementary' THEN Qty END AS 'Suppl',
 CASE WHEN MealName = 'Pack' THEN Qty END AS 'Pack',terminal as location
FROM MealTranx where 1=1
")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealsPerStaff
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Cursor = Cursors.WaitCursor

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim query As New StringBuilder()
            query.Append("SELECT  convert(date,eatdate,103) as edate,Company,Department,userid,username,
        CASE WHEN MealName = 'Breakfast' THEN Qty END AS 'Breakfast',
        CASE WHEN MealName = 'Lunch' THEN Qty END AS 'Lunch',
        CASE WHEN MealName = 'Dinner' THEN Qty END AS 'Dinner',
        CASE WHEN MealName = 'Supplementary' THEN Qty END AS 'Suppl',
         CASE WHEN MealName = 'Pack' THEN Qty END AS 'Pack',terminal as location
        FROM MealTranx where 1=1
            ")

            If cbShopname.SelectedIndex > -1 Then
                query.Append(" AND Company = @shop")
            End If

            If cbItemname.SelectedIndex > -1 Then
                query.Append(" AND Customername = @item")
            End If
            query.Append(" AND convert(date,eatdate,103) between convert(datetime,@datefrom,103) and convert(datetime,@dateto,103)")

            Using command As New SqlCommand(query.ToString(), Poscon)
                command.Parameters.AddWithValue("@dateFrom", dpdatefrom.Value.ToString("dd/MM/yyyy"))
                command.Parameters.AddWithValue("@dateTo", dpdateto.Value.ToString("dd/MM/yyyy"))

                If cbShopname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@shop", cbShopname.Text.Trim)
                End If

                If cbItemname.SelectedIndex > -1 Then
                    command.Parameters.AddWithValue("@item", cbItemname.Text.Trim)
                End If

                Dim adapter As New SqlDataAdapter(command)
                '  Dim dt As New DataSet()
                dt.Tables("eatrows").Rows.Clear()
                adapter.Fill(dt, "eatrows")

                If dt.Tables("eatrows").Rows.Count > 0 Then
                    ' Do something with the dataTable
                Else
                    Cursor = Cursors.Default
                    MsgBox("No results found")
                    Exit Sub
                End If
            End Using

            '' Get an array of DataRow objects with errors
            'Dim rowsWithErrors As DataRow() = dt.Tables("salestranx").GetErrors()

            '' Iterate through the rows with errors and display the error message
            'For Each row As DataRow In rowsWithErrors
            '    Console.WriteLine("Error: " + row.RowError)
            '    MsgBox("Error: " + row.RowError)
            'Next


            Dim sql = "select * from ClientReg"
            cmd = New SqlCommand(sql, Poscon)
            da.SelectCommand = cmd
            dt.Tables("clientreg").Rows.Clear()
            da.Fill(dt, "ClientReg")

            Dim report As New rptMealPerStaffSumm
            report.SetDataSource(dt)
            frmSupplierReport.Show()
            frmSupplierReport.CrystalReportViewer1.ReportSource = report
            frmSupplierReport.CrystalReportViewer1.Refresh()
            cmd.Dispose()
            da.Dispose()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class