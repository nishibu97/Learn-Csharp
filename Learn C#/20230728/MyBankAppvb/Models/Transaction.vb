Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Web.Security

Namespace MyBankAppvb.Models
    Public Class Transaction
        Public Property ID As Integer ' トランザクションのID
        Public Property Amount As Decimal ' 金額
        Public Property [Date] As DateTime ' 日付
        Public Property Note As String ' 内容

        Public Sub New(ByVal amount As Decimal, ByVal [date] As DateTime, ByVal note As String)
            amount = amount
            [date] = [date]
            note = note
        End Sub
    End Class
End Namespace
