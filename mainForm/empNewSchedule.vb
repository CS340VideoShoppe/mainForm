Imports System.Text.RegularExpressions
'This class allows the user to input a date, time/days available, and start and end times. It then  validates the input and passes it to the
'db controler class to be added to the database
Public Class empNewSchedule
    Dim validInput As Boolean = True


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'goes back to previous form
        empInfo.Show()

        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'checcks for valid input then updates user
        isValid()

        If validInput = True Then
            Dim e1 As Employee = user.employee
            Dim db As dbControler = New dbControler
            Randomize()
            Dim num As Integer = Int(Rnd() * 99999)
            Dim sch As Schedule = New Schedule(num.ToString, e1.getEmpID, workDaytxt.Text, starttxt.Text, endtxt.Text, daysAvl.Text)


            db.connect()
            db.addSchedule(sch)
        Else
            MessageBox.Show("Error Saving Schedule")
        End If



    End Sub

    Private Sub empNewSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub isValid()
        If Not Regex.IsMatch(workDaytxt.Text, "^(19|20)\d\d[- /.]?(0[1-9]|1[012])[- /.]?(0[1-9]|[12][0-9]|3[01])$") Or String.IsNullOrEmpty(workDaytxt.Text) Then
            MessageBox.Show("Invalid Date")
            validInput = False
        

        ElseIf String.IsNullOrEmpty(daysAvl.Text) Then

            MessageBox.Show("Invalid Title")

            daysAvl.Focus()
            daysAvl.Clear()

            validInput = False
        

        ElseIf Not Regex.IsMatch(starttxt.Text, "([0-1]\d|2[0-3]):([0-5]\d)") Or String.IsNullOrEmpty(starttxt.Text) Then
            validInput = False
            MessageBox.Show("Invalid start time")
       

        ElseIf Not Regex.IsMatch(endtxt.Text, "([0-1]\d|2[0-3]):([0-5]\d)") Or String.IsNullOrEmpty(endtxt.Text) Then
            validInput = False
            MessageBox.Show("Invalid end time")
        Else
            validInput = True
        End If

    End Sub

  

End Class