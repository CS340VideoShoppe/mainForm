'This class allows the user to process new rentals, late fee transactions, returns, and launces the alerts and member update forms.
'Users can also delete members
'Uses some database functionality to properly reteive information from the database

Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class memInfo
    Dim validInput As Boolean = True


    Dim conn As New MySqlConnection
    Dim rentalscommand As New MySqlCommand
    Dim rentalsadapter As New MySqlDataAdapter
    Dim rentalsdata As New DataTable

    Dim newCommand As New MySqlCommand
    Dim newAdapter As New MySqlDataAdapter
    Dim newData As New DataTable


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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isValid()

        If validInput = True Then
            Dim a1 As address = New address(ID.Text, street.Text, city.Text, state.Text, zip.Text)

            Dim cr1 As creditCard = New creditCard(creditNum.Text, a1, expDate.Text, memName.Text, " ", " ")
            Dim c1 As Customer = New Customer(ID.Text, memName.Text, phone.Text, a1, cr1, email.Text, dob.Text)
            user.customer = c1
            user.address = a1
            user.creditCard = cr1

            memConfirm.Show()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        member.Show()
        Me.Close()

    End Sub


    Private Sub street_TextChanged(sender As Object, e As EventArgs) Handles street.TextChanged


    End Sub

    Private Sub ID_TextChanged(sender As Object, e As EventArgs) Handles ID.TextChanged

    End Sub

    Private Sub memInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()
        Button7.Enabled = False


        Dim c1 As Customer = user.customer
        Dim a1 As address = user.address
        Dim cc As creditCard = user.creditCard
        Dim ren1 As Rental = user.rental


        'get new values for days past and fees, update database here


        connect()

        SQL = "SELECT distinct dvds.upc, DVDS.TITLE, dvds.rentalcount, dvds.numberavailable, RENTALS.RENTALDATE, rentals.dueDate, rentals.daysPast FROM RENTALS, DVDS WHERE DVDS.UPC = RENTALS.UPC AND MEMBERID = '" & c1.getMemberID & "'"

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
        dob.Text = c1.getDOB
        Dim dueDate As Date
        Dim daysPastDue As Int32
        Dim latefees As Double
        Dim currentDate As Date



        'find and display the member's late fees
        Try


            Dim rentDate As Date = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
            currentDate = Date.Now
            ' Dim lateFees As Double
            daysPastDue = Me.DataGridView1.Item(6, Me.DataGridView1.CurrentCell.RowIndex).Value
            user.daysPast = daysPastDue
            dueDate = Me.DataGridView1.Item(5, Me.DataGridView1.CurrentCell.RowIndex).Value
        Catch ex As System.NullReferenceException

        End Try

        If DueDate < Date.Now Then
            connect()

            Dim query As String = "SELECT DVDS.TITLE, rentals.Fees FROM DVDS, RENTALS WHERE RENTALS.UPC = DVDS.UPC AND RENTALS.MEMBERID = '" & c1.getMemberID & "'AND  RENTALS.DUEDATE < '" & Date.Now & "'"
            Try
                Try

                    conn.Open()

                    newCommand.Connection = conn
                    newCommand.CommandText = query
                    newAdapter.SelectCommand = newCommand
                    newAdapter.Fill(newData)

                    DataGridView2.DataSource = newData



                Catch ex As Exception
                    MessageBox.Show("Cannot connect to database: ")
                Finally
                    conn.Close()
                    conn.Dispose()
                 
                End Try
           
                user.fees = Me.DataGridView2.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value
            Catch ex As System.NullReferenceException

            End Try
            Button7.Enabled = True

        End If



        'format as $
        If daysPastDue < 14 Then
            lateFees = 2 * daysPastDue
        Else
            lateFees = 30
        End If




        If daysPastDue > 0 Then
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999)
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






    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.RowCount > 2 Then
            MessageBox.Show("Member has reached the maximum number of rentals")

        Else
            titleInfo.Show()
            Me.Close()
        End If

      

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
       




        ElseIf Not Regex.IsMatch(phone.Text, "[0-9]") Or String.IsNullOrEmpty(phone.Text) Or phone.Text.Length <> 10 Then
            phone.Focus()
            phone.Clear()

            MessageBox.Show("Invalid Phone Number")

            validInput = False
       

        ElseIf Not Regex.Match(street.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(street.Text) Or Not Regex.Match(street.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Street")
       

        ElseIf Not Regex.Match(city.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(city.Text) Or Regex.Match(city.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid city")
       

        ElseIf Not Regex.IsMatch(zip.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(zip.Text) Or zip.Text.Length <> 5 Then
            validInput = False

            MessageBox.Show("Invalid zip")
      

        ElseIf Not Regex.IsMatch(creditNum.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(creditNum.Text) Or creditNum.Text.Length <> 16 Then
            validInput = False

            MessageBox.Show("Invalid Credit Card Number")

        ElseIf ValidateEmail(email.Text) = False Then
            validInput = False
            MessageBox.Show("Invalid Email Address")
        Else
            validInput = True
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

        Try
            upc = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
            rentCount = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value
            onHand = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value + 1

            Dim dvd As DVD = New DVD(upc, rentCount, onHand)
            Dim db As dbControler = New dbControler
            Dim c1 As Customer = user.customer
            db.connect()
            db.deleteRental(dvd, c1)
        Catch ex As System.NullReferenceException
            MessageBox.Show("Invalid Input")
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        payFees.Show()
        Me.Close()

    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub

   
End Class