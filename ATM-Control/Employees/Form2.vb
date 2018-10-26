Imports System.Data.SqlClient


Public Class Form2

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button5.Enabled = False
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If IsNumeric(e.KeyChar) Then
            SendKeys.Send(Chr(8))
        End If

        If e.KeyChar = Chr(13) Then
            TextBox2.Select()
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

        If IsNumeric(e.KeyChar) Then
            SendKeys.Send(Chr(8))
        End If

        If e.KeyChar = Chr(13) Then
            TextBox3.Select()
        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If IsNumeric(e.KeyChar) Then
            SendKeys.Send(Chr(8))
        End If

        If e.KeyChar = Chr(13) Then
            TextBox4.Select()
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress

        If e.KeyChar = Chr(13) Then
            TextBox5.Select()
        End If

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Select()

        End If
    End Sub



    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox7.Select()
        End If
    End Sub


    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox8.Select()
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox9.Select()
        End If
    End Sub





    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
        Button5.Enabled = True

        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        Dim txt As Control

        For Each txt In GroupBox1.Controls
            If txt.GetType() = GetType(TextBox) Then
                txt.Text = ""
            End If
        Next

        Dim chk As CheckBox
        For Each chk In GroupBox2.Controls
            chk.Checked = False
        Next
        TextBox1.Select()
        Label13.Text = GetNewID("employees")

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        TextBox10.Text = TextBox1.Text & Label13.Text
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox11.Text = RSet(System.Guid.NewGuid().ToString(), 8)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        comm.Connection = conn
        comm.CommandType = CommandType.Text
        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("@firstname", TextBox1.Text)
        comm.Parameters.AddWithValue("@lastname", TextBox2.Text)
        comm.Parameters.AddWithValue("@jobtitle", TextBox3.Text)
        comm.Parameters.AddWithValue("@businessphone", TextBox4.Text)
        comm.Parameters.AddWithValue("@homephone", TextBox5.Text)
        comm.Parameters.AddWithValue("@mobilephone", TextBox6.Text)
        comm.Parameters.AddWithValue("@email", TextBox8.Text)
        comm.Parameters.AddWithValue("@street", TextBox9.Text)
        comm.Parameters.AddWithValue("@city", TextBox7.Text)
        comm.Parameters.AddWithValue("@username", TextBox10.Text)
        comm.Parameters.AddWithValue("@password", TextBox11.Text)
        comm.Parameters.AddWithValue("@status", CheckBox1.Checked)
        comm.Parameters.AddWithValue("@customerform", CheckBox3.Checked)
        comm.Parameters.AddWithValue("@depositsform", CheckBox4.Checked)
        comm.Parameters.AddWithValue("@withdrawalsform", CheckBox5.Checked)
        comm.Parameters.AddWithValue("@newcustomer", CheckBox6.Checked)
        comm.Parameters.AddWithValue("@deletecustomer", CheckBox7.Checked)
        comm.Parameters.AddWithValue("@admin", CheckBox2.Checked)
        comm.CommandText = "insert into Employees (firstname,LastName,jobtitle,businessphone,homephone,mobilephone,email,street," &
            "city,[username],[password],status,customerform,depositsform,WithdrawalsForm,newcustomer,deletecustomer," &
            "admin) values (@firstname,@lastname,@jobtitle,@businessphone,@homephone,@mobilephone,@email,@street," &
            "@city,@username,@password,@status,@customerform,@depositsform,@withdrawalsform,@newcustomer,@deletecustomer,@admin)"
        Dim affected As Integer
        conn.Open()
        affected = comm.ExecuteNonQuery()
        If affected <= 0 Then
            MsgBox("لم يتم تسجيل البيانات")
            Exit Sub
        Else
            MsgBox("تم تسجيل بيانات الموظف الجديد بنجاح")
            conn.Close()
            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = False
            Button5.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim UID As String
        UID = TextBox12.Text
        If Trim(UID) = "" Then Exit Sub
        comm.CommandType = CommandType.Text
        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("@uid", UID)
        comm.CommandText = "select * from employees where username=@uid"
        conn.Open()
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr("FirstName")
            TextBox2.Text = dr("LastName")
            TextBox3.Text = dr("JobTitle")
            TextBox4.Text = dr("BusinessPhone")
            TextBox5.Text = dr("HomePhone")
            TextBox6.Text = dr("MobilePhone")
            TextBox8.Text = dr("Email")
            TextBox9.Text = dr("Street")
            TextBox7.Text = dr("City")
            TextBox10.Text = dr("UserName")
            TextBox11.Text = dr("PassWord")
            CheckBox1.Checked = dr("Status")
            CheckBox3.Checked = dr("CustomerForm")
            CheckBox4.Checked = dr("DepositsForm")
            CheckBox5.Checked = dr("WithdrawalsForm")
            CheckBox6.Checked = dr("NewCustomer")
            CheckBox7.Checked = dr("DeleteCustomer")
            CheckBox2.Checked = dr("Admin")
            Button4.Enabled = True
            Button8.Enabled = True
            GroupBox1.Enabled = True
            GroupBox2.Enabled = True
            dr.Close()
            conn.Close()
        Else
            MsgBox("Employees not found")
            dr.Close()
            conn.Close()
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim UID As String
        UID = TextBox12.Text
        comm.Connection = conn
        comm.CommandType = CommandType.Text
        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("@firstname", TextBox1.Text)
        comm.Parameters.AddWithValue("@lastname", TextBox2.Text)
        comm.Parameters.AddWithValue("@jobtitle", TextBox3.Text)
        comm.Parameters.AddWithValue("@businessphone", TextBox4.Text)
        comm.Parameters.AddWithValue("@homephone", TextBox5.Text)
        comm.Parameters.AddWithValue("@mobilephone", TextBox6.Text)
        comm.Parameters.AddWithValue("@email", TextBox8.Text)
        comm.Parameters.AddWithValue("@street", TextBox9.Text)
        comm.Parameters.AddWithValue("@city", TextBox7.Text)
        comm.Parameters.AddWithValue("@username", TextBox10.Text)
        comm.Parameters.AddWithValue("@password", TextBox11.Text)
        comm.Parameters.AddWithValue("@status", CheckBox1.Checked)
        comm.Parameters.AddWithValue("@customerform", CheckBox3.Checked)
        comm.Parameters.AddWithValue("@depositsform", CheckBox4.Checked)
        comm.Parameters.AddWithValue("@withdrawalsform", CheckBox5.Checked)
        comm.Parameters.AddWithValue("@newcustomer", CheckBox6.Checked)
        comm.Parameters.AddWithValue("@deletecustomer", CheckBox7.Checked)
        comm.Parameters.AddWithValue("@admin", CheckBox2.Checked)
        comm.Parameters.AddWithValue("@uid", UID)
        comm.CommandText = "UPDATE Employees SET FirstName=@FirstName ,LastName=@LastName ,JobTitle=@JobTitle," &
                           "BusinessPhone=@BusinessPhone,HomePhone=@HomePhone,MobilePhone=@MobilePhone," &
                           "Email=@Email,Street=@Street,City=@City,[UserName]=@UserName ,[PassWord]=@PassWord," &
                           "Status=@Status ,CustomerForm=@CustomerForm,DepositsForm=@DepositsForm ," &
                           "WithdrawalsForm=@WithdrawalsForm,NewCustomer=@NewCustomer ,DeleteCustomer=@DeleteCustomer," &
                           "Admin=@Admin WHERE username=@uid"
        conn.Open()
        Dim aff As Integer
        aff = comm.ExecuteNonQuery
        conn.Close()

        If aff > 0 Then
            MessageBox.Show("تم تحديث بيانات العميل بنجاح")
        Else
            MessageBox.Show("فشلت عملية تحديث البيانات")
        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox12.AutoCompleteCustomSource.Clear()
        comm.CommandType = CommandType.Text
        comm.CommandText = "select username from employees"
        Dim dr As SqlDataReader
        conn.Open()
        dr = comm.ExecuteReader
        Do While dr.Read
            TextBox12.AutoCompleteCustomSource.Add(dr("username"))
        Loop
        dr.Close()
        conn.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If MsgBox("هل انت متأكد من حذف هذا الموظف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim UID As String
            UID = TextBox12.Text
            comm.CommandType = CommandType.Text
            comm.Parameters.Clear()
            comm.Parameters.AddWithValue("@uid", UID)
            comm.CommandText = "delete  from employees where username=@uid"
            conn.Open()
            Dim aff As Integer = comm.ExecuteNonQuery()
            If aff > 0 Then
                MessageBox.Show("تم الحذف بنجاح")
            Else
                MsgBox("فشلت العملية")
            End If
            conn.Close()
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        Button5.Enabled = False
        Button4.Enabled = False
        Button8.Enabled = False
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        Dim txt As Control
        For Each txt In GroupBox1.Controls
            If txt.GetType() = GetType(TextBox) Then
                txt.Text = ""
            End If
        Next
        Dim chk As CheckBox
        For Each chk In GroupBox2.Controls
            chk.Checked = False
        Next
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Form3.ShowDialog()

    End Sub

End Class