using System;

namespace HomeWork12
{
    public class BSearch
    {
        /// <summary>
        /// Method provides binary search through array
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="search"> Number to search </param>
        /// <returns> Flase or true </returns>
        public static bool BinarySearch(int[] array, int search)
        {
            if (array.Length == 1 && search == array[0])
            {
                return true;
            }
            else if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("You can't find anything in empty array");
            }
            else
            {
                int left = 0,
                    right = array.Length - 1, 
                    mid = (right + left) / 2,
                    find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];
                    }
                    else if (search < find)
                    {
                        right = mid;
                        mid = (left + right) / 2;
                        find = array[mid];
                    }
                    else if (search == find)
                    {
                        return true;
                    }
                    if (right - left == 1)
                    {
                        right++;
                        mid = (left + right) / 2;
                    }

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
