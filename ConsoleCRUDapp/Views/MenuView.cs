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

        public static void RootMenuDisplay()
        {
            try
            {
/*                while (true)
                {*/
                    ShowStudentMenu();
                    int option_ = Int32.Parse(Console.ReadLine());
                    
                    switch (option_)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n");
                            Utilities.ConsoleUtility.ShowBanner("VIEW ALL STUDENTS", true, ConsoleColor.Cyan);
                            Utilities.TableGenerator.DisplayStudentTable(DaStudent.ListAllStudents());
                            break;
                        case 2:
                            Console.Clear();
                            Utilities.ConsoleUtility.ShowBanner("VIEW STUDENT DETAILS", true, ConsoleColor.Cyan);
                            Console.WriteLine("\tSearch and View from\n\tID / Name / Username / Email ::: [ 1 / 2 / 3 / 4 ]");
                            int infoIndex = Int32.Parse(Console.ReadLine());

                            if (infoIndex == 1 || infoIndex == 2 || infoIndex == 3 || infoIndex == 4)
                            {
                                Console.WriteLine("\n\tEnter student info you want to view:");
                                string info = Console.ReadLine();

                                int id = 0;
                                if (infoIndex == 4)
                                {
                                    Console.Clear();
                                    var studentIds = DaStudent.GetStudentIdsByEmail(info);
                                    if (studentIds.Count > 1)
                                    {
                                        Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                                        Console.WriteLine("\tPlease select one:");
                                        for (int i = 0; i < studentIds.Count; i++)
                                        {
                                            var student = DaStudent.GetStudentById(studentIds[i]);
                                            Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.Email}");
                                        }

                                        Console.WriteLine("\n\t [ SELECT ] ");
                                        int choice = Int32.Parse(Console.ReadLine()) - 1;
                                        if (choice >= 0 && choice < studentIds.Count)
                                        {
                                            DaStudent.ShowStudent(studentIds[choice]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid choice.");
                                        }
                                    }
                                    else if (studentIds.Count == 1)
                                    {
                                        DaStudent.ShowStudent(studentIds[0]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No student found.");
                                    }
                                }
                                else if (infoIndex == 3)
                                {
                                    Console.Clear();
                                    var studentIds = DaStudent.GetStudentIdsByUserName(info);
                                    if (studentIds.Count > 1)
                                    {
                                        Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                                        Console.WriteLine("\tPlease select one:");
                                        for (int i = 0; i < studentIds.Count; i++)
                                        {
                                            var student = DaStudent.GetStudentById(studentIds[i]);
                                            Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.UserName}");
                                        }

                                        Console.WriteLine("\n\t [ SELECT ] ");
                                        int choice = Int32.Parse(Console.ReadLine()) - 1;
                                        if (choice >= 0 && choice < studentIds.Count)
                                        {
                                            DaStudent.ShowStudent(studentIds[choice]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid choice.");
                                        }
                                    }
                                    else if (studentIds.Count == 1)
                                    {
                                        DaStudent.ShowStudent(studentIds[0]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No student found.");
                                    }
                                }
                                else if (infoIndex == 2)
                                {
                                    Console.Clear();
                                    var studentIds = DaStudent.GetStudentIdsByName(info);
                                    if (studentIds.Count > 1)
                                    {
                                        Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                                        Console.WriteLine("\tPlease select one:");
                                        for (int i = 0; i < studentIds.Count; i++)
                                        {
                                            var student = DaStudent.GetStudentById(studentIds[i]);
                                            Console.WriteLine($"\t[ {i + 1} ] {student.Name}");
                                        }

                                        Console.WriteLine("\n\t [ SELECT ] ");
                                        int choice = Int32.Parse(Console.ReadLine()) - 1;
                                        if (choice >= 0 && choice < studentIds.Count)
                                        {
                                            DaStudent.ShowStudent(studentIds[choice]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid choice.");
                                        }
                                    }
                                    else if (studentIds.Count == 1)
                                    {
                                        DaStudent.ShowStudent(studentIds[0]);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Utilities.ConsoleUtility.ShowBanner("No student found.", true, ConsoleColor.Red);
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    if (infoIndex == 1)
                                    {
                                        id = Int32.Parse(info);
                                        DaStudent.ShowStudent(id);
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("#ERROR OCCURRED\n\tUser selected invalid option or trying to get invalid id of student !!!");
                            }
                            break;
                    case 3:
                        break;

                    case 4:
                        break;
                    default:
                        Console.WriteLine();
                        break;
                    }
                //}
            }
            catch (Exception ex)
            {
                throw;
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

    }
}
