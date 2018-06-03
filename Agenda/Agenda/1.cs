//Raul Gogna
//14/05/2018 - RaulGogna, V.01 Run the main menu
//15/05/2018 - RaulGogna, V.02 Run the WelcomeScreen

class Agenda
{
    public static void Run()
    {
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Run();
        MenuScreen menu = new MenuScreen();
        menu.Run();
    }
    static void Main(string[] args)
    {
        Run();
    }
}//23/05/2018 - RaulGogna, V.02 Improve Calendar, show month actual and other functions
//17/05/2018 - Brandom Blasco, V.01 Show Calendar

class Calendar
{
    ScreenCalendar screenCalendar;

    public void Run()
    {
        screenCalendar = new ScreenCalendar();
        screenCalendar.Run();
    }
}
//16/05/2018 - RaulGogna, V.01 Implemented all functions of class
/*This class can change the background color and foregroundColor and save code
 in the all proyect.*/
using System;
class ConfigurationConsole
{
    public bool GetLanguage = MenuScreen.Spanish;
    public static string colorChangedBack = "greenD";
    public static string colorChangedFore = "blueD";
    public string SwitchBa(string color)
    {
        switch (color)
        {
            case "amarillo":
            case "yellow":
                Console.BackgroundColor = ConsoleColor.Yellow;
                break;
            case "azul":
            case "blue":
                Console.BackgroundColor = ConsoleColor.Blue;
                break;
            case "azulD":
            case "blueD":
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                break;
            case "rojo":
            case "red":
                Console.BackgroundColor = ConsoleColor.Red;
                break;
            case "verde":
            case "green":
                Console.BackgroundColor = ConsoleColor.Green;
                break;
            case "verdeD":
            case "greenD":
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                break;
            case "negro":
            case "black":
                Console.BackgroundColor = ConsoleColor.Black;
                break;
            case "blanco":
            case "white":
                Console.BackgroundColor = ConsoleColor.White;
                break;
            case "gris":
            case "gray":
                Console.BackgroundColor = ConsoleColor.Gray;
                break;
            default:
                break;
        }
        return color;
    }

    public string SwitchFore(string color)
    {
        switch (color)
        {
            case "amarillo":
            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "azul":
            case "blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "azulD":
            case "blueD":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case "rojo":
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "verde":
            case "green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "verdeD":
            case "greenD":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case "negro":
            case "black":
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case "blanco":
            case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "gris":
            case "gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            default:
                break;
        }
        return color;
    }

    //Function to save code in others classes(Fore the ForegroundColor)
    public string WriteFore(int x, int y, string text, string color, 
        bool line)
    {
        WriteFore(x, y, color);
        if (line)
            Console.WriteLine(text);
        else
            Console.Write(text);
        return color;
    }

    public string WriteFore(string text, string color, bool line)
    {
        SwitchFore(color);
        if (line)
            Console.WriteLine(text);
        else
            Console.Write(text);
        return color;
    }

    public void WriteFore(int x, int y, string color)
    {
        Console.SetCursorPosition(x, y);
        SwitchFore(color);
    }
    public string WriteFore(string color)
    {
        SwitchFore(color);
        return color;
    }
    
    
    //Function to save code in others classes(Back the BackgroundColor)
    public string WriteBack(int x, int y, string text, string color,
        bool line)
    {
        WriteBack(x, y, color);
        if (line)
            Console.WriteLine(text);
        else
            Console.Write(text);
        return color;
    }
    public void WriteBack(int x, int y, string text, bool line)
    {
        Console.SetCursorPosition(x, y);
        if (line)
            Console.WriteLine(text);
        else
            Console.Write(text);
    }
    public string WriteBack(string text, string color, bool line)
    {
        SwitchBa(color);
        if(line)
            Console.WriteLine(text);
        else
            Console.Write(text);
        return color;
    }
    public void WriteBack(int x, int y, string color)
    {
        Console.SetCursorPosition(x, y);
        SwitchBa(color);
    }
    
    public string WriteBack(string color)
    {
        SwitchBa(color);
        return color;
    }

    public string ChangeBackgroundColor(ref string colorChangedBack)
    {
        Console.Clear();
        if(!GetLanguage)
            Console.WriteLine("What background color do you want to put ? ");
        else
            Console.WriteLine("�Que color de fondo quieres poner ? ");
        string color = "";
        try
        {
            color = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        colorChangedBack = color;
        SwitchBa(colorChangedBack);
        return colorChangedBack;
    }
    public string ChangeColorFont(ref string colorChangedFore)
    {
        Console.Clear();
        if (!GetLanguage)
            Console.WriteLine("What foreground color do you want to put ? ");
        else
            Console.WriteLine("�Que color de primer plano quieres poner ? ");
        string color = "";
        try
        {
            color = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        colorChangedFore = color;
        SwitchFore(colorChangedFore);
        return colorChangedFore;
    }

    public void Run()
    {
        bool exit = false;
        colorChangedBack = "greenD";
        colorChangedFore = "blueD";
        do
        {
            PrintBorders();
            int option = 1;
            bool selectedOption = false;
            do
            {
                PrintMenu(option);
                GetUserOption(ref option, ref selectedOption);
            } while (!selectedOption);

            switch (option)
            {
                case 1: ChangeBackgroundColor(ref colorChangedBack);break;
                case 2: ChangeColorFont(ref colorChangedFore);break;
                case 0: exit = true; break;
                default:
                    break;
            }
        } while (!exit);
    }

    public void PrintBorders()
    {
        
        Console.Clear();

        string line = new string(' ', Console.WindowWidth);
        string emptyLine = new string(' ', Console.WindowWidth - 4);

        WriteBack(0, 0, line, colorChangedBack, false);
        for (int i = 1; i < Console.WindowHeight; i++)
        {
            WriteBack(0, i, "  ", colorChangedBack, false);
            WriteBack(emptyLine, colorChangedFore, false);
            WriteBack("  ", colorChangedBack, false);
        }
        WriteBack(0, 0, line, false);
        WriteBack(colorChangedBack = "green");
        if(!GetLanguage)
            WriteFore(4, (Console.WindowHeight - 3), "Press ESC to Back", 
            (colorChangedFore = "blue"), false);
        else
            WriteFore(4, (Console.WindowHeight - 3),"Presione ESC para volver",
            (colorChangedFore = "blue"), false);
    }

    public void PrintMenu(int cursorOption)
    {
        int x = Console.WindowWidth / 2 - 15;
        int y = Console.WindowHeight / 2 - 2;

        string[] options = {"Change background color of screen",
                            "Change foreground color of fonts"};
        string[] opciones = {"Cambiar el color de fondo de la pantalla ",
                            "Cambiar el color de primer plano de las fuentes"};
        string[] option;
        if (!GetLanguage)
            option = options;
        else
            option = opciones;

        for (int i = 0; i < option.Length; i++)
        {
            //green
            WriteFore(x, y + i, (colorChangedBack = "white"));
            if (i == cursorOption - 1)
            {
                WriteBack(colorChangedBack = "green");
                WriteFore(colorChangedFore = "blue");
                Console.Write(option[i]);
            }
            else
            {
                WriteBack(colorChangedFore = "blueD");
                Console.Write(option[i]);
            }
        }
    }

    public void GetUserOption(ref int option, ref bool selectedOption)
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
                    if (option < 2)
                        option++;
                    else
                        option = 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (option > 1)
                        option--;
                    else
                        option = 2;
                    break;
                default:
                    break;
            }
        }
    }
}
// 22/05/2018 - RaulGogna, V.01 created constructor, and Properties
using System;

