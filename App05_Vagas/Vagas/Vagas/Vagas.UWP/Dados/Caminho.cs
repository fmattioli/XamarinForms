using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Dados;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using Vagas.UWP.Dados;

[assembly:Dependency(typeof(Caminho))]
namespace Vagas.UWP.Dados
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string NomeArquivoBD)
        {
            string caminhoDaPasta = ApplicationData.Current.LocalFolder.Path;
            string caminhoDoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBD);
            return caminhoDoBanco;
        }
    }
}
