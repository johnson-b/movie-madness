using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMDbRequests
{
    public class TMDb
    {
        public int Requests { get; set; }
        public readonly int MaxRequests = 40;

        public async Task<List<Movie>> GetMoviesSimilarTo(CancellationToken cancellationToken, string search)
        {
            List<Movie> movieResults = new List<Movie>();
            try
            {
                using (var client = new ServiceClient(Properties.Settings.Default.tmdbApiKey))
                {
                    var movies = await client.Movies.SearchAsync(search, "en", true, null, 1, cancellationToken);
                    foreach(Movie m in movies.Results)
                    {
                        var movie = await client.Movies.GetAsync(m.Id, "en", true, cancellationToken);
                        movieResults.Add(movie);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return movieResults;
        }
        public async Task<List<Movie>> GetMovies(CancellationToken cancellationToken)
        {
            Requests = 0;
            List<Movie> movieResults = new List<Movie>();
            try
            {
                using (var client = new ServiceClient(Properties.Settings.Default.tmdbApiKey))
                {
                    for (int i = 10000; i <= 25000; i++)
                    {
                        try
                        {
                            Requests++;
                            CoolDown();
                            var movie = await client.Movies.GetAsync(i, "en", true, cancellationToken);
                            movieResults.Add(movie);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return movieResults;
            }
            return movieResults;
        }

        public async Task<List<Movie>> GetComingSoonMovies(CancellationToken cancellationtoken)
        {
            Requests = 0;
            List<Movie> movieResults = new List<Movie>();
            try
            {
                using (var client = new ServiceClient(Properties.Settings.Default.tmdbApiKey))
                {
                    var movies = await client.Movies.GetUpcomingAsync(null, 1, cancellationtoken);
                    foreach (Movie m in movies.Results)
                    {
                        var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationtoken);
                        movieResults.Add(movie);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return movieResults;
            }
            return movieResults;
        }
        public async Task<List<Movie>> GetPopularMovies(CancellationToken cancellationToken, int pages)
        {
            Requests = 0;
            List<Movie> movieResults = new List<Movie>();
            try
            {
                using (var client = new ServiceClient(Properties.Settings.Default.tmdbApiKey))
                {
                    Console.WriteLine("Getting today's popular movies...");
                    for (int i = 1; i <= pages; i++)
                    {
                        CoolDown();
                        var movies = await client.Movies.GetPopularAsync(null, i, cancellationToken);
                        Requests++;
                        foreach (Movie m in movies.Results)
                        {
                            CoolDown();
                            var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationToken);
                            Requests++;
                            movieResults.Add(movie);
                        }
                        Console.WriteLine(string.Format("Page {0} of {1} finished", i, pages));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return movieResults;
            }
            return movieResults;
        }

        public void CoolDown()
        {
            if (Requests == MaxRequests)
            {
                Console.Write("Cooldown initiated...");
                for (int i = 10; i > 0; i--)
                {
                    Console.Write("....................................");
                    Thread.Sleep(1000);
                    Console.Write("....................................");
                }
                Console.WriteLine("");
                Requests = 0;
            }
        }
    }
}
