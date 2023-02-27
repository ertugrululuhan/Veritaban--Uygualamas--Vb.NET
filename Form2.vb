Imports System.Data.SqlClient
Public Class kitapform
    Private Sub kitapform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verigetir()
    End Sub
    Private Sub temizle()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Public Sub verigetir()
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "Select * from kitap"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "kitap")
        DataGridView1.DataSource = dsv.Tables("kitap")
        Connection.Close()
        temizle()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "insert into kitap (barkodno, kiapadı, yazarno, turno, sayfasayisi, puan) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "update kitap set barkodno ='" + TextBox2.Text + "',kiapadı= '" + TextBox3.Text + "',yazarno='" + TextBox4.Text + "',turno= '" + TextBox5.Text + "',sayfasayisi='" + TextBox6.Text + "',puan= '" + TextBox7.Text + "'where kitapno=" + TextBox1.Text
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "select* from kitap where kitapno= '" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "kitap")
        DataGridView1.DataSource = dsv.Tables("kitap")
        temizle()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "delete from kitap where kitapno='" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        verigetir()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox2.Text = DataGridView1(1, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox3.Text = DataGridView1(2, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox4.Text = DataGridView1(3, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox5.Text = DataGridView1(4, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox6.Text = DataGridView1(5, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox7.Text = DataGridView1(6, DataGridView1.CurrentCell.RowIndex).Value.ToString()
    End Sub
End Class