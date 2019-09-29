using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using System.Reflection;

namespace BLL.Mappers
{
    public class AccountMapper
    {
        public static BankAccountDTO AccountToDTO(BankAccount account)
        {
            return new BankAccountDTO(
                account.Id,
                account.FirstName,
                account.LastName,
                account.Balance,
                account.BonusPoints,
                account.GetType().ToString());
        }

        public static BankAccount DTOToAccount(BankAccountDTO accountDTO)
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
    }
}
