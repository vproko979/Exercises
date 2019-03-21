using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class MovieListGenerator
    {
        public static List<Movie> List1 ()
        {
            return new List<Movie>
            {
                new Movie("Scary Movie", Genre.Comedy, 4),
                new Movie("American Pie", Genre.Comedy, 4),
                new Movie("Saw", Genre.Horror, 4),
                new Movie("The Shining", Genre.Horror, 4),
                new Movie("Rambo", Genre.Action, 4),
                new Movie("The Terminator", Genre.Action, 4),
                new Movie("Forrest Gump", Genre.Drama, 4),
                new Movie("12 Angru Men", Genre.Drama, 4),
                new Movie("Passengers", Genre.SciFi, 4),
                new Movie("Interstellar", Genre.SciFi, 4)
            };
        }

        public static List<Movie> List2()
        {
            return new List<Movie>
            {
                new Movie("Airplane", Genre.Comedy, 4),
                new Movie("Johnny English", Genre.Comedy, 4),
                new Movie("The Ring", Genre.Horror, 4),
                new Movie("Sinister", Genre.Horror, 4),
                new Movie("RoboCop", Genre.Action, 4),
                new Movie("Judge Dredd", Genre.Action, 4),
                new Movie("The Social Network", Genre.Drama, 4),
                new Movie("The Shawshank Redemption", Genre.Drama, 4),
                new Movie("Inception", Genre.SciFi, 4),
                new Movie("Avatar", Genre.SciFi, 4)
            };
        }
    }
}
