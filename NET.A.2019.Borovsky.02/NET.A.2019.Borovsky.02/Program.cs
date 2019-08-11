using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindNextBiggerNumber;
using InsertNumber;
using FilterDigit;
using FindNthRoot;

namespace NET.A._2019.Borovsky._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding next number");

            int a = 1234321;
            Console.WriteLine(FNBN.FindNextBiggerNumber(a));

            Console.WriteLine("Inserting number");

            Console.WriteLine(InsNum.InsertNumber(8, 15, 3, 8));

            Console.WriteLine("FilterDigit");

            List<int> arr = new List<int> { 1, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            arr = FilDig.FilterDigit(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Finding Nth root");

            Console.WriteLine(NthRoot.FindNthRoot(8, 3, 0.001));

            Console.ReadKey();
        }
    }
}
