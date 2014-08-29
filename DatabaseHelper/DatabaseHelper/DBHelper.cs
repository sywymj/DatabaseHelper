using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabaseHelper.Modules;
using DatabaseHelper.Exceptions;
using System.Data;

namespace DatabaseHelper
{
    /// <summary>
    /// The class provides a modular interface to a database.
    /// 
    /// Inherently, the following modules are supported:
    /// - Simulation: Test environment with no memory.
    /// - MicrosoftSQLServer: Microsoft SQL Server.
    /// 
    /// </summary>
    public class DBHelper
    {
        #region Fields
        
        /// <summary>
        /// Defines the type of the database.
        /// </summary>
        private DatabaseType databaseType;

        /// <summary>
        /// Defines the currently active module.
        /// </summary>
        private IDatabaseModule module;

        /// <summary>
        /// Defines username for the user who is accessing the database.
        /// </summary>
        internal string UserName;

        /// <summary>
        /// Defines password for the user who is accessing the database.
        /// </summary>
        internal string Password;

        /// <summary>
        /// Defines the name of the database.
        /// </summary>
        internal string DatabaseName;

        /// <summary>
        /// Defines the URL of the server hosting the database.
        /// </summary>
        internal string ServerURL;

        #endregion

        #region Constructors
        /// <summary>
        /// Defines a new Database Helper.
        /// </summary>
        /// <param name="type">The type of the underlying database.</param>
        public DBHelper(DatabaseType type)
        {
            setDBType(type);
        }

        /// <summary>
        /// Defines a new database helper with a user-defined module.
        /// </summary>
        /// <param name="module">The desired module.</param>
        public DBHelper(IDatabaseModule module)
        {
            setDBModule(module);
        }

        /// <summary>
        /// Defines a new Database Helper with a preconstructed module and immediate sets up login information.
        /// </summary>
        /// <param name="type">The type of the underlying database</param>
        /// <param name="username">The id of the user.</param>
        /// <param name="password">The password to the database.</param>
        /// <param name="databasename">The name of the database.</param>
        /// <param name="serverURL">The url of the server hosting the database.</param>
        public DBHelper(DatabaseType type, string username, string password, string databasename, string serverURL)
            : this(type)
        {
            SetLoginInformation(username, password, databasename, serverURL);
        }

        /// <summary>
        /// Defines a new Database Helper with a user-defined module and immediate sets up login information.
        /// </summary>
        /// <param name="type">The type of the underlying database</param>
        /// <param name="username">The id of the user.</param>
        /// <param name="password">The password to the database.</param>
        /// <param name="databasename">The name of the database.</param>
        /// <param name="serverURL">The url of the server hosting the database.</param>
        public DBHelper(IDatabaseModule module, string username, string password, string databasename, string serverURL)
            : this(module)
        {
            SetLoginInformation(username, password, databasename, serverURL);
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
                    module = new MicrosoftSQLServerModule(this);
                    break;
                case DatabaseType.Simulation:
                    module = new SimulationModule();
                    break;
            }
        }

        /// <summary>
        /// Sets the module to a user-defined module.
        /// </summary>
        /// <param name="module">The desired module.</param>
        public void setDBModule(IDatabaseModule module)
        {
            databaseType = DatabaseType.SelfDefined;
            this.module = module;
        }

        /// <summary>
        /// Executes a given query.
        /// </summary>
        /// <param name="query">Query: The query to be executed.</param>
        /// <returns>Object: The result of the query.</returns>
        public SqlResult executeQuery(Query query)
        {
            if (UserName == null) throw new DatabaseException("User undefined. Please use SetLoginInformation to log in.");
            return module.executeQuery(query);
        }

        /// <summary>
        /// Sets username, password, servername, and server url for the database.
        /// </summary>
        /// <param name="username">The id of the user.</param>
        /// <param name="password">The password to the database.</param>
        /// <param name="databasename">The name of the database.</param>
        /// <param name="serverURL">The url of the server hosting the database.</param>
        public void SetLoginInformation(string username, string password, string databasename, string serverURL)
        {
            UserName = username;
            Password = password;
            DatabaseName = databasename;
            ServerURL = serverURL;
        }

        #endregion
    }
}