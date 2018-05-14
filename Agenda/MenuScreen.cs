/*This class creates the entire screen of the main menu,
and allows you to select the menu options.*/
using System;
public class MenuScreen
{
    public  void Run()
    {
        ConfigureConsole();

        bool exit = false;

        do
        {
            PrintBorders();

            int option = 1;
            bool selectedOption = false;
            do
            {
                PrintMenu(option);
                GetChosenOption(ref option, ref selectedOption);
            } while (!selectedOption);

            switch (option)
            {
                case 1:
                    Calendar calendar = new Calendar();
                    calendar.Run();
                    break;
                case 2:
                    Contacts contacts = new Contacts();
                    contacts.Run();
                    break;
                case 3:
                    TaskToDo tasks = new TaskToDo();
                    tasks.Run();
                    break;
                case 4:
                    Notes notes = new Notes();
                    notes.Run();
                    break;
                case 5:
                    ConfigurationConsole configuration = 
                        new ConfigurationConsole();
                    configuration.Run();
                    break;
                case 0:
                    exit = true; break;
                default: break;
            }
        } while (!exit);
    }

    public void ConfigureConsole()
    {
        Console.Title = "Agenda 2018";
        Console.SetWindowSize(81, 25);
        Console.SetBufferSize(81, 25);
        Console.CursorVisible = false;
    }

    public void PrintBorders()
    {
        Console.Clear();
        string line = new string(' ', Console.WindowWidth);
        string emptyLine = new string(' ', Console.WindowWidth - 4);

        Console.BackgroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0,0);
        Console.Write(line);
        for (int i = 1; i < Console.WindowHeight; i++)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, i);
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(emptyLine);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  ");
        }
        Console.SetCursorPosition(0,0);
        Console.Write(line);

        Console.SetCursorPosition(4, Console.WindowHeight-3);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Press ESC to Exit");
        Console.ResetColor();
    }

    public void PrintMenu(int cursorOption)
    {
        int x = Console.WindowWidth / 2 - 7;
        int y = Console.WindowHeight / 2 - 2;
        string[] option = {"Calendar" , "Contacts", "Task to do", "Notes",
                            "Configuration"};

        for (int i = 0; i < option.Length; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.ForegroundColor = ConsoleColor.White;
            if (i == cursorOption - 1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(option[i]);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(option[i]);
            }
            Console.ResetColor();
        }
    }

    public void GetChosenOption(ref int option, ref bool selectedOption)
    {
        ConsoleKeyInfo key;

        if (Console.KeyAvailable)
        {
            do
            {
                key = Console.ReadKey(true);
            } while (Console.KeyAvailable);

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    selectedOption = true;
                    break;
                case ConsoleKey.Escape:
                    option = 0;
                    selectedOption = true;
                    break;
                case ConsoleKey.DownArrow:
                    if (option < 5)
                        option++;
                    else
                        option = 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (option > 1)
                        option--;
                    else
                        option = 5;
                    break;
                default:
                    break;
            }
        }
    }
}