Public Class payment

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        confirm.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        titleInfo.Show()
        Me.Close()

    End Sub

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dvd As DVD = user.dvd

        upctxt.Text = dvd.getUPC
        titletxt.Text = dvd.getTitle

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim currentDate As Date = Date.Now
        Dim dueDate As Date = currentDate.AddDays(5)



        Dim renID As String = CInt(Math.Ceiling(Rnd() * 99999) + 1).ToString

        Dim c1 As Customer = user.customer

        Dim d1 As DVD = user.dvd



        Dim r2 As Rental = New Rental("11111117", c1.getMemberID, d1.getUPC, dueDate, 4.75)
        TextBox1.Text = r2.getPrice
        'Update rental count and on hand in DVDs


        Dim cont As dbControler = New dbControler()
        cont.connect()
        cont.updateDVD(d1)
        cont.addRental(r2)
    End Sub
End Class