Public Class invInfo

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim d1 As DVD = New DVD(UPCtxt.Text, title.Text, statustxt.Text, genretxt.Text, languagetxt.Text, agetxt.Text,
                                releaseDatetxt.Text, directortxt.Text, actorstxt.Text)

        Dim db As dbControler = New dbControler
        db.connect()

        db.AddDvd(d1)
        db.addCategory(d1)






        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        invDel.Show()

        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        inventory.Show()
        Me.Hide()

    End Sub
End Class