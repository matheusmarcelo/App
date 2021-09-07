using AppRpgEtec.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppRpgEtec.Service.personagem
{
    public class PersonagemService : Request
    {
        private readonly Request _request = null;

        private const string ApiUrlBase = "http://MN-RPG.somee.com/RpgApi/Personagem";
        private string _token;

        public PersonagemService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Personagem> PostPersonagemAsync(Personagem p)
        { 
            return await _request.PostAsync(ApiUrlBase, p, _token); 
        }
        public async Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        { 
            string urlComplementar = string.Format("{0}", "/GetAll");
            
            ObservableCollection<Model.Personagem> listaPersonagens = await _request.GetAsync<ObservableCollection<Model.Personagem>>(ApiUrlBase + urlComplementar, _token);
            
            return listaPersonagens;
        }
        public async Task<ObservableCollection<Personagem>> GetPersonagemAsync(int personagemId)
        { 
            ObservableCollection<Model.Personagem> listaPersonagens = await _request.GetAsync<ObservableCollection<Model.Personagem>>(ApiUrlBase, _token);
            
            var personagemFiltrado = listaPersonagens.Where(p => p.Id == personagemId);
            
            return new ObservableCollection<Personagem>(personagemFiltrado);
        }
        public async Task<Personagem> PutPersonagemAsync(Personagem p)
        { 
            var result = await _request.PutAsync(ApiUrlBase, p, _token);
            
            return result;
        }
        public async Task<Personagem> DeletePersonagemAsync(int personagemId)
        { 
            string urlComplementar = string.Format("/{0}", personagemId);
            
            await _request.DeleteAsync(ApiUrlBase + urlComplementar, _token);
            
            return new Personagem()
            {
                Id = personagemId
            };
        }
    }
}
