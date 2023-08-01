Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports System.Text

Namespace MyBankAppvb.Models
    Public Class BankAccount
        <Key> ' 主キーを示す属性
        Public Property AccountId As String ' アカウントID
        Public Property Name As String ' アカウント名
        Public Property Password As String ' パスワード
        Public Property Email As String ' メールアドレス
        Public Property Balance As Decimal ' 残高

        Private ReadOnly allTransactions As List(Of Transaction) = New List(Of Transaction)()
        Private Shared accountNumberSeed As Integer = 1234567890

        Public Sub New(name As String, password As String, email As String, initialBalance As Decimal)
            ' コンストラクタで初期値を設定する
            Me.Name = name
            Me.Password = password
            Me.Email = email
            Me.Balance = initialBalance
        End Sub

        Public Sub New(name As String, initialBalance As Decimal)
            Me.Name = name

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance")

            Me.AccountId = accountNumberSeed.ToString()
            accountNumberSeed += 1
        End Sub

        Public Sub MakeDeposit(amount As Decimal, [date] As DateTime, note As String)
            If amount <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(amount), "Amount of deposit must be positive")
            End If
            Dim deposit = New Transaction(amount, [date], note)
            allTransactions.Add(deposit)
        End Sub

        Public Sub MakeWithdrawal(amount As Decimal, [date] As DateTime, note As String)
            If amount <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(amount), "Amount of withdrawal must be positive")
            End If
            If Balance - amount < 0 Then
                Throw New InvalidOperationException("Not sufficient funds for this withdrawal")
            End If
            Dim withdrawal = New Transaction(-amount, [date], note)
            allTransactions.Add(withdrawal)
        End Sub

        Public Function GetAccountHistory() As String
            Dim report = New StringBuilder()
            ' Header
            report.AppendLine("Date" & vbTab & "Amount" & vbTab & "Note")
            For Each item In allTransactions
                ' Rows
                report.AppendLine($"{item.Date.ToShortDateString()}{vbTab}{item.Amount}{vbTab}{item.Note}")
            Next
            Return report.ToString()
        End Function
    End Class
End Namespace
