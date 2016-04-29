Public Class employeeUser
    Private Property userName As String
    Private Property password As String
    Private Property isLogedIn As Boolean


    Public Sub New(userName As String, password As String)
        Me.userName = userName
        Me.password = password

    End Sub

    Public Function getUserName() As String
        Return Me.userName

    End Function

    Public Function getPassword() As String
        Return Me.password

    End Function

    Public Sub Login()
        Me.isLogedIn = True
    End Sub

    Public Sub logOut()
        Me.isLogedIn = False

    End Sub

End Class
