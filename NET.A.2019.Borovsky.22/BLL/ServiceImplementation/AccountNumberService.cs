using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberService : IAccountNumberService
    {
        public int GenerateNumber(int number)
        {
            return number + 1;
        }
    }
}
