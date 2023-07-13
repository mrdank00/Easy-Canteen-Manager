Imports System
Imports System.Data.SqlClient
Public Class ExpiryModule
    Private Shared ReadOnly ExpiryDateKey As String = "2" ' Replace with your secret key

    Public Shared Function IsExpired() As Boolean
        Return DateTime.Now > GetExpiryDate()
    End Function

    Public Shared Function GenerateExtensionKey() As String
        Dim expiryDate As DateTime = GetExpiryDate().AddDays(90)
        Dim extensionKey As String = GenerateKey(expiryDate)
        Return extensionKey
    End Function

    Public Shared Function ExtendExpiry(extensionKey As String) As Boolean
        Dim expiryDate As DateTime = GetExpiryDate().AddDays(90)
        Dim expectedKey As String = GenerateKey(expiryDate)

        If extensionKey = expectedKey Then
            ' Key is valid, extend the expiry
            SaveExpiryDate(expiryDate)
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Function GetExpiryDate() As DateTime
        ' Retrieve the expiry date from storage (e.g., file, registry, database)
        ' Return the stored expiry date or a default date if not found
        ' For example:
        ' Return Date.Parse(My.Settings.ExpiryDate)
        Dim expiryDate As DateTime = DateTime.MinValue
        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If

        Dim query As String = "SELECT exdate FROM clientreg"
        Using command As New SqlCommand(query, Poscon)
            Using reader As SqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    expiryDate = reader.GetDateTime(0)
                End If
            End Using
        End Using

        'MsgBox(expiryDate)
        Return DateTime.Parse(expiryDate)
        'Return DateTime.Parse("2023-07-30")
    End Function

    Private Shared Sub SaveExpiryDate(expiryDate As DateTime)

        If Poscon.State = ConnectionState.Closed Then
            Poscon.Open()
        End If

        Dim query As String = "UPDATE clientreg SET exdate = @expiryDate"
        Using command As New SqlCommand(query, Poscon)
            command.Parameters.AddWithValue("@expiryDate", expiryDate)
            command.ExecuteNonQuery()
        End Using

    End Sub

    Private Shared Function GenerateKey(expiryDate As DateTime) As String
        ' Generate a unique key based on the expiry date and your secret key
        Dim keyData As String = expiryDate.ToString("yyyyMMdd") & ExpiryDateKey
        Dim keyBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(keyData)
        Dim hashBytes As Byte() = New System.Security.Cryptography.SHA256Managed().ComputeHash(keyBytes)
        Dim key As String = Convert.ToBase64String(hashBytes)
        Return key
    End Function

    Public Shared Function IsExpiredNotif() As Boolean
        Dim expiryDate As DateTime = GetExpiryDate()
        Dim alertDate As DateTime = expiryDate.AddMonths(-1) ' Set the alert date to one month before expiry

        If DateTime.Now > expiryDate Then
            ' Expired
            Return True
        ElseIf DateTime.Now > alertDate Then
            ' Alert: One month before expiry
            ShowExpiryAlert()
        End If

        Return False
    End Function
    Private Shared Sub ShowExpiryAlert()
        Dim expiryDate As DateTime = GetExpiryDate()
        Dim daysLeft As Integer = (expiryDate - DateTime.Now).Days

        Dim message As String
        If daysLeft = 1 Then
            message = "Software Maintanance due in 1 day." + vbNewLine + "Please contact Hardsoft on 0242838080 / 0244366722 to renew."
        ElseIf (daysleft < 30) Then
            message = "Software Maintanance due in " & daysLeft & " days." + vbNewLine + "Please contact Hardsoft on 0242838080 / 0244366722 to renew."
        End If

        MessageBox.Show(message)
    End Sub

End Class
