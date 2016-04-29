Public Class Schedule

    Private Property schedID As String
    Private Property employeeID As String
    Private Property workDay As Date
    Private Property startTime As String
    Private Property endTime As String
    Private Property daysAvl As String


    Public Sub New(schedID As String, employeeID As String, workDay As Date, startTime As String, endTime As String, daysAvl As String)
        Me.schedID = schedID
        Me.employeeID = employeeID
        Me.workDay = workDay
        Me.startTime = startTime
        Me.endTime = endTime
        Me.daysAvl = daysAvl


    End Sub

    Public Function getSchedID() As String
        Return Me.schedID

    End Function

    Public Function getEmployeeID()
        Return Me.employeeID
    End Function

    Public Function getWordDay() As Date
        Return Me.workDay

    End Function

    Public Function getStartTime()
        Return Me.startTime

    End Function

    Public Function getEndTime()
        Return Me.endTime

    End Function

    Public Function getDaysAvl()
        Return Me.daysAvl

    End Function

End Class
