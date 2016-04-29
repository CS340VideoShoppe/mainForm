Public Class Rental

    Private Property rentalNumber As String
    Private Property memberID As String
    Private Property rentalDate As Date
    Private Property UPC As String
    Private Property dueDate As Date
    Private Property title As DVD
    Private Property price As Double
    Private Property daysPast As Integer
    Private Property fees As Double


    Public Sub New(rentalNumber As String, memberID As String, UPC As String, rentalDate As Date, price As Double)
        Me.rentalNumber = rentalNumber
        Me.memberID = memberID
        Me.UPC = UPC
        Me.rentalDate = rentalDate
        Me.price = price

        Me.dueDate = rentalDate.AddDays(5)
        If dueDate < rentalDate Then
            Me.daysPast = rentalDate.Subtract(dueDate).Days
            If Me.daysPast >= 30 Then
                Me.fees = 60
            Else
                Me.fees = 2 * daysPast

            End If
        Else
            Me.daysPast = 0
            Me.fees = 0

        End If



    End Sub

    Public Sub New(memberID As String, rentalDate As Date, dueDate As Date, title As DVD, price As Double)
        Me.memberID = memberID
        Me.rentalDate = rentalDate
        Me.dueDate = dueDate
        Me.title = title
        Me.price = price

        Me.dueDate = rentalDate.AddDays(5)
        If dueDate < rentalDate Then
            Me.daysPast = rentalDate.Subtract(dueDate).Days
            If Me.daysPast >= 30 Then
                Me.fees = 60
            ElseIf Me.daysPast >= 1 Then

                Me.fees = 2 * daysPast

            Else
                Me.fees = 0
            End If
        Else
            Me.daysPast = 0


        End If


    End Sub

    Public Function getRentalDate() As Date
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

    Public Function getDueDate() As Date
        Return Me.dueDate

    End Function

    Public Function getDaysPast() As Integer
        If Me.dueDate < Me.rentalDate Then
            Me.daysPast = rentalDate.Subtract(dueDate).Days
           
        Else
            Me.daysPast = 0

        End If
        Return Me.daysPast


    End Function

    Public Function getFees() As Integer
        If Me.daysPast >= 30 Then
            Me.fees = 60
        ElseIf Me.daysPast >= 1 Then
            Me.fees = 2 * daysPast

        Else
            Me.fees = 0

        End If

        Return Me.fees


    End Function

   



End Class
