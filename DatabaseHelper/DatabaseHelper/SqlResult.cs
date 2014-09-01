using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatabaseHelper.Exceptions;

namespace DatabaseHelper
{
    public class SqlResult
    {
        #region Fields
        /// <summary>
        /// The table into which the result of the query has been loaded.
        /// </summary>
        public DataTable Table { get; set; }
        
        /// <summary>
        /// The row pointer. Initialized to -1 to simplify use of NextRow.
        /// </summary>
        private int RowPointer = -1;
        #endregion

        #region Constructors
        /// <summary>
        /// Defines a new SqlResult.
        /// </summary>
        /// <param name="reader">A DataReader resulting from a query.</param>
        internal SqlResult(System.Data.SqlClient.SqlDataReader reader)
        {
            Table = new DataTable();
            Table.Load(reader);
        }
        #endregion

        #region Control_Methods

        /// <summary>
        /// Gets the amount of rows in the table.
        /// </summary>
        /// <returns>Row count.</returns>
        public int AmountOfRows()
        {
            return Table.Rows.Count;
        }

        /// <summary>
        /// Gets the amount of rows remaining according to the row parser.
        /// </summary>
        /// <returns>The difference between the amount of rows and the position of the row pointer.</returns>
        public int RemainingRows()
        {
            return AmountOfRows() - RowPointer;
        }

        /// <summary>
        /// Determines whether any rows remain in the table.
        /// </summary>
        /// <returns>True if the end of the table has not been reached.</returns>
        public bool DataRemaining()
        {
            return RemainingRows() > 0;
        }

        /// <summary>
        /// Moves the pointer to the next row.
        /// </summary>
        /// <returns>True if the end of the table has not been reached.</returns>
        public bool NextRow()
        {
            RowPointer++;
            return DataRemaining();
        }
        #endregion

        #region Reader_Methods
        /// <summary>
        /// Reads from column with a specified name and returns the result as a string.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public string ReadString(string name)
        {   
            return Lookup(name).ToString();
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a boolean.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public bool ReadBoolean(string name)
        {
            return System.Convert.ToBoolean(Lookup(name));
        }
        
        /// <summary>
        /// Reads from column with a specified name and returns the result as a character.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public char ReadChar(string name)
        {
            return System.Convert.ToChar(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a 16-bit integer.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public short ReadInt16(string name)
        {
            return System.Convert.ToInt16(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a 32-bit integer.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public int ReadInt32(string name)
        {
            return System.Convert.ToInt32(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a 64-bit integer.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public long ReadInt64(string name)
        {
            return System.Convert.ToInt64(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a decimal.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public decimal ReadDecimal(string name)
        {
            return System.Convert.ToDecimal(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a single.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public Single ReadSingle(string name)
        {
            return System.Convert.ToSingle(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a double.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public double ReadDouble(string name)
        {
            return System.Convert.ToDouble(Lookup(name));
        }

        /// <summary>
        /// Reads from column with a specified name and returns the result as a DateTime.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The contents of the cell.</returns>
        public DateTime ReadDateTime(string name)
        {
            return System.Convert.ToDateTime(Lookup(name));
        }

        /// <summary>
        /// Performs a lookup in the associated datatable, checking for errors meanwhile.
        /// </summary>
        /// <param name="columnName">The name of the column to be retrieved.</param>
        /// <returns>The contents of the cell.</returns>
        public object Lookup(string name)
        {
            if (RowPointer < 0)
            {
                throw new LookupException("First row not initialized.");
            }
            else if (!DataRemaining())
            {
                throw new LookupException("No rows remain in the result.");
            }
            else if (!Table.Columns.Contains(name))
            {
                throw new LookupException("The table contains no column with the name '" + name + "'.");
            }

            return Table.Rows[RowPointer][name];
        }
        #endregion

    }
}
