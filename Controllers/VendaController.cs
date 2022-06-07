using Models;
using Services;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class VendaController
    {
        public bool Inserir(Venda venda)
        {
            return new VendaService().Inserir(venda);
        }

        public List<Venda> ConsultarTudo()
        {
            return new VendaService().ConsultarTudo();
        }
    }
}
