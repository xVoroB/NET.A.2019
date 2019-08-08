using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MergeSort;
using QuickSort;
using Array;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // First array

            MyArr one = new MyArr();
            int[] array = one.GetArr();

            Console.Write("Unsorted array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Merge sorting

            MSort.MergeSort(array);

            Console.Write("Merge sorted array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Second array

            RandArr two = new RandArr();
            array = two.GetArr();

            Console.Write("Unsorted array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Quick sorting

            QSort.QuickSort(array);

            Console.Write("Quick sorted array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
