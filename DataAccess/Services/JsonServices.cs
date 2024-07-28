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
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }

        public T GetById(int id)
        {
            var items = GetAll();
            return items.Find(item => (int)typeof(T).GetProperty("Id")?.GetValue(item) == id);
        }

        public void Add(T item)
        {
            var items = GetAll();
            items.Add(item);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
        }

        public void Update(T item)
        {
            var items = GetAll();
            var index = items.FindIndex(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == (int)typeof(T).GetProperty("Id")?.GetValue(item));
            if (index >= 0)
            {
                items[index] = item;
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
            }
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.Find(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == id);
            if (item != null)
            {
                items.Remove(item);
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
            }
        }
    }
}
