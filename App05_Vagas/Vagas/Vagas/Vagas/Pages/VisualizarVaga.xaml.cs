using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Models;
using Vagas.Dados;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VisualizarVaga : ContentPage
	{
        private List<Vaga> _ListaVagas { get; set; }
        public VisualizarVaga ()
		{
			InitializeComponent ();
            ConsultarVagas();
        }


        private void ConsultarVagas()
        {
            Banco banco = new Banco();
            _ListaVagas = banco.Consultar();
            ListaVagas.ItemsSource = banco.Consultar();
            lblQtdevagas.Text = _ListaVagas.Count() + " vagas encontradas";
        }
       
        public void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = sender as Label;
            TapGestureRecognizer tap = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            Vaga vaga = tap.CommandParameter as Vaga;
            Navigation.PushAsync(new EditarVaga(vaga));
        }
        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = sender as Label;
            TapGestureRecognizer tap = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
            Vaga vaga = tap.CommandParameter as Vaga;

            Banco banco = new Banco();
            banco.Exclusao(vaga);
            ConsultarVagas();
        }

        private void txtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = _ListaVagas.Where(a => a.NomeVaga.Contains(e.NewTextValue)).ToList();
        }
    }
}