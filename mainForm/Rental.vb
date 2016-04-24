Public Class Rental

    Private Property rentalNumber As String
    Private Property memberID As String
    Private Property rentalDate As Date
    Private Property UPC As String
    Private Property dueDate As Date
    Private Property title As DVD
    Private Property price As Double

    Public Sub New(rentalNumber As String, memberID As String, UPC As String, rentalDate As Date, price As Double)
        Me.rentalNumber = rentalNumber
        Me.memberID = memberID
        Me.UPC = UPC
        Me.rentalDate = rentalDate
        Me.price = price


    End Sub

    Public Sub New(memberID As String, rentalDate As Date, dueDate As Date, title As DVD, price As Double)
        Me.memberID = memberID
        Me.rentalDate = rentalDate
        Me.dueDate = dueDate
        Me.title = title
        Me.price = price

    End Sub

    Public Function getDueDate() As Date
        Return Me.rentalDate

    End Function

    Public Function getPrice() As Double

        Return Me.price

    End Function

    Public Function getUPC() As String
        Return Me.UPC

    End Function

    Public Function getRentalNumber() As String
        Return Me.rentalNumber

    End Function

    Public Function getMemberID() As String
        Return Me.memberID

    End Function

   



End Class
