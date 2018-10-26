Imports System.Data.SqlClient

Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        comm.Connection = Conn
        comm.CommandType = CommandType.Text
        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("Firstname", TextBox1.Text)
        comm.Parameters.AddWithValue("LastName", TextBox2.Text)
        comm.Parameters.AddWithValue("Company", TextBox3.Text)
        comm.Parameters.AddWithValue("JobTitle", TextBox4.Text)
        comm.Parameters.AddWithValue("BusinessPhone", TextBox5.Text)
        comm.Parameters.AddWithValue("HomePhone", TextBox6.Text)
        comm.Parameters.AddWithValue("MobilePhone", TextBox7.Text)
        comm.Parameters.AddWithValue("Email", TextBox8.Text)
        comm.Parameters.AddWithValue("Street", TextBox9.Text)
        comm.Parameters.AddWithValue("City", TextBox10.Text)
        comm.Parameters.AddWithValue("AccountNo", TextBox11.Text)
        comm.Parameters.AddWithValue("PinCode", TextBox12.Text)
        comm.Parameters.AddWithValue("Status", CheckBox1.Checked)
        comm.CommandText = "INSERT INTO Customers (FirstName,LastName,Company,JobTitle,BusinessPhone,HomePhone," &
           "MobilePhone,Email,Street,City,AccountNo,PinCode,Status) VALUES (@FirstName,@LastName,@Company,@JobTitle," &
           "@BusinessPhone,@HomePhone,@MobilePhone,@Email,@Street,@City,@AccountNo,@PinCode,@Status)"
        Conn.Open()

        Dim aff As Integer
        aff = comm.ExecuteNonQuery
        If aff > 0 Then
            MsgBox("تم تسجيل بيانات العميل الجديد بنجاح", MsgBoxStyle.Information, "عميل جديد")
        Else
            MessageBox.Show("فشلت عملية التسجيل")
        End If
        Conn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub
End Class