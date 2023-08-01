using Microsoft.AspNetCore.Mvc;
using MyBank.Models;
using System;
using System.Text;

namespace MyBank.Controllers
{
    public class BankAccountController : Controller
    {
        string name = "nishibu"; // ユーザー名を仮定
        string password = "p@ssw0rd"; // パスワードを仮定
        string email = "nishibu@fintechsys.co.jp"; // メールアドレスを仮定
        decimal initialBalance = 10000; // 初期残高を仮定
        public IActionResult Index()
        {
            var account = new BankAccount(name, password, email, initialBalance);
            ViewData["Message"] = $"Account {account.AccountID} was created for {account.Owner} with {account.Balance}.";

            account.MakeWithdrawal(120, DateTime.Now, "Hanmock");
            ViewData["Balance1"] = account.Balance;

            account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");
            ViewData["Balance2"] = account.Balance;

            ViewData["AccountHistory"] = account.GetAccountHistory();

            // 追加: 履歴データを改行区切りの文字列としてビューに渡す
            var history = string.Join(Environment.NewLine, account.GetAccountHistory());
            ViewData["AccountHistoryString"] = history;

            return View();
        }

        // 新規入力画面を表示するアクションメソッド
        public IActionResult NewTransaction()
        {
            return View();
        }

        // 新規入力データを受け取り、入金または出金を行うアクションメソッド
        [HttpPost]
        public IActionResult NewTransaction(decimal amount, DateTime date, string note)
        {
            // 受け取ったデータを使って入金または出金を行う
            if (amount > 0)
            {
                // 入金
                var account = GetBankAccount(); // 既存のデータを取得するメソッド（仮定）
                account.MakeDeposit(amount, date, note);
            }
            else if (amount < 0)
            {
                // 出金
                var account = GetBankAccount(); // 既存のデータを取得するメソッド（仮定）
                account.MakeWithdrawal(-amount, date, note);
            }

            return RedirectToAction("Index");
        }

        // 編集画面を表示するアクションメソッド
        public IActionResult EditTransaction(DateTime date, decimal amount, string notes)
        {
            // 編集画面に表示するデータをViewBagに設定
            ViewBag.Date = date;
            ViewBag.Amount = amount;
            ViewBag.Notes = notes;

            return View();
        }

        // 編集データを受け取り、入金または出金の編集を行うアクションメソッド
        [HttpPost]
        public IActionResult EditTransaction(DateTime oldDate, decimal oldAmount, string oldNotes,
            decimal newAmount, DateTime newDate, string newNotes)
        {
            // 編集前のトランザクションを削除
            var account = GetBankAccount(); // 既存のデータを取得するメソッド（仮定）
            account.DeleteTransaction(oldDate, oldAmount, oldNotes);

            // 編集後のデータを追加
            if (newAmount > 0)
            {
                // 入金
                account.MakeDeposit(newAmount, newDate, newNotes);
            }
            else if (newAmount < 0)
            {
                // 出金
                account.MakeWithdrawal(-newAmount, newDate, newNotes);
            }

            return RedirectToAction("Index");
        }

        // 既存のデータを取得する仮定のメソッド（実際のデータ取得処理はアプリケーションによって異なります）

        private BankAccount GetBankAccount()
        {
            string name = "nishibu"; // ユーザー名を仮定
            string password = "p@ssw0rd"; // パスワードを仮定
            string email = "nishibu@fintechsys.co.jp"; // メールアドレスを仮定
            decimal initialBalance = 10000; // 初期残高を仮定

            // 既存のデータを取得または新規作成
            var account = new BankAccount(name, password, email, initialBalance);

            return account;
        }
    }
}
