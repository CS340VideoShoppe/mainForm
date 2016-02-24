Public Class WaitingList

    Private Property memberID As String
    Private Property title As DVD
    Private Property dueDate As Date
    Private Property position As Integer

    Public Sub New(memberID As String, title As DVD, dueDate As Date, position As Integer)
        Me.memberID = memberID
        Me.title = title
        Me.dueDate = dueDate
        Me.position = position


    End Sub

    Public Function getPosition() As Integer
        Return Me.position

    End Function

    Public Sub addCustomer()

    End Sub

    Public Sub removeCustomer()

    End Sub

End Class
