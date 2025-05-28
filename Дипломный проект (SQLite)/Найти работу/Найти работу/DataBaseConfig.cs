using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Найти_работу
{
    public static class DataBaseConfig
    {
        public static string ConnectionString { get; private set; }

        static DataBaseConfig()
        {
            string databasePath = "НайтиРаботу.db";
            ConnectionString = $@"Data Source={databasePath};Version=3;";

            EnableWALMode();
        }

        private static void EnableWALMode()
        {
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString))
            {
                con.Open();
                using (SQLiteCommand com = new SQLiteCommand("PRAGMA journal_mode=WAL;", con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }
    }

}
