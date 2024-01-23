using MICALCU.ModeloVista;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICALCU.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calvuladora : ContentPage
    {
        public Calvuladora()
        {
            InitializeComponent();
            BindingContext = new Mcalcu();
        }
    }

}
