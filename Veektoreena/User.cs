using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veektoreena
{
    namespace Veektoreena
    {
        class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string BirthDate { get; set; }
            public List<Result> Results { get; set; } = new List<Result>();
        }
    }
}
