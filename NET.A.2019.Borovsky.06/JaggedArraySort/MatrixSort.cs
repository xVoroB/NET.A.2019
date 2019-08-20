using System;

namespace Sort
{
    public class MatrixSort
    {
        /// <summary>
        /// Sorting array from lower to higher sum of elements
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToHighSum(int[][] matrix)
        {
            return Sorting(Sum(matrix), true, matrix);
        }

        /// <summary>
        /// Sorting array from higher to lower sum of elements
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToLowSum(int[][] matrix)
        {
            return Sorting(Sum(matrix), false, matrix);
        }

        /// <summary>
        /// Sorting array from lower to higher by max element in row
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToHighMax(int[][] matrix)
        {
            return Sorting(MaxOrMin(true, matrix), true, matrix);
        }

        /// <summary>
        /// Sorting array from higher to lower by max element in row
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToLowMax(int[][] matrix)
        {
            return Sorting(MaxOrMin(true, matrix), false, matrix);
        }

        /// <summary>
        /// Sorting array from lower to higher by min element in row
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToHighMin(int[][] matrix)
        {
            return Sorting(MaxOrMin(false, matrix), true, matrix);
        }

        /// <summary>
        /// Sorting array from higher to lower by min element in row
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        public static int[][] SortArrToLowMin(int[][] matrix)
        {
            return Sorting(MaxOrMin(false, matrix), false, matrix);
        }

        /// <summary>
        /// Method for making array to work with sums
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        /// <returns> Sum of every row in matrix </returns>
        private static int[] Sum(int[][] matrix)
        {
            int[] sums = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    sums[i] += matrix[i][k];
                }
            }
            return sums;
        }

        /// <summary>
        /// Method for making array to work with max or min elements
        /// </summary>
        /// <param name="matrix"> Jagged array </param>
        /// <param name="isMax"> Are we looking for max element or not </param>
        /// <returns> Sum of every row in matrix </returns>
        private static int[] MaxOrMin(bool isMax, int[][] matrix)
        {
            int[] result = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length > 0)
                {
                    result[i] = matrix[i][0];
                    for (int k = 1; k < matrix[i].Length; k++)
                    {
                        if (isMax)
                        {
                            if (result[i] < matrix[i][k])
                            {
                                result[i] = matrix[i][k];
                            }
                        }
                        else
                        {
                            if (result[i] > matrix[i][k])
                            {
                                result[i] = matrix[i][k];
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Method to sort array in the way we need
        /// </summary>
        /// <param name="param"> Working array </param>
        /// <param name="toHigh"> How do we sort: fro low to high or from high to low </param>
        /// <param name="matrix"> Jagged array </param>
        private static int[][] Sorting(int[] param, bool toHigh, int[][] matrix)
        {
            for (int i = 0; i < param.Length - 1; i++)
            {
                for (int k = i + 1; k < param.Length; k++)
                {
                    if (toHigh)
                    {
                        if (param[i] > param[k])
                        {
                            CopySort(matrix, i, k, param);
                        }
                    }
                    else
                    {
                        if (param[i] < param[k])
                        {
                            CopySort(matrix, i, k, param);
                        }
                    }
                }
            }

            return matrix;
        }

        private static void CopySort(int[][] matrix, int i, int k, int[] param)
        {
            int temp;
            int[] tempArr = new int[matrix[i].Length];
            Array.Copy(matrix[i], tempArr, matrix[i].Length);
            matrix[i] = new int[matrix[k].Length];
            Array.Copy(matrix[k], matrix[i], matrix[k].Length);
            matrix[k] = new int[tempArr.Length];
            Array.Copy(tempArr, matrix[k], tempArr.Length);
            temp = param[i];
            param[i] = param[k];
            param[k] = temp;
        }
    }
}
