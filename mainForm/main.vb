Public Class Main


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            salesInfo.Show()
            Me.Hide()

        End If

        If RadioButton4.Checked = True Then
            inventory.Show()
            Me.Hide()

        End If

        If RadioButton2.Checked = True Then
            member.Show()
            Me.Hide()


        End If

        If RadioButton3.Checked = True Then
            employee.Show()
            Me.Hide()

        End If

        If RadioButton5.Checked = True Then
            finance.Show()
            Me.Hide()

        End If

        If RadioButton6.Checked = True Then
            alerts.Show()
            Me.Hide()

        End If

    End Sub

    

    
End Class
