Imports System.Data.SqlClient
Public Class Login
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
     

        Dim chuoiketnoi As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"

        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdapter As New SqlDataAdapter("select * from NhanVien where Username='" & txtuser.Text & "' and PassWord = '" & txtpas.Text & "' ", ketnoi)
        Dim tb As New DataTable

        Try
            ketnoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("Đăng nhập thành công")
                Main.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai Username Hoặc Password")
                txtuser.Clear()
                txtpas.Clear()

            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtpas.Clear()
        txtuser.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()

    End Sub

    Private Sub txtuser_TextChanged(sender As Object, e As EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
