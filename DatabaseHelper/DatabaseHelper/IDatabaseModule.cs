using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public interface IDatabaseModule
    {
        object executeQuery(Query query);
    }
}
