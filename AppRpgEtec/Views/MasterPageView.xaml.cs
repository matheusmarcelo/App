using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageView : ContentPage
    {
        public Model.MenuItem[] OpcoesMenu { get; set; }
        public ListView ListView { get; set; }
        public MasterPageView()
        {
            InitializeComponent();
            
            DefinirMenu();
            ListView = itensMenuListView;
            BindingContext = this;
        }

        public string Login
        {
            get
            {
                string login = string.Empty;

                if (Application.Current.Properties.ContainsKey("UsuarioUsername"))
                    login = Application.Current.Properties["UsuarioUsername"].ToString();

                return login;
            }
        }

        public void DefinirMenu()
        {
            OpcoesMenu = new[]
            {
                new Model.MenuItem
                {
                    Id = 0, 
                    Title = "Usuários",
                    TargetType = typeof(Views.Usuarios.ListagemView),
                    IconSource = "MenuUsuarios.png"
                },

                new Model.MenuItem
                {
                    Id = 1, 
                    Title = "Personagens",
                    TargetType = typeof(Views.Personagens.ListagemView),
                    IconSource = "MenuPersonagens.png"
                },

                new Model.MenuItem
                {
                    Id = 2, 
                    Title = "Disputas",
                    TargetType = typeof(Views.Disputas.ListagemView),
                    IconSource = "MenuDisputas.png"
                },
            };
        }
    }
}