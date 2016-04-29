Imports System.Text.RegularExpressions

Public Class payFees
    Dim isValid As Boolean = True
    Dim newTotal As Double
    Dim daysPast As Integer


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub payFees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        centerButton()

        TextBox1.Text = user.fees
        daysPast = user.daysPast



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrEmpty(amount.Text) Or Not Regex.IsMatch(amount.Text, "^[0-9 ]+$") Then
            MessageBox.Show("Invalid Amount")

        Else

            If RadioButton3.Checked = True Then
                Dim pay As Double = cash.Text
                If pay > user.fees Then
                    change.Text = pay - user.fees
                End If

                newTotal = user.fees - CDbl(amount.Text)



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
                newTotal = user.fees - CDbl(amount.Text)



            End If
            Dim c1 As Customer = user.customer
            Dim db As dbControler = New dbControler
            newTotal = user.fees - CDbl(amount.Text)
            TextBox2.Text = newTotal
            If newTotal = 0 Then
                daysPast = 0
            End If
            db.connect()
            db.updateRental(newTotal, daysPast, c1)
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        memInfo.Show()
        Me.Close()

    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class