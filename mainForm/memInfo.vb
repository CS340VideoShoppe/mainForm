Imports MySql.Data.MySqlClient

Public Class memInfo

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
        memConfirm.Show()

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

        SQL = "SELECT UPC, RENTALDATE FROM RENTALS WHERE MEMBERID = '" & c1.getMemberID & "'"

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
            Dim dueDate As Date = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value
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
            Dim title As String = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
            Dim alertMessage As String = c1.getName & " , the following items are overdue: " & title
            Dim alert As Alert = New Alert("12345678", c1.getMemberID, "Overdue", "Sent", 1, Date.Now, alertMessage)

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
End Class