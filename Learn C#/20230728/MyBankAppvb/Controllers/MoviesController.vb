Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MyBankAppvb

Namespace Controllers
    Public Class MoviesController
        Inherits System.Web.Mvc.Controller

        Private db As New MovieDBContext

        ' GET: Movies
        Function Index() As ActionResult
            Return View(db.Movies.ToList())
        End Function

        ' GET: Movies/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        ' GET: Movies/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Movies/Create
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Title,ReleaseDate,Genre,Price")> ByVal movie As Movie) As ActionResult
            If ModelState.IsValid Then
                db.Movies.Add(movie)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(movie)
        End Function

        ' GET: Movies/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        ' POST: Movies/Edit/5
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Title,ReleaseDate,Genre,Price")> ByVal movie As Movie) As ActionResult
            If ModelState.IsValid Then
                db.Entry(movie).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(movie)
        End Function

        ' GET: Movies/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim movie As Movie = db.Movies.Find(id)
            If IsNothing(movie) Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        ' POST: Movies/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim movie As Movie = db.Movies.Find(id)
            db.Movies.Remove(movie)
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
