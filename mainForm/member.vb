Public Class member

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        memResults.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        customerAdd.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        memberSummary.Show()
        Me.Hide()

    End Sub
End Class
