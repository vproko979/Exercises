using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public static class LoginService
    {
        public static Roles usersPostition(string choice)
        {
            Roles userPosition = Roles.Student;

            if (choice == "1")
            {
                userPosition = Roles.Admin;
            }
            else if (choice == "2")
            {
                userPosition = Roles.Trainer;
            }
            else if (choice == "3")
            {
                userPosition = Roles.Student;
            }
            else
            {
                throw new Exception("You must enter a number between 1 and 3.");
            }

            return userPosition;
        }

        public static void AddNewUser(List<User> users, Admin newUser)
        {
            users.Add(newUser);
            Console.Clear();
        }

        public static void AddNewUser(List<User> users, Trainer newUser)
        {
            users.Add(newUser);
            Console.Clear();
        }

        public static void AddNewUser(List<User> users, Student newUser)
        {
            users.Add(newUser);
            Console.Clear();
        }

        public static void CheckLogIn(User logged, string userUsername, string userPassword, Roles userPosition, ref bool loginIsOk, ref string usersName, ref string loggedUsername)
        {
            if (logged.Username == userUsername && logged.Password == userPassword && logged.Role == userPosition)
            {
                loginIsOk = true;
                usersName = logged.FirstName;
                loggedUsername = logged.Username;
            }
        }

        public static void ResetLogin(ref string userUsername, ref string userPassword, ref Roles userPosition, ref bool loginIsOk)
        {
            userUsername = "";
            userPassword = "";
            userPosition = Roles.Student;
            loginIsOk = false;
            Console.Clear();
        }

        public static string ShowMatch(List<User> list, string input)
        {
            string result = "";

            foreach (Student user in list)
            {
                if (user.FirstName.ToLower() == input.ToLower())
                {
                    result = $"Full name: {user.FullName()} / Subject {user.Subject} / Grade {user.Grade}";
                }
            }

            return result;
        }

        public static void StudentsStatus(Student student, string subject)
        {
            student.Subject = subject;
            Console.Clear();
            Console.WriteLine("Your current status:");
            Console.WriteLine();
            Console.WriteLine($"Full name: {student.FullName()} / Current subject: {student.Subject}");
            Console.WriteLine();
        }

        public static User FindByUsername(List<User> users, string username)
        {
            return users.FirstOrDefault(user => user.Username == username);
        }

        public static void ListStudents(List<Student> list)
        {
            foreach (var student in list)
            {
                Console.WriteLine($"Full name: {student.FullName()} / Subject {student.Subject} / Grade {student.Grade}");
            }
        }

        public static IEnumerable<string> ExtractStudentProperty(List<User> users)
        {
            var studentsList = users.OfType<Student>().ToList();
            return studentsList.Select(user => user.Subject).Distinct();
        }

        public static List<Student> FilterStudentsBySubject(List<User> users, string subject)
        {
            return FilterUsersByDataType(users).Where(student => student.Subject == subject).ToList();
        }

        public static List<Student> FilterUsersByDataType(List<User> users)
        {
            return users.OfType<Student>().ToList();
        }

        public static List<User> FilterUsersByRole(List<User> users, Roles role)
        {
            return users.Where(user => user.Role == role).ToList();
        }

        public static void SwitchingStudentsSubject(List<User> filteredList, string usersName, string subject)
        {
            foreach (Student student in filteredList)
            {
                if (student.FirstName == usersName)
                {
                    StudentsStatus(student, subject);
                }
            }
        }
    }
}
