Imports MySql.Data.MySqlClient

Public Class dbControler
    Dim conn As New MySqlConnection
    Dim MembersCommand As New MySqlCommand
    Dim MembersAdapter As New MySqlDataAdapter
    Public MembersData As New DataTable

    Dim DVDsCommand As New MySqlCommand
    Dim DVDsAdapter As New MySqlDataAdapter
    Public DVDsData As New DataTable

    Dim CategoriesCommand As New MySqlCommand
    Dim CategoriesAdapter As New MySqlDataAdapter
    Public CategoriesData As New DataTable

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

    Public Sub AddMember(Customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "INSERT INTO Members(memberID, name, phone, emailAddress) Values('" & Customer.getMemberID & "', '" + Customer.getName &
            "', '" + Customer.getPhone & "', '" & Customer.getEmail & "')"
        Try
            dbcomm = New MySqlCommand(SQL, conn)
            dbread = dbcomm.ExecuteReader()
            dbread.Close()
        Catch ex As Exception
            MsgBox("Error in saving to Database. Error is :" & ex.Message)
            dbread.Close()
            Exit Sub
        End Try
        MsgBox("Success")

        conn.Close()
    End Sub

    Public Sub displayMember()
        SQL = "SELECT * FROM MEMBERS "

        Try

            conn.Open()

            MembersCommand.Connection = conn
            MembersCommand.CommandText = SQL
            MembersAdapter.SelectCommand = MembersCommand
            MembersAdapter.Fill(MembersData)

        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Public Sub searchMember()

    End Sub

    Public Sub AddDvd(DVD As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "INSERT INTO DVDs(UPC, title, status) Values('" & DVD.getUPC & "', '" + DVD.getTitle &
            "', '" + DVD.getStatus & "')"
        Try
            dbcomm = New MySqlCommand(SQL, conn)
            dbread = dbcomm.ExecuteReader()
            dbread.Close()
        Catch ex As Exception
            MsgBox("Error in saving to Database. Error is :" & ex.Message)
            dbread.Close()
            Exit Sub
        End Try
        MsgBox("Success")

        conn.Close()

    End Sub

    Public Sub displayDVD()

        SQL = "SELECT * DVDs "

        Try

            conn.Open()

            MembersCommand.Connection = conn
            MembersCommand.CommandText = SQL
            MembersAdapter.SelectCommand = MembersCommand
            MembersAdapter.Fill(MembersData)

        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Public Sub searchDVD()

    End Sub

    Public Sub addCreditCard(creditCard As creditCard)

    End Sub

    Public Sub displayCreditCard()

    End Sub

    Public Sub addCategory(DVD As DVD)

        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "INSERT INTO Categories(UPC, genre, language, releaseDate) Values('" & DVD.getUPC & "', '" + DVD.getGenre &
            "', '" + DVD.getLanguage & "', '" + DVD.getReleaseDate & "')"
        Try
            dbcomm = New MySqlCommand(SQL, conn)
            dbread = dbcomm.ExecuteReader()
            dbread.Close()
        Catch ex As Exception
            MsgBox("Error in saving to Database. Error is :" & ex.Message)
            dbread.Close()
            Exit Sub
        End Try
        MsgBox("Success")

        conn.Close()

    End Sub

    Public Sub addDVD_Info(DVD As DVD)

    End Sub

    Public Sub completeMember()

    End Sub

End Class
