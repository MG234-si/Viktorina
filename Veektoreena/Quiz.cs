using System;
using System.Collections.Generic;
using Veektoreena;

namespace Veektoreena;

class Quiz
{
    public string Category { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();

    public Result Run()
    {
        int score = 0;

        for (int i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].Text}");
            for (int j = 0; j < Questions[i].Options.Count; j++)
                Console.WriteLine($"{j + 1}. {Questions[i].Options[j]}");

            Console.Write("Your anwswer(s): ");
            var input = Console.ReadLine();
            var selected = new List<int>();
            foreach (var part in input.Split(","))
                if (int.TryParse(part.Trim(), out int idx)) selected.Add(idx - 1);

            if (Questions[i].IsCorrect(selected))
                score++;
        }

        return new Result { Score = score, Category = this.Category };
    }
}
