using System;
using BLL.Interface;
using DependencyResolver;
using Ninject;

namespace ConsoleUI
{
    internal class Program
    {
        private static readonly IKernel _Resolver;

        static Program()
        {
            _Resolver = new StandardKernel();
            _Resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService service = _Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = _Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Owner", "First", AccountType.Base, creator);
            service.OpenAccount("Owner", "Second", AccountType.Silver, creator);
            service.OpenAccount("Owner", "Third", AccountType.Gold, creator);
            service.OpenAccount("Owner", "Fourth", AccountType.Base, creator);

            var accounts = service.GetAllAccounts();

            foreach (var t in accounts)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in accounts)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}