using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public static class CinemaService
    {
        public static void ShowCinemaMenu(string cinemaName)
        {
            Console.WriteLine($"You've choose {char.ToUpper(cinemaName[0]) + cinemaName.Substring(1)} cinema.");
            Console.WriteLine($"Check {cinemaName}'s repertoire:");
            Console.WriteLine();
            Console.WriteLine("1) Show all movies.");
            Console.WriteLine("2) Show movies by genre.");
        }

        public static void ControlSelection(string userSelection)
        {
            if (userSelection == "")
            {
                throw new Exception("You can't continue without making a choice.");
            }
            else if (int.Parse(userSelection) != 1 && int.Parse(userSelection) != 2)
            {
                throw new Exception("You must enter 1 or 2, to continue.");
            }
        }

        public static void ShowMoviesByGenre()
        {
            Console.WriteLine("Enter movie genre");
        }

        public static string ShowAllMovies(List<Movie> cinema)
        {
            string result = "";

            foreach (Movie movie in cinema)
            {
                result += $"{movie.Title}\n";
            }

            return result;
        }

        public static string ShowByGenre(Cinema cinema, string genre)
        {
            string result = "";
            string matchGenre = genre.ToLower();
            Genre selectedGenre;

            switch (matchGenre)
            {
                case "comedy":
                    selectedGenre = Genre.Comedy;
                    break;
                case "horror":
                    selectedGenre = Genre.Horror;
                    break;
                case "action":
                    selectedGenre = Genre.Action;
                    break;
                case "drama":
                    selectedGenre = Genre.Drama;
                    break;
                case "scifi":
                    selectedGenre = Genre.SciFi;
                    break;
                default:
                    throw new Exception("You can proceed only if you type one of this choices: comedy, horror, action, drama or scifi.");
            }

            List<Movie> listOfMovies = cinema.ListOfMovies.Where(movie => movie.Genre == selectedGenre ).ToList();

            foreach (Movie movie in listOfMovies)
            {
                result += $"{movie.Title}\n";
            }

            return result;
        }

        public static void DoWeHaveAMatch(string userSelection, Cinema selectedCinema)
        {
            if (!ShowAllMovies(selectedCinema.ListOfMovies).ToLower().Contains(userSelection.ToLower()))
            {
                throw new Exception("Enter correct title from the list.");
            }
            else if (userSelection == "")
            {
                throw new Exception("You must enter the title of the movie.");
            }
            else
            {
                foreach (Movie movie in selectedCinema.ListOfMovies)
                {
                    if (movie.Title.ToLower() == userSelection.ToLower())
                    {
                        Console.WriteLine(selectedCinema.WatchingMovie(movie));
                    }
                };
            }
        }
    }
}
