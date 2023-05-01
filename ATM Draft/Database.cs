using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace ATM_Draft
{
    class Database
    {
        public SQLiteConnection myConnection;
        public string strConnection = "Data Source = database.sqlite3";

        public Database()
        {
            if (!File.Exists("./database.sqlite3"))
            {
                myConnection = new SQLiteConnection(strConnection);
                SQLiteConnection.CreateFile("database.sqlite3");
            }
        }
    }
}
