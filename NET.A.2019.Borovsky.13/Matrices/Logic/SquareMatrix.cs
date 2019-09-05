using System;

namespace HomeWork13
{
    public class SquareMatrix<T>
    {
        public delegate void Changes(int index1, int index2);

        public event Changes OnElementChange;

        protected T[][] matrix;

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

        public void GetMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                foreach (var internalArrayValue in matrix[i])
                {
                    Console.Write(internalArrayValue + " ");
                }
                Console.WriteLine();
            }
        }

        public void SetValue(int rowIndex, int columnIndex, T value)
        {
            if (value.GetType() != matrix[0][0].GetType())
            {
                throw new ArgumentException("You can't change value to other type");
            }
            else if (rowIndex > matrix.Length || columnIndex > matrix.Length)
            {
                throw new IndexOutOfRangeException("Indexes were out of matrix range");
            }
            else
            {
                matrix[rowIndex][columnIndex] = value;
            }

            OnValueChange(rowIndex, columnIndex);
        }

        protected void OnValueChange(int rowIndex, int columnIndex)
        {
            var hand = new MatrixEventHandler();

            if (OnElementChange == null)
            {
                OnElementChange += hand.Message;
            }

            OnElementChange.Invoke(rowIndex, columnIndex);
        }

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
                        sumResult[i][j] = firstMatrix.matrix[i][j] as dynamic + secondMatrix.matrix[i][j] as dynamic;
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
    }

}
