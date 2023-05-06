using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System.Net.WebSockets;

namespace MyNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // MovieLibraryOO has examples of each of these if you need it.

            //Creating main menu options & Reading user input
            Console.WriteLine("Please select your menu option.");
            Console.WriteLine("It may take some time to properly load.");
            Console.WriteLine("1) Search for a movie.");
            Console.WriteLine("2) Add a movie.");
            Console.WriteLine("3) Update a movie.");
            Console.WriteLine("4) Delete a movie.");
            Console.WriteLine("Press any other key to exit...");
            var menuOption = Console.ReadLine();
            
            //Creating the various options that the user can choose.
            if (menuOption == "1")
            {
                // Searching for a movie.
                Console.WriteLine("Search for a Movie!");

                using (var db = new MovieContext())
                {
                    var moveies = db.Movies;
                    //.Include(x => x.MovieGenres)
                    //.ThenInclude(x => x.Genres);

                    //Use something like this for exact movie match? 
                    //var mov = db.Movies.FirstOrDefault(x => x.Title == movieUpdate);
                    var limitedMovies = moveies.Take(10);

                    Console.WriteLine("The Movies are: ");
                    foreach (var mov in moveies.Take(10).ToList())
                    {
                        Console.WriteLine($"Movie Title: {mov.Title}  ");
                        
                    }

                }

            }
            else if (menuOption == "2")
            {
                //Adding a new movie to the database. 

                Console.WriteLine("Adding a Movie to the database.");

                Console.WriteLine("Enter a movie Title");
                var movie = Console.ReadLine();
                Console.WriteLine("Enter a movie Release Date");
                Console.WriteLine(" MM / DD / YYYY - Use this format");

                var releaseDate = DateTime.Parse(Console.ReadLine());

                using (var db = new MovieContext())
                {
                    var mov = new Movie();
                    mov.Title = movie;
                    mov.ReleaseDate = releaseDate;

                    db.Movies.Add(mov);
                    db.SaveChanges();
                    Console.WriteLine($"Created {mov.Id} {mov.Title} {mov.ReleaseDate}!");
                }

            }
            else if (menuOption == "3")
            {
                // Updating the movie
                Console.WriteLine("Updating a movie in the database.");

                Console.WriteLine("Enter an Movie to update");
                var movieUpdate = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var mov = db.Movies.FirstOrDefault(x => x.Title == movieUpdate);
                    // Add Release Date functionality here.

                    Console.WriteLine("Enter the updated movie Title");
                    var movTitle = Console.ReadLine();

                    mov.Title = movieUpdate;
                    

                    db.SaveChanges();
                }

            }
            else if (menuOption == "4")
            {
                Console.WriteLine("Deleting a movie entry in the database.");


            }
            else if (menuOption != "1" && menuOption != "2" && menuOption != "3" && menuOption != "4")
            {
                // Could honestly just do an else instead...
                Console.WriteLine("Exiting Program...");
            }



            /*

            // In-class code stuffs.

            // CRUD
            // Create, read, update, delete.

            // cRud
            // READ
            using (var db = new MovieContext())
            {
                var occupations = db.Occupations;

                Console.WriteLine("The occupations are :");
                foreach (var occ in occupations)
                {
                    Console.WriteLine(occ.Name);
                }

            }

            // Crud
            // CREATE
            Console.WriteLine("Enter an occupation");
            var occupation = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var occ = new Occupation();
                occ.Name = occupation;

                db.Occupations.Add(occ);
                db.SaveChanges();
                Console.WriteLine($"Created {occ.Id} {occ.Name}!");
            }

            // crUd
            // UPDATE
            Console.WriteLine("Enter an occupation to update");
            occupation = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var occ = db.Occupations.FirstOrDefault(x => x.Name == occupation);

                Console.WriteLine("Enter the updated occupation name");
                var occName = Console.ReadLine();

                occ.Name = occupation;

                db.SaveChanges();
            }


            // Users stuff

            using (var db = new MovieContext())
            {
                var users = db.Users;
                    //.Include(x => x.Occupation)
                    //.Include(x => x.UserMovies)
                    //.ThenInclude(x => x.Movie);

                var limitedUsers = users.Take(10);

                Console.WriteLine("The users are :");
                foreach (var user in users.Take(10).ToList())
                {
                    Console.WriteLine($"User: {user.Id} {user.Gender} {user.ZipCode}");
                    Console.WriteLine($"Occupation: {user.Occupation.Name}");
                    Console.WriteLine($"Rather Movies: ");
                    foreach (var userMovie in user.UserMovies)
                    {
                        Console.WriteLine(userMovie.Movie.Title);
                    }

                }

            }


            // REMOVE

            using (var db = new MovieContext())
            {
                var occ = db.Occupations.FirstOrDefault(x => x.Name == "");
                db.Occupations.Remove(occ);
                db.SaveChanges();


            }

            */

        }
    }
}