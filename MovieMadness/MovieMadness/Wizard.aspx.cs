using MovieDbEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieMadness
{
    public partial class Wizard : System.Web.UI.Page
    {
        SqlConnection Connection { get; set; }
        public static List<DbMovie> Favorites { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
            if (!IsPostBack)
                Favorites = new List<DbMovie>();
        }

        protected void SearchMovie(object sender, EventArgs e)
        {
            DataSet data = DbMovie.SearchMovieTitles(Connection, TxtSearch.Text);
            Movies.DataSource = data;
            Movies.DataBind();
        }

        [WebMethod]
        public static void AddMovieToFavorites(string title)
        {
            if (Favorites.Count != 3)
            {
                Favorites.Add(DbMovie.GetMovie(GetSqlConnection(), title));
            }
            else
            {

            }
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
        }
    }
}