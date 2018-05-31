//18/05/2018 - RaulGogna, V.01 Show TasksToDo
//21/05/2018 - RaulGogna, V.02 Completed methods
using System;
class ScreenTasks
{
    public ConfigurationConsole config = new ConfigurationConsole();
    public TasksList tasks = new TasksList();
    public bool GetLanguage = MenuScreen.Spanish;
    public static string[] camps = { "Description:", "DateStart:", "DateDue:",
            "Category:", "Priority:", "Confidential:"};
    public static string[] campos = { "Descripcion:", "DataInicio:","DateFin:",
            "Categoria:", "Prioridad:", "Confidencial:"};
    public static string[] modifies = {
    "Enter new descrpition (was {0})", "Enter new dateStart (was {0})",
    "Enter new dateEnd (was {0})", "Enter new category (was {0})",
    "Enter new priority (was {0})", "Enter new confdential "};
    public static string[] options;
    public static string[] optionsModi;
    public int contCamps = 0;
    public void Run()
    {
        ConfigureConsole();
        Console.Clear();
        int option = 1;
        bool exit = false;
        if (!GetLanguage)
            options = camps;
        else
            options = campos;
        do
        {
            DisplayTaskList(tasks, option);
            GetChosenOption(ref tasks, ref option, ref exit);
        } while (!exit);
    }
    public void ConfigureConsole()
    {
        if (!GetLanguage)
            Console.Title = "Agenda 2018 - Tasks to Do";
        else
            Console.Title = "Agenda 2018 - Tareas Pendientes";
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        Console.CursorVisible = false;
    }
    public void Add()
    {
        if (!GetLanguage)
            options = camps;
        else
            options = campos;

        Console.Clear();
        contCamps = 0;
        config.WriteFore(options[contCamps], "white", false);
        string description = Console.ReadLine();
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string dateStart = Console.ReadLine();
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string dateDue = Console.ReadLine();
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string category = Console.ReadLine();
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string answer = Console.ReadLine();
        int priority = 0;
        if (answer != "")
            priority = Convert.ToInt32(answer);
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        answer = Console.ReadLine();
        bool confidential = false;
        if (answer == "yes")
            confidential = true;
        else if (answer == "no")
            confidential = false;
        contCamps = 0;

        tasks.Add(new Task(
           description, dateStart, dateDue, category, priority, confidential));
        tasks.Save();
    }

