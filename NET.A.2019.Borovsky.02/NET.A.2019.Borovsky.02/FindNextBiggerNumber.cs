using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NET.A._2019.Borovsky._02
{
    class FindNextBiggerNumber
    {
        public int FNBN(int number)
        {
            int num = number;                                           // "Comparator"
            var watch = Stopwatch.StartNew();                           // Setting stopwatch

            if (number < 0)
            {
                return -1;
            }

            List<int> numbers = new List<int>();

            int current = 0;

            while (true)                                                // Finding "stop point" - higher number from the end
            {
                if (current < number % 10)
                {
                    current = number % 10;                              // Listing all the low numbers
                    numbers.Add(current);
                    number /= 10;
                }
                else
                {
                    numbers.Add(number % 10);
                    number /= 10;
                    break;
                }
            }
            number *= (int)Math.Pow(10, (double)numbers.Count);         // Adding zeros

            numbers.Remove(current);
            numbers.Sort();
            numbers.Reverse();                                          // Sorting from low to high

            number += current * (int)Math.Pow(10, (double)numbers.Count);

            int[] nums = numbers.ToArray();                              // Creating new number from "stop point"

            for (int i = 0; i < nums.Length; i++)
            {
                number += nums[i] * (int)Math.Pow(10, (double)i);
            }

            watch.Stop();                                               // Stopping stopwatch

            Console.WriteLine("Elapsed time in ms = " + watch.ElapsedMilliseconds);

            if (number == num)                                          // Checking if number didn't change
            {
                return -1;
            }

            return number;
        }
    }
}
