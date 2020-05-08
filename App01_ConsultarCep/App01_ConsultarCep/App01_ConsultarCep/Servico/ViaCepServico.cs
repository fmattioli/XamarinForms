using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCep.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL { get; set; }
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoUrl = $"http://viacep.com.br/ws/{cep}/json/";
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if(end.cep == null)
            {
                return null;
            }
            return end;
        }
    }
}
