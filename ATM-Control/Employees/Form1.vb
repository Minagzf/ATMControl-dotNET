Imports System.Data.SqlClient

Public Class Form1


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userid As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        comm.CommandType = CommandType.StoredProcedure
        comm.CommandText = "IsAdmin"
        comm.Connection = conn

        comm.Parameters.Clear()
        comm.Parameters.AddWithValue("@UID", userid)
        comm.Parameters.AddWithValue("@PWD", password)
        conn.Open()
        Dim returnvalue As SqlParameter = comm.Parameters.Add("@Return_Value", SqlDbType.Int)
        returnvalue.Direction = ParameterDirection.ReturnValue
        comm.ExecuteNonQuery()
        Dim i As Integer
        i = returnvalue.Value
        conn.Close()
        If i = 0 Then
            MsgBox("خطأ في اسم المستخدم او الرقم السري")
            Exit Sub
        End If
        If i = 1 Then
            MsgBox("غير مصرح لك بالدخول هنا")
            End
        End If
        If i = 2 Then
            MsgBox("هذا المستخدم موقوف مؤقتاً")
            End
        End If
        Me.Hide()
        Form2.Show()





        'Dim str As String
        'str = "select * from employees where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'"
        'Employees.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Employees.Open(str, Cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        'If Employees.EOF = True Or Employees.BOF = True Then
        '    MsgBox("User or password not valid")
        '    Employees.Close()
        '    Cn.Close()
        '    Exit Sub
        'End If

        'If Employees("Admin").Value = False Then
        '    MsgBox("عفواً ليس لديك صلاحية للدخول هنا")
        '    End
        'End If

        'If Employees("Status").Value = False Then
        '    MsgBox("هذا الحساب موقوف مؤقتا")
        '    End
        'End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = CnStr
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Chr(13) Then
            TextBox2.Select()
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

        If e.KeyChar = Chr(13) Then

            Button1.Select()

        End If

    End Sub

End Class
