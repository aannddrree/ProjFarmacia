using System;

namespace Models
{
    public abstract class Pessoa
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return "ID: " + this.Id + "\nNome: " + this.Nome;
        }

    }
}
