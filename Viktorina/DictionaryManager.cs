using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionary
{
    public class DictionaryManager
    {
        public List<LanguageDictionary> Dictionaries { get; set; }

        public DictionaryManager()
        {
            Dictionaries = new List<LanguageDictionary>();
        }

        public void SaveToFile(string path)
        {
            var json = JsonSerializer.Serialize(Dictionaries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                Dictionaries = JsonSerializer.Deserialize<List<LanguageDictionary>>(json);
            }
        }

        public void ExportWord(LanguageDictionary dict, string word, string exportPath)
        {
            var entry = dict.FindEntry(word);
            if (entry != null)
            {
                var export = JsonSerializer.Serialize(entry, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(exportPath, export);
            }
        }

        public LanguageDictionary GetDictionaryByName(string name)
        {
            return Dictionaries.Find(d => d.Name == name);
        }
    }
}
