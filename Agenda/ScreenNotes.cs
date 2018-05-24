//24/05/2018 - RaulGogna, V.01 Implemented all functions
using System;
using System.Collections.Generic;
using System.Linq;
class ScreenNotes
{
    MenuScreen menu = new MenuScreen();
    ConfigurationConsole config = new ConfigurationConsole();
    public NotesList notesList;

    //Function to split the description and do not pass half screen.
    public static string recStr(string user)
    {
        if (user.Length < Console.WindowWidth / 2 - 2)
        {
            return user;
        }
        return user.Substring(0, Console.WindowWidth / 2 - 1)
            + "\n\r"
            + recStr(user.Substring(Console.WindowWidth / 2 - 1));
    }

    public int noteActual = 0;
    public void Run()
    {
        ConfigureConsole();
        Console.Clear();
        notesList = new NotesList();
        int option = 1, changeNote = 1;
        bool exit = false;
        do
        {
            DisplayActualNote(notesList, option);
            GetChosenOption(ref notesList, ref option, ref changeNote,ref exit);
        } while (!exit);
        menu.Run();
    }
    public void ConfigureConsole()
    {
        Console.Title = "Agenda 2018 - Notes";
        Console.SetBufferSize(81, 25);
        Console.SetWindowSize(81, 25);
        Console.CursorVisible = false;
    }
    private void SetConsole(NotesList notes, int option)
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Blue;
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth));
            //To draw bar vertical in middle of screen
            if (i <= 21)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2), i);
                Console.Write("|" + new string(' ', Console.WindowWidth / 2));
            }
            if (i == 2 || i == 21)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string('-', (Console.WindowWidth / 2)));
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, i);
                Console.Write(new string('-', (Console.WindowWidth / 2)));
            }
            if (i == 1)
            {
                config.WriteBack((Console.WindowWidth / 2) -
                    notes.Notes[option].Title.Length / 2, i, 
                    notes.Notes[option].Title);
            }
            if(i == 22)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, i);
                Console.Write("Page " + option + " of " + notes.NumPages);
            }
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void SetConsoleEmpty()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Blue;
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Add()
    {
        Console.Clear();

        Console.WriteLine("Enter the note's title: ");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the note's description: ");
        string description = Console.ReadLine();
        description = recStr(description);

        Console.WriteLine("Enter the note's category: ");
        string category = Console.ReadLine();

        Console.WriteLine("Enter the note's confidential: ");
        string confidential = Console.ReadLine().ToLower();

        Console.WriteLine("Enter if the note is done: ");
        string answer = Console.ReadLine().ToLower();
        bool done = false;
        if (answer == "yes")
            done = true;
        else if (answer == "no")
            done = false;

        notesList.Add(new Note(title, description, category,
            confidential, done));
        notesList.Save();

    }

    public void Modify(int option)
    {

    }

    public void DisplayActualNote(NotesList notes, int option)
    {
        string line = new string('-', Console.WindowWidth / 2);
        string helpLine1 = "1 - Add  2 - Modify  3 - Delete  4 - Category";
        string helpLine2 = "<-- --> - Change Note  ";

        

        if (notes.Count == 0)
        {
            SetConsoleEmpty();
            Console.WriteLine("Not dates");

            Console.Write("Do you want add first record(yes/no): ");
            string answer = Console.ReadLine();
            if (answer == "yes")
                Add();
            else if (answer == "no")
            {
                Console.WriteLine("Okey. See you!");
                Console.WriteLine("Pres ESC to return.");
            }
        }
        else
        {
            SetConsole(notes, option);
            config.WriteBack(0, 3, "Completed items: ", true);

            config.WriteBack("blue");
            config.WriteFore("white");
            config.WriteBack(0, (Console.WindowHeight - 4), line, false);
            config.WriteBack(Console.WindowWidth / 2 -
             (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1, true);
            config.WriteBack(Console.WindowWidth / 2 -
             (helpLine2.Length / 2), Console.WindowHeight - 2, helpLine2, true);
        }
    }

    public void Delete(int option)
    {
        notesList.Delete(option);
    }

    public void Sort()
    {
        notesList.Notes.Sort();
    }

    public void NextNote()
    {
        //To DO
    }

    public void GetChosenOption(ref NotesList notes, ref int option, 
        ref int changeNote, ref bool exit)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.NumPad1: Add(); break;
            case ConsoleKey.NumPad2: Modify(option); break;
            case ConsoleKey.NumPad3: Delete(option); break;
            //case ConsoleKey.NumPad4: Search(); break;
            case ConsoleKey.Escape:
                exit = true;
                notesList.Save();
                break;
            case ConsoleKey.LeftArrow:
                if (changeNote > 1)
                    changeNote--;
                else
                    changeNote = notes.Count;
                break;
            case ConsoleKey.RightArrow:
                if (changeNote < notes.Count)
                    changeNote++;
                else
                    changeNote = 1;
                break;
            default:
                break;
        }
    }
}
///Foreach
/// if(tal.Done == true && tal.Title = )