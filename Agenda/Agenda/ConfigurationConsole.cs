//16/05/2018 - RaulGogna, V.01 Implemented all functions of class
/*This class can change the background color and foregroundColor and save code
 in the all proyect.*/
using System;
class ConfigurationConsole
{
    public static string colorChangedBack = "greenD";
    public static string colorChangedFore = "blueD";
    public string SwitchBa(string color)
    {
        switch (color)
        {
            case "yellow":
                Console.BackgroundColor = ConsoleColor.Yellow;
                break;
            case "blue":
                Console.BackgroundColor = ConsoleColor.Blue;
                break;
            case "blueD":
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                break;
            case "red":
                Console.BackgroundColor = ConsoleColor.Red;
                break;
            case "green":
                Console.BackgroundColor = ConsoleColor.Green;
                break;
            case "greenD":
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                break;
            case "black":
                Console.BackgroundColor = ConsoleColor.Black;
                break;
            case "white":
                Console.BackgroundColor = ConsoleColor.White;
                break;
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
            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "blueD":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "greenD":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case "black":
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;
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


    /*public void Request(string text, int x, int y, string color, int length)
    {
        //To DO
    }
    */
    public string ChangeBackgroundColor(ref string colorChangedBack)
    {
        Console.Clear();
        Console.WriteLine("What background color do you want to put ? ");
        string color = Console.ReadLine();
        colorChangedBack = color;
        SwitchBa(colorChangedBack);
        return colorChangedBack;
    }
    public string ChangeColorFont(ref string colorChangedFore)
    {
        Console.Clear();
        Console.WriteLine("What foreground color do you want to put?");
        string color = Console.ReadLine();
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
        WriteFore(4, (Console.WindowHeight - 3), "Press ESC to Back", 
            (colorChangedFore = "blue"), false);
    }

    public void PrintMenu(int cursorOption)
    {
        int x = Console.WindowWidth / 2 - 15;
        int y = Console.WindowHeight / 2 - 2;
        string[] options = {"Change background color of screen",
                            "Change foreground color of fonts"};

        for (int i = 0; i < options.Length; i++)
        {
            //green
            WriteFore(x, y + i, (colorChangedBack = "white"));
            if (i == cursorOption - 1)
            {
                WriteBack(colorChangedBack = "green");
                WriteFore(colorChangedFore = "blue");
                Console.Write(options[i]);
            }
            else
            {
                WriteBack(colorChangedFore = "blueD");
                Console.Write(options[i]);
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
