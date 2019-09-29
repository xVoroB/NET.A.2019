using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Interface for repository classes
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds new account to repository
        /// </summary>
        /// <param name="account">DTO account to add</param>
        void AddAccount(BankAccountDTO account);

        /// <summary>
        /// Updates account in repository
        /// </summary>
        /// <param name="account">DTO account to update</param>
        void UpdateAccount(BankAccountDTO account);

        /// <summary>
        /// Removes account from repository
        /// </summary>
        /// <param name="account">DTO account to remove</param>
        void RemoveAccount(BankAccountDTO account);

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>DTO account with given id</returns>
        BankAccountDTO GetAccountById(int id);

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        /// <returns>All DTO account objects</returns>
        IEnumerable<BankAccountDTO> GetAll();
    }
}
