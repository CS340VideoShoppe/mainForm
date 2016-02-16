Public Class invInfo

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        invUpdate.Show()

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