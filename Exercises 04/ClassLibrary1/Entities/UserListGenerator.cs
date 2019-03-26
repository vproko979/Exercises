using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public static class UserListGenerator
    {
        public static List<User> UsersList()
        {
            return new List<User>
            {
                new Admin("John", "Doe", "jdoe", "jdoe123"),
                new Trainer("Bob", "Bobsky", "bsky", "bsky123"),
                new Trainer("Mike", "Bobsky", "bsky1", "bsky123"),
                new Student("Kimiko", "Burkett", "kimi", "kimi123", "C#", 5),
                new Student("Horacio", "Villar", "villa", "vila123", "JS", 4),
                new Student("Boris", "Lacross", "cross", "cross123", "C#", 5),
                new Student("Toney", "Matsui", "toni", "toni123", "C#", 5),
                new Student("Ron", "Currin", "curr", "curr123", "JS", 4)
            };
        }
    }
}
