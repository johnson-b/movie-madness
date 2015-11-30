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
        public string Movie { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
            Movie = Request.QueryString["movie"];
            DbMovie movie = DbMovie.GetMovie(Connection, Movie);
            MovieTitle.Text = movie.Title;
            ReleaseDate.Text = movie.ReleaseYear.ToString();
            Duration.Text = movie.Duration.ToString();
            Rating.Text = movie.Rating;            
        }
    }
}