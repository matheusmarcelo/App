using AppRpgEtec.Model;
using AppRpgEtec.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        UsuarioViewModel usuarioViewModel;
        Usuario u;
        public LoginView()
        {
            InitializeComponent();
            u = new Usuario();
            usuarioViewModel = new UsuarioViewModel();
            BindingContext = usuarioViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Usuario>(this, "InformacaoCRUD", async (u) =>
            {
                if (!string.IsNullOrEmpty(u.Token))
                {
                    Application.Current.Properties["UsuarioId"] = u.Id;
                    Application.Current.Properties["UsuarioUsername"] = u.Username;
                    Application.Current.Properties["UsuarioPerfil"] = u.Perfil;
                    Application.Current.Properties["UsuarioToken"] = u.Token;


                    string mensagem = string.Format("Bem-Vindo, {0}", u.Username);
                    await DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new Views.DetailsView();
                }
                else
                    await DisplayAlert("Informação", "Dados incorretos!!!", "Ok");
            });
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}