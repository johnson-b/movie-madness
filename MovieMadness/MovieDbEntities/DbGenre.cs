using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbGenre : DbEntity
    {
        public static string TableName = "genre";
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string Genre { get; set; }
        public DbGenre(string genre)
        {
            Genre = genre;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertGenre", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Genre", Genre);
            return cmd;
        }

        public static List<DbGenre> GetMovieGenres(SqlConnection conn, long id)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getMovieGenres";
            cmd.Parameters.AddWithValue("@MovieId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            data.Load(cmd.ExecuteReader());
            conn.Close();
            List<DbGenre> genres = new List<DbGenre>();
            foreach(var result in data.Select())
            {
                DbGenre genre = new DbGenre(result["genre"] as string);
                genre.Id = (int)result["id"];
                genres.Add(genre);
            }
            return genres;
        }
    }
}
