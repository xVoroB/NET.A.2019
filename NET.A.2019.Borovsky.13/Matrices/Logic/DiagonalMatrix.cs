namespace HomeWork13
{
    using System;

    /// <summary>
    /// Class to operate with diagonal matrices.
    /// </summary>
    /// <typeparam name="T"> Generic type. </typeparam>
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix"> Diagonal matrix. </param>
        public DiagonalMatrix(T[][] matrix)
            : base(matrix)
        {
            if (this.IsSymMatrix(matrix))
            {
                this.matrix = matrix;
            }
        }

        /// <summary>
        /// Checks if given matrix is diagonal.
        /// </summary>
        /// <param name="matrix"> Input matrix. </param>
        /// <returns> True or false. </returns>
        protected override bool IsSymMatrix(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i != j && this.IsDefault(matrix[i][j]))
                    {
                        continue;
                    }
                    else if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException("Matrix is not diagonal");
                    }
                }
            }

            return base.IsSymMatrix(matrix);
        }

        /// <summary>
        /// Method to check if element is default value.
        /// </summary>
        /// <param name="o"> Element. </param>
        /// <returns> True or false. </returns>
        private bool IsDefault(T o)
        {
            return (o == null) ? (default(T) == null) : o.Equals(default(T));
        }
    }
}
