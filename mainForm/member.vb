Imports MySql.Data.MySqlClient

Public Class member

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

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SQL = "SELECT * FROM MEMBERS Inner JOIN MEMBERADDRESS ON MEMBERS.MEMBERID = MEMBERADDRESS.MEMBERID Inner JOIN CREDITCARD ON MEMBERS.MEMBERID = CREDITCARD.MEMBERID AND MEMBERS.NAME = '" & nameSearch.Text & "'"
       
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        customerAdd.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()

        SQL = "SELECT * FROM MEMBERS LEFT JOIN MEMBERADDRESS ON MEMBERS.MEMBERID = MEMBERADDRESS.MEMBERID Left JOIN CREDITCARD ON MEMBERS.MEMBERID = CREDITCARD.MEMBERID"

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
       
      

        id = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        name = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        phone = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        email = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        street = Me.DataGridView1.Item(5, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        city = Me.DataGridView1.Item(6, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        state = Me.DataGridView1.Item(7, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        zip = Me.DataGridView1.Item(8, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        card = Me.DataGridView1.Item(10, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        expDate = Me.DataGridView1.Item(11, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        'rentals
        ' rentID = Me.DataGridView1.Item(13, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        ' upc = Me.DataGridView1.Item(14, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        ' dueDate = Me.DataGridView1.Item(15, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        ' price = Me.DataGridView1.Item(16, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString


        Dim c1 As Customer = New Customer(id, name, phone, email)
        Dim a1 As address = New address(id, street, city, state, zip)
        Dim cc As creditCard = New creditCard(id, card, expDate)


        ' Dim ren1 As Rental = New Rental(rentID, id, upc, dueDate, price)



        'set up sql to get email, address, rentals, wishlist, etc


        user.customer = c1
        user.address = a1
        user.creditCard = cc
        ' user.rental = ren1

        memInfo.Show()
        Me.Close()






    End Sub
End Class
