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
        /// <returns>The corresponding SqlDbType</returns>
        internal System.Data.SqlDbType getParameterType()
        {
            switch (parameterType){
                case DataType.Int32:
                    return System.Data.SqlDbType.Int;
                case DataType.Text:
                    return System.Data.SqlDbType.Text;
                case DataType.DateTime:
                    return System.Data.SqlDbType.DateTime;
                case DataType.VarChar:
                    return System.Data.SqlDbType.VarChar;
                case DataType.FixedChar:
                    return System.Data.SqlDbType.Char;
                case DataType.Boolean:
                    return System.Data.SqlDbType.Bit;
                case DataType.Byte:
                    return System.Data.SqlDbType.TinyInt;
                case DataType.Int64:
                    return System.Data.SqlDbType.BigInt;
                case DataType.FixedBinary:
                    return System.Data.SqlDbType.Binary;
                case DataType.Date:
                    return System.Data.SqlDbType.Date;
                case DataType.DateTime2:
                    return System.Data.SqlDbType.DateTime2;
                case DataType.DateTimeOffSet:
                    return System.Data.SqlDbType.DateTimeOffset;
                case DataType.Decimal:
                    return System.Data.SqlDbType.Decimal;
                case DataType.Float:
                    return System.Data.SqlDbType.Float;
                case DataType.Image:
                    return System.Data.SqlDbType.Image;
                case DataType.Money:
                    return System.Data.SqlDbType.Money;
                case DataType.NFixedChar:
                    return System.Data.SqlDbType.NChar;
                case DataType.NText:
                    return System.Data.SqlDbType.NText;
                case DataType.NVarChar:
                    return System.Data.SqlDbType.NVarChar;
                case DataType.Real:
                    return System.Data.SqlDbType.Real;
                case DataType.SmallDateTime:
                    return System.Data.SqlDbType.SmallDateTime;
                case DataType.Int16:
                    return System.Data.SqlDbType.SmallInt;
                case DataType.SmallMoney:
                    return System.Data.SqlDbType.SmallMoney;
                case DataType.Structured:
                    return System.Data.SqlDbType.Structured;
                case DataType.Time:
                    return System.Data.SqlDbType.Time;
                case DataType.Timestamp:
                    return System.Data.SqlDbType.Timestamp;
                case DataType.Udt:
                    return System.Data.SqlDbType.Udt;
                case DataType.UniqueIdentifier:
                    return System.Data.SqlDbType.UniqueIdentifier;
                case DataType.VarBinary:
                    return System.Data.SqlDbType.VarBinary;
                case DataType.Variant:
                    return System.Data.SqlDbType.Variant;
                case DataType.XML: 
                    return System.Data.SqlDbType.Xml;
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
