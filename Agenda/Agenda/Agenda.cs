//Raul Gogna
//14/05/2018 - RaulGogna, V.01 Run the main menu
//15/05/2018 - RaulGogna, V.02 Run the WelcomeScreen

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