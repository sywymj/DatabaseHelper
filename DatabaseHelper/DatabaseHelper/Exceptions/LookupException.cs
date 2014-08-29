using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Exceptions
{
    class LookupException: Exception
    {
        public LookupException(string p)
            : base(p)
        {

        }
    }
}
