Public Class ExpiryAlert

    Private Property memberID As String
    Private Property daysPastDue As Integer

    Public Sub New(memberID As String, daysPastDue As Integer)

        Me.memberID = memberID
        Me.daysPastDue = daysPastDue

    End Sub

    Public Sub sendAlert()

    End Sub

End Class
