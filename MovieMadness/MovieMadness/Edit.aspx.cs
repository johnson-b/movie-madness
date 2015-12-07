using MovieDbEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieMadness
{
    public partial class Edit : System.Web.UI.Page
    {
        SqlConnection Connection { get; set; }
        public long MovieId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
            DbMovie movie = DbMovie.GetMovie(Connection, Request.QueryString["movie"]);
            MovieId = movie.Id;
            if (!IsPostBack)
            {
                MovieTitle.Text = movie.Title;
                ReleaseDate.Text = movie.ReleaseYear.ToString();
                Duration.Text = movie.Duration.ToString();
                Rating.Text = movie.Rating;
            }
        }

        protected void UpdateMovie(object sender, EventArgs e)
        {
            
            DbMovie movie = new DbMovie(MovieTitle.Text, Convert.ToInt32(ReleaseDate.Text), Convert.ToInt32(Duration.Text), Rating.Text);
            movie.Id = MovieId;
            DbMovie.UpdateMovie(Connection, movie);
            Response.Redirect("Browse.aspx");
        }
    }
}