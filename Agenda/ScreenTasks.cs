//18/05/2018 - RaulGogna, V.01 Show TasksToDo
//21/05/2018 - RaulGogna, V.02 Completed methods
using System;
class ScreenTasks
{
    MenuScreen menu = new MenuScreen();
    ConfigurationConsole config = new ConfigurationConsole();
    public TasksList tasks;
    public int taskActual = 0;
    public void Run()
    {
        tasks = new TasksList();
        int count = 1;
        int option = 1;
        bool selectedOption = false;
        bool exit = false;
        do
        {
            DisplayTaskActual(tasks, count);
            GetChosenOption(ref count, ref tasks, ref option, 
                ref selectedOption, ref exit);
        } while (!exit);
        menu.Run();
    }
    private void Add()
    {
        Console.Clear();
        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("DateStart: ");
        string dateStart = Console.ReadLine();

        Console.Write("DateDue: ");
        string dateDue = Console.ReadLine();

        Console.Write("Category: ");
        string category = Console.ReadLine();

        Console.Write("Priority: ");
        string answer= Console.ReadLine();
        int priority = 0;
        if (answer != "")
            priority = Convert.ToInt32(answer);
        Console.Write("Confidential: ");
        answer = Console.ReadLine();
        bool confidential = false;
        if (answer == "yes")
            confidential = true;
        else if (answer == "no")
            confidential = false;

        tasks.Add(new Task(
            description, dateStart, dateDue, category, priority, confidential));
    }

    private void Modify(int index)
    {
        Task taskToModify = tasks.Get(taskActual);

        Console.Clear();

        config.WriteFore(0,4, "Description", "white", false);
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
        Console.WriteLine("Enter new DateStart (was {0})",
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
        Console.WriteLine("Enter new Category (was {0})",
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

        tasks.Set(taskActual, taskToModify);

    }

    private void Delete()
    {
        //To DO
    }

    private void Sort()
    {
        Task task = new Task();
        task.CompareTo(tasks.Get(taskActual).Priority);
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
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private void DisplayTaskActual(TasksList Task, int count)
    {
        SetConsole();

        string line = new string('-', Console.WindowWidth);
        string helpLine1 = "1-Add  2-Modify  3-Delete  4-Search  " +
            "5-ShowTask  Esc-Exit";
        string helpLine2 = "7-Listados";

        /*if(Task.Count == 0)
        {
            Console.WriteLine("Not dates");
            return;
        }*/
        string[] camps = { "Description:", "DateStart:", "DateDue:",
            "Category:", "Priority:", "Confidential:"};

        //Program body
        try
        {
            int contCamps = 0;
            config.WriteFore(0, 4, camps[contCamps], "white", false);
            config.WriteFore(15, 4, 
                checkVacio(tasks.Get(count).Description), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore(0, 7, camps[contCamps], "white", false);
            config.WriteFore(15, 7,
                checkVacio(tasks.Get(count).DateStart), "gray", true);
            contCamps++;

            config.WriteFore(0, 8, camps[contCamps], "white", false);
            config.WriteFore(15, 8,
                checkVacio(tasks.Get(count).DateDue), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore(0, 10, camps[contCamps], "white", false);
            config.WriteFore(15, 10,
                checkVacio(tasks.Get(count).Category), "gray", true);
            contCamps++;

            config.WriteFore(0, 12, camps[contCamps], "white", false);
            config.WriteFore(15, 12,
                checkVacio(tasks.Get(count).Priority), "gray", true);
            contCamps++;

            config.WriteFore(0, 14, camps[contCamps], "white", false);
            config.WriteFore(15, 14,
                checkVacio(tasks.Get(count).Confidential), "gray", true);
            contCamps = 0;

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        config.WriteBack(0, (Console.WindowHeight - 4), line, false);
        config.WriteBack(Console.WindowWidth / 2 -
            (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1, true);
        config.WriteBack(Console.WindowWidth / 2 -
            (helpLine2.Length / 2), Console.WindowHeight - 2, helpLine2, true);
 
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
        if (lineToCheck.ToString() == "")
        {
            return "(Por Confirmar)";
        }
        else
        {
            return lineToCheck.ToString();
        }
    }
    private void GetChosenOption(ref int count, ref TasksList Task, 
        ref int option, ref bool selectedOption, ref bool exit)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.Enter: selectedOption = true; break;
            case ConsoleKey.Escape:
                exit = true;
                Task.Save();
                break;
            case ConsoleKey.NumPad1: Add(); break;
            case ConsoleKey.NumPad2: Modify(taskActual); break;
            case ConsoleKey.NumPad3: Delete();break;
            case ConsoleKey.NumPad4: Search();break;
            case ConsoleKey.NumPad5: DisplayTaskActual(Task, count);break;
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

    private void ShowInCalendar()
    {
        //To DO
    }
}
