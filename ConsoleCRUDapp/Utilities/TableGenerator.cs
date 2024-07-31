using MasterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCRUDapp.Utilities
{
    /// <summary>
    /// Table Generator Class | UTILITY CLASS
    /// </summary>
    public static class TableGenerator
    {

        /// <summary>
        /// Displays the student model records as in table format
        /// </summary>
        /// <param name="students"></param>
        public static void DisplayStudentTable(List<StudentModel> students)
        {
            try
            {
                if (students == null || !students.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tNo students available to display.");
                    Console.ResetColor();
                    return;
                }

                // Get the maximum length of each column
                int idMaxLength = Math.Max("Id".Length, students.Max(s => s.Id.ToString().Length));
                int nameMaxLength = Math.Max("Name".Length, students.Max(s => s.Name.Length));
                int usernameMaxLength = Math.Max("Username".Length, students.Max(s => s.UserName.Length));
                int emailMaxLength = Math.Max("Email".Length, students.Max(s => s.Email?.Length ?? 0));
                int ageMaxLength = Math.Max("Age".Length, students.Max(s => s.Age.ToString().Length));

                string horizontalSeparatorUp = $"\t┌─{new string('─', idMaxLength)}─┬─{new string('─', nameMaxLength)}─┬─{new string('─', usernameMaxLength)}─┬─{new string('─', emailMaxLength)}─┬─{new string('─', ageMaxLength)}─┐";
                string horizontalSeparatorMid = $"\t├─{new string('─', idMaxLength)}─┼─{new string('─', nameMaxLength)}─┼─{new string('─', usernameMaxLength)}─┼─{new string('─', emailMaxLength)}─┼─{new string('─', ageMaxLength)}─┤";
                string horizontalSeparatorDown = $"\t└─{new string('─', idMaxLength)}─┴─{new string('─', nameMaxLength)}─┴─{new string('─', usernameMaxLength)}─┴─{new string('─', emailMaxLength)}─┴─{new string('─', ageMaxLength)}─┘";

                // Print the header
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(horizontalSeparatorUp);
                Console.WriteLine($"\t│ {"Id".PadCenter(idMaxLength)} │ {"Name".PadCenter(nameMaxLength)} │ {"Username".PadCenter(usernameMaxLength)} │ {"Email".PadCenter(emailMaxLength)} │ {"Age".PadCenter(ageMaxLength)} │");
                Console.WriteLine(horizontalSeparatorMid);
                Console.ResetColor();

                // Print each student
                foreach (var student in students)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t│ {student.Id.ToString().PadCenter(idMaxLength)} │ {student.Name.PadCenter(nameMaxLength)} │ {student.UserName.PadCenter(usernameMaxLength)} │ {student.Email?.PadCenter(emailMaxLength) ?? new string(' ', emailMaxLength)} │ {student.Age.ToString().PadCenter(ageMaxLength)} │");
                    Console.ResetColor();
                }

                Console.WriteLine(horizontalSeparatorDown);
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDApp.Utilities.TableGenerator.DisplayTable()::{ex.Message}");
            }
        }

        /// <summary>
        /// Method to centering the cell content in ASCII Table
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string PadCenter(this string str, int length)
        {
            try
            {
                int spaces = length - str.Length;
                int padLeft = spaces / 2 + str.Length;
                return str.PadLeft(padLeft).PadRight(length);
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDApp.Utilities.TableGenerator.PadCenter()::{ex.Message}");
            }
        }
    }
}
