using BLL;
using BLL.Interface;
using DAL;
using DAL.Interface;
using Ninject;

namespace DependencyResolver
{
    /// <summary>
    /// Configuration for dependency resolver
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Configurates dependency resolver
        /// </summary>
        /// <param name="kernel">Kernel instance</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();

            // kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");

            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();

            // kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}