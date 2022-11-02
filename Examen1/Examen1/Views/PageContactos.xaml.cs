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
    public partial class PageContactos : ContentPage
    {
        public PageContactos()
        {
            InitializeComponent();
        }

        Models.Contactos _contactos;

        public PageContactos(Models.Contactos contactos)
        {
            InitializeComponent();
            Title = "Editar contacto";
            _contactos = contactos;
            TxtNombres.Text = contactos.Nombres;
            TxtApellidos.Text = contactos.Apellidos;
            TxtTelefono.Text = Convert.ToString(contactos.Telefono);
            TxtEdad.Text = Convert.ToString(contactos.Edad);
            TxtNombres.Focus();

        }

        private async void ToolAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMostrar());
        }

        //private async void ToolMap_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Views.PageMap());
        //}

        private async void MostrarGeo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageGeo());
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            var contactos = new Models.Contactos
            {
                Id = Convert.ToInt32(TxtCodigo.Text),
                Nombres = TxtNombres.Text,
                Apellidos = TxtApellidos.Text,
                Telefono = Convert.ToInt32(TxtTelefono.Text),
                Edad = Convert.ToInt32(TxtEdad.Text),
                Pais = pickerCountry.SelectedItem.ToString(),
                Nota = TxtNota.Text,

            };


            if (String.IsNullOrEmpty(TxtNombres.Text))
            {
                await DisplayAlert("Aviso", "Ingrese su nombre", "OK");
            }

            if (String.IsNullOrEmpty(TxtApellidos.Text))
            {
                await DisplayAlert("Aviso", "Ingrese su apellido", "OK");
            }

            if (String.IsNullOrEmpty(TxtEdad.Text))
            {
                await DisplayAlert("Aviso", "Ingrese su edad", "OK");
            }

            if (String.IsNullOrEmpty(TxtNota.Text))
            {
                await DisplayAlert("Aviso", "Ingrese una nota", "OK");
            }

            else
            {
                if (await App.dbcontacto.StoreContac(contactos) > 0)
                    await DisplayAlert("Aviso", "Registro ingresado con exito!!", "OK");
                
            }            

        }

        public void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            TxtTelefono.Text = "";
            TxtEdad.Text = "";
            pickerCountry.SelectedItem = "";
            TxtNota.Text = "";
        }
    }
}