using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Curriculo.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private  void GoCarreira(object sender, EventArgs args)
        {
            Detail= new Pages.Perfil();

        }
        private void GoEventos(object sender, EventArgs args)
        {
            Detail = new Pages.Sobre();
        }

        private void GoEducacional(object sender, EventArgs args)
        {
            Detail = new Pages.Educacional();
        }
        private void GoSkills(object sender, EventArgs args)
        {
            Detail = new Pages.Skills();
        }
    }
}