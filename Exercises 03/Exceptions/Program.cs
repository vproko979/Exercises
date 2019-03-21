using ClassLibrary1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1
            //Movie movie21 = new Movie("21 grams", Genre.Drama);
            //Console.WriteLine(movie21.Rating);
            #endregion

            //Exercise 2

            Cinema cinema1 = new Cinema("Cineplex", new List<int>() { 1, 2, 3, 4 }, MovieListGenerator.List1());
            Cinema cinema2 = new Cinema("Milenium", new List<int>() { 1, 2, 3, 4 }, MovieListGenerator.List2());

            string userSelection;
            Cinema selectedCinema;
            string selectedGenre = "";

            try
            {
                Console.WriteLine("Choose your cinema:");
                Console.WriteLine("1) Cineplex");
                Console.WriteLine("2) Milenium");
                userSelection = Console.ReadLine();

                if (int.Parse(userSelection) == 1)
                {
                    userSelection = "Cineplex";
                    selectedCinema = cinema1;
                }
                else if (int.Parse(userSelection) == 2)
                {
                    userSelection = "Milenium";
                    selectedCinema = cinema2;
                }
                else
                {
                    throw new Exception("You can enter either 1 or 2.");
                }

                Console.Clear();
                if (userSelection.ToLower() == cinema1.Name.ToLower())
                {
                    CinemaService.ShowCinemaMenu(userSelection);
                    userSelection = Console.ReadLine();
                    CinemaService.ControlSelection(userSelection);
                    Console.Clear();
                }
                else if (userSelection.ToLower() == cinema2.Name.ToLower())
                {
                    CinemaService.ShowCinemaMenu(userSelection);
                    userSelection = Console.ReadLine();
                    CinemaService.ControlSelection(userSelection);
                    Console.Clear();
                }

                if (userSelection == "1")
                {
                    Console.WriteLine(CinemaService.ShowAllMovies(selectedCinema.ListOfMovies));
                    Console.WriteLine("Type in one of the titles from the list.");
                    userSelection = Console.ReadLine();

                    CinemaService.DoWeHaveAMatch(userSelection, selectedCinema);
                }
                else if (userSelection == "2")
                {
                    Console.WriteLine("Enter the genre of the movie you want to see:");
                    userSelection = Console.ReadLine();
                    selectedGenre = userSelection;
                    Console.WriteLine(CinemaService.ShowByGenre(selectedCinema, userSelection));
                    Console.WriteLine("Type in one of the titles from the list.");
                    userSelection = Console.ReadLine();

                    CinemaService.DoWeHaveAMatch(userSelection, selectedCinema);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please don't leave empty field.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
             Console.ReadLine();

        }
    }
}
