using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
        public double TicketPrice { get; set; }

        public Movie(string title, Genre genre, int rating)
        {
            Title = title;
            Genre = genre;
            try
            {

                if (rating <= 0 || rating > 5)
                {
                    throw new Exception("The value must be between 1 and 5.");
                }
                else if (rating.GetType() == null)
                {
                    throw new ArgumentNullException("The value can't be \"null\".");
                }
                Rating = rating;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TicketPrice = 5 * Rating;
        }
    }
}
