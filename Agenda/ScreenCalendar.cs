//28/05/2018 - RaulGogna, V.02 Show Tasks in the calendar
//23/05/2018 - RaulGogna, V.01 Display Calendar
using System;
using System.Collections.Generic;
using System.Globalization;


class ScreenCalendar
{
    CalendarFunctions functions;
    ConfigurationConsole config;
    public List<Month> months = new List<Month>();
    public static TasksList tasksList = new TasksList();
    public struct Month
    {
        //num dias
        public int days;
        public Day day;
        public string monthName;
        //num mes
        public int numMonth;
        public int year;
    }
    public struct Day
    {
        //num.dia del mes
        public int dayOfMonth;
        //dias de la semana(0-6)
        public int currentDay;
    }

    public void Run()
    {
        config = new ConfigurationConsole();
        bool exit = false;
        SetConsole();
        PrintMenu();
        do
        {
            DisplayCalendar();
            GetChosenOption(ref exit);
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
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void PrintMenu()
    {
        SetConsole();

        string line = new string('-', Console.WindowWidth);
        string helpLine1 = "Esc-Exit  V-Visualization  S-Search  " +
            "Enter-Open Day";

        config.WriteBack("black");
        config.WriteFore("white");
        config.WriteBack(0, (Console.WindowHeight - 4), line, false);
        config.WriteBack(Console.WindowWidth / 2 -
            (helpLine1.Length / 2), Console.WindowHeight - 3, helpLine1,
            "black", true);
        /*config.WriteBack(Console.WindowWidth / 2 -
            (helpLine2.Length / 2), Console.WindowHeight - 2, helpLine2, true);*/
    }
    public bool ContainsTasks(int diaTask, int mesTask, int añoTask)
    {
        string date = diaTask.ToString() + "/" + mesTask.ToString() + "/"
            + añoTask.ToString();
        for (int i = 0; i < tasksList.Count; i++)
        {
            if (tasksList.Tasks[i].DateStart.Contains(date) &&
               tasksList.Tasks[i].Confidential == false)
                return true;
        }
        return false;
    }

    public void ShowDay(int dayS, int monthS, int yearS)
    {
        Console.Clear();
        DateTime searchDay = new DateTime();
        searchDay = new DateTime(
            Convert.ToInt32(dayS.ToString("dd")),
            Convert.ToInt32(monthS.ToString("MM")),
            Convert.ToInt32(yearS.ToString("yyyy")));

        SetConsole();

        Console.WriteLine(months[monthS].numMonth);
    }
    public void DaysInMonths(List<Month> months, int year)
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

    public void DisplayCalendar()
    {

        DateTime startDate = new DateTime();
        int day = 0, month = 0, year = 0;


        CurrentDay(ref day, ref month, ref year);
        startDate = new DateTime(year, month, 1);

        DaysInMonths(months, year);

        //Header

        string header = startDate.ToString("MMMM yyyy",
            CultureInfo.CreateSpecificCulture("en-US"));
        string subHeader = "Mo   Tu   We   Th   Fr   Sa   Su";
        int size = (40 - header.Length / 2);
        int sizeSubHeader = (40 - subHeader.Length / 2);
        config.WriteBack("black");
        config.WriteFore("white");
        config.WriteBack(size, 3, header, true);
        config.WriteBack(sizeSubHeader, 6, subHeader, true);

        Month myMonth = months[month - 1];

        int j = 0;
        for (int i = 1; i <= months[month - 1].days; i++)
        {

            DateTime dia1 = new DateTime(year, month, i);
            myMonth.day.dayOfMonth = i;
            if (Convert.ToInt32(dia1.DayOfWeek) == 0)
                myMonth.day.currentDay = 7;
            else
                myMonth.day.currentDay = Convert.ToInt32(dia1.DayOfWeek);

            months[month - 1] = myMonth;
            int x = 23, y = 8;
            switch (myMonth.day.currentDay)
            {
                case 1: Console.SetCursorPosition(x, y + j); break;
                case 2: Console.SetCursorPosition(x + 5, y + j); break;
                case 3: Console.SetCursorPosition(x + 10, y + j); break;
                case 4: Console.SetCursorPosition(x + 15, y + j); break;
                case 5: Console.SetCursorPosition(x + 20, y + j); break;
                case 6: Console.SetCursorPosition(x + 25, y + j); break;
                case 7: Console.SetCursorPosition(x + 30, y + j); break;
                default:
                    break;
            }
            if (ContainsTasks(i, month, year))
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
                Console.BackgroundColor = ConsoleColor.Black;

            if (myMonth.day.currentDay == 7)
            {
                j += 2;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {
                if (myMonth.day.currentDay == 6)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
            }

            if (i < 9)
                Console.Write("  {0}", i);
            else
                Console.Write(" {0}", i);

        }
        Console.ResetColor();
    }
    //////
    public void CurrentDay(ref int day, ref int month, ref int year)
    {
        string[] dateCurrent = DateTime.Today.ToString("dd/MM/yyyy").Split('/');
        day = Convert.ToInt32(dateCurrent[0]);
        month = Convert.ToInt32(dateCurrent[1]);
        year = Convert.ToInt32(dateCurrent[2]);
    }
    public void CurrentDay()
    {
        Console.Clear();

        Console.WriteLine("What date do you want to see: ");
        string[] date = Console.ReadLine().Split('/');
        int day = Convert.ToInt32(date[0]);
        int month = Convert.ToInt32(date[1]);
        int year = Convert.ToInt32(date[2]);

        ShowDay(day, month, year);
    }


    public void GetChosenOption(ref bool exit)
    {
        ConsoleKeyInfo key;
        functions = new CalendarFunctions();

        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            //case ConsoleKey.S: functions.SearchByDay(); break;
            case ConsoleKey.Escape: exit = true; break;
            case ConsoleKey.Enter: functions.OpenDay(); break;
            case ConsoleKey.V: functions.ChangeVisualization(); break;
            default:
                break;
        }
    }
}
