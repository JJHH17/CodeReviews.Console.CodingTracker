using Dapper;
using System;
using System.IO;
using System.Configuration;
using System.Data.SQLite;

// TODO - Add Dapper installation to README
// TODO - Add SQLITE installation to README
namespace CodingTracker.JJHH17
{
    public class Database
    {
        // Imports database from config file
        private static readonly string dbPath = ConfigurationManager.AppSettings["databasePath"];

        public static void CreateDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine("Database created successfully.");
            } else
            {
                Console.WriteLine("Database already exists.");
            }
        }
    }

}
