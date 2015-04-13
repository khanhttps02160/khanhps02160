Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class QLSP
    Dim tb As New DataTable
    Dim conectrt As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"
    Dim ketnoi As New SqlConnection(conectrt)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtmasanp.Text = DataGridView1.Item(0, index).Value
        txttensp.Text = DataGridView1.Item(1, index).Value
        txtgia.Text = DataGridView1.Item(2, index).Value
        txtsoluong.Text = DataGridView1.Item(3, index).Value
        txtchitiet.Text = DataGridView1.Item(4, index).Value
        txtmaloai.Text = DataGridView1.Item(5, index).Value
    End Sub

    Public Sub loadData()
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter("select * from SanPham", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub
    
    Private Sub QLSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "UPDATE SanPham Set TenSP = @TenSP,DonGia = @DonGia,SoLuong = @SoLuong,ChiTietSP = @ChiTietSP,LoaiSanPham_MaLoai = @LoaiSanPham_MaLoai WHERE MaSP = @MaSP"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaSP", txtmasanp.Text)
            com.Parameters.AddWithValue("@TenSP", txttensp.Text)
            com.Parameters.AddWithValue("@DonGia", txtgia.Text)
            com.Parameters.AddWithValue("@Soluong", txtsoluong.Text)
            com.Parameters.AddWithValue("@ChitietSP", txtchitiet.Text)
            com.Parameters.AddWithValue("@LoaiSanPham_MaLoai", txtmaloai.Text)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "Delete From SanPham Where MaSP=@MaSP"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaSP", txtmasanp.Text)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "insert into SanPham Values(@MaSP,@TenSP,@DonGia,@SoLuong,@ChitietSP,@LoaiSanPham_MaLoai)"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaSP", txtmasanp.Text)
            com.Parameters.AddWithValue("@TenSP", txttensp.Text)
            com.Parameters.AddWithValue("@DonGia", txtgia.Text)
            com.Parameters.AddWithValue("@Soluong", txtsoluong.Text)
            com.Parameters.AddWithValue("@ChitietSP", txtchitiet.Text)
            com.Parameters.AddWithValue("@LoaiSanPham_MaLoai", txtmaloai.Text)
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

    Private Sub txtsoluong_TextChanged(sender As Object, e As EventArgs) Handles txtsoluong.TextChanged

    End Sub
End Class