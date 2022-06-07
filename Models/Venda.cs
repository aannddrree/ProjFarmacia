using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Medicamento Medicamento { get; set; }
        public DateTime DtVenda { get; set; }

        public override string ToString()
        {
            return "Id: " + this.Id + "\nCliente:\n" + this.Cliente;
        }
    }
}
