Public Class memConfirm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If yeschk.Checked = True Then
            memInfo.Close()

            Dim c1 As Customer = user.customer
            Dim cr1 As creditCard = user.creditCard
            Dim a1 As address = user.address
            Dim db As dbControler = New dbControler

            db.connect()
            db.updateMember(c1)
            db.updateCreditCard(cr1, c1)
            db.updateMemberAddress(c1, a1)


            Me.Close()
            member.Show()


        Else
            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        memInfo.Show()
        Me.Hide()

    End Sub

    Private Sub memConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class