Public Class Rental

    Private Property memberID As String
    Private Property rentalDate As Date
    Private Property dueDate As Date
    Private Property title As DVD
    Private Property price As Double

    Public Sub New(memberID As String, rentalDate As Date, dueDate As Date, title As DVD, price As Double)
        Me.memberID = memberID
        Me.rentalDate = rentalDate
        Me.dueDate = dueDate
        Me.title = title
        Me.price = price

    End Sub

    Public Sub New()

    End Sub



End Class
