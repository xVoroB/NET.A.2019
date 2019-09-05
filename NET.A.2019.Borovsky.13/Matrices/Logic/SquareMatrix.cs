namespace HomeWork13
{
    using System;

    /// <summary>
    /// Base class for square matrices.
    /// </summary>
    /// <typeparam name="T"> Generic type. </typeparam>
    public class SquareMatrix<T>
    {
        protected T[][] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix"> Square matrix. </param>
        public SquareMatrix(T[][] matrix)
        {
            foreach (var internalArray in matrix)
            {
                if (matrix.Length != internalArray.Length)
                {
                    throw new ArgumentException("Enter square matrix");
                }
            }

            this.matrix = matrix;
        }

        /// <summary>
        /// Delegate to handle changing.
        /// </summary>
        /// <param name="index1"> Row index </param>
        /// <param name="index2"> Column index </param>
        public delegate void Changes(int index1, int index2);

        /// <summary>
        /// Event to trigger on changing
        /// </summary>
        public event Changes OnElementChange;

        public static T[][] operator +(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.Length != secondMatrix.matrix.Length)
            {
                throw new ArgumentException("You can't sum matrices with different lengths");
            }

            int len = firstMatrix.matrix.Length;

            T[][] sumResult = new T[len][];

            for (int i = 0; i < len; i++)
            {
                sumResult[i] = new T[len];
                for (int j = 0; j < len; j++)
                {
                    if (firstMatrix.matrix[i][j] == null)
                    {
                        sumResult[i][j] = secondMatrix.matrix[i][j];
                    }
                    else if (secondMatrix.matrix[i][j] == null)
                    {
                        sumResult[i][j] = firstMatrix.matrix[i][j];
                    }
                    else
                    {
                        sumResult[i][j] = (firstMatrix.matrix[i][j] as dynamic) + (secondMatrix.matrix[i][j] as dynamic);
                    }
                }
            }

            return sumResult;
        }

        public static T[][] operator +(SquareMatrix<T> firstMatrix, T[][] secondMatrix)
        {
            var matrixToOperate = new SquareMatrix<T>(secondMatrix);
            return firstMatrix + matrixToOperate;
        }

        public static T[][] operator +(T[][] firstMatrix, SquareMatrix<T> secondMatrix)
        {
            return secondMatrix + firstMatrix;
        }

        /// <summary>
        /// Writing down to console all the matrix.
        /// </summary>
        public void GetMatrix()
        {
            for (int i = 0; i < this.matrix.Length; i++)
            {
                foreach (var internalArrayValue in this.matrix[i])
                {
                    Console.Write(internalArrayValue + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Setting value for element of matrix.
        /// </summary>
        /// <param name="rowIndex"> Row index. </param>
        /// <param name="columnIndex"> Column index. </param>
        /// <param name="value"> Value to set. </param>
        public void SetValue(int rowIndex, int columnIndex, T value)
        {
            if (value.GetType() != this.matrix[0][0].GetType())
            {
                throw new ArgumentException("You can't change value to other type");
            }
            else if (rowIndex > this.matrix.Length || columnIndex > this.matrix.Length)
            {
                throw new IndexOutOfRangeException("Indexes were out of matrix range");
            }
            else
            {
                this.matrix[rowIndex][columnIndex] = value;
            }

            this.OnValueChange(rowIndex, columnIndex);
        }

        /// <summary>
        /// Method to invoke event.
        /// </summary>
        /// <param name="rowIndex"> Row index. </param>
        /// <param name="columnIndex"> Column index. </param>
        protected void OnValueChange(int rowIndex, int columnIndex)
        {
            var hand = new MatrixEventHandler();

            if (this.OnElementChange == null)
            {
                this.OnElementChange += hand.Message;
            }

            this.OnElementChange.Invoke(rowIndex, columnIndex);
        }
    }
}
