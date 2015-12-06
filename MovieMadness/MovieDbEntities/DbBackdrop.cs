using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbBackdrop : DbEntity
    {
        public static string TableName = "backdrop";
        public long Id { get; set; }
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
    }
}
