﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbEntities
{
    public abstract class DbEntity
    {
        public abstract SqlCommand Insert(SqlConnection conn);
    }
}
