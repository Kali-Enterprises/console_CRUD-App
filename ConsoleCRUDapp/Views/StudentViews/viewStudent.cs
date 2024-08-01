using DataAccess;
using MasterClass;
using System;
using System.Threading;

namespace ConsoleCRUDapp.Views.StudentViews
{
    public class viewStudent
    {
        public void ViewAllStudent()
        {
			try
			{
                Utilities.ConsoleUtility.ShowBanner("VIEW ALL STUDENTS", true, ConsoleColor.Cyan);
                Utilities.TableGenerator.DisplayStudentTable(DaStudent.ListAllStudents());
                Thread.Sleep(2000);
                Console.ReadLine();
            }
			catch(Exception ex)
			{
				throw new Exception($"\nConsoleCRUDapp.Views.StudentViews.viewStudent()::{ex.Message}");
			}
        }

        public void GetSingleStudent()
        {
            try
            {
                Utilities.ConsoleUtility.ShowBanner("VIEW STUDENT DETAILS", true, ConsoleColor.Cyan);
                Console.WriteLine("\tSearch and View from\n\tID / Name / Username / Email ::: [ 1 / 2 / 3 / 4 ]");
                int infoIndex = Int32.Parse(Console.ReadLine());

                if(infoIndex == 1 || infoIndex == 2 || infoIndex == 3 || infoIndex == 4)
                {
                    Console.WriteLine("\n\tEnter student info you want to view:");
                    string info = Console.ReadLine();

                    int id = 0;
                    if(infoIndex == 4)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByEmail(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.Email}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                        }
                    }
                    else if(infoIndex == 3)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByUserName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.UserName}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                        }
                    }
                    else if(infoIndex == 2)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
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
                        // Console.Clear();
                        if(infoIndex == 1)
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
                Thread.Sleep(2000);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.StudentViews.GetSingleStudent()::{ex.Message}");
            }
        }

        public void CreateNewStudent()
        {
            try
            {
                Utilities.ConsoleUtility.ShowBanner("ADD NEW STUDENT RECORD", true, ConsoleColor.Blue);
                DaStudent.SetStudentData();
                Thread.Sleep(2000);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.StudentViews.CreateNewStudent()::{ex.Message}");
            }
        }

        public void UpdateStudent()
        {
            int id = 0;
            StudentModel objUpdStdModel = new StudentModel();
            try
            {
                Utilities.ConsoleUtility.ShowBanner("MODIFIY STUDENT RECORD", true, ConsoleColor.Blue);
                Console.WriteLine("\tSearch and View from\n\tID / Name / Username / Email ::: [ 1 / 2 / 3 / 4 ]");
                int infoIndex = Int32.Parse(Console.ReadLine());

                if(infoIndex == 1 || infoIndex == 2 || infoIndex == 3 || infoIndex == 4)
                {
                    Console.WriteLine("\n\tEnter student info you want to view:");
                    string info = Console.ReadLine();
                    if(infoIndex == 4)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByEmail(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.Email}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                            Thread.Sleep(1000);
                        }

                    }
                    else if(infoIndex == 3)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByUserName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.UserName}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                        }
                    }
                    else if(infoIndex == 2)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name}");
                            }

                            Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
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
                        // Console.Clear();
                        if(infoIndex == 1)
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
                DataAccess.DaStudent.SetStudentData(DaStudent.OPERATION.UPDATE, id);

                Thread.Sleep(2000);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.StudentViews.UpdateStudent()::{ex.Message}");
            }
        }

        public void DeleteStudent()
        {
            int id = 0;
            StudentModel objUpdStdModel = new StudentModel();
            try
            {
                Utilities.ConsoleUtility.ShowBanner("REMOVE STUDENT RECORD", true, ConsoleColor.Red);
                Console.WriteLine("\tSearch and View from\n\tID / Name / Username / Email ::: [ 1 / 2 / 3 / 4 ]");
                int infoIndex = Int32.Parse(Console.ReadLine());
                 if(infoIndex == 1 || infoIndex == 2 || infoIndex == 3 || infoIndex == 4)
                {
                    Console.WriteLine("\n\tEnter student info you want to view:");
                    string info = Console.ReadLine();
                    if(infoIndex == 4)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByEmail(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.Email}");
                            }
                             Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                            Thread.Sleep(1000);
                        }
                     }
                    else if(infoIndex == 3)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByUserName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name} \t {student.UserName}");
                            }
                             Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
                        }
                        else
                        {
                            Console.WriteLine("No student found.");
                        }
                    }
                    else if(infoIndex == 2)
                    {
                        // Console.Clear();
                        var studentIds = DaStudent.GetStudentIdsByName(info);
                        if(studentIds.Count > 1)
                        {
                            Utilities.ConsoleUtility.ShowBanner("MULTIPLE FILTERED STUDENTS FOUND");
                            Console.WriteLine("\tPlease select one:");
                            for(int i = 0; i < studentIds.Count; i++)
                            {
                                var student = DaStudent.GetStudentById(studentIds[i]);
                                Console.WriteLine($"\t[ {i + 1} ] {student.Name}");
                            }
                             Console.WriteLine("\n\t [ SELECT ] ");
                            int choice = Int32.Parse(Console.ReadLine()) - 1;
                            if(choice >= 0 && choice < studentIds.Count)
                            {
                                DaStudent.ShowStudent(studentIds[choice]);
                                id = Convert.ToInt32(studentIds[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                        else if(studentIds.Count == 1)
                        {
                            DaStudent.ShowStudent(studentIds[0]);
                            id = Convert.ToInt32(studentIds[0]);
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
                        // Console.Clear();
                        if(infoIndex == 1)
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
                DataAccess.DaStudent.SetStudentData(DaStudent.OPERATION.DELETE, id);
                Thread.Sleep(2000);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.Views.StudentViews.DeleteStudent()::{ex.Message}");
            }
        }
    }
}