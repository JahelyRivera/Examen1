using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace Examen1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGeo : ContentPage
    {
        double Lati;
        double Longi;

        public PageGeo()
        {
            InitializeComponent();
            Localizar();
        }

        private async void Localizar()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }

                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        Lon.Text = loc.Longitude.ToString();
                        Longi = double.Parse(Lon.Text);
                        Lat.Text = loc.Latitude.ToString();
                        Lati = double.Parse(Lat.Text);
                    };
                }
            }
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