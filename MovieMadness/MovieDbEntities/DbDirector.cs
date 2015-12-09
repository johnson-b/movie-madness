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
    public class DbDirector : DbEntity
    {
        public static string TableName = "director";
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string ImageUrl { get; set; }
        public DbDirector() { }
        public DbDirector(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertDirector", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
            return cmd;
        }

        public static DbDirector GetMovieDirector(SqlConnection conn, long id)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getMovieDirector";
            cmd.Parameters.AddWithValue("@MovieId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            data.Load(cmd.ExecuteReader());
            conn.Close();
            DbDirector director = new DbDirector();
            var res = data.Select().FirstOrDefault();
            director.Id = (int)res["id"];
            director.Name = res["name"] as string;
            director.ImageUrl = res["imageUrl"] as string;
            return director;
        }
    }
}
