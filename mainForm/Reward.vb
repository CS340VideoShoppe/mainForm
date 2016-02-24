Public Class Reward

    Private Property type As String
    Private Property startDate As Date
    Private Property endDate As Date

    Public Sub New(type As String, startDate As Date, endDate As Date)

        Me.type = type
        Me.startDate = startDate
        Me.endDate = endDate

    End Sub

    Public Sub addNew()

    End Sub
End Class
