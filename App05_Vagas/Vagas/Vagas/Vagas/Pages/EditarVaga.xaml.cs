using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Models;
using Vagas.Dados;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
        private Vaga _vaga { get; set; }
		public EditarVaga (Vaga vaga)
		{
			InitializeComponent();
            this._vaga = vaga;
            PreencherCampos(_vaga);

            //TODO: Listagem na tela
		}

        private void PreencherCampos(Vaga vaga)
        {
            txtNomeVaga.Text = vaga.NomeVaga;
            txtEmpresa.Text = vaga.Empresa;
            txtQtde.Text = vaga.Quantidade.ToString();
            txtCidade.Text = vaga.Cidade;
            txtSalaro.Text = vaga.Salario.ToString();
            txtDescricaoVaga.Text = vaga.Descricao;
            TipoContratacao.IsToggled = vaga.TipoContratacao == "CLT" ? false : true;
            txtTelefone.Text = vaga.Telefone;
            txtEmail.Text = vaga.Email;
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            _vaga.NomeVaga = txtNomeVaga.Text;
            _vaga.Quantidade = short.Parse(txtQtde.Text);
            _vaga.Salario = double.Parse(txtSalaro.Text);
            _vaga.Empresa = txtEmpresa.Text;
            _vaga.Cidade = txtCidade.Text;
            _vaga.Descricao = txtDescricaoVaga.Text;
            _vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            _vaga.Telefone = txtTelefone.Text;
            _vaga.Email = txtEmail.Text;
            Banco banco = new Banco();
            banco.Atualizacao(_vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVaga());
        }
    }
}