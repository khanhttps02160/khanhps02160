Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class LoaiSP
    Dim tb As New DataTable
    Dim conectrt As String = "workstation id=khanhps02160.mssql.somee.com;packet size=4096;user id=khanh02160;pwd=123456aA;data source=khanhps02160.mssql.somee.com;persist security info=False;initial catalog=khanhps02160"
    Dim ketnoi As New SqlConnection(conectrt)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtma.Text = DataGridView1.Item(0, index).Value
        txtten.Text = DataGridView1.Item(1, index).Value
    End Sub
    Public Sub loadData()
        Dim ketnoi As New SqlConnection(conectrt)
        Dim sqlAdapter As New SqlDataAdapter("select * from loaisanpham", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub
    Private Sub LoaiSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim stadd As String = "insert into loaisanpham values (@MaLoai,@TenLoai  )"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaLoai", txtma.Text)
            com.Parameters.AddWithValue("@TenLoai", txtten.Text)
            
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "UPDATE LoaiSanPham Set TenLoai = @TenLoai where MaLoai= @MaLoai "
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaLoai", txtma.Text)
            com.Parameters.AddWithValue("@TenLoai", txtten.Text)
            
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ketnoi As New SqlConnection(conectrt)
        ketnoi.Open()
        Dim stadd As String = "Delete From loaiSanPham Where MaLoai=@MaLoai"
        Dim com As SqlCommand = New SqlCommand(stadd, ketnoi)
        Try
            com.Parameters.AddWithValue("@MaLoai", txtma.Text)
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