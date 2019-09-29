using BLL.Interface;

namespace BLL
{
    /// <summary>
    /// Account number creator
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Generates number
        /// </summary>
        /// <param name="num">Given number</param>
        /// <returns>Generated number</returns>
        public int GenerateNumber(int num)
        {
            return num + 1;
        }
    }
}