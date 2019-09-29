using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    class AccountNumberService : IAccountNumberService
    {
        public int GenerateNumber(int number)
        {
            return number + 1;
        }
    }
}
