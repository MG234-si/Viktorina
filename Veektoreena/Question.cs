using System.Collections.Generic;
using System.Linq;

namespace Veektoreena;

class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public List<int> CorrectIndexes { get; set; } = new List<int>();

    public bool IsCorrect(List<int> answers)
    {
        return answers.OrderBy(x => x).SequenceEqual(CorrectIndexes.OrderBy(x => x));
    }
}