    public void Modify(int index)
    {
        if (!GetLanguage)
        {
            options = camps;
            optionsModi = modifies;
        }
        else
            options = campos;

        Task taskToModify = tasks.Get(index);

        Console.Clear();
        contCamps = 0;
        config.WriteFore(0, 4, options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Description);
        string answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Description = answer;
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.DateStart);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.DateStart = answer;
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.DateDue);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.DateDue = answer;
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Category);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Category = answer;
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Priority);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Priority = Convert.ToInt32(answer);
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        if (!GetLanguage)
        {
            if (taskToModify.Confidential)
                Console.WriteLine(optionsModi[contCamps] + "(was yes)");
            else if (!taskToModify.Confidential)
                Console.WriteLine(optionsModi[contCamps] + "(was no)");
        }
        else
        {
            if (taskToModify.Confidential)
                Console.WriteLine(optionsModi[contCamps] + "(era si)");
            else if (!taskToModify.Confidential)
                Console.WriteLine(optionsModi[contCamps] + "(era no)");
        }
        answer = Console.ReadLine();
        if (answer == "yes" || answer == "si")
            taskToModify.Confidential = true;
        else if (answer == "no")
            taskToModify.Confidential = false;

        tasks.Set(index, taskToModify);

    }

    private void Delete(int option)
    {
        tasks.Delete(option - 1);
        Sort();
    }

    private void Sort()
    {
        tasks.Tasks.Sort();
    }

    private void Search()
    {
        //To Do
    }
    private void SetConsole()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Blue;
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth));
            //To draw bar vertical in middle of screen
            if (i <= 20)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2), i);
                Console.Write("|" + new string(' ', Console.WindowWidth / 2));
            }
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void SetConsoleEmpty()
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
    public void DisplayTaskList(TasksList Tasks, int option)
    {
        string line = new string('-', Console.WindowWidth);
        string lineaAyuda1 =
            "1-Añadir  2-Modificar  3-Borrar  4-Buscar  Esc-Salir";
        string helpLine1 = "1-Add  2-Modify  3-Delete  4-Search  Esc-Exit";
        string languageHelp;
        if (!GetLanguage)
            languageHelp = helpLine1;
        else
            languageHelp = lineaAyuda1;


        if (Tasks.Count == 0)
        {
            SetConsoleEmpty();
            if (!GetLanguage)
            {
                Console.WriteLine("Not dates!");

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
                Console.WriteLine("No hay datos!");

                Console.Write("Quieres añadir el primer registro (si/no): ");
                string answer = Console.ReadLine();
                if (answer == "si")
                    Add();
                else if (answer == "no")
                {
                    Console.WriteLine("Vale. Nos vemos!");
                    Console.WriteLine("Presione ESC para volver.");
                }
            }
        }
        else
        {
            SetConsole();

            int x = 0;
            int y = 1;
            for (int i = 0; i < Tasks.Count; i++)
            {

                config.WriteFore(x, y + i, "white");
                if (i == option - 1)///
                {
                    config.WriteBack("green");
                    config.WriteFore((i + 1) + "." + Tasks.Tasks[i].Description +
                        " (" + Tasks.Tasks[i].DateDue + ")", "white", false);
                }
                else
                {
                    config.WriteBack((i + 1) + "." + Tasks.Tasks[i].Description
                        + " (" + Tasks.Tasks[i].DateDue + ")", "blue", false);
                }
                Console.ResetColor();
            }

            config.WriteBack("blue");
            config.WriteFore("white");
            config.WriteBack(0, (Console.WindowHeight - 4), line, false);
            config.WriteBack(Console.WindowWidth / 2 -
            (languageHelp.Length / 2), Console.WindowHeight - 3,
            languageHelp, true);

            ShowTaskCursor(Tasks, option);
        }
    }

    public virtual void ShowTaskCursor(TasksList tasksList, int option)
    {
        if (!GetLanguage)
            options = camps;
        else
            options = campos;
        //Program body
        try
        {
            int contCamps = 0;
            config.WriteFore((Console.WindowWidth / 2 + 2), 4,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 4,
                checkVacio(tasks.Get(option).Description), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 7,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 7,
                checkVacio(tasks.Get(option).DateStart), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 8,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 8,
                checkVacio(tasks.Get(option).DateDue), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 10,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 10,
                checkVacio(tasks.Get(option).Category), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 12,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 12,
                checkVacio(tasks.Get(option).Priority), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 14,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 14,
                checkVacio(tasks.Get(option).Confidential), "gray", true);
            contCamps = 0;

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    public string checkVacio(string lineToCheck)
    {
        if (lineToCheck == "" || lineToCheck == null)
        {
            return "(Por Confirmar)";
        }
        else
        {
            return lineToCheck.ToString();
        }
    }

    public string checkVacio(int lineToCheck)
    {
        if (lineToCheck == 0)
        {
            return "(Por Confirmar)";
        }
        else
        {
            return lineToCheck.ToString();
        }
    }

    public string checkVacio(bool lineToCheck)
    {
        string answer = "";
        if (lineToCheck.ToString() == "")
        {
            return answer = "(Por Confirmar)";
        }
        else
        {
            if (lineToCheck)
                answer = "Yes";
            else if (!lineToCheck)
                answer = "No";
            return answer;
        }
    }
    private void GetChosenOption(ref TasksList Task,
        ref int option, ref bool exit)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.Escape:
                exit = true;
                Task.Save();
                break;
            case ConsoleKey.NumPad1: Add(); break;
            case ConsoleKey.NumPad2: Modify(option); break;
            case ConsoleKey.NumPad3: Delete(option); break;
            //case ConsoleKey.NumPad4: Search();break;
            case ConsoleKey.DownArrow:
                if (option < Task.Count)
                    option++;
                else
                    option = 1;
                break;
            case ConsoleKey.UpArrow:
                if (option > 1)
                    option--;
                else
                    option = Task.Count;
                break;
            default:
                break;
        }
    }
}
