using System.Data.Entity;
using DAL.Database.Models;

namespace DAL.Database.Context
{
    public class AccountContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountContext() : base("DbConnection")
        {
            System.Data.Entity.Database.SetInitializer(new AccountsInitializer());
            Database.Initialize(true);
        }

        /// <summary>
        /// Set of accounts stored in database
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Set of account owners in database
        /// </summary>
        public DbSet<AccountOwner> AccountOwners { get; set; }

        /// <summary>
        /// Set of account types in database
        /// </summary>
        public DbSet<AccountTypeDB> AccountTypes { get; set; }
    }
}