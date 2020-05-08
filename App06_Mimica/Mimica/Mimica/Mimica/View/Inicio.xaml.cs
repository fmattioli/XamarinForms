using Mimica.ViewModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mimica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent();
            BindingContext = new InicioViewModel();
		}       
	}

   
}