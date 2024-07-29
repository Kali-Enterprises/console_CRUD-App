using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCRUDapp.Views
{
    public class MenuView
    {
        public enum MENUSET
        {
            ADD = 0,
            VIEWALL = 1,
            VIEWONE = 2,
            UPDATE = 3,
            DELETE = 4
        }

        public static readonly string[] StudentMenu = { "Manage Students", "View All Students", "View Student", "Add Student", "Update Student", "Delete Student" };
        public static readonly string[] TeacherMenu = { "Manage Teacher", "View All Teachers", "View Teacher", "Add Teacher", "Update Teacher", "Delete Teacher" };
        public static readonly string[] SchoolMenu = { "Manage School", "View All Schools", "View School", "Add School", "Update School", "Delete School" };
        public static readonly string[] ExamMenu = { "Manage Exam", "View All Exams", "View Exam", "Add Exam", "Update Exam", "Delete Exam" };

        public static void ShowStudentMenu()
        {
            string menu = string.Empty;
            Utilities.ConsoleUtility.ShowBanner(StudentMenu[0]);
            menu += $@"
    [1] {StudentMenu[1]}
    [2] {StudentMenu[2]}
    [3] {StudentMenu[3]}
    [4] {StudentMenu[4]}
    [5] {StudentMenu[5]}
        [ OPTION ] ::: ";
            Console.WriteLine(menu);
            // Console.SetCursorPosition(35, 12);

            int option_ = int.Parse(Console.ReadLine());
            switch(option_)
            {
                case 1:
                    //
                    break;
                case 2:
                    //
                    break;
                default:
                    break;
            }
        }
    }
}
