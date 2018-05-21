//17/05/2018 - Brandom Blasco, V.01 Show Calendar
using System;
using System.Collections.Generic;
class Calendar
{
    MenuScreen menu;
    DateTime date = DateTime.Now;

    public void Run()
    {
        Display();
    }

    public void Display()
    {
        bool exit = false;
        int width = 40;
        int height = 10;
        string[] months = { "January", "February","March","April","May","June",
            "July","agost","September","October","November","December"};
        string[] days = {"Monday", "Tuesday","Wednesday","Thursday","Friday",
            "Saturday","Sunday"};
        string line = new string('-', width);
        do
        {
            Console.Clear();
            Console.SetCursorPosition(35, 5);
            Console.WriteLine(months[date.Month] + " - " + date.Year);

            Console.SetCursorPosition(14, 10);
            for (int i = 0; i < 6; i++)
            {
                Console.Write(days[i] + "  ");
            }
            Console.SetCursorPosition(15, 13);
            Console.Write(date.Day);

        } while (!exit);
        menu = new MenuScreen();
        menu.Run();
    }

    public void SelectDay()
    {

    }
}
