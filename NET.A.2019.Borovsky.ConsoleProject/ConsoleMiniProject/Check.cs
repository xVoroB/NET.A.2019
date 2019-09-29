﻿using System;
using System.Text.RegularExpressions;

namespace MiniProject
{
    class Check
    {
        public static bool FirstName(string input)
        {
            if (Regex.IsMatch(input, @"[A-Z][a-z]") && input.Length > 2)
            {
                return true;
            }
            Console.WriteLine("Wrong input");
            return false;
        }

        public static bool LastName(string input)
        {
            if (Regex.IsMatch(input, @"[A-Z][a-z]") && input.Length > 2)
            {
                return true;
            }
            Console.WriteLine("Wrong input");
            return false;
        }

        public static bool BirthDate(string input)
        {
            if (Regex.IsMatch(input, @"[0-3]\d([-]|[.]|[/])[0-1]\d([-]|[.]|[/])[0-2]\d") && input.Length == 10)
            {
                return true;
            }
            Console.WriteLine("Wrong input");
            return false;
        }
    }
}