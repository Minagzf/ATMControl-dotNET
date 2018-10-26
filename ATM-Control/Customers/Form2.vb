Imports System.Data.SqlClient
Public Class Form2

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim H As String = InputBox("Please enter account no", "Search")
        If Len(Trim(H)) = 0 Then Exit Sub
        comm.CommandText = $"select * from customers where AccountNo ='{ H }'"
        comm.Connection = Conn
        comm.CommandType = CommandType.Text
        Conn.Open()
        DR = comm.ExecuteReader
        DR.Read()
        If dr.HasRows = False Then
            MsgBox("Not Found", MsgBoxStyle.Critical, "Customers")
            DR.Close()
            Conn.Close()
            Exit Sub
        End If
        Form4.ShowDialog()
    End Sub
End Class