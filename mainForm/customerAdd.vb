Imports System.Text.RegularExpressions

Public Class customerAdd
    Dim validInput As Boolean = True

    Dim validName As Boolean
    Dim validPhone As Boolean




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ' If validName = True Then

        member.Show()
        Me.Hide()

        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        memberID.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        isValid()

        If validInput = True Then
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999)


            Dim a1 As address = New address(num.ToString, streetNum.Text, city.Text, ComboBox1.SelectedItem, zip.Text)

            Dim cr1 As creditCard = New creditCard(creditNum.Text, a1, expDate.Text, memName.Text, secCode.Text, Bank.Text)



            Dim c1 As Customer = New Customer(num.ToString, memName.Text, phone.Text, a1, cr1, email.Text)

            Dim db As New dbControler

            db.connect()

            db.AddMember(c1)
            db.addMemberAddress(c1, a1)
            db.addCreditCard(cr1, c1)

        Else
            MessageBox.Show("Error in creating member")
        End If


    End Sub

    Private Sub isValid()
      

        If Not Regex.Match(memName.Text, "[(a-z)(A-Z)]", RegexOptions.IgnoreCase).Success Or String.IsNullOrEmpty(memName.Text) Or Not memName.Text.Contains(" "c) Or Regex.Match(memName.Text, "[0-9]", RegexOptions.IgnoreCase).Success Then

            MessageBox.Show("Invalid Name")

            memName.Focus()
            memName.Clear()

            validInput = False
        Else

            validName = True

        End If
        If Not Regex.IsMatch(phone.Text, "[0-9]") Or String.IsNullOrEmpty(phone.Text) Or phone.Text.Length <> 10 Then
            phone.Focus()
            phone.Clear()

            MessageBox.Show("Invalid Phone Number")

            validInput = False

        Else
            validPhone = True
        End If

        If Not Regex.Match(streetNum.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(streetNum.Text) Or Not Regex.Match(streetNum.Text, "[0-9]").Success Then
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

        If Not Regex.IsMatch(secCode.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(secCode.Text) Or secCode.Text.Length <> 3 Then
            validInput = False

            MessageBox.Show("Invalid Security Code")

        End If

        If Not Regex.IsMatch(Bank.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(Bank.Text) Then
            validInput = False

            MessageBox.Show("Invalid Bank")

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


    Private Sub customerAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class