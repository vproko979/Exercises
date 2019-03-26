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
            List<User> users = UserListGenerator.UsersList();

            Roles userPosition = Roles.Student;
            bool loginIsOk = false;
            string loggedUsername = "";
            string usersName = "";


            try
            {

                do
                {

                    Menus.MainMenu();
                    string usersChoice = Console.ReadLine();
                    Console.Clear();

                    //Selecting position.
                    Errors.EmptyField(usersChoice);
                    if (usersChoice != "")
                    {
                        userPosition = LoginService.usersPostition(usersChoice);
                    }

                    string userUsername = "", userPassword = "";
                    Menus.UsernamePasswordInput(ref userUsername, ref userPassword);
                    Errors.EmptyFields2(userUsername, userPassword);

                    if (userUsername != "" && userPassword != "")
                    {
                        foreach (User logged in users)
                        {

                            LoginService.CheckLogIn(logged, userUsername, userPassword, userPosition, ref loginIsOk, ref usersName, ref loggedUsername);

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
                                    User.PrintAllUsers(users);
                                    Menus.AdminsSubMenu();
                                    string adminsChoice = Console.ReadLine();
                                    Console.Clear();

                                    //Add new user
                                    if (adminsChoice == "1")
                                    {
                                        string enteredName = "", enteredLastName = "", enteredUserName = "", enteredPassword = "";
                                        Menus.NewUserInfo(ref enteredName, ref enteredLastName, ref enteredUserName, ref enteredPassword);
                                        Errors.EmptyFields3(enteredName, enteredLastName, enteredUserName, enteredPassword);
                                        Menus.PositionSelection();
                                        string enteredPosition = Console.ReadLine();
                                        Errors.WrongPosition(enteredPosition);

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
                                            Errors.EmptyField(enteredSubject);
                                            Errors.WrongSubject(enteredSubject);
                                            Console.WriteLine("Enter student's grade:");
                                            int enteredGrade = int.Parse(Console.ReadLine());
                                            Errors.WrongNumber(enteredGrade);
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
                                        Errors.EmptyField(enteredUser);

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
                                    Menus.TrainerSubMenu();
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
                                            Errors.WrongExit(teachersChoice);

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
                                            Errors.EmptyField(teachersInput);

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
                                            teachersChoice = Console.ReadLine().ToLower();
                                            Errors.WrongExit(teachersChoice);

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
                                            Menus.SelectSubject();
                                            teachersChoice = Console.ReadLine();
                                            Console.Clear();
                                            Errors.WrongSubject3(teachersChoice);

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
                                            Errors.WrongExit(teachersChoice);

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
                                    Menus.StudentsMenu();
                                    string studentsChoice = Console.ReadLine();
                                    Console.Clear();
                                    Errors.WrongSubject2(studentsChoice);

                                    if (studentsChoice == "1")
                                    {
                                        do
                                        {
                                            Menus.SubjectSelection();
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
