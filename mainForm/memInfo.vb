Public Class memInfo

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        memConfirm.Show()

        Dim address1 As New address("1234", "42", "some street", "Florence", "SC", "29501", "", "US")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        member.Show()
        Me.Hide()

    End Sub

    
    Private Sub street_TextChanged(sender As Object, e As EventArgs) Handles street.TextChanged


    End Sub
End Class