using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Student : User
    {
        public string Subject { get; set; }
        public int Grade { get; set; }

        public Student(string name, string lastName, string userName, string password, string subject, int grade) : base(name, lastName, userName, password)
        {
            Subject = subject.ToUpper();
            Grade = grade;
            Role = Roles.Student;
        }
    }
}
