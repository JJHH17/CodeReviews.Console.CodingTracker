using System.Configuration;
using Spectre.Console;

// Pulls from App.config
// var dbConnection = ConfigurationManager.AppSettings.Get(0);
// Console.WriteLine(dbConnection);

public static class Program
{
    public static void Main()
    {
        AnsiConsole.MarkupLine("[yellow]Welcome to Code Tracker![/]");
    }
}