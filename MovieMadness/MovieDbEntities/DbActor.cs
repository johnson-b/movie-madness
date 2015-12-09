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
    public class DbActor : DbEntity
    {
        public static string TableName = "actor";
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string ImageUrl { get; set; }
        public DbActor() { }
        public DbActor(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertActor", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
            return cmd;
        }

        public static List<DbActor> GetMovieActors(SqlConnection conn, long id)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getMovieActors";
            cmd.Parameters.AddWithValue("@MovieId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            data.Load(cmd.ExecuteReader());
            conn.Close();
            List<DbActor> actors = new List<DbActor>();
            foreach (var result in data.Select())
            {
                DbActor actor = new DbActor();
                actor.Id = (int)result["id"];
                actor.Name = result["name"] as string;
                actor.ImageUrl = result["imageUrl"] as string;
                actors.Add(actor);
            }

            return actors;
        }
    }
}
