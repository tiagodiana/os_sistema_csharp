using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace OS_Sistema
{
    class Cliente: Conexao
    {
        private int id_cliente;
        private string nome;
        private string cpf;
        private string tel;
        private string cel;
        private string rua;
        private string bairro;
        private string cidade;
        private string estado;
        private string cep;

        public Cliente()
        {

        }
        //
        //METÓDO CONSTRUTOR PARA EDIÇÃO
        //
        public Cliente(int id_cliente, string nome, string cpf, string tel,
            string cel, string rua, string bairro,
            string cidade, string estado, string cep)
        {
            this.id_cliente = id_cliente;
            this.nome = nome;
            this.cpf = cpf;
            this.tel = tel;
            this.cel = cel;
            this.rua = rua;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
        }
        //
        //METODO CONSTRUTOS PARA BUSCAR CLIENTE PELO CPF
        //
        public Cliente(string cpf)
        {
            this.cpf = cpf;
        }
        //
        //METDO CONSTRUTOR PARA INSERIR CLIENTE
        public Cliente(string nome, string cpf, string tel, 
            string cel, string rua, string bairro, 
            string cidade, string estado, string cep)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.tel = tel;
            this.cel = cel;
            this.rua = rua;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
        }
        //
        // CADASTRANDO CLIENTE
        //
        public bool cadastrar()
        {
            conectar();
            string sql = "INSERT INTO clientes VALUES(0, @nome, @cpf, @tel, @cel, @rua, @bairro, @cidade, @estado, @cep)";
            //Criando lista de parâmetros
            List<MySqlParameter> parametros = new  List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@nome", nome));
            parametros.Add(new MySqlParameter("@cpf", cpf));
            parametros.Add(new MySqlParameter("@tel", tel));
            parametros.Add(new MySqlParameter("@cel", cel));
            parametros.Add(new MySqlParameter("@rua", rua));
            parametros.Add(new MySqlParameter("@bairro", bairro));
            parametros.Add(new MySqlParameter("@cidade", cidade));
            parametros.Add(new MySqlParameter("@estado", estado));
            parametros.Add(new MySqlParameter("@cep", cep));
            bool retorno = executarSQL(sql, parametros);
            desconectar();
            return retorno;
        }
        //
        //BUSCANDO TODOS OS CLIENTES
        //
        public DataTable todosClientes()
        {
            conectar();
            string sql = "SELECT * FROM clientes order by nome";
            DataTable dados = consulta(sql, null);
            desconectar();
            return dados;
        }
        //
        //BUSCANDO PELO ID
        //
        public DataTable buscarCPF()
        {
            conectar();
            string sql = "SELECT * FROM clientes WHERE cpf LIKE @cpf";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@cpf", cpf));
            DataTable dados = consulta(sql, parametros);
            desconectar();
            return dados;
        }
        //
        //ALTERANDO DADOS DO CLIENTE
        //
        public bool alterarCliente()
        {
            conectar();
            string sql = "UPDATE clientes SET nome = @nome, cpf = @cpf, telefone = @telefone, celular = @celular, rua = @rua, bairro = @bairro, cidade = @cidade, estado = @estado, CEP = @cep WHERE id = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@nome", nome));
            parametros.Add(new MySqlParameter("@cpf", cpf));
            parametros.Add(new MySqlParameter("@telefone", tel));
            parametros.Add(new MySqlParameter("@celular", cel));
            parametros.Add(new MySqlParameter("@rua", rua));
            parametros.Add(new MySqlParameter("@bairro", bairro));
            parametros.Add(new MySqlParameter("@cidade", cidade));
            parametros.Add(new MySqlParameter("@estado", estado));
            parametros.Add(new MySqlParameter("@cep", cep));
            parametros.Add(new MySqlParameter("@id", id_cliente));
            bool retorno = executarSQL(sql, parametros);
            desconectar();
            return retorno;
        }
    }
}
