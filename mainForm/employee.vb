Public Class Employee

    Private Property empID As String
    Private Property name As String
    Private Property phone As String
    Private Property dateHired As Date
    Private Property dob As Date
    Private Property login As String
    Private Property password As String
    Private Property hoursWorked As Double
    Private Property schedule As Schedule
    Private Property payRate As Double

    Public Sub New(empID As String, name As String, phone As String, datehired As Date, dob As Date, login As String, password As String)

        Me.empID = empID
        Me.name = name
        Me.phone = phone
        Me.dateHired = datehired
        Me.dob = dob
        Me.login = login
        Me.password = password


    End Sub

    Public Function displaySchedule() As Schedule
        Return Me.schedule

    End Function

    Public Function getEmpID() As String
        Return Me.empID

    End Function

    Public Function getName() As String
        Return Me.name

    End Function

    Public Function getPhone() As String
        Return Me.phone

    End Function

    Public Function getDateHired() As Date
        Return Me.dateHired
    End Function

    Public Function getDOB() As Date
        Return Me.dob

    End Function

    Public Function getLogin() As String
        Return Me.login

    End Function

    Public Function getPassword() As String
        Return Me.password

    End Function
End Class
