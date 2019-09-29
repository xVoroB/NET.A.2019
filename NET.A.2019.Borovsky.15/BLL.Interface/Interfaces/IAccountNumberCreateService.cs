namespace BLL.Interface
{
    /// <summary>
    /// Interface for account number generator classes
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Generates number
        /// </summary>
        /// <param name="number">Given number</param>
        /// <returns>Generated number</returns>
        int GenerateNumber(int number);
    }
}