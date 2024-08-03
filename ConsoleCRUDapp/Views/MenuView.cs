using DataAccess;
using MasterClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCRUDapp.Views
{
    public class MenuView
    {
        public static readonly string[] StudentMenu = { "Manage Students", "View All Students", "View Student", "Add Student", "Update Student", "Delete Student" };
        public static readonly string[] TeacherMenu = { "Manage Teacher", "View All Teachers", "View Teacher", "Add Teacher", "Update Teacher", "Delete Teacher" };
        public static readonly string[] SchoolMenu = { "Manage School", "View All Schools", "View School", "Add School", "Update School", "Delete School" };
        public static readonly string[] ExamMenu = { "Manage Exam", "View All Exams", "View Exam", "Add Exam", "Update Exam", "Delete Exam" };

        public static void RootMenuDisplay()
        {
            StudentViews.viewStudent objViews = new StudentViews.viewStudent();
            try
            {
                var menu = new Dictionary<string, Action>()
                {
                    { "1", objViews.ViewAllStudent },
                    { "2", objViews.GetSingleStudent },
                    { "3", objViews.CreateNewStudent },
                    { "4", objViews.UpdateStudent },
                    { "5", objViews.DeleteStudent },
                    { "6", MenuView.Exit }
                };
                while (true)
                {
                    ShowStudentMenu();
                    var option_ = Console.ReadLine();

                    if(menu.ContainsKey(option_))
                    {
                        Console.Clear();
                        menu[option_].Invoke();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\n\t#ERROR\n\tInvalid option selected !!!!!");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.MenuView.RootMenuDisplay()::{ex.Message}");
            }
        }

        /// <summary>
        /// Student Menu Template
        /// </summary>
        public static void ShowStudentMenu()
        {
            string menu = string.Empty;

            Console.Clear();
            Utilities.ConsoleUtility.ShowBanner(StudentMenu[0]);
            menu += $@"
    [1] {StudentMenu[1]}
    [2] {StudentMenu[2]}
    [3] {StudentMenu[3]}
    [4] {StudentMenu[4]}
    [5] {StudentMenu[5]}
    [6] Go to back menu
        [ OPTION ] ::: ";
            Console.WriteLine(menu);
            Console.SetCursorPosition(25, 11);
        }
        
        public static void Exit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Utilities.ConsoleUtility.ShowBanner("ARE YOU WANT TO EXIT ??");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t\tPress 'Y' to Yes or 'N' to No:");

                Console.ResetColor();
                char xOption = Convert.ToChar(Console.ReadLine());
                if (xOption == 'Y' || xOption == 'y')
                {
                    Environment.Exit(0);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.MenuView.Exit()::{ex.Message}");
            }
        }
    }
}
