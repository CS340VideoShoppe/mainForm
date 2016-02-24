Public Class OverdueAlert

    Private Property memberID As String
    Private Property daysPastDue As Integer
    Private Property lateFees As Integer

    Public Sub New(memberID As String, daysPastDue As Integer, lateFees As Integer)
        Me.memberID = memberID
        Me.daysPastDue = daysPastDue
        Me.lateFees = lateFees


    End Sub

End Class
