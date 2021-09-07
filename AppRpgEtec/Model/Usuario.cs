using System;
using System.Collections.Generic;
using System.Text;

namespace AppRpgEtec.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordString { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }
    }
}
