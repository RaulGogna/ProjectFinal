/*This class creates the entire screen of the main menu,
and allows you to select the menu options.*/
using System;
class MenuScreen
{
    public static bool Spanish { get; set; }

    private string[] options = {"Calendar" , "Contacts", "Task to do","Notes",
                            "Configuration", "Credtis", "Change language"};

    private string[] opciones = { "Calendario", "Contactos",
        "Tareas pendientes", "Notas", "Configuracion", "Creditos",
        "Cambiar idioma" };
    public MenuScreen()
    {
        Spanish = false;
    }
    public void Run()
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
                PrintMenu(option, Spanish);
                GetChosenOption(ref option, ref selectedOption);
            } while (!selectedOption);

            switch (option)
            {
                case 1:
                    Calendar calendar = new Calendar(); calendar.Run();
                    break;
                case 2:
                    Contacts contacts = new Contacts(); contacts.Run();
                    break;
                case 3:
                    TaskToDo tasks = new TaskToDo(); tasks.Run();
                    break;
                case 4:
                    Notes notes = new Notes(); notes.Run();
                    break;
                case 5:
                    ConfigurationConsole config = new ConfigurationConsole();
                    config.Run();
                    break;
                case 6:
                    CreditsScreen credits = new CreditsScreen();
                    credits.Run();
                    break;
                case 7:
                    Spanish = !Spanish;
                    break;
                case 0:
                    exit = true;
                    break;
                default: break;
            }
        } while (!exit);
    }

    public void ConfigureConsole()
    {
        Console.Title = "Agenda 2018";
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        Console.CursorVisible = false;
    }

    public void PrintBorders()
    {
        Console.Clear();
        string line = new string(' ', Console.WindowWidth);
        string emptyLine = new string(' ', Console.WindowWidth - 4);

        Console.BackgroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
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
        Console.SetCursorPosition(0, 0);
        Console.Write(line);

        Console.SetCursorPosition(4, Console.WindowHeight - 3);
        Console.ForegroundColor = ConsoleColor.Black;
        if (!Spanish)
            Console.Write("Press ESC to Exit");
        else
            Console.Write("Presione ESC para salir");
        Console.ResetColor();
    }

    public void PrintMenu(int cursorOption, bool Spanish)
    {
        int x = Console.WindowWidth / 2 - 7;
        int y = Console.WindowHeight / 2 - 2;

        if (!Spanish)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.ForegroundColor = ConsoleColor.White;
                if (i == cursorOption - 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(options[i]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(options[i]);
                }
                Console.ResetColor();
            }
        }
        else
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.ForegroundColor = ConsoleColor.White;
                if (i == cursorOption - 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(opciones[i]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(opciones[i]);
                }
                Console.ResetColor();
            }
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
                    if (option < options.Length)
                        option++;
                    else
                        option = 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (option > 1)
                        option--;
                    else
                        option = options.Length;
                    break;
                default:
                    break;
            }
        }
    }
}
