using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DatabaseHelper.Modules
{
    internal class MicrosoftSQLServerModule : IDatabaseModule
    {
        private DBHelper DbHelper;

        #region Constructors
        /// <summary>
        /// Defines a new MicrosoftSqlServerModule.
        /// </summary>
        /// <param name="dbHelper">The parent.</param>
        public MicrosoftSQLServerModule(DBHelper dbHelper)
        {
            DbHelper = dbHelper;
        }
        #endregion

        #region Inherited_Methods
        /// <summary>
        /// Inherited method. Executes an SQL Query.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <returns>The result on a DataTable format.</returns>
        public SqlResult executeQuery(Query query){
            //Open a connection:
            SqlConnection con = new SqlConnection("user id="+DbHelper.UserName+";" +
                                       "password="+DbHelper.Password+
                                        ";server="+DbHelper.ServerURL+";" +
                                       "Trusted_Connection=yes;" +
                                       "database="+DbHelper.DatabaseName+"; " +
                                       "connection timeout=30");
            con.Open();

            //Convert the query:
            SqlCommand cmd = query.getSqlCommand();
            cmd.Connection = con;

            //Execute the query:
            SqlDataReader reader = cmd.ExecuteReader();
            
            //Build the result:
            SqlResult result = new SqlResult(reader);

            //Close the connection:
            con.Close();

            //Return the result:
            return result;
        }
        #endregion
    }
}
