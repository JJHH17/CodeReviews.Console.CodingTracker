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
        private static readonly string tableName = ConfigurationManager.AppSettings["tableName"];

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

            CreateTable(); // table is created after database is created
        }

        // Creates a table in the database (pulled from config file)
        private static void CreateTable()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Creating table via Dapper
                string tableCreation = @"CREATE TABLE IF NOT EXISTS CodeTracker (
                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    StartTime TEXT NOT NULL,
                    EndTime TEXT NOT NULL,
                    Duration INTEGER);";

                connection.Execute(tableCreation);
                Console.WriteLine("Table created successfully.");
            }
        }
    }
}
