Public Class finance

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        user.startDate = DateTimePicker1.Value
        user.endDate = DateTimePicker2.Value



        'finReport.Show()
        Me.Hide()

    End Sub

    Private Sub finance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
