using System;
using System.Collections.Generic;
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
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} OUTPUT INSERTED.ID VALUES ('{1}');", TableName, Name);
        }
    }
}
