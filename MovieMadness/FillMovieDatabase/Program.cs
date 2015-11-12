using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

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

                TMDbClient client = new TMDbClient(Properties.Settings.Default.tmdbApiKey);
                SearchContainer<MovieResult> movies = client.GetMovieList(TMDbLib.Objects.Movies.MovieListType.TopRated, 100);
                foreach (MovieResult movieResult in movies.Results)
                {
                    Movie movie = client.GetMovie(movieResult.Id);
                    Credits credits = movie.Credits;
                    if (credits != null)
                    {
                        Console.WriteLine("Title: {0}", movie.Title);
                    }
                    
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
}
