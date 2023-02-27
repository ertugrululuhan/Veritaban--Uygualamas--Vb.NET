Imports System.Data.SqlClient
Public Class islem
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "insert into islem (ogrno, kitapno, atarih, vtarih) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + DateTimePicker1.Value + "','" + DateTimePicker2.Value + "')"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
    End Sub

    Private Sub temizle()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
    End Sub
    Private Sub islem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verigetir()
    End Sub
    Public Sub verigetir()
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "Select * from islem"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "islem")
        DataGridView1.DataSource = dsv.Tables("islem")
        Connection.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "update islem set ogrno ='" + TextBox2.Text + "',kitapno= '" + TextBox3.Text + "',atarih='" + DateTimePicker1.Value + "',vtarih= '" + DateTimePicker2.Value + "'where islemno=" + TextBox1.Text
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "delete from islem where islemno='" + TextBox1.Text + "'"
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
        Dim sorgu = "select* from islem where islemno= '" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "islem")
        DataGridView1.DataSource = dsv.Tables("islem")
        temizle()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox2.Text = DataGridView1(1, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox3.Text = DataGridView1(2, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        DateTimePicker1.Value = DataGridView1(3, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        DateTimePicker2.Value = DataGridView1(4, DataGridView1.CurrentCell.RowIndex).Value.ToString()
    End Sub
End Class