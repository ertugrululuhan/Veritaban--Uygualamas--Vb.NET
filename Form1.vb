Imports System.Data.SqlClient

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verigetir()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "insert into ogrenci (ograd,ogrsoyad,cinsiyet,dtarih,bolum) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DateTimePicker1.Value + "','" + TextBox5.Text + "')"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "ogrenci")
        DataGridView1.DataSource = dsv.Tables("ogrenci")

        verigetir()

    End Sub

    Public Sub verigetir()
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "Select * from ogrenci"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "ogrenci")
        DataGridView1.DataSource = dsv.Tables("ogrenci")
        Connection.Close()
        temizle()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "update ogrenci set ograd='" + TextBox2.Text + "',ogrsoyad='" + TextBox3.Text + "',cinsiyet='" + TextBox4.Text + "',dtarih='" + DateTimePicker1.Value + "',bolum='" + TextBox5.Text + "'where ogrno='" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()

    End Sub
    Private Sub temizle()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        DateTimePicker1.Value = Now
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox2.Text = DataGridView1(1, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox3.Text = DataGridView1(2, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox4.Text = DataGridView1(3, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        If DataGridView1(4, DataGridView1.CurrentCell.RowIndex).Value.ToString() <> "" Then
            DateTimePicker1.Value = DataGridView1(4, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        End If
        TextBox5.Text = DataGridView1(5, DataGridView1.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub kayitsilbutton_Click(sender As Object, e As EventArgs) Handles kayitsilbutton.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "delete from ogrenci where ogrno='" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tur.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "select* from ogrenci where ogrno= '" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "ogrenci")
        DataGridView1.DataSource = dsv.Tables("ogrenci")
        temizle()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        verigetir()
        temizle()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        yazar.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        kitapform.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        islem.ShowDialog()
    End Sub
End Class
