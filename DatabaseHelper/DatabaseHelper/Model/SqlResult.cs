using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Model
{
    public class SqlResult
    {
        private System.Data.SqlClient.SqlDataReader reader;

        public SqlResult(System.Data.SqlClient.SqlDataReader reader)
        {
            // TODO: Complete member initialization
            this.reader = reader;
        }
    }
}
