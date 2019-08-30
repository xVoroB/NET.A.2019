using System;
using System.Diagnostics;

namespace GCD
{
    public class GCD_Calculations
    {
        /// <summary>
        /// Library contains 4 methods to calculate GCD. Two of them provide
        /// ability to calculate time needed for calculations, returning it in ticks.
        /// 
        /// Euclidean method calcuates GCD by division.
        /// </summary>
        /// <param name="ticks"> Ticks needed to calculate GCD </param>
        /// <param name="inputNumbers"> Input numbers </param>
        /// <returns> GCD (int32 format) and ticks </returns>

        private static readonly int[] array;

        /// <summary>
        /// Delegate
        /// </summary>
        /// <param name="isEuclid"> Used calculation method </param>
        /// <param name="gcd"> Gcd of given numbers </param>
        /// <returns> Ticks </returns>
        delegate long WatchNSet(bool isEuclid, out int gcd, params int[] numbers);

        static WatchNSet start = StartingPoint;

        /// <summary>
        /// Method to copy input array, start calculations and count time needed
        /// </summary>
        static private long StartingPoint(bool isEuclid, out int gcd, params int[] numbers)
        {
            Array.Copy(numbers, array, numbers.Length);
            var watch = Stopwatch.StartNew();
            gcd = Set(true, array);
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            return ticks;
        }
        static public int Euclidean(out long ticks, params int[] inputNumbers)
        {
            ticks = start(true, out int gcd);
            return gcd;
        }

        static public int Euclidean(params int[] numbers)
        {
            return Set(true, numbers); 
        }

        /// <summary>
        /// "Binary" method calculates GCD with the help of binary operations.
        /// </summary>

        static public int Binary(out long ticks, params int[] inputNumbers)
        {
            ticks = start(false, out int gcd);
            return gcd;
        }

        static public int Binary(params int[] numbers)
        {
            return Set(false, numbers);
        }

        /// <summary>
        /// Setting array to appropriate - sorting and then calling selected by user calculation
        /// </summary>
        /// <param name="isEuclid"> Selector of the calculation method </param>
        /// <param name="numbers"> Input numbers </param>
        /// <returns> GCD of array </returns>
        static int Set(bool isEuclid, params int[] numbers)
        {
            int[] opArray = new int[numbers.Length];
            numbers.CopyTo(opArray, 0);

            foreach (var num in opArray)
            {
                if (num == 0)
                {
                    return 0;
                }
            }

            for (int i = 0; i < opArray.Length; i++)
            {
                if (opArray[i] < 0)
                {
                    opArray[i] = -opArray[i];
                }
            }

            int endOfArray = opArray.Length - 1;

            for (int i = 0; i + 1 < opArray.Length; i++)
            {
                for (int k = 0; k + 1 < opArray.Length; k++)
                {
                    if (opArray[k + 1] != 0)
                    {
                        if (isEuclid)
                        {
                            opArray[k] = EuclidCalculation(opArray[k], opArray[k + 1]);
                        }
                        else
                        {
                            opArray[k] = BinaryCalculation(opArray[k], opArray[k + 1]);
                        }
                    }
                }
                opArray[endOfArray--] = 0;
            }
            return opArray[0];
        }

        /// <summary>
        /// Euclidean calculation by division
        /// </summary>
        /// <param name="a"> First int </param>
        /// <param name="b"> Second int </param>
        /// <returns> GCD(a,b) </returns>
        static int EuclidCalculation(int a, int b)
        {
            while (true)
            {
                if (a == 0 || b == 0)
                {
                    return 0;
                }
                else if (a % b == 0)
                {
                    return b;
                }
                else
                {
                    int temp = a;
                    a = b;
                    b = temp % b;
                }
            }
        }

        /// <summary>
        /// Binary calculation
        /// </summary>
        /// <param name="a"> First int </param>
        /// <param name="b"> Second int </param>
        /// <returns> GCD(a,b) </returns>
        static int BinaryCalculation(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else if (a == b)
            {
                return a;
            }
            if (a % 2 == 0)
            {
                if (b % 2 != 0)
                {
                    return BinaryCalculation(a >> 1, b);
                }
                else
                {
                    return BinaryCalculation(a >> 1, b >> 1) << 1;
                }
            }
            if (b % 2 == 0)
            {
                return BinaryCalculation(a, b >> 1);
            }
            if (a > b)
            {
                return BinaryCalculation((a - b) >> 1, b);
            }
            return BinaryCalculation((b - a) >> 1, a);
        }
    }
}
