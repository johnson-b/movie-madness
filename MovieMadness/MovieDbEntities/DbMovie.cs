using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbMovie : DbEntity
    {
        public static string TableName = "movie";
        public long Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Rating { get; set; }
        public float UserRating { get; set; }
        public int UserRatingCount { get; set; }
        public string Overview { get; set; }
        public string PosterImageUrl { get; set; }
        public DbMovie() { }
        public DbMovie(string title, int releaseYear, int duration, string rating)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Duration = duration;
            Rating = rating;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertMovie", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@ReleaseYear", ReleaseYear);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            cmd.Parameters.AddWithValue("@Rating", Rating);
            cmd.Parameters.AddWithValue("@UserRating", UserRating);
            cmd.Parameters.AddWithValue("@UserRatingCount", UserRatingCount);
            cmd.Parameters.AddWithValue("@Overview", Overview);
            cmd.Parameters.AddWithValue("@PosterImageUrl", PosterImageUrl);
            return cmd;
        }

        public static void UpdateMovie(SqlConnection conn, DbMovie movie)
        {
            conn.Open();
            string update = string.Format("UPDATE {0} SET title='{1}', release_year={2}, duration={3}, rating='{4}' WHERE id={5}",
                TableName, movie.Title, movie.ReleaseYear, movie.Duration, movie.Rating, movie.Id);
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.ExecuteScalar();
            conn.Close();
        }

        public static DataSet GetAllMovies(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getPageOfMovies";
            cmd.Parameters.AddWithValue("@PageStart", 1);
            cmd.Parameters.AddWithValue("@MoviesPerPage", 30);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = cmd;
            conn.Open();
            adapter.Fill(data);
            conn.Close();
            return data;
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet data = new DataSet();
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandText = string.Format("SELECT * FROM {0}", TableName);
            //adapter.SelectCommand = cmd;
            //conn.Open();
            //adapter.Fill(data);
            //conn.Close();
            //return data;

        }

        public static DbMovie GetMovie(SqlConnection conn, string title)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM {0} WHERE title='{1}'", TableName, title), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DbMovie movie = new DbMovie();
            while (reader.Read())
            {
                movie.Id = reader.GetInt32(0);
                movie.Title = reader.GetString(1) as string;
                movie.ReleaseYear = reader.GetInt32(2);
                movie.Duration = reader.GetInt32(3);
                movie.Rating = reader.GetString(4) as string;
            }
            conn.Close();
            return movie;
        }

        public static DataSet SearchMovieTitles(SqlConnection conn, string txt)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0} WHERE title LIKE '%{1}%'", TableName, txt);
            adapter.SelectCommand = cmd;
            conn.Open();
            adapter.Fill(data);
            conn.Close();
            return data;
        }


        public static void Delete(SqlConnection conn, string title)
        {
            conn.Open();
            string delete = string.Format("DELETE FROM {0} WHERE title='{1}'", TableName, title);
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.ExecuteScalar();
            conn.Close();
        }
    }
}
