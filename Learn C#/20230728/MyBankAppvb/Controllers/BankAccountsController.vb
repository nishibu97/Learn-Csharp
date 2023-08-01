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
    Public Class BankAccountsController
        Inherits System.Web.Mvc.Controller

        Private db As New MovieDBContext

        ' GET: BankAccounts
        Function Index() As ActionResult
            Return View(db.BankAccounts.ToList())
        End Function

        ' GET: BankAccounts/Details/5
        Function Details(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bankAccount As BankAccount = db.BankAccounts.Find(id)
            If IsNothing(bankAccount) Then
                Return HttpNotFound()
            End If
            Return View(bankAccount)
        End Function

        ' GET: BankAccounts/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: BankAccounts/Create
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="AccountId,Name,Password,Email,Balance")> ByVal bankAccount As BankAccount) As ActionResult
            If ModelState.IsValid Then
                db.BankAccounts.Add(bankAccount)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(bankAccount)
        End Function

        ' GET: BankAccounts/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bankAccount As BankAccount = db.BankAccounts.Find(id)
            If IsNothing(bankAccount) Then
                Return HttpNotFound()
            End If
            Return View(bankAccount)
        End Function

        ' POST: BankAccounts/Edit/5
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="AccountId,Name,Password,Email,Balance")> ByVal bankAccount As BankAccount) As ActionResult
            If ModelState.IsValid Then
                db.Entry(bankAccount).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(bankAccount)
        End Function

        ' GET: BankAccounts/Delete/5
        Function Delete(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bankAccount As BankAccount = db.BankAccounts.Find(id)
            If IsNothing(bankAccount) Then
                Return HttpNotFound()
            End If
            Return View(bankAccount)
        End Function

        ' POST: BankAccounts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As String) As ActionResult
            Dim bankAccount As BankAccount = db.BankAccounts.Find(id)
            db.BankAccounts.Remove(bankAccount)
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
