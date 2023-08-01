using System;
using System.Collections.Generic;
using System.Text;


namespace MyBank.Models
{
    public class BankAccount
    {
        // アカウントID
        public string AccountID { get; }
        // アカウント名
        public string Owner { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; private set; }



        private List<Transaction> allTransactions = new List<Transaction>();

        // 口座番号
        private static int accountNumberSeed = 1234567890;
        public BankAccount(string name, string password, string email, decimal initialBalance)
        {
            AccountID = accountNumberSeed.ToString();
            accountNumberSeed++;

            Email = email;
            Owner = name;
            Password = password;
            Balance = initialBalance;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        // 預入
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
            Balance += amount;
        }

        // 引き出しメソッド
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            Balance -= amount;
        }

        // 口座の履歴取得メソッド
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }

        // トランザクションを削除するメソッド
        public void DeleteTransaction(DateTime date, decimal amount, string notes)
        {
            // 削除するトランザクションを検索して削除
            var transactionToDelete = allTransactions.Find(t => t.Date == date && t.Amount == amount && t.Notes == notes);
            if (transactionToDelete != null)
            {
                allTransactions.Remove(transactionToDelete);
                Balance -= transactionToDelete.Amount; // 残高を修正
            }
        }
    }
}
