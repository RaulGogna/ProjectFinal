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
