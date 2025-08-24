using System.Configuration;
using Spectre.Console;

// Pulls from App.config
// var dbConnection = ConfigurationManager.AppSettings.Get(0);
// Console.WriteLine(dbConnection);

enum MenuOptions
{
    Add,
    Exit,
}

public static class Program
{
    public static void Main()
    {
        bool active = true;
        AnsiConsole.MarkupLine("[yellow]Welcome to Code Tracker![/]");

        // Main Menu
        while (active)
        {
            Console.Clear(); // Clears the console when menu is shown 

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.Add:
                    AnsiConsole.MarkupLine("[green]You chose to add a new entry![/]");
                    break;

                case MenuOptions.Exit:
                    AnsiConsole.MarkupLine("[red]Exiting the application. Goodbye![/]");
                    active = false;
                    break;
            }
        }
    }
}