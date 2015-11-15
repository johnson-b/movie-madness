using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public class DbMovie : DbEntity
    {
        public static string TableName = "movie";
        public long Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Rating { get; set; }
        public DbMovie(string title, int releaseYear, int duration, string rating)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Duration = duration;
            Rating = rating;
        }
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} OUTPUT INSERTED.ID VALUES ('{1}', {2}, {3}, '{4}');", TableName, Title, ReleaseYear, Duration, Rating);
        }
    }
}
