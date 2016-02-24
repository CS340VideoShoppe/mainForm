Public Class empSchOverview

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows(0).Cells(0).Value = "11:00 - 4:30"
        DataGridView1.Rows(0).Cells(1).Value = "-"
        DataGridView1.Rows(0).Cells(2).Value = "-"
        DataGridView1.Rows(0).Cells(3).Value = "3:30 - 8:00"
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()

        DataGridView1.Rows(1).Cells(0).Value = "3:30 - 8:00"



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        employeeUI.Show()
        Me.Hide()

    End Sub
End Class