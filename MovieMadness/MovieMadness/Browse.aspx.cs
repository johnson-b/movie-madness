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
    public partial class _Browse : Page
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

        [WebMethod]
        public static void DeleteMovie(string title)
        {
            DbMovie.Delete(GetSqlConnection(), title.Trim());
            //RepeaterItem movie = (sender as LinkButton).NamingContainer as RepeaterItem;
            //Label title = movie.FindControl("title") as Label;
            //DbMovie.Delete(Connection, title.Text);
            //GetAllMovies();
        }

        protected void EditMovie(object sender, EventArgs e)
        {
            RepeaterItem movie = (sender as LinkButton).NamingContainer as RepeaterItem;
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

        protected void MovieDetails(object sender, EventArgs e)
        {
            RepeaterItem movie = (sender as LinkButton).NamingContainer as RepeaterItem;
            Label title = movie.FindControl("title") as Label;
            Response.Redirect(string.Format("MovieDetail.aspx?movie={0}", title.Text));
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bmj29_db"].ConnectionString);
        }
    }
}