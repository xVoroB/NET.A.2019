using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Database.Models
{
    public class AccountOwner
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountOwner()
        {
            Accounts = new HashSet<Account>();
        }

        /// <summary>
        /// Id of the account owner
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the account owner
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the account owner
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Collection of the owner's accounts
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
    }
}