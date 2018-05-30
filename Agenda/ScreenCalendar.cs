﻿//28/05/2018 - RaulGogna, V.02 Show Tasks in the calendar
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
    public static int day, mounthD = 0, year = 0;
    public static DateTime dateActual = DateTime.Now;
    public bool selectedDay = false, cursorSelected = false;
    public static void GetCurrentMounth(
        ref int day, ref int month, ref int year)
    {
        string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
        day = dateActual.Day/*Convert.ToInt32(date[0])*/;
        month = dateActual.Month;
        year = dateActual.Year;
    }
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
        int xCursor = 23, yCursor = 8;
        do
        {
            DisplayCalendar(ref xCursor, ref yCursor, cursorSelected, exit);
            GetChosenOption(ref exit, ref xCursor, ref yCursor,
                ref selectedDay, ref cursorSelected);
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
        Console.ResetColor();
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
        foreach (Task c in tasksList.Tasks)
        {
            if (c.DateStart.Contains(date) &&
               c.Confidential == false)
                return true;
        }
        return false;
    }


    public void ShowDay(int dayS, int monthS, int yearS)
    {
        Console.Clear();
        DateTime searchDay = new DateTime();
        searchDay = new DateTime(yearS, monthS, dayS);

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

    //Para posicionamiento correcto de texto
    public void Daylessthan10(int i)
    {
        if (i < 10)
            Console.Write("  ");
        else
            Console.Write(" ");
    }
    public void DrawHeader(bool selectedCursor)
    {
        PrintMenu();
        //para comprobar solo una vez cada vez que se inicia opcion calendario
        if(!selectedCursor)
            GetCurrentMounth(ref day, ref mounthD, ref year);
        dateActual = new DateTime(year, mounthD, day);
        DaysInMonths(months, year);

        //Header
        string header = dateActual.ToString("MMMM yyyy",
            CultureInfo.CreateSpecificCulture("en-US"));
        string subHeader = "Mo   Tu   We   Th   Fr   Sa   Su";
        int size = (40 - header.Length / 2);
        int sizeSubHeader = (40 - subHeader.Length / 2);
        config.WriteBack("black");
        config.WriteFore("white");
        config.WriteBack(size, 3, header, true);
        config.WriteBack(sizeSubHeader, 6, subHeader, true);
    }
    public void DisplayCalendar(ref int xCursor, ref int yCursor, 
        bool selectedCursor, bool exit)
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
            //do while

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
            if (!cursorSelected && i == day && ContainsTasks(i, mounthD, year))
            {
                //Daylessthan10(i);
                //Contiene tareas y cursor encima del dia
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if(cursorSelected && i == day && ((x + k) == xCursor && 
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
                if(i > 9)
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
            if(myMonth.day.currentDay == 7)
                j += 2;
            Console.ResetColor();
        }
    }

    public void SearchDay()
    {
        Console.Clear();

        Console.WriteLine("What date do you want to see: ");
        string[] date = Console.ReadLine().Split('/');
        int day = Convert.ToInt32(date[0]);
        int month = Convert.ToInt32(date[1]);
        int year = Convert.ToInt32(date[2]);

        ShowDay(day, month, year);
    }

    public void GetChosenOption(ref bool exit, ref int xCursor,
        ref int yCursor, ref bool selectDay, ref bool cursorSelected)
    {
        ConsoleKeyInfo key;
        functions = new CalendarFunctions();
        int x = xCursor, y = yCursor;
        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable);

        switch (key.Key)
        {
            //case ConsoleKey.S: SearchDay(); break;
            case ConsoleKey.Escape: exit = true; break;
            /*case ConsoleKey.Enter:
                selectDay = true;
                functions.OpenDay();
                break;*/
            //case ConsoleKey.V: functions.ChangeVisualization(); break;
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
}