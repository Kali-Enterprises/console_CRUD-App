using System;
using DataAccess;
using MasterClass;

namespace ConsoleCRUDapp
{
    public class AppStarter
    {
        static void Main(string[] args)
        {
            Utilities.ConsoleUtility.SetConsoleFont();

            Views.MenuView.ShowStudentMenu();

            DaStudent.AddStudent(DaStudent.SetStudentData());
            DaStudent.ListAllStudents();

            Console.ReadLine();
        }
    }
}
