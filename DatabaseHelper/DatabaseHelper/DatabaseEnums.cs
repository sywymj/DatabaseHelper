namespace DatabaseHelper
{
    /// <summary>
    /// Represents the various types of data which the database can contain.
    /// </summary>
    public enum DataType
    {
        Integer = 0,
        Text = 1,
        DateTime = 2

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