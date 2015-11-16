using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public override SqlCommand Insert(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("insertMovieGenre", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@MovieId", MovieId);
            cmd.Parameters.AddWithValue("@GenreId", GenreId);
            return cmd;
        }
    }
}
