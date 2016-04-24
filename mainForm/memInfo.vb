Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class memInfo
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

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isValid()

        If validInput = True Then
            Dim a1 As address = New address(ID.Text, street.Text, city.Text, state.Text, zip.Text)

            Dim cr1 As creditCard = New creditCard(creditNum.Text, a1, expDate.Text, memName.Text, " ", " ")
            Dim c1 As Customer = New Customer(ID.Text, memName.Text, phone.Text, a1, cr1, email.Text)
            user.customer = c1
            user.address = a1
            user.creditCard = cr1

            memConfirm.Show()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        member.Show()
        Me.Hide()

    End Sub


    Private Sub street_TextChanged(sender As Object, e As EventArgs) Handles street.TextChanged


    End Sub

    Private Sub ID_TextChanged(sender As Object, e As EventArgs) Handles ID.TextChanged

    End Sub

    Private Sub memInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim c1 As Customer = user.customer
        Dim a1 As address = user.address
        Dim cc As creditCard = user.creditCard
        Dim ren1 As Rental = user.rental


        connect()

        SQL = "SELECT distinct dvds.upc, DVDS.TITLE, dvds.rentalcount, dvds.numberavailable, RENTALS.RENTALDATE FROM RENTALS, DVDS WHERE DVDS.UPC = RENTALS.UPC AND MEMBERID = '" & c1.getMemberID & "'"

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

        'Check if alerts are needed



        ID.Text = c1.getMemberID
        memName.Text = c1.getName
        phone.Text = c1.getPhone
        email.Text = c1.getEmail
        street.Text = a1.getStreet
        city.Text = a1.getCity
        state.Text = a1.getState
        zip.Text = a1.getzip
        creditNum.Text = cc.getNum
        expDate.Text = cc.getExpDate

        '  ListBox1.Items.Add(ren1.getUPC() & "          " & ren1.getDueDate)

        'find and display the member's late fees
        Dim dueDate As Date = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
        Dim currentDate As Date = Date.Now
        Dim lateFees As Double

        Dim daysPastDue As Int32 = currentDate.Subtract(dueDate).Days
        'format as $
        If daysPastDue < 14 Then
            lateFees = 2 * daysPastDue
        Else
            lateFees = 30
        End If

        If daysPastDue > 0 Then
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999999)
            'If the item is overdue, an overdue alert is automatically created
            Dim title As String = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
            Dim alertMessage As String = c1.getName & " , the following items are overdue: " & title
            Dim alert As Alert = New Alert(num, c1.getMemberID, "Overdue", "Sent", 1, Date.Now, alertMessage)

            Dim db As dbControler = New dbControler

            db.connect()

            db.addAlert(alert)


        End If

        'Another statement for exp credit card alerts
        If cc.getExpDate < currentDate Then
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999999)

            'Create another alert
            Dim alertMessage As String = c1.getName & ",  your credit card has expired on " & cc.getExpDate.ToString
            Dim alert As Alert = New Alert(num, c1.getMemberID, "Exp Crd", "Sent", 1, Date.Now, alertMessage)
            Dim db As dbControler = New dbControler
            db.connect()
            db.addAlert(alert)


        End If


        ListBox2.Items.Add(daysPastDue & " days past due   " & lateFees)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        titleInfo.Show()
        Me.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        alertResults.Show()
        Me.Close()


    End Sub

    Private Sub isValid()


        If Not Regex.Match(memName.Text, "[(a-z)(A-Z)]", RegexOptions.IgnoreCase).Success Or String.IsNullOrEmpty(memName.Text) Or Not memName.Text.Contains(" "c) Or Regex.Match(memName.Text, "[0-9]", RegexOptions.IgnoreCase).Success Then

            MessageBox.Show("Invalid Name")

            memName.Focus()
            memName.Clear()

            validInput = False
        Else



        End If
        If Not Regex.IsMatch(phone.Text, "[0-9]") Or String.IsNullOrEmpty(phone.Text) Or phone.Text.Length <> 10 Then
            phone.Focus()
            phone.Clear()

            MessageBox.Show("Invalid Phone Number")

            validInput = False

        Else

        End If

        If Not Regex.Match(street.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(street.Text) Or Not Regex.Match(street.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Street")

        End If

        If Not Regex.Match(city.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(city.Text) Or Regex.Match(city.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid city")

        End If

        If Not Regex.IsMatch(zip.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(zip.Text) Or zip.Text.Length <> 5 Then
            validInput = False

            MessageBox.Show("Invalid zip")

        End If

        If Not Regex.IsMatch(creditNum.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(creditNum.Text) Or creditNum.Text.Length <> 16 Then
            validInput = False

            MessageBox.Show("Invalid Credit Card Number")

        End If

       

      

        'validate release date


        If ValidateEmail(email.Text) = False Then
            validInput = False
            MessageBox.Show("Invalid Email Address")

        End If





    End Sub

    Public Function ValidateEmail(ByVal strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        isValid()
        If validInput = True Then
            Dim db As dbControler = New dbControler
            Dim c1 As Customer = user.customer


            db.connect()

            db.deleteMember(c1)
            db.deleteCreditCard(c1)
            db.deleteMemberAddress(c1)
            db.deleteRental(c1)

            Me.Close()
            member.Show()

        End If
       

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim upc As String
        Dim onHand As Integer
        Dim rentCount As Integer


        upc = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        rentCount = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value - 1
        onHand = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value + 1
        Dim dvd As DVD = New DVD(upc, rentCount, onHand)
        Dim db As dbControler = New dbControler
        Dim c1 As Customer = user.customer
        db.connect()
        db.deleteRental(dvd, c1)





    End Sub
End Class