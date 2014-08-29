using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelper;
using System.Collections.Generic;
using System.Data;

namespace DatabaseHandlerTest
{
    [TestClass]
    public class DBHelperTest
    {
        [TestMethod]
        public void TestCreateDBHelper()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            dbHelper = new DBHelper(DatabaseType.Simulation);
        }

        #region Microsoft_SQL_Server
        [TestMethod]
        public void TestConnectToDatabase()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            SetupTestDatabaseForMSSQL(dbHelper);

            Query q = new Query("SELECT DB_NAME() AS Name");
            SqlResult result = dbHelper.executeQuery(q);

            Assert.IsNotNull(result);

            result.NextRow();

            var strResult = result.ReadString("Name");

            Assert.AreEqual("testing", strResult);
        }

        [TestMethod]
        public void TestCreateRetrieveAndDeleteRow()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            SetupTestDatabaseForMSSQL(dbHelper);

            Query q = new Query("INSERT INTO test_table (ID, Description) "+
                                "VALUES (1, 'ettal')");
            SqlResult result = dbHelper.executeQuery(q);
            Assert.IsNotNull(result);


            Query q2 = new Query("SELECT Description "+ 
                                    "FROM test_table "+
                                    "WHERE ID=1");
            result = dbHelper.executeQuery(q2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DataRemaining());

            result.NextRow();
            var strResult = result.ReadString("Description");
            Assert.AreEqual("ettal", strResult);

            Query q3 = new Query("DELETE FROM test_table  " +
                                "WHERE ID=1");
            result = dbHelper.executeQuery(q3);
            Assert.IsNotNull(result);

            result = dbHelper.executeQuery(q2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.AmountOfRows() == 0);
        }

        [TestMethod]
        public void TestIntParametrization()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            SetupTestDatabaseForMSSQL(dbHelper);

            Query q = new Query("INSERT INTO test_table (ID, Description) " +
                                "VALUES (@id, 'ettal')");
            q.addIntParameter("id", 1);
            SqlResult result = dbHelper.executeQuery(q);
            Assert.IsNotNull(result);

            Query q2 = new Query("SELECT Description " +
                                    "FROM test_table " +
                                    "WHERE ID=@id");
            q2.addIntParameter("id", 1);
            result = dbHelper.executeQuery(q2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DataRemaining());

            result.NextRow();
            var strResult = result.ReadString("Description");
            Assert.AreEqual("ettal", strResult);

            Query q3 = new Query("DELETE FROM test_table  " +
                                "WHERE ID=1");
            result = dbHelper.executeQuery(q3);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStringParametrization()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            SetupTestDatabaseForMSSQL(dbHelper);

            Query q = new Query("INSERT INTO test_table (ID, Description) " +
                                "VALUES (1, 'ettal')");
            SqlResult result = dbHelper.executeQuery(q);
            Assert.IsNotNull(result);

            Query q2 = new Query("SELECT ID " +
                                    "FROM test_table " +
                                    "WHERE Description LIKE @description");
            q2.addTextParameter("description", "ettal");
            result = dbHelper.executeQuery(q2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DataRemaining());

            result.NextRow();
            var intResult = result.ReadInt("ID");
            Assert.AreEqual(1, intResult);

            Query q3 = new Query("DELETE FROM test_table  " +
                                "WHERE ID=1");
            result = dbHelper.executeQuery(q3);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestDateTime()
        {
            DBHelper dbHelper = new DBHelper(DatabaseType.MicrosoftSQLServer);
            SetupTestDatabaseForMSSQL(dbHelper);

            Query q = new Query("INSERT INTO test_table (ID, DateCreated) " +
                                "VALUES (1, @dateCreated)");
            q.addDateTimeParameter("datecreated", DateTime.Today.Date);
            SqlResult result = dbHelper.executeQuery(q);
            Assert.IsNotNull(result);

            Query q2 = new Query("SELECT DateCreated " +
                                    "FROM test_table " +
                                    "WHERE ID=1");
            result = dbHelper.executeQuery(q2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DataRemaining());

            result.NextRow();
            Assert.AreEqual(DateTime.Today.Date, result.ReadDateTime("DateCreated"));

            Query q3 = new Query("DELETE FROM test_table  " +
                                "WHERE ID=1");
            result = dbHelper.executeQuery(q3);
            Assert.IsNotNull(result);
        }

        private static void SetupTestDatabaseForMSSQL(DBHelper dbHelper)
        {
            string name = "michael";
            string password = "Cant0r";
            string serverurl = "localhost\\SQLEXPRESS";
            string databasename = "testing";
            dbHelper.SetLoginInformation(name, password, databasename, serverurl);
        }
        #endregion
    }
}
