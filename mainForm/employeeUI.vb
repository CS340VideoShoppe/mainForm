Imports MySql.Data.MySqlClient

Public Class employeeUI

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim empID As String
        Dim name As String
        Dim phone As String
        Dim dateHired As Date
        Dim dob As Date
        Dim login As String
        Dim password As String
        Dim street As String
        Dim city As String
        Dim state As String
        Dim zip As String


        empID = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        Name = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        phone = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        dateHired = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value
        dob = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
        login = Me.DataGridView1.Item(5, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        password = Me.DataGridView1.Item(6, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        street = Me.DataGridView1.Item(8, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        city = Me.DataGridView1.Item(9, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        state = Me.DataGridView1.Item(10, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        zip = Me.DataGridView1.Item(11, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString


        Dim e1 As Employee = New Employee(empID, name, phone, dateHired, dob, login, password)
        Dim a1 As address = New address(empID, street, city, state, zip)

        user.address = a1
        user.employee = e1



        empInfo.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView1.ClearSelection()
        SQL = "SELECT employee.Name, schedules.scheduleID, schedules.employeeID, schedules.workDay, schedules.timeStart, schedules.timeEnd, schedules.hoursDaysAvailable, employeeaddress.street, employeeaddress.city, employeeaddress.state, employeeaddress.zipCode FROM SCHEDULES INNER join EMPLOYEEADDRESS on schedules.employeeID = employeeaddress.employeeID inner join employee on schedules.employeeID = employee.employeeID"

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



        '  empSchOverview.Show()
        '  Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        empAdd.Show()


        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Main.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SQL = "SELECT * FROM EMPLOYEE LEFT JOIN EMPLOYEEADDRESS ON EMPLOYEE.EMPLOYEEID = EMPLOYEEADDRESS.EMPLOYEEID"

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

    End Sub
End Class
