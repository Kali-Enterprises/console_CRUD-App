using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccess
{
    public class XmlServices<T>
    {
        private readonly string _filePath;

        public XmlServices(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                return (List<T>)serializer.Deserialize(stream);
            }
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
            using (var stream = new FileStream(_filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(stream, items);
            }
        }

        public void Update(T item)
        {
            var items = GetAll();
            var index = items.FindIndex(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == (int)typeof(T).GetProperty("Id")?.GetValue(item));
            if (index >= 0)
            {
                items[index] = item;
                using (var stream = new FileStream(_filePath, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(stream, items);
                }
            }
        }

        public void Delete(int id)
        {
            var items = GetAll();
            var item = items.Find(i => (int)typeof(T).GetProperty("Id")?.GetValue(i) == id);
            if (item != null)
            {
                items.Remove(item);
                using (var stream = new FileStream(_filePath, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(stream, items);
                }
            }
        }
    }
}