Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class HoaDon
    Dim tb As New DataTable
    Dim conectrt As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"
    Dim ketnoi As New SqlConnection(conectrt)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtmahd.Text = DataGridView1.Item(0, index).Value
        txtngay.Text = DataGridView1.Item(1, index).Value
        txttien.Text = DataGridView1.Item(2, index).Value
        txtkh.Text = DataGridView1.Item(3, index).Value
        txtnv.Text = DataGridView1.Item(4, index).Value
    End Sub
    Public Sub loadData()
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter("select * from HoaDon", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub
    Private Sub HoaDon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        Application.Exit()
    End Sub

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim ma As String = txtmahd.Text
        Dim stadd As String = "insert into Hoadon Values(@MaHD,@NgayLap,@TongTien,@KhachHang_MaKH,@NhanVien_MaNhanVien)"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaHD", txtmahd.Text)
            com.Parameters.AddWithValue("@NgayLap", txtngay.Text)
            com.Parameters.AddWithValue("@TongTien", txttien.Text)
            com.Parameters.AddWithValue("@KhachHang_MaKH", txtkh.Text)
            com.Parameters.AddWithValue("@NhanVien_MaNhanVien", txtnv.Text)

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
        Dim stadd As String = "UPDATE HoaDon Set NgayLap = @NgayLap,TongTien = @TongTien,KhachHang_MaKH = @KhachHang_MaKH,NhanVien_MaNhanVien = @NhanVien_MaNhanVien WHERE MaHD = @MaHD"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaHD", txtmahd.Text)
            com.Parameters.AddWithValue("@NgayLap", txtngay.Text)
            com.Parameters.AddWithValue("@TongTien", txttien.Text)
            com.Parameters.AddWithValue("@KhachHang_MaKH", txtkh.Text)
            com.Parameters.AddWithValue("@NhanVien_MaNhanVien", txtnv.Text)
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
        Dim stadd As String = "Delete From hoadon Where MaHD=@MaHD"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaHD", txtmahd.Text)
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
End Class