Imports System.Data.SqlClient

Public Class Form5

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Trim(TextBox1.Text) = "" And Trim(TextBox2.Text) = "" Then
            MsgBox("يرجى ادخال بين كود جديد ")
            Exit Sub
        End If
        If TextBox1.Text <> TextBox2.Text Then
            MsgBox(" يرجى التأكد من تطابق البين كود الجديد")
            Exit Sub
        End If
        comm.CommandText = $"dbo.UpdatePinCode '{ac}' , '{TextBox1.Text}'"
        Conn.Open()
        Dim dr As SqlDataReader = comm.ExecuteReader
        dr.Read()
        MsgBox(dr(0))
        dr.Close()
        Conn.Close()
        Me.Dispose()
    End Sub


End Class