using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Collections.Generic;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;
        public AccountService(IRepository repository)
        {
            _repository = repository;
        }
        public int Count
        {
            get
            {
                return GetCount();
            }
        }
        public int Last
        {
            get
            {
                return GetLast();
            }
        }

        public void CloseAccount(BankAccount account)
        {
            BankAccountDTO accToRemove = AccountMapper.AccountToDTO(account);
            _repository.RemoveAccount(accToRemove);
        }

        public void DepositAccount(BankAccount account, decimal deposit)
        {
            account.Deposit(deposit);
            BankAccountDTO accToUpdate = AccountMapper.AccountToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                yield return AccountMapper.DTOToAccount(acc);
            }
        }
        private int GetCount()
        {
            int count = 0;

            foreach (var acc in GetAllAccounts())
            {
                count++;
            }

            return count;
        }
        private int GetLast()
        {
            int last = 0;

            foreach (var acc in GetAllAccounts())
            {
                if (acc.Id > last)
                {
                    last = acc.Id;
                }
            }

            return last;
        }

        public BankAccount GetAccountById(int id)
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                if (acc.Id == id)
                {
                    return AccountMapper.DTOToAccount(acc);
                }
            }

            return null;
        }

        public void OpenAccount(string firstName, string lastName, AccountType accountType, IAccountNumberService accountNumberCreator)
        {
            int id = accountNumberCreator.GenerateNumber(Last);
            _repository.AddAccount(new BankAccountDTO(id, firstName, lastName, 0.0m, 0, accountType.ToString()));
        }

        public void WithdrawAccount(BankAccount account, decimal withdraw)
        {
            account.Withdraw(withdraw);
            BankAccountDTO accToUpdate = AccountMapper.AccountToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }
    }
}
