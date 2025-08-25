using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace CodingTracker.JJHH17
{
    internal class Menu
    {

        enum MenuOptions
        {
            Add,
            ViewAll,
            DeleteAll,
            DeleteSingleEntry,
            Exit,
        }

        public static void Show()
        {
            bool active = true;

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
                        AnsiConsole.MarkupLine("[green]You chose to add a new entry[/]");
                        AddEntry();
                        break;

                    case MenuOptions.ViewAll:
                        AnsiConsole.MarkupLine("[green]You chose to view all entries[/]");
                        ViewEntries();
                        break;

                    case MenuOptions.DeleteAll:
                        AnsiConsole.MarkupLine("[green]You chose to delete all entries[/]");
                        DeleteAllEntries();
                        break;

                    case MenuOptions.DeleteSingleEntry:
                        AnsiConsole.MarkupLine("[green]You chose to delete a single entry[/]");
                        DeleteSingleEntry();
                        break;


                    case MenuOptions.Exit:
                        AnsiConsole.MarkupLine("[red]Exiting the application. Goodbye![/]");
                        active = false;
                        break;
                }
            }
        }

        public static void AddEntry()
        {
            string startTime = AnsiConsole.Ask<string>("Enter the [yellow]start time[/] (e.g., 2023-10-01 14:30 (time is optional)):");
            // Parsing to DateTime to ensure correct format (end time must be after start time)
            DateTime parsedStartTime;
            while (!DateTime.TryParse(startTime, out parsedStartTime))
            {
                AnsiConsole.MarkupLine("[red]Invalid date format. Please try again.[/]");
                startTime = AnsiConsole.Ask<string>("Enter the [yellow]start time[/] (e.g., 2023-10-01 14:30 (time is optional)):");
            }

            string endTime = AnsiConsole.Ask<string>("Enter the [yellow]end time[/] (e.g., 2023-10-01 16:30 (time is optional)):");

            DateTime parsedEndTime;
            while (!DateTime.TryParse(endTime, out parsedEndTime) || parsedEndTime <= parsedStartTime)
            {
                AnsiConsole.MarkupLine("[red]Invalid date format or end time is before start time. Please try again.[/]");
                endTime = AnsiConsole.Ask<string>("Enter the [yellow]end time[/] (e.g., 2023-10-01 16:30 (time is optional)):");
            }

            AnsiConsole.MarkupLine($"[green]New entry added:[/] Start Time: {startTime}, End Time: {endTime}");
            Console.ReadKey();
            var newEntry = new CodingSession(startTime, endTime);
            newEntry.CalculateDuration();
            Database.AddEntry(startTime, endTime, newEntry.Duration);

        }

        public static void ViewEntries()
        {
            var table = new Table();
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[yellow]Start Time[/]");
            table.AddColumn("[yellow]End Time[/]");
            table.AddColumn("[yellow]Duration[/]");

            List<CodingSession> entries = Database.ReturnAllEntries();
            foreach (var entry in entries)
            {
                table.AddRow(entry.Id.ToString(), entry.StartTime, entry.EndTime, entry.Duration);
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void DeleteAllEntries()
        {
            string confirmation = AnsiConsole.Ask<string>("[yellow]Are you sure you want to delete all entries? Type [red]DELETE[/] to confirm:[/]").ToLower();
            if (confirmation == "delete")
            {
                Database.DeleteAllEntries();
                AnsiConsole.MarkupLine("[green]All entries have been deleted.[/]");
                AnsiConsole.MarkupLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Deletion cancelled.[/]");
                AnsiConsole.MarkupLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        // Entry to delete a single entry
        public static void DeleteSingleEntry()
        {
            ViewEntries();
            int idToDelete = AnsiConsole.Ask<int>("Enter the [yellow]ID[/] of the entry you want to delete:");
            AnsiConsole.MarkupLine($"[red]Are you sure you wish to delete entry {idToDelete}?[/]");
            string confirmation = AnsiConsole.Ask<string>("Type [red]DELETE[/] to confirm:").ToLower();

            if (confirmation == "delete")
            {
                Database.DeleteEntryById(idToDelete);
                AnsiConsole.MarkupLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Deletion cancelled.[/]");
                AnsiConsole.MarkupLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }
    }
}
