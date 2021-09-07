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
    public partial class DetailsView : MasterDetailPage
    {
        public DetailsView()
        {
            InitializeComponent();

            //Evento está sendo atribuido ao ListView da Masgter
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            IsPresented = true;

            //Página que aparecerá no Detail está sendo instanciada
            var navigationPage = new Xamarin.Forms.NavigationPage(new MainPage());

            //Página instanciada sendo enviada para propriedade Detail.
            this.Detail = navigationPage;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.MenuItem;

            if (item == null)
                return;

            var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            //Detail = new Xamarin.Forms.NavigationPage(page);
            Detail.Navigation.PushAsync(page);

            IsPresented = false;
            masterPage.ListView.SelectedItem = null;
        }

        public string Login
        {
            get
            {
                string login = string.Empty;
                if (Application.Current.Properties.ContainsKey("UsuarioUsername"))
                    login = Application.Current.Properties["UsuarioUsername"].ToString();

                return string.Format("Login: {0}", login);
            }
        }
    }
}