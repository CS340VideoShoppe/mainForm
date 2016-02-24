Public Class Phone

    Private Property type As String
    Private Property hoursAvailable As Integer
    Private Property number As String


    Public Sub New(type As String, hoursAvailable As Integer, number As String)

        Me.type = type
        Me.hoursAvailable = hoursAvailable
        Me.number = number

    End Sub

    Public Sub addNew()

    End Sub

    Public Sub setNumber(number As Integer)
        Me.number = number

    End Sub

    Public Function getNumber() As String
        Return Me.number

    End Function

    Public Function findType() As String
        Return Me.type

    End Function

End Class
