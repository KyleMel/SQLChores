using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLChores
{
    public class DBaccessfile
    {
        public string access { get; }
        public DBaccessfile()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "Kyle";
            builder.Password = "Temp123!";
            builder.InitialCatalog = "master";
            access = builder.ConnectionString;
        }
    }
}
