using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Veektoreena.Veektoreena;
using Veektoreena;

namespace Veektoreena;

class UserManager
{
    public List<User> Users { get; set; } = new List<User>();

    public bool Register(string login, string pass, string birth)
    {
        if (Users.Any(u => u.Login == login)) return false;
        Users.Add(new User { Login = login, Password = pass, BirthDate = birth });
        return true;
    }

    public User? Login(string login, string pass)
    {
        return Users.FirstOrDefault(u => u.Login == login && u.Password == pass);
    }

    public void Load(string path)
    {
        if (File.Exists(path))
            Users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(path));
    }

    public void Save(string path)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(Users, new JsonSerializerOptions { WriteIndented = true }));
    }

    public List<Result> GetTop(string category)
    {
        return Users.SelectMany(u => u.Results.Where(r => r.Category == category).Select(r => new Result
        {
            UserName = u.Login,
            Category = r.Category,
            Score = r.Score
        }))
        .OrderByDescending(r => r.Score)
        .Take(20)
        .ToList();
    }
}
