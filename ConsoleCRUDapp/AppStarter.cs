﻿using System;
using DataAccess;
using MasterClass;

namespace ConsoleCRUDapp
{
    public class AppStarter
    {
        static void Main(string[] args)
        {
			try
			{
                Utilities.ConsoleUtility.SetConsoleFont();

                // Views.MenuView.ShowStudentMenu();
                Views.MenuView.RootMenuDisplay();
                // DaStudent.AddStudent(DaStudent.SetStudentData());

                Console.ReadLine();
            }
			catch (Exception ex)
			{
                Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message.ToString());
                Console.ResetColor();
                Console.ReadLine();
			}
        }
    }
}
