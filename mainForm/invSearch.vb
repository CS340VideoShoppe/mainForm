Public Class invSearch

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        invInfo.Show()

        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        inventory.Show()
        Me.Hide()

    End Sub
End Class