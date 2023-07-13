Imports System.Data.SqlClient
Module DbCon
    Public Function PosConnection() As SqlConnection
        Return New SqlConnection(My.Settings.NetworkPos)
    End Function
    Public Poscon As SqlConnection = PosConnection()
End Module
