using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace App03_TarefasDiarias.Modelos
{
    public class Gerenciador
    {
        public List<Tarefa> ListaTarefas { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            ListaTarefas = Listagem();
            ListaTarefas.Add(tarefa);
            SalvarNoProperties(ListaTarefas);
        }

        public void Remover(int indice)
        {
            ListaTarefas = Listagem();
            ListaTarefas.RemoveAt(indice);
            SalvarNoProperties(ListaTarefas);
        }
        public void Finalizar(int indice, Tarefa tarefa)
        {
            ListaTarefas = Listagem();
            ListaTarefas.RemoveAt(indice);
            tarefa.DataFinalizacao = DateTime.Now;
            ListaTarefas.Add(tarefa);
            SalvarNoProperties(ListaTarefas);
        }

        private void SalvarNoProperties(List<Tarefa> tarefas)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            string jsonVal = JsonConvert.SerializeObject(tarefas);
            App.Current.Properties.Add("Tarefas", jsonVal);
        }

        public List<Tarefa> Listagem()
        {
            return ListagemProperties();
        }

        private List<Tarefa> ListagemProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string JSONVal = App.Current.Properties["Tarefas"].ToString();
                List<Tarefa> Lista = JsonConvert.DeserializeObject<List<Tarefa>>(JSONVal);
                return Lista;
            }
            return new List<Tarefa>();
        }

        

    }
}
