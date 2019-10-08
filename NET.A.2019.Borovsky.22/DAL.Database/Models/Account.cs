namespace DAL.Database.Models
{
    public class Account
    {
        /// <summary>
        /// Id of the account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the account owner
        /// </summary>
        public int AccountOwnerId { get; set; }

        /// <summary>
        /// Balance of the account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus points of the account
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Id of the account type of the account
        /// </summary>
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Owner of the account
        /// </summary>
        public virtual AccountOwner AccountOwner { get; set; }

        /// <summary>
        /// Account type of the account
        /// </summary>
        public virtual AccountTypeDB AccountType { get; set; }
    }
}