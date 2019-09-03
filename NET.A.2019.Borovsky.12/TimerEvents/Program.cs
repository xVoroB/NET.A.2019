using System;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TimerEvents();
            Console.WriteLine("Enter how many seconds to count");
            while (true)
            {
                var inputSec = Console.ReadLine();
                a.SetTimer(inputSec);
                Console.WriteLine("You can change time by simply entering it");
            }
        }       
    }

}