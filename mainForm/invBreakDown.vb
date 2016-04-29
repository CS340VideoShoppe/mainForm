Imports System.Text.RegularExpressions

Public Class invBreakDown
    Dim validInput As Boolean = True



    Private Sub invBreakDown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        centerButton()

        Dim d1 As DVD = user.dvd

        title.Text = d1.getTitle()
        UPCtxt.Text = d1.getUPC
        actorstxt.Text = d1.getActors
        directortxt.Text = d1.getDirector()
        languagetxt.Text = d1.getLanguage
        statustxt.Text = d1.getStatus
        agetxt.Text = d1.getAgeRating
        releaseDatetxt.Text = d1.getReleaseDate
        genretxt.Text = d1.getGenre
        onHand.Text = d1.getOnHand
        rentCount.Text = d1.getRentCount


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim db As dbControler = New dbControler
        Dim dvd As DVD = user.dvd

        db.connect()
        db.deleteDVD(dvd)
        db.deleteCategory(dvd)
        db.deleteDVDinfo(dvd)
        db.deleteRental(dvd)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        isValid()

        If validInput = True Then
            'create new dvd class
            Dim dvd As DVD = New DVD(UPCtxt.Text, title.Text, statustxt.Text, genretxt.Text, languagetxt.Text, agetxt.Text, releaseDatetxt.Text, directortxt.Text, actorstxt.Text, rentCount.Text, onHand.Text)
            Dim db As dbControler = New dbControler

            db.connect()
            db.alterDVD(dvd)
            db.alterCategory(dvd)
            db.alterDVDInfo(dvd)
            MessageBox.Show("Item Updated Successfully")
        Else
            MessageBox.Show("Cannot connect")

        End If
      

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



        ElseIf Not Regex.IsMatch(upc.Text, "[0-9 ]") Or String.IsNullOrEmpty(upc.Text) Or UPCtxt.Text.Length < 12 Then
            validInput = False

            MessageBox.Show("Invalid UPC")



        ElseIf String.IsNullOrEmpty(agetxt.Text) Or agetxt.Text.Length > 5 Then
            validInput = False

            MessageBox.Show("Invalid Age Rating")



        ElseIf Not Regex.IsMatch(onHand.Text, "[0-9 ]") Or String.IsNullOrEmpty(onHand.Text) Or onHand.Text.Length < 0 Then
            validInput = False

            MessageBox.Show("Invalid Number on Hand")


        ElseIf Not Regex.IsMatch(statustxt.Text, "[(a-z)(A-Z)]") Or String.IsNullOrEmpty(statustxt.Text) Then
            validInput = False

            MessageBox.Show("Invalid Rental Status")

        Else
            validInput = True

        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        inventory.Show()
        Me.Close()

    End Sub
    Private Sub CenterButton()
        GroupBox1.Top = (Me.ClientSize.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.ClientSize.Width / 2) - (GroupBox1.Width / 2)
    End Sub
End Class