using System.Text.RegularExpressions;

namespace BookService
{
    /// <summary>
    /// Class to validate incoming information
    /// </summary>
    public static class IsValid
    {
        /// <summary>
        /// Method to validate author info
        /// </summary>
        public static bool Author(string value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to validate ISBN
        /// </summary>
        public static bool ISBN(string value)
        {
            value = value.Replace("-", "");
            if (Regex.IsMatch(value, @"\d"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to validate publisher info
        /// </summary>
        public static bool Publisher(string value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to validate paublish year
        /// </summary>
        public static bool PublishYear(int value)
        {
            if (value < 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to validate title
        /// </summary>
        public static bool Title(string value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to validate price
        /// </summary>
        public static bool Price(double value)
        {
            if (value < 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to validate number of pages
        /// </summary>
        public static bool Pages(int value)
        {
            if (value < 0)
            {
                return false;
            }
            return true;
        }
    }

}
