using MICALCU.Vista;
using Xamarin.Forms;

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

