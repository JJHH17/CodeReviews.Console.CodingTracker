using System.Configuration;
using Spectre.Console;
using Menu = CodingTracker.JJHH17.Menu;

// Pulls from App.config
// var dbConnection = ConfigurationManager.AppSettings.Get(0);
// Console.WriteLine(dbConnection);

namespace CodingTracker.JJHH17;

public static class Program
    {
    public static void Main()
    {
        AnsiConsole.MarkupLine("[yellow]Welcome to Code Tracker![/]");

        // Main Menu
        Menu.Show();
    }
}