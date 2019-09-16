﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMiniProject
{
    public class User
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string birthDate { get; private set; }
        public int number { get; set; }

        static int counter;

        /// <summary>
        /// Basic constructor
        /// </summary>
        public User()
        {
            counter++;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="index"> Current index </param>
        /// <param name="firstName"> Firstname </param>
        /// <param name="lastName"> Lastname </param>
        /// <param name="birthDate"> Date of birth </param>
        public User(int index, string firstName, string lastName, string birthDate)
        {
            counter++;
            number = index;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        /// <summary>
        /// Setting counter to zero
        /// </summary>
        public void ZeroCount()
        {
            counter = 0;
        }

        /// <summary>
        /// Creating the user
        /// </summary>
        public void Create()
        {
            string input = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter firstname");
                input = Console.ReadLine();
                isValid = Check.FirstName(input);
            }
            SetNames(input, 1);

            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter lastname");
                input = Console.ReadLine();
                isValid = Check.LastName(input);
            }
            SetNames(input, 2);

            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter date of birth");
                input = Console.ReadLine();
                isValid = Check.BirthDate(input);
            }
            SetNames(input, 3);
        }

        /// <summary>
        /// Setting data
        /// </summary>
        /// <param name="input"> Input </param>
        /// <param name="whichInput"> Position of input </param>
        public void SetNames(string input, int whichInput)
        {
            if (whichInput == 1)
            {
                firstName = input;
            }
            else if (whichInput == 2)
            {
                lastName = input;
            }
            else if (whichInput == 3)
            {
                birthDate = input;
                number = counter;
                Console.WriteLine("Record #{0} is created", number);
            }
        }

        /// <summary>
        /// Getting user info
        /// </summary>
        /// <returns> All user info </returns>
        public string GetInfo()
        {
            return ("#" + number + ", " + firstName + ", " + lastName);
        }

        /// <summary>
        /// Finder
        /// </summary>
        /// <param name="toFind"> What property to find </param>
        /// <param name="setter"> What to find </param>
        /// <returns> Id </returns>
        public int Finder(string toFind, string setter)
        {
            setter = setter.Trim('\"', '\'');
            if (toFind.Equals("firstname"))
            {
                if (firstName == setter)
                {
                    return number;
                }
            }
            else if (toFind.Equals("lastname"))
            {
                if (lastName == setter)
                {
                    return number;
                }
            }
            return 0;
        }

        /// <summary>
        /// Method to edit user
        /// </summary>
        public void Edit()
        {
            GetInfo();

            string input = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter firstname");
                input = Console.ReadLine();
                isValid = Check.FirstName(input);
            }
            SetNames(input, 1);

            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter lastname");
                input = Console.ReadLine();
                isValid = Check.LastName(input);
            }
            SetNames(input, 2);

            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter date of birth");
                input = Console.ReadLine();
                isValid = Check.BirthDate(input);
            }
            SetNames(input, 3);

            Console.WriteLine("Record #{0} is edited", number);
        }

        /// <summary>
        /// Extended list
        /// </summary>
        /// <param name="finder"> Property to show </param>
        /// <returns> Value of property </returns>
        public string ExtendedList(string finder)
        {
            if (finder.Equals("firstname"))
            {
                return firstName;
            }
            else if (finder.Equals("id"))
            {
                return ("#" + number.ToString());
            }
            else if (finder.Equals("lastname"))
            {
                return lastName;
            }
            return "";
        }
    }   

}
