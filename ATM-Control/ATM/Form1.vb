Imports System.Data.SqlClient

Public Class Form1

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn.ConnectionString = Str
        comm.Connection = Conn

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim acc As String = TextBox1.Text
        Dim pin As String = TextBox2.Text
        comm.Connection = Conn
        comm.CommandText = $"select dbo.CustomerStatus ( '{acc}' , '{pin}' )"
        Conn.Open()
        Dim st As Integer
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader
        dr.Read()
        st = dr(0)
        dr.Close()
        Conn.Close()
        If st = 0 Then
            MsgBox("خطأ في رقم الحساب او البين كود")
            Exit Sub
        End If
        If st = 1 Then
            MsgBox("الحساب موقوف مؤقتا")
            Exit Sub
        End If
        ac = TextBox1.Text
        Form2.Show()
        Me.Hide()
    End Sub
End Class
