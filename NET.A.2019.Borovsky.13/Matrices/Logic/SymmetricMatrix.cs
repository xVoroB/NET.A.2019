using System;

namespace HomeWork13
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(T[][] matrix) : base(matrix)
        {
            if (IsSymMatrix(matrix))
            {
                this.matrix = matrix;
            }
        }

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
