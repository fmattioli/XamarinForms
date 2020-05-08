using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Servico.Modelo;
using App01_ConsultarCep.Servico;

namespace App01_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnBuscar.Clicked += BuscarCEP;
        
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = Cep.Text.Trim();
            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);
                    if (end != null) 
                    {
                        lblResultado.Text = $"Endereço: {end.localidade} {end.uf}. {end.logradouro} {end.bairro}";
                        Cep.Text = string.Empty;
                    }
                    else
                    {
                        DisplayAlert("Erro Crítico!!", $"O Endereço não foi encontrado para o CEP: {Cep.Text}", "Ok");
                    }
                }
                catch (Exception erro)
                {
                    DisplayAlert("Erro Crítico!!", erro.Message.ToString(), "Ok");
                }
            }
        }

        private bool IsValidCEP(string cep)
        {
            bool isValid = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O Cep deve conter 8 caracteres", "Ok");
                isValid = false;
            }

            int novoCep = 0;
            if(!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "CEP Inválido! O Cep deve conter apenas números", "Ok");
                isValid = false;
            }
            return isValid;
        }
    }
}
