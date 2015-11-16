using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbDirector : DbEntity
    {
        public static string TableName = "director";
        public long Id { get; set; }
        public string Name { get; set; }
        public DbDirector(string name)
        {
            Name = name;
        }
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertDirector", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", Name);
            return cmd;
        }
    }
}
