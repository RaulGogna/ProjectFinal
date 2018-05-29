//18/05/2018 - RaulGogna, V.01 Show TasksToDo
//21/05/2018 - RaulGogna, V.02 Completed methods
using System;
class ScreenTasks
{
    ConfigurationConsole config = new ConfigurationConsole();
    public TasksList tasks;
    public void Run()
    {
        ConfigureConsole();
        Console.Clear();
        tasks = new TasksList();
        int option = 1;
        bool exit = false;
        do
        {
            DisplayTaskList(tasks, option);
            GetChosenOption(ref tasks, ref option, ref exit);
        } while (!exit);
    }
    public void ConfigureConsole()
    {
        Console.Title = "Agenda 2018 - Tasks to Do";
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        Console.CursorVisible = false;
    }
    private void Add()
    {
        Console.Clear();
        config.WriteFore("Description: ", "white", false);
        string description = Console.ReadLine();

        config.WriteFore("DateStart: ", "white", false);
        string dateStart = Console.ReadLine();

        config.WriteFore("DateDue: ", "white", false);
        string dateDue = Console.ReadLine();

        config.WriteFore("Category: ", "white", false);
        string category = Console.ReadLine();

        config.WriteFore("Priority: ", "white", false);
        string answer = Console.ReadLine();
        int priority = 0;
        if (answer != "")
            priority = Convert.ToInt32(answer);

        config.WriteFore("Confidential: ", "white", false);
        answer = Console.ReadLine();
        bool confidential = false;
        if (answer == "yes")
            confidential = true;
        else if (answer == "no")
            confidential = false;

        tasks.Add(new Task(
           description, dateStart, dateDue, category, priority, confidential));
        tasks.Save();
    }

    private void Modify(int index)
    {
        Task taskToModify = tasks.Get(index);

        Console.Clear();

        config.WriteFore(0,4, "Description: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new descrpition (was {0})",
            taskToModify.Description);
        string answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Description = answer;

        config.WriteFore("DateStart: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new dateStart (was {0})",
            taskToModify.DateStart);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.DateStart = answer;

        config.WriteFore("DateDue: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new DateDue (was {0})",
            taskToModify.DateDue);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.DateDue = answer;

        config.WriteFore("Category: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new category (was {0})",
            taskToModify.Category);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Category = answer;

        config.WriteFore("Priority: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new priority (was {0})",
            taskToModify.Priority);
        answer = Console.ReadLine();
        if (answer != "")
            taskToModify.Priority = Convert.ToInt32(answer);

        config.WriteFore("Confidential: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        if (taskToModify.Confidential)
            Console.WriteLine("Enter new confidential (was yes)");
        else if(!taskToModify.Confidential)
            Console.WriteLine("Enter new confidential (was no)");
        answer = Console.ReadLine();
        if (answer == "yes")
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
    private void DisplayTaskList(TasksList Tasks, int option)
    {
        string line = new string('-', Console.WindowWidth);
        string helpLine1 = "1-Add  2-Modify  3-Delete  4-Search  Esc-Exit";
        string helpLine2 = "7-Listados";

        if(Tasks.Count == 0)
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
            SetConsole();

            int x = 2;
            int y = 1;
            for (int i = 0; i < Tasks.Count; i++)
            {
                config.WriteFore(x, y + i, "white");
                if (i == option - 1)///
                {
                    config.WriteBack("green");
                    config.WriteFore(Tasks.Tasks[i].Description + " (" +
                        Tasks.Tasks[i].DateDue + ")", "white", false);
                }
                else
                {
                    config.WriteBack(Tasks.Tasks[i].Description + " (" +
                        Tasks.Tasks[i].DateDue + ")", "blue", false);
                }
                Console.ResetColor();
            }

            config.WriteBack("blue");
            config.WriteFore("white");
            config.WriteBack(0, (Console.WindowHeight - 4), line, false);
            config.WriteBack(Console.WindowWidth / 2 -
            (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1, true);
            config.WriteBack(Console.WindowWidth / 2 -
            (helpLine2.Length / 2), Console.WindowHeight - 2, helpLine2, true);

            ShowTaskCursor(Tasks, option);
        }
    }

    private void ShowTaskCursor(TasksList tasksList, int option)
    {
        string[] camps = { "Description:", "DateStart:", "DateDue:",
            "Category:", "Priority:", "Confidential:"};

        //Program body
        try
        {
            int contCamps = 0;
            config.WriteFore((Console.WindowWidth / 2 + 2), 4,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 4,
                checkVacio(tasks.Get(option).Description), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 7,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 7,
                checkVacio(tasks.Get(option).DateStart), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 8,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 8,
                checkVacio(tasks.Get(option).DateDue), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 10,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 10,
                checkVacio(tasks.Get(option).Category), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 12,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 12,
                checkVacio(tasks.Get(option).Priority), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 14,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 14,
                checkVacio(tasks.Get(option).Confidential), "gray", true);
            contCamps = 0;

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    private string checkVacio(string lineToCheck)
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

    private string checkVacio(int lineToCheck)
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

    private string checkVacio(bool lineToCheck)
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
            case ConsoleKey.NumPad3: Delete(option);break;
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
