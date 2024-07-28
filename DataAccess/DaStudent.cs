using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MasterClass;

namespace DataAccess
{
    public class DaStudent
    {
        public static StudentModel _stdModel;
        private static string jPath = "students.json";
        private static string xPath = "students.xml";
        private JsonServices<StudentModel> objJSONService;
        private XmlServices<StudentModel> objXMLService;

        public DaStudent()
        {
            objJSONService = new JsonServices<StudentModel>(jPath);
            objXMLService = new XmlServices<StudentModel>(xPath);
        }
        public void ListAllStudents()
        {
            if (objJSONService != null && objXMLService != null)
            {
                // List all students from JSON file
                Console.WriteLine("Students from JSON:");
                foreach (var student in objJSONService.GetAll())
                {
                    Console.WriteLine($"{student.Id}: {student.Name}, {student.Age} years old");
                }

                // List all students from XML file
                Console.WriteLine("Students from XML:");
                foreach (var student in objXMLService.GetAll())
                {
                    Console.WriteLine($"{student.Id}: {student.Name}, {student.Age} years old");
                }
            }
            else
            {
                throw new Exception("#ERROR OCCURRED!!!\n\tObjects are empty, No Data found !!!");
            }
        }
        public void ShowStudent(int id)
        {
        }
        public void AddStudent()
        {
            _stdModel = new StudentModel()
            {
                Id = 1,
                Name = "John Doe",
                Age = 20
            };

            // Add a student to JSON file
            objJSONService.Add(_stdModel);

            // Add a student to XML file
            objXMLService.Add(_stdModel);
        }
        public void UpdateStudent()
        {
            // Update a student in JSON file
            _stdModel.Name = "John Updated";
            objJSONService.Update(_stdModel);

            // Update a student in XML file
            _stdModel.Name = "Jane Updated";
            objXMLService.Update(_stdModel);
        }
        public void DeleteStudent()
        {
            // Delete a student from JSON file
            objJSONService.Delete(1);

            // Delete a student from XML file
            objXMLService.Delete(2);
        }
    }
}
