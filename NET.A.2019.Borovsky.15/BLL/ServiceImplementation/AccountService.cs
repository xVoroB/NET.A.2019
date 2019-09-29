using System;
using System.Collections.Generic;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    /// <summary>
    /// Service class to work with bank accounts
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Rep for bank accounts</param>
        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Number of accounts in repository
        /// </summary>
        public int Count
        {
            get
            {
                return GetCount();
            }
        }

        /// <summary>
        /// Last id in repository
        /// </summary>
        public int Max
        {
            get
            {
                return GetMax();
            }
        }

        /// <summary>
        /// Open new account
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="accountNumberCreator">Account number generator</param>
        public void OpenAccount(string firstName, string lastName, AccountType accountType, IAccountNumberCreateService accountNumberCreator)
        {
            int id = accountNumberCreator.GenerateNumber(Max);
            _repository.AddAccount(new BankAccountDTO(id, firstName, lastName, 0.0m, 0, accountType.ToString()));
        }

        /// <summary>
        /// Closes account
        /// </summary>
        /// <param name="account">Account to close</param>
        public void CloseAcount(BankAccount account)
        {
            BankAccountDTO accToRemove = BankAccountMapper.BankAccToDTO(account);
            _repository.RemoveAccount(accToRemove);
        }

        /// <summary>
        /// Deposits into an account
        /// </summary>
        /// <param name="account">Account to deposit</param>
        /// <param name="deposit">Deposit amount</param>
        public void DepositAccount(BankAccount account, decimal deposit)
        {
            account.Deposit(deposit);
            BankAccountDTO accToUpdate = BankAccountMapper.BankAccToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }

        /// <summary>
        /// Withdraws from an account
        /// </summary>
        /// <param name="account">Account to withdraw</param>
        /// <param name="withdraw">Withdrawal amount</param>
        public void WithdrawAccount(BankAccount account, decimal withdraw)
        {
            account.Withdraw(withdraw);
            BankAccountDTO accToUpdate = BankAccountMapper.BankAccToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }

        /// <summary>
        /// Gets account by its id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Account with given id</returns>
        public BankAccount GetAccountById(int id)
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                if (acc.Id == id)
                {
                    return BankAccountMapper.DTOToBancAcc(acc);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all accounts in the repository
        /// </summary>
        /// <returns>Collection of all accounts in the repository</returns>
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                yield return BankAccountMapper.DTOToBancAcc(acc);
            }
        }

        /// <summary>
        /// Gets number of accounts in repository
        /// </summary>
        /// <returns>Number of accounts in repository</returns>
        private int GetCount()
        {
            int count = 0;

            foreach (var acc in GetAllAccounts())
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Gets last id in repository
        /// </summary>
        /// <returns>Last id</returns>
        private int GetMax()
        {
            int max = 0;

            foreach (var acc in GetAllAccounts())
            {
                if (acc.Id > max)
                {
                    max = acc.Id;
                }
            }

            return max;
        }
    }
}