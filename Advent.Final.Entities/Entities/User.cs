using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Entities.Entities
{
    public class User: Person
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public bool UserState { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogIn { get; set; }
        public DateTime? LastLogOut { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
    }
}
