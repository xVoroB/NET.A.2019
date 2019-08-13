using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Borovsky._02
{
    class FindNthRoot
    {
        public double NthRoot(double num, int n, double cap)
        {
            if (cap < 0 || n < 0)                                       // Checking if all the data is correct
            {
                return 0;
            }

            double result = num / n;                                    // Setting x0

            double curr = 0;
            int count = 0;

            while (cap < 1)                                             // Calculating precision
            {
                count++;
                cap *= 10;
            }

            while (curr != result)                                      // Calculating 
            {
                curr = result;
                result = Math.Round(Calc(curr, num, n), count);
            }


            return result;
        }

        double Calc(double res, double num, int n)
        {
            return (((n - 1) * res + (num / Math.Pow(res, n - 1))) / n);            // Next iteration calculation
        }
    }
}
