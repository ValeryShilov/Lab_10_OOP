using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    internal class Menu
    {
        public static int ReadInt(string message, string errorMessage, string par = "-", int start = -10000, int end = 10000)
        {
            bool isRead;
            bool isInt;
            bool isNotNeg;
            bool isNotNul;
            bool inBord;
            int number;
            do
            {
                isRead = false;
                isInt = false;
                isNotNeg = false;
                isNotNul = false;
                inBord = false;
                Console.WriteLine(message);
                string buf = Console.ReadLine();
                isInt = int.TryParse(buf, out number);
                if (!isInt)
                {
                    Console.WriteLine(errorMessage);
                }
                if (par == "-")
                {
                    isNotNeg = true;
                    isNotNul = true;
                    inBord = true;
                }
                if (par == "0")
                {
                    if (number >= 0)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
                if (par == "+")
                {
                    if (number > 1)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
                if (par == "->")
                {
                    if (number >= start && number <= end)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
            } while (!(isInt && isNotNul && isNotNeg && inBord));
            return number;
        }

        public static double ReadDouble(string message, string errorMessage, string par = "-", double start = -10000, double end = 10000)
        {
            bool isDouble;
            bool isNotNeg;
            bool isNotNul;
            bool inBord;
            double number;
            do
            {
                isDouble = false;
                isNotNeg = false;
                isNotNul = false;
                inBord = false;
                Console.WriteLine(message);
                string buf = Console.ReadLine();
                isDouble = double.TryParse(buf, out number);
                if (!isDouble)
                {
                    Console.WriteLine(errorMessage);
                }
                if (par == "-")
                {
                    isNotNeg = true;
                    isNotNul = true;
                    inBord = true;
                }
                if (par == "0")
                {
                    if (number >= 0)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
                if (par == "+")
                {
                    if (number >= 1)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
                if (par == "->")
                {
                    if (number >= start && number <= end)
                    {
                        isNotNul = true;
                        isNotNeg = true;
                        inBord = true;
                    }
                    else Console.WriteLine(errorMessage);
                }
            } while (!(isDouble && isNotNul && isNotNeg && inBord));
            return number;
        }
    }
}
