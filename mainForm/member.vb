Imports MySql.Data.MySqlClient
'This method allows the user to view all members, search for members, select a single member, and launch the add member form
'It contains some database functionality for propertly retrieving member information 
Public Class member
    Dim isNull As Boolean = False


    Dim conn As New MySqlConnection
    Dim MembersCommand As New MySqlCommand
    Dim MembersAdapter As New MySqlDataAdapter
    Dim MembersData As New DataTable
    Dim MemberAddressCommand As New MySqlCommand
    Dim memberaddressadapter As New MySqlDataAdapter
    Dim MemberAddressData As New DataTable
    Dim dvdsCommand As New MySqlCommand
    Dim dvdsAdapter As New MySqlDataAdapter
    Dim dvdsdata As New DataTable
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Method to search for members by phone or name
        'Clears data for new search
        MembersData.Clear()

        SQL = "SELECT distinct members.memberID, members.name, members.phone, members.emailAddress, members.DOB, memberaddress.street, memberaddress.city, memberaddress.state, memberaddress.zipCode, creditcard.number, creditcard.expirationDate FROM MEMBERS LEFT JOIN MEMBERADDRESS ON MEMBERS.MEMBERID = MEMBERADDRESS.MEMBERID Left JOIN CREDITCARD ON MEMBERS.MEMBERID = CREDITCARD.MEMBERID WHERE MEMBERS.NAME LIKE '%" & nameSearch.Text & "%' OR MEMBERS.PHONE = '" & phoneSearch.Text & "' "

        connect()


        DataGridView1.DataSource = MembersData

        Try

            conn.Open()

            MembersCommand.Connection = conn
            MembersCommand.CommandText = SQL
            MembersAdapter.SelectCommand = MembersCommand
            MembersAdapter.Fill(MembersData)

            DataGridView1.DataSource = MembersData

            results()


        Catch ex As Exception
            '  MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        Button5.Enabled = True


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'displays the form to add members
        customerAdd.Show()
        Me.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Me.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Method to display all members to the datagrid
        MembersData.Clear()

        connect()

        SQL = "SELECT distinct members.memberID, members.name, members.phone,  members.emailAddress, members.DOB, memberaddress.street, memberaddress.city, memberaddress.state, memberaddress.zipCode, creditcard.number, creditcard.expirationDate FROM MEMBERS LEFT JOIN MEMBERADDRESS ON MEMBERS.MEMBERID = MEMBERADDRESS.MEMBERID Left JOIN CREDITCARD ON MEMBERS.MEMBERID = CREDITCARD.MEMBERID"

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

        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Button5.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim id As String
        Dim name As String
        Dim phone As String
        Dim email As String
        Dim street As String
        Dim city As String
        Dim state As String
        Dim zip As String
        Dim card As String
        Dim expDate As Date
        Dim dob As Date


        Try
            If Not String.IsNullOrWhiteSpace(Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString) Then

                id = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                name = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                phone = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                email = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                dob = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
                street = Me.DataGridView1.Item(5, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                city = Me.DataGridView1.Item(6, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                state = Me.DataGridView1.Item(7, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                zip = Me.DataGridView1.Item(8, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                card = Me.DataGridView1.Item(9, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
                expDate = Me.DataGridView1.Item(10, Me.DataGridView1.CurrentCell.RowIndex).Value

                Dim c1 As Customer = New Customer(id, name, phone, email, dob)
                Dim a1 As address = New address(id, street, city, state, zip)
                Dim cc As creditCard = New creditCard(id, card, expDate)


                user.customer = c1
                user.address = a1
                user.creditCard = cc

                memInfo.Show()
                Me.Close()
            Else
                MessageBox.Show("Invalid Input")

            End If
        Catch ex As System.NullReferenceException
            MessageBox.Show("Invalid Input")
        End Try

    End Sub

    Public Sub results()

        If String.IsNullOrWhiteSpace(Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString) Or String.IsNullOrEmpty(Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString) Or String.IsNullOrWhiteSpace(Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString) Then
            MessageBox.Show("No results found")
            MembersData.Clear()


        End If
    End Sub

    Private Sub nameSearch_TextChanged(sender As Object, e As EventArgs) Handles nameSearch.TextChanged

    End Sub

    Private Sub member_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        user.isLoggedIn = False
        Logon.Show()
        Me.Hide()
    End Sub
End Class
