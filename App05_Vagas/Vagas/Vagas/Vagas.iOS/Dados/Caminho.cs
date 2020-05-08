using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Vagas.Dados;
using Vagas.iOS.Dados;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace Vagas.iOS.Dados
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string NomeArquivoBD)
        {
            var pathFolderDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBiblioteca = Path.Combine(pathFolderDB, "..", "Library");
            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBD);
            return caminhoBanco;
        }
    }
}