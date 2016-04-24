Imports System.Text.RegularExpressions

Public Class empAdd
    Dim validInput As Boolean = True


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        employeeUI.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        isValid()
        If validInput = True Then
            Dim db As dbControler = New dbControler
            Dim log As String = nametxt.Text & "1"
            Randomize()
            Dim num As Integer = Int(Rnd() * 999999)

            db.connect()

            Dim e1 As Employee = New Employee(num.ToString, nametxt.Text, phonetxt.Text, Date.Now.Date, dobtxt.Text, log, passwordtxt.Text)
            Dim a1 As address = New address(num.ToString, sttxt.Text, citytxt.Text, statetxt.SelectedItem, ziptxt.Text)

            db.addEmployee(e1)
            db.addEmpAddress(a1, e1)
        End If
        

    End Sub

    Public Sub isValid()
        If Not Regex.Match(nametxt.Text, "[(a-z)(A-Z)]", RegexOptions.IgnoreCase).Success Or String.IsNullOrEmpty(nametxt.Text) Or Not nametxt.Text.Contains(" "c) Or Regex.Match(nametxt.Text, "[0-9]", RegexOptions.IgnoreCase).Success Then

            MessageBox.Show("Invalid Name")

            nametxt.Focus()
            nametxt.Clear()

            validInput = False
        Else



        End If
        If Not Regex.IsMatch(phonetxt.Text, "[0-9]") Or String.IsNullOrEmpty(phonetxt.Text) Or phonetxt.Text.Length <> 10 Then
            phonetxt.Focus()
            phonetxt.Clear()

            MessageBox.Show("Invalid Phone Number")

            validInput = False

        Else

        End If

        If Not Regex.Match(sttxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(sttxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Street")

        End If

        If Not Regex.Match(citytxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(citytxt.Text) Or Regex.Match(citytxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid city")

        End If

        If Not Regex.IsMatch(ziptxt.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(ziptxt.Text) Or ziptxt.Text.Length <> 5 Then
            validInput = False

            MessageBox.Show("Invalid zip")

        End If

        If Not Regex.Match(passwordtxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(passwordtxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Password")

        End If




    End Sub
End Class