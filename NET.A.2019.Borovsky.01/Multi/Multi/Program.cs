using System;

namespace Multi
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArr one = new MyArr();
            int[] array = one.GetArr();

            Console.Write("First array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            RandArr two = new RandArr();
            array = two.GetArr();

            Console.Write("Second array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
