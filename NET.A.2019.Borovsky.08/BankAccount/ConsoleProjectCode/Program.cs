using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();

            account.Withdraw(50);
            account.ShowBalance();
            account.ShowBonus();

            account.Deposit(500);
            account.ShowInfo();

            account.Withdraw(530);
            account.ShowInfo();

            account.Upgrade("gold");
            account.Deposit(150);

            account.Downgrade("base");
            account.ShowInfo();

            account.Withdraw(160.5);

            Console.WriteLine(account.ShowBalance());

            account.Close();
            account.ShowInfo();

            account.NewAccount(false);
            account.Deposit(50);
            account.Withdraw(10);

            account.Upgrade();
            account.ShowInfo();


            account.NewAccount(true);
            account.ShowInfo();
        }
    }
}
