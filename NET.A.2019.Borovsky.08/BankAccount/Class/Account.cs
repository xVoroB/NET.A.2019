using System;

namespace BankAccount
{
    class Account
    {
        enum Grad
        {
            Base = 1,
            Gold,
            Platinum
        }

        public int number { get; private set; }
        public string[] owner { get; private set; }
        public double balance { get; private set; }
        public double bonus { get; private set; }
        Grad cardGrad { get; set; }
        public bool status { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Account()
        {
            SetOwnerInfo();
            number = new Random().Next(1, 55555);
            balance = 0;
            bonus = 0;
            status = true;
        }

        /// <summary>
        /// Method to print all information about account to console
        /// </summary>
        public void ShowInfo()
        {
            if (status)
            {
                Console.WriteLine("Card number: {4}. \n" +
                                  "Card gradation: {5} \n" +
                                  "Owner: {1} {2}. \n" +
                                  "Balance: {0}. \n" +
                                  "Bonus: {3}. ",
                                  balance, owner[0], owner[1], bonus, number, cardGrad);
            }
            else
            {
                Console.WriteLine("Card is closed");
            }
        }

        /// <summary>
        /// Method to see palance
        /// </summary>
        public double ShowBalance()
        {
            if (status)
            {
                return balance;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Method to see bonus points
        /// </summary>
        public double ShowBonus()
        {
            if (status)
            {
                return bonus;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Method to set all the information
        /// </summary>
        private void SetOwnerInfo()
        {
            owner = new string[2];
            Console.WriteLine("Enter firstname");
            owner[0] = Console.ReadLine();
            Console.WriteLine("Enter lastname");
            owner[1] = Console.ReadLine();
            Console.WriteLine("Base, Gold or platinum?");
            while (true)
            {
                string one = Console.ReadLine();

                switch (one.ToLower())
                {
                    case "base":
                        cardGrad = Grad.Base;
                        break;
                    case "gold":
                        cardGrad = Grad.Gold;
                        break;
                    case "platinum":
                        cardGrad = Grad.Platinum;
                        break;
                    default:
                        Console.WriteLine("Wrong gradation, enter once more");
                        break;
                }

                if (cardGrad > 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Method to withdraw money from account
        /// </summary>
        /// <param name="sum"> Money to withdraw </param>
        public void Withdraw(double sum)
        {
            if (status)
            {
                if (balance + bonus - sum < 0)
                {
                    Console.WriteLine("You can't overdraft");
                    return;
                }

                if (bonus > 0 && bonus > sum / 10)
                {
                    bonus -= sum / 10;
                    balance -= sum - sum / 10;
                }
                else
                {
                    balance -= sum - bonus;
                    bonus = 0;
                }
            }
            else
            {
                Console.WriteLine("Card is closed");
            }
        }

        /// <summary>
        /// Method to deposit money to account
        /// </summary>
        /// <param name="sum"> Money to deposit </param>
        public void Deposit(double sum)
        {
            if (status)
            {
                BonusCalc(sum);
                balance += sum;
            }
        }

        /// <summary>
        /// Used to calculate bonus points
        /// </summary>
        /// <param name="sum"> Money to calculate from </param>
        private void BonusCalc(double sum)
        {
            bonus += sum * (((double)cardGrad + 5) / 100);
        }

        /// <summary>
        /// Creating new account
        /// </summary>
        /// <param name="newHuman"> If owner is new person - true </param>
        public void NewAccount(bool newHuman)
        {
            if (newHuman)
            {
                SetOwnerInfo();
            }
            balance = 0;
            bonus = 0;
            status = true;
            number = new Random().Next(1, 55555);
        }

        /// <summary>
        /// Method to upgrade card to some gradation
        /// </summary>
        /// <param name="up"> Gradation to be upgraded to </param>
        public void Upgrade(string up)
        {
            if (status)
            {

                if (up.ToLower().Equals("gold"))
                {
                    cardGrad = Grad.Gold;
                }
                else if (up.ToLower().Equals("platinum"))
                {
                    cardGrad = Grad.Platinum;
                }
                else
                {
                    Console.WriteLine("Wrong upgrade attempt");
                }
            }
        }

        /// <summary>
        /// Method to upgrade once per time
        /// </summary>
        public void Upgrade()
        {
            if ((int)cardGrad > 2)
            {
                Console.WriteLine("Wrong upgrade attempt");
            }
            else
            {
                cardGrad++;
            }
        }

        /// <summary>
        /// Method to downgrade once per time
        /// </summary>
        public void Downgrade()
        {
            if ((int)cardGrad < 2)
            {
                Console.WriteLine("Wrong downgrade attempt");
            }
            else
            {
                cardGrad--;
            }
        }

        /// <summary>
        /// Method to downgrade card to some gradation
        /// </summary>
        /// <param name="up"> Gradation to be downgrade to </param>
        public void Downgrade(string down)
        {
            if (status)
            {

                if (down.ToLower().Equals("gold"))
                {
                    cardGrad = Grad.Gold;
                }
                else if (down.ToLower().Equals("base"))
                {
                    cardGrad = Grad.Base;
                }
                else
                {
                    Console.WriteLine("Wrong downgrade attempt");
                }
            }
        }

        /// <summary>
        /// Method to close the account
        /// </summary>
        public void Close()
        {
            status = false;
            balance = 0;
            bonus = 0;
        }
    }
}
