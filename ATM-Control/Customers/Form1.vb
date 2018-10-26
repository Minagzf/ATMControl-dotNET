Imports System.Data.SqlClient

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ATM;Data Source=."

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        End

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        comm.CommandText = $"select dbo.employeestatus ('{ TextBox1.Text}','{TextBox2.Text}' )"
        comm.Connection = Conn
        Dim H As Integer
        Conn.Open()
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader
        dr.Read()
        H = dr(0)
        Conn.Close()
        If H = 0 Then
            MsgBox("عفوا  اسم المستخدم او كلمة المرور غير صحيحة")
            Exit Sub
        End If
        If H = 1 Then
            MsgBox("البيانات صحيحة لكن المستخدم موقوف مؤقتا")
            Exit Sub
        End If
        EmpUserName = TextBox1.Text
        Me.Hide()
        Form2.Show()
    End Sub
End Class
