Imports System.Text.RegularExpressions
'This class retreives and validates member information and passes it to the dbcontroler 
Public Class customerAdd
    Dim validInput As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Goes back to the previous form


        member.Show()
        Me.Hide()

        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        memberID.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'checks for valid inputs, then inserts memeber into database
        isValid()

        If validInput = True Then
            'create random MemberID and checks if it is already taken 
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999)


            Dim a1 As address = New address(num.ToString, streetNum.Text, city.Text, ComboBox1.SelectedItem, zip.Text)

            Dim cr1 As creditCard = New creditCard(creditNum.Text, a1, expDate.Text, memName.Text, secCode.Text, Bank.Text)



            Dim c1 As Customer = New Customer(num.ToString, memName.Text, phone.Text, a1, cr1, email.Text, dob.Text)

            Dim db As New dbControler

            db.connect()

            db.AddMember(c1)
            db.addMemberAddress(c1, a1)
            db.addCreditCard(cr1, c1)

            MessageBox.Show("Member Created Successfully")

        Else
            MessageBox.Show("Error in creating member")
        End If


    End Sub

    Private Sub isValid()
        'Method to validate all input fields
        
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




        ElseIf Not Regex.Match(streetNum.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(streetNum.Text) Or Not Regex.Match(streetNum.Text, "[0-9]").Success Then
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



        ElseIf Not Regex.IsMatch(secCode.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(secCode.Text) Or secCode.Text.Length <> 3 Then
            validInput = False

            MessageBox.Show("Invalid Security Code")



        ElseIf Not Regex.IsMatch(Bank.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(Bank.Text) Then
            validInput = False

            MessageBox.Show("Invalid Bank")


        ElseIf Not Regex.IsMatch(dob.Text, "^(19|20)\d\d[- /.]?(0[1-9]|1[012])[- /.]?(0[1-9]|[12][0-9]|3[01])$") Or String.IsNullOrEmpty(dob.Text) Then
            MessageBox.Show("Invalid DOB")
            validInput = False

        ElseIf Not Regex.IsMatch(expDate.Text, "^(19|20)\d\d[- /.]?(0[1-9]|1[012])[- /.]?(0[1-9]|[12][0-9]|3[01])$") Or String.IsNullOrEmpty(expDate.Text) Then
            MessageBox.Show("Invalid Expiration Date")
            validInput = False


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


    Private Sub customerAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

    End Sub

    Private Sub secCode_TextChanged(sender As Object, e As EventArgs) Handles secCode.TextChanged

    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class