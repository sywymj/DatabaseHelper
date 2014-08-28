using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabaseHelper.Modules;

namespace DatabaseHelper
{
    /// <summary>
    /// The class provides an interface to a database, along with a simulation framework for testing.
    /// </summary>
    public class DBHelper
    {
        private DatabaseType databaseType;
        private IDatabaseModule module;

        #region Constructors
        /// <summary>
        /// Defines a new Database Helper.
        /// </summary>
        /// <param name="type">DatabaseType: The type of the underlying database.</param>
        public DBHelper(DatabaseType type)
        {
            setDBType(type);
        }
        #endregion

        #region Public_Methods

        /// <summary>
        /// Sets the type of the database. 
        /// </summary>
        /// <param name="type">DatabaseType: The type of the underlying database.</param>
        public void setDBType(DatabaseType type)
        {
            databaseType = type;
            switch (type)
            {
                case DatabaseType.MicrosoftSQLServer:
                    module = new MicrosoftSQLServerModule();
                    break;
                case DatabaseType.Simulation:
                    module = new SimulationModule();
                    break;
            }
        }

        /// <summary>
        /// Executes a given query.
        /// </summary>
        /// <param name="query">Query: The query to be executed.</param>
        /// <returns>Object: The result of the query.</returns>
        public Object executeQuery(Query query)
        {
            module.executeQuery(query);            
            return null;
        }

           

        

        #endregion

        //TODO: Manage this properly:
        #region Private_Utility_Methods

        private string getDB()
        {
            return @"server=localhost;userid=Michael;
            password=Cant0r;database=vinguide";
        }

        private object executeQuery(SqlCommand q)
        {
            throw new NotImplementedException();
        }

        private object simulateQuery(Query query)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private_Connection_Methods


        #endregion
    }
}
