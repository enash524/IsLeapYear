using System;
using System.Collections.Generic;

namespace IsLeapYear.ConsoleApp
{
    internal class Program
    {
        private static bool IsLeapYear(int year)
        {
            bool leap;

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        leap = true;
                    }
                    else
                    {
                        leap = false;
                    }
                }
                else
                {
                    leap = true;
                }
            }
            else
            {
                leap = false;
            }

            return leap;
        }

        private static void Main(string[] args)
        {
            List<int> years = new List<int> { 1900, 1990, 1992, 2000 };

            foreach (int year in years)
            {
                bool isLeapYear = IsLeapYear(year);
                Console.WriteLine(isLeapYear);
            }
        }
    }
}
