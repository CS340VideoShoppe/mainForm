'This class initially displays alerts for the member selected and allows the user to search for alerts by member name or phone number
'or view all alerts for every member
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

            ' MsgBox("Connected")
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        memInfo.Show()
        Me.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        membersdata.Clear()


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
        membersdata.Clear()


        SQL = "SELECT DISTINCT MEMBERS.MEMBERID, MEMBERS.NAME, MEMBERS.PHONE, MEMBERS.EMAILADDRESS, MEMBERS.DOB, ALERTS.ALERTID, ALERTS.TYPE, ALERTS.ALERTCOUNT, ALERTS.ALERTSTATUS, ALERTS.MESSAGE FROM MEMBERS Inner JOIN ALERTS ON MEMBERS.MEMBERID = Alerts.MEMBERID AND MEMBERS.NAME like '%" & srch.Text & "%' OR MEMBERS.PHONE = '" & srch.Text & "' "

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

    Private Sub alertResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

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

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class