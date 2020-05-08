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
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            lblData.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM");
            CarregarTasks();
        }

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image Delete = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile($"Delete.png")
            };

            TapGestureRecognizer DeleteTap = new TapGestureRecognizer();
            DeleteTap.Tapped += delegate
            {
                new Gerenciador().Remover(index);
                CarregarTasks();
            };

            Delete.GestureRecognizers.Add(DeleteTap);

            if (Device.RuntimePlatform == Device.UWP)
            {
                Delete.Source = ImageSource.FromFile($"Resources/Delete.png");
            }

            Image Prioridade = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile($"p{tarefa.Prioridade}.png")
            };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Prioridade.Source = ImageSource.FromFile($"Resources/p{tarefa.Prioridade }.png");
            }

            View StackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {

                StackCentral = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = tarefa.Nome

                };
            }
            else
            {
                StackCentral = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                ((StackLayout)StackCentral).Children.Add(new Label()
                    {
                        Text = tarefa.Nome,
                        TextColor = Color.Gray
                    }
                );
                ((StackLayout)StackCentral).Children.Add(new Label()
                    {
                        Text = "Finalizado em: " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h",
                        TextColor = Color.Gray,
                        FontSize = 10
                    }
                );


            }

            Image Check = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }
            if(tarefa.DataFinalizacao != null)
            {
                Check.Source = ImageSource.FromFile("CheckOn.png");
                if (Device.RuntimePlatform == Device.UWP)
                {
                    Check.Source = ImageSource.FromFile("Resources/CheckOn.png");
                }
            }

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();
            CheckTap.Tapped += delegate
            {
                new Gerenciador().Finalizar(index, tarefa);
                CarregarTasks();
            };
            Check.GestureRecognizers.Add(CheckTap);

            
            StackLayout Linha = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);
            SLTarefas.Children.Add(Linha);
        }

        private void CarregarTasks()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> list = new Gerenciador().Listagem();
            int i= 0;
            foreach (var item in list)
            {
                LinhaStackLayout(item, i);
                i++;
            }
        }

    }
}