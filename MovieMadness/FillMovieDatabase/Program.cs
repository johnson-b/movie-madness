using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TMDbLib.Client;
//using TMDbLib.Objects.General;
//using TMDbLib.Objects.Movies;
using System.Net.TMDb;
using System.Threading;
using System.IO;

namespace FillMovieDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString);
                connection.Open();

                TMDb db = new TMDb();
                var moviesTask = db.GetMovies(CancellationToken.None);
                Task.WaitAll(moviesTask);
                List<Movie> movies = moviesTask.Result;
                foreach (Movie movie in movies)
                {
                    SqlCommand command = connection.CreateCommand();

                    /* movie table 
                     * title
                     * release year(int)
                     * duration(int)
                     * rating(R, PG etc.)
                     */

                    /* director table 
                     * first name
                     * last name
                     */

                    /* directMovie table
                     * director id
                     * movie id
                     */

                    /* actor table 
                     * first name
                     * last name 
                     */

                    /* actorRole table
                     * actor id
                     * movie id
                     * actor_role (character name)
                     */

                    /* genre table 
                     * genre 
                     */

                    /* movieGenre table 
                     * genre id 
                     * movie id
                     */
                }

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.Read();
        }
    }

    public class TMDb
    {
        public async Task<List<Movie>> GetMovies(CancellationToken cancellationToken)
        {
            List<Movie> movieResults = new List<Movie>();
            using (var client = new ServiceClient(Properties.Settings.Default.tmdbApiKey))
            {

                var movies = await client.Movies.GetPopularAsync(null, 1, cancellationToken);
                foreach (Movie m in movies.Results)
                {
                    var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationToken);
                    movieResults.Add(movie);
                }
            }
            return movieResults;
        }
    }
}
