using System.Configuration;
using Spectre.Console;
using System.IO;
using Menu = CodingTracker.JJHH17.Menu;
using Database = CodingTracker.JJHH17.Database;

namespace CodingTracker.JJHH17;

public static class Program
    {
    public static void Main()
    {
        // AnsiConsole.MarkupLine("[yellow]Welcome to Code Tracker![/]");

        // Menu.Show();

        Database.CreateDatabase();
    }
}