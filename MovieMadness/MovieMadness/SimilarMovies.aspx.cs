using MovieDbEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.TMDb;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMDbRequests;

namespace MovieMadness
{
    public partial class SimilarMovies : System.Web.UI.Page
    {
        SqlConnection Connection { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);

            List<DbMovie> dbMovies = new List<DbMovie>();
            DbMovie movie1 = DbMovie.GetMovie(Connection, Request.QueryString["movie_1"]);
            DbMovie movie2 = DbMovie.GetMovie(Connection, Request.QueryString["movie_2"]);
            DbMovie movie3 = DbMovie.GetMovie(Connection, Request.QueryString["movie_3"]);

            List<DbGenre> genres = new List<DbGenre>();
            foreach(DbGenre g in DbGenre.GetMovieGenres(Connection, movie1.Id))
            {
                if (!genres.Contains(g))
                    genres.Add(g);
            }

            //foreach (DbGenre g in DbGenre.GetMovieGenres(Connection, movie2.Id))
            //{
            //    if (!genres.Contains(g))
            //        genres.Add(g);
            //}

            //foreach (DbGenre g in DbGenre.GetMovieGenres(Connection, movie3.Id))
            //{
            //    if (!genres.Contains(g))
            //        genres.Add(g);
            //}

            foreach (DbGenre genre in genres)
            {
                foreach(DbMovie m in DbMovie.GetSimilarMovies(Connection, genre.Id))
                {
                    if (!dbMovies.Contains(m))
                        dbMovies.Add(m);
                }
            }

            Movies.DataSource = dbMovies;
            Movies.DataBind();
        }
    }
}