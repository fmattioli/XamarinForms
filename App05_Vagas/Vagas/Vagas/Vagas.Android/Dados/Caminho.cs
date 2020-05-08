using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Vagas.Models;
using Vagas.Dados;
using System.IO;
using Vagas.Droid.Dados;

[assembly:Dependency(typeof(Caminho))]
namespace Vagas.Droid.Dados
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string NomeArquivoBD)
        {
            var pathFolderDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBD = Path.Combine(pathFolderDB, NomeArquivoBD);
            return caminhoBD;
        }
    }
}