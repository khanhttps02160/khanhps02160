Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class NhanVien
    Dim tb As New DataTable
    Dim conectrt As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"
    Dim ketnoi As New SqlConnection(conectrt)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtma.Text = DataGridView1.Item(0, index).Value
        txtten.Text = DataGridView1.Item(1, index).Value
        txtgt.Text = DataGridView1.Item(2, index).Value
        txtsdt.Text = DataGridView1.Item(3, index).Value
        txtuser.Text = DataGridView1.Item(4, index).Value
        txtpass.Text = DataGridView1.Item(5, index).Value
    End Sub
    Public Sub loadData()
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter("select * from nhanvien", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub NhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter
        Try
            ketnoi.Open()
            sqlAdapter.Fill(tb)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        loadData()
    End Sub

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "insert into NhanVien Values(@MaNhanVien,@TenNhanVien,@GioiTinh,@SoDienThoai,@Username,@PassWord)"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaNhanVien", txtma.Text)
            com.Parameters.AddWithValue("@TenNhanVien", txtten.Text)
            com.Parameters.AddWithValue("@GioiTinh", txtgt.Text)
            com.Parameters.AddWithValue("@SoDienThoai", txtsdt.Text)
            com.Parameters.AddWithValue("@Username", txtuser.Text)
            com.Parameters.AddWithValue("@PassWord", txtpass.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm Thành Công")
        Catch ex As Exception

        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        loadData()
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "UPDATE NHANVIEN Set TenNhanVien = @TenNhanVien,GioiTinh = @GioiTinh,SoDienThoai = @SoDienThoai,Username = @Username,PassWord = @PassWord WHERE MaNhanVien = @MaNhanVien"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaNhanVien", txtma.Text)
            com.Parameters.AddWithValue("@TenNhanVien", txtten.Text)
            com.Parameters.AddWithValue("@GioiTinh", txtgt.Text)
            com.Parameters.AddWithValue("@SoDienThoai", txtsdt.Text)
            com.Parameters.AddWithValue("@Username", txtuser.Text)
            com.Parameters.AddWithValue("@PassWord", txtpass.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa Thành Công")
        Catch ex As Exception

        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        loadData()
    End Sub

    Private Sub btnxoa_Click(sender As Object, e As EventArgs) Handles btnxoa.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "Delete From nhanvien Where MaNhanVien=@MaNhanVien"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaNhanVien", txtma.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xoá Thành Công")
        Catch ex As Exception

        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        loadData()
    End Sub

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        Application.ExitThread()
    End Sub
End Class