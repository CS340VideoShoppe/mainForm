Public Class lateFee
    Private Property feeID As String
    Private Property upc As String
    Private Property memID As String
    Private Property daysPast As Integer
    Private Property dueDate As Date
    Private Property fees As Double

    Public Sub New(feeID As String, upc As String, memID As String, daysPast As Integer, dueDate As Date, fees As Double)
        Me.feeID = feeID
        Me.upc = upc
        Me.memID = memID
        Me.daysPast = daysPast
        Me.dueDate = dueDate
        Me.fees = fees

    End Sub

    Public Function getFeeID()
        Return Me.feeID

    End Function

    Public Function getUPC()
        Return upc

    End Function

    Public Function getMemID()
        Return Me.memID

    End Function

    Public Function getDaysPast() As Integer
        Return Me.daysPast

    End Function

    Public Function getDueDate() As Date
        Return Me.dueDate

    End Function

    Public Function getFees() As Double
        Return Me.fees

    End Function
End Class
