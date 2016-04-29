Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions



Public Class empInfo
    Dim validInput As Boolean = True

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

            ' MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        rentalsdata.Clear()

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
        Me.Close()


    End Sub

    Private Sub empInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        centerButton()

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
        empID.Text = e1.getEmpID
        passwordtxt.Text = e1.getPassword
        logintxt.Text = e1.getLogin





    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        isValid()

        If validInput = True Then
            Dim e1 As Employee = New Employee(empID.Text, nametxt.Text, phonetxt.Text, hiretxt.Text, dobtxt.Text, logintxt.Text, passwordtxt.Text)
            Dim a1 As address = New address(empID.Text, sttxt.Text, ctytxt.Text, statetxt.Text, ziptxt.Text)
            Dim db As dbControler = New dbControler

            db.connect()
            db.updateEmployee(e1)
            db.updateEmployeeAddress(e1, a1)

            MessageBox.Show("Employee Added Successfully")


        Else
            MessageBox.Show("Error in savaing employee data")

        End If



    End Sub

    Public Sub isValid()
        If Not Regex.Match(sttxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(sttxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Street")



        ElseIf Not Regex.Match(ctytxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(ctytxt.Text) Or Regex.Match(ctytxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid city")



        ElseIf Not Regex.IsMatch(ziptxt.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(ziptxt.Text) Or ziptxt.Text.Length <> 5 Then
            validInput = False

            MessageBox.Show("Invalid zip")



        ElseIf Not Regex.Match(passwordtxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(passwordtxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Password")
        Else
            validInput = True


        End If




    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        empNewSchedule.Show()
        Me.Close()

    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class