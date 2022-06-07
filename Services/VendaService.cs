using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    public class VendaService
    {
        static List<Venda> vendas = new List<Venda>();

        public bool Inserir(Venda venda)
        {
            vendas.Add(venda);
            return true;
        }

        public List<Venda> ConsultarTudo()
        {
            return vendas;
        }
    }
}
