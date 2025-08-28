```Coding Tracking Application```

A command line based application, used for tracking time coded by a user.
The user can either enter a date and time manually, or they can use a stopwatch feature to track the time during the session.
This project was built following the CSharpAcademy Coding Tracker project requirements: https://www.thecsharpacademy.com/project/13/coding-tracker.

```Technologies used and installed```
- SQLite database.
- Dapper (for integrating with SQLite).
- Spectre console (for terminal styling).

```Application Details```
- The application can be started by cloning the directory and running the program.cs file.
- You're then presented with a list of options - use the arrow keys to navigate via the terminal options:
<img width="400" height="300" alt="image" src="https://github.com/user-attachments/assets/13bbf513-4539-4d3c-9885-987ea834eefc" />

- You can enter a start and endtime manually via the "AddEventManually" option - this takes in a specific date and time format:
<img width="700" height="600" alt="image" src="https://github.com/user-attachments/assets/c140559c-eb67-42a2-90df-f0584174d5b8" />

- Alternatively, you can use the "Stopwatch", which will time your session until you hit the enter key, which stops the session on the database.
You can also:
- View a full list of coding events added.
- Delete a single event (by the unique event ID)
- Delete all events on the database.

```Project Challenges and Learnings```
- One of the biggest challenges was using Dapper, parsing the data and then feeding it back to Spectre for the frontend/terminal, although this got easier as I used it more with other methods.
- I initially struggled with formatting the "duration" of entries.
- A potential change i'd make in the future would be storing time as an integer (or having multiple cells in the Database table) for hours, days, months etc... rather than storing them as a single string based cell.
- This would make calculating the difference easier, without needing to parse to DateTime objects or explore using Regex.
- Finally, it was great to learn about config files, understand where they may be useful in projects and use them here, which I'm sure will be great knowledge to have going into bigger projects.

I'd like to thank the CSharp Academy for this project, the opportunity and the Discord community for the previous insight/help gained.
