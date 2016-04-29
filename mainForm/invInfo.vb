'This method accecpts input for dvd information, validates the input, and adds the dvd to the dvds database by passing
'it to the dbcontroler class
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
        Me.Close()


    End Sub

    Private Sub isValid()


        If String.IsNullOrEmpty(title.Text) Then

            MessageBox.Show("Invalid Title")

            title.Focus()
            title.Clear()

            validInput = False
        
        ElseIf Not Regex.IsMatch(genretxt.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(genretxt.Text) Or Regex.IsMatch(genretxt.Text, "[0-9]") Then
            genretxt.Focus()
            genretxt.Clear()

            MessageBox.Show("Invalid Genre")

            validInput = False
     

        ElseIf Not Regex.Match(actorstxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(actorstxt.Text) Or Regex.Match(actorstxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Actors")
       

        ElseIf Not Regex.Match(directortxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(directortxt.Text) Or Regex.Match(actorstxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Director")
    

        ElseIf Not Regex.Match(languagetxt.Text, "[(a-z)(A-Z)]").Success Or String.IsNullOrEmpty(languagetxt.Text) Or Regex.Match(languagetxt.Text, "[0-9]").Success Then
            validInput = False

            MessageBox.Show("Invalid Language")
       

        ElseIf Not Regex.IsMatch(upc.Text, "[0-9 ]") Or String.IsNullOrEmpty(upc.Text) Or UPCtxt.Text.Length <> 12 Then
            validInput = False

            MessageBox.Show("Invalid UPC")
       

        ElseIf String.IsNullOrEmpty(agetxt.Text) Or agetxt.Text.Length > 5 Then
            validInput = False

            MessageBox.Show("Invalid Age Rating")
       

        ElseIf Not Regex.IsMatch(onHand.Text, "^[0-9 ]+$") Or String.IsNullOrEmpty(onHand.Text) Or onHand.Text.Length < 0 Then
            validInput = False

            MessageBox.Show("Invalid Number on Hand")
       

        ElseIf Not Regex.IsMatch(statustxt.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(statustxt.Text) Then
            validInput = False

            MessageBox.Show("Invalid Rental Status")
      

        ElseIf Not Regex.IsMatch(releaseDatetxt.Text, "^(19|20)\d\d[- /.]?(0[1-9]|1[012])[- /.]?(0[1-9]|[12][0-9]|3[01])$") Or String.IsNullOrEmpty(releaseDatetxt.Text) Then
            MessageBox.Show("Invalid Release Date")
            validInput = False
        Else
            validInput = True
        End If

    End Sub

    Private Sub invInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterButton()

    End Sub

    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class