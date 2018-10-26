Imports System.Data.SqlClient

Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comm.CommandText = $"select dbo.getbalance('{ac}')"
        Dim dr As SqlDataReader
        Conn.Open()
        dr = comm.ExecuteReader
        dr.Read()
        TextBox1.Text = dr(0)
        dr.Close()
        Conn.Close()
    End Sub
End Class