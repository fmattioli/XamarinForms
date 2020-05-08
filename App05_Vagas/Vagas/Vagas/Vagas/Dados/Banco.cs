using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using Vagas.Models;
using Xamarin.Forms;
namespace Vagas.Dados
{
    class Banco
    {
        private SQLiteConnection _conexao;

        public Banco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.GetCaminho("dbvagas.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();  
        }

        public List<Vaga> ConsultarPorNome(string palavra)
        {
            return _conexao.Table<Vaga>().Where(a=> a.NomeVaga.Contains(palavra)).ToList();
        }

        public Vaga ObterVagaById(int id)
        {
            return _conexao.Table<Vaga>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

       
        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
