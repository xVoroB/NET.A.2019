using DAL.Interface.DTO;
using System;
using System.Collections.Generic;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Fake repository for bank accounts
    /// </summary>
    public class FakeRepository
    {
        private readonly List<BankAccountDTO> _accounts;

        /// <summary>
        /// Constructor
        /// </summary>
        public FakeRepository()
        {
            _accounts = new List<BankAccountDTO>();
        }

        /// <summary>
        /// Adds new account to fake repository
        /// </summary>
        /// <param name="account">Bank account DTO object to add</param>
        public void AddAccount(BankAccountDTO account)
        {
            _accounts.Add(account);
        }

        /// <summary>
        /// Updates account in fake repository
        /// </summary>
        /// <param name="account">AccountDTO object to update</param>
        public void UpdateAccount(BankAccountDTO account)
        {
            BankAccountDTO oldAccount = _accounts.Find(acc => acc.Id == account.Id);

            if (oldAccount == null)
            {
                throw new ArgumentException("There is no such account in repository.");
            }

            oldAccount.FirstName = account.FirstName;
            oldAccount.LastName = account.LastName;
            oldAccount.Balance = account.Balance;
            oldAccount.BonusPoints = account.BonusPoints;
            oldAccount.AccountType = account.AccountType;
        }

        /// <summary>
        /// Removes account from fake repository
        /// </summary>
        /// <param name="account">AccountDTO object to remove</param>
        public void RemoveAccount(BankAccountDTO account)
        {
            BankAccountDTO accountToRemove = _accounts.Find(acc => acc.Id == account.Id);

            if (accountToRemove == null)
            {
                throw new ArgumentException("There is no such account in repository.");
            }

            _accounts.Remove(accountToRemove);
        }

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>AccountDTO object with given id</returns>
        public BankAccountDTO GetAccountById(int id)
        {
            return _accounts.Find(acc => acc.Id == id);
        }

        /// <summary>
        /// Gets all accounts
        /// </summary>
        /// <returns>All DTO account objects</returns>
        public IEnumerable<BankAccountDTO> GetAll()
        {
            foreach (BankAccountDTO account in _accounts)
            {
                yield return account;
            }
        }
    }
}
