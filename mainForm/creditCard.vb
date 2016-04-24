Public Class creditCard

    Private Property cardNumber As String
    Private Property id As String
    Private Property address As address
    Private Property expDate As Date
    Private Property name As String
    Private Property secCode As String
    Private Property bank As String

    Public Sub New(id As String, cardNumber As String, expDate As Date)
        Me.id = id
        Me.cardNumber = cardNumber
        Me.expDate = expDate



    End Sub

    Public Sub New(cardNumber As String, address As address, expDate As String, name As String, secCode As String, bank As String)
        Me.cardNumber = cardNumber
        Me.address = address
        Me.expDate = expDate
        Me.name = name
        Me.secCode = secCode
        Me.bank = bank


    End Sub

    Public Function getNum()
        Return Me.cardNumber
    End Function

    Public Function getExpDate() As Date

        Return Me.expDate
    End Function


End Class
