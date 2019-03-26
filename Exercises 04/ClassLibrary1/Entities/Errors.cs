using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public static class Errors
    {
        //Wrong input or empty field/s
        public static void EmptyField(string input)
        {
            if (input == "")
            {
                throw new Exception("ERROR: incorrect input, or empty field.");
            }
        }

        public static void EmptyFields2(string input1, string input2)
        {
            if (input1 == "" || input2 == "")
            {
                throw new Exception("ERROR: incorrect input, or empty field.");
            }
        }

        public static void EmptyFields3(string input1, string input2, string input3, string input4)
        {
            if (input1 == "" || input2 == "" || input3 == "" || input4 == "")
            {
                throw new Exception("ERROR: incorrect input, or empty field.");
            }
        }

        //Wrong position selection of the new user
        public static void WrongPosition(string input)
        {
            if (int.Parse(input) < 1 || int.Parse(input) > 3 || input == "")
            {
                throw new Exception("ERROR: incorrect input, or empty field..");
            }
        }

        //Wrong subject selection
        public static void WrongSubject(string subject)
        {
            if (subject.ToLower() != "js" && subject.ToLower() != "c#")
            {
                throw new Exception("ERROR: Enter correct name of the subject.");
            }
        }

        public static void WrongSubject2(string input)
        {
            if (input == "" || (int.Parse(input) != 1 && int.Parse(input) != 2))
            {
                throw new Exception("ERROR: You must enter either 1 or 2.");
            }
        }

        public static void WrongSubject3(string input)
        {
            if (input == "" || int.Parse(input) < 1 || int.Parse(input) > 2)
            {
                throw new Exception("ERROR: You must enter a number between 1 and 2.");
            }
        }

        public static void WrongNumber(int number)
        {
            if (number < 1 || number > 5)
            {
                throw new Exception("ERROR: The grade must be between 1 and 5.");
            }
        }

        public static void WrongExit(string input)
        {
            if (input != "e")
            {
                throw new Exception("ERROR: You can exit only by pressing \"E\".");
            }
        }
    }
}
