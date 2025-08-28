using Dapper;
using System;
using System.IO;
using System.Configuration;
using System.Data.SQLite;

namespace CodingTracker.JJHH17
{
    public class Database
    {
        // These values are read from App.config
        private static readonly string dbPath = ConfigurationManager.AppSettings["databasePath"];
        private static readonly string tableName = ConfigurationManager.AppSettings["tableName"];
        private static readonly string connectionString = $"Data Source={dbPath};";

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

            CreateTable();
        }

        private static void CreateTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string tableCreation = @"CREATE TABLE IF NOT EXISTS CodeTracker (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    StartTime TEXT NOT NULL,
                    EndTime TEXT NOT NULL,
                    Duration TEXT);";

                connection.Execute(tableCreation);
                Console.WriteLine("Table created successfully.");
            }
        }

        public static long AddEntry(string startTime, string endTime, string duration)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sql = $"INSERT INTO {tableName} (startTime, endTime, duration) VALUES (@StartTime, @EndTime, @Duration);" +
                    $"SELECT last_insert_rowid();";

                var newEntry = new CodingSession(startTime, endTime, duration);

                long newId = connection.ExecuteScalar<long>(sql, new
                {
                    StartTime = newEntry.StartTime, EndTime = newEntry.EndTime, Duration = newEntry.Duration });

                return newId;
            }
        }

        public static List<CodingSession> ReturnAllEntries()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sql = $"SELECT * FROM {tableName};";
                var entries = connection.Query<CodingSession>(sql).ToList();
                return entries;
            }
        }

        public static void DeleteAllEntries()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sql = $"DELETE FROM {tableName};";
                var affectedRows = connection.Execute(sql);
            }
        }

        public static void DeleteEntryById(long id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sql = $"DELETE FROM {tableName} WHERE Id = @Id;";
                var affectedRows = connection.Execute(sql, new { Id = id });
            }
        }
    }
}