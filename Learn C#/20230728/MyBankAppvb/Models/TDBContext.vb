Imports System.Collections.Generic
Imports System.Data.Entity
Imports MyBankAppvb.MyBankAppvb.Models

Namespace MyBankAppvb.Models
    Public Class TDBContext
        Inherits DbContext

        Public Property Transactions As DbSet(Of Transaction)
        Public Property BankAccounts As DbSet(Of BankAccount)

    End Class
End Namespace
