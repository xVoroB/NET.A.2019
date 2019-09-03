using System.Collections.Generic;

namespace HomeWork12
{
    public class Sequence
    {
        /// <summary>
        /// Method provides Fibonacci sequence generation
        /// </summary>
        /// <param name="count"> How many numbers to generate </param>
        /// <returns> Array with wanted amount of numbers </returns>
        public static int[] Fibonacci(int count)
        {
            List<int> tempList = new List<int>();

            for (int i = 0; i < count; i++)
            {
                if (tempList.Count < 2)
                {
                    tempList.Add(1);
                }
                else
                {
                    int toAdd = tempList[i - 1] + tempList[i - 2];
                    tempList.Add(toAdd);
                }
            }

            return tempList.ToArray();
        }
    }
}
