using System;
using System.Collections.Generic;
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
            return cmd;
        }

        public static List<DbMovie> GetAllMovies(SqlConnection conn)
        {
            List<DbMovie> movies = new List<DbMovie>();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM {0}", TableName), conn);
            var m = cmd.ExecuteReader();
            while (m.NextResult())
            {
                DbMovie movie = new DbMovie();
                movie.Title = m.GetString(1) as string;
                movie.ReleaseYear = m.GetInt16(2);
                movies.Add(movie);
            }

            Trace.WriteLine("BREAK");
            return movies;

        }
    }
}
