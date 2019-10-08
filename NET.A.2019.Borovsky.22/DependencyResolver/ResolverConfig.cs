using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Database.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IRepository>().To<AccountDbRepository>();
            kernel.Bind<IAccountNumberService>().To<AccountNumberService>().InSingletonScope();
        }
    }
}