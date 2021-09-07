using AppRpgEtec.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Service.Usuarios
{
    class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://MN-RPG.somee.com/RpgApi/Usuarios";
        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostLoginUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u.Token = await _request.PostReturnStringAsync(apiUrlBase + urlComplementar, u);

            return u;
        }
    }

}
