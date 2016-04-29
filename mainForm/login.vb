'This first form gets username and password checks for the values in the database

Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Data.SqlClient

Public Class Logon
    Dim con As New MySqlConnection
    Dim MembersCommand As New MySqlCommand
    Dim MembersAdapter As New MySqlDataAdapter
    Public MembersData As New DataTable

    Public com As MySqlCommand
    Public reader As MySqlDataReader
    Public reader2 As MySqlDataReader

    Dim sql As String

    Private NameValid As Boolean
    Private passwordValid As Boolean

    Public Sub connect()
        Dim DatabaseName As String = "vbtest"
        Dim server As String = "localhost"
        Dim userName As String = "root"
        Dim password As String = "mypassword2"
        If Not con Is Nothing Then con.Close()
        con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            con.Open()

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Login in button
       
 
        connect()

        Try
            con.Open()
            com = New MySqlCommand("SELECT employeeid FROM employee WHERE login ='" & uName.Text & "'", con)
            reader = com.ExecuteReader
            If reader.HasRows = True Then
                reader.Close()

                com = New MySqlCommand("SELECT employeeid FROM employee WHERE password = '" & pWord.Text & "' AND login ='" & uName.Text & "'", con)
                reader2 = com.ExecuteReader
                If reader2.HasRows = True Then
                    user.isLoggedIn = True
                    Main.Show()
                    Me.Hide()
                Else
                    MsgBox("Invalid Password")
                    pWord.Focus()
                End If

            ElseIf String.IsNullOrEmpty(uName.Text) Then
                MsgBox("Invalid Username")
                uName.Focus()
            Else
                MsgBox("Invalid Username")
                ' Form2.Show()
            End If

            reader2.Close()
            con.Close()

        Catch ex As Exception
            If Not con.State = ConnectionState.Closed Then
                con.Close()
            End If
            MsgBox("Invalid Username")
        End Try



    End Sub

    Private Sub Logon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()
        uName.Clear()
        pWord.Clear()


    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Resize
        CenterButton()
    End Sub

    Public Sub validLogin()
        Dim log As employeeUser = New employeeUser(uName.Text, pWord.Text)
        user.employeeUser = log
        Dim dbcontroler As dbControler = New dbControler
        dbcontroler.connect()

        dbcontroler.verifyMember(log)

    End Sub
End Class