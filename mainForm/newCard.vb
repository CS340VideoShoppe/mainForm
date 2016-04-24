Imports System.Text.RegularExpressions

Public Class newCard
    Dim isValid As Boolean


    Private Sub newCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

        If isValid = True Then
            user.cardNum = creditNum.Text
            Me.Hide()

        End If


    End Sub
End Class