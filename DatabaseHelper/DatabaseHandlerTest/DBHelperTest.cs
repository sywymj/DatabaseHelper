using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelper;
using System.Collections.Generic;

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
            string name = "admin";
            string password = "password";
            string serverurl = "localhost";
            string databasename = "test_helper";
            dbHelper.SetLoginInformation(name, password, databasename, serverurl);
        }
        #endregion
    }
}
