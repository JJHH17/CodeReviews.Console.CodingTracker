using System.Configuration;

var dbConnection = ConfigurationManager.AppSettings.Get(0);

Console.WriteLine(dbConnection);