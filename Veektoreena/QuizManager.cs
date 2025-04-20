using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace Veektoreena;

class QuizManager
{
    public List<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public void Load(string path)
    {
        if (File.Exists(path))
            Quizzes = JsonSerializer.Deserialize<List<Quiz>>(File.ReadAllText(path));
        else
            //С вопросами я проленился, их делал чат гпт!!!
            Quizzes.Add(new Quiz
            {
                Category = "Math",
                Questions = new List<Question>
            {
                new Question { Text = "What is 2 + 2?", Options = new List<string> { "3", "4", "5", "6" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 5 + 3?", Options = new List<string> { "7", "8", "9", "10" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 12 - 4?", Options = new List<string> { "6", "7", "8", "9" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 6 * 7?", Options = new List<string> { "38", "40", "42", "44" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 15 / 3?", Options = new List<string> { "3", "4", "5", "6" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 9 * 9?", Options = new List<string> { "71", "72", "81", "90" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 25 + 37?", Options = new List<string> { "52", "62", "72", "82" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 8 * 6?", Options = new List<string> { "42", "46", "48", "52" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 20 - 7?", Options = new List<string> { "11", "12", "13", "14" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is 100 / 4?", Options = new List<string> { "20", "25", "30", "35" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What is 45 + 30?", Options = new List<string> { "70", "75", "80", "85" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 16 - 9?", Options = new List<string> { "5", "6", "7", "8" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What is 50 / 2?", Options = new List<string> { "20", "25", "30", "35" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 9 + 10?", Options = new List<string> { "18", "19", "20", "21" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 30 * 3?", Options = new List<string> { "80", "90", "100", "110" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 100 - 55?", Options = new List<string> { "40", "45", "50", "55" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 11 * 11?", Options = new List<string> { "110", "121", "130", "140" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 50 + 25?", Options = new List<string> { "70", "75", "80", "85" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is 60 / 5?", Options = new List<string> { "10", "12", "14", "16" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What is 4 * 4?", Options = new List<string> { "12", "14", "15", "16" }, CorrectIndexes = new List<int> { 3 } }
            }
            });

        Quizzes.Add(new Quiz
        {
            Category = "Ukrainian History",
            Questions = new List<Question>
            {
                new Question { Text = "First president of Ukraine?", Options = new List<string> { "Leonid Kravchuk", "Viktor Yanukovych", "Petro Poroshenko", "Volodymyr Zelensky" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "When did Ukraine declare independence?", Options = new List<string> { "1990", "1991", "1992", "1993" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "WName of the anthem of Ukraine?", Options = new List<string> { "Shche ne vmerla Ukraina", "Ode to Joy", "Ukraine Has Not Yet Perished", "Zbroya" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Who was the Hetman of Ukraine in the 17th century?", Options = new List<string> { "Bohdan Khmelnytsky", "Taras Shevchenko", "Ivan Mazepa", "Petro Konashevych" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What even started Holodomor?", Options = new List<string> { "Famine", "World War I", "The Soviet Revolution", "The Treaty of Pereyaslav" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which Ukrainian city was the capital of the Cossack Hetmanate?", Options = new List<string> { "Lviv", "Kyiv", "Kharkiv", "Cherkasy" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is the Ukrainian national flower?", Options = new List<string> { "Sunflower", "Rose", "Tulip", "Daisy" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which war did Ukraine fight in from 2014 onward?", Options = new List<string> { "World War I", "Crimean War", "War in Donbas", "Russo-Japanese War" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "Who wrote the national poem 'Kobzar'?", Options = new List<string> { "Ivan Franko", "Bohdan Khmelnytsky", "Taras Shevchenko", "Lesya Ukrainka" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is the capital city of Ukraine?", Options = new List<string> { "Lviv", "Kyiv", "Odesa", "Kharkiv" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "Which battle in 1709 was a turning point in the history of Ukraine?", Options = new List<string> { "Battle of Poltava", "Battle of the Dnieper", "Battle of Kyiv", "Battle of Lviv" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Who was the famous Ukrainian poet, writer, and artist who became a symbol of Ukrainian national identity?", Options = new List<string> { "Ivan Franko", "Mykhailo Hrushevsky", "Taras Shevchenko", "Lesya Ukrainka" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "When did Ukraine gain independence from the Soviet Union?", Options = new List<string> { "1990", "1991", "1992", "1993" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "Who is considered the founder of the modern Ukrainian state?", Options = new List<string> { "Viktor Yushchenko", "Mykhailo Hrushevsky", "Petro Poroshenko", "Bohdan Khmelnytsky" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is the primary religion of Ukraine?", Options = new List<string> { "Orthodox Christianity", "Catholicism", "Islam", "Judaism" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which year did the Ukrainian Revolution of Dignity (Euromaidan) begin?", Options = new List<string> { "2013", "2014", "2015", "2016" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Who was the Ukrainian president during the Orange Revolution in 2004?", Options = new List<string> { "Viktor Yushchenko", "Leonid Kuchma", "Viktor Yanukovych", "Petro Poroshenko" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which city is known as the cultural capital of Ukraine?", Options = new List<string> { "Kyiv", "Lviv", "Odesa", "Dnipro" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is the name of the Ukrainian parliament?", Options = new List<string> { "Supreme Council", "Rada", "Sejm", "Duma" }, CorrectIndexes = new List<int> { 1 } }
            }
        });

        Quizzes.Add(new Quiz
        {
            Category = "Coding",
            Questions = new List<Question>
            {
                new Question { Text = "What does HTML stand for?", Options = new List<string> { "Hyper Text Markup Language", "High Text Markup Language", "Hyperlink Text Markup Language", "None of the above" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which language is primarily used for web development?", Options = new List<string> { "Java", "Python", "JavaScript", "C++" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "Which of the following is a valid CSS selector?", Options = new List<string> { "id:header", ".header", "#header", "all.header" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is the main use of the 'console.log()' function in JavaScript?", Options = new List<string> { "To print output to the screen", "To send data to the server", "To log messages to the console", "None of the above" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is the difference between '==' and '===' in JavaScript?", Options = new List<string> { "'==' checks value, '===' checks both value and type", "'==' checks type, '===' checks value", "'==' checks data type", "'===' checks syntax" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What is the correct HTML element for the largest heading?", Options = new List<string> { "<heading>", "<h6>", "<h1>", "<head>" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "Which of the following is not a programming language?", Options = new List<string> { "Python", "Java", "HTML", "C++" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is an example of an interpreted language?", Options = new List<string> { "Java", "C", "Python", "C++" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "Which method is used to parse a JSON string in JavaScript?", Options = new List<string> { "JSON.parse()", "JSON.stringify()", "JSON.encode()", "None of the above" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which of these is used to comment code in JavaScript?", Options = new List<string> { "// comment", "/* comment */", "// comment */", "Both 1 and 2" }, CorrectIndexes = new List<int> { 3 } },
                new Question { Text = "What does SQL stand for?", Options = new List<string> { "Structured Query Language", "Simple Query Language", "Standard Query Language", "Structured Question Language" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What does 'DOM' stand for in web development?", Options = new List<string> { "Domain Object Model", "Document Object Model", "Data Object Model", "None of the above" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "Which of the following is an example of a front-end technology?", Options = new List<string> { "Node.js", "React", "Django", "Java" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "Which of the following is not a database?", Options = new List<string> { "MongoDB", "MySQL", "JavaScript", "PostgreSQL" }, CorrectIndexes = new List<int> { 2 } },
                new Question { Text = "What is the syntax to create a variable in JavaScript?", Options = new List<string> { "var x = 10", "int x = 10", "create x = 10", "None of the above" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "What does 'API' stand for?", Options = new List<string> { "Application Programming Interface", "Application Process Interface", "Automated Programming Interface", "None of the above" }, CorrectIndexes = new List<int> { 0 } },
                new Question { Text = "Which of the following is used to store data temporarily on a web page?", Options = new List<string> { "Session Storage", "Local Storage", "Cookies", "All of the above" }, CorrectIndexes = new List<int> { 3 } },
                new Question { Text = "What is Git?", Options = new List<string> { "A code editor", "A version control system", "A programming language", "A database" }, CorrectIndexes = new List<int> { 1 } },
                new Question { Text = "What is the purpose of the 'return' statement in JavaScript?", Options = new List<string> { "To terminate the function", "To send a value from a function", "Both", "None" }, CorrectIndexes = new List<int> { 2 } }
            }
        });
    }

    public List<string> GetCategories()
    {
        return Quizzes.Select(q => q.Category).ToList();
    }

    public Quiz GetQuizByCategory(string category)
    {
        return Quizzes.First(q => q.Category == category);
    }

    public Quiz GenerateMixedQuiz()
    {
        var allQuestions = Quizzes.SelectMany(q => q.Questions).OrderBy(x => System.Guid.NewGuid()).Take(20).ToList();
        return new Quiz { Category = "Mixed", Questions = allQuestions };
    }
}
