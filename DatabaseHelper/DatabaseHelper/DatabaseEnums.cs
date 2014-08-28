namespace DatabaseHelper
{
    /// <summary>
    /// Represents the various types of data which the database can contain.
    /// </summary>
    public enum DataType
    {
        Integer = 0,
        Text = 1
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