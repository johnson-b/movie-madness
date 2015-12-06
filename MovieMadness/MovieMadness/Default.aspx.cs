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
    public partial class _Default : Page
    {
        SqlConnection Connection { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
            GetAllMovies();
        }

        protected void GetAllMovies()
        {
            DataSet data = DbMovie.GetAllMovies(Connection);
            Movies.DataSource = data;
            Movies.DataBind();
        }

        protected void DeleteMovie(object sender, EventArgs e)
        {
            RepeaterItem movie = (sender as LinkButton).NamingContainer as RepeaterItem;
            Label title = movie.FindControl("title") as Label;
            DbMovie.Delete(Connection, title.Text);
            GetAllMovies();
        }

        protected void EditMovie(object sender, EventArgs e)
        {
            RepeaterItem movie = (sender as Button).NamingContainer as RepeaterItem;
            Label title = movie.FindControl("title") as Label;
            Response.Redirect(string.Format("Edit.aspx?movie={0}", title.Text));
        }

        protected void SearchMovie(object sender, EventArgs e)
        {
            DataSet data = DbMovie.SearchMovieTitles(Connection, TxtSearch.Text);
            Movies.DataSource = data;
            Movies.DataBind();
        }

        protected void InsertMovie(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx");
        }
    }
}