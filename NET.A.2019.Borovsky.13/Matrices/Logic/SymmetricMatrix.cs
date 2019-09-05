namespace HomeWork13
{
    using System;

    /// <summary>
    /// Class to operate with symmetric matrices.
    /// </summary>
    /// <typeparam name="T"> Generic type. </typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix"> Symmetric matrix. </param>
        public SymmetricMatrix(T[][] matrix)
            : base(matrix)
        {
            if (this.IsSymMatrix(matrix))
            {
                this.matrix = matrix;
            }
        }

        /// <summary>
        /// Checker if given matrix is symmetric.
        /// </summary>
        /// <param name="matrix"> Input matrix. </param>
        /// <returns> False or true. </returns>
        protected virtual bool IsSymMatrix(T[][] matrix)
        {
            bool isSym = false;
            int len = matrix.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (matrix[i][j] == null && matrix[j][i] == null)
                    {
                        continue;
                    }

                    if (matrix[i][j] == null || matrix[j][i] == null)
                    {
                        throw new ArgumentException("Matrix is not symmetric");
                    }
                    else if (!matrix[i][j].Equals(matrix[j][i]))
                    {
                        throw new ArgumentException("Matrix is not symmetric");
                    }
                }

                isSym = true;
            }

            return isSym;
        }
    }
}
