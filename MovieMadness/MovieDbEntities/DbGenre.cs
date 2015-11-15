using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbGenre : DbEntity
    {
        public static string TableName = "genre";
        public long Id { get; set; }
        public string Genre { get; set; }
        public DbGenre(string genre)
        {
            Genre = genre;
        }
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} OUTPUT INSERTED.ID VALUES ('{1}');", TableName, Genre);
        }
    }
}
