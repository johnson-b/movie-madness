using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbMovieBackdrop : DbEntity
    {
        public static string TableName = "movieBackdrop";
        public long MovieId { get; set; }
        public long BackdropId { get; set; }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertMovieBackdrop", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            cmd.Parameters.AddWithValue("@BackdropId", BackdropId);
            return cmd;
        }
    }
}
