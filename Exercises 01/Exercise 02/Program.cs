using System;
using Exercise2.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[5];

            users[0] = new User(23, "John", "dfert43");
            users[1] = new User(34, "Bob", "453fg3rf");
            users[2] = new User(13, "Jill", "45fsd3");



            Console.WriteLine("Choose your option(enter number):\n" +
                              "1) Register\n" +
                              "2) Log in.");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Enter your ID");
                int userId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your username:");
                string usersUsername = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string usersPassword = Console.ReadLine();

                Console.WriteLine(Registration(userId, usersUsername, usersPassword, users));

                Console.Write(ShowList(users));
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Enter your username:");
                string usersUsername = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string usersPassword = Console.ReadLine();

                if (usersUsername == "" || usersPassword == "")
                {
                    Console.Write("Please don't leave empty fields.");
                }
                else
                {
                    Console.Write(LogIn(usersUsername, usersPassword, users));
                }
            }


            Console.ReadLine();
        }

        public static string Registration(int id, string username, string password, User[] users)
        {
            string message = "";
            int emptySlots = 0;

            // A way to find out how many empty slots are in the "users" array
            foreach (User user in users)
            {
                if (user == null)
                {
                    emptySlots++;
                }
            }

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == null)
                {
                    continue;
                }
                else
                {
                    if (users[i].Username == username)
                    {
                        message = "User with that name already exist";
                        break;
                    }
                    else
                    {
                        // [users.Length - emptySlots] puts the new user in the first empty slot in the users array.
                        users[users.Length - emptySlots] = new User(id, username, password);
                        message = "Registration complete! Users:";
                        break;
                    }
                }
            }

            return message;
        }

        public static string LogIn(string username, string password, User[] users)
        {
            string message = "";

            foreach (User user in users)
            {
                if (user == null)
                {
                    continue;
                }
                else
                {
                    if (user.Username == username && user.Password == password)
                    {
                        message += $"Welcome {user.Username}. Here are your messages:\n" +
                                   $"{user.Messages[0]}\n" +
                                   $"{user.Messages[1]}";
                        break;
                    }
                    else
                    {
                        message += "Something went wrong, either your username, or password is incorrect.";
                        break;
                    }
                }
            }

            return message;
        }

        public static string ShowList(User[] users)
        {
            string result = "";

            foreach (User user in users)
            {
                if (user == null)
                {
                    continue;
                }
                else
                {
                    result += $"{user.ShowStudentsInfo()}\n";
                }
            }

            return result;
        }
    }
}
