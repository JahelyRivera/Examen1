using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMostrar : ContentPage
    {
        public PageMostrar()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listaContactos.ItemsSource = await App.dbcontacto.listaContactos();
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var contac = item.CommandParameter as Contactos;
            await Navigation.PushAsync(new PageContactos(contac));
        }

        //private async void BtnEliminar_Clicked(object sender, EventArgs e)
        //{
        //    if(await DisplayAlert("Confirmación", "¿Está seguro de eliminar este contacto?", "Si", "No"))
        //    {
        //        var contac = (Contactos)(sender as MenuItem).CommandParameter;
        //        var resul = await App.dbcontacto.DeleteContactos(contac);

        //        if(resul == 1)
        //        {
        //            LstContactos.ItemsSource = await App.dbcontacto.listaContactos();
        //        }
        //    }
        //}



        private void LstContactos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void listaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listaContactos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}