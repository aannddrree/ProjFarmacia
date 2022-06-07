using Controllers;
using Models;
using System;

namespace ProjFarmacia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "João",
                Telefone = "16 9999-8888"
            };

            Funcionario funcionario = new Funcionario()
            {
                Id = 1,
                Nome = "José",
                Telefone = "16 8888-3333"
            };

            Venda venda = new Venda()
            {
                Id = 1,
                Cliente = cliente,
                Medicamento = new Medicamento() { Id = 2, Descricao = "Dor nas costas"},
                Funcionario = funcionario,
                DtVenda = DateTime.Now
            };

            //Inserir no lista (memória - simulando o banco de dados)
            new VendaController().Inserir(venda);

            //Consultar todos os elementos da lista
            new VendaController().ConsultarTudo().ForEach(x => Console.WriteLine(x));
        }
    }
}
