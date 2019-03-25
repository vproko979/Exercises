using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public User(string name, string lastName, string userName, string password)
        {
            FirstName = name;
            LastName = lastName;
            Username = userName;
            Password = password;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

    
