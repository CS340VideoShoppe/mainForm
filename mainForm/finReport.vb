'This class displays a bar graph depending on the user's selection 
'It contains database functionality to retreive database information and pass it to the graph

Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class finReport

    Dim conn As New MySqlConnection
    Dim dvdsCommand As New MySqlCommand
    Dim dvdsAdapter As New MySqlDataAdapter
    Dim dvdsData As New DataTable

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



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        centerbutton()

        connect()

        SQL = "SELECT DISTINCT DVDS.UPC, DVDS.TITLE, DVDS.RENTALCOUNT, DVDS.NUMBERAVAILABLE, RENTALS.CURRENTPRICE FROM DVDS LEFT JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC Left JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC LEFT JOIN RENTALS ON DVDS.UPC = RENTALS.UPC"


        Try

            conn.Open()

            dvdsCommand.Connection = conn
            dvdsCommand.CommandText = SQL
            dvdsAdapter.SelectCommand = dvdsCommand
            dvdsAdapter.Fill(dvdsData)

            DataGridView1.DataSource = dvdsData


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        Dim title As String
     
        Dim rentalStatus As String
        Dim UPC As String
        Dim rentCount As Integer
        Dim onHand As Integer

        'Chart1.Series.points.addxy()
        UPC = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        title = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        rentalStatus = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        rentCount = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value
        onHand = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
  

        ' Dim d1 As DVD = New DVD(UPC, title, rentalStatus, genre, language, ageRating, releaseDate, director, actors, rentCount, onHand)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        inventory.Show()

        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Views total number of rentals
        Chart1.Series.Clear()
       

     

        Try
            Try
                conn.Open()
            Catch ex As Exception
                MsgBox("error in button1")
            End Try

            SQL = "select distinct title, rentalCount from dvds;"

            Using dbComm = New MySqlCommand(SQL, conn)



                ' dbCommand.ExecuteNonQuery()

                dbread = dbComm.ExecuteReader()

                Chart1.Series.Add("TITLE_VS_RENTALCOUNT")


                While dbread.Read
                    Chart1.Series("TITLE_VS_RENTALCOUNT").Points.AddXY(dbread.GetString("title"), dbread.GetInt32("rentalCount"))

                End While

            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try

        conn.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Views revenue by title 
        Chart1.Series.Clear()
        Try
            conn.Open()


            SQL = "select DISTINCT dvds.title, dvds.rentalCount * rentals.currentPrice from dvds, rentals where dvds.upc = rentals.upc"

            dbcomm = New MySqlCommand(SQL, conn)
            dbread = dbcomm.ExecuteReader()


            Chart1.Series.Add("TITLE_VS_REVENUE")
            '  Chart1.Series.Add("Total Revenue")
            '  Chart1.Series.Add("rentalCount")

            While dbread.Read
                Chart1.Series("TITLE_VS_REVENUE").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("dvds.rentalCount * rentals.currentPrice"))
                '   Chart1.Series("Total Revenue").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
            End While
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Displays total revenue 
        Chart1.Series.Clear()
        Try
            conn.Open()


            SQL = "select DISTINCT sum(dvds.rentalCount * rentals.currentPrice) from dvds, rentals where dvds.upc = rentals.upc "

            dbcomm = New MySqlCommand(SQL, conn)
            dbread = dbcomm.ExecuteReader()


            Chart1.Series.Add("Total Revenue")
            '  Chart1.Series.Add("Total Revenue")
            '  Chart1.Series.Add("rentalCount")

            While dbread.Read
                Chart1.Series("Total Revenue").Points.AddY(dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
                '   Chart1.Series("Total Revenue").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
            End While
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'finance.Show()
        Chart1.Series.Clear()
        Dim startDate As Date
        Dim endDate As Date




        Try
            Try
                conn.Open()
            Catch ex As Exception
                MsgBox("error in button1")
            End Try

            SQL = "select distinct sum(rentals.currentPrice * dvds.rentalCount) from dvds,rentals where dvds.upc = rentals.upc and rentals.rentalDate >= @startDate and rentals.rentalDate <= @endDate; "

            Using dbComm = New MySqlCommand(SQL, conn)


                dbComm.Parameters.Add(New MySqlParameter("@startDate", startDate))
                dbComm.Parameters.Add(New MySqlParameter("@endDate", endDate))

                ' dbCommand.ExecuteNonQuery()

                dbread = dbComm.ExecuteReader()

                Chart1.Series.Add(" Revenue for ")

                'crashes when null
                While dbread.Read
                    Chart1.Series(" Revenue for ").Points.AddY(dbread.GetDouble("sum(rentals.currentPrice * dvds.rentalCount)"))
                    '   Chart1.Series("Total Revenue").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
                End While
                ' conn.Close()


                conn.Close()




            End Using
        Catch ex As Exception
            MsgBox("Another Error")
        End Try
        ' dbcomm = New MySqlCommand(SQL, conn)
        '  dbread = dbcomm.ExecuteReader()






    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Asks the user for a genre, validates input, and displays revenue by genre
        Dim genre As String = InputBox("Enter Genre", "Enter Value", "Please Enter a Genre")
        Chart1.Series.Clear()
        Try
            conn.Open()

            Try
                SQL = "select distinct dvds.title, categories.genre, sum(rentals.currentPrice * dvds.rentalCount) from dvds, categories, rentals where dvds.upc = rentals.upc and dvds.upc = categories.upc and categories.genre =  '" & genre & "'"

                dbcomm = New MySqlCommand(SQL, conn)
                dbread = dbcomm.ExecuteReader()


                Chart1.Series.Add(genre & " Revenue")

                'crashes when null
                While dbread.Read
                    Chart1.Series(genre & " Revenue").Points.AddXY(dbread.GetString("genre"), dbread.GetDouble("sum(rentals.currentPrice * dvds.rentalCount)"))
                    '   Chart1.Series("Total Revenue").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
                End While
            Catch ex As System.Data.SqlTypes.SqlNullValueException
                MessageBox.Show("Value not found")
            End Try

            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Retreives language from the user, validates input, and displays revenue by language 
        Dim language As String = InputBox("Enter Language", "Enter Language", "Please Enter a Language")
        Chart1.Series.Clear()
        Try
            conn.Open()

            Try
                SQL = "select distinct dvds.title, categories.language, sum(rentals.currentPrice * dvds.rentalCount) from dvds, categories, rentals where dvds.upc = rentals.upc and dvds.upc = categories.upc and categories.language =  '" & language & "'"

                dbcomm = New MySqlCommand(SQL, conn)
                dbread = dbcomm.ExecuteReader()


                Chart1.Series.Add(language & " Revenue")

                'crashes when null
                While dbread.Read
                    Chart1.Series(language & " Revenue").Points.AddXY(dbread.GetString("language"), dbread.GetDouble("sum(rentals.currentPrice * dvds.rentalCount)"))
                    '   Chart1.Series("Total Revenue").Points.AddXY(dbread.GetString("title"), dbread.GetDouble("sum(dvds.rentalCount * rentals.currentPrice)"))
                End While
            Catch ex As System.Data.SqlTypes.SqlNullValueException
                MessageBox.Show("Value not found")
            End Try

            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub

   
  
End Class