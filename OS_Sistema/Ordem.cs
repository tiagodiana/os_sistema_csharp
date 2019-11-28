using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace OS_Sistema
{
    class Ordem: Conexao
    {
        private int id_os;
        private string tipo, marca, modelo, num_serie, defeito, solucao;
        private decimal valor;
        public string data = DateTime.Now.ToString();
        

        public Ordem()
        {

        }
        //
        //METODO CONSTRUTOR PARA EDITAR E BUSCAR TODAS AS OS
        //
        public Ordem(int id_os)
        {
            this.id_os = id_os;
        }
        //
        //METODO CONSTRUTOR PARA CRIAR ORDEM
        //
        public Ordem(string tipo, string marca, 
            string modelo, string num_serie, 
            string defeito,string solucao, decimal valor)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.modelo = modelo;
            this.num_serie = num_serie;
            this.defeito = defeito;
            this.solucao = solucao;
            this.valor = valor;
        }
        //
        //METODO CONSTRUTOR PARA EDITAR OS
        //
        public Ordem(int id_os, string tipo, string marca,
            string modelo, string num_serie,
            string defeito, string solucao, decimal valor)
        {
            this.id_os = id_os;
            this.tipo = tipo;
            this.marca = marca;
            this.modelo = modelo;
            this.num_serie = num_serie;
            this.defeito = defeito;
            this.solucao = solucao;
            this.valor = valor;
        }
        //
        //FUNÇÃO PARA SALVAR UMA NOVA ORDEM DE SERVIÇO
        //
        public bool novaOrdem(int id_cliente)
        {
            conectar();
            string sql = "INSERT INTO ordem VALUES(0, @tipo, @marca, @modelo, @num_serie, @defeito, @solucao, @valor, 0, @id_cliente, @data_entrada, null)";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@tipo", tipo));
            parametros.Add(new MySqlParameter("@marca", marca));
            parametros.Add(new MySqlParameter("@modelo", modelo));
            parametros.Add(new MySqlParameter("@num_serie", num_serie));
            parametros.Add(new MySqlParameter("@defeito", defeito));
            parametros.Add(new MySqlParameter("@solucao", solucao));
            parametros.Add(new MySqlParameter("@valor", valor));
            parametros.Add(new MySqlParameter("@id_cliente", id_cliente));
            //DateTime.Parse() converte a data para o formato Mysql
            parametros.Add(new MySqlParameter("@data_entrada", DateTime.Parse(data)));
            bool retorno = executarSQL(sql, parametros);
            desconectar();
            return retorno;
        }
        //
        //BUSCANDO ORDEM DE SERVIÇO PELO ID
        //
        public DataTable buscarOrdem()
        {
            conectar();
            string sql = "SELECT * FROM ordem INNER JOIN clientes ON ordem.id_cliente = clientes.id where id_os = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id_os));
            DataTable dados = consulta(sql, parametros);
            desconectar();
            return dados;
        }
        //
        //FINALIZANDO ORDEM DE SERVIÇO
        //
        public bool finalizarOrdem()
        {
            conectar();
            string sql = "UPDATE ordem SET status = 1, data_saida = @data WHERE id_os = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id_os));
            parametros.Add(new MySqlParameter("@data", DateTime.Parse(data)));
            bool retorno = executarSQL(sql, parametros);
            return retorno;
        }
        //
        //ALTERANDO ORDEM DE SERVIÇO
        //
        public bool alterarOrdem()
        {
            conectar();
            string sql = "UPDATE ordem SET tipo = @tipo, marca= @marca, modelo = @modelo, num_serie = @num_serie, defeito = @defeito, solucao = @solucao, valor = @valor WHERE id_os = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@tipo", tipo));
            parametros.Add(new MySqlParameter("@marca", marca));
            parametros.Add(new MySqlParameter("@modelo", modelo));
            parametros.Add(new MySqlParameter("@num_serie", num_serie));
            parametros.Add(new MySqlParameter("@defeito", defeito));
            parametros.Add(new MySqlParameter("@solucao", solucao));
            parametros.Add(new MySqlParameter("@valor", valor));
            parametros.Add(new MySqlParameter("@id",id_os));
            bool retorno = executarSQL(sql, parametros);
            desconectar();
            return retorno;
        }
        //
        //DELETANDO ORDEM DE SERIVÇO
        //
        public bool deltarOrdem()
        {
            conectar();
            string sql = "DELETE FROM ordem WHERE id_os = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id_os));
            bool retorno = executarSQL(sql, parametros);
            desconectar();
            return retorno;
        }
    }
}
