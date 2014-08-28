using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Exceptions
{
    class DatabaseException : Exception
    {

        public DatabaseException(string p):base(p)
        {
            
        }
    }
}
