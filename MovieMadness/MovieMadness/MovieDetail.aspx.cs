using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieMadness
{
    public partial class MovieDetail : System.Web.UI.Page
    {
        SqlConnection Connection { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string movie = Request.QueryString["movie"];
            // get backdrop
            // get posterImageurl
            // get overview
            // get director
            // get actors?
            // get genre
            // get rating
            // get user rating
            // get count of user ratings
            // get duration
            // get release_year
        }
    }
}