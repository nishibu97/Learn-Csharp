using Microsoft.AspNetCore.Mvc;
using MyBank.Models;
using System;

namespace MyBank.Controllers
{
    public class BankAccountController : Controller
    {
        public IActionResult Index()
        {
            var account = new BankAccount("Kendara", 10000);
            ViewData["Message"] = $"Account {account.Number} was created for {account.Owner} with {account.Balance}.";

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
    }
}

