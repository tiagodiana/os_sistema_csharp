using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Importando biblioteca do MySql
using MySql.Data.MySqlClient;
//Biblioteca para DataTable
using System.Data;

namespace OS_Sistema
{
    public class Conexao
    {
        /*Somente a classe tem acesso aos atributos private*/
        private string servername;
        private string username;
        private string password;
        private string dbname;
        private string port;

        private MySqlConnection conexao;


        //Método construtor

        public Conexao()
        {
            this.servername = "localhost";
            this.username = "root";
            this.password = "";
            this.dbname = "os";
            this.port = "3306";
        }
        public Conexao(string servername, string username, string password, string dbname, string port)
        {
            this.servername = servername;
            this.username = username;
            this.password = password;
            this.dbname = dbname;
            this.port = port;
        }

        public bool conectar()
        {

            string informacoes = "SERVER=" + servername + ";";
            informacoes += "DATABASE=" + dbname + ";";
            informacoes += "UID=" + username + ";";
            informacoes += "PASSWORD=" + password + ";";
            informacoes += "PORT=" + port + ";";

            conexao = new MySqlConnection(informacoes);
            try
            {
                conexao.Open();
                return true;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                return false;
            }
        }

        protected bool executarSQL(string sql, List<MySqlParameter> valores)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                if (valores != null)
                {
                    comando.Parameters.AddRange(valores.ToArray<MySqlParameter>());
                }
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                return false;
            }
        }

        protected DataTable consulta(string sql, List<MySqlParameter> valores)
        {
            try
            {
                MySqlDataAdapter comando = new MySqlDataAdapter(sql, conexao);
                if (valores != null)
                {
                    comando.SelectCommand.Parameters.AddRange(valores.ToArray<MySqlParameter>());
                }
                DataTable data = new DataTable();
                comando.Fill(data);
                return data;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                return null;
            }
        }



        protected void desconectar()
        {
            //Fechando conexão de banco de dados

            conexao.Close();
        }
    }
}
    

