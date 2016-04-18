Imports MySql.Data.MySqlClient

Public Class transReturn

    Dim conn As New MySqlConnection
    Dim dvdsCommand As New MySqlCommand
    Dim dvdsAdapter As New MySqlDataAdapter
    Dim dvdsData As New DataTable

    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Dim SQL As String

    Public Sub connect()
        Dim DatabaseName As String = "vbtest"
        Dim server As String = "localhost"
        Dim userName As String = "root"
        Dim password As String = "mypassword2"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            conn.Open()

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim d1 As DVD = user.dvd
        Dim c1 As Customer = user.customer
        Dim db As dbControler = New dbControler


        connect()

        SQL = "DELETE FROM RENTALS WHERE MEMBERID = '" & c1.getMemberID & "' AND UPC = '" & d1.getUPC & "'"

        Try

            conn.Open()

            dvdsCommand.Connection = conn
            dvdsCommand.CommandText = SQL
            dvdsAdapter.SelectCommand = dvdsCommand
            dvdsAdapter.Fill(dvdsData)

            '  DataGridView1.DataSource = rentalsdata


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        db.connect()
        db.updateDVD(d1)



    End Sub

    Private Sub transReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d1 As DVD = user.dvd
        Dim c1 As Customer = user.customer


    End Sub
End Class