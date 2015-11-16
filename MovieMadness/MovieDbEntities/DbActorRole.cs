using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbActorRole : DbEntity
    {
        public static string TableName = "actorRole";
        public long ActorId { get; set; }
        public long MovieId { get; set; }
        public string ActorRole { get; set; }
        public DbActorRole(long actorId, long movieId, string actorRole)
        {
            ActorId = actorId;
            MovieId = movieId;
            ActorRole = actorRole;
        }                                      
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertActorRole", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ActorId", ActorId);
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            cmd.Parameters.AddWithValue("@ActorRole", ActorRole);
            return cmd;
        }
    }
}
