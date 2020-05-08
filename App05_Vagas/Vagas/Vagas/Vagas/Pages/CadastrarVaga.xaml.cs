using System;
using Vagas.Dados;
using Vagas.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastrarVaga : ContentPage
	{
		public CadastrarVaga ()
		{
			InitializeComponent();
		}
        


        private void SalvarAction(object sender, EventArgs args)
        {
            //TODO: VALIDAR DADOS 
            Vaga vaga = new Vaga();
            vaga.NomeVaga = txtNomeVaga.Text;
            vaga.Quantidade = short.Parse(txtQtde.Text);
            vaga.Salario = double.Parse(txtSalaro.Text);
            vaga.Empresa = txtEmpresa.Text;
            vaga.Cidade = txtCidade.Text;
            vaga.Descricao = txtDescricaoVaga.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = txtTelefone.Text;
            vaga.Email = txtEmail.Text;

            Banco Banco = new Banco();
            Banco.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVaga());
        }
	}
}