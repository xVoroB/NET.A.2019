using DAL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    /// <summary>
    /// Binary file repository for bank accounts
    /// </summary>
    public class AccountBinaryRepository : IRepository
    {
        private readonly List<BankAccountDTO> _accounts;
        private readonly string _filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        public AccountBinaryRepository(string filePath)
        {
            _accounts = new List<BankAccountDTO>();
            _filePath = filePath;
            Import(_filePath);
        }

        /// <summary>
        /// Adds new account to binary file
        /// </summary>
        /// <param name="account">AccountDTO object to add</param>
        public void AddAccount(BankAccountDTO account)
        {
            _accounts.Add(account);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _accounts);
            }
        }

        /// <summary>
        /// Updates account in binary file
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

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _accounts);
            }
        }

        /// <summary>
        /// Removes account from binary file
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

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _accounts);
            }
        }

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>AccountDTO with given id</returns>
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

        /// <summary>
        /// Import accounts from binary file
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        private void Import(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<BankAccountDTO> deserializeAccounts = (List<BankAccountDTO>)formatter.Deserialize(fs);

                    foreach (var account in deserializeAccounts)
                    {
                        _accounts.Add(account);
                    }
                }
            }
        }
    }
}