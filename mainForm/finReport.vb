Public Class finReport

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows(0).Cells(0).Value = "85"
        DataGridView1.Rows(0).Cells(1).Value = "-"
        DataGridView1.Rows(0).Cells(2).Value = "-"
        DataGridView1.Rows(0).Cells(3).Value = "3:30 - 8:00"
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        finance.Show()
        Me.Hide()

    End Sub
End Class