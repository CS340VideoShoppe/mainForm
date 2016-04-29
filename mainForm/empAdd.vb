Imports System.Text.RegularExpressions

Public Class empAdd
    Dim validInput As Boolean = True


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        employeeUI.Show()
        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Checks for valid inputs and then creates a new employee object and adds it to the employee database
        isValid()
        If validInput = True Then
            Randomize()
            Dim logNum As Integer = Int(Rnd() * 99)
            Dim db As dbControler = New dbControler
            Dim log As String = "Vshoppe" & logNum.ToString
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
   
        ElseIf Not Regex.IsMatch(phonetxt.Text, "[0-9]") Or String.IsNullOrEmpty(phonetxt.Text) Or phonetxt.Text.Length <> 10 Then
            phonetxt.Focus()
            phonetxt.Clear()

            MessageBox.Show("Invalid Phone Number")

            validInput = False





        ElseIf Not Regex.Match(sttxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(sttxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Street")



        ElseIf Not Regex.Match(citytxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(citytxt.Text) Or Regex.Match(citytxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid city")



        ElseIf Not Regex.IsMatch(ziptxt.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(ziptxt.Text) Or ziptxt.Text.Length <> 5 Then
            validInput = False

            MessageBox.Show("Invalid zip")



        ElseIf Not Regex.Match(passwordtxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(passwordtxt.Text) Or Not Regex.Match(sttxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Password")

        ElseIf Not Regex.IsMatch(dobtxt.Text, "^(19|20)\d\d[- /.]?(0[1-9]|1[012])[- /.]?(0[1-9]|[12][0-9]|3[01])$") Or String.IsNullOrEmpty(dobtxt.Text) Then
            MessageBox.Show("Invalid DOB")
            validInput = False


        Else
            validInput = True

        End If




    End Sub

    Private Sub empAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class