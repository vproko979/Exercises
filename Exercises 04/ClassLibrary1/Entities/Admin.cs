using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Admin : User
    {
        public Admin(string name, string lastName, string userName, string password) : base(name, lastName, userName, password)
        {
            Role = Roles.Admin;
        }
    }
}
