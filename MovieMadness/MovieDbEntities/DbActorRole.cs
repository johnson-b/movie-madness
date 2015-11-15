using System;
using System.Collections.Generic;
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
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} VALUES ({1}, {2}, '{3}');", TableName, ActorId, MovieId, ActorRole);
        }
    }
}
