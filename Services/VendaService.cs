using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Services
{
    public class VendaService
    {
        string strCon = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\Banco\dbfarmacia.mdf;";
        SqlConnection conn;

        public VendaService()
        {
            //Abre a conexão
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        public bool Inserir(Venda venda)
        {
            string strInsert = "insert into Venda (IdCliente, IdFuncionario, IdMedicamento, Data) values (@IdCliente, @IdFuncionario, @IdMedicamento, @Data)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@IdCliente", InserirCliente(venda)));
            commandInsert.Parameters.Add(new SqlParameter("@IdFuncionario", InserirFuncionario(venda)));
            commandInsert.Parameters.Add(new SqlParameter("@IdMedicamento", InserirMedicamento(venda)));
            commandInsert.Parameters.Add(new SqlParameter("@Data", venda.DtVenda));

            commandInsert.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        private int InserirCliente(Venda venda)
        {
            string strInsert = "insert into Cliente (Nome, Telefone) values (@Nome, @Telefone); SELECT CAST(scope_identity() AS int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", venda.Cliente.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", venda.Cliente.Telefone));

            return (Int32)commandInsert.ExecuteScalar();
        }

        private int InserirFuncionario(Venda venda)
        {
            string strInsert = "insert into Funcionario (Nome, Telefone) values (@Nome, @Telefone); SELECT CAST(scope_identity() AS int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", venda.Funcionario.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", venda.Funcionario.Telefone));

            return (Int32)commandInsert.ExecuteScalar();
        }

        private int InserirMedicamento(Venda venda)
        {
            string strInsert = "insert into Medicamento (Descricao) values (@Descricao); SELECT CAST(scope_identity() AS int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Descricao", venda.Medicamento.Descricao));

            return (Int32)commandInsert.ExecuteScalar();
        }


        public List<Venda> ConsultarTudo()
        {
            List<Venda> vendas = new List<Venda>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select v.Id Id, ");
            sb.Append("       c.Nome NomeCliente,  ");
            sb.Append("       f.Nome NomeFuncionario,  ");
            sb.Append("       m.Descricao Medicamento,  ");
            sb.Append("       v.Data Data");
            sb.Append(" from  Venda v, ");
            sb.Append("       Funcionario f, ");
            sb.Append("       Cliente c, ");
            sb.Append("       Medicamento m ");
            sb.Append(" where v.IdCliente = c.Id ");
            sb.Append("   and v.IdFuncionario = f.Id ");
            sb.Append("   and v.IdMedicamento = m.Id ");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Venda venda = new Venda();

                venda.Id = Convert.ToInt32(dr["Id"]);
                venda.Cliente = new Cliente() { Nome = dr["NomeCliente"].ToString() };
                venda.Funcionario = new Funcionario() { Nome = dr["NomeFuncionario"].ToString() };
                venda.Medicamento = new Medicamento() { Descricao = dr["Medicamento"].ToString() };
                venda.DtVenda = DateTime.Parse(dr["Data"].ToString());
                vendas.Add(venda);
            }
            return vendas;
        }
    }
}
