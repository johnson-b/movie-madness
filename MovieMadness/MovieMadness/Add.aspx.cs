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
    public partial class Add : System.Web.UI.Page
    {
        SqlConnection Connection { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
        }

        protected void InsertMovie(object sender, EventArgs e)
        {
            Connection.Open();
            DbMovie movie = new DbMovie(MovieTitle.Text, Convert.ToInt32(ReleaseDate.Text), Convert.ToInt32(Duration.Text), Rating.Text);
            SqlCommand cmd = movie.Insert(Connection);
            cmd.ExecuteScalar();
            Connection.Close();
            Response.Redirect("Default.aspx");
        }
    }
}