using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    /// <summary>
    /// The interface corresponding to the modules. Any user-designed module must inherit from this interface.
    /// </summary>
    public interface IDatabaseModule
    {
        /// <summary>
        /// The result of an SQL Query when using the module.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <returns>The result of the query.</returns>
        SqlResult executeQuery(Query query);
    }
}
