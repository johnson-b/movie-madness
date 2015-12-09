using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MovieDbEntities
{
    public class DbMovie : DbEntity
    {
        public static string TableName = "movie";
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public int ReleaseYear { get; set; }
        [JsonProperty]
        public int Duration { get; set; }
        [JsonProperty]
        public string Rating { get; set; }
        [JsonProperty]
        public float UserRating { get; set; }
        [JsonProperty]
        public int UserRatingCount { get; set; }
        [JsonProperty]
        public string Overview { get; set; }
        [JsonProperty]
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
            movie.Title = movie.Title.Replace("'", "''");
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
            cmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = cmd;
            conn.Open();
            adapter.Fill(data);
            conn.Close();
            return data;
        }

        public static List<DbMovie> GetSimilarMovies(SqlConnection conn, long genreId)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("getSimilarMovies", conn);
            cmd.Parameters.AddWithValue("@GenreId", genreId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<DbMovie> movies = new List<DbMovie>();
            while (reader.Read())
            {
                DbMovie movie = new DbMovie();
                movie.Id = reader.GetInt32(1);
                movie.Title = reader.GetString(2) as string;
                movie.ReleaseYear = reader.GetInt32(3);
                movie.Duration = reader.GetInt32(4);
                movie.Rating = reader.GetString(5) as string;
                movie.UserRating = (float)reader.GetDouble(6);
                movie.UserRatingCount = reader.GetInt32(7);
                movie.Overview = reader.GetString(8) as string;
                movie.PosterImageUrl = reader.GetString(9) as string;
                if (!movies.Contains(movie))
                    movies.Add(movie);                
            }
            conn.Close();
            return movies;
        }

        public static DbMovie GetMovie(SqlConnection conn, string title)
        {
            conn.Open();
            title = title.Replace("'", "''");
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM {0} WHERE title='{1}'", TableName, Uri.UnescapeDataString(title)), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DbMovie movie = new DbMovie();
            while (reader.Read())
            {
                movie.Id = reader.GetInt32(0);
                movie.Title = reader.GetString(1) as string;
                movie.ReleaseYear = reader.GetInt32(2);
                movie.Duration = reader.GetInt32(3);
                movie.Rating = reader.GetString(4) as string;
                movie.UserRating = (float)reader.GetDouble(5);
                movie.UserRatingCount = reader.GetInt32(6);
                movie.Overview = reader.GetString(7) as string;
                movie.PosterImageUrl = reader.GetString(8) as string;
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
            title = title.Replace("'", "''");
            string delete = string.Format("DELETE FROM {0} WHERE title='{1}'", TableName, title);
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.ExecuteScalar();
            conn.Close();
        }
    }
}
