using System;

namespace HomeWork12
{
    public class BSearch
    {
        /// <summary>
        /// Method provide binary search through array
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="search"> Number to search </param>
        /// <returns> False or true </returns>

        public static bool BinarySearch(double[] array, double search)
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
                double temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;

                double find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }

        }
        public static bool BinarySearch(long[] array, long search)
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
                long temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;
                long find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }

        }
        public static bool BinarySearch(ulong[] array, ulong search)
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
                ulong temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;
                ulong find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }

        }
        public static bool BinarySearch(sbyte[] array, sbyte search)
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
                sbyte temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;
                sbyte find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }

        }
        public static bool BinarySearch(uint[] array, uint search)
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
                uint temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;
                uint find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }


        }
        public static bool BinarySearch(byte[] array, byte search)
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
                byte temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

                int left = 0,
                    right = array.Length - 1,
                    mid = (right + left) / 2;
                byte find = array[mid];

                while (true)
                {
                    if (search > find)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                        find = array[mid];

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }

        }
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
                int temp;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int k = i + 1; k < array.Length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                if (array[array.Length - 1] < search)
                {
                    return false;
                }

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

                        if (right - left == 1)
                        {
                            right++;
                            mid = (left + right) / 2;
                        }
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

                    if ((mid == left || mid == right) && find != search)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
