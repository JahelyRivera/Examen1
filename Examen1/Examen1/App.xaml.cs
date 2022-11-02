using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen1
{
    public partial class App : Application
    {
        static Controllers.DBContacto dBContacto;

        public static Controllers.DBContacto dbcontacto
        {
            get
            {
                if (dBContacto == null)
                {
                    string DBName = "contactos.db3";
                    string PathDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
                    dBContacto = new Controllers.DBContacto(PathDB);
                }

                return dBContacto;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
