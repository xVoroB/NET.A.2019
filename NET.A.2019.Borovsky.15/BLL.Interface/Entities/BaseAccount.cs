namespace BLL.Interface
{
    /// <summary>
    /// Bank account of base type
    /// </summary>
    public class BaseAccount : BankAccount
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="balance">Balance</param>
        /// <param name="bonusPoints">Bonus points</param>
        public BaseAccount(int id, string firstName, string lastName, decimal balance, int bonusPoints) :
            base(id, firstName, lastName, balance, bonusPoints)
        {
        }

        /// <summary>
        /// Calculates bonus points
        /// </summary>
        /// <param name="value">Value to operate</param>
        /// <returns>Calculated bonus points</returns>
        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * 1);
        }

        /// <summary>
        /// Determines if balance value is valid
        /// </summary>
        /// <param name="value">Balance value</param>
        /// <returns>True, if balance value is valid</returns>
        protected override bool IsBalanceValid(decimal value)
        {
            return value >= 0;
        }

        /// <summary>
        /// Converts a base bank account to string representation
        /// </summary>
        /// <returns>Base account string</returns>
        public override string ToString()
        {
            return base.ToString() +
                $"\nType: Base";
        }
    }
}