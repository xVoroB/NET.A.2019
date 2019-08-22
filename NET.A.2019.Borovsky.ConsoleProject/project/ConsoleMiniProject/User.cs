using System;
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
        public User()
        {
            counter++;
        }

        public User(int index, string firstName, string lastName, string birthDate)
        {
            counter++;
            number = index;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        public void ZeroCount()
        {
            counter = 0;
        }

        public void MinusCount()
        {
            counter--;
        }

        public void Create()
        {
            Console.WriteLine("Enter first name");
            string input = Console.ReadLine();
            //check
            SetNames(input, 1);
            Console.WriteLine("Enter last name");
            input = Console.ReadLine();
            //check
            SetNames(input, 2);
            Console.WriteLine("Enter date of birth");
            input = Console.ReadLine();
            //check
            SetNames(input, 3);
        }

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

        public string GetInfo()
        {
            return ("#" + number + ", " + firstName + ", " + lastName);
        }
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

        public void Edit()
        {
            GetInfo();

            Console.WriteLine("Enter firstname");
            string input = Console.ReadLine();
            //check
            firstName = input;
            Console.WriteLine("Enter lastname");
            input = Console.ReadLine();
            //check
            lastName = input;
            Console.WriteLine("Enter date of birth");
            input = Console.ReadLine();
            //check
            birthDate = input;

            Console.WriteLine("Record #{0} is edited", number);
        }

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
