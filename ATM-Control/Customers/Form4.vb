Public Class Form4
    Dim ss As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = DR("Firstname")
        TextBox2.Text = DR("LastName")
        TextBox3.Text = DR("Company")
        TextBox4.Text = DR("JobTitle")
        TextBox5.Text = DR("BusinessPhone")
        TextBox6.Text = DR("HomePhone")
        TextBox7.Text = DR("MobilePhone")
        TextBox8.Text = DR("Email")
        TextBox9.Text = DR("Street")
        TextBox10.Text = DR("City")
        TextBox11.Text = DR("AccountNo")
        TextBox12.Text = DR("PinCode")
        CheckBox1.Checked = DR("Status")
        DR.Close()
        Conn.Close()
        comm.CommandText = $"select dbo.GetBalance('{TextBox11.Text}' ) as [Balance]"
        Conn.Open()
        DR = comm.ExecuteReader
        DR.Read()
        TextBox13.Text = DR("Balance")
        DR.Close()
        Conn.Close()
        ss = TextBox11.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل انت متأكد من الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            comm.CommandText = $"delete from Customers where accountno=@accountno"
            comm.Parameters.Clear()
            comm.Parameters.AddWithValue("@accountno", TextBox11.Text)
            Conn.Open()
            Dim aff As Integer = comm.ExecuteNonQuery
            If aff > 0 Then
                MsgBox("تم حذف الحساب بنجاح")
            Else
                MessageBox.Show("فشلت عملسة الحذف")
            End If
            Conn.Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        End
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox12.Text = RSet(System.Guid.NewGuid().ToString, 8)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        comm.CommandText = $"UPDATE Customers SET 
	                         FirstName = @FirstName ,LastName = @LastName ,
                             Company = @Company ,JobTitle = @JobTitle ,
                             BusinessPhone = @BusinessPhone ,HomePhone= @HomePhone ,
                             MobilePhone = @MobilePhone,Email = @Email ,
                             Street = @Street,City = @City ,AccountNo = @AccountNo ,
                             PinCode = @PinCode ,[Status] = @Status WHERE accountno=@accno"
        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("@Firstname", TextBox1.Text)
        comm.Parameters.AddWithValue("@LastName", TextBox2.Text)
        comm.Parameters.AddWithValue("@Company", TextBox3.Text)
        comm.Parameters.AddWithValue("@JobTitle", TextBox4.Text)
        comm.Parameters.AddWithValue("@BusinessPhone", TextBox5.Text)
        comm.Parameters.AddWithValue("@HomePhone", TextBox6.Text)
        comm.Parameters.AddWithValue("@MobilePhone", TextBox7.Text)
        comm.Parameters.AddWithValue("@Email", TextBox8.Text)
        comm.Parameters.AddWithValue("@Street", TextBox9.Text)
        comm.Parameters.AddWithValue("@City", TextBox10.Text)
        comm.Parameters.AddWithValue("@AccountNo", TextBox11.Text)
        comm.Parameters.AddWithValue("@PinCode", TextBox12.Text)
        comm.Parameters.AddWithValue("@Status", CheckBox1.Checked)
        comm.Parameters.AddWithValue("@accno", ss)
        Conn.Open()
        Dim aff As Int16
        aff = comm.ExecuteNonQuery
        If aff > 0 Then
            MsgBox("تم تحديث البيانات بنجاح")
        Else
            MessageBox.Show("لم يتم تحديث البيانات")
        End If
        Conn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form6.ShowDialog()

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form7.ShowDialog()

    End Sub

End Class