using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace MyBankApp.Models
{
    public class BankAccount
    {
        [Key] // 主キーを示す属性
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; } // アカウントID
        public string Name { get; set; } // アカウント名
        public string Password { get; set; } // パスワード
        public string Email { get; set; } // メールアドレス
        public decimal Balance  // 残高
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
            set
            {
            }
        }

        public BankAccount(string name, string password, string email, decimal initialBalance)
        {
            // コンストラクタで初期値を設定する
            Name = name;
            Password = password;
            Email = email;
            Balance = initialBalance;
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Name = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            this.AccountId = accountNumberSeed;
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

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
        }

        public string GetAccountHistroty()
        {
            var report = new StringBuilder();
            // Header
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                // Rows
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Note}");
            }
            return report.ToString();
        }

        /*  private List<Transaction> transactions = new List<Transaction>(); // トランザクション履歴

          // アカウントのコンストラクタ
          public BankAccount(int accountId, string name, string password, string email, decimal initialBalance)
          {
              AccountId = accountId;
              Name = name;
              Password = password;
              Email = email;
              Balance = initialBalance;
          }

          // 入金メソッド
          public void MakeDeposit(decimal amount, DateTime date, string note)
          {
              if (amount <= 0)
              {
                  throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
              }

              var deposit = new Transaction { Amount = amount, Date = date, Note = note };
              transactions.Add(deposit);
              Balance += amount;
          }

          // 出金メソッド
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

              var withdrawal = new Transaction { Amount = -amount, Date = date, Note = note };
              transactions.Add(withdrawal);
              Balance -= amount;
          }

          // トランザクション履歴を取得するメソッド
          public List<Transaction> GetTransactions()
          {
              return transactions;
          }*/
    }
}
