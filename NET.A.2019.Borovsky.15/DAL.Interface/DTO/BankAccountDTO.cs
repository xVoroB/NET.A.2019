namespace DAL.Interface.DTO
{
    /// <summary>
    /// Account DTO object
    /// </summary>
    public class BankAccountDTO
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="balance">Balance</param>
        /// <param name="bonusPoints">Bonus points</param>
        /// <param name="accountType">Account type</param>
        public BankAccountDTO(int id, string firstName, string lastName, decimal balance, int bonusPoints, string accountType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            BonusPoints = bonusPoints;
            AccountType = accountType;
        }

        /// <summary>
        /// Id of the account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the owner
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the owner
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Balance of the account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus points of the account
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        public string AccountType { get; set; }
    }
}
