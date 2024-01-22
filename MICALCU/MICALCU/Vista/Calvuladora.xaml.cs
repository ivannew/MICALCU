using MICALCU.ModeloVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICALCU.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calvuladora : ContentPage
	{
		public Calvuladora ()
		{
			BindingContext = new Mcalcu();
		}
	}
}