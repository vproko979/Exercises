using ClassLibrary1.Entities;
using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new Admin("John", "Doe", "jdoe", "jdoe123"));
            users.Add(new Trainer("Bob", "Bobsky", "bsky", "bsky123"));
            users.Add(new Trainer("Mike", "Bobsky", "bsky1", "bsky123"));
            users.Add(new Student("Kimiko", "Burkett", "kimi", "kimi123", "C#", 5));
            users.Add(new Student("Horacio", "Villar", "villa", "vila123", "JS", 4));
            users.Add(new Student("Boris", "Lacross", "cross", "cross123", "C#", 5));
            users.Add(new Student("Toney", "Matsui", "toni", "toni123",  "C#", 5));
            users.Add(new Student("Ron", "Currin", "curr", "curr123", "JS", 4));

            Roles userPosition = Roles.Student;
            bool loginIsOk = false;
            string loggedUsername = "";
            string usersName = "";


            try
            {

                do
                {

                    //Main login menu.
                    Console.WriteLine("Choose your position");
                    Console.WriteLine();
                    Console.WriteLine("1) Admin");
                    Console.WriteLine("2) Trainer");
                    Console.WriteLine("3) Student");
                    Console.WriteLine();
                    Console.Write("User's choice: ");
                    string usersChoice = Console.ReadLine();
                    Console.Clear();

                    //Selecting position.
                    if (usersChoice == "")
                    {
                        throw new Exception("You must enter a number, between 1 and 3.");
                    }
                    else
                    {
                        userPosition = LoginService.usersPostition(usersChoice);
                    }

                    //Asking for username and password.
                    Console.WriteLine("Enter username:");
                    string userUsername = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string userPassword = Console.ReadLine();
                    Console.Clear();

                    if (userUsername == "" || userPassword == "")
                    {
                        throw new Exception("Don't leave empty fields.");
                    }


                    if (userUsername != "" && userPassword != "")
                    {
                        foreach (User logged in users)
                        {

                            if (logged.Username == userUsername && logged.Password == userPassword && logged.Role == userPosition)
                            {
                                loginIsOk = true;
                                usersName = logged.FirstName;
                                loggedUsername = logged.Username;
                                break;
                            }

                        }

                        if (loginIsOk == false)
                        {

                            Console.WriteLine("Either your username, or your password was wrong.");
                            Console.WriteLine("Try again...");
                            Console.WriteLine();

                        }

                        if (loginIsOk)
                        {
                            Console.WriteLine($"Welcome {usersName}");

                            do
                            {

                                //Shows the sub-menu according to its position.
                                if (userPosition == Roles.Admin)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("List of all users:");
                                    Console.WriteLine();
                                    foreach (User userr in users)
                                    {
                                        Console.WriteLine($"Position: {userr.Role} / Username: {userr.Username} / First name: {userr.FirstName} / Last name: {userr.LastName}");
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("1) Add user");
                                    Console.WriteLine("2) Remove user");
                                    Console.WriteLine("3) Logout");
                                    Console.WriteLine();
                                    Console.Write("User's choice: ");
                                    string adminsChoice = Console.ReadLine();
                                    Console.Clear();

                                    //Add new user
                                    if (adminsChoice == "1")
                                    {
                                        Console.WriteLine("Enter user's first name:");
                                        string enteredName = Console.ReadLine();
                                        Console.WriteLine("Enter user's last name:");
                                        string enteredLastName = Console.ReadLine();
                                        Console.WriteLine("Enter user's username:");
                                        string enteredUserName = Console.ReadLine();
                                        Console.WriteLine("Enter user's password:");
                                        string enteredPassword = Console.ReadLine();

                                        if (enteredName == "" || enteredUserName == "" || enteredUserName == "" || enteredPassword == "")
                                        {
                                            throw new Exception("Don't leave empty fields.");
                                        }

                                        Console.WriteLine("Choose your position");
                                        Console.WriteLine("1) Admin");
                                        Console.WriteLine("2) Trainer");
                                        Console.WriteLine("3) Student");
                                        string enteredPosition = Console.ReadLine();
                                        int enteredPositionInt = int.Parse(enteredPosition);

                                        if (enteredPositionInt < 1 || enteredPositionInt > 3 || enteredPosition == "")
                                        {
                                            throw new Exception("You must enter a number between 1 and 3.");
                                        }

                                        if (enteredPosition == "1")
                                        {
                                            Admin newAdmin = new Admin(enteredName, enteredLastName, enteredUserName, enteredPassword);
                                            LoginService.AddNewUser(users, newAdmin);
                                        }

                                        if (enteredPosition == "2")
                                        {
                                            Trainer newTrainer = new Trainer(enteredName, enteredLastName, enteredUserName, enteredPassword);
                                            LoginService.AddNewUser(users, newTrainer);
                                        }

                                        if (enteredPosition == "3")
                                        {
                                            Console.WriteLine("Enter student's subject:");
                                            string enteredSubject = Console.ReadLine();

                                            if (enteredSubject == "")
                                            {
                                                throw new Exception("Don't leave empty field.");
                                            }

                                            if(enteredSubject.ToLower() != "js" && enteredSubject.ToLower() != "c#")
                                            {
                                                throw new Exception("Enter correct name of the subject.");
                                            }

                                            Console.WriteLine("Enter student's grade:");
                                            int enteredGrade = int.Parse(Console.ReadLine());

                                            if (enteredGrade < 1 || enteredGrade > 5 )
                                            {
                                                throw new Exception("The grade must be between 1 and 5.");
                                            }

                                            Student newStudent = new Student(enteredName, enteredLastName, enteredUserName, enteredPassword, enteredSubject, enteredGrade);
                                            LoginService.AddNewUser(users, newStudent);
                                        }
                                    }

                                    //Remove user
                                    if (adminsChoice == "2")
                                    {
                                        Console.WriteLine("Enter user's username that you want to remove:");
                                        string enteredUser = Console.ReadLine();
                                        Console.Clear();                                        

                                        if (enteredUser == "")
                                        {
                                            throw new Exception("Don't leave empty search field.");
                                        }

                                        if (enteredUser != loggedUsername)
                                        {
                                            var found = LoginService.FindByUsername(users, enteredUser);

                                            if (found == null)
                                            {
                                                Console.WriteLine("User with that username doesn't exist on the list.");
                                            }
                                            else
                                            {
                                                users.Remove(found);
                                                Console.WriteLine($"You've removed user \"{enteredUser}\"");
                                            }
                                        }
                                        else if (enteredUser == loggedUsername)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You can't remove yourself.");
                                        }
                                    }

                                    if (adminsChoice == "3")
                                    {
                                        LoginService.ResetLogin(ref userUsername, ref userPassword, ref userPosition, ref loginIsOk);
                                        break;
                                    }
                                }

                                //Trainer's menu
                                if (userPosition == Roles.Trainer)
                                {
                                    Console.WriteLine("What list do you want to see:");
                                    Console.WriteLine();
                                    Console.WriteLine("1) See the list with students");
                                    Console.WriteLine("2) Search student by name");
                                    Console.WriteLine("3) See list by subject");
                                    Console.WriteLine("4) Logout");
                                    Console.WriteLine();
                                    Console.Write("User's choice: ");
                                    string teachersChoice = Console.ReadLine();
                                    Console.Clear();

                                    if (teachersChoice == "1")
                                    {
                                        do
                                        {
                                            Console.WriteLine("Student's list:");
                                            Console.WriteLine();

                                            LoginService.ListStudents(LoginService.FilterUsersByDataType(users));

                                            Console.WriteLine();
                                            Console.WriteLine("Press \"E\" if you want to exit.");
                                            teachersChoice = Console.ReadLine();

                                            if (teachersChoice == "e")
                                            {
                                                Console.Clear();
                                                break;
                                            }

                                        } while (true);
                                    }
                                    else if (teachersChoice == "2")
                                    {
                                        do
                                        {
                                            Console.WriteLine("Enter student's name: ");
                                            Console.Write("Search: ");
                                            string teachersInput = Console.ReadLine();

                                            string result = LoginService.ShowMatch(LoginService.FilterUsersByRole(users, Roles.Student), teachersInput);

                                            if (teachersInput == "")
                                            {
                                                throw new Exception("Don't leave empty search field.");
                                            }

                                            Console.Clear();
                                            if (result != "")
                                            {
                                                Console.WriteLine(result);
                                            }

                                            if (result == "")
                                            {
                                                Console.WriteLine("Sorry no student by that name.");
                                            }
                                                                                        

                                            Console.WriteLine();
                                            Console.WriteLine("Press \"E\" if you want to exit.");
                                            teachersChoice = Console.ReadLine();

                                            if (teachersChoice.ToLower() != "e")
                                            {
                                                throw new Exception("You can exit only by pressing \"E\".");
                                            }

                                            if (teachersChoice == "e")
                                            {
                                                Console.Clear();
                                                break;
                                            }

                                        } while (true);
                                    }
                                    else if (teachersChoice == "3")
                                    {
                                        do
                                        {
                                            Console.WriteLine("Subjects:");
                                            Console.WriteLine();
                                            Console.WriteLine("1) C#");
                                            Console.WriteLine("2) JS");
                                            Console.WriteLine();
                                            Console.WriteLine("Choose subject by entering the number in front of it, to see the list of students.");
                                            Console.Write("Search: ");
                                            teachersChoice = Console.ReadLine();
                                            int teachersChoiceInt = int.Parse(teachersChoice);
                                            Console.Clear();

                                            if (teachersChoice == "" || teachersChoiceInt < 1 || teachersChoiceInt > 2)
                                            {
                                                throw new Exception("You must enter a number between 1 and 2.");
                                            }

                                            if (int.Parse(teachersChoice) == 1)
                                            {
                                                LoginService.ListStudents(LoginService.FilterStudentsBySubject(users, "C#"));
                                            }

                                            if (int.Parse(teachersChoice) == 2)
                                            {
                                                LoginService.ListStudents(LoginService.FilterStudentsBySubject(users, "JS"));
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("Press \"E\" if you want to exit.");
                                            teachersChoice = Console.ReadLine().ToLower();

                                            if (teachersChoice != "e")
                                            {
                                                throw new Exception("If you want to exit press \"E\".");
                                            }

                                            if (teachersChoice == "e")
                                            {
                                                Console.Clear();
                                                break;
                                            }

                                        } while (true);
                                    }
                                    else if (teachersChoice == "4")
                                    {
                                        LoginService.ResetLogin(ref userUsername, ref userPassword, ref userPosition, ref loginIsOk);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You musth choose between 1 and 4.");
                                        Console.WriteLine();
                                    }
                                }

                                if (userPosition == Roles.Student)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("1) See the list of available subjects");
                                    Console.WriteLine("2) Logout");
                                    Console.WriteLine();
                                    Console.Write("Your choice: ");
                                    string studentsChoice = Console.ReadLine();
                                    Console.Clear();

                                    if (studentsChoice == "" || (int.Parse(studentsChoice) != 1 && int.Parse(studentsChoice) != 2))
                                    {
                                        throw new Exception("You must enter either 1 or 2.");
                                    }

                                    if (studentsChoice == "1")
                                    {
                                        do
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
                                            studentsChoice = Console.ReadLine();

                                            if (studentsChoice == "1")
                                            {
                                                LoginService.SwitchingStudentsSubject(LoginService.FilterUsersByRole(users, Roles.Student), usersName, "C#");
                                            }
                                            else if (studentsChoice == "2")
                                            {
                                                LoginService.SwitchingStudentsSubject(LoginService.FilterUsersByRole(users, Roles.Student), usersName, "JS");
                                            }
                                            else if(studentsChoice.ToLower() == "g")
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Your grade from your current subject.");
                                                Console.WriteLine(LoginService.ShowMatch(LoginService.FilterUsersByRole(users, Roles.Student), usersName));
                                                Console.WriteLine();
                                            }
                                            else if (studentsChoice == "e")
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                throw new Exception("You must choose \"1\", \"2\", \"g\" or \"e\".");
                                            }

                                        } while (true);
                                    }

                                    if (studentsChoice == "2")
                                    {
                                        LoginService.ResetLogin(ref userUsername, ref userPassword, ref userPosition, ref loginIsOk);
                                        break;
                                    }
                                }

                            } while (true);

                        }
                    }

                } while (true);

            }
            catch (FormatException)
            {

                Console.WriteLine("You did not enter a correct format.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There is no user with that name.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();

        }
    }
}
