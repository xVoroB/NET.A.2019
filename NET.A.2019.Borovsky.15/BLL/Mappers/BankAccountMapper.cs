using System;
using System.Reflection;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    /// <summary>
    /// Class for mapping BankAccount object to BankAccountDTO object and vice versa
    /// </summary>
    public static class BankAccountMapper
    {
        /// <summary>
        /// Maps BankAccountDTO object to BankAccount object
        /// </summary>
        /// <param name="accountDTO">BankAccountDTO object</param>
        /// <returns>Generated BankAccount object</returns>
        public static BankAccount DTOToBancAcc(BankAccountDTO accountDTO)
        {
            string accountType = accountDTO.AccountType;

            if (accountType.Substring(0, 3) != "BLL")
            {
                accountType = "BLL.Interface." + accountType + "Account";
            }

            Assembly asm = typeof(BaseAccount).Assembly;
            Type type = asm.GetType(accountType);

            dynamic account = Activator.CreateInstance(type, accountDTO.Id, accountDTO.FirstName, accountDTO.LastName, accountDTO.Balance, accountDTO.BonusPoints) as BankAccount;

            return account;
        }

        /// <summary>
        /// Maps BankAccount object to BankAccountDTO object
        /// </summary>
        /// <param name="account">BankAccount object</param>
        /// <returns>Generated BankAccountDTO object</returns>
        public static BankAccountDTO BankAccToDTO(BankAccount account)
        {
            return new BankAccountDTO(
                account.Id,
                account.FirstName,
                account.LastName,
                account.Balance,
                account.BonusPoints,
                account.GetType().ToString());
        }


    }
}