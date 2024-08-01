using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    public class JsonServices<T>
    {
        /// <summary>
        /// JSON file path which is used as a DataBase
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Constructor method for JsonServices<T> Service Class
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="Exception"></exception>
        public JsonServices(string filePath)
        {
            try
            {
                // Get the application root path
                string appRootPath = AppDomain.CurrentDomain.BaseDirectory;

                // Construct the full path to the file
                _filePath = Path.Combine(appRootPath, "DATA", filePath);

                // Ensure the directory exists
                string directoryPath = Path.GetDirectoryName(_filePath);
                if(!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                // _filePath = filePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.JsonServices[CONSTRUCTOR]::{ex.Message}");
            }
        }

        /// <summary>
        /// Method to get all Records from JSON File
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<T> GetAll()
        {
            try
            {
                if (!File.Exists(_filePath)) return new List<T>();

                var jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.GetAll()::{ex.Message}");
            }
        }

        /// <summary>
        /// Method to get Record from JSON File where id is equivalent to user input
        /// </summary>
        /// <param name="id"></param>
        /// <returns><![CDATA[T: where T is any type of value]]></returns>
        /// <exception cref="Exception"></exception>
        public T GetById(int id)
        {
            try
            {
                var items = GetAll();
                return items.Find(item => (int)typeof(T).GetProperty("Id")?.GetValue(item) == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.GetById()::{ex.Message}");
            }
        }

        /// <summary>
        /// Create and Add New Record into JSON File
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public bool Add(T item)
        {
            var items = GetAll();
            try
            {
                if(item != null)
                {
                    items.Add(item);
                    File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.Add()::{ex.Message}");
            }
        }

        /// <summary>
        /// Update and Add Existing Record into JSON File
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public bool Update(T item)
        {
            try
            {
                var items = GetAll();
                var index = items.FindIndex(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == (int)typeof(T).GetProperty("Id")?.GetValue(item));
                if (index >= 0)
                {
                    items[index] = item;
                    File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.Update()::{ex.Message}");
            }
        }

        /// <summary>
        /// Delete Record from JSON File
        /// </summary>
        /// <param name="id"></param>
        /// <returns><![CDATA[True if record deleted successfully otherwise it returns False]]></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            try
            {
                var items = GetAll();
                var item = items.Find(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == id);
                if (item != null)
                {
                    items.Remove(item);
                    File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception($"\nDataAccess.Services.JsonServices<T>.Delete()::{ex.Message}");
            }
        }
    }
}