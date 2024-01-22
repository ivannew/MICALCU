using MICALCU.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICALCU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calvuladora();
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
