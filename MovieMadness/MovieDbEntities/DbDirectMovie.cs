using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbDirectMovie : DbEntity
    {
        public static string TableName = "directMovie";
        public long DirectorId { get; set; }
        public long MovieId { get; set; }
        public DbDirectMovie(long directorId, long movieId)
        {
            DirectorId = directorId;
            MovieId = movieId;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertDirectMovie", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            cmd.Parameters.AddWithValue("@DirectorId", DirectorId);
            return cmd;
        }
    }
}
