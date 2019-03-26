using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public static class Menus
    {
        //Main login menu
        public static void MainMenu()
        {
            Console.WriteLine("Choose your position");
            Console.WriteLine();
            Console.WriteLine("1) Admin");
            Console.WriteLine("2) Trainer");
            Console.WriteLine("3) Student");
            Console.WriteLine();
            Console.Write("User's choice: ");
        }

        public static void UsernamePasswordInput(ref string userUsername, ref string userPassword)
        {
            Console.WriteLine("Enter username:");
            userUsername = Console.ReadLine();
            Console.WriteLine("Enter password");
            userPassword = Console.ReadLine();
            Console.Clear();
        }

        //ADMINISTRATORS

        //Administrator's sub-menu
        public static void AdminsSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Add user");
            Console.WriteLine("2) Remove user");
            Console.WriteLine("3) Logout");
            Console.WriteLine();
            Console.Write("User's choice: ");
        }

        public static void NewUserInfo(ref string enteredName, ref string enteredLastName, ref string enteredUserName, ref string enteredPassword)
        {
            Console.WriteLine("Enter user's first name:");
            enteredName = Console.ReadLine();
            Console.WriteLine("Enter user's last name:");
            enteredLastName = Console.ReadLine();
            Console.WriteLine("Enter user's username:");
            enteredUserName = Console.ReadLine();
            Console.WriteLine("Enter user's password:");
            enteredPassword = Console.ReadLine();
        }

        //Choosing position of the new user
        public static void PositionSelection()
        {
            Console.WriteLine("Choose your position");
            Console.WriteLine("1) Admin");
            Console.WriteLine("2) Trainer");
            Console.WriteLine("3) Student");
        }

        //TRAINERS

        //Trainer's sub-menu
        public static void TrainerSubMenu()
        {
            Console.WriteLine("What list do you want to see:");
            Console.WriteLine();
            Console.WriteLine("1) See the list with students");
            Console.WriteLine("2) Search student by name");
            Console.WriteLine("3) See list by subject");
            Console.WriteLine("4) Logout");
            Console.WriteLine();
            Console.Write("User's choice: ");
        }

        //Checking list by subject
        public static void SelectSubject()
        {
            Console.WriteLine("Subjects:");
            Console.WriteLine();
            Console.WriteLine("1) C#");
            Console.WriteLine("2) JS");
            Console.WriteLine();
            Console.WriteLine("Choose subject by entering the number in front of it, to see the list of students.");
            Console.Write("Search: ");
        }

        //STUDENTS

        //Main student's sub-menu
        public static void StudentsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) See the list of available subjects");
            Console.WriteLine("2) Logout");
            Console.WriteLine();
            Console.Write("Your choice: ");
        }

        public static void SubjectSelection()
        {
            Console.WriteLine("List of subjects you can choose to enroll in:");
            Console.WriteLine();
            Console.WriteLine("1) C#");
            Console.WriteLine("2) JS");
            Console.WriteLine();
            Console.WriteLine("If you just want to check your grade of your current subject, press \"g\".");
            Console.WriteLine();
            Console.WriteLine("You must enter the number in front of the subject(e.g. 1): ");
            Console.WriteLine("If you want to exit press \"e\"");
            Console.WriteLine();
            Console.Write("Your choice: ");
        }
    }
}
