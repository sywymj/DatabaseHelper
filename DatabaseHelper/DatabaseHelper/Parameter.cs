using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseHelper
{
    public class Parameter
    {
        private object value;
        private string name;
        private ParameterType parameterType;

        #region Constructors
        public Parameter(string name, object value, ParameterType parameterType)
        {
            this.name = name;
            this.value = value;
            this.parameterType = parameterType;
        }
        #endregion

        #region Protected_Services
        internal System.Data.SqlDbType getParameterType()
        {
            switch (parameterType){
                case ParameterType.Integer:
                    return System.Data.SqlDbType.Int;
                case ParameterType.Text:
                    return System.Data.SqlDbType.Text;
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
