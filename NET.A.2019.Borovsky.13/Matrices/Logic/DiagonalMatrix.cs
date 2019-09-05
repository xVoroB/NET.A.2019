using System;

namespace HomeWork13
{
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
    {
        bool isDefault(T o)
        {
            return (o == null) ? (default(T) == null) : o.Equals(default(T));
        }

        public DiagonalMatrix(T[][] matrix) : base(matrix)
        {
            if (this.IsSymMatrix(matrix))
            {
                this.matrix = matrix;
            }
        }

        protected override bool IsSymMatrix(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i != j && isDefault(matrix[i][j]))
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
    }
}
