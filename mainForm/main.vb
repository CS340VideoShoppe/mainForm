Public Class Main


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
     

        If RadioButton4.Checked = True Then
            inventory.Show()
            Me.Hide()

        End If

        If RadioButton2.Checked = True Then
            member.Show()
            Me.Hide()


        End If

        If RadioButton3.Checked = True Then
            employeeUI.Show()
            Me.Hide()

        End If

       

      

    End Sub

    

    
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        user.isLoggedIn = False
        Logon.Show()
        Me.Hide()

    End Sub
End Class
