using System.Collections.Generic;
using System.Linq;

namespace MultiValueDict
{
    public class MultiValueDictionary : IMultiValueDictionary
    {
        private readonly Dictionary<string, List<string>> _dictionary;

        public MultiValueDictionary()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        public void AddValue(string key, string value)
        {
            if (_dictionary.TryGetValue(key, out List<string> values))
            {
                _dictionary[key].Add(value);
            }
            else
            {
                _dictionary.Add(key, new List<string>() { value });
            }
        }

        public void ClearDictionary()
        {
            _dictionary.Clear();
        }

        public IEnumerable<KeyValuePair<string, List<string>>> GetAllItems()
        {
            return _dictionary;
        }

        public IEnumerable<string> GetAllMembers()
        {
            return _dictionary.Values.SelectMany(_ => _);
        }

        public IEnumerable<string> GetKeys()
        {
            return _dictionary.Keys;
        }

        public IEnumerable<string> GetMembers(string key)
        {
            return _dictionary[key];
        }

        public bool KeyExists(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void RemoveAll(string key)
        {
            _dictionary.Remove(key);
        }

        public void RemoveValue(string key, string value)
        {
            _dictionary[key].RemoveAll(_ => _ == value);
            if (_dictionary[key].Count == 0)
            {
                _dictionary.Remove(key);
            }
        }

        public bool ValueExists(string key, string value)
        {
            return _dictionary[key].Exists(_ => _ == value);
        }
    }
}
