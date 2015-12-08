using MovieDbEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieMadness
{
    public partial class MovieDetail : System.Web.UI.Page
    {
        public SqlConnection Connection { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
            //DbMovie movie = DbMovie.GetMovie(GetSqlConnection(), Request.QueryString["movie"]);
            // get backdrop
            //DbBackdrop backdrop = DbBackdrop.GetMovieBackdrop(Connection, movie.Id);
            // get posterImageurl --> get from Movie.PosterImageUrl
            // get overview --> get from Movie.Overview
            // get director
            // get actors?
            // get genre 
            // get rating --> get from Movie.Rating
            // get user rating --> get from Movie.UserRating
            // get count of user ratings --> get from Movie.UserRatingCount
            // get duration --> get from Movie.duration
            // get release_year --> get from Movie.ReleaseYear
        }

        [WebMethod]
        public static DbMovie GetMovieDetails(string title)
        {
            return DbMovie.GetMovie(GetSqlConnection(), title);
        }

        [WebMethod]
        public static List<DbBackdrop> GetMovieBackdrops(long id)
        {
            return DbBackdrop.GetMovieBackdrop(GetSqlConnection(), id);
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
        }
    }
}