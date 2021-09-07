using AppRpgEtec.Model;
using AppRpgEtec.Service.personagem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRpgEtec.ViewModels.Personagens
{
    public class CadastroPersonagemViewModel : BaseViewModel
    {
        private PersonagemService pService;

        public CadastroPersonagemViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            pService = new PersonagemService(token);
        }

        private int id;
        private string nome;
        private int pontosVida;
        private int forca;
        private int defesa;
        private int inteligencia;
        private int disputas;
        private int vitorias;
        private int derrotas;

        public int Id
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }
        public int PontosVida
        {
            get => pontosVida;
            set
            {
                pontosVida = value;
                OnPropertyChanged();
            }
        }
        public int Forca
        {
            get => forca;
            set
            {
                forca = value;
                OnPropertyChanged();
            }
        }
        public int Defesa
        {
            get => defesa;
            set
            {
                defesa = value;
                OnPropertyChanged();
            }
        }
        public int Inteligencia
        {
            get => inteligencia;
            set
            {
                inteligencia = value;
                OnPropertyChanged();
            }
        }
        public int Disputas
        {
            get => disputas;
            set
            {
                disputas = value;
                OnPropertyChanged();
            }
        }
        public int Vitorias
        {
            get => vitorias;
            set
            {
                vitorias = value;
                OnPropertyChanged();
            }
        }
        public int Derrotas
        {
            get => derrotas;
            set
            {
                derrotas = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TipoClasse> listaTiposClasse;
        public ObservableCollection<TipoClasse> ListaTiposClasse
        {
            get { return listaTiposClasse; }
            set
            {
                if (value != null)
                {
                    listaTiposClasse = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ObterClasses
        {
            get => new Command(() =>
            {
                ListaTiposClasse = new ObservableCollection<TipoClasse>();
                ListaTiposClasse.Add(new TipoClasse() { Id = 1, Descricao = "Cavaleiro" });
                ListaTiposClasse.Add(new TipoClasse() { Id = 2, Descricao = "Mago" });
                ListaTiposClasse.Add(new TipoClasse() { Id = 3, Descricao = "Clerigo" });
                OnPropertyChanged(nameof(ListaTiposClasse));
            });
        }

        private TipoClasse tipoClasseSelecionado;
        public TipoClasse TipoClasseSelecionado
        {
            get { return tipoClasseSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoClasseSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand SalvarPersonagem
        {
            get => new Command(async () =>
            {
                try
                {
                    Personagem model = new Personagem()
                    {
                        Nome = this.nome,
                        PontosVida = this.PontosVida,
                        Defesa = this.defesa,
                        Derrotas = this.derrotas,
                        Disputas = this.disputas,
                        Forca = this.forca,
                        Inteligencia = this.inteligencia,
                        Vitorias = this.vitorias,
                        Id = this.id,

                        Classe = (ClassEnum)tipoClasseSelecionado.Id
                    };

                    if (model.Id == 0)
                        await pService.PostPersonagemAsync(model);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
                }
                catch (System.Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "Ok");
                }
            });
        }
    }
}
