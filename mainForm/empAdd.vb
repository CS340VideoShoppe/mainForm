Public Class empAdd

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        employeeUI.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As dbControler = New dbControler
        Dim log As String = nametxt.Text & "1"

        db.connect()

        Dim e1 As Employee = New Employee("111111111111", nametxt.Text, phonetxt.Text, Date.Now.Date, dobtxt.Text, log, passwordtxt.Text)
        Dim a1 As address = New address("111111111111", sttxt.Text, citytxt.Text, statetxt.Text, ziptxt.Text)

        db.addEmployee(e1)
        db.addEmpAddress(a1, e1)

    End Sub
End Class