using System;
using Dictionary;

namespace Dictionary
{
    class Program
    {
        static DictionaryManager manager = new DictionaryManager();

        static void Main(string[] args)
        {
            manager.LoadFromFile("dictionaries.json");
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Dictionary menu ---");
                Console.WriteLine("1.Create");
                Console.WriteLine("2.Edit");
                Console.WriteLine("3.Save");
                Console.WriteLine("4.Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateDictionary();
                        break;
                    case "2":
                        WorkWithDictionary();
                        break;
                    case "3":
                        manager.SaveToFile("dictionaries.json");
                        Console.WriteLine("Saved.");
                        break;
                    case "4":
                        return;
                }
            }
        }

        static void CreateDictionary()
        {
            Console.Write("Add the designation of yor dictionary: ");
            var name = Console.ReadLine();
            if (manager.GetDictionaryByName(name) == null)
            {
                manager.Dictionaries.Add(new LanguageDictionary(name));
                Console.WriteLine("Created.");
            }
            else
            {
                Console.WriteLine("Such disctionary already exists.");
            }
        }

        static void WorkWithDictionary()
        {
            Console.Write("name of the dictionary: ");
            var name = Console.ReadLine();
            var dict = manager.GetDictionaryByName(name);
            if (dict == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            while (true)
            {
                Console.WriteLine($"\n--- Dictionary: {dict.Name} ---");
                Console.WriteLine("1.Add word + translation");
                Console.WriteLine("2.Efdit a word");
                Console.WriteLine("3.Change translation");
                Console.WriteLine("4.Delete a word");
                Console.WriteLine("5.delete a translation");
                Console.WriteLine("6.Find translation");
                Console.WriteLine("7.Export");
                Console.WriteLine("8.Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWord(dict);
                        break;
                    case "2":
                        ReplaceWord(dict);
                        break;
                    case "3":
                        ReplaceTranslation(dict);
                        break;
                    case "4":
                        DeleteWord(dict);
                        break;
                    case "5":
                        DeleteTranslation(dict);
                        break;
                    case "6":
                        FindTranslation(dict);
                        break;
                    case "7":
                        ExportWord(dict);
                        break;
                    case "8":
                        return;
                }
            }
        }

        static void AddWord(LanguageDictionary dict)
        {
            Console.Write("Word: ");
            var word = Console.ReadLine();
            Console.Write("translation: ");
            var translation = Console.ReadLine();
            dict.AddOrUpdateWord(word, translation);
        }

        static void ReplaceWord(LanguageDictionary dict)
        {
            Console.Write("Old word: ");
            var oldWord = Console.ReadLine();
            Console.Write("New word: ");
            var newWord = Console.ReadLine();
            dict.ReplaceWord(oldWord, newWord);
        }

        static void ReplaceTranslation(LanguageDictionary dict)
        {
            Console.Write("Word: ");
            var word = Console.ReadLine();
            Console.Write("Old translation: ");
            var oldTr = Console.ReadLine();
            Console.Write("New translation: ");
            var newTr = Console.ReadLine();
            dict.ReplaceTranslation(word, oldTr, newTr);
        }

        static void DeleteWord(LanguageDictionary dict)
        {
            Console.Write("Word to delete: ");
            var word = Console.ReadLine();
            dict.RemoveWord(word);
        }

        static void DeleteTranslation(LanguageDictionary dict)
        {
            Console.Write("Word: ");
            var word = Console.ReadLine();
            Console.Write("Translation for deleteion: ");
            var tr = Console.ReadLine();
            if (!dict.RemoveTranslation(word, tr))
                Console.WriteLine("ERROR: You can't delete the last translation");
        }

        static void FindTranslation(LanguageDictionary dict)
        {
            Console.Write("Word: ");
            var word = Console.ReadLine();
            var entry = dict.FindEntry(word);
            if (entry != null)
                Console.WriteLine($"Translations: {string.Join(", ", entry.Translations)}");
            else
                Console.WriteLine("Word not found.");
        }

        static void ExportWord(LanguageDictionary dict)
        {
            Console.Write("Word for export: ");
            var word = Console.ReadLine();
            Console.Write("Name: ");
            var file = Console.ReadLine();
            manager.ExportWord(dict, word, file);
        }
    }
}
