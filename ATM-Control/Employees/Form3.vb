Imports System.Data.SqlClient

Public Class Form3

    Private Sub Form3_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comm.Connection = conn
        Dim dap As New SqlDataAdapter("select * from employees", conn)
        Dim ds As New DataSet
        dap.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Refresh()
    End Sub
End Class