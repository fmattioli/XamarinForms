using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Mimica.Model;
using Xamarin.Forms;

namespace Mimica.ViewModel
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo{ get; set; }
        public Command JogarNovamente { get; set; }
        public ResultadoViewModel()
        {
            Jogo = Storage.Storage.Jogo;
            JogarNovamente = new Command(JogarNovamenteAction);
        }

        private void JogarNovamenteAction(object obj)
        {
            App.Current.MainPage = new View.Inicio();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PalavraPontuacao)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PalavraPontuacao));
            }
        }
    }
}
