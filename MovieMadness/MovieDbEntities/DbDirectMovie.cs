using System;
using System.Collections.Generic;
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
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} VALUES ({1}, {2});", TableName, DirectorId, MovieId);
        }
    }
}
