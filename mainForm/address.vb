'Class used to store member's address information and passed dbcontroler class to be stored into the memberAddress database
Public Class address

    Private Property memID As String
    Public Property street As String
    Private Property city As String
    Private Property state As String
    Private Property zip As String
    Private Property aptNumber As String
    Private Property country As String

    Public Sub New(memID As String, street As String, city As String, state As String, zip As String)
        Me.memID = memID
        Me.street = street
        Me.city = city
        Me.state = state
        Me.zip = zip
    End Sub


    Public Sub New(memID As String, street As String, city As String, state As String, zip As String, aptNum As String, country As String)
        Me.memID = memID
        Me.street = street
        Me.city = city
        Me.state = state
        Me.zip = zip
        Me.aptNumber = aptNumber
        Me.country = country


    End Sub

    Public Sub verify()

    End Sub

    Public Sub add()

    End Sub

    Public Sub change()

    End Sub

    Public Function getStreet() As String
        Return Me.street

    End Function

    Public Function getCity() As String
        Return Me.city

    End Function

    Public Function getState() As String
        Return Me.state

    End Function

    Public Function getzip() As String
        Return Me.zip

    End Function






End Class
