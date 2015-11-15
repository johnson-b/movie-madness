using System;
using System.Collections.Generic;
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
        public override string Insert()
        {
            return string.Format("INSERT INTO {0} OUTPUT INSERTED.ID VALUES ('{1}');", TableName, Name);
        }

        public string Update()
        {
            return string.Format("UPDATE {0} SET name='{1}' OUTPUT INSERTED.ID WHERE name='{1}';", TableName, Name);
        }
    }
}
