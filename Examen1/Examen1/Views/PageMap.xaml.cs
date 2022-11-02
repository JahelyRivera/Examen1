using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace Examen1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var localizacion = await Geolocation.GetLocationAsync();
            Pin ubicacion = new Pin();
            ubicacion.Label = "UCENM SPS";
            ubicacion.Address = "San Pedro Sula";
            ubicacion.Position = new Position(localizacion.Latitude, localizacion.Longitude);
            Mapas.Pins.Add(ubicacion);

            Mapas.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude), Distance.FromKilometers(1)));
        }
    }
}