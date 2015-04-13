Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class KhachHang

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub KhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Dim tb As New DataTable
    Dim conectrt As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"
    Dim ketnoi As New SqlConnection(conectrt)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtmakh.Text = DataGridView1.Item(0, index).Value
        txttenkh.Text = DataGridView1.Item(1, index).Value
        txtsdt.Text = DataGridView1.Item(2, index).Value
        txtdiachi.Text = DataGridView1.Item(3, index).Value
        
    End Sub
    Public Sub loadData()
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter("select * from KhachHang", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "insert into khachhang Values(@MaKH,@TenKH,@SDT,@DiaChi)"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaKH", txtmakh.Text)
            com.Parameters.AddWithValue("@TenKH", txttenkh.Text)
            com.Parameters.AddWithValue("@SDT", txtsdt.Text)
            com.Parameters.AddWithValue("@DiaChi", txtdiachi.Text)
           
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

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        Application.Exit()
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "UPDATE KhachHang Set TenKH = @TenKH,SDT = @SDT,DiaChi = @DiaChi WHERE MaKH = @MaKH"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
           com.Parameters.AddWithValue("@MaKH", txtmakh.Text)
            com.Parameters.AddWithValue("@TenKH", txttenkh.Text)
            com.Parameters.AddWithValue("@SDT", txtsdt.Text)
            com.Parameters.AddWithValue("@DiaChi", txtdiachi.Text)
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
        Dim stadd As String = "Delete From khachhang Where MaKH=@MaKH"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaKH", txtmakh.Text)
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