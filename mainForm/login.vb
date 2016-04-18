Imports System.Text.RegularExpressions


Public Class Logon

    Private NameValid As Boolean
    Private passwordValid As Boolean



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not Regex.Match(uName.Text, "^[a-zA-Z][a-zA-Z0-9_]*$", RegexOptions.IgnoreCase).Success Then 'Only Letters

            MessageBox.Show("Invalid Username") 'Inform User

            uName.Focus() 'Return Focus
            uName.Clear() 'Clear TextBox

            NameValid = False 'Boolean = False
        Else

            NameValid = True 'Everything Fine

        End If

        'If Not A Matching Format Entered
        If Not Regex.Match(uName.Text, "^[a-zA-Z][a-zA-Z0-9_]*$").Success Then 'Only Letters

            MessageBox.Show("Invalid Password") 'Inform User

            uName.Focus() 'Return Focus
            uName.Clear() 'Clear TextBox

            passwordValid = False 'Boolean = False
        Else

            passwordValid = True 'Everything Fine

        End If

        If NameValid And passwordValid Then
            Main.Show()
            Me.Hide()
        End If
        


    End Sub

   






End Class