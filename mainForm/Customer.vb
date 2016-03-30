Public Class Customer

    Private Property memberID As String
    Private Property name As String
    Private Property phones As String
    Private Property address As address
    Private Property creditCards As creditCard
    Private Property rentalHistory As DVD
    Private Property currentRentals As DVD
    Private Property familyMember As Customer
    Private Property emailAddress As String
    Private Property overdueItems As DVD
    Private Property lateFees As String
    Private Property requestedItems As DVD

    Public Sub New(memberID As String, name As String, phones As String,
                   address As address, creditCards As creditCard, emailAddress As String)

        Me.memberID = memberID
        Me.name = name
        Me.phones = phones
        Me.address = address
        Me.creditCards = creditCards
        Me.emailAddress = emailAddress
       

    End Sub

    Public Function getRentalHistory()
        Return Me.rentalHistory

    End Function

    Public Sub addFamilyMember()

    End Sub

    Public Sub revokeMembership()

    End Sub

    Public Function getMemberID() As String
        Return Me.memberID

    End Function

    Public Function getName() As String
        Return Me.Name

    End Function

    Public Function getAddress() As address
        Return Me.address

    End Function

    Public Function getPhone() As String
        Return Me.phones
    End Function

    Public Function getEmail() As String
        Return Me.emailAddress

    End Function





End Class
