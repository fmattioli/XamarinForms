using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Dados;
using Vagas.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarVaga : ContentPage
    {
        private List<Vaga> _ListaVagas { get; set; }
        public ConsultarVaga()
        {
            InitializeComponent();
            Banco banco = new Banco();
            _ListaVagas = banco.Consultar();
            ListaVagas.ItemsSource = banco.Consultar();
            lblQtdeVagas.Text = _ListaVagas.Count.ToString() + " vagas encontradas";
        }

        private void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new VisualizarVaga());
        }

        private void DetalheAction(object sender, EventArgs args)
        {
            Label lblDetalhe = sender as Label;
            TapGestureRecognizer tap = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];
            Vaga vaga = tap.CommandParameter as Vaga;
            Navigation.PushAsync(new DetalheVaga(vaga));
        }

        private void txtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = _ListaVagas.Where(a => a.NomeVaga.Contains(e.NewTextValue)).ToList();
            
        }
    }
}