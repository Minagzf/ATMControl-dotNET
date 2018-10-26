Imports System.Data.SqlClient

Public Class Form4

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        comm.CommandText = $"AtmWithdrawal '{ac}' , '{TextBox1.Text}'"
        Dim dr As SqlDataReader
        Conn.Open()
        dr = comm.ExecuteReader
        dr.Read()
        MsgBox(dr(0))
        dr.Close()
        Conn.Close()
        Me.Dispose()
    End Sub
End Class