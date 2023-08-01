using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Security;


namespace MyBankApp.Models
{
    public class Transaction
    {
        public int ID { get; set; } // トランザクションのID
        public decimal Amount { get; set; } // 金額
        public DateTime Date { get; set; } // 日付
        public string Note { get; set; } // 内容

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}