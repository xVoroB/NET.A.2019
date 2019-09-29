namespace BLL.Interface
{
    /// <summary>
    /// Bank account of silver type
    /// </summary>
    public class SilverAccount : BankAccount
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="balance">Balance</param>
        /// <param name="bonusPoints">Bonus points</param>
        public SilverAccount(int id, string firstName, string lastName, decimal balance, int bonusPoints) :
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
            return (int)(value * 2);
        }

        /// <summary>
        /// Determines if balance value is valid
        /// </summary>
        /// <param name="value">Balance value</param>
        /// <returns>True, if balance value is valid</returns>
        protected override bool IsBalanceValid(decimal value)
        {
            return value >= -50;
        }

        /// <summary>
        /// Converts a silver bank account to string representation
        /// </summary>
        /// <returns>Silver account string</returns>
        public override string ToString()
        {
            return base.ToString() +
                $"\nType: Silver";
        }
    }
}