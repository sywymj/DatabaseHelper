using DatabaseHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DatabaseHelper
{
    public class Query
    {
        #region Fields
        /// <summary>
        /// The text of the query.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Contains any eventual parameters.
        /// </summary>
        protected List<Parameter> Parameters { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Sets up an empty query.
        /// </summary>
        public Query()
        {
            Parameters = new List<Parameter>();
        }

        /// <summary>
        /// Sets up a defined query.
        /// </summary>
        /// <param name="m">The text of the query.</param>
        public Query(string m)
            : this()
        {
            Text = m;
        }

        /// <summary>
        /// Sets up a defined query with a specific set of parameters.
        /// </summary>
        /// <param name="m">The text of the query.</param>
        /// <param name="paramlist">A list of parameters.</param>
        public Query(string m, List<Parameter> paramlist) : this(m)
        {
            Parameters = paramlist;
        }
        #endregion

        #region Parametrization
        /// <summary>
        /// Adds an already defined parameter to the query.
        /// </summary>
        /// <param name="p">The parameter to be added.</param>
        public void addParameter(Parameter p)
        {
            Parameters.Add(p);
        }

        /// <summary>
        /// Generates and adds an integer parameter based on column name and value.
        /// </summary>
        /// <param name="column">The name of the parameter.</param>
        /// <param name="value">The value to be set.</param>
        public void addIntParameter(string name, int value)
        {
            Parameters.Add(new Parameter(name, value, DataType.Integer));
        }

        /// <summary>
        /// Generates and adds a text parameter based on column name and value.
        /// </summary>
        /// <param name="column">The name of the parameter.</param>
        /// <param name="value">The value to be set.</param>
        public void addTextParameter(string name, string value)
        {
            Parameters.Add(new Parameter(name, value, DataType.Text));
        }
        #endregion

        #region Utility
        /// <summary>
        /// Determines whether the given query is well-formed. Compares defined parameters with given parameters.
        /// </summary>
        /// <returns>True iff the query is valid; False otherwise.</returns>
        public bool Validate()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Internal_Services
        /// <summary>
        /// Returns an SQL translation of this command:
        /// </summary>
        /// <returns></returns>
        internal SqlCommand getSqlCommand()
        {
            //Create SQL command:
            SqlCommand query = new SqlCommand(Text);

           
            //Apply parameters:
            foreach (Parameter parameter in Parameters)
            {
                System.Data.SqlDbType type = parameter.getParameterType();
                string name = "@" + parameter.getName();
                query.Parameters.Add(new SqlParameter(name, type));
                query.Parameters[name].Value = parameter.getValue();
            }

            //Return the final product:
            return query;
        }

        #endregion
    }
}
