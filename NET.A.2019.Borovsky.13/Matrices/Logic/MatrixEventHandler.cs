using System;

namespace HomeWork13
{
    class MatrixEventHandler
    {
        public void Message(int rowIndex, int columnIndex)
        {
            Console.WriteLine("Element in row {0} column {1} was changed", rowIndex, columnIndex);
        }
    }
}
