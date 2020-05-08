using App03_TarefasDiarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App03_TarefasDiarias.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        public byte _Prioridade { get; set; }
        public Cadastro ()
		{
			InitializeComponent ();
		}

        private void PrioridadeSelected(object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;
            foreach (var Linha in Stacks)
            {
                Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            String prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("p", "");
            prioridade = prioridade.Replace("p", "");
            this._Prioridade = byte.Parse(prioridade);
          
        }

        private void Salvar(object sender, EventArgs args)
        {
            if (txtNome.Text == string.Empty)
            {
                DisplayAlert("Erro!", "Prencha o campo nome!!!", "OK");
                return;
            }
            
            if(!(this._Prioridade > 0))
            {
                DisplayAlert("Erro!", "Prencha a prioridade!!!", "OK");
                return;
            }

            Tarefa task = new Tarefa();
            task.Nome = txtNome.Text.Trim();
            task.Prioridade = this._Prioridade;

            new Gerenciador().Salvar(task);
            App.Current.MainPage = new NavigationPage(new Inicio());
           
           
        }

    }
}