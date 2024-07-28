using System;

namespace ConsoleCRUDapp
{
    public class AppStarter
    {
        static void Main(string[] args)
        {
            Utilities.ConsoleUtility.SetConsoleFont();

            Views.MenuView.ShowStudentMenu();

            Console.ReadLine();
        }
    }
}
