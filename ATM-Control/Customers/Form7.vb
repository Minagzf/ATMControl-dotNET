Imports System.Data.SqlClient

Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dap As New SqlDataAdapter($"exec custactions {Form4.TextBox11.Text}", Conn)
        Dim ds As New DataSet
        dap.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Refresh()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Dispose()

    End Sub
End Class