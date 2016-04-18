Imports MySql.Data.MySqlClient



Public Class empInfo

    Dim conn As New MySqlConnection
    Dim rentalscommand As New MySqlCommand
    Dim rentalsadapter As New MySqlDataAdapter
    Dim rentalsdata As New DataTable

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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.ClearSelection()
        Dim e1 As Employee = user.employee
        SQL = "SELECT WORKDAY, TIMESTART,TIMEEND, HOURSDAYSAVAILABLE FROM SCHEDULES WHERE EMPLOYEEID =  '" & e1.getEmpID & "'"

        connect()


        DataGridView1.DataSource = rentalsdata

        Try

            conn.Open()

            rentalscommand.Connection = conn
            rentalscommand.CommandText = SQL
            rentalsadapter.SelectCommand = rentalscommand
            rentalsadapter.Fill(rentalsdata)

            DataGridView1.DataSource = rentalsdata


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try




        'empSchedule.Show()
        'Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        employeeUI.Show()
        Me.Hide()

    End Sub

    Private Sub empInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim e1 As Employee = user.employee
        Dim a1 As address = user.address

        nametxt.Text = e1.getName
        phonetxt.Text = e1.getPhone
        dobtxt.Text = e1.getDOB
        hiretxt.Text = e1.getDateHired
        sttxt.Text = a1.getStreet
        ctytxt.Text = a1.getCity
        statetxt.Text = a1.getState
        ziptxt.Text = a1.getzip




    End Sub
End Class