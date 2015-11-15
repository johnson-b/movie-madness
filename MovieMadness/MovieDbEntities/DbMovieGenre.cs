using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbMovieGenre : DbEntity
    {
        public static string TableName = "movieGenre";
        public long MovieId { get; set; }
        public long GenreId { get; set; }
        public DbMovieGenre(long movieId, long genreId)
        {
            MovieId = movieId;
            GenreId = genreId;
        }
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} VALUES ({1}, {2});", TableName, MovieId, GenreId);
        }
    }
}
