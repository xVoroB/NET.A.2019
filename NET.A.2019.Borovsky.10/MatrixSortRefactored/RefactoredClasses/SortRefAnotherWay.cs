using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class BySum : IComparer<int[]>
    {
        /// <summary>
        /// Comparing two lines by their sum
        /// </summary>
        public int Compare(int[] x, int[] y)
        {
            if (Sum(x) > Sum(y))
            {
                return 1;
            }
            else if (Sum(x) < Sum(y))
            {
                return -1;
            }
            else
            {
                return 0;
            }

            int Sum(int[] a)
            {
                int sum = 0;
                foreach (var item in a)
                {
                    sum += item;
                }
                return sum;
            }
        }
    }
    class ByMax : IComparer<int[]>
    {
        /// <summary>
        /// Comparing two lines by their max elements
        /// </summary>
        public int Compare(int[] x, int[] y)
        {
            if (Max(x) > Max(y))
            {
                return 1;
            }
            else if (Max(x) < Max(y))
            {
                return -1;
            }
            else
            {
                return 0;
            }

            int Max(int[] a)
            {
                int max = a[0];
                foreach (var item in a)
                {
                    if (item > max)
                    {
                        max = item;
                    }
                }
                return max;
            }
        }
    }
    class ByMin : IComparer<int[]>
    {
        /// <summary>
        /// Comparing lines by their min element
        /// </summary>
        public int Compare(int[] x, int[] y)
        {
            if (Min(x) > Min(y))
            {
                return 1;
            }
            else if (Min(x) < Min(y))
            {
                return -1;
            }
            else
            {
                return 0;
            }

            int Min(int[] a)
            {
                int min = a[0];
                foreach (var item in a)
                {
                    if (min > item)
                    {
                        min = item;
                    }
                }
                return min;
            }
        }
    }
    public class SortRefAnotherWay
    {
        /// <summary>
        /// Main sort method
        /// </summary>
        private static void Sorting(int[][] matrix, bool toHigh, Comparison<int[]> comparisonDel)
        {
            if (matrix.Length == 0)
            {
                return;
            }

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int k = i + 1; k < matrix.Length; k++)
                {
                    if (toHigh)
                    {
                        if (comparisonDel(matrix[i], matrix[k]) > 0)
                        {
                            SortLines(matrix, i, k);
                        }
                    }
                    else
                    {
                        if (comparisonDel(matrix[i], matrix[k]) < 0)
                        {
                            SortLines(matrix, i, k);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Creating delegate through interface variable
        /// </summary>
        /// <param name="matrix"> jagged array </param>
        /// <param name="toHigh"> Order </param>
        /// <param name="comparisonDel"> Delegate </param>
        private static void Sorting(int[][] matrix, bool toHigh, IComparer<int[]> comparer)
        {
            Comparison<int[]> comparisonDel = comparer.Compare;
            Sorting(matrix, toHigh, comparisonDel);
        }

        /// <summary>
        /// switching places of two lines
        /// </summary>
        private static void SortLines(int[][] matrix, int i, int k)
        {
            int[] tempArr = new int[matrix[i].Length];
            Array.Copy(matrix[i], tempArr, matrix[i].Length);
            matrix[i] = new int[matrix[k].Length];
            Array.Copy(matrix[k], matrix[i], matrix[k].Length);
            matrix[k] = new int[tempArr.Length];
            Array.Copy(tempArr, matrix[k], tempArr.Length);
        }

        /// <summary>
        /// Sorting array from lower to higher sum of elements
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToHighSum(int[][] matrix)
        {
            Sorting(matrix, true, new BySum());
        }

        /// <summary>
        /// Sorting array from higher to lower sum of elements
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToLowSum(int[][] matrix)
        {
            Sorting(matrix, false, new BySum());
        }

        /// <summary>
        /// Sorting jagged array by max element from low to high
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToHighMax(int[][] matrix)
        {
            Sorting(matrix, true, new ByMax());
        }

        /// <summary>
        /// Sorting jagged array by max element from high to low
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToLowMax(int[][] matrix)
        {
            Sorting(matrix, false, new ByMax());
        }

        /// <summary>
        /// Sorting jagged array by min element from low to high
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToHighMin(int[][] matrix)
        {
            Sorting(matrix, true, new ByMin());
        }

        /// <summary>
        /// Sorting jagged array by min element from high to low
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static void SortToLowMin(int[][] matrix)
        {
            Sorting(matrix, false, new ByMin());
        }
    }
}
