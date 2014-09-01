namespace DatabaseHelper
{
    /// <summary>
    /// Represents the various types of data which the database can contain.
    /// </summary>
    public enum DataType
    {
        //Boolean type:
        /// <summary>
        /// An unsigned numeric value that can be 0, 1, or null.
        /// </summary>
        Boolean,

        //Numeric types:
        /// <summary>
        /// An 8-bit unsigned integer.
        /// </summary>
        Byte,
        /// <summary>
        /// A 16-bit signed integer.
        /// </summary>
        Int16,
        /// <summary>
        /// A 32-bit signed integer.
        /// </summary>
        Int32,
        /// <summary>
        /// A 64-bit signed integer.
        /// </summary>
        Int64,

        //Floating point types:
        /// <summary>
        /// A fixed precision and scale numeric value between -1.00E+38 +1 and 1.00E+38 -1.
        /// </summary>
        Decimal,
        /// <summary>
        /// A floating point number within the range of -3.40E+38 through 3.40E+38.
        /// </summary>
        Real,
        /// <summary>
        /// A floating point number within the range of -1.79E+308 through 1.79E+308.
        /// </summary>
        Float,

        //Text types:
        /// <summary>
        /// A fixed-length stream of non-Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        FixedChar,
        /// <summary>
        /// A variable-length stream of non-Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        VarChar,
        /// <summary>
        /// A fixed-length stream of Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        NFixedChar,
        /// <summary>
        /// A variable-length stream of Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        NVarChar,

        //Time types:
        /// <summary>
        /// Date data ranging in value from January 1,1 AD through December 31, 9999 AD.
        /// </summary>
        Date,
        /// <summary>
        /// Date and time data ranging in value from January 1, 1753 to December 31, 9999 to an accuracy of 3.33 milliseconds.
        /// </summary>
        DateTime,
        /// <summary>
        /// Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        DateTime2,
        /// <summary>
        /// Date and time data with time zone awareness. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range is -14:00 through +14:00.
        /// </summary>
        DateTimeOffSet,
        /// <summary>
        /// Date and time data ranging in value from January 1, 1900 to June 6, 2079 to an accuracy of one minute.
        /// </summary>
        SmallDateTime,
        /// <summary>
        /// Time data based on a 24-hour clock. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Corresponds to a SQL Server time value.
        /// </summary>
        Time,

        //Currency types:
        /// <summary>
        /// A currency value ranging from -214,748.3648 to +214,748.3647 with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        SmallMoney,
        /// <summary>
        /// A currency value ranging from -2 63 (or -9,223,372,036,854,775,808) to 2 63 -1 (or +9,223,372,036,854,775,807) with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        Money,

        //Array types:
        /// <summary>
        /// A fixed-length stream of binary data ranging between 1 and 8,000 bytes.
        /// </summary>
        FixedBinary,
        /// <summary>
        /// A variable-length stream of binary data ranging between 1 and 8,000 bytes.
        /// </summary>
        VarBinary,

        //Auxilliary types:
        /// <summary>
        /// A special data type for specifying structured data contained in table-valued parameters.
        /// </summary>
        Structured,
        /// <summary>
        ///  Automatically generated binary numbers, which are guaranteed to be unique within a database. timestamp is used typically as a mechanism for version-stamping table rows. The storage size is 8 bytes.
        /// </summary>
        Timestamp,
        /// <summary>
        /// A SQL Server user-defined type (UDT).
        /// </summary>
        Udt,
        /// <summary>
        /// A globally unique identifier (or GUID).
        /// </summary>
        UniqueIdentifier,
        /// <summary>
        /// A special data type that can contain numeric, string, binary, or date data as well as the SQL Server values Empty and Null, which is assumed if no other type is declared.
        /// </summary>
        Variant,
        /// <summary>
        /// An XML value.
        /// </summary>
        XML,


        //Deprecated types:

        /// <summary>
        /// Will be deprecated soon. Do not use except for backward compatibility.
        /// </summary>
        Text,
        /// <summary>
        /// Will be deprecated soon. Do not use except for backward compatibility.
        /// </summary>
        NText,
        /// <summary>
        /// Will be deprecated soon. Do not use except for backward compatibility.
        /// </summary>
        Image

        //To add a datatype: Include it here, in Parameter.cs, in Query.cs, and in SqlResult.cs.
    }

    /// <summary>
    /// Represents the various module available for the database. SelfDefined is automatically used if a non-standard module is loaded through the specialized constructor.
    /// </summary>
    public enum DatabaseType
    {
        Simulation = 0,
        MicrosoftSQLServer = 1,
        SelfDefined = 2
    }
}