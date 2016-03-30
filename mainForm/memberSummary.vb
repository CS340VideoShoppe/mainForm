Imports MySql.Data.MySqlClient

Public Class memberSummary

    Dim conn As New MySqlConnection
    Dim MembersCommand As New MySqlCommand
    Dim MembersAdapter As New MySqlDataAdapter
    Dim MembersData As New DataTable
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SQL = "SELECT * FROM MEMBERS "
        Dim c As dbControler = New dbControler

        c.connect()

        c.displayMember()

        DataGridView1.DataSource = c.MembersData
        Try

            conn.Open()

            MembersCommand.Connection = conn
            MembersCommand.CommandText = SQL
            MembersAdapter.SelectCommand = MembersCommand
            MembersAdapter.Fill(MembersData)

            DataGridView1.DataSource = MembersData


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub memberSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        member.Show()
        Me.Hide()

    End Sub
End Class