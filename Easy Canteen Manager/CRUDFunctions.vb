'Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports CrystalDecisions.CrystalReports.Engine
Module CRUDFunction
    Public result As String
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public tbl As New DataTable
    Public ds As New DataSet
    Public dr As SqlDataReader
    Public outto As Date
    Public outfrom As Date
    Public tranx As SqlTransaction
    Public path As String
#Region "Report"
    Public Sub reports(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
        '
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If

            Dim reportname As String
            With cmd
                .Connection = Poscon
                .CommandText = sql
            End With
            ds = New DataSet
            da = New SqlDataAdapter(sql, Poscon)
            da.Fill(ds)
            reportname = rptname
            Dim reportdoc = "" 'As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim strReportPath As String
            strReportPath = Application.StartupPath & "\SalesMenu\" & reportname & ".rpt"
            '    "K:\Daakye\FoodApplication\SalesMenu\rptProformaA4.rpt"

            With reportdoc
                '.Load(strReportPath)
                '.SetDataSource(ds.Tables(0))

            End With
            With crystalRpt
                .ShowRefreshButton = False
                .ShowCloseButton = False
                .ShowGroupTreeButton = False
                .ReportSource = reportdoc
            End With
            'frmSupplierReport.Show()
        Catch ex As Exception
            MsgBox(ex.Message & "No Crystal Reports have been Installed")
        Finally
            If Poscon.State = ConnectionState.Open Then
                Poscon.Close()
                da.Dispose()
            End If
        End Try
        'poscon.Close()
        'da.Dispose()
    End Sub

    'THIS METHOD IS FOR INSERTING DATA IN THE DATABASE
    Public Sub create(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = Poscon
                .CommandText = sql
                'EXECUTE THE DATA
                result = cmd.ExecuteNonQuery
                'CHECKING IF THE DATA HAS EXECUTED OR NOT AND THEN THE POP UP MESSAGE WILL APPEAR
                If result = 0 Then
                    ' MessageBox.Show("Failed ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ' MessageBox.Show("Data has been inserted in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'Poscon.Close()
        End Try

    End Sub
    Public Sub ComboFeed(ByVal sql As String, combo As ComboBox, Optional row As Integer = 0, Optional vmem As Integer = Nothing)
        Try


            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            cmd = New SqlCommand

            With cmd
                .Connection = Poscon
                .CommandText = sql
                dr = cmd.ExecuteReader
                combo.Items.Clear()
                While dr.Read
                    combo.Items.Add(dr(row))
                End While

            End With

            dr.Close()
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub newComboFeed(ByVal sql As String, combo As ComboBox, row As Integer)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                dr = cmd.ExecuteReader
                combo.Items.Clear()
                While dr.Read
                    combo.Items.Add(dr(row))

                End While

            End With
            Poscon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub Reader(ByVal sql As String, combo As ComboBox, row As Integer)
        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If
        With cmd
            .Connection = Poscon
            .CommandText = sql
            dr = cmd.ExecuteReader
            combo.Items.Clear()
            While dr.Read
                combo.Items.Add(dr(row))

            End While

        End With
        Poscon.Close()
    End Sub

    Public Sub createLogged(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = Poscon
                .CommandText = sql
                'EXECUTE THE DATA
                result = cmd.ExecuteNonQuery
                'CHECKING IF THE DATA HAS EXECUTED OR NOT AND THEN THE POP UP MESSAGE WILL APPEAR
                If result = 0 Then
                    'MessageBox.Show("Data is failed to insert.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'MessageBox.Show("Data has been inserted in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Poscon.Close()
        End Try

    End Sub

    '    'THIS METHOD IS FOR RETRIEVING DATA IN THE DATABASE
    Public Sub reload(ByVal sql As String, ByVal DTG As Object)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            tbl = New DataTable
            With cmd
                .Connection = Poscon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(tbl)
            DTG.DataSource = tbl
            Poscon.Close()
            da.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Poscon.Close()
            da.Dispose()
        End Try
    End Sub
#End Region
    Public Sub reloadtxt(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
            End With
            tbl = New DataTable
            da = New SqlDataAdapter(sql, Poscon)
            da.Fill(tbl)

        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame = st.GetFrame(st.FrameCount - 1)
            Dim lineNumber As Integer = frame.GetFileLineNumber()
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "Line number: " & lineNumber.ToString())
        Finally
            If Poscon.State = ConnectionState.Open Then
                Poscon.Close()
                da.Dispose()
            End If
        End Try
    End Sub

    Public Sub daccessdb(txt As TextBox)

        Dim opf As New OpenFileDialog
        opf.Filter = "Access Files (*.mdb, *.accdb)|*.mdb;*.accdb"
        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = opf.FileName.ToString()
            txt.Text = opf.FileName.ToString()
        End If
    End Sub
    Public Sub SetLabelOnForm(formName As String, labelName As String, labelText As String)
        Dim targetForm As Form = CType(Application.OpenForms(formName), Form)
        If targetForm IsNot Nothing Then
            Dim label As Label = TryCast(targetForm.Controls.Find(labelName, True).FirstOrDefault(), Label)
            If label IsNot Nothing Then
                label.Text = labelText
            End If
        End If
    End Sub

    Sub pvouchno(colanam As String, vouchno As Integer, svouch As String, init As String)
        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If
        Dim cmd As New SqlCommand("vnum", Poscon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@columnName", colanam)
        vouchno = CInt(cmd.ExecuteScalar())
        svouch = init & vouchno.ToString("D4")
    End Sub
    Sub updatevouch(colum As String)

        'If Poscon.State = ConnectionState.Closed Then
        '    Poscon.Open()
        'End If
        'Dim cmd As New SqlCommand("updateserial", Poscon)
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.Parameters.AddWithValue("@table_name", "Serialconfigs")
        'cmd.Parameters.AddWithValue("@column_name", colum)
        'cmd.Parameters.AddWithValue("@new_value", (vouchno + 1).ToString)
        'cmd.ExecuteNonQuery()


    End Sub

    'THIS METHOD IS FOR UPDATING THE DATA IN THE DATABASE.
    Public Sub updates(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Data is failed to updated", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'MessageBox.Show("Data has been updated in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Poscon.Close()
        End Try
    End Sub
    Public Sub PostToGeneralLedger(accountNumber As String, amount As Decimal, transactionDate As Date, transactionType As String, ByVal ref As String, ByVal isDebit As Boolean)
        Dim sign As Integer = If(isDebit, 1, -1)
        amount *= sign
        ' Open connection to database

        'Poscon.Open()

        ' Start a transaction
        ' Dim transaction As SqlTransaction = Poscon.BeginTransaction()

        ' Try
        ' Insert a record into the GeneralLedger table
        cmd = New SqlCommand("INSERT INTO GeneralLedger (AccountNumber, Amount, TransactionDate, TransactionType,ref) VALUES (@AccountNumber, @Amount, @TransactionDate, @TransactionType,@ref)", Poscon, tranx)
        cmd.Parameters.AddWithValue("@AccountNumber", accountNumber)
        cmd.Parameters.AddWithValue("@Amount", amount)
        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate)
        cmd.Parameters.AddWithValue("@TransactionType", transactionType)
        cmd.Parameters.AddWithValue("@ref", ref)
        cmd.ExecuteNonQuery()


        '' Update the balance of the account
        'cmd = New SqlCommand("UPDATE glAccounts SET Balance = Balance + @Amount WHERE glAccountNo = @AccountNumber", Poscon, tranx)
        'cmd.Parameters.AddWithValue("@AccountNumber", accountNumber)
        'cmd.Parameters.AddWithValue("@Amount", amount)
        'cmd.ExecuteNonQuery()


        ' Commit the transaction
        ' transaction.Commit()
        ' Catch ex As Exception
        ' If an error occurs, roll back the transaction
        'transaction.Rollback()
        'Throw ex
        ' End Try

    End Sub

    Public Sub PostToGL(ByVal lbldr As String, ByVal lblCr As String, ByVal postamt As Double, ByVal ref As String, ByVal nar As String, ByVal tranxtype As String, ByVal tranxgroup As String, Optional loc As String = "Main Store")


        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        ' Post debit transaction
        cmd = New SqlCommand("SELECT * FROM glaccounts WHERE accountname='" + lbldr + "'", Poscon, tranx)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                cmd = New SqlCommand("INSERT INTO GLPostings(Acctno, acctname, narration, debit, credit, acctclass, accthead, acctsubhead, accttype, acctcateg,maincc, subcc, tranxref, date,tranxtype,tranxgroup,tranxdesc) " &
                                  "VALUES ('" + dr.Item("glaccountno").ToString + "', '" & lbldr & "', '" + nar + "', '" & postamt & "', '" & 0 & "', '" + dr.Item("accountclass").ToString + "', " &
                                  "'" + dr.Item("accounthead").ToString + "', '" + dr.Item("accountsubhead").ToString + "', '" + dr.Item("accounttype").ToString + "', '" + dr.Item("accountcategory").ToString + "','GFG Tarkwa', " &
                                  "'" + loc + "', '" & ref & "', CONVERT(DATETIME, '" + DateTime.Now + "', 105),'" + tranxtype + "','" + tranxgroup + "','" + lblCr + "')", Poscon, tranx)

                With cmd
                    .ExecuteNonQuery()
                End With

                cmd = New SqlCommand("UPDATE glaccounts SET debit=debit+'" & postamt & "', balance=balance+'" & postamt & "' WHERE glaccountno='" & dr.Item("glaccountno").ToString & "'", Poscon, tranx)
                cmd.ExecuteNonQuery()
            End While
        Else
            MsgBox("Debit Account Not Found")
        End If
        dr.Close()

        ' Post credit transaction
        cmd = New SqlCommand("SELECT * FROM glaccounts WHERE accountname='" + lblCr + "'", Poscon, tranx)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                cmd = New SqlCommand("INSERT INTO GLPostings(Acctno, acctname, narration, debit, credit, acctclass, accthead, acctsubhead, accttype, acctcateg,maincc, subcc, tranxref, date,tranxtype,tranxgroup,tranxdesc) " &
                                  "VALUES ('" + dr.Item("glaccountno").ToString + "', '" & lblCr & "', '" + nar + "', '" & 0 & "', '" & postamt & "', '" + dr.Item("accountclass").ToString + "', " &
                                  "'" + dr.Item("accounthead").ToString + "', '" + dr.Item("accountsubhead").ToString + "', '" + dr.Item("accounttype").ToString + "', '" + dr.Item("accountcategory").ToString + "','GFG Tarkwa', " &
                                  "'" + loc + "', '" & ref & "', CONVERT(DATETIME, '" + DateTime.Now + "', 105),'Sales','" + tranxgroup + "','" + lbldr + "')", Poscon, tranx)

                With cmd
                    .ExecuteNonQuery()
                End With

                cmd = New SqlCommand("UPDATE glaccounts SET credit=credit+'" & postamt & "', balance=balance-'" & postamt & "' WHERE glaccountno='" & dr.Item("glaccountno").ToString & "'", Poscon, tranx)
                cmd.ExecuteNonQuery()
            End While
        Else
            MsgBox("Credit Account Not Found")
        End If
        dr.Close()
    End Sub


    Public Function PostSalesTransaction(ByVal accountName As String, ByVal salesTotal As Decimal, ByVal shopName As String, ByVal receiptNo As String) As Boolean
        Dim success As Boolean = False

        Try
            ' Retrieve the GL account record for the given account name
            Dim cmdSelect As New SqlCommand("SELECT * FROM glaccounts WHERE accountname=@AccountName", Poscon, tranx)
            cmdSelect.Parameters.AddWithValue("@AccountName", accountName)
            cmdSelect.Transaction = tranx
            Dim dr As SqlDataReader = cmdSelect.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    ' Insert a new GLPosting record for the sales transaction
                    Dim cmdInsert As New SqlCommand("INSERT INTO GLPostings(Acctno, acctname, tranxdesc, debit, credit, acctclass, accthead, acctsubhead, accttype, acctcateg, subcc, tranxid, date) " &
                                                "VALUES(@AcctNo, @AcctName, 'Sales', @Debit, @Credit, @AcctClass, @AcctHead, @AcctSubhead, @AcctType, @AcctCateg, @Subcc, @TranxId, @Date)", Poscon)
                    cmdInsert.Parameters.AddWithValue("@AcctNo", dr.Item("glaccountno").ToString())
                    cmdInsert.Parameters.AddWithValue("@AcctName", accountName)
                    cmdInsert.Parameters.AddWithValue("@Debit", salesTotal)
                    cmdInsert.Parameters.AddWithValue("@Credit", 0)
                    cmdInsert.Parameters.AddWithValue("@AcctClass", dr.Item("accountclass").ToString())
                    cmdInsert.Parameters.AddWithValue("@AcctHead", dr.Item("accounthead").ToString())
                    cmdInsert.Parameters.AddWithValue("@AcctSubhead", dr.Item("accountsubhead").ToString())
                    cmdInsert.Parameters.AddWithValue("@AcctType", dr.Item("accounttype").ToString())
                    cmdInsert.Parameters.AddWithValue("@AcctCateg", dr.Item("accountcategory").ToString())
                    cmdInsert.Parameters.AddWithValue("@Subcc", shopName)
                    cmdInsert.Parameters.AddWithValue("@TranxId", receiptNo)
                    cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now)
                    cmdInsert.Transaction = tranx
                    cmdInsert.ExecuteNonQuery()

                    ' Update the corresponding glaccount record with the sales transaction amount
                    Dim cmdUpdate As New SqlCommand("UPDATE glaccounts SET debit=debit+@Debit, balance=balance+@Debit WHERE glaccountno=@AcctNo", Poscon)
                    cmdUpdate.Parameters.AddWithValue("@Debit", salesTotal)
                    cmdUpdate.Parameters.AddWithValue("@AcctNo", dr.Item("glaccountno").ToString())
                    cmdUpdate.Transaction = tranx
                    cmdUpdate.ExecuteNonQuery()
                End While
                success = True
            Else
                MsgBox("Account not found")
            End If
        Catch ex As Exception
            MsgBox("Error posting sales transaction: " & ex.Message)
        End Try

        Return success
    End Function


    Public Sub PostTransaction(account As String, amount As Decimal, transactionType As String, reference As String, narration As String)
        ' Create a connection to the database
        Dim connString As String = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;"
        Dim conn As New SqlConnection(connString)
        conn.Open()

        ' Begin a database transaction
        Dim trans As SqlTransaction = conn.BeginTransaction()

        Try
            ' Insert a record into the general ledger table
            Dim glCommand As New SqlCommand("INSERT INTO GeneralLedger (Account, Amount, TransactionType, Reference, Narration) VALUES (@Account, @Amount, @TransactionType, @Reference, @Narration)", conn, trans)
            glCommand.Parameters.AddWithValue("@Account", account)
            glCommand.Parameters.AddWithValue("@Amount", amount)
            glCommand.Parameters.AddWithValue("@TransactionType", transactionType)
            glCommand.Parameters.AddWithValue("@Reference", reference)
            glCommand.Parameters.AddWithValue("@Narration", narration)
            glCommand.ExecuteNonQuery()

            ' Commit the transaction
            trans.Commit()

        Catch ex As Exception
            ' Rollback the transaction if there is an error
            trans.Rollback()
            MsgBox(ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub



    'Mother UPDATE phone
    Public Sub StudentUpdatePhone(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Student information is failed to Saved", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Student has been added to parent list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Poscon.Close()
        End Try
    End Sub

    Public Sub UpdatePhone(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Poscon.Close()
        End Try
    End Sub
    'INSERT SMS 
    Public Sub insertd(ByVal sql As String)
        'Try
        '    If Poscon.State = ConnectionState.Closed Then
        '        Poscon.Open()
        '    End If
        '    With cmd
        '        .Connection = Poscon
        '        .CommandText = sql
        '        result = cmd.ExecuteNonQuery
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.message)
        'Finally
        '    Poscon.Close()
        'End Try

        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = Poscon
                .CommandText = sql
                'EXECUTE THE DATA
                result = cmd.ExecuteNonQuery
                'CHECKING IF THE DATA HAS EXECUTED OR NOT AND THEN THE POP UP MESSAGE WILL APPEAR
                If result = 0 Then
                    '  MessageBox.Show("Faileds ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'MessageBox.Show("Data has been inserted in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With

        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame = st.GetFrame(st.FrameCount - 1)
            Dim lineNumber As Integer = frame.GetFileLineNumber()
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "Line number: " & lineNumber.ToString())
        Finally
            Poscon.Close()
        End Try
    End Sub

    Public Sub Sql(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Data is failed to updated", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ' MessageBox.Show("Data has been updated in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame = st.GetFrame(st.FrameCount - 1)
            Dim lineNumber As Integer = frame.GetFileLineNumber()
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "Line number: " & lineNumber.ToString())
        Finally
            Poscon.Close()

        End Try

    End Sub
    'THIS METHOD IS FOR DELETING THE DATA IN THE DATABASE
    Public Sub delete(ByVal sql As String)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            With cmd
                .Connection = Poscon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    '  MessageBox.Show("Data is failed to delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    '  MessageBox.Show("Data has been deleted in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame = st.GetFrame(st.FrameCount - 1)
            Dim lineNumber As Integer = frame.GetFileLineNumber()
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "Line number: " & lineNumber.ToString())
        Finally
            Poscon.Close()
        End Try
    End Sub

    Public Sub findRecords(sql As String, dtg As DataGridView)
        Try
            If Poscon.State = ConnectionState.Closed Then
                Poscon.Open()
            End If
            cmd = New SqlCommand
            With cmd
                .Connection = Poscon
                .CommandText = sql
            End With
            da = New SqlDataAdapter
            da.SelectCommand = cmd
            tbl = New DataTable
            da.Fill(tbl)
            dtg.DataSource = tbl
        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame = st.GetFrame(st.FrameCount - 1)
            Dim lineNumber As Integer = frame.GetFileLineNumber()
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "Line number: " & lineNumber.ToString())
        Finally
            Poscon.Close()
            da.Dispose()
        End Try
    End Sub
    Public Sub userc()
        'frmSales.lblTotal.Visible = False
    End Sub

    ''Public Sub ExecuteQueryAndDisplayReport(query As String, tableName As String, report As ReportDocument, form As Form, crystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer, Optional query1 As String = "", Optional tableName1 As String = "")
    ''    Try
    ''        If Poscon.State = ConnectionState.Closed Then
    ''            Poscon.Open()
    ''        End If

    ''        Dim cmd = New SqlCommand(query, Poscon)
    ''        Dim da = New SqlDataAdapter(cmd)
    ''        Dim dt = New DataSet()

    ''        da.Fill(dt, tableName)



    ''        If query1 <> "" Then
    ''            cmd = New SqlCommand(query1, Poscon)
    ''            da = New SqlDataAdapter(cmd)
    ''            da.Fill(dt, tableName1)

    ''        End If

    ''        report.SetDataSource(dt)
    ''        form.Show()
    ''        crystalReportViewer.ReportSource = report
    ''        crystalReportViewer.Refresh()

    ''        cmd.Dispose()
    ''        da.Dispose()
    ''        Poscon.Close()
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    End Try
    ''End Sub
    ''''''''' Roll Back SQL Changes VB.NET'''''''''''''''''''''
    '    Dim conn As New SqlConnection("your connection string here")
    'conn.Open()

    'Dim tran As SqlTransaction = conn.BeginTransaction()

    '    Try
    '    ' Execute your INSERT or UPDATE statements here, using the SqlCommand object
    '    ' and passing the SqlTransaction object as a parameter.

    '    tran.Commit()
    'Catch ex As Exception
    '    tran.Rollback()
    '    ' Handle the exception here
    'Finally
    '    conn.Close()
    'End Try
    ''''''''''''''''''''''''''''''Roll Back Changes in C#'''''''''''''''''''''''''''
    '    Using (SqlConnection conn = New SqlConnection("your connection string here"))
    '{
    '    conn.Open();
    '    SqlTransaction tran = conn.BeginTransaction();
    '    Try
    '    {
    '        // Execute your INSERT Or UPDATE statements here, using the SqlCommand object
    '        // And passing the SqlTransaction object as a parameter.

    '        tran.Commit();
    '    }
    '    Catch (Exception ex)
    '    {
    '        tran.Rollback();
    '        // Handle the exception here
    '    }
    '}
End Module

