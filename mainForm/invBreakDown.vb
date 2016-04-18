Public Class invBreakDown

    Private Sub invBreakDown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d1 As DVD = user.dvd

        title.Text = d1.getTitle()
        UPCtxt.Text = d1.getUPC
        actorstxt.Text = d1.getactors
        directortxt.Text = d1.getDirector()
        languagetxt.Text = d1.getLanguage
        statustxt.Text = d1.getStatus
        agetxt.Text = d1.getAgeRating
        releaseDatetxt.Text = d1.getReleaseDate
        genretxt.Text = d1.getGenre


    End Sub
End Class