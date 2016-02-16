Public Class alertsPending

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        alertsDetails.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        alertConfirm.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        alertConfirm.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        alerts.Show()
        Me.Hide()

    End Sub
End Class