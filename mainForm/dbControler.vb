'This class controls database functions. It includes methods for inserting, deleting, and updating database tables.

Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Data.SqlClient

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

    Dim employeeLoginCommand As New MySqlCommand
    Dim employeeLoginAdapter As New MySqlDataAdapter
    Public employeeLoginData As New DataTable

    Dim DVD_InfoLoginCommand As New MySqlCommand
    Dim DVD_InfoLoginAdapter As New MySqlDataAdapter
    Public DVD_InfoLoginData As New DataTable

    Dim rentalsCommand As New MySqlCommand
    Dim rentalsAdapter As New MySqlDataAdapter
    Dim rentalslogindata As New DataTable

    Dim employeesCommand As New MySqlCommand
    Dim employeesAdapter As New MySqlDataAdapter
    Dim employeesLoginData As New DataTable

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
        Try
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
        Catch ex As Exception
            MessageBox.Show("Primary Key Already Exists")



        End Try


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

    Public Sub updateMember(Customer As Customer)

        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "UPDATE MEMBERS SET name = '" & Customer.getName & "', phone = '" & Customer.getPhone & "', emailAddress = ' " & Customer.getEmail & "' WHERE memberID = '" & Customer.getMemberID & "' "
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

    Public Sub deleteMember(customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM MEMBERS WHERE MEMBERID = '" & customer.getMemberID & "' "
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

    Public Sub AddDvd(DVD As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "INSERT INTO DVDs(UPC, title, status, rentalCount, numberAvailable) Values('" & DVD.getUPC & "', '" + DVD.getTitle &
            "', '" + DVD.getStatus & "', '" + DVD.getRentCount & "', '" + DVD.getOnHand & "')"
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

    Public Sub updateDVD(DVD As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "UPDATE DVDS SET RENTALCOUNT = '" & DVD.getRentCount & "' , NUMBERAVAILABLE = '" & DVD.getOnHand & "' WHERE UPC = '" & DVD.getUPC & "' "
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

    Public Sub searchDVD()

    End Sub

    Public Sub deleteDVD(dvd As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM DVDS WHERE UPC = '" & dvd.getUPC & "' "
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

    Public Sub deleteCategory(dvd As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM CATEGORIES WHERE UPC = '" & dvd.getUPC & "' "
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

    Public Sub deleteDVDinfo(dvd As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM DVD_INFO WHERE UPC = '" & dvd.getUPC & "' "
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

    Public Sub deleteRental(dvd As DVD)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM RENTALS WHERE UPC = '" & dvd.getUPC & "' "
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

    Public Sub deleteRental(customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM RENTALS WHERE MEMBERID = '" & customer.getMemberID & "' "
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

    Public Sub alterDVD(dvd As DVD)
        Try

            Dim strAccQuery As String = "UPDATE dvds SET title = @title, status = @status, rentalCount = @rentalCount, numberAvailable = @numberAvailable  WHERE UPC = '" & dvd.getUPC & "'"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                ' dbCommand.Parameters.Add(New MySqlParameter("@memberID", customer.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@title", dvd.getTitle))
                dbCommand.Parameters.Add(New MySqlParameter("@status", dvd.getStatus))
                dbCommand.Parameters.Add(New MySqlParameter("@rentalCount", dvd.getRentCount))
                dbCommand.Parameters.Add(New MySqlParameter("@numberAvailable", dvd.getOnHand))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()


    End Sub

    Public Sub alterCategory(dvd As DVD)
        Try

            Dim strAccQuery As String = "UPDATE categories SET genre = @genre, language = @language, releaseDate = @releaseDate WHERE UPC = '" & dvd.getUPC & "'"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                ' dbCommand.Parameters.Add(New MySqlParameter("@memberID", customer.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@genre", dvd.getGenre))
                dbCommand.Parameters.Add(New MySqlParameter("@language", dvd.getLanguage))
                dbCommand.Parameters.Add(New MySqlParameter("@releaseDate", dvd.getReleaseDate))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()
    End Sub

    Public Sub alterDVDInfo(dvd As DVD)
        Try

            Dim strAccQuery As String = "UPDATE dvd_info SET ageRating = @ageRating, actors = @actors, directors = @directors WHERE UPC = '" & dvd.getUPC & "'"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try


                dbCommand.Parameters.Add(New MySqlParameter("@ageRating", dvd.getAgeRating))
                dbCommand.Parameters.Add(New MySqlParameter("@actors", dvd.getActors))
                dbCommand.Parameters.Add(New MySqlParameter("@directors", dvd.getDirector))


                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()
    End Sub

    Public Sub delteAlerts(customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM ALERTS WHERE MEMBERID = '" & customer.getMemberID & "' "
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

    Public Sub addCreditCard(creditCard As creditCard, customer As Customer)

        Try

            Dim strAccQuery As String = "Insert Into creditcard(memberID, number, expirationDate) Values (@memberID, @number, @expirationDate)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@memberID", customer.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@number", creditCard.getNum))
                dbCommand.Parameters.Add(New MySqlParameter("@expirationDate", creditCard.getExpDate))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub updateCreditCard(creditcard As creditCard, customer As Customer)
        Try

            Dim strAccQuery As String = "UPDATE creditcard SET number = @number, expirationdate = @expirationDate WHERE MEMBERID = '" & customer.getMemberID & "'"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                ' dbCommand.Parameters.Add(New MySqlParameter("@memberID", customer.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@number", creditcard.getNum))
                dbCommand.Parameters.Add(New MySqlParameter("@expirationDate", creditcard.getExpDate))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()
    End Sub

    Public Sub deleteCreditCard(customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM CREDITCARD WHERE MEMBERID = '" & customer.getMemberID & "' "
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


    Public Sub addMemberAddress(Customer As Customer, address As address)
        Try

            Dim strAccQuery As String = "Insert Into memberaddress(memberID, street, city, state, zipCode) Values (@memberID, @street, @city, @state, @zipCode)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@memberID", Customer.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@street", address.getStreet))
                dbCommand.Parameters.Add(New MySqlParameter("@city", address.getCity))
                dbCommand.Parameters.Add(New MySqlParameter("@state", address.getState))
                dbCommand.Parameters.Add(New MySqlParameter("@zipCode", address.getzip))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub updateMemberAddress(customer As Customer, address As address)

        Try

            Dim strAccQuery As String = "UPDATE memberaddress SET street = @street, city = @city, state = @state, zipCode = @zipCode WHERE MEMBERID = '" & customer.getMemberID & "'"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@street", address.getStreet))
                dbCommand.Parameters.Add(New MySqlParameter("@city", address.getCity))
                dbCommand.Parameters.Add(New MySqlParameter("@state", address.getState))
                dbCommand.Parameters.Add(New MySqlParameter("@zipCode", address.getzip))


                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub deleteMemberAddress(customer As Customer)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "DELETE FROM MEMBERADDRESS WHERE MEMBERID = '" & customer.getMemberID & "' "
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

    Public Sub displayCreditCard()

    End Sub

    Public Sub deleteRental(dvd As DVD, customer As Customer)
        SQL = "DELETE FROM RENTALS WHERE MEMBERID = '" & customer.getMemberID & "' AND UPC = '" & dvd.getUPC & "'"

        Try

            conn.Open()

            DVDsCommand.Connection = conn
            DVDsCommand.CommandText = SQL
            DVDsAdapter.SelectCommand = DVDsCommand
            DVDsAdapter.Fill(DVDsData)

            '  DataGridView1.DataSource = rentalsdata


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        updateDVD(dvd)

    End Sub

    Public Sub addCategory(DVD As DVD)

        Try

            Dim strAccQuery As String = "Insert Into categories (UPC, genre, language, releaseDate) Values (@UPC, @genre, @language, @releaseDate)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@UPC", DVD.getUPC))
                dbCommand.Parameters.Add(New MySqlParameter("@genre", DVD.getGenre))
                dbCommand.Parameters.Add(New MySqlParameter("@language", DVD.getLanguage))
                dbCommand.Parameters.Add(New MySqlParameter("@releasedate", DVD.getReleaseDate))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub addDVD_Info(DVD As DVD)

        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try
        SQL = "INSERT INTO DVD_Info(UPC, ageRating, actors, directors) Values('" & DVD.getUPC & "', '" + DVD.getAgeRating &
            "', '" + DVD.getActors & "',  '" + DVD.getDirector & "' )"
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

    Public Sub addEmployee(Employee As Employee)
        Try

            Dim strAccQuery As String = "Insert Into Employee (employeeID, name, phone, dateHired, dob, login, password) Values (@employeeID, @name, @phone, @dateHired, @dob, @login, @password)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@employeeID", Employee.getEmpID))
                dbCommand.Parameters.Add(New MySqlParameter("@name", Employee.getName))
                dbCommand.Parameters.Add(New MySqlParameter("@phone", Employee.getPhone))
                dbCommand.Parameters.Add(New MySqlParameter("@dateHired", Employee.getDateHired))
                dbCommand.Parameters.Add(New MySqlParameter("@dob", Employee.getDOB))
                dbCommand.Parameters.Add(New MySqlParameter("@login", Employee.getLogin))
                dbCommand.Parameters.Add(New MySqlParameter("@password", Employee.getPassword))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub addEmpAddress(address As address, employee As Employee)
        Try

            conn.Open()
        Catch ex As Exception
            MsgBox("error in button1")
        End Try

        SQL = "INSERT INTO EMPLOYEEADDRESS(employeeID, street, city, state, zipCode) Values('" & employee.getEmpID & "', '" + address.getStreet & " ', ' " + address.getCity &
            "', '" + address.getState & "',  '" + address.getzip & "' )"
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

    Public Sub completeMember()

    End Sub

    Public Sub addRental(Rental As Rental)
        Try

            Dim strAccQuery As String = "Insert Into Rentals (rentalNumber, memberid, UPC, rentalDate, currentPrice) Values (@rentalNumber, @memberid, @UPC, @rentalDate, @currentPrice)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@rentalNumber", Rental.getRentalNumber))
                dbCommand.Parameters.Add(New MySqlParameter("@memberid", Rental.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@UPC", Rental.getUPC))
                dbCommand.Parameters.Add(New MySqlParameter("@rentalDate", Rental.getDueDate))
                dbCommand.Parameters.Add(New MySqlParameter("@currentPrice", Rental.getPrice))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()


    End Sub

    Public Sub addAlert(Alert As Alert)

        Try

            Dim strAccQuery As String = "Insert Into Alerts (memberID, type, alertCount, alertStatus, message, alertDate) Values (@memberID, @type, @alertCount, @alertStatus, @message, @alertDate)"

            Using dbCommand = New MySqlCommand(strAccQuery, conn)
                Try
                    conn.Open()
                Catch ex As Exception
                    MsgBox("error in button1")
                End Try

                dbCommand.Parameters.Add(New MySqlParameter("@memberID", Alert.getMemberID))
                dbCommand.Parameters.Add(New MySqlParameter("@type", Alert.GetType))
                dbCommand.Parameters.Add(New MySqlParameter("@alertCount", Alert.getAlertCount))
                dbCommand.Parameters.Add(New MySqlParameter("@alertStatus", Alert.getAlertStatus))
                dbCommand.Parameters.Add(New MySqlParameter("@message", Alert.getAlertMessage))
                dbCommand.Parameters.Add(New MySqlParameter("@alertDate", Alert.getAlertDate))

                dbCommand.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()

    End Sub

    Public Sub verifyMember(username As String, password As String)
        SQL = "SELECT username FROM employee_login "

        Try

            conn.Open()

            employeeLoginCommand.Connection = conn
            employeeLoginCommand.CommandText = SQL
            employeeLoginAdapter.SelectCommand = MembersCommand
            employeeLoginAdapter.Fill(MembersData)


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

End Class
