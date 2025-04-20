using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class LanguageDictionary
    {
        public string Name { get; set; }
        public List<DictionaryEntry> Entries { get; set; }

        public LanguageDictionary(string name)
        {
            Name = name;
            Entries = new List<DictionaryEntry>();
        }

        public DictionaryEntry FindEntry(string word)
        {
            return Entries.FirstOrDefault(e => e.Word == word);
        }

        public void AddOrUpdateWord(string word, string translation)
        {
            var entry = FindEntry(word);
            if (entry == null)
            {
                entry = new DictionaryEntry(word);
                Entries.Add(entry);
            }
            if (!entry.Translations.Contains(translation))
                entry.Translations.Add(translation);
        }

        public bool RemoveWord(string word)
        {
            var entry = FindEntry(word);
            if (entry != null)
                return Entries.Remove(entry);
            return false;
        }

        public bool RemoveTranslation(string word, string translation)
        {
            var entry = FindEntry(word);
            if (entry != null && entry.Translations.Count > 1)
                return entry.Translations.Remove(translation);
            return false;
        }

        public void ReplaceWord(string oldWord, string newWord)
        {
            var entry = FindEntry(oldWord);
            if (entry != null)
                entry.Word = newWord;
        }

        public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            var entry = FindEntry(word);
            if (entry != null)
            {
                int index = entry.Translations.IndexOf(oldTranslation);
                if (index != -1)
                    entry.Translations[index] = newTranslation;
            }
        }
    }
}
