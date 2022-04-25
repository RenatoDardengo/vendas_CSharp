using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salesSystem.DTO
{
    internal class LoginDTO
    {
        private string username;
        private string password;
        private int permission;
        private string typePassword;


        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Permission { get => permission; set => permission = value; }
        public string TypePassword { get => typePassword; set => typePassword = value; }
    }
}
