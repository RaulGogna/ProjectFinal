//Raul Gogna
//v.01 Run the main menu
using System;
using System.Collections.Generic;
class Agenda
{
    public static void Run()
    {
        MenuScreen menu = new MenuScreen();
        menu.Run();
    }
    static void Main(string[] args)
    {
        Run();
    }
}