using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public abstract class DbEntity
    {
        public abstract SqlCommand Insert(SqlConnection conn);
        public static string GetImageUrl(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "";
            }
            return "http://image.tmdb.org/t/p/original" + path;
        }

        public static void ProcessMovieResponse(List<Movie> movies, SqlConnection connection)
        {
            connection.Open();
            DataTable data = new DataTable();
            int movieCount = 0;
            foreach (Movie movie in movies)
            {
                try
                {
                    DbMovie dbMovie = new DbMovie()
                    {
                        Title = movie.Title
                    };
                    var rating = (from r in movie.Releases.Results
                                  where r.CountryCode.Contains("US")
                                  select r).FirstOrDefault();
                    dbMovie.Rating = rating != null ? rating.Certification : "";
                    if (movie.ReleaseDate.HasValue)
                        dbMovie.ReleaseYear = movie.ReleaseDate.Value.Year;
                    if (movie.Runtime.HasValue)
                        dbMovie.Duration = movie.Runtime.Value;
                    dbMovie.UserRating = (float)movie.VoteAverage;
                    dbMovie.UserRatingCount = movie.VoteCount;
                    dbMovie.Overview = movie.Overview;
                    dbMovie.PosterImageUrl = DbEntity.GetImageUrl(movie.Poster);
                    var mRes = dbMovie.Insert(connection).ExecuteReader();
                    data.Load(mRes);
                    mRes.Close();
                    //int movieId = (int)dbMovie.Insert(connection).ExecuteScalar();
                    int movieId = (int)data.Select().FirstOrDefault()["Id"];
                    var res = data.Select().FirstOrDefault()["Response"];
                    if (res != null)
                        Console.WriteLine(res);
                    else
                        Console.WriteLine(string.Format("Movie ({0}) inserted...", movie.Title));
                    data.Clear();

                    var directorQuery = from d in movie.Credits.Crew
                                        where d.Department.Contains("Directing")
                                        where d.Job.Contains("Director")
                                        select d;
                    if (directorQuery.FirstOrDefault() != null)
                    {
                        DbDirector director = new DbDirector(directorQuery.FirstOrDefault().Name, DbEntity.GetImageUrl(directorQuery.FirstOrDefault().Profile));
                        var dRes = director.Insert(connection).ExecuteReader();
                        data.Load(dRes);
                        dRes.Close();
                        int directorId = (int)data.Select().FirstOrDefault()["Id"];
                        res = data.Select().FirstOrDefault()["Response"];
                        if (res != null)
                            Console.WriteLine(res);
                        //else
                        //    Console.WriteLine(string.Format("Director ({0}) inserted...", director.Name));
                        data.Clear();

                        DbDirectMovie directMovie = new DbDirectMovie(directorId, movieId);
                        directMovie.Insert(connection).ExecuteNonQuery();
                        //Console.WriteLine(string.Format("Movie ({0}) linked with Director ({1})...", dbMovie.Title, director.Name));
                    }

                    foreach (MediaCast actor in movie.Credits.Cast)
                    {
                        string name = actor.Name;
                        if (name.Contains("'"))
                        {
                            name = name.Replace("'", "''");
                        }
                        DbActor dbActor = new DbActor(name, DbEntity.GetImageUrl(actor.Profile));
                        var aRes = dbActor.Insert(connection).ExecuteReader();
                        data.Load(aRes);
                        aRes.Close();
                        int actorId = (int)data.Select().FirstOrDefault()["Id"];
                        res = data.Select().FirstOrDefault()["Response"];
                        if (res != null)
                            Console.WriteLine(res);
                        //else
                        //    Console.WriteLine(string.Format("Actor ({0}) inserted...", dbActor.Name));
                        data.Clear();

                        string roleName = actor.Character;
                        if (roleName.Contains("'"))
                        {
                            roleName = roleName.Replace("'", "''");
                        }
                        DbActorRole actorRole = new DbActorRole(actorId, movieId, roleName);
                        actorRole.Insert(connection).ExecuteNonQuery();
                        //Console.WriteLine(string.Format("Actor ({0}) with Role ({1}) linked with Movie ({2})...", dbActor.Name, actorRole.ActorRole, dbMovie.Title));
                    }

                    foreach (Genre genre in movie.Genres)
                    {
                        DbGenre dbGenre = new DbGenre(genre.Name);
                        var gRes = dbGenre.Insert(connection).ExecuteReader();
                        data.Load(gRes);
                        gRes.Close();
                        int genreId = (int)data.Select().FirstOrDefault()["Id"];
                        res = data.Select().FirstOrDefault()["Response"];
                        if (res != null)
                            Console.WriteLine(res);
                        //else
                        //    Console.WriteLine(string.Format("Genre ({0}) inserted...", dbGenre.Genre));
                        data.Clear();

                        DbMovieGenre movieGenre = new DbMovieGenre(genreId, movieId);
                        movieGenre.Insert(connection).ExecuteNonQuery();
                        //Console.WriteLine(string.Format("Genre ({0}) linked with Movie ({1})...", dbGenre.Genre, dbMovie.Title));
                    }

                    foreach (Image image in movie.Images.Backdrops)
                    {
                        DbBackdrop dbBackdrop = new DbBackdrop();
                        dbBackdrop.BackdropUrl = GetImageUrl(image.FilePath);
                        var bRes = dbBackdrop.Insert(connection).ExecuteReader();
                        data.Load(bRes);
                        bRes.Close();
                        int backdropId = (int)data.Select().FirstOrDefault()["Id"];
                        res = data.Select().FirstOrDefault()["Response"];
                        if (res != null)
                            Console.WriteLine(res);
                        //else
                        //    Console.WriteLine(string.Format("Backdrop image ({0}) inserted...", dbBackdrop.BackdropUrl));
                        data.Clear();

                        DbMovieBackdrop dbMovieBackdrop = new DbMovieBackdrop();
                        dbMovieBackdrop.MovieId = movieId;
                        dbMovieBackdrop.BackdropId = backdropId;
                        dbMovieBackdrop.Insert(connection).ExecuteNonQuery();
                        //Console.WriteLine(string.Format("Backdrop Image ({0}) linked with Movie ({1})...", dbMovieBackdrop.BackdropId, dbMovieBackdrop.MovieId));
                    }
                    movieCount++;
                    Console.WriteLine(string.Format("Finished processing movie #{0} out of #{1}", movieCount, movies.Count));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            connection.Close();
        }
    }
}
