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
        private readonly string _filePath;

        public JsonServices(string filePath)
        {
            try
            {
                _filePath = filePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.JsonServices<T>.JsonServices[CONSTRUCTOR]::{ex.Message}");
            }
        }

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
                throw new Exception($"\nDataAccess.JsonServices<T>.GetAll()::{ex.Message}");
            }
        }

        public T GetById(int id)
        {
            try
            {
                var items = GetAll();
                return items.Find(item => (int)typeof(T).GetProperty("Id")?.GetValue(item) == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.JsonServices<T>.GetById()::{ex.Message}");
            }
        }

        public void Add(T item)
        {
            try
            {
                var items = GetAll();
                items.Add(item);
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.JsonServices<T>.Add()::{ex.Message}");
            }
        }

        public void Update(T item)
        {
            try
            {
                var items = GetAll();
                var index = items.FindIndex(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == (int)typeof(T).GetProperty("Id")?.GetValue(item));
                if (index >= 0)
                {
                    items[index] = item;
                    File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.JsonServices<T>.Update()::{ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var items = GetAll();
                var item = items.Find(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == id);
                if (item != null)
                {
                    items.Remove(item);
                    File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDataAccess.JsonServices<T>.Delete()::{ex.Message}");
            }
        }
    }
}