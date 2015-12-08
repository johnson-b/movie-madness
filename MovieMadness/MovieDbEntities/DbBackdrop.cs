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
    public class DbBackdrop : DbEntity
    {
        public static string TableName = "backdrop";
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string BackdropUrl { get; set; }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertBackdropImage", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@BackdropUrl", BackdropUrl);
            return cmd;
        }

        public static List<DbBackdrop> GetMovieBackdrop(SqlConnection conn, long movieId)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getMovieBackdrop";
            cmd.Parameters.AddWithValue("@MovieId", movieId);
            cmd.CommandType = CommandType.StoredProcedure;
            data.Load(cmd.ExecuteReader());
            conn.Close();
            List<DbBackdrop> backdrops = new List<DbBackdrop>();
            foreach (var result in data.Select())
            {
                DbBackdrop backdrop = new DbBackdrop();
                backdrop.BackdropUrl = result["backdropUrl"] as string;
                backdrop.Id = (int)result["id"];
                backdrops.Add(backdrop);
            }

            return backdrops;
        }
    }
}
