Imports System.Data.Entity

Public Class Movie
    Public Property ID() As Integer
    Public Property Title() As String
    Public Property ReleaseDate() As Date
    Public Property Genre() As String
    Public Property Price() As Decimal
End Class

Public Class MovieDBContext
    Inherits DbContext
    Public Property Movies() As DbSet(Of Movie)
    Public Property BankAccounts As System.Data.Entity.DbSet(Of MyBankAppvb.Models.BankAccount)
    Public Property Transactions As System.Data.Entity.DbSet(Of MyBankAppvb.Models.Transaction)
End Class