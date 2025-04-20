using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class DictionaryEntry
    {
        public string Word { get; set; }
        public List<string> Translations { get; set; }

        public DictionaryEntry(string word)
        {
            Word = word;
            Translations = new List<string>();
        }
    }
}
