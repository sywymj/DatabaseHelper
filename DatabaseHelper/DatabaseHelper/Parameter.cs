using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseHelper
{
    public class Parameter
    {
        #region Fields
        /// <summary>
        /// The parameter name used in the query:
        /// </summary>
        private string name;

        /// <summary>
        /// The value to which the parameter should be set:
        /// </summary>
        private object value;
        
        /// <summary>
        /// The type of the parameter. Supported types can be seen in DatabaseHelper.DatabaseEnums.ParameterType
        /// </summary>
        private DataType parameterType;
        #endregion

        #region Constructors
        /// <summary>
        /// Defines a new parameter.
        /// </summary>
        /// <param name="name">The name given in the query.</param>
        /// <param name="value">The value to which the parameter should be set.</param>
        /// <param name="parameterType">The type of the parameter.</param>
        public Parameter(string name, object value, DataType parameterType)
        {
            this.name = name;
            this.value = value;
            this.parameterType = parameterType;
        }
        #endregion

        #region Internal_Services
        /// <summary>
        /// Service method for MicrosoftSQL that defines type:
        /// </summary>
        /// <returns></returns>
        internal System.Data.SqlDbType getParameterType()
        {
            switch (parameterType){
                case DataType.Integer:
                    return System.Data.SqlDbType.Int;
                case DataType.Text:
                    return System.Data.SqlDbType.Text;
                case DataType.DateTime:
                    return System.Data.SqlDbType.DateTime;
            }
            
            throw new Exception("Wrongful parametrization.");
        }

        internal string getName()
        {
            return name;
        }

        internal object getValue()
        {
            return value;
        }
        #endregion
    }
}
