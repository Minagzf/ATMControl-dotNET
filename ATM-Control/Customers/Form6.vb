﻿Public Class Form6

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim AccNo As Integer = Form4.TextBox11.Text
        Dim Amount As Decimal = TextBox1.Text
        Dim Details As String = $"'{TextBox2.Text}'"
        Dim H As String = $"AddWithdrawal {AccNo} ,{Amount} ,{Details},'{EmpUserName}'"
        comm.CommandText = H
        Conn.Open()
        DR = comm.ExecuteReader
        DR.Read()
        MsgBox(DR(0))
        DR.Close()
        Conn.Close()
        Me.Dispose()
    End Sub
End Class