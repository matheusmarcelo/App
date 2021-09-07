using AppRpgEtec.Model;
using AppRpgEtec.Service.personagem;
using AppRpgEtec.Views.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRpgEtec.ViewModels.Personagens
{
    public class ListagemPersonagemViewModel : BaseViewModel
    {
        private PersonagemService pService;
        public ObservableCollection<Personagem> Personagens
        {
            get; set;
        }

        public ListagemPersonagemViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            pService = new PersonagemService(token);
            Personagens = new ObservableCollection<Personagem>();
        }

        public async Task ObterPersonagemAsync()
        {
            Personagens = await pService.GetPersonagensAsync();
            OnPropertyChanged(nameof(Personagens));
        }

        public ICommand ObterPersonagens
        {
            get
            {
                return new Command(async () =>
                {
                    try //Junto com o Cacth evitará que erros fechem o aplicativo
                    {
                        Personagens = await pService.GetPersonagensAsync();
                        OnPropertyChanged(nameof(Personagens)); //Informará a View que houve carregamento                       
                    }
                    catch (Exception ex)
                    {
                        //Captará o erro para exibir em tela
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
                    }
                });
            }
        }

        public ICommand NovoPersonagem
        {
            get
            {
                return new Command(async () =>
                {
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CadastroPersonagemView());
                });
            }
        }
    }
}
