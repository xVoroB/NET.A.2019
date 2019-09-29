using System.Collections.Generic;

namespace DAL.Interface
{
    /// <summary>
    /// Interface for repository classes
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds new account to repository
        /// </summary>
        /// <param name="account">Bank account DTO object to add</param>
        void AddAccount(BankAccountDTO account);

        /// <summary>
        /// Updates account in repository
        /// </summary>
        /// <param name="account">Bank account DTO object to update</param>
        void UpdateAccount(BankAccountDTO account);

        /// <summary>
        /// Removes account from repository
        /// </summary>
        /// <param name="account">Bank account DTO object to remove</param>
        void RemoveAccount(BankAccountDTO account);

        /// <summary>
        /// Gets account by its id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Bank account DTO object with given id</returns>
        BankAccountDTO GetAccountById(int id);

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        /// <returns>All DTO account objects</returns>
        IEnumerable<BankAccountDTO> GetAll();
    }
}