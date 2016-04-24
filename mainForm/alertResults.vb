Imports MySql.Data.MySqlClient

Public Class alertResults

    Dim conn As New MySqlConnection
    Dim memberscommand As New MySqlCommand
    Dim membersadapter As New MySqlDataAdapter
    Dim membersdata As New DataTable

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
        memInfo.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SQL = "SELECT * FROM MEMBERS Inner JOIN ALERTS ON MEMBERS.MEMBERID = Alerts.MEMBERID "

        connect()

        DataGridView1.DataSource = MembersData

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If RadioButton1.Checked Then
            SQL = "SELECT * FROM MEMBERS Inner JOIN ALERTS ON MEMBERS.MEMBERID = Alerts.MEMBERID AND MEMBERS.NAME =  '" & srch.Text & "'"

            connect()

            DataGridView1.DataSource = membersdata

            Try

                conn.Open()

                memberscommand.Connection = conn
                memberscommand.CommandText = SQL
                membersadapter.SelectCommand = memberscommand
                membersadapter.Fill(membersdata)

                DataGridView1.DataSource = membersdata


            Catch ex As Exception
                MessageBox.Show("Cannot connect to database: ")
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If



    End Sub

    Private Sub alertResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c1 As Customer = user.customer

        SQL = "SELECT * FROM MEMBERS Inner JOIN ALERTS ON MEMBERS.MEMBERID = Alerts.MEMBERID AND MEMBERS.NAME =  '" & c1.getName & "'"

        connect()

        DataGridView1.DataSource = membersdata

        Try

            conn.Open()

            memberscommand.Connection = conn
            memberscommand.CommandText = SQL
            membersadapter.SelectCommand = memberscommand
            membersadapter.Fill(membersdata)

            DataGridView1.DataSource = membersdata


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
End Class