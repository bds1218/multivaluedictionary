using System.Collections.Generic;

namespace MultiValueDict
{
    public interface IMultiValueDictionary
    {
        IEnumerable<string> GetKeys();
        IEnumerable<string> GetMembers(string key);
        void AddValue(string key, string value);
        void RemoveValue(string key, string value);
        void RemoveAll(string key);
        void ClearDictionary();
        bool KeyExists(string key);
        bool ValueExists(string key, string value);
        IEnumerable<string> GetAllMembers();
        IEnumerable<KeyValuePair<string, List<string>>> GetAllItems();
    }
}
