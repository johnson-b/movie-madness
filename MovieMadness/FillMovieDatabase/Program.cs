using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.TMDb;
using System.Threading;
using MovieDbEntities;
using TMDbRequests;

namespace FillMovieDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString);
                TMDb db = new TMDb();
                //var moviesTask = db.GetPopularMovies(CancellationToken.None, 10);
                //var moviesTask = db.GetComingSoonMovies(CancellationToken.None);
                //var moviesTask = db.GetMovies(CancellationToken.None);
                var moviesTask = db.GetMoviesSimilarTo(CancellationToken.None, "Saw");
                Task.WaitAll(moviesTask);
                List<Movie> movies = moviesTask.Result;
                DbEntity.ProcessMovieResponse(movies, connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Press <Enter> to continue...");
            Console.Read();
        }
    }
}
