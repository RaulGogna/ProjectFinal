//22/05/2018 - RaulGogna, V.01 Completed methods
using System;
class ScreenContacts
{
    ConfigurationConsole config = new ConfigurationConsole();
    public ContactsList listContact;

    public void Run()
    {
        ConfigureConsole();
        listContact = new ContactsList();
        int option = 1;
        bool exit = false;
        do
        {
            DisplayContactsList(listContact, option);
            GetChosenOption(ref listContact, ref option, ref exit);
        } while (!exit);
    }
    public void ConfigureConsole()
    {
        Console.Title = "Agenda 2018 - Contacts";
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

        config.WriteFore("Name: ", "white", false);
        string name = Console.ReadLine();

        config.WriteFore("Email: ", "white", false);
        string email = Console.ReadLine();

        config.WriteFore("Age: ", "white", false);
        string answer = Console.ReadLine();
        int age = 0;
        if (answer != "")
            age = Convert.ToInt32(answer);

        config.WriteFore("Telephone: ", "white", false);
        string telephone = Console.ReadLine();

        config.WriteFore("Address: ", "white", false);
        string adress = Console.ReadLine();

        config.WriteFore("Country: ", "white", false);
        string country = Console.ReadLine();

        config.WriteFore("Observations: ", "white", false);
        string observations = Console.ReadLine();

        listContact.Add(new Contact(
            name, email, age, telephone, adress, country, observations));
        listContact.Save();
    }
    private void Modify(int index)
    {
        Contact contactToModify = listContact.Get(index);

        Console.Clear();


        config.WriteFore(0, 4, "Name: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new name (was {0}):",
            contactToModify.Name);
        string answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Name = answer;

        config.WriteFore("Email: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new email (was {0})",
            contactToModify.Email);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Email = answer;

        config.WriteFore("Age: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new age (was {0})",
            contactToModify.Age);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Age = Convert.ToInt32(answer);

        config.WriteFore("Telephone: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new telephone (was {0})",
            contactToModify.Telephone);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Telephone = answer;

        config.WriteFore("Address: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new address (was {0})",
            contactToModify.Address);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Address = answer;

        config.WriteFore("Country: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new country (was {0})",
            contactToModify.Country);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Country = answer;

        config.WriteFore("Observations: ", "white", false);
        Console.Write("  ");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter new observations (was {0})",
            contactToModify.Observations);
        answer = Console.ReadLine();
        if (answer != "")
            contactToModify.Observations = answer;

        listContact.Set(index, contactToModify);
    }
    private void DisplayContactsList(ContactsList Contacts, int option)
    {
        string line = new string('-', Console.WindowWidth);
        string helpLine1 = "1-Add  2-Modify  3-Delete  4-Search  Esc-Exit";
        string helpLine2 = "7-Listados";

        if (listContact.Count == 0)
        {
            SetConsoleEmpty();

            Console.WriteLine("Not dates");

            Console.Write("Do you want add first record(yes/no): ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
                Add();
            else if (answer == "no")
            {
                Console.WriteLine("Okey. See you!");
                Console.WriteLine("Press Esc to return.");
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
                if (i == option - 1)///
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
            (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1, true);
            config.WriteBack(Console.WindowWidth / 2 -
            (helpLine2.Length / 2), Console.WindowHeight - 2, helpLine2, true);

            //Program body
            ShowContactCursor(Contacts, option);
        }
    }

    private void ShowContactCursor(ContactsList contacts, int option)
    {
        string[] camps = { "Name:", "Email:", "Age:",
            "Telephone:", "Address:", "Country:", "Observations:"};

        try
        {
            int contCamps = 0;
            config.WriteFore((Console.WindowWidth / 2 + 2), 4,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 4,
                checkVacio(listContact.Get(option).Name), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 7,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 7,
                checkVacio(listContact.Get(option).Email), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 8,camps[contCamps],
                "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 8,
                checkVacio(listContact.Get(option).Age), "gray", true);
            contCamps++;

            Console.WriteLine();
            config.WriteFore((Console.WindowWidth / 2 + 2), 10,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 10,
                checkVacio(listContact.Get(option).Telephone), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 12,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 12,
                checkVacio(listContact.Get(option).Address), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 14,
                camps[contCamps], "white", false);
            config.WriteFore(
                (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 14,
                checkVacio(listContact.Get(option).Country), "gray", true);
            contCamps++;

            config.WriteFore((Console.WindowWidth / 2 + 2), 16,
                camps[contCamps], "white", false);
            config.WriteFore(
               (Console.WindowWidth / 2 + (camps[contCamps].Length + 4)), 16,
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
            //case ConsoleKey.NumPad4: Search(); break;
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
    public void GetImports()
    {
        //o DO
    }
}