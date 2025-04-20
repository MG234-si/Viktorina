using System;
using System.Collections.Generic;
using Veektoreena.Veektoreena;

namespace Veektoreena
{
    class Program
    {
        static UserManager userManager = new UserManager();
        static QuizManager quizManager = new QuizManager();
        static User? currentUser = null;

        static void Main(string[] args)
        {
            userManager.Load("users.json");
            quizManager.Load("quizzes.json");
            LoginMenu();
        }

        static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Welcome to Quiz menu ---");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Login();
                        if (currentUser != null)
                            MainMenu();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        return;
                }
            }
        }

        static void Register()
        {
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.Write("Password: ");
            var pass = Console.ReadLine();
            Console.Write("Birth date (day, month, year): ");
            var date = Console.ReadLine();

            if (userManager.Register(login, pass, date))
                Console.WriteLine("You rehistered");
            else
                Console.WriteLine("Such login already exists, try again");
        }

        static void Login()
        {
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.Write("Password: ");
            var pass = Console.ReadLine();

            var user = userManager.Login(login, pass);
            if (user != null)
            {
                Console.WriteLine("Success");
                currentUser = user;
            }
            else
                Console.WriteLine("You have w ritten something incorrect");
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine($"\n--- Menu ({currentUser.Login}) ---");
                Console.WriteLine("1.Start quiz");
                Console.WriteLine("2.My results");
                Console.WriteLine("3.Top 20");
                Console.WriteLine("4.Settings");
                Console.WriteLine("5.Logout");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartQuiz();
                        break;
                    case "2":
                        ShowResults();
                        break;
                    case "3":
                        ShowTop();
                        break;
                    case "4":
                        Settings();
                        break;
                    case "5":
                        currentUser = null;
                        return;
                }
            }
        }

        static void StartQuiz()
        {
            Console.WriteLine("\nChoose category:");
            var categories = quizManager.GetCategories();
            for (int i = 0; i < categories.Count; i++)
                Console.WriteLine($"{i + 1}. {categories[i]}");
            Console.WriteLine($"{categories.Count + 1}. Mixed");

            var input = Console.ReadLine();
            int index = int.Parse(input);
            Quiz quiz;

            if (index == categories.Count + 1)
                quiz = quizManager.GenerateMixedQuiz();
            else
                quiz = quizManager.GetQuizByCategory(categories[index - 1]);

            var result = quiz.Run();
            currentUser.Results.Add(result);
            Console.WriteLine($"Correct answers: {result.Score}/20");
            userManager.Save("users.json");
        }

        static void ShowResults()
        {
            foreach (var r in currentUser.Results)
                Console.WriteLine($"{r.Category} - {r.Score}/20");
        }

        static void ShowTop()
        {
            Console.Write("Enter category: ");
            var cat = Console.ReadLine();
            var top = userManager.GetTop(cat);

            Console.WriteLine("--- Top 20 ---");
            int i = 1;
            foreach (var r in top)
            {
                Console.WriteLine($"{i++}. {r.UserName}: {r.Score}/20");
            }
        }

        static void Settings()
        {
            Console.WriteLine("1.Change password");
            Console.WriteLine("2.Change birthdate");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("New password: ");
                currentUser.Password = Console.ReadLine();
            }
            else if (choice == "2")
            {
                Console.Write("New birth date: ");
                currentUser.BirthDate = Console.ReadLine();
            }

            Console.WriteLine("Updated.");
            userManager.Save("users.json");
        }
    }
}
    
