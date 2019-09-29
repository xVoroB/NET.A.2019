using System.Collections.Generic;

namespace BLL.Interface
{
    /// <summary>
    /// Interface for bank account service classes
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Opens new account
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="accountNumberGenerator">Account number generator</param>
        void OpenAccount(string firstName, string lastName, AccountType accountType, IAccountNumberCreateService accountNumberGenerator);

        /// <summary>
        /// Closes account
        /// </summary>
        /// <param name="account">Account to close</param>
        void CloseAcount(BankAccount account);

        /// <summary>
        /// Deposits into an account
        /// </summary>
        /// <param name="account">Account to deposit to</param>
        /// <param name="deposit">Deposit amount</param>
        void DepositAccount(BankAccount account, decimal deposit);

        /// <summary>
        /// Withdraws from an account
        /// </summary>
        /// <param name="account">Account to withdraw from</param>
        /// <param name="withdrawal">Withdrawal amount</param>
        void WithdrawAccount(BankAccount account, decimal withdrawal);

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="id">Id of account</param>
        /// <returns>Account with given id</returns>
        BankAccount GetAccountById(int id);

        /// <summary>
        /// Gets all accounts in the repository
        /// </summary>
        /// <returns>All accounts in the repository</returns>
        IEnumerable<BankAccount> GetAllAccounts();
    }
}