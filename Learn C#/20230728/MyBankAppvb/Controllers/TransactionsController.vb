Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MyBankAppvb
Imports MyBankAppvb.MyBankAppvb.Models

Namespace Controllers
    Public Class TransactionsController
        Inherits System.Web.Mvc.Controller

        Private db As New MovieDBContext

        ' GET: Transactions
        Function Index() As ActionResult
            Return View(db.Transactions.ToList())
        End Function

        ' GET: Transactions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim transaction As Transaction = db.Transactions.Find(id)
            If IsNothing(transaction) Then
                Return HttpNotFound()
            End If
            Return View(transaction)
        End Function

        ' GET: Transactions/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Transactions/Create
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Amount,Date,Note")> ByVal transaction As Transaction) As ActionResult
            If ModelState.IsValid Then
                db.Transactions.Add(transaction)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(transaction)
        End Function

        ' GET: Transactions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim transaction As Transaction = db.Transactions.Find(id)
            If IsNothing(transaction) Then
                Return HttpNotFound()
            End If
            Return View(transaction)
        End Function

        ' POST: Transactions/Edit/5
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Amount,Date,Note")> ByVal transaction As Transaction) As ActionResult
            If ModelState.IsValid Then
                db.Entry(transaction).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(transaction)
        End Function

        ' GET: Transactions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim transaction As Transaction = db.Transactions.Find(id)
            If IsNothing(transaction) Then
                Return HttpNotFound()
            End If
            Return View(transaction)
        End Function

        ' POST: Transactions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim transaction As Transaction = db.Transactions.Find(id)
            db.Transactions.Remove(transaction)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
