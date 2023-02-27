Imports System.Data.SqlClient
Public Class tur
    Private Sub tur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verigetir()
    End Sub
    Public Sub verigetir()
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "Select * from tur"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv, "tur")
        DataGridView1.DataSource = dsv.Tables("tur")
        Connection.Close()
    End Sub
    Private Sub temizle()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Connection As New SqlConnection
        Dim dsv As New DataSet
        Connection.ConnectionString = "Data Source=Localhost;Initial Catalog=kutuphane;User ID=ertu06;Password='0606'"
        Connection.Open()
        Dim SQLcommand As New SqlCommand
        Dim sorgu = "insert into tur (turadi) values('" + TextBox2.Text + "')"
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
        Dim sorgu = "update tur set turadi ='" + TextBox2.Text + "'where turno='" + TextBox1.Text + "'"
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
        Dim sorgu = "delete from tur where turno='" + TextBox1.Text + "'"
        SQLcommand.Connection = Connection
        Dim adaptor = New SqlDataAdapter(sorgu, Connection) 'baglantiyi acar
        adaptor.Fill(dsv)
        verigetir()
        temizle()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value.ToString()
        TextBox2.Text = DataGridView1(1, DataGridView1.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        verigetir()
        temizle()
    End Sub
End Class