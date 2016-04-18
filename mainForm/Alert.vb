Public Class Alert

    Private Property alertID As String
    Private Property memberID As String
    Private Property alertType As String
    Private Property alertCount As Integer
    Private Property alertStatus As String
    Private Property alertDate As Date
    Private Property alertMessage As String


    Public Sub New(alertID As String, memberID As String, alertType As String, alertStatus As String, alertCount As Integer, alertDate As Date, alertMessage As String)
        Me.alertID = alertID
        Me.memberID = memberID
        Me.alertType = alertType
        Me.alertStatus = alertStatus
        Me.alertCount = alertCount
        Me.alertDate = alertDate
        Me.alertMessage = alertMessage


    End Sub

    Public Function getAlertID() As String
        Return Me.alertID

    End Function

    Public Function getMemberID() As String
        Return Me.memberID

    End Function

    Public Function getAlertType() As String
        Return Me.alertType

    End Function

    Public Function getAlertCount() As Integer
        Return Me.alertCount

    End Function

    Public Function getAlertDate() As Date
        Return Me.alertDate

    End Function

    Public Function getAlertMessage() As String
        Return Me.alertMessage

    End Function

    Public Function getAlertStatus() As String
        Return Me.alertStatus

    End Function

End Class
