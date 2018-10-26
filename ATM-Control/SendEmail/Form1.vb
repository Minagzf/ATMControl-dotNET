Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim E1 As New System.Net.Mail.SmtpClient()
        E1.Credentials = New Net.NetworkCredential("mina.gzf@gmail.com", "01221541215")
        E1.EnableSsl = True
        E1.Port = 587
        E1.Host = "smtp.gmail.com"
        E1.Send("MinaGamal <Mina.gzf@gmail.com>", "Xicus_bone@yahoo.com", "Test Email", "This is a test email")
        MsgBox("تم ارسال الرسالة بنجاح")
    End Sub
End Class
