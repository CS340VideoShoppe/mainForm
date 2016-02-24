Public Class DVD
    Private Property title As String
    Private Property genre As String
    Private Property language As String
    Private Property name As String
    Private Property ageRating As String
    Private Property releaseDate As Date
    Private Property director As String
    Private Property actors As String

    Public Sub New(title As String, genre As String, language As String, ageRating As String, releaseDate As Date, director As String, actors As String)
        Me.title = title
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

    Public Function getTitle() As String
        Return Me.title
    End Function



End Class
