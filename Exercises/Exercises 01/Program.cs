using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            

            do
            {

                Console.WriteLine("Please enter a number: ");
                var userInput = Console.ReadLine();
                
                double number;
                bool check = double.TryParse(userInput, out number);
                string answer;

                if (check == false)
                {
                    Console.WriteLine("Please enter valid number.");
                }
                else
                {
                    double userInputToDouble = double.Parse(userInput);
                    Console.WriteLine(PrintStats(userInputToDouble));
                }

                Console.WriteLine("Do you want to try again?");
                answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }

            } while (true);

            
        }

        public static string IsItPositive(double num)
        {
            if (num < 0)
            {
                return "The number is negative.";
            }
            else
            {
                return "The number is positive.";
            }
        }

        public static string IsItEven(double num)
        {
            if (num % 2 == 0)
            {
                return "The number is even.";
            }
            else
            {
                return "The number is odd.";
            }
        }


        public static string IsItInteger(double num)
        {
            num = num < 0 ? num * -1 : num;
            double number = Math.Floor(num);
            if (num > number)
            {
                return "It is decimal.";
            }
            else
            {
                return "It is integer.";
            }
        }

        public static string PrintStats(double number)
        {
            return $"{IsItPositive(number)}\n" +
                   $"{IsItEven(number)}\n" +
                   $"{IsItInteger(number)}";
        }
    }
}
