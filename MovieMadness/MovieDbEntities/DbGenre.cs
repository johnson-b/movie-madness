using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbGenre : DbEntity
    {
        public static string TableName = "genre";
        public long Id { get; set; }
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
    }
}
