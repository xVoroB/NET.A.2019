namespace HomeWork13
{
    using System;

    /// <summary>
    /// Class to handle event.
    /// </summary>
    internal class MatrixEventHandler
    {
        /// <summary>
        /// Writes a message about changed element.
        /// </summary>
        /// <param name="rowIndex"> Row index. </param>
        /// <param name="columnIndex"> Column index. </param>
        public void Message(int rowIndex, int columnIndex)
        {
            Console.WriteLine("Element in row {0} column {1} was changed", rowIndex, columnIndex);
        }
    }
}
