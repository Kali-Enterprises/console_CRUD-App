using System;
using System.Collections.Generic;
using System.Linq;
using MasterClass;

namespace DataAccess
{
    public class DaStudent
    {
        private static string jPath = "students.json";
        public static StudentModel _stdModel;
        private static JsonServices<StudentModel> objJSONService = new JsonServices<StudentModel>(jPath);

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
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                    return objJSONService.GetAll();
                }
                else
                {
                    return objJSONService.GetAll();
                }
                // throw new Exception("#ERROR OCCURRED!!!\n\tObjects are empty, No Data found !!!");
            }
            catch (Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.ListAllStudents()::{ex.Message}");
            }
        }
        // ----------------------------------------------------------------------------------------
        /// <summary>
        /// Getting Multiple Filtered Records
        /// </summary>
        /// <param name="name"></param>
        /// <returns><![CDATA[List<int> ListOfIds]]></returns>
        /// <exception cref="Exception"></exception>
        public static List<int> GetStudentIdsByName(string name)
        {
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                }
                var students = objJSONService.GetAll();
                if (!String.IsNullOrEmpty(name))
                {
                    var matchingStudents = students
                        .Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Select(s => s.Id)
                        .ToList();
                    return matchingStudents;
                }
                return new List<int>();
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.DaStudent.GetStudentIdsByName()::{ex.Message}");
            }
        }
        /// <summary>
        /// Getting Multiple Filtered Records
        /// </summary>
        /// <param name="username"></param>
        /// <returns><![CDATA[List<int> ListOfIds]]></returns>
        /// <exception cref="Exception"></exception>
        public static List<int> GetStudentIdsByUserName(string username)
        {
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                }
                var students = objJSONService.GetAll();
                if (!String.IsNullOrEmpty(username))
                {
                    var matchingStudents = students
                        .Where(s => s.UserName.IndexOf(username, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Select(s => s.Id)
                        .ToList();
                    return matchingStudents;
                }
                return new List<int>();
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.DaStudent.GetStudentIdsByUserName()::{ex.Message}");
            }
        }
        /// <summary>
        /// Getting Multiple Filtered Records
        /// </summary>
        /// <param name="email"></param>
        /// <returns><![CDATA[List<int> ListOfIds]]></returns>
        /// <exception cref="Exception"></exception>
        public static List<int> GetStudentIdsByEmail(string email)
        {
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                }
                var students = objJSONService.GetAll();
                if (!String.IsNullOrEmpty(email))
                {
                    var matchingStudents = students
                        .Where(s => s.Email.IndexOf(email, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Select(s => s.Id)
                        .ToList();
                    return matchingStudents;
                }
                return new List<int>();
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.DaStudent.GetStudentIdsByEmail()::{ex.Message}");
            }
        }
        public static StudentModel GetStudentById(int id)
        {
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                }
                return objJSONService.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"DataAccess.DaStudent.GetStudentById()::{ex.Message}");
            }
        }
        // ------------------------------------------------------------------------------------------------------------------
        public static int GetStudentIdByName(string name)
        {
            try
            {
                if (objJSONService == null)
                {
                    objJSONService = new JsonServices<StudentModel>(jPath);
                }
                var students = objJSONService.GetAll();
                if (!String.IsNullOrEmpty(name))
                {
                    var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    return student?.Id ?? -1;
                }
                return 0;
            }
            catch(Exception ex)
            {
                return 0;
                throw new Exception($"DataAccess.DaStudent.GetStudentIdByName()::{ex.Message}");
            }
        }
        /// <summary>
        /// To Get Student ID By Users Email Address
        /// </summary>
        /// <param name="email"></param>
        /// <returns><![CDATA[int Id]]></returns>
        /// <exception cref="Exception"></exception>
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
                throw new Exception($"\nDataAccess.DaStudent.GetStudentIdByEmail()::{ex.Message}");
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
                StudentModel Student_ = objJSONService.GetById(id);

                string std_ = $"\n\t[ ID: {Student_.Id} ]";
                std_ += $"\n\tStudent Name     : {Student_.Name}";
                std_ += $"\n\tStudent UserName : {Student_.UserName}";
                std_ += $"\n\tStudent Email    : {Student_.Email}";
                std_ += $"\n\tStudent Age      : {Student_.Age.ToString()}\n";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(std_);
                Console.ResetColor();
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
