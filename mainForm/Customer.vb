Public Class Customer

    Private Property memberID As String
    Private Property lastName As String
    Private Property firstName As String
    Private Property midInit As String
    Private Property phones As Phone
    Private Property address As address
    Private Property creditCards As creditCard
    Private Property rentalHistory As DVD
    Private Property currentRentals As DVD
    Private Property familyMember As Customer
    Private Property emailAddress As EmailAddress
    Private Property overdueItems As DVD
    Private Property lateFees As String
    Private Property requestedItems As DVD

    Public Sub New(memberID As String, lastName As String, firstName As String, midInit As String, phones As Phone,
                   address As address, creditCards As creditCard, rentalHistory As DVD, currentRentals As DVD,
                   familyMember As Customer, emailAddress As EmailAddress, overdueItems As DVD, lateFees As String,
                   requestedItems As DVD)

        Me.memberID = memberID
        Me.lastName = lastName
        Me.firstName = firstName
        Me.midInit = midInit
        Me.phones = phones
        Me.address = address
        Me.creditCards = creditCards
        Me.rentalHistory = rentalHistory
        Me.currentRentals = currentRentals
        Me.familyMember = familyMember
        Me.emailAddress = emailAddress
        Me.overdueItems = overdueItems
        Me.lateFees = lateFees
        Me.requestedItems = requestedItems

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
        Return Me.firstName + Me.lastName

    End Function

    Public Function getAddress() As address
        Return Me.address

    End Function





End Class
