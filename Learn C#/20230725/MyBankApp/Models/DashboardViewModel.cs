using System.Collections.Generic;


namespace MyBankApp.Models
{ 
    public class DashboardViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}