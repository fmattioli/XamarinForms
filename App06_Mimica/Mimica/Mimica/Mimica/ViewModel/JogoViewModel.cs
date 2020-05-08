using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Mimica.Model;

namespace Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }
        private byte _PalavraPontuacao { get; set; }
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }
        private string _Palavra { get; set; }
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }
        private string _TextoContagem { get; set; }
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private bool _IsVisibleContainerContagem { get; set; }
        public bool IsVisibleContainerContagem { get { return _IsVisibleContainerContagem; } set { _IsVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem"); } }
        private bool _IsVisibleContainerIniciar { get; set; }
        public bool IsVisibleContainerIniciar { get { return _IsVisibleContainerIniciar; } set { _IsVisibleContainerIniciar = value; OnPropertyChanged("IsVisibleContainerIniciar"); } }
        private bool _IsVisibleBtnMostrar { get; set; }
        public bool IsVisibleBtnMostrar { get { return _IsVisibleBtnMostrar; } set { _IsVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); } }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel(Grupo grupo)
        {
            Grupo = grupo;
            NomeGrupo = grupo.Nome;
            IsVisibleContainerContagem = false;
            IsVisibleContainerIniciar = false;
            IsVisibleBtnMostrar = true;
            Palavra = "*************";
            MostrarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);

        }



        private void MostrarPalavraAction()
        {
            PalavraPontuacao = 3;
            var NumNivel = Storage.Storage.Jogo.NivelNumerico;
            if (NumNivel == 0)
            {
                Random rd = new Random();
                int niv = rd.Next(0, 2);
                int i = rd.Next(0, Storage.Storage.palavras[niv].Length);
                Palavra = Storage.Storage.palavras[niv][i];
                PalavraPontuacao = (byte) ((niv == 0) ? 1 : (niv == 1) ? 3 : 5);
            }

            if (NumNivel == 1)
            {
                Random rd = new Random();
                int i = rd.Next(0, Storage.Storage.palavras[NumNivel - 1].Length);
                Palavra = Storage.Storage.palavras[NumNivel - 1][i];
                PalavraPontuacao = 1;
            }
            if (NumNivel == 2)
            {
                Random rd = new Random();
                int i = rd.Next(0, Storage.Storage.palavras[NumNivel - 1].Length);
                Palavra = Storage.Storage.palavras[NumNivel - 1][i];
                PalavraPontuacao = 3;
            }
            if (NumNivel == 3)
            {
                Random rd = new Random();
                int i = rd.Next(0, Storage.Storage.palavras[NumNivel - 1].Length);
                Palavra = Storage.Storage.palavras[NumNivel - 1][i];
                PalavraPontuacao = 5;

            }
            IsVisibleBtnMostrar = false;
            IsVisibleContainerIniciar = true;
        }

        private void IniciarAction()
        {
            IsVisibleContainerIniciar = false;
            IsVisibleContainerContagem = true;

            int i = Storage.Storage.Jogo.TempoPalavra;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TextoContagem = i.ToString();
                i--;
                if (i < 0)
                {
                    TextoContagem = "Esgotou o tempo";
                }
                return true;
            });
        }
        private void ErrouAction(object obj)
        {
            GoProximoGrupo();
        }

        private void AcertouAction(object obj)
        {
            Grupo.Pontuacao += PalavraPontuacao;
            GoProximoGrupo();
        }

        private void GoProximoGrupo()
        {
            Grupo grupo;
            if (Storage.Storage.Jogo.Grupo1 == Grupo)
            {
                grupo = Storage.Storage.Jogo.Grupo2;


            }
            else
            {
                grupo = Storage.Storage.Jogo.Grupo1;
                Storage.Storage.RodadaAtual++;
            }

            if (Storage.Storage.RodadaAtual > Storage.Storage.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            {
                App.Current.MainPage = new View.Jogo(grupo);
            }


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
