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
    public partial class ListagemView : ContentPage
    {
        private ListagemPersonagemViewModel viewModel;
        public ListagemView()
        {
            InitializeComponent();
            viewModel = new ListagemPersonagemViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ObterPersonagens.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}