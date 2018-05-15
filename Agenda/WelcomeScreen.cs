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
                Thread.Sleep(100);
            }
            
        } while (count < 101.0);
    }

}
