using System;
using System.Globalization;
using System.Threading;

namespace BLL.Interface
{
    /// <summary>
    /// Bank account
    /// </summary>
    public abstract class BankAccount
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private decimal _balance;
        private int _bonusPoints;

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
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            BonusPoints = bonusPoints;
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
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid id value");
                }

                _id = value;
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
                if (value == null)
                {
                    throw new ArgumentException("Invalid first name value");
                }

                _firstName = value;
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
                if (value == null)
                {
                    throw new ArgumentException("Invalid last name value");
                }

                _lastName = value;
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
                if (!IsBalanceValid(value))
                {
                    throw new ArgumentException("Invalid balance value");
                }

                _balance = value;
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
                if (value < 0)
                {
                    throw new ArgumentException("Invalid bonus points value");
                }

                _bonusPoints = value;
            }
        }

        /// <summary>
        /// Converts a bank account to string representation
        /// </summary>
        /// <returns>Bank account string</returns>
        public override string ToString()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;

            return $"Id: {Id}\n" +
                   $"First name: {FirstName}\n" +
                   $"Last name: {LastName}\n" +
                   $"Balance: {Balance:C2}\n" +
                   $"Bonus points: {BonusPoints}";
        }

        /// <summary>
        /// Deposits into an account
        /// </summary>
        /// <param name="deposit">Deposit amount</param>
        public void Deposit(decimal deposit)
        {
            if (deposit < 0)
            {
                throw new ArgumentException("Impossible to deposite negative amount");
            }

            Balance += deposit;
            BonusPoints += CalculateBonusPoints(deposit);
        }

        /// <summary>
        /// Withdraws from an account
        /// </summary>
        /// <param name="withdrawal">Withdrawal amount</param>
        public void Withdraw(decimal withdrawal)
        {
            if (withdrawal < 0)
            {
                throw new ArgumentException("Impossible to withdraw negative amount");
            }

            Balance -= withdrawal;

            int newBonusPoints = CalculateBonusPoints(withdrawal);
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