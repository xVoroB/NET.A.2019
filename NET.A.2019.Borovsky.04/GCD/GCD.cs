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
        
        public static int Euclidean(out long ticks, params int[] inputNumbers)
        {
            var watch = Stopwatch.StartNew();
            int gcd = Set(true, inputNumbers);
            watch.Stop();
            ticks = watch.ElapsedTicks;
            return gcd;
        }

        public static int Euclidean(params int[] numbers)
        {
            return Set(true, numbers); 
        }

        /// <summary>
        /// "Binary" method calculates GCD with the help of binary operations.
        /// </summary>

        public static int Binary(out long ticks, params int[] numbers)
        {
            var watch = Stopwatch.StartNew();
            int gcd = Set(false, numbers);
            watch.Stop();
            ticks = watch.ElapsedTicks;
            return gcd;
        }

        public static int Binary(params int[] numbers)
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

            int temp1;
            for (int i = 0; i < opArray.Length - 1; i++)
            {
                for (int k = i + 1; k < opArray.Length; k++)
                {
                    if (opArray[i] > opArray[k])
                    {
                        temp1 = opArray[i];
                        opArray[i] = opArray[k];
                        opArray[k] = temp1;
                    }
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
