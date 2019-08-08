using System;

namespace Array
{
    class RandArr
    {
        public int[] GetArr()
        {
            Random rand = new Random();
            int[] array = new int[rand.Next(10, 40)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(100);
            }
            return array;
        }
    }
}
