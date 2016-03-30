Public Class DVD
    Private Property UPC As String
    Private Property title As String
    Private Property genre As String
    Private Property language As String
    Private Property name As String
    Private Property ageRating As String
    Private Property releaseDate As Date
    Private Property director As String
    Private Property actors As String
    Private Property status As String


    Public Sub New(UPC As String, title As String, status As String, genre As String, language As String,
                   ageRating As String, releaseDate As Date, director As String, actors As String)
        Me.UPC = UPC
        Me.title = title
        Me.status = status
        Me.genre = genre
        Me.language = language
        Me.ageRating = ageRating
        Me.releaseDate = releaseDate
        Me.director = director
        Me.actors = actors

    End Sub

    Public Sub addDVD()

    End Sub

    Public Sub removeDVD()

    End Sub

    Public Sub orderDVD()

    End Sub

    Public Sub categorize()

    End Sub

    Public Function getUPC() As String
        Return Me.UPC

    End Function

    Public Function getTitle() As String
        Return Me.title
    End Function

    Public Function getStatus() As String
        Return Me.status
    End Function

    Public Function getGenre() As String
        Return Me.genre

    End Function

    Public Function getReleaseDate() As Date
        Return Me.releaseDate

    End Function

    Public Function getLanguage() As String
        Return Me.language

    End Function



End Class