[Serializable]
class Contact : IComparable
{
    // Attributes

    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public string Telephone { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string Observations { get; set; }

    public Contact(string name, string email, int age, string telephone, 
        string adress, string country, string observations)
    {
        Name = name;
        Email = email;
        Age = age;
        Telephone = telephone;
        Address = adress;
        Country = country;
        Observations = observations;
    }

    public Contact()
    {

    }

    public int CompareTo(Object c2)
    {
        return (Name).CompareTo(
            ((Contact)c2).Name);
    }
}
//22/05/2018 - RaulGogna, V.01 Created object screenContacts of class ScreenContacts
class Contacts
{
    public void Run()
    {
        ScreenContacts screenContacts = new ScreenContacts();
        screenContacts.Run();
    }
}
//28-05-2018 - RaulGogna, V.02 Implemented method of save files
//22-05-2018 - RaulGogna, V.01 Implemented methods
using System;
using System.Collections.Generic;
using System.IO;
class ContactsList
{
    public List<Contact> Contacts { get; set; }
    public int Count { get; set; }

    public ContactsList()
    {
        Contacts = new List<Contact>();
        Load();
        Count = Contacts.Count;
    }
    public void Add(Contact contactToAdd)
    {
        try
        {
            Contacts.Add(contactToAdd);
            Count++;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public Contact Get(int index)
    {
        try
        {
            return Contacts[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Contact contact)
    {
        try
        {
            if (n >= Count || n < 0)
            {
                return;
            }
            else
            {
                Contacts[n] = contact;
                Save();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int o)
    {
        try
        {
            Contacts.RemoveAt(o);
            Count--;
        }
        catch (Exception)
        {
            return;
        }
    }

    public void Save()
    {
        try
        {
            StreamWriter contactsOutput = new StreamWriter("Contacts.dat");
            foreach (Contact c in Contacts)
            {
                contactsOutput.WriteLine("Contacts:" + c.Name + ";" + c.Email
                    + ";" + c.Age + ";" + c.Telephone + ";" + c.Address +
                    ";" + c.Country + ";" + c.Observations + "\n");
            }
            contactsOutput.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Error: path too long");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: file not found");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public void Load()
    {
        try
        {
            StreamReader contactsInput = new StreamReader("Contacts.dat");
            string line;
            string[] contacts;
            do
            {
                line = contactsInput.ReadLine();
                if (line != null)
                {
                    /*To extract the data from when you find two points in the 
                     * text file.*/
                    line = line.Substring(line.IndexOf(":") + 1);
                    contacts = line.Split(';');
                    Add(new Contact(
                        contacts[0], contacts[1],
                        Convert.ToInt32(contacts[2]),
                        contacts[3], contacts[4],
                        contacts[5], contacts[6]));
                }
            } while (line != null);
            contactsInput.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Error: path too long");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: file not found");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
// 25/05/2018 - RaulGogna, V.0, Created basis animation and functionality
using System;
using System.Threading;

class CreditsScreen : Screen
{
    ConfigurationConsole config = new ConfigurationConsole();
    protected short startY = 22;
    protected short endY = 4;
    protected bool finished = false;

    public void Run()
    {
        Display();
    }
    public override void Display()
    {
        Console.Clear();

        Console.SetCursorPosition
            (Console.WindowWidth / 2, Console.WindowHeight / 2);
        string[] credits = { "Creator of the project: Raul Gogna",
            "Version: 2.0", "Data ot creation: 14/05/2018" ,
            "Data of finalization: 01/06/2018", "Project Boss: Nacho Cabanes"};
        while(!finished)
        {
            for (int i = credits.Length - 1; i > 0; i--)
            {

                config.WriteFore(20, (startY), credits[i], "green", true);

                Thread.Sleep(1000);
                if (startY < endY)
                    finished = true;
                startY -= 2;
                Console.Clear();
                if (startY < endY)
                    finished = true;
            }
        }
    }
}
/*This class creates the entire screen of the main menu,
and allows you to select the menu options.*/
using System;
class MenuScreen
{
    public static bool Spanish { get; set; }

    private string[] options = {"Calendar" , "Contacts", "Task to do","Notes",
                            "Configuration", "Credits", "Change language"};

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
//23/05/2018 - RaulGogna, V.01 Implemented Constructor, and Properties
using System;
[Serializable]
class Note : IComparable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Confidential { get; set; }
    public bool Done { get; set; }

    public Note(string title,string description, string category,
        string confidential, bool done)
    {
        Title = title;
        Description = description;
        Category = category;
        Confidential = confidential;
        Done = done;
    }

    public Note()
    {

    }

    public int CompareTo(Object n2)
    {
        return (Title).CompareTo(((Note)n2).Title);
    }
}
// 23/05/2018 - RaulGogna, V.01 Called method Run of ScreenNotes
using System;
public class Notes
{
    public void Run()
    {
        ScreenNotes screenNotes = new ScreenNotes();
        screenNotes.Run();
    }
}
// 23/05/2018 - RaulGogna, V.01 Implemented methods,constructors,and properties
// 24/05/2018 - RaulGogna, V.02 Improve some functions
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class NotesList
{
    public List<Note> Notes { get; set; }
    public int Count { get; set; }

    public NotesList()
    {
        Notes = new List<Note>();
        Load();
        Count = Notes.Count;
    }
    public void Add(Note noteToAdd)
    {
        Notes.Add(noteToAdd);
        Count++;
    }

    public Note Get(int index)
    {
        try
        {
            return Notes[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Note note)
    {
        if (n >= Count || n < 0)
        {
            return;
        }
        else
        {
            Notes[n] = note;
            Save();
        }
    }
    public void Delete(int o)
    {
        try
        {
            Notes.RemoveAt(o);
            Count--;
        }
        catch (Exception)
        {
            return;
        }
    }
    public void Load()
    {
        if (File.Exists("Notes.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Notes.dat", FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                Notes = (List<Note>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
    public void Save()
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Notes.dat", FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Notes);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
using System;
abstract class Screen
{
    public abstract void Display();
}
﻿//28/05/2018 - RaulGogna, V.02 Show Tasks in the calendar
//23/05/2018 - RaulGogna, V.01 Display Calendar
using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;


class ScreenCalendar
{
    public ConfigurationConsole config = new ConfigurationConsole();
    public ScreenTasks tasksScreen = new ScreenTasks();
    private List<Month> months = new List<Month>();
    private int day, mounthD = 0, year = 0, ChosenDay = 0;
    public static DateTime dateActual = DateTime.Now;
    private bool selectedDay = false, cursorSelected = false;
    public bool GetLanguage = MenuScreen.Spanish;
    public static void GetCurrentMounth(
        ref int day, ref int month, ref int year)
    {
        string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
        day = dateActual.Day;
        month = dateActual.Month;
        year = dateActual.Year;
    }
    public struct Month
    {
        public int days;
        public Day day;
        public string monthName;
        public int numMonth;
        public int year;
    }
    public struct Day
    {
        public int dayOfMonth;
        public int currentDay;
    }

    public void Run()
    {
        bool exit = false;
        int xCursor = 23, yCursor = 8;
        do
        {
            DisplayCalendar(ref xCursor, ref yCursor, ref cursorSelected,
                ref selectedDay, ref ChosenDay);
            GetChosenOption(ref exit, ref xCursor, ref yCursor,
                ref selectedDay, ref cursorSelected, ref ChosenDay);
        } while (!exit);
    }

    private void SetConsole()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Black;
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Green;
    }
    private void PrintMenu()
    {
        Console.ResetColor();
        SetConsole();

        string line = new string('-', Console.WindowWidth);
        string lineaAyuda1 = "Esc-Salir  S-Buscar  Enter-Ver Dia  " +
            "Flechas-Moverse";
        string helpLine1 = "Esc-Exit  S-Search  Enter-Show Day  Arrows-Move";

        config.WriteBack("black");
        config.WriteFore("white");
        config.WriteBack(0, (Console.WindowHeight - 4), line, false);
        if (!GetLanguage)
            config.WriteBack(Console.WindowWidth / 2 -
            (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1,
            "black", true);
        else
            config.WriteBack(Console.WindowWidth / 2 -
            (helpLine1.Length / 2), Console.WindowHeight - 3, lineaAyuda1,
            "black", true);
    }
    private bool ContainsTasks(int diaTask, int mesTask, int añoTask)
    {
        string date = diaTask.ToString() + "/" + mesTask.ToString() + "/"
            + añoTask.ToString();
        foreach (Task c in tasksScreen.tasks.Tasks)
        {
            if (c.DateStart.Equals(date) && c.Confidential == false)
                return true;
        }
        return false;
    }

    public void TasksInDate(string dateChoosed)
    {
        for (int i = 0; i < tasksScreen.tasks.Tasks.Count; i++)
        {
            if (tasksScreen.tasks.Tasks[i].DateStart == dateChoosed)
            {
                if (!GetLanguage)
                    config.WriteBack(0, 0, "Day: " + dateChoosed +
                    new string(' ', 7) + "Tasks: " + (i + 1), true);
                else
                    config.WriteBack(0, 0, "Dia: " + dateChoosed +
                    new string(' ', 7) + "Tarea: " + (i + 1), true);
                Console.WriteLine(new string('-', Console.WindowWidth));
                ShowTaskCursor(tasksScreen.tasks, i);
                if(!GetLanguage)
                    config.WriteBack(0, 23, "Press enter to show " +
                    "the next task if there were one more.", false);
                else
                    config.WriteBack(0, 23, "Presione enter para mostrar " +
                        "la siguiente tarea si hubiese una más.", false);
                Console.SetCursorPosition(0, 23);
                try
                {
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            Console.Clear();
        }
        if (!GetLanguage)
            Console.WriteLine("Do you want to add some task? (Yes/No)");
        else
            Console.WriteLine("Quieres añadir una tarea? (Si/No)");
        string answer = "";
        try
        {
            answer = Console.ReadLine().ToLower();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        if (answer == "yes" || answer == "si")
        {
            tasksScreen.SetConsoleEmpty();
            tasksScreen.Add();
        }
        else if (answer == "no")
        {
            if (!GetLanguage)
                Console.WriteLine("Okey. See you!");
            else
                Console.WriteLine("Vale. Nos vemos!");
            Thread.Sleep(2000);
        }
    }
    private void ShowDay(int chosedDay)
    {
        SetConsole();

        dateActual = new DateTime(year, mounthD, chosedDay);
        string dateSelected = dateActual.ToString("d/M/yyyy");
        TasksInDate(dateSelected);
    }
    public void SearchDay()
    {
        SetConsole();
        if (!GetLanguage)
            Console.WriteLine("What date do you want to see: ");
        else
            Console.WriteLine("Qué fecha quieres ver: ");
        string date = "";
        try
        {
            date = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        TasksInDate(date);
    }
    public void ShowTaskCursor(TasksList tasksList, int option)
    {
        string[] camps = { "Description:", "DateStart:", "DateDue:",
            "Category:", "Priority:", "Confidential:"};
        string[] campos = { "Descripcion:", "DataInicio:", "DataFin:",
            "Categoria:", "Prioridad:", "Confidencial:"};
        int contCamps;
        try
        {
            if (!GetLanguage)
            {
                option += 1;
                contCamps = 0;
                config.WriteFore(0, 4, camps[contCamps],
                    "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 4,
                    tasksScreen.checkVacio(tasksList.Get(option).Description),
                    "green", true);
                contCamps++;

                Console.WriteLine();
                config.WriteFore(0, 7, camps[contCamps],
                    "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 7,
                    tasksScreen.checkVacio(tasksList.Get(option).DateStart),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 8, camps[contCamps],
                    "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 8,
                    tasksScreen.checkVacio(tasksList.Get(option).DateDue),
                    "green", true);
                contCamps++;

                Console.WriteLine();
                config.WriteFore(0, 10,
                    camps[contCamps], "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 10,
                    tasksScreen.checkVacio(tasksList.Get(option).Category),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 12,
                    camps[contCamps], "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 12,
                    tasksScreen.checkVacio(tasksList.Get(option).Priority),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 14,
                    camps[contCamps], "green", false);
                config.WriteFore((camps[contCamps].Length + 4), 14,
                    tasksScreen.checkVacio(tasksList.Get(option).Confidential),
                    "green", true);
                contCamps = 0;
            }
            else
            {
                option += 1;
                contCamps = 0;
                config.WriteFore(0, 4, campos[contCamps],
                    "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 4,
                    tasksScreen.checkVacio(tasksList.Get(option).Description),
                    "green", true);
                contCamps++;

                Console.WriteLine();
                config.WriteFore(0, 7, campos[contCamps],
                    "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 7,
                    tasksScreen.checkVacio(tasksList.Get(option).DateStart),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 8, campos[contCamps],
                    "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 8,
                    tasksScreen.checkVacio(tasksList.Get(option).DateDue),
                    "green", true);
                contCamps++;

                Console.WriteLine();
                config.WriteFore(0, 10,
                    campos[contCamps], "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 10,
                    tasksScreen.checkVacio(tasksList.Get(option).Category),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 12,
                    campos[contCamps], "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 12,
                    tasksScreen.checkVacio(tasksList.Get(option).Priority),
                    "green", true);
                contCamps++;

                config.WriteFore(0, 14,
                    campos[contCamps], "green", false);
                config.WriteFore((campos[contCamps].Length + 4), 14,
                    tasksScreen.checkVacio(tasksList.Get(option).Confidential),
                    "green", true);
                contCamps = 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    private void DaysInMonths(List<Month> months, int year)
    {
        string[] monthsNames = {"January", "February", "March", "April",
                                "May", "June", "July", "August", "September",
                                "October", "November", "December"};
        for (int i = 0; i < 12; i++)
        {
            Month m = new Month();
            m.numMonth = i + 1;
            m.monthName = monthsNames[i];
            m.year = year;
            if ((i + 1 == 1) || (i + 1 == 3) || (i + 1 == 5) ||
               (i + 1 == 7) || (i + 1 == 8) || (i + 1 == 10) ||
               (i + 1 == 12))
            {
                m.days = 31;
            }
            else if (i + 1 == 2)
            {
                if (year % 4 == 0)
                    m.days = 29;
                else if (year % 4 != 0)
                    m.days = 28;
            }
            else
            {
                m.days = 30;
            }
            months.Add(m);
        }
    }

    //For correct positioning of text.
    private void Daylessthan10(int i)
    {
        if (i < 10)
            Console.Write("  ");
        else
            Console.Write(" ");
    }
    public void DrawHeader(bool selectedCursor)
    {
        PrintMenu();
        //To check only once each time you start calendar option
        if (!selectedCursor)
            GetCurrentMounth(ref day, ref mounthD, ref year);
        dateActual = new DateTime(year, mounthD, day);
        DaysInMonths(months, year);

        //Header
        string culture;
        string subHeader;
        if (!GetLanguage)
        {
            culture = "en-US";
            subHeader = "Mo   Tu   We   Th   Fr   Sa   Su";
        }
        else
        {
            culture = "es-MX";
            subHeader = "Lu   Ma   Mi   Ju   Vi   Sa   Do";
        }

        string header = dateActual.ToString("MMMM yyyy",
            CultureInfo.CreateSpecificCulture(culture));
        int size = (40 - header.Length / 2);
        int sizeSubHeader = (40 - subHeader.Length / 2);
        config.WriteBack("black");
        config.WriteFore("white");
        config.WriteBack(size, 3, header, true);
        config.WriteBack(sizeSubHeader, 6, subHeader, true);
    }
    public void DisplayCalendar(ref int xCursor, ref int yCursor,
        ref bool selectedCursor, ref bool selectedDay, ref int ChosenDay)
    {
        DrawHeader(selectedCursor);
        Month myMonth = months[mounthD - 1];

        int j = 0;
        for (int i = 1; i <= months[mounthD - 1].days; i++)
        {
            DateTime dia1 = new DateTime(year, mounthD, i);
            myMonth.day.dayOfMonth = i;
            if (Convert.ToInt32(dia1.DayOfWeek) == 0)
                myMonth.day.currentDay = 7;
            else
                myMonth.day.currentDay = Convert.ToInt32(dia1.DayOfWeek);

            months[mounthD - 1] = myMonth;

            int x = 23, y = 8, k = 5;
            switch (myMonth.day.currentDay)
            {
                case 1:
                    k = 0; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 2:
                    k = 5; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 3:
                    k += 5; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 4:
                    k += 10; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 5:
                    k += 15; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 6:
                    k += 20; Console.SetCursorPosition(x + k, y + j);
                    break;
                case 7:
                    k += 25; Console.SetCursorPosition(x + k, y + j);
                    break;
                default:
                    break;
            }
            //If i is equals to day of current month
            if (!cursorSelected && i == day)
            {
                xCursor = x + k;
                yCursor = y + j;
                Console.SetCursorPosition(xCursor, yCursor);
                Daylessthan10(i);
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            if (!cursorSelected && i == day && 
                (ContainsTasks(i, mounthD, year)))
            {
                //Contains tasks and cursor over the day but no value
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if (cursorSelected && i == day && ((x + k) == xCursor &&
                (y + j) == yCursor) && ContainsTasks(i, mounthD, year))
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (ContainsTasks(i, mounthD, year))
            {
                Daylessthan10(i);
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (i != day && (!ContainsTasks(i, mounthD, year)))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Daylessthan10(i);
            }
            else if (cursorSelected && i == day &&
                   (!((x + k) == xCursor && (y + j) == yCursor)))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Daylessthan10(i);
            }
            if (myMonth.day.currentDay == 7)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else
            {
                if (myMonth.day.currentDay == 6)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
            }
            if (cursorSelected && ((x + k) == xCursor && (y + j) == yCursor))
            {
                if (i > 9)
                    Console.SetCursorPosition(xCursor + 1, yCursor);
                else
                    Console.SetCursorPosition(xCursor + 2, yCursor);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(i);
            }
            else
            {
                Console.Write(i);
            }
            if (myMonth.day.currentDay == 7)
                j += 2;
            if (selectedDay && cursorSelected &&
                ((x + k) == xCursor && (y + j) == yCursor))
            {
                ChosenDay = i;
            }
            Console.ResetColor();
        }
    }


    public void GetChosenOption(ref bool exit, ref int xCursor,
        ref int yCursor, ref bool selectedDay, ref bool cursorSelected,
        ref int ChosenDay)
    {
        ConsoleKeyInfo key;
        int x = xCursor, y = yCursor;
        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.S: SearchDay(); break;
            case ConsoleKey.Escape: exit = true; break;
            case ConsoleKey.Enter:
                selectedDay = true;
                cursorSelected = true;
                DisplayCalendar(ref xCursor, ref yCursor, ref cursorSelected,
                    ref selectedDay, ref ChosenDay);
                ShowDay(ChosenDay);
                selectedDay = false;
                ChosenDay = 0;
                break;
            case ConsoleKey.LeftArrow:
                if (x > 23)
                    xCursor -= 5;
                cursorSelected = true;
                break;
            case ConsoleKey.UpArrow:
                if (y > 8)
                    yCursor -= 2;
                cursorSelected = true;
                break;
            case ConsoleKey.RightArrow:
                if (x < 53)
                    xCursor += 5;
                cursorSelected = true;
                break;
            case ConsoleKey.DownArrow:
                if (y < 16)
                    yCursor += 2;
                cursorSelected = true;
                break;
            default:
                break;
        }
    }
}﻿//22/05/2018 - RaulGogna, V.01 Completed methods
using System;
class ScreenContacts
{
    ConfigurationConsole config = new ConfigurationConsole();
    public ContactsList listContact;
    public bool GetLanguage = MenuScreen.Spanish;
    public static string[] camps = { "Name:", "Email:", "Age:",
            "Telephone:", "Address:", "Country:", "Observations:"};
    public static string[] campos = { "Nombre:", "Correo:","Edad:",
            "Teléfono:", "Calle:", "Ciudad:", "Observaciones:"};
    public static string[] modifiEN = {
    "Enter new name (was {0})", "Enter new email (was {0})",
    "Enter new age (was {0})", "Enter new telephone (was {0})",
    "Enter new address (was {0})", "Enter new country (was {0})",
    "Enter new observations (was {0})" };
    public static string[] modifiES = {
    "Ingrese un nuevo nombre (era {0})", "Ingrese un nuevo correo (era {0})",
    "Ingrese una nueva edad (era {0})", "Ingrese un nuevo telefono (era {0})",
    "Ingrese una nueva direccion (era {0})",
    "Ingrese una nueva ciudad (era {0})",
    "Ingrese una nueva observacion (era {0})"};
    public static string[] options;
    public static string[] optionsModi;
    public int contCamps = 0;
    public void Run()
    {
        ConfigureConsole();
        listContact = new ContactsList();
        int option = 1;
        bool exit = false;
        if (!GetLanguage)
        {
            options = camps;
            optionsModi = modifiEN;
        }
        else
        {
            options = campos;
            optionsModi = modifiES;
        }
        do
        {
            DisplayContactsList(listContact, option);
            GetChosenOption(ref listContact, ref option, ref exit);
        } while (!exit);
    }
    public void ConfigureConsole()
    {
        if (!GetLanguage)
            Console.Title = "Agenda 2018 - Contacts";
        else
            Console.Title = "Agenda 2018 - Contactos";
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        Console.CursorVisible = false;
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
    private void Add()
    {
        Console.Clear();
        contCamps = 0;
        config.WriteFore(options[contCamps], "white", false);
        string name = " ";
        try
        {
            name = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string email = " ";
        try
        {
            email = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string answer;
        int age = 0;
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                age = Convert.ToInt32(answer);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string telephone = " ";
        try
        {
            telephone = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string adress = " ";
        try
        {
            adress = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string country = "";
        try
        {
            country = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string observations = "";
        try
        {
            observations = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps = 0;

        listContact.Add(new Contact(
            name, email, age, telephone, adress, country, observations));
        listContact.Save();
    }
    private void Modify(int index)
    {
        Contact contactToModify = listContact.Get(index);

        Console.Clear();
        contCamps = 0;

        config.WriteFore(0, 4, options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Name);
        string answer;
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Name = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Email);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Email = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Age);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Age = Convert.ToInt32(answer);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Telephone);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Telephone = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Address);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Address = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], contactToModify.Country);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Country = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps],contactToModify.Observations);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                contactToModify.Observations = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        contCamps = 0;

        listContact.Set(index, contactToModify);
    }
    private void DisplayContactsList(ContactsList Contacts, int option)
    {
        string line = new string('-', Console.WindowWidth);
        string lineaAyuda1 =
            "1-Añadir  2-Modificar  3-Borrar  Arriba/Abajo-Cambiar  Esc-Salir";
        string helpLine1="1-Add  2-Modify  3-Delete  Up/Down-Change  Esc-Exit";
        string languageHelp;
        if (!GetLanguage)
            languageHelp = helpLine1;
        else
            languageHelp = lineaAyuda1;

        if (listContact.Count == 0)
        {
            SetConsoleEmpty();
            if (!GetLanguage)
            {
                Console.WriteLine("Not dates!");

                Console.Write("Do you want add first record(yes/no): ");
                string answer = "";
                try
                {
                    answer = Console.ReadLine();
                }
                catch (Exception)
                {
                    throw;
                }
                if (answer == "yes")
                    Add();
                else if (answer == "no")
                {
                    Console.WriteLine("Okey. See you!");
                    Console.WriteLine("Press ESC to return.");
                }
            }
            else
            {
                Console.WriteLine("No hay datos!");

                Console.Write("Quieres añadir el primer registro (si/no): ");
                string answer = "";
                try
                {
                    answer = Console.ReadLine();
                }
                catch (Exception)
                {
                    throw;
                }
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

            int x = 2;
            int y = 1;
            for (int i = 0; i < listContact.Count; i++)
            {
                config.WriteFore(x, y + i, "white");
                if (i == option - 1)
                {
                    config.WriteBack("green");
                    config.WriteFore(listContact.Contacts[i].Name + " (" +
                      listContact.Contacts[i].Telephone + ")", "white", false);
                }
                else
                {
                    config.WriteBack(listContact.Contacts[i].Name + " (" +
                       listContact.Contacts[i].Telephone + ")", "blue", false);
                }
                Console.ResetColor();
            }

            config.WriteBack("blue");
            config.WriteFore("white");
            config.WriteBack(0, (Console.WindowHeight - 4), line, false);
            config.WriteBack(Console.WindowWidth / 2 -
            (languageHelp.Length / 2), Console.WindowHeight - 3, 
            languageHelp, true);

            ShowContactCursor(Contacts, option);
        }
    }

    private void ShowContactCursor(ContactsList contacts, int option)
    {
        try
        {
            int contCamps = 0;
            config.WriteFore((Console.WindowWidth / 2 + 2), 4,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 4,
                checkVacio(listContact.Get(option).Name), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 7, 
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 7,
                checkVacio(listContact.Get(option).Email), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 8, 
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 8,
                checkVacio(listContact.Get(option).Age), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 10,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)),10,
                checkVacio(listContact.Get(option).Telephone), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 12,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)),12,
                checkVacio(listContact.Get(option).Address), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 14,
                options[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (options[contCamps].Length + 4)),14,
                checkVacio(listContact.Get(option).Country), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 16,
                options[contCamps], "white", false);
            config.WriteFore(
               (Console.WindowWidth / 2 + (options[contCamps].Length + 4)), 16,
               checkVacio(listContact.Get(option).Observations), "gray", true);
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
            return "(Por Confirmar)";
        else
        {
            return lineToCheck.ToString();
        }
    }
    private string checkVacio(int lineToCheck)
    {
        if (lineToCheck == 0)
            return "(Por Confirmar)";
        else
        {
            return lineToCheck.ToString();
        }
    }
    private void Delete(int option)
    {
        listContact.Delete(option - 1);
        Sort();
    }
    public void Sort()
    {
        listContact.Contacts.Sort();
    }
    
    public void GetChosenOption(ref ContactsList Contacts, ref int option, 
        ref bool exit)
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
            case ConsoleKey.Escape:
                exit = true;
                Contacts.Save();
                break;
            case ConsoleKey.DownArrow:
                if (option < Contacts.Count)
                    option++;
                else
                    option = 1;
                break;
            case ConsoleKey.UpArrow:
                if (option > 1)
                    option--;
                else
                    option = Contacts.Count;
                break;
            default:
                break;
        }
    }
}﻿//24/05/2018 - RaulGogna, V.01 Implemented all functions
//24/05/2018 - RaulGogna, V.02 Improve minor corrections of visualization
using System;
using System.Linq;
class ScreenNotes
{
    ConfigurationConsole config = new ConfigurationConsole();
    public NotesList notesList;
    public bool GetLanguage = MenuScreen.Spanish;
    public int numPages;

    public static string[] camps = {
    "Enter the note's title: " , "Enter the note's description: ",
    "Enter the note's category: ", "Enter the note's confidential: ",
    "Enter if the note is done: "};
    public static string[] campos = {
    "Introduce el título de la nota: ","Introduce la descripcion de la nota: ",
    "Introduce la categoría de la nota: ",
    "Introduce la confidencialida de la nota: ",
    "Introduce si la nota esta completada: "};
    public static string[] modifiEN = {
    "Enter new title (was {0})", "Enter new description (was {0})",
    "Enter new category (was {0})", "Enter new confidential (was {0})",
    "Enter if is done or not (was {0})"};
    public static string[] modifiES = {
    "Ingrese un nuevo título (era {0})",
    "Ingrese una nueva descripción (era {0})",
    "Ingrese una nueva categoría (era {0})",
    "Ingrese una nueva confidencialidad (era {0})",
    "Ingrese si está hecho o no la nota (era {0})"};
    public static string[] options;
    public static string[] optionsModi;
    public int contCamps = 0;

    //Function to split the description and do not pass half screen.
    public static string recStr1(string user)
    {
        if (user.Length < Console.WindowWidth / 2 - 2)
        {
            return user;
        }
        return user.Substring(0, Console.WindowWidth / 2 - 2)
            + "\n"
            + recStr1(user.Substring(Console.WindowWidth / 2 - 2));
    }

    public static string recStr2(string user1)
    {
        if (user1.Length < ((Console.WindowWidth / 2 + 38) - 2))
        {
            return user1;
        }
        return user1.Substring(0, Console.WindowWidth / 2 - 4)
            + "\n" + new string(' ', 42) 
            + recStr1(user1.Substring(Console.WindowWidth / 2 - 4));
    }

    public void Run()
    {
        ConfigureConsole();
        Console.Clear();
        notesList = new NotesList();
        numPages = notesList.Count;
        int option1 = 0;
        int option2 = 1;
        int changeNote = option1;
        bool exit = false;
        if (!GetLanguage)
        {
            options = camps;
            optionsModi = modifiEN;
        }
        else
        {
            options = campos;
            optionsModi = modifiES;
        }
        do
        {
            DisplayActualNote(notesList, option1, option2, changeNote);
            GetChosenOption(ref notesList, ref option1, ref option2, 
                ref changeNote, ref exit);
        } while (!exit);
    }
    public void ConfigureConsole()
    {
        if (!GetLanguage)
            Console.Title = "Agenda 2018 - Notes";
        else
            Console.Title = "Agenda 2018 - Notas";
        Console.SetBufferSize(80, 25);
        Console.SetWindowSize(80, 25);
        Console.CursorVisible = false;
    }
    private void SetConsole(NotesList notes, int option1, int option2,
        int changeNote)
    {
        Console.ResetColor();
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Blue;
        try
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
                //To draw bar vertical in middle of screen
                if (i < 23)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2), i);
                    Console.Write("|" + new string(' ',
                        Console.WindowWidth / 2 - 1));
                }
                if (i == 2 || i == 21)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(new string('-', (Console.WindowWidth / 2)));
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 1, i);
                    Console.Write(new string(
                        '-', (Console.WindowWidth / 2 - 1)));
                }
                if (i == 1)
                {//if option1 is different from changeNote,option1 is displayed
                    config.WriteBack((Console.WindowWidth / 2 - 20) -
                        notes.Notes[option1].Title.Length / 2, i,
                        notes.Notes[option1].Title, false);
                    if (numPages > 1)
                    {
                        if (notes.Notes[option2].Title !=
                            notes.Notes[option1].Title)
                            config.WriteBack((Console.WindowWidth - 20) -
                            notes.Notes[option2].Title.Length / 2, i,
                            notes.Notes[option2].Title, false);
                    }
                }

                if (i == 22)
                {
                    string page1;
                    string page2;
                    if (!GetLanguage)
                        page1 = "Page " + (option1 + 1) + " of " + numPages;
                    else
                        page1 = "Página " + (option1 + 1) + " de " + numPages;

                    config.WriteBack((Console.WindowWidth / 2 - 20) -
                        page1.Length / 2, i, page1, false);

                    Console.SetCursorPosition(Console.WindowWidth / 2 + 1, i);
                    Console.Write(new string(
                        ' ', Console.WindowWidth / 2 - 1));

                    if (numPages > 1)
                    {
                        if (!GetLanguage)
                            page2 = "Page " + (option2 + 1) + " of " +
                                numPages;
                        else
                            page2 = "Página " + (option2 + 1) + " de " + 
                                numPages;

                        config.WriteBack((Console.WindowWidth - 20) -
                        page2.Length / 2, i, page2, false);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
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
        contCamps = 0;
        Console.WriteLine(options[contCamps]);
        string title = "";
        try
        {
            title = Console.ReadLine();
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        Console.WriteLine(options[contCamps]);
        string description = "";
        try
        {
            description = Console.ReadLine();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        Console.WriteLine(options[contCamps]);
        string category = "";
        try
        {
            category = Console.ReadLine();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        Console.WriteLine(options[contCamps]);
        string confidential = "";
        try
        {
            confidential = Console.ReadLine().ToLower();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        Console.WriteLine(options[contCamps]);
        string answer = "";
        bool done = false;
        try
        {
            answer = Console.ReadLine().ToLower();
            if (answer == "yes")
                done = true;
            else if (answer == "no")
                done = false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps = 0;

        notesList.Add(new Note(title, description, category,
            confidential, done));
        notesList.Save();
    }

    public void Modify(int changeNote, int option1, int option2)
    {
        Note noteToModify = notesList.Get(changeNote + 1);
        string answer = "";
        Console.Clear();
        contCamps = 0;
        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], noteToModify.Title);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                noteToModify.Category = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(0, 4, options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        if(noteToModify.Description.Length > 10)
            Console.WriteLine(optionsModi[contCamps], 
                noteToModify.Description.Substring(0,10) + "...");
        else
            Console.WriteLine(optionsModi[contCamps],noteToModify.Description);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
            {
                if (changeNote == option2)
                    noteToModify.Description = recStr2(answer);
                else if (changeNote == option1)
                    noteToModify.Description = recStr1(answer);
            }
            if (changeNote == option2)
                noteToModify.Description = recStr2(noteToModify.Description);
            else if (changeNote == option1)
                noteToModify.Description = recStr1(noteToModify.Description);
        }
        catch (Exception)
        {

            throw;
        }
        
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], noteToModify.Category);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                noteToModify.Category = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], noteToModify.Confidential);
        answer = Console.ReadLine();
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                noteToModify.Confidential = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        if (!GetLanguage)
        {
            if (noteToModify.Done)
                Console.WriteLine(optionsModi[contCamps], "yes");
            else if (!noteToModify.Done)
                Console.WriteLine(optionsModi[contCamps], "no");
        }
        else
        {
            if (noteToModify.Done)
                Console.WriteLine(optionsModi[contCamps], "si");
            else if (!noteToModify.Done)
                Console.WriteLine(optionsModi[contCamps], "no");
        }
        try
        {
            answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "si")
                noteToModify.Done = true;
            else if (answer == "no")
                noteToModify.Done = false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        notesList.Set(changeNote, noteToModify);
    }

    public void DisplayActualNote(NotesList notes, int option1, int option2, 
        int changeNote)
    {
        string line = new string('-', Console.WindowWidth);
        string lineaAyuda1 = "1-Añadir  2-Modificar  3-Borrar  4- Categoria";
        string lineaAyuda2 = "<-- --> -Cambiar nota  Esc- Salir";
        string helpLine1 = "1- Add  2- Modify  3- Delete  4- Category";
        string helpLine2 = "<-- --> -Change note  Esc- Exit";
        string languageHelp, languageHelp2;

        if (!GetLanguage)
        {
            languageHelp = helpLine1;
            languageHelp2 = helpLine2;
        }
        else
        {
            languageHelp = lineaAyuda1;
            languageHelp2 = lineaAyuda2;
        }

        if (notes.Count == 0)
        {
            SetConsoleEmpty();
            if (!GetLanguage)
            {
                Console.WriteLine("Not dates!");
                Console.WriteLine("Do you want to add some task? (Yes/No)");
            }
            else
            {
                Console.WriteLine("No hay datos!");
                Console.WriteLine("Quieres añadir una tarea? (Si/No)");
            }
            string answer =  ""; 
            try
            {
                answer = Console.ReadLine().ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            if (answer == "yes" || answer == "si")
            {
                Add();
            }
            else if (answer == "no")
            {
                if (!GetLanguage)
                {
                    Console.WriteLine("Okey. See you!");
                    Console.WriteLine("Press ESC to return.");
                }
                else
                {
                    Console.WriteLine("Vale. Nos vemos!");
                    Console.WriteLine("Presione ESC para volver.");
                }
            }
        }
        else
        {
            try
            {
                SetConsole(notes, option1, option2, changeNote);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " +e.Message);
            }
            if(!GetLanguage)
                config.WriteBack(0, 2, "Completed notes: ", false);
            else
                config.WriteBack(0, 2, "Notas completadas: ", false);
            if(notes.Count > 1)
            {
                if (!GetLanguage)
                    config.WriteBack(Console.WindowWidth / 2 + 1, 2, 
                        "Completed notes: ", false);
                else
                    config.WriteBack(Console.WindowWidth / 2 + 1, 2, 
                        "Notas completadas: ", false);
            }
            int x = 0, y1 = 4, x2 = Console.WindowWidth / 2 + 2, y2 = 4;
            for (int i = 0; i < notesList.Count; i++)
            {
                if (notesList.Notes[i].Title ==
                    notesList.Notes[option1].Title &&
                    notesList.Notes[i].Category ==
                    notesList.Notes[option1].Category &&
                    notesList.Notes[i].Done == true)
                {
                    Console.SetCursorPosition(x, y1);
                    Console.WriteLine((y1 - 3) + "." +
                        recStr1(notesList.Notes[i].Description));
                    y1++;
                }
            }
            for (int i = 0; i < notesList.Count; i++)
            {
                if (notesList.Notes[i].Title ==
                    notesList.Notes[option2].Title &&
                    notesList.Notes[i].Category ==
                    notesList.Notes[option2].Category &&
                    notesList.Notes[i].Done == true)
                {
                    Console.SetCursorPosition(x2, y2);
                    Console.WriteLine((y2 - 3) + "." +
                        recStr2(notesList.Notes[i].Description));
                    y2++;
                }
            }
            config.WriteBack("blue");
            config.WriteFore("white");
            config.WriteBack(0, (Console.WindowHeight - 3), line, false);
            config.WriteBack(Console.WindowWidth / 2 -
            (languageHelp.Length / 2), Console.WindowHeight - 2, 
            languageHelp, false);
            config.WriteBack(Console.WindowWidth / 2 -
            (languageHelp2.Length / 2), Console.WindowHeight - 1, 
            languageHelp2, false);
        }
    }

    public void Delete(int changeNote)
    {
        notesList.Delete(changeNote);
    }

    public void Sort()
    {
        notesList.Notes.Sort();
    }

    public void GetChosenOption(ref NotesList notes, ref int option1, 
        ref int option2, ref int changeNote, ref bool exit)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.NumPad1: Add(); break;
            case ConsoleKey.NumPad2: Modify(changeNote,option1,option2);break;
            case ConsoleKey.NumPad3: Delete(option1); break;
            //case ConsoleKey.NumPad4: Search(); break;
            case ConsoleKey.Escape:
                exit = true;
                break;
            case ConsoleKey.LeftArrow:
                if (changeNote > 0)
                    changeNote--;
                else
                    changeNote = 0;
                break;
            case ConsoleKey.RightArrow:
                if (changeNote < notes.Count)
                    changeNote++;
                else
                    changeNote = notes.Count-1;
                break;
            default:
                break;
        }
    }
}﻿//18/05/2018 - RaulGogna, V.01 Show TasksToDo
//21/05/2018 - RaulGogna, V.02 Completed methods
using System;
class ScreenTasks
{
    public ConfigurationConsole config = new ConfigurationConsole();
    public TasksList tasks = new TasksList();
    public bool GetLanguage = MenuScreen.Spanish;
    public static string[] camps = { "Description:", "DateStart:", "DateDue:",
            "Category:", "Priority:", "Confidential:"};
    public static string[] campos = { "Descripcion:", "DataInicio:","DataFin:",
            "Categoria:", "Prioridad:", "Confidencial:"};
    public static string[] modifiEN = {
    "Enter new descrpition (was {0})", "Enter new dateStart (was {0})",
    "Enter new dateEnd (was {0})", "Enter new category (was {0})",
    "Enter new priority (was {0})", "Enter new confdential "};
    public static string[] modifiES = {
    "Ingrese una nueva descripción (era {0})",
    "Ingrese una nueva dataInicio (era {0})",
    "Ingrese una nueva dataFin (era {0})",
    "Ingrese una nueva categoria (era {0})",
    "Ingrese una nueva prioridad (era {0})",
    "Indique una nueva confidencialidad " };
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
        {
            options = camps;
            optionsModi = modifiEN;
        }
        else
        {
            options = campos;
            optionsModi = modifiES;
        }
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
        string description = "";
        try
        {
            description = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string dateStart = "";
        try
        {
            dateStart = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string dateDue = "";
        try
        {
            dateDue = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string category = "";
        try
        {
            category = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        string answer = "";
        int priority = 0;

        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                priority = Convert.ToInt32(answer);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        answer = Console.ReadLine().ToLower();
        bool confidential = false;
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
            {
                if (answer == "yes" || answer == "si")
                    confidential = true;
                else if (answer == "no")
                    confidential = false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps = 0;

        tasks.Add(new Task(
           description, dateStart, dateDue, category, priority, confidential));
        tasks.Save();
    }

    public void Modify(int index)
    {
        Task taskToModify = tasks.Get(index);

        Console.Clear();
        contCamps = 0;
        config.WriteFore(0, 4, options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Description);
        string answer = "";
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                taskToModify.Description = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.DateStart);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                taskToModify.DateStart = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.DateDue);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                taskToModify.DateDue = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Category);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                taskToModify.Category = answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        contCamps++;

        config.WriteFore(options[contCamps], "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(optionsModi[contCamps], taskToModify.Priority);
        try
        {
            answer = Console.ReadLine();
            if (answer != "")
                taskToModify.Priority = Convert.ToInt32(answer);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
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
        try
        {
            answer = Console.ReadLine();
            if (answer == "yes" || answer == "si")
                taskToModify.Confidential = true;
            else if (answer == "no")
                taskToModify.Confidential = false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

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
            "1-Añadir  2-Modificar  3-Borrar  Arriba/Abajo-Cambiar  Esc-Salir";
        string helpLine1="1-Add  2-Modify  3-Delete  Up/Down-Change  Esc-Exit";
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
                Console.WriteLine("Do you want to add some task? (Yes/No)");
            }
            else
            {
                Console.WriteLine("No hay datos!");
                Console.WriteLine("Quieres añadir una tarea? (Si/No)");
            }
            string answer;
            try
            {
                answer = Console.ReadLine().ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw;
            }
            if (answer == "yes" || answer == "si")
            {
                Add();
            }
            else if (answer == "no")
            {
                if (!GetLanguage)
                {
                    Console.WriteLine("Okey. See you!");
                    Console.WriteLine("Press ESC to return.");
                }
                else
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
                answer = "yes";
            else if (!lineToCheck)
                answer = "no";
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
//18/05/2018 - RaulGogna, V.01 Implemented constructor
using System;
[Serializable]
class Task : IComparable
{
    public string Description { get; set; }
    public string DateStart { get; set; }
    public string DateDue { get; set; }
    public string Category { get; set; }
    public int Priority { get; set; }
    public bool Confidential { get; set; }

    public Task(string description, string dateStart, string dateDue, 
        string category, int priority, bool confidential)
    {
        Description = description;
        DateStart = dateStart;
        DateDue = dateDue;
        Category = category;
        Priority = priority;
        Confidential = confidential;
    }
    public Task()
    {

    }

    public int CompareTo(Object t2)
    {
        return (Priority).CompareTo(
            ((Task)t2).Priority);
    }
}
//18-05-2018 - RaulGogna, V.01 Implemented methods
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class TasksList
{
    public List<Task> Tasks { get; set; }
    public int Count { get; set; }
    public TasksList()
    {
        Tasks = new List<Task>();
        Load();
        Count = Tasks.Count;
    }
    public void Add(Task taskToAdd)
    {
        Tasks.Add(taskToAdd);
        Count++;
    }
    public Task Get(int index)
    {
        try
        {
            return Tasks[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Task task)
    {
        try
        {
            if (n >= Tasks.Count || n < 0)
            {
                return;
            }
            else
            {
                Tasks[n - 1] = task;
                Save();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int o)
    {
        try
        {
            Tasks.RemoveAt(o);
            Count--;
        }
        catch (Exception)
        {
            return;
        }
    }
    public void Save()
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Tasks.dat", FileMode.Create, 
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Tasks);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Write fail ERROR: " + e.Message);
        }
    }

    public void Load()
    {
        if (File.Exists("Tasks.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Tasks.dat", FileMode.Open, 
                    FileAccess.Read, FileShare.Read);
                Tasks = (List<Task>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Read fail");
            }
        }
    }

}
//21/05/2018 - RaulGogna, V.01 Called run's method of ScreenTasks class
using System;
class TaskToDo
{
    public void Run()
    {
        ScreenTasks screenTasks = new ScreenTasks();
        screenTasks.Run();
    }
}// 15-05-2018 - RaulGogna, V.01
/*In this class we have created the welcome screen with a 
progression bar animation.*/

using System;
using System.Threading;

class WelcomeScreen : Screen
{
    public void Run()
    {
        Display();
    }

    public override void Display()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.Title = "Agenda 2018";
        string intro = "Agenda 2018";
        Console.SetCursorPosition(40 - intro.Length / 2, 4);
        Console.WriteLine(intro);

        string line = new string('-', Console.WindowWidth-6);
        string lineMiddle = new string(' ', Console.WindowWidth-8);
        double count = (100.0 / (Console.WindowWidth - 9));

        
        Console.SetCursorPosition(3, 13);
        Console.Write("Loading...");
        Console.SetCursorPosition(3,14);
        Console.Write(line);
        Console.SetCursorPosition(3, 15);
        Console.Write("|" + lineMiddle + "|");
        Console.SetCursorPosition(3, 16);
        Console.Write(line);
        int x = 0;
        int y = 15;
        Console.SetCursorPosition((int)x,y);
        do
        {
            if (x != 75)
            {
                Console.SetCursorPosition(x + 4, y);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
                Console.SetCursorPosition(3, 17);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine((int)count + "%");
                count += (100.0 / (Console.WindowWidth - 9));
                x++;
                Thread.Sleep(50);
            }
            
        } while (count < 101.0);
    }

}
