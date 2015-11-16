using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.TMDb;
using System.Threading;
using System.IO;
using MovieDbEntities;

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
                    DbMovie dbMovie = new DbMovie(
                        movie.Title,
                        movie.ReleaseDate.Value.Year,
                        movie.Runtime.Value,
                        (from r in movie.Releases.Results
                         where r.CountryCode.Contains("US")
                         select r).FirstOrDefault().Certification);
                    int movieId = (int)dbMovie.Insert(connection).ExecuteScalar();
                    Console.WriteLine(string.Format("Movie ({0}) inserted...", movie.Title));

                    var directorQuery = from d in movie.Credits.Crew
                                        where d.Department.Contains("Directing")
                                        where d.Job.Contains("Director")
                                        select d;
                    DbDirector director = new DbDirector(directorQuery.FirstOrDefault().Name);
                    int directorId = (int)director.Insert(connection).ExecuteScalar();
                    Console.WriteLine(string.Format("Director ({0}) inserted...", director.Name));

                    DbDirectMovie directMovie = new DbDirectMovie(directorId, movieId);
                    directMovie.Insert(connection).ExecuteScalar();
                    Console.WriteLine(string.Format("Movie ({0}) linked with Director ({1})...", dbMovie.Title, director.Name));

                    foreach (MediaCast actor in movie.Credits.Cast)
                    {
                        string name = actor.Name;
                        if (name.Contains("'"))
                        {
                            name = name.Replace("'", "''");
                        }
                        DbActor dbActor = new DbActor(name);
                        int actorId = (int)dbActor.Insert(connection).ExecuteScalar();
                        Console.WriteLine(string.Format("Actor ({0}) inserted...", dbActor.Name));

                        string roleName = actor.Character;
                        if (roleName.Contains("'"))
                        {
                            roleName = roleName.Replace("'", "''");
                        }
                        DbActorRole actorRole = new DbActorRole(actorId, movieId, roleName);
                        actorRole.Insert(connection).ExecuteScalar();
                        Console.WriteLine(string.Format("Actor ({0}) with Role ({1}) linked with Movie ({2})...", dbActor.Name, actorRole.ActorRole, dbMovie.Title));
                    }

                    foreach (Genre genre in movie.Genres)
                    {
                        DbGenre dbGenre = new DbGenre(genre.Name);
                        int genreId = (int)dbGenre.Insert(connection).ExecuteScalar();
                        Console.WriteLine(string.Format("Genre ({0}) inserted...", dbGenre.Genre));

                        DbMovieGenre movieGenre = new DbMovieGenre(genreId, movieId);
                        movieGenre.Insert(connection).ExecuteScalar();
                        Console.WriteLine(string.Format("Genre ({0}) linked with Movie ({1})...", dbGenre.Genre, dbMovie.Title));
                    }
                }

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Press <Enter> to continue...");
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
