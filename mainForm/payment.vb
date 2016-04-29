Imports System.Text.RegularExpressions

Public Class payment
    Dim isValid As Boolean = True


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        confirm.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        titleInfo.Show()
        Me.Close()

    End Sub

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        centerButton()

        Dim dvd As DVD = user.dvd

        upctxt.Text = dvd.getUPC
        titletxt.Text = dvd.getTitle

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cont As dbControler = New dbControler()
        Dim currentDate As Date = Date.Now
        Dim dueDate As Date = currentDate.AddDays(5)

        Dim c1 As Customer = user.customer

        Dim d1 As DVD = user.dvd
        Randomize()
        Dim num As Integer = Int(Rnd() * 999999)


        Dim r2 As Rental = New Rental(num.ToString, c1.getMemberID, d1.getUPC, currentDate, 4.75)
        TextBox1.Text = r2.getPrice

        'Update rental count and on hand in DVDs
        If RadioButton3.Checked = True Then
            Dim pay As Double = cash.Text
            If pay > 4.75 Then
                change.Text = pay - 4.75
            End If





        ElseIf RadioButton2.Checked = True Then
            If Not Regex.IsMatch(creditNum.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(creditNum.Text) Or creditNum.Text.Length <> 16 Then

                MessageBox.Show("Invalid Credit Card Number")
                creditNum.Clear()
                creditNum.Focus()
                isValid = False
           

            End If

            If expDate.Text < Date.Now Then
                MessageBox.Show("Invalid expiration date")
                isValid = False
            

            End If



        End If




      

        If isValid = True Then
            cont.connect()
            cont.updateDVD(d1)
            cont.addRental(r2)
            MessageBox.Show("Success. " & titletxt.Text & " will be due on " & dueDate.ToString & " Price: 4.75")
        End If











    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class