
Public Class customerAdd



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        member.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        memberID.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a1 As address = New address(memID.Text, streetNum.Text, city.Text, state.Text, zip.Text, apt.Text, country.Text)

        Dim cr1 As creditCard = New creditCard(creditNum.Text, a1, expDate.Text, memName.Text, secCode.Text, Bank.Text)



        Dim c1 As Customer = New Customer(memID.Text, memName.Text, phone.Text, a1, cr1, email.Text)

        Dim db As New dbControler

        db.connect()

        db.AddMember(c1)

    End Sub

   

   
   
End Class