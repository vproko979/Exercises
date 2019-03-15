using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Messages { get; set; }

        public User(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Messages = new string[3];
            Messages[0] = "This is 2-step verification.";
            Messages[1] = "A code will be sent to your phone via SMS, please enter it.";
        }

        public string ShowStudentsInfo()
        {
            return $"ID:{Id} Username:{Username}";
        }
    }

}
