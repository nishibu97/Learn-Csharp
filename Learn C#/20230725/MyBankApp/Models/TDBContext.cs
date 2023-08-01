using System.Collections.Generic;
using System.Data.Entity;

namespace MyBankApp.Models
{
    public class TDBContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        // DbContextを構成するためのコンストラクタ
/*        public TDBContext(DbContextOptions<TDBContext> options) : base(options)
        {
        }*/

    }
}
