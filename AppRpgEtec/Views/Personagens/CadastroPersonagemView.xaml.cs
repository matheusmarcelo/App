﻿using AppRpgEtec.ViewModels.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views.Personagens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPersonagemView : ContentPage
    {
        private CadastroPersonagemViewModel cadViewModel;
        public CadastroPersonagemView()
        {
            InitializeComponent();

            this.cadViewModel = new CadastroPersonagemViewModel();
            this.BindingContext = cadViewModel;
            this.Title = "Novo Personagem";

            cadViewModel.ObterClasses.Execute(null);
        }
    }
}