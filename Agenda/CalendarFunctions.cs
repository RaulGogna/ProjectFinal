//23/05/2018 - RaulGogna, V.01 Functions advanced of calendar
using System;
class CalendarFunctions
{
    public ScreenCalendar screenCal = new ScreenCalendar();
    public  void ChangeVisualization()
    {
        //To DO
    }

    public  void MoveArounTheCalendar()
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            case ConsoleKey.Enter:
                break;
            case ConsoleKey.LeftArrow:
                break;
            case ConsoleKey.UpArrow:
                break;
            case ConsoleKey.RightArrow:
                break;
            case ConsoleKey.DownArrow:
                break;
        }
    }
    public  void AddTasks()
    {
        //To DO
    }
    public  void AddEvent()
    {
        //To DO
    }
    public  void OpenDay()
    {
        Console.Clear();

        Console.WriteLine("What date do you want to see: ");
        string[] date = Console.ReadLine().Split('/');
        int day = Convert.ToInt32(date[0]);
        int month = Convert.ToInt32(date[1]);
        int year = Convert.ToInt32(date[2]);

        screenCal.ShowDay(day, month, year);
    }
}
