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
}
