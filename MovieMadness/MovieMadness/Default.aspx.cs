using MovieDbEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieMadness
{
    public partial class _Default : Page
    {
        SqlConnection connection { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
        }

        protected void GetAllMovies(object sender, EventArgs e)
        {
            connection.Open();
            List<DbMovie> movies = DbMovie.GetAllMovies(connection);
            foreach (DbMovie movie in movies)
            {
                
            }
            connection.Close();
        }
    }
}