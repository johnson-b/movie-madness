using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbActor : DbEntity
    {
        public static string TableName = "actor";
        public long Id { get; set; }
        public string Name { get; set; }
        public DbActor(string name)
        {
            Name = name;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertActor", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", Name);
            return cmd;
        }
    }
}
