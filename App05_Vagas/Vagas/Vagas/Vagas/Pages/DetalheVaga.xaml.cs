using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheVaga : ContentPage
	{
		public DetalheVaga (Vaga vaga)
		{   
			InitializeComponent();
            BindingContext = vaga;
        }
	}
}