//Raul Gogna
//v.01 Run the main menu
//v.02 Run the WelcomeScreen
using System;
using System.Collections.Generic;
class Agenda
{
    public static void Run()
    {
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Run();
        MenuScreen menu = new MenuScreen();
        menu.Run();
    }
    static void Main(string[] args)
    {
        Run();
    }
}