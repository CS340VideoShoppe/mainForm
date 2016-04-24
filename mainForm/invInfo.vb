Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class invInfo
    Dim validInput As Boolean = True


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        isValid()

        If validInput = True Then
            Dim d1 As DVD = New DVD(UPCtxt.Text, title.Text, statustxt.Text, genretxt.Text, languagetxt.Text, agetxt.Text,
                               releaseDatetxt.Text, directortxt.Text, actorstxt.Text, 0, CInt(onHand.Text))

            Dim db As dbControler = New dbControler
            db.connect()

            db.AddDvd(d1)
            db.addCategory(d1)
            db.addDVD_Info(d1)

            Me.Hide()
        Else
            MessageBox.Show("Error in creating title")
        End If

        

       

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        invDel.Show()

        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        inventory.Show()
        Me.Hide()

    End Sub

    Private Sub isValid()


        If String.IsNullOrEmpty(title.Text) Then

            MessageBox.Show("Invalid Title")

            title.Focus()
            title.Clear()

            validInput = False

        End If
        If Not Regex.IsMatch(genretxt.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(genretxt.Text) Or Regex.IsMatch(genretxt.Text, "[0-9]") Then
            genretxt.Focus()
            genretxt.Clear()

            MessageBox.Show("Invalid Genre")

            validInput = False

        End If

        If Not Regex.Match(actorstxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(actorstxt.Text) Or Regex.Match(actorstxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Actors")

        End If

        If Not Regex.Match(directortxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(directortxt.Text) Or Regex.Match(actorstxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Director")

        End If

        If Not Regex.Match(languagetxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(languagetxt.Text) Or Regex.Match(languagetxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Language")

        End If

        If Not Regex.IsMatch(upc.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(upc.Text) Or UPCtxt.Text.Length <> 12 Then
            validInput = False

            MessageBox.Show("Invalid UPC")

        End If

        If Not Regex.IsMatch(agetxt.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(agetxt.Text) Or agetxt.Text.Length > 5 Then
            validInput = False

            MessageBox.Show("Invalid Age Rating")

        End If

        If Not Regex.IsMatch(onHand.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(onHand.Text) Or onHand.Text.Length < 0 Then
            validInput = False

            MessageBox.Show("Invalid Number on Hand")

        End If

        If Not Regex.IsMatch(statustxt.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(statustxt.Text) Then
            validInput = False

            MessageBox.Show("Invalid Rental Status")

        End If








    End Sub
End Class