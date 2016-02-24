Public Class Employee

    Private Property lastName As String
    Private Property firstName As String
    Private Property midInit As String
    Private Property hoursWorked As Double
    Private Property schedule As Schedule
    Private Property payRate As Double

    Public Sub New(lastName As String, firstName As String, midInit As String, hoursWorked As Double,
                   schedule As Schedule, payRate As Double)

        Me.lastName = lastName
        Me.firstName = firstName
        Me.midInit = midInit
        Me.hoursWorked = hoursWorked
        Me.schedule = schedule
        Me.payRate = payRate

    End Sub

    Public Function displaySchedule() As Schedule
        Return Me.schedule

    End Function



End Class
