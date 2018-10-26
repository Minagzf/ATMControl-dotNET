Imports System.Data.SqlClient
Module Module1
    Public CnStr As String = "Password=000;Persist Security Info=True;User ID=dev1;Initial Catalog=ATM;Data Source=."
    Public conn As New SqlConnection(CnStr)
    Public comm As New SqlCommand()

    Public Function GetNewID(TableName As String) As Integer
        comm.Connection = conn
        comm.CommandType = CommandType.Text
        comm.Parameters.Clear()
        comm.CommandText = $"Select IDENT_CURRENT ('{TableName}')"
        conn.Open()
        Dim DR As SqlDataReader
        DR = comm.ExecuteReader()
        DR.Read()
        If DR.HasRows() Then
            GetNewID = DR(0)
        Else
            GetNewID = 1
        End If
        DR.Close()

        conn.Close()
    End Function
End Module
