//Show TasksToDo - V.01
using System;
class ScreenTasks
{
    public void Run()
    {
        TasksList Tasks = new TasksList();
        int count = 1;
        bool exit = false;
        do
        {
            DisplayTaskActual(Tasks, count);
            GetChosenOption(ref count, ref Tasks, ref exit);
        } while (!exit);
    }
    private void Add()
    {
        //To DO
    }

    private void Modify()
    {
        //To DO
    }

    private void Delete()
    {
        //To DO
    }

    private void Sort()
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
    }
    private void GetChosenOption(ref int count, ref TasksList Task, 
        ref bool exit)
    {
        
    }

    private void ShowInCalendar()
    {
        //To DO
    }
}
