using System;
using System.Collections.Generic;
using System.Linq;
using MasterClass;

namespace DataAccess
{
    public class DaStudent
    {
        public static StudentModel _stdModel;
        private static string jPath = "students.json";

        private static JsonServices<StudentModel> objJSONService;

        public DaStudent()
        {
            objJSONService = new JsonServices<StudentModel>(jPath);
        }

        /// <summary>
        /// Setting up the Student Data for next Manipulation
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static StudentModel SetStudentData()
        {
            _stdModel = new StudentModel();
            try
            {
                Console.WriteLine($"\n\t[ Student Sr. No.: ");
                _stdModel.Id = int.Parse(Console.ReadLine());

                Console.WriteLine($"\n\t[ Student Name : ");
                _stdModel.Name = Console.ReadLine();

                Console.WriteLine($"\n\t[ Student Username (Must be unique): ");
                _stdModel.UserName = Console.ReadLine();

                Console.WriteLine($"\n\t[ Student Email-Id : ");
                _stdModel.Email = Console.ReadLine();

                Console.WriteLine($"\n\t[ Student Age : ");
                _stdModel.Age = int.Parse(Console.ReadLine());

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.SetStudentData()::{ex.Message}");
            }
            return _stdModel;
        }

        /// <summary>
        /// Display all Records of students
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static List<StudentModel> ListAllStudents()
        {
            //objJSONService = new JsonServices<StudentModel>(jPath);
            try
            {
                if(objJSONService == null)
                {
                    throw new Exception("#ERROR OCCURRED!!!\n\tObjects are empty, No Data found !!!");
                }
                else
                {
                    // List all students from JSON file
                    Console.WriteLine("Students from JSON:");
                    return objJSONService.GetAll();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.ListAllStudents()::{ex.Message}");
            }
        }
        public static int GetStudentIdByName(string name)
        {
            try
            {
                var students = objJSONService.GetAll();
                var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                return student?.Id ?? -1;
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GetStudentIdByName()::{ex.Message}");
            }
        }

        public static int GetStudentIdByEmail(string email)
        {
            try
            {
                var students = objJSONService.GetAll();
                var student = students.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
                return student?.Id ?? -1;
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GetStudentIdByEmail()::{ex.Message}");
            }
        }

        public static int GetStudentIdByUsername(string username)
        {
            try
            {
                var students = objJSONService.GetAll();
                var student = students.FirstOrDefault(s => s.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                return student?.Id ?? -1;
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GetStudentIdByUsername()::{ex.Message}");
            }
        }
        /// <summary>
        /// Getting Last Index of Record
        /// </summary>
        /// <returns><![CDATA[int ID (of Student)]]></returns>
        /// <exception cref="Exception"></exception>
        public static int GetLastStudentId()
        {
            try
            {
                var students = objJSONService.GetAll();
                return students.Count > 0 ? students.Max(s => s.Id) : 0;
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GetLastStudentId()::{ex.Message}");
            }
        }

        /// <summary>
        /// Generate new Student ID for New record Creation
        /// </summary>
        /// <returns><![CDATA[int ID]]></returns>
        /// <exception cref="Exception"></exception>
        public static int GenerateNewStudentId()
        {
            try
            {
                return GetLastStudentId() + 1;
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GenerateNewStudentId()::{ex.Message}");
            }
        }

        /// <summary>
        /// Displays the single record of Student
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public static void ShowStudent(int id)
        {
            try
            {
                var Student_ = objJSONService.GetById(id);

                foreach(var item in Student_.ToString())
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.ShowStudent()::{ex.Message}");
            }
        }

        /// <summary>
        /// Add New Record Of Student
        /// </summary>
        /// <param name="stdModel_"></param>
        /// <exception cref="Exception"></exception>
        public static void AddStudent(StudentModel stdModel_)
        {
            try
            {
                if(objJSONService != null)
                {
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Add a student to JSON file
                    objJSONService.Add(_stdModel);
                }
                else
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Add a student to JSON file
                    objJSONService.Add(_stdModel);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.AddStudent()::{ex.Message}");
            }
        }

        /// <summary>
        /// Updates the record and add it into existing JSON Object
        /// </summary>
        /// <param name="stdModel_"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateStudent(StudentModel stdModel_)
        {
            try
            {
                if(objJSONService != null)
                {
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Update a student to JSON file
                    objJSONService.Update(_stdModel);
                }
                else
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Update a student to JSON file
                    objJSONService.Update(_stdModel);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.UpdateStudent()::{ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the record from existing JSON Object
        /// </summary>
        /// <param name="stdModel_"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteStudent(StudentModel stdModel_)
        {
            try
            {
                if(objJSONService != null)
                {
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Delete a student from JSON file
                    var isDeleted = stdModel_ != null ? objJSONService.Delete(stdModel_.Id) : throw new Exception($"\n\tInvalid Record !!!\n\tPlease check further record...");
                    if(isDeleted)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\tRecord for student [{stdModel_.Id}] :: [ {stdModel_.Name} ] is deleted successfully");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\t#ERROR OCCURED\n\tRecord for student [{stdModel_.Id}] :: [ {stdModel_.Name} ] is not deleted");
                        Console.ResetColor();
                    }
                }
                else
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                    _stdModel = _stdModel != null ? stdModel_ : throw new Exception("Object of Student is null or empty !!!!");

                    // Delete a student from JSON file
                    var isDeleted = stdModel_ != null ? objJSONService.Delete(stdModel_.Id) : throw new Exception($"\n\tInvalid Record !!!\n\tPlease check further record...");
                    if(isDeleted)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\tRecord for student [{stdModel_.Id}] :: [ {stdModel_.Name} ] is deleted successfully");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\t#ERROR OCCURED\n\tRecord for student [{stdModel_.Id}] :: [ {stdModel_.Name} ] is not deleted");
                        Console.ResetColor();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.DeleteStudent()::{ex.Message}");
            }
        }
    }
}
