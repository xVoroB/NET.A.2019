using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Bank account
    /// </summary>
    public abstract class BankAccount
    {
        private int _id, _bonusPoints;
        private string _firstName, _lastName;
        private decimal _balance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="balance">Balance</param>
        /// <param name="bonusPoints">Bonus points</param>
        public BankAccount(int id, string firstName, string lastName, decimal balance, int bonusPoints)
        {
            Id = id;
            BonusPoints = bonusPoints;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        /// <summary>
        /// Id of the account
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Wrong id");
                }
            }
        }

        /// <summary>
        /// Bonus points of the account
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return _bonusPoints;
            }
            set
            {
                if (value >= 0)
                {
                    _bonusPoints = value;
                }
                else
                {
                    throw new ArgumentException("Wrong bonus points");
                }
            }
        }

        /// <summary>
        /// First name of the owner
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Wrong firstname");
                }
            }
        }

        /// <summary>
        /// Last name of the owner
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("Wrong lastname");
                }
            }
        }

        /// <summary>
        /// Balance of the account
        /// </summary>
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    throw new ArgumentException("Wrong balance");
                }
            }
        }

        /// <summary>
        /// Converts a bank account to string representation
        /// </summary>
        /// <returns>Bank account string</returns>
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                  $"First name: {FirstName}\n" +
                  $"Last name: {LastName}\n" +
                  $"Balance: {Balance:C2}\n" +
                  $"Bonus points: {BonusPoints}";
        }

        /// <summary>
        /// Deposits into an account
        /// </summary>
        /// <param name="depositAmount">Deposit amount</param>
        public void Deposit(decimal depositAmount)
        {
            if (depositAmount < 0)
            {
                throw new ArgumentException("Wrong deposit amount");
            }

            Balance += depositAmount;
            BonusPoints += CalculateBonusPoints(depositAmount);
        }

        /// <summary>
        /// Withdraws from an account
        /// </summary>
        /// <param name="withdrawAmount">Withdraw amount</param>
        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount < 0)
            {
                throw new ArgumentException("Wrong withdraw amount");
            }

            Balance -= withdrawAmount;
            int newBonusPoints = CalculateBonusPoints(withdrawAmount);
            if (BonusPoints < newBonusPoints)
            {
                BonusPoints = 0;
            }
            else
            {
                BonusPoints -= newBonusPoints;
            }
        }

        /// <summary>
        /// Calculates bonus points
        /// </summary>
        /// <param name="value">Value to operate</param>
        /// <returns>Calculated bonus points</returns>
        protected abstract int CalculateBonusPoints(decimal value);

        /// <summary>
        /// Determines if balance value is valid
        /// </summary>
        /// <param name="value">Balance value</param>
        /// <returns>True, if balance value is valid</returns>
        protected abstract bool IsBalanceValid(decimal value);
    }
}
